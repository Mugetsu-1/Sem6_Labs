#include <iostream>
#include <string>
using namespace std;

int main() {
    string s;
    cout << "Enter string: ";
    cin >> s;
    int state = 0; // 0: q0, 1: q1, 2: qf
    for (char c : s) {
        if (state == 0) state = (c == '0') ? 1 : 0;
        else if (state == 1) state = (c == '0') ? 1 : 2;
        else if (state == 2) state = (c == '0') ? 1 : 0;
    }
    cout << (state == 2 ? "Accepted" : "Rejected") << endl;
    
    cout << "\nLab No_Q.: 1(b) | Name: Saugat Bikram Thapa | Roll No./Sec: 80117731/A\n";
    return 0;
}