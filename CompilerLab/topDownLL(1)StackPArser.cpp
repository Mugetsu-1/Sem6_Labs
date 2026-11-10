#include <iostream>
#include <stack>
#include <string>
#include <map>
using namespace std;

int main() {
    string in; cout << "Enter input expression (e.g. i+i): "; cin >> in; in += "$";
    map<pair<char, char>, string> M = {{{  'E','i'}, "TR"}, {{'R','+'}, "+TR"}, {{'R','$'}, "e"}, {{'T','i'}, "i"}};
    stack<char> st; st.push('$'); st.push('E');
    size_t ip = 0;
    while (!st.empty()) {
        char top = st.top(); st.pop();
        if (top == in[ip]) ip++;
        else if (M.count({top, in[ip]})) {
            string p = M[{top, in[ip]}];
            if (p != "e") for (int k = p.length() - 1; k >= 0; k--) st.push(p[k]);
        } else { cout << "Parsing Failed!\n"; return 0; }
    }
    cout << "String Successfully Parsed!\n";

    cout << "\nLab No_Q.: 10 | Name: Saugat Bikram Thapa | Roll No./Sec: 80117731/A\n";
    return 0;
}