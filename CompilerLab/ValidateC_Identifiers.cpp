#include <iostream>
#include <string>
#include <set>
#include <cctype>
using namespace std;

int main() {
    string s;
    cout << "Enter string: ";
    cin >> s;
    set<string> kw = {
        "auto","break","case","char","const","continue","default","do","double",
        "else","enum","extern","float","for","goto","if","int","long","register",
        "return","short","signed","sizeof","static","struct","switch","typedef",
        "union","unsigned","void","volatile","while"
    };

    if (kw.count(s)) {
        cout << "Reserved Keyword\n";
    } else if (s.empty()) {
        cout << "Invalid Identifier: Empty input.\n";
    } else if (!(isalpha((unsigned char)s[0]) || s[0] == '_')) {
        cout << "Invalid Identifier: Must start with letter or underscore.\n";
    } else {
        for (char c : s) {
            if (!(isalnum((unsigned char)c) || c == '_')) {
                cout << "Invalid Identifier: Contains invalid character '" << c << "'\n";
                cout << "\nLab No_Q.: 4 | Name: Saugat Bikram Thapa | Roll No./Sec: 80117731/A\n";
                return 0;
            }
        }
        cout << "Valid Identifier\n";
    }

    cout << "\nLab No_Q.: 4 | Name: Saugat Bikram Thapa | Roll No./Sec: 80117731/A\n";
    return 0;
}
