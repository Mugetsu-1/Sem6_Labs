#include <iostream>
#include <string>
using namespace std;

int main() {
    string s;
    cout << "Enter line: ";
    getline(cin, s);
    int n = s.length();

    if (n >= 2 && s[0] == '/' && s[1] == '/')
        cout << "comment (Single-line)\n";
    else if (n >= 4 && s[0] == '/' && s[1] == '*' && s[n-2] == '*' && s[n-1] == '/')
        cout << "comment (Multi-line)\n";
    else
        cout << "not a comment\n";

    cout << "\nLab No_Q.: 3 | Name: Saugat Bikram Thapa | Roll No./Sec: 80117731/A\n";
    return 0;
}