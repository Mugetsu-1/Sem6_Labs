#include <iostream>
#include <string>
#include <map>
using namespace std;

void classify(string op, int line) {
    static map<string, string> type = {
        {"+","Arithmetic"}, {"-","Arithmetic"}, {"*","Arithmetic"}, {"/","Arithmetic"}, {"%","Arithmetic"},
        {"<","Relational"}, {">","Relational"}, {"<=","Relational"}, {">=","Relational"}, {"==","Relational"}, {"!=","Relational"},
        {"&&","Logical"}, {"||","Logical"}, {"!","Logical"},
        {"=","Assignment"}, {"+=","Assignment"}, {"-=","Assignment"}, {"*=","Assignment"}, {"/=","Assignment"}
    };
    if (type.count(op)) cout << "<" << op << ", " << type[op] << ", " << line << ">\n";
}

int main() {
    string s, lineText;
    int line = 1;
    cout << "Enter expression/file content (Ctrl+Z then Enter to stop):\n";

    while (getline(cin, lineText)) {
        s = lineText;
        for (size_t i = 0; i < s.length(); i++) {
        string two = s.substr(i, 2);
        if (two=="<="||two==">="||two=="=="||two=="!="||two=="&&"||two=="||"||two=="+="||two=="-="||two=="*="||two=="/=") {
            classify(two, line);
            i++;
        } else if (string("+-*/%=<>!").find(s[i]) != string::npos) {
            classify(s.substr(i, 1), line);
        } else if (s[i] == '&' || s[i] == '|') {
            cout << "Invalid Operator: " << s[i] << " at line " << line << "\n";
        }
        }
        line++;
    }

    cout << "\nLab No_Q.: 5 | Name: Saugat Bikram Thapa | Roll No./Sec: 80117731/A\n";
    return 0;
}
