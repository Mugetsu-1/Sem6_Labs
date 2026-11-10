#include <iostream>
#include <string>
#include <unordered_map>

enum DataType { TYPE_INT, TYPE_FLOAT, TYPE_BOOL, TYPE_ARRAY, TYPE_ERROR };

struct Symbol {
    DataType type;
    int arrayBound;
};

std::unordered_map<std::string, Symbol> symbolTable;

std::string typeToString(DataType t) {
    switch (t) {
        case TYPE_INT: return "TYPE_INT";
        case TYPE_FLOAT: return "TYPE_FLOAT";
        case TYPE_BOOL: return "TYPE_BOOL";
        case TYPE_ARRAY: return "TYPE_ARRAY";
        default: return "TYPE_ERROR";
    }
}

DataType evaluate_binary_type(DataType left, DataType right, int lineNo) {
    if (left == TYPE_ERROR || right == TYPE_ERROR) return TYPE_ERROR;
    if (left == TYPE_INT && right == TYPE_INT) return TYPE_INT;
    if ((left == TYPE_INT && right == TYPE_FLOAT) || (left == TYPE_FLOAT && right == TYPE_INT)) {
        return TYPE_FLOAT;
    }
    if (left == TYPE_FLOAT && right == TYPE_FLOAT) return TYPE_FLOAT;

    std::cout << "Line " << lineNo << ": Type Error Incompatible operands.\n";
    return TYPE_ERROR;
}

DataType verify_array_access(const std::string& name, DataType indexType, int indexVal, int lineNo) {
    if (!symbolTable.count(name)) {
        std::cout << "Line " << lineNo << ": Error: Variable '" << name << "' undeclared.\n";
        return TYPE_ERROR;
    }
    if (indexType != TYPE_INT) {
        std::cout << "Line " << lineNo << ": Type Error: Array index must evaluate to TYPE_INT.\n";
        return TYPE_ERROR;
    }
    if (indexVal < 0 || indexVal >= symbolTable[name].arrayBound) {
        std::cout << "Line " << lineNo << ": Error: Index " << indexVal << " out of bounds for '" << name << "'.\n";
        return TYPE_ERROR;
    }
    std::cout << "Line " << lineNo << ": Array access valid for '" << name << "'.\n";
    return symbolTable[name].type;
}

int main() {
    // Default array symbol for immediate testing
    symbolTable["arr"] = {TYPE_INT, 10};

    int choice;
    do {
        std::cout << "\nType Checking Module\n";
        std::cout << "1. Declare Array Symbol\n";
        std::cout << "2. Evaluate Binary Expression Type\n";
        std::cout << "3. Verify Array Access\n";
        std::cout << "4. Exit\n";
        std::cout << "Choice: ";

        if (!(std::cin >> choice) || choice == 4) break;

        if (choice == 1) {
            std::string name;
            int typeChoice, bound;
            std::cout << "Enter Array Name, Element Type (0: INT, 1: FLOAT, 2: BOOL), Bound: ";
            std::cin >> name >> typeChoice >> bound;
            DataType dt = (typeChoice == 0) ? TYPE_INT : ((typeChoice == 1) ? TYPE_FLOAT : TYPE_BOOL);
            symbolTable[name] = {dt, bound};
            std::cout << "Array '" << name << "' declared with bound " << bound << ".\n";
        } else if (choice == 2) {
            int leftChoice, rightChoice, lineNo;
            std::cout << "Enter Left Type (0: INT, 1: FLOAT, 2: BOOL), Right Type (0: INT, 1: FLOAT, 2: BOOL), Line No: ";
            std::cin >> leftChoice >> rightChoice >> lineNo;
            DataType left = (leftChoice == 0) ? TYPE_INT : ((leftChoice == 1) ? TYPE_FLOAT : TYPE_BOOL);
            DataType right = (rightChoice == 0) ? TYPE_INT : ((rightChoice == 1) ? TYPE_FLOAT : TYPE_BOOL);
            DataType result = evaluate_binary_type(left, right, lineNo);
            if (result != TYPE_ERROR) {
                std::cout << "Resulting Data Type: " << typeToString(result) << "\n";
            }
        } else if (choice == 3) {
            std::string name;
            int indexTypeChoice, indexVal, lineNo;
            std::cout << "Enter Array Name, Index Type (0: INT, 1: FLOAT, 2: BOOL), Index Value, Line No: ";
            std::cin >> name >> indexTypeChoice >> indexVal >> lineNo;
            DataType idxType = (indexTypeChoice == 0) ? TYPE_INT : ((indexTypeChoice == 1) ? TYPE_FLOAT : TYPE_BOOL);
            verify_array_access(name, idxType, indexVal, lineNo);
        }
    } while (true);

    std::cout << "\nLab No. 18 Name: Saugat Bikram Thapa /Roll No.: 80117731/ Section: A\n";
    return 0;
}