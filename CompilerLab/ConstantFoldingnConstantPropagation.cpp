#include <iostream>
#include <vector>
#include <string>
#include <unordered_map>
#include <cctype>

struct Quadruple { std::string op, arg1, arg2, result; };

bool isNumber(const std::string& s) {
    if (s.empty()) return false;
    for (char c : s) if (!isdigit(c) && c != '.') return false;
    return true;
}

void optimizeConstants(std::vector<Quadruple>& quadList) {
    std::unordered_map<std::string, double> constTable;
    bool modified = true;
    while (modified) {
        modified = false;
        for (auto& quad : quadList) {
            if (constTable.count(quad.arg1)) {
                quad.arg1 = std::to_string((int)constTable[quad.arg1]);
                modified = true;
            }
            if (constTable.count(quad.arg2)) {
                quad.arg2 = std::to_string((int)constTable[quad.arg2]);
                modified = true;
            }
            if (isNumber(quad.arg1) && isNumber(quad.arg2) && quad.op == "+") {
                double res = std::stod(quad.arg1) + std::stod(quad.arg2);
                quad.op = "=";
                quad.arg1 = std::to_string((int)res);
                quad.arg2 = "";
                constTable[quad.result] = res;
                modified = true;
            } else if (isNumber(quad.arg1) && isNumber(quad.arg2) && quad.op == "*") {
                double res = std::stod(quad.arg1) * std::stod(quad.arg2);
                quad.op = "=";
                quad.arg1 = std::to_string((int)res);
                quad.arg2 = "";
                constTable[quad.result] = res;
                modified = true;
            } else if (quad.op == "=" && !isNumber(quad.arg1)) {
                if (constTable.count(quad.result)) {
                    constTable.erase(quad.result);
                    modified = true;
                }
            }
        }
    }
}

int main() {
    std::vector<Quadruple> quadList = {
        {"*", "4", "5", "t1"},
        {"+", "t1", "10", "t2"},
        {"=", "y", "", "t2"}
    };

    std::cout << "Input TAC Quadruples before Optimization:\n";
    for (const auto& q : quadList) {
        std::cout << q.op << " " << q.arg1 << " " << q.arg2 << " -> " << q.result << "\n";
    }

    optimizeConstants(quadList);

    std::cout << "\nOptimized TAC Quadruples (Constant Folding & Propagation):\n";
    for (const auto& q : quadList) {
        std::cout << q.op << " " << q.arg1 << " " << q.arg2 << " -> " << q.result << "\n";
    }

    std::cout << "\nLab No. 24 Name: Saugat Bikram Thapa /Roll No.: 80117731/ Section: A\n";
    return 0;
}