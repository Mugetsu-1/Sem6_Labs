#include <iostream>
#include <vector>
#include <set>
#include <map>
#include <string>
#include <iomanip>

using namespace std;

struct Production {
    char lhs;
    string rhs;
};

// Grammar from PDF: S->E, E->E+T|T, T->T*F|F, F->(E)|id (id represented as 'i')
vector<Production> grammar = {
    {'Z', "S"},   // 0: Z -> S (Augmented)
    {'S', "E"},   // 1: S -> E
    {'E', "E+T"}, // 2: E -> E+T
    {'E', "T"},   // 3: E -> T
    {'T', "T*F"}, // 4: T -> T*F
    {'T', "F"},   // 5: T -> F
    {'F', "(E)"}, // 6: F -> (E)
    {'F', "i"}    // 7: F -> id ('i')
};

struct Item {
    int rule;
    int dot;
    bool operator<(const Item& o) const {
        if (rule != o.rule) return rule < o.rule;
        return dot < o.dot;
    }
    bool operator==(const Item& o) const {
        return rule == o.rule && dot == o.dot;
    }
};

typedef set<Item> State;

// Core Function 1: CLOSURE(I)
State CLOSURE(State I) {
    State closure = I;
    bool added = true;
    while (added) {
        added = false;
        State temp = closure;
        for (auto it : temp) {
            string rhs = grammar[it.rule].rhs;
            if (it.dot < rhs.length()) {
                char B = rhs[it.dot];
                for (size_t r = 0; r < grammar.size(); r++) {
                    if (grammar[r].lhs == B) {
                        Item newItem = {(int)r, 0};
                        if (closure.find(newItem) == closure.end()) {
                            closure.insert(newItem);
                            added = true;
                        }
                    }
                }
            }
        }
    }
    return closure;
}

// Core Function 2: GOTO(I, X)
State GOTO(State I, char X) {
    State J;
    for (auto it : I) {
        string rhs = grammar[it.rule].rhs;
        if (it.dot < rhs.length() && rhs[it.dot] == X) {
            J.insert({it.rule, it.dot + 1});
        }
    }
    return CLOSURE(J);
}

int main() {
    vector<State> C;
    map<pair<int, char>, int> GOTO_Table;
    map<pair<int, char>, string> ACTION_Table;

    // 1. Generate Canonical Collection C = { I0, I1, ... In }
    State I0 = CLOSURE({{0, 0}});
    C.push_back(I0);

    string symbols = "SETF+*()i";
    char terminals[] = {'i', '+', '*', '(', ')', '$'};
    char nonTerminals[] = {'S', 'E', 'T', 'F'};

    for (size_t i = 0; i < C.size(); i++) {
        for (char X : symbols) {
            State nextState = GOTO(C[i], X);
            if (!nextState.empty()) {
                int found = -1;
                for (size_t j = 0; j < C.size(); j++) {
                    if (C[j] == nextState) { found = j; break; }
                }
                if (found == -1) {
                    C.push_back(nextState);
                    found = C.size() - 1;
                }
                GOTO_Table[{i, X}] = found;
            }
        }
    }

    // Print Canonical LR(0) Items
    cout << "Canonical Collection of LR(0) Items (" << C.size() << " States):\n";
    for (size_t i = 0; i < C.size(); i++) {
        cout << "I" << i << ":\n";
        for (auto item : C[i]) {
            string r = grammar[item.rule].rhs;
            string dotted = r.substr(0, item.dot) + "." + r.substr(item.dot);
            cout << "  " << grammar[item.rule].lhs << " -> " << dotted << "\n";
        }
    }

    // 2. Compute SLR(1) ACTION Table using FOLLOW sets
    map<char, vector<char>> FOLLOW = {
        {'S', {'$'}},
        {'E', {'+', ')', '$'}},
        {'T', {'+', '*', ')', '$'}},
        {'F', {'+', '*', ')', '$'}}
    };

    for (size_t i = 0; i < C.size(); i++) {
        for (auto item : C[i]) {
            string rhs = grammar[item.rule].rhs;
            if (item.dot == rhs.length()) { // Complete Item -> Reduce action
                if (item.rule == 0) {
                    ACTION_Table[{i, '$'}] = "acc";
                } else {
                    char A = grammar[item.rule].lhs;
                    for (char a : FOLLOW[A]) {
                        ACTION_Table[{i, a}] = "r" + to_string(item.rule);
                    }
                }
            } else { // Shift action
                char a = rhs[item.dot];
                if (GOTO_Table.count({i, a})) {
                    int j = GOTO_Table[{i, a}];
                    if (a == 'i' || a == '+' || a == '*' || a == '(' || a == ')') {
                        ACTION_Table[{i, a}] = "s" + to_string(j);
                    }
                }
            }
        }
    }

    // 3. Print Formatted ACTION and GOTO Table
    cout << "\n--- SLR(1) Parsing Table ---\n";
    cout << left << setw(6) << "State";
    for (char t : terminals) cout << setw(6) << t;
    for (char nt : nonTerminals) cout << setw(6) << nt;
    cout << "\n";

    for (size_t i = 0; i < C.size(); i++) {
        cout << setw(6) << i;
        for (char t : terminals) {
            cout << setw(6) << (ACTION_Table.count({i, t}) ? ACTION_Table[{i, t}] : "");
        }
        for (char nt : nonTerminals) {
            cout << setw(6) << (GOTO_Table.count({i, nt}) ? to_string(GOTO_Table[{i, nt}]) : "");
        }
        cout << "\n";
    }

    cout << "\nLab No_Q.: 12 | Name: Saugat Bikram Thapa | Roll No./Sec: 80117731/A\n";
    return 0;
}