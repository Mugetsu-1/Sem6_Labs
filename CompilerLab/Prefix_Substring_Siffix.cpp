#include <iostream>
#include <string>
#include <set>
using namespace std;

int main() {
    string s;
    cout << "Enter string: ";
    cin >> s;
    int n = s.length();

    cout << "\nPrefixes\n";
    cout << "Proper Prefixes: ";
    for (int i = 0; i < n; i++) cout << "\"" << s.substr(0, i) << "\" ";
    cout << "\nImproper Prefix: \"" << s << "\"\n";

    cout << "\nSuffixes\n";
    cout << "Proper Suffixes: ";
    for (int i = 1; i <= n; i++) cout << "\"" << s.substr(i) << "\" ";
    cout << "\nImproper Suffix: \"" << s << "\"\n";

    cout << "\nSubstrings\n";
    set<string> sub;
    for (int i = 0; i < n; i++)
        for (int len = 1; len <= n - i; len++) sub.insert(s.substr(i, len));
    for (auto str : sub) cout << str << " ";
    cout << endl;

    cout << "\nLab No_Q.: 2 | Name: Saugat Bikram Thapa | Roll No./Sec: 80117731/A\n";
    return 0;
}