#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

int main() {
    string in, stk = "";
    cout << "Enter input expression (e.g. i+i): "; cin >> in; in += "$";
    cout << left << setw(12) << "Stack" << setw(12) << "Input" << "Action\n";
    for (size_t i = 0; i < in.length(); ) {
        cout << setw(12) << stk << setw(12) << in.substr(i) << "Shift\n";
        stk += in[i++];
        if (stk.back() == 'i') {
            cout << setw(12) << stk << setw(12) << in.substr(i) << "Reduce E -> id\n";
            stk.back() = 'E';
        }
        if (stk.size() >= 3 && stk.substr(stk.size() - 3) == "E+E") {
            cout << setw(12) << stk << setw(12) << in.substr(i) << "Reduce E -> E+E\n";
            stk.erase(stk.size() - 3); stk += 'E';
        }
    }
    cout << (stk == "E$" ? "ACCEPTED\n" : "REJECTED\n");

    cout << "\nLab No_Q.: 11 | Name: Saugat Bikram Thapa | Roll No./Sec: 80117731/A\n";
    return 0;
}