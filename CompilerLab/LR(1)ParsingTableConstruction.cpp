#include <iostream>
#include <vector>
#include <set>
#include <map>
#include <string>
#include <iomanip>
#include <cctype>

using namespace std;

struct Rule { char lhs; string rhs; };
vector<Rule> gram;

struct Item {
    int r, dot;
    char la;
    bool operator<(const Item& o) const {
        if (r != o.r) return r < o.r;
        if (dot != o.dot) return dot < o.dot;
        return la < o.la;
    }
    bool operator==(const Item& o) const {
        return r == o.r && dot == o.dot && la == o.la;
    }
};
typedef set<Item> State;

set<char> getFirst(char c) {
    set<char> res;
    if (!isupper(c)) { res.insert(c); return res; }
    for (auto &rule : gram) {
        if (rule.lhs == c) {
            if (rule.rhs.empty() || rule.rhs == "e") res.insert('e');
            else if (!isupper(rule.rhs[0])) res.insert(rule.rhs[0]);
            else if (rule.rhs[0] != c) {
                set<char> sub = getFirst(rule.rhs[0]);
                res.insert(sub.begin(), sub.end());
            }
        }
    }
    return res;
}

set<char> getFirstString(string str, char la) {
    set<char> res;
    if (str.empty()) { res.insert(la); return res; }
    for (char c : str) {
        set<char> f = getFirst(c);
        bool hasEps = false;
        for (char x : f) {
            if (x == 'e') hasEps = true;
            else res.insert(x);
        }
        if (!hasEps) return res;
    }
    res.insert(la);
    return res;
}

State CLOSURE(State I) {
    State cl = I;
    bool add = true;
    while (add) {
        add = false;
        State tmp = cl;
        for (auto it : tmp) {
            string rhs = gram[it.r].rhs;
            if (it.dot < (int)rhs.size()) {
                char B = rhs[it.dot];
                if (isupper(B)) {
                    string beta = rhs.substr(it.dot + 1);
                    set<char> las = getFirstString(beta, it.la);
                    for (size_t i = 0; i < gram.size(); i++) {
                        if (gram[i].lhs == B) {
                            for (char b : las) {
                                if (cl.insert({(int)i, 0, b}).second) add = true;
                            }
                        }
                    }
                }
            }
        }
    }
    return cl;
}

State GOTO(State I, char X) {
    State J;
    for (auto it : I) {
        string rhs = gram[it.r].rhs;
        if (it.dot < (int)rhs.size() && rhs[it.dot] == X) {
            J.insert({it.r, it.dot + 1, it.la});
        }
    }
    return CLOSURE(J);
}

int main() {
    int n;
    cout << "Enter number of rules: ";
    if (!(cin >> n)) return 0;
    cout << "Enter rules (e.g., S CC or C cC or C d):\n";

    gram.push_back({'Z', ""});
    set<char> term, nonterm;

    for (int i = 0; i < n; i++) {
        char h; string b;
        cin >> h >> b;
        if (i == 0) gram[0].rhs = string(1, h);
        gram.push_back({h, b});
        nonterm.insert(h);
        for (char c : b) {
            if (isupper(c)) nonterm.insert(c);
            else term.insert(c);
        }
    }
    term.insert('$');

    vector<State> C;
    C.push_back(CLOSURE({{(int)0, 0, '$'}}));

    map<pair<int, char>, int> gotoTbl;
    map<pair<int, char>, string> actTbl;

    string symbols = "";
    for (char c : nonterm) symbols += c;
    for (char c : term) if (c != '$') symbols += c;

    for (size_t i = 0; i < C.size(); i++) {
        for (char X : symbols) {
            State nxt = GOTO(C[i], X);
            if (!nxt.empty()) {
                int id = -1;
                for (size_t j = 0; j < C.size(); j++) {
                    if (C[j] == nxt) { id = j; break; }
                }
                if (id == -1) {
                    C.push_back(nxt);
                    id = C.size() - 1;
                }
                gotoTbl[{i, X}] = id;
            }
        }
    }

    cout << "\nLR(1) Items (" << C.size() << " States):\n";
    for (size_t i = 0; i < C.size(); i++) {
        cout << "I" << i << ":\n";
        for (auto it : C[i]) {
            string r = gram[it.r].rhs;
            cout << "  [" << gram[it.r].lhs << " -> " << r.substr(0, it.dot) << "." << r.substr(it.dot) << ", " << it.la << "]\n";
        }
    }

    for (size_t i = 0; i < C.size(); i++) {
        for (auto it : C[i]) {
            string r = gram[it.r].rhs;
            if (it.dot == (int)r.size()) {
                actTbl[{i, it.la}] = (it.r == 0) ? "acc" : "r" + to_string(it.r);
            } else if (!isupper(r[it.dot])) {
                char a = r[it.dot];
                if (gotoTbl.count({i, a})) {
                    actTbl[{i, a}] = "s" + to_string(gotoTbl[{i, a}]);
                }
            }
        }
    }

    cout << "\nLR(1) ACTION & GOTO Table:\n";
    cout << left << setw(8) << "State";
    for (char t : term) cout << setw(8) << t;
    for (char nt : nonterm) cout << setw(8) << nt;
    cout << "\n";

    for (size_t i = 0; i < C.size(); i++) {
        cout << setw(8) << i;
        for (char t : term) {
            cout << setw(8) << (actTbl.count({i, t}) ? actTbl[{i, t}] : "");
        }
        for (char nt : nonterm) {
            cout << setw(8) << (gotoTbl.count({i, nt}) ? to_string(gotoTbl[{i, nt}]) : "");
        }
        cout << "\n";
    }

    cout << "\nLab No_Q.: 13 | Name: Saugat Bikram Thapa | Roll No./Sec: 80117731/A\n";
    return 0;
}