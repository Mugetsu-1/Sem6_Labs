#include <iostream>
#include <vector>
#include <string>
#include <stack>
#include <cctype>

struct Quadruple { std::string op, arg1, arg2, result; };
std::vector<Quadruple> quadList;
int tempCount = 1;

std::string newTemp() { return "t" + std::to_string(tempCount++); }

int precedence(const std::string& op) {
    if (op == "==" || op == ">" || op == "<") return 1;
    if (op == "+" || op == "-") return 2;
    if (op == "*" || op == "/") return 3;
    return 0;
}

bool isoperator(const std::string& token) {
    return token == "+" || token == "-" || token == "*" || token == "/" || token == "==" || token == ">" || token == "<";
}

std::vector<std::string> shuntingYard(const std::vector<std::string>& tokens) {
    std::vector<std::string> output;
    std::stack<std::string> ops;
    for (const auto& token : tokens) {
        if (isalnum(token[0])) {
            output.push_back(token);
        } else if (token == "(") {
            ops.push(token);
        } else if (token == ")") {
            while (!ops.empty() && ops.top() != "(") {
                output.push_back(ops.top());
                ops.pop();
            }
            if (!ops.empty()) ops.pop();
        } else if (isoperator(token)) {
            while (!ops.empty() && precedence(ops.top()) >= precedence(token)) {
                output.push_back(ops.top());
                ops.pop();
            }
            ops.push(token);
        }
    }
    while (!ops.empty()) {
        output.push_back(ops.top());
        ops.pop();
    }
    return output;
}

void generateTACFromPostfix(const std::vector<std::string>& tokens) {
    std::stack<std::string> st;
    for (const auto& token : tokens) {
        if (isoperator(token)) {
            std::string arg2 = st.top(); st.pop();
            std::string arg1 = st.top(); st.pop();
            std::string t = newTemp();
            quadList.push_back({token, arg1, arg2, t});
            st.push(t);
        } else {
            st.push(token);
        }
    }
}

int main() {
    std::vector<std::string> infix = {"(", "a", "+", "b", ")", "*", "c", ">", "d"};
    std::cout << "Input Infix Expression: ( a + b ) * c > d\n\n";

    std::vector<std::string> postfix = shuntingYard(infix);
    generateTACFromPostfix(postfix);

    std::cout << "Generated TAC Quadruples:\n";
    std::cout << "Op\tArg1\tArg2\tResult\n";
    for (const auto& q : quadList) {
        std::cout << q.op << "\t" << q.arg1 << "\t" << q.arg2 << "\t" << q.result << "\n";
    }

    std::cout << "\nLab No. 20 Name: Saugat Bikram Thapa /Roll No.: 80117731/ Section: A\n";
    return 0;
}