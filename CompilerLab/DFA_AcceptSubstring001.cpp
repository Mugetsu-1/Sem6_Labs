#include <iostream>
#include <string>
using namespace std;

int main() {
    string s;
    cout << "Enter string: ";
    cin >> s;
    int state = 0; // 0: q0, 1: q1, 2: q2, 3: qf
    for (char c : s) {
        if (state == 0) state = (c == '0') ? 1 : 0;
        else if (state == 1) state = (c == '0') ? 2 : 0;
        else if (state == 2) state = (c == '0') ? 2 : ((c == '1') ? 3 : 0);
        else if (state == 3) state = 3;
    }
    cout << (state == 3 ? "Accepted" : "Rejected") << endl;
    
    cout << "\nLab No_Q.: 1(c) | Name: Saugat Bikram Thapa | Roll No./Sec: 80117731/A\n";
    return 0;
}