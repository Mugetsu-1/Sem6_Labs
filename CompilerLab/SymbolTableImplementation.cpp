#include <iostream>
#include <cstring>
#include <iomanip>

#define MAX_SYMBOLS 100

typedef struct {
    char name[32];
    char type[10];
    int address;
    int size;
} Symbol;

Symbol symbolTable[MAX_SYMBOLS];
int symbolCount = 0;

int findSymbol(const char* name) {
    for (int i = 0; i < symbolCount; ++i) {
        if (strcmp(symbolTable[i].name, name) == 0) return i;
    }
    return -1;
}

void insertSymbol() {
    if (symbolCount >= MAX_SYMBOLS) {
        std::cout << "Symbol Table Full\n";
        return;
    }
    Symbol s;
    std::cout << "Enter Symbol Name, Type, Address, Size: ";
    std::cin >> s.name >> s.type >> s.address >> s.size;
    if (findSymbol(s.name) != -1) {
        std::cout << "Duplicate symbol\n";
    } else {
        symbolTable[symbolCount++] = s;
        std::cout << "Symbol inserted successfully.\n";
    }
}

void displayTable() {
    std::cout << "\nIndex\tName\tType\tAddress\tSize\n";
    for (int i = 0; i < symbolCount; ++i) {
        std::cout << i << "\t" << symbolTable[i].name << "\t"
                  << symbolTable[i].type << "\t" << symbolTable[i].address
                  << "\t" << symbolTable[i].size << "\n";
    }
}

void deleteSymbol() {
    char name[32];
    std::cout << "Enter symbol name to delete: ";
    std::cin >> name;
    int idx = findSymbol(name);
    if (idx == -1) {
        std::cout << "Label not found\n";
    } else {
        for (int i = idx; i < symbolCount - 1; ++i) {
            symbolTable[i] = symbolTable[i + 1];
        }
        symbolCount--;
        std::cout << "Symbol deleted successfully.\n";
    }
}

void searchSymbol() {
    char name[32];
    std::cout << "Enter symbol name to search: ";
    std::cin >> name;
    int idx = findSymbol(name);
    if (idx == -1) {
        std::cout << "Symbol not found\n";
    } else {
        std::cout << "Index: " << idx << " | Name: " << symbolTable[idx].name
                  << " | Type: " << symbolTable[idx].type
                  << " | Address: " << symbolTable[idx].address
                  << " | Size: " << symbolTable[idx].size << "\n";
    }
}

void modifySymbol() {
    char name[32];
    std::cout << "Enter symbol name to modify: ";
    std::cin >> name;
    int idx = findSymbol(name);
    if (idx == -1) {
        std::cout << "Symbol not found\n";
    } else {
        std::cout << "Enter new Type, Address, Size: ";
        std::cin >> symbolTable[idx].type >> symbolTable[idx].address >> symbolTable[idx].size;
        std::cout << "Symbol modified successfully.\n";
    }
}

int main() {
    int choice;
    do {
        std::cout << "\n1. Insert  2. Display  3. Delete  4. Search  5. Modify  6. Exit\nChoice: ";
        if (!(std::cin >> choice) || choice == 6) break;
        switch (choice) {
            case 1: insertSymbol(); break;
            case 2: displayTable(); break;
            case 3: deleteSymbol(); break;
            case 4: searchSymbol(); break;
            case 5: modifySymbol(); break;
        }
    } while (true);

    std::cout << "\nLab No. 16 Name: Saugat Bikram Thapa /Roll No.: 80117731/ Section: A\n";
    return 0;
}