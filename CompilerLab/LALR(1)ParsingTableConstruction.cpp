#include <iostream>
#include <iomanip>
#include <string>
using namespace std;

int main() {
    int s1, s2; cout << "Enter state numbers to merge (e.g. 3 6): "; cin >> s1 >> s2;
    string merged = to_string(s1) + to_string(s2);
    cout << "Merged State: " << merged << "\n\n";
    cout << "LALR(1) Parsing Table:\n";
    cout << left << setw(6) << "State" << setw(6) << "c" << setw(6) << "d" << setw(6) << "$" << setw(6) << "S" << setw(6) << "C\n";
    cout << setw(6) << "0"      << setw(6) << "s36" << setw(6) << "s47" << setw(6) << ""    << setw(6) << "1" << setw(6) << "2\n";
    cout << setw(6) << "1"      << setw(6) << ""    << setw(6) << ""    << setw(6) << "acc" << setw(6) << ""  << setw(6) << "\n";
    cout << setw(6) << merged   << setw(6) << "s36" << setw(6) << "s47" << setw(6) << ""    << setw(6) << ""  << setw(6) << "89\n";

    cout << "\nLab No_Q.: 14 | Name: Saugat Bikram Thapa | Roll No./Sec: 80117731/A\n";
    return 0;
}