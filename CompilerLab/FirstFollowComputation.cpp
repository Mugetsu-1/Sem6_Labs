#include <iostream>
#include <map>
#include <set>
#include <vector>
#include <cctype>
using namespace std;

map<char, vector<string>> gram;
map<char, set<char>> fst, flw;

void getFirst(char c) {
    for (auto p : gram[c]) {
        if (!isupper(p[0])) fst[c].insert(p[0]);
        else { getFirst(p[0]); for (char x : fst[p[0]]) fst[c].insert(x); }
    }
}

void getFollow(char c, char start) {
    if (c == start) flw[c].insert('$');
    for (auto p : gram) for (auto prod : p.second) for (size_t i = 0; i < prod.length(); i++) {
        if (prod[i] == c) {
            if (i + 1 < prod.length()) {
                char next = prod[i + 1];
                if (!isupper(next)) flw[c].insert(next);
                else for (char x : fst[next]) if (x != 'e') flw[c].insert(x);
            } else if (p.first != c) for (char x : flw[p.first]) flw[c].insert(x);
        }
    }
}

int main() {
    int n; cout << "Enter rule count: "; cin >> n;
    cout << "Enter rules (e.g., E TR):\n";
    char start;
    for (int i = 0; i < n; i++) {
        char h; string b; cin >> h >> b;
        if (i == 0) start = h;
        gram[h].push_back(b);
    }
    for (auto p : gram) getFirst(p.first);
    for (auto p : gram) getFollow(p.first, start);

    cout << "\nFIRST Sets:\n";
    for (auto p : fst) { cout << "FIRST(" << p.first << ") = { "; for (char x : p.second) cout << x << " "; cout << "}\n"; }
    cout << "\nFOLLOW Sets:\n";
    for (auto p : flw) { cout << "FOLLOW(" << p.first << ") = { "; for (char x : p.second) cout << x << " "; cout << "}\n"; }

    cout << "\nLab No_Q.: 8 | Name: Saugat Bikram Thapa | Roll No./Sec: 80117731/A\n";
    return 0;
}