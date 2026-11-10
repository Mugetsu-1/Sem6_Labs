#include <iostream>
#include <vector>
#include <string>
#include <unordered_map>

struct Quadruple { std::string op, arg1, arg2, result; };

std::unordered_map<std::string, int> stackOffset;
int currentOffset = 2;

int getOffset(const std::string& var) {
    if (!stackOffset.count(var)) {
        stackOffset[var] = currentOffset;
        currentOffset += 2;
    }
    return stackOffset[var];
}

void generate8086(const std::vector<Quadruple>& quads) {
    std::cout << "PUSH BP\nMOV BP, SP\nSUB SP, 16\n";
    for (const auto& q : quads) {
        if (q.op == "+") {
            int off1 = getOffset(q.arg1);
            int off2 = getOffset(q.arg2);
            int offRes = getOffset(q.result);

            std::cout << "MOV AX, [BP-" << off1 << "]\n";
            std::cout << "ADD AX, [BP-" << off2 << "]\n";
            std::cout << "MOV [BP-" << offRes << "], AX\n";
        } else if (q.op == "*") {
            int off1 = getOffset(q.arg1);
            int off2 = getOffset(q.arg2);
            int offRes = getOffset(q.result);

            std::cout << "MOV AX, [BP-" << off1 << "]\n";
            std::cout << "IMUL WORD PTR [BP-" << off2 << "]\n";
            std::cout << "MOV [BP-" << offRes << "], AX\n";
        } else if (q.op == "ifFalse") {
            int off = getOffset(q.arg1);
            std::cout << "MOV AX, [BP-" << off << "]\nCMP AX, 0\nJE " << q.result << "\n";
        }
    }
    std::cout << "MOV SP, BP\nPOP BP\nRET\n";
}

int main() {
    std::vector<Quadruple> quads = {
        {"+", "a", "b", "t1"},
        {"*", "a", "b", "t2"},
        {"ifFalse", "t1", "", "L1"}
    };

    std::cout << "Input TAC Quadruples:\n";
    std::cout << "1. t1 = a + b\n";
    std::cout << "2. t2 = a * b\n";
    std::cout << "3. ifFalse t1 goto L1\n\n";

    std::cout << "Generated 8086 Assembly Code:\n";
    generate8086(quads);

    std::cout << "\nLab No. 23 Name: Saugat Bikram Thapa /Roll No.: 80117731/ Section: A\n";
    return 0;
}