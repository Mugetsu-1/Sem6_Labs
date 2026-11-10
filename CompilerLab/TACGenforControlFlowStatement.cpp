#include <iostream>
#include <vector>
#include <string>

struct Quadruple { std::string op, arg1, arg2, result; };
std::vector<Quadruple> quadList;
int labelCount = 1;

std::string newLabel() { return "L" + std::to_string(labelCount++); }

std::vector<int> make_list(int quad_index) {
    return {quad_index};
}

std::vector<int> merge_list(const std::vector<int>& list1, const std::vector<int>& list2) {
    std::vector<int> result = list1;
    result.insert(result.end(), list2.begin(), list2.end());
    return result;
}

void backpatch(const std::vector<int>& list, const std::string& label) {
    for (int quadIdx : list) {
        quadList[quadIdx].result = label;
    }
}

void emit(std::string op, std::string arg1, std::string arg2, std::string result) {
    quadList.push_back({op, arg1, arg2, result});
}

int main() {
    std::cout << "Input Control Flow Expression: if (a < b && c > d) then S1 else S2\n\n";

    int q1 = quadList.size(); emit("ifFalse", "a < b", "", "");
    std::string labelNextCond = newLabel();
    backpatch(make_list(q1), labelNextCond);

    int q2 = quadList.size(); emit("ifFalse", "c > d", "", "");
    std::string labelThen = newLabel();
    std::string labelElse = newLabel();

    int qGoto = quadList.size(); emit("goto", "", "", "");

    backpatch(make_list(q2), labelElse);
    backpatch(make_list(qGoto), labelThen);

    std::cout << "Generated Control Flow Quadruples:\n";
    std::cout << "Index\tOp\tArg1\tArg2\tResult\n";
    for (size_t i = 0; i < quadList.size(); ++i) {
        std::cout << i << "\t" << quadList[i].op << "\t" << quadList[i].arg1 << "\t"
                  << quadList[i].arg2 << "\t" << quadList[i].result << "\n";
    }

    std::cout << "\nLab No. 21 Name: Saugat Bikram Thapa /Roll No.: 80117731/ Section: A\n";
    return 0;
}