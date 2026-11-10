#include <iostream>
#include <string>
using namespace std;

int main() {
    char A; string a, b, b1, b2;
    cout << "Left Recursion - Enter A, alpha, beta: ";
    cin >> A >> a >> b;
    cout << A << " -> " << b << A << "'\n" << A << "' -> " << a << A << "' | e\n\n";

    cout << "Left Factoring - Enter A, alpha, beta1, beta2: ";
    cin >> A >> a >> b1 >> b2;
    cout << A << " -> " << a << A << "'\n" << A << "' -> " << b1 << " | " << b2 << "\n";

    cout << "\nLab No_Q.: 7 | Name: Saugat Bikram Thapa | Roll No./Sec: 80117731/A\n";
    return 0;
}