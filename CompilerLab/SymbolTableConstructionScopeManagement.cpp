#include <iostream>
#include <vector>
#include <string>
#include <unordered_map>

struct SymbolInfo {
    std::string name;
    std::string type;
    int size;
    int scopeLevel;
};

class ScopedSymbolTable {
private:
    std::vector<std::unordered_map<std::string, SymbolInfo>> scopeStack;

public:
    ScopedSymbolTable() {
        scopeStack.push_back({});
    }

    void enter_scope() {
        scopeStack.push_back({});
        std::cout << "Entered Scope Level " << scopeStack.size() - 1 << "\n";
    }

    void leave_scope() {
        if (scopeStack.size() > 1) {
            std::cout << "Left Scope Level " << scopeStack.size() - 1 << "\n";
            scopeStack.pop_back();
        } else {
            std::cout << "Error: Cannot leave global scope (Level 0)\n";
        }
    }

    void insert(const std::string& name, const std::string& type, int size) {
        int currentLevel = scopeStack.size() - 1;
        if (scopeStack.back().count(name)) {
            std::cout << "Redeclaration Error: " << name << " in current scope\n";
        } else {
            scopeStack.back()[name] = {name, type, size, currentLevel};
            std::cout << "Inserted '" << name << "' (" << type << ", size " << size 
                      << ") into scope level " << currentLevel << "\n";
        }
    }

    SymbolInfo* lookup(const std::string& name) {
        for (int i = (int)scopeStack.size() - 1; i >= 0; --i) {
            auto it = scopeStack[i].find(name);
            if (it != scopeStack[i].end()) {
                std::cout << "Found '" << name << "' -> Type: " << it->second.type 
                          << ", Size: " << it->second.size 
                          << ", Scope Level: " << it->second.scopeLevel << "\n";
                return &(it->second);
            }
        }
        std::cout << "Undeclared Error: " << name << "\n";
        return nullptr;
    }

    int getCurrentScopeLevel() const {
        return scopeStack.size() - 1;
    }
};

struct ASTNode {
    virtual ~ASTNode() = default;
    virtual void execute(ScopedSymbolTable& st) = 0;
};

struct VarDeclASTNode : public ASTNode {
    std::string name, type;
    int size;
    VarDeclASTNode(std::string n, std::string t, int s) : name(n), type(t), size(s) {}
    void execute(ScopedSymbolTable& st) override {
        st.insert(name, type, size);
    }
};

struct LookupASTNode : public ASTNode {
    std::string name;
    LookupASTNode(std::string n) : name(n) {}
    void execute(ScopedSymbolTable& st) override {
        st.lookup(name);
    }
};

struct BlockASTNode : public ASTNode {
    void execute(ScopedSymbolTable& st) override {
        st.enter_scope();
    }
};

int main() {
    ScopedSymbolTable st;
    int choice;
    std::string name, type;
    int size;

    do {
        std::cout << "\nCurrent Scope Level: " << st.getCurrentScopeLevel() << "\n";
        std::cout << "1. Enter Scope ({)\n";
        std::cout << "2. Leave Scope (})\n";
        std::cout << "3. Insert Variable\n";
        std::cout << "4. Lookup Variable\n";
        std::cout << "5. Exit\n";
        std::cout << "Choice: ";

        if (!(std::cin >> choice) || choice == 5) break;

        switch (choice) {
            case 1: {
                BlockASTNode blockNode;
                blockNode.execute(st);
                break;
            }
            case 2:
                st.leave_scope();
                break;
            case 3: {
                std::cout << "Enter Name, Type, Size: ";
                std::cin >> name >> type >> size;
                VarDeclASTNode declNode(name, type, size);
                declNode.execute(st);
                break;
            }
            case 4: {
                std::cout << "Enter Name to Lookup: ";
                std::cin >> name;
                LookupASTNode lookupNode(name);
                lookupNode.execute(st);
                break;
            }
            default:
                std::cout << "Invalid choice.\n";
        }
    } while (true);

    std::cout << "\nLab No. 17 Name: Saugat Bikram Thapa /Roll No.: 80117731/ Section: A\n";
    return 0;
}