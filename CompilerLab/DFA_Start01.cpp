#include <iostream>
#include <string>
using namespace std;

int main() {
    string s;
    cout << "Enter string: ";
    cin >> s;
    int state = 0; // 0: start, 1: got '0', 2: accepted (got '01'), 3: dead state
    for (char c : s) {
        if (state == 0) state = (c == '0') ? 1 : 3;
        else if (state == 1) state = (c == '1') ? 2 : 3;
        else if (state == 3) state = 3;
    }
    cout << (state == 2 ? "Accepted" : "Rejected") << endl;
    
    // Print required lab student details[cite: 1]
    cout << "\nLab No_Q.: 1(a) | Name: Saugat Bikram Thapa | Roll No./Sec: 80117731/A\n";
    return 0;
}