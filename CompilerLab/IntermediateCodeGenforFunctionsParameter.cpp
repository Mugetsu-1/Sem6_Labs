#include <iostream>
#include <vector>
#include <string>
#include <unordered_map>

struct Quadruple { std::string op, arg1, arg2, result; };
std::vector<Quadruple> quadList;
std::unordered_map<std::string, int> funcSignatures;

void declare_function(const std::string& name, int paramCount) {
    funcSignatures[name] = paramCount;
    quadList.push_back({"FUNC_BEGIN", name, "", ""});
}

void call_function(const std::string& name, const std::vector<std::string>& args, const std::string& retTemp) {
    if (funcSignatures.count(name) && funcSignatures[name] != (int)args.size()) {
        std::cout << "Signature Error: " << name << " expects "
                  << funcSignatures[name] << " params, got " << args.size() << "\n";
        return;
    }
    for (const auto& arg : args) {
        quadList.push_back({"PARAM", arg, "", ""});
    }
    quadList.push_back({"CALL", name, std::to_string(args.size()), retTemp});
}

int main() {
    std::cout << "Input Declarations and Function Calls:\n";
    std::cout << "1. declare_function(\"foo\", 2)\n";
    std::cout << "2. call_function(\"foo\", {\"a\", \"b\"}, \"t1\")\n";
    std::cout << "3. call_function(\"foo\", {\"a\"}, \"t2\") [Mismatched Arguments]\n\n";

    declare_function("foo", 2);
    quadList.push_back({"RETURN", "x", "", ""});
    quadList.push_back({"FUNC_END", "foo", "", ""});

    call_function("foo", {"a", "b"}, "t1");
    quadList.push_back({"=", "t1", "", "x"});
    call_function("foo", {"a"}, "t2");

    std::cout << "\nGenerated TAC Quadruples:\n";
    std::cout << "Op\tArg1\tArg2\tResult\n";
    for (const auto& q : quadList) {
        std::cout << q.op << "\t" << q.arg1 << "\t" << q.arg2 << "\t" << q.result << "\n";
    }

    std::cout << "\nLab No. 22 Name: Saugat Bikram Thapa /Roll No.: 80117731/ Section: A\n";
    return 0;
}