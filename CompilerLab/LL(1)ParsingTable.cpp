#include <iostream>
#include <vector>
#include <map>
#include <set>
#include <string>
#include <iomanip>
#include <cctype>

using namespace std;

map<char, vector<string>> gram;
map<char, set<char>> fst, flw;
map<pair<char, char>, string> tbl;

void getFirst(char c) {
    for (auto p : gram[c]) {
        if (!isupper(p[0])) fst[c].insert(p[0]);
        else {
            getFirst(p[0]);
            for (char x : fst[p[0]]) fst[c].insert(x);
        }
    }
}

void getFollow(char c, char start) {
    if (c == start) flw[c].insert('$');
    for (auto p : gram) {
        for (auto prod : p.second) {
            for (size_t i = 0; i < prod.length(); i++) {
                if (prod[i] == c) {
                    if (i + 1 < prod.length()) {
                        char next = prod[i + 1];
                        if (!isupper(next)) flw[c].insert(next);
                        else for (char x : fst[next]) if (x != 'e') flw[c].insert(x);
                    } else if (p.first != c) {
                        for (char x : flw[p.first]) flw[c].insert(x);
                    }
                }
            }
        }
    }
}

int main() {
    int n; cout << "Enter number of productions: "; cin >> n;
    cout << "Enter rules (use 'e' for epsilon, e.g., E TR or R +TR or R e):\n";
    char start = '\0';
    set<char> nts, ts;
    for (int i = 0; i < n; i++) {
        char h; string b; cin >> h >> b;
        if (i == 0) start = h;
        gram[h].push_back(b);
        nts.insert(h);
        for (char c : b) if (!isupper(c) && c != 'e') ts.insert(c);
    }
    ts.insert('$');

    for (char nt : nts) getFirst(nt);
    for (char nt : nts) getFollow(nt, start);

    for (auto p : gram) {
        char A = p.first;
        for (auto rhs : p.second) {
            set<char> targetFirst;
            if (!isupper(rhs[0])) targetFirst.insert(rhs[0]);
            else targetFirst = fst[rhs[0]];

            for (char a : targetFirst) {
                if (a != 'e') tbl[{A, a}] = string(1, A) + "->" + rhs;
                else {
                    for (char b : flw[A]) tbl[{A, b}] = string(1, A) + "->" + rhs;
                }
            }
        }
    }

    cout << "\nFIRST Sets:\n";
    for (char nt : nts) {
        cout << "FIRST(" << nt << ") = { ";
        for (char x : fst[nt]) cout << x << " ";
        cout << "}\n";
    }

    cout << "\nFOLLOW Sets:\n";
    for (char nt : nts) {
        cout << "FOLLOW(" << nt << ") = { ";
        for (char x : flw[nt]) cout << x << " ";
        cout << "}\n";
    }

    cout << "\nLL(1) Parsing Table:\n" << left << setw(8) << "NT";
    for (char t : ts) cout << setw(15) << t;
    cout << "\n";
    for (char nt : nts) {
        cout << setw(8) << nt;
        for (char t : ts) cout << setw(15) << (tbl.count({nt, t}) ? tbl[{nt, t}] : "-");
        cout << "\n";
    }

    cout << "\nLab No_Q.: 9 | Name: Saugat Bikram Thapa | Roll No./Sec: 80117731/A\n";
    return 0;
}