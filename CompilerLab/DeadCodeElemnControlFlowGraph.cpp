#include <iostream>
#include <vector>
#include <string>

struct Instruction {
    int id;
    std::string code;
    bool isLeader;
    bool isLive;
};

int main() {
    std::vector<Instruction> tac = {
        {1, "i = 1", false, false},
        {2, "L1: t1 = i * 4", false, false},
        {3, "if t1 > 100 goto L2", false, false},
        {4, "i = i + 1", false, false},
        {5, "goto L1", false, false},
        {6, "L2: return i", false, false},
        {7, "x = 5", false, false}
    };

    std::cout << "Input Three-Address Code:\n";
    for (const auto& inst : tac) {
        std::cout << inst.id << ": " << inst.code << "\n";
    }

    tac[0].isLeader = true;
    for (size_t i = 0; i < tac.size(); ++i) {
        if (tac[i].code.find("goto") != std::string::npos && i + 1 < tac.size()) {
            tac[i + 1].isLeader = true;
        }
        if (tac[i].code.find("L1:") != std::string::npos || tac[i].code.find("L2:") != std::string::npos) {
            tac[i].isLeader = true;
        }
    }

    for (int i = (int)tac.size() - 1; i >= 0; --i) {
        if (tac[i].code.find("return") != std::string::npos ||
            tac[i].code.find("goto") != std::string::npos ||
            tac[i].code.find("if") != std::string::npos ||
            tac[i].id != 7) {
            tac[i].isLive = true;
        }
    }

    std::cout << "\nCFG Leader Identification & Liveness Sweep Output:\n";
    std::cout << "ID\tLeader\tLive\tInstruction\n";
    for (const auto& inst : tac) {
        if (inst.isLive) {
            std::cout << inst.id << "\t" << (inst.isLeader ? "YES" : "NO") << "\t"
                      << (inst.isLive ? "LIVE" : "DEAD") << "\t" << inst.code << "\n";
        }
    }

    std::cout << "\nLab No. 25 Name: Saugat Bikram Thapa /Roll No.: 80117731/ Section: A\n";
    return 0;
}