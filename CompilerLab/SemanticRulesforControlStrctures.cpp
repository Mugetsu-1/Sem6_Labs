#include <iostream>
#include <string>
#include <unordered_map>

enum DataType { TYPE_INT, TYPE_FLOAT, TYPE_BOOL, TYPE_ERROR };

class IfASTNode;
class WhileASTNode;
class ForASTNode;
class BreakASTNode;
class ContinueASTNode;
class VarASTNode;
class ExprASTNode;

class SemanticVisitor {
public:
    virtual ~SemanticVisitor() = default;
    virtual DataType visitIfNode(IfASTNode* node) = 0;
    virtual DataType visitWhileNode(WhileASTNode* node) = 0;
    virtual DataType visitForNode(ForASTNode* node) = 0;
    virtual DataType visitBreakNode(BreakASTNode* node) = 0;
    virtual DataType visitContinueNode(ContinueASTNode* node) = 0;
    virtual DataType visitVarNode(VarASTNode* node) = 0;
    virtual DataType visitExprNode(ExprASTNode* node) = 0;
};

class ASTNode {
public:
    int lineNo;
    virtual ~ASTNode() = default;
    virtual DataType accept(SemanticVisitor* visitor) = 0;
};

class ExprASTNode : public ASTNode {
public:
    DataType type;
    ExprASTNode(DataType t, int line) : type(t) { lineNo = line; }
    DataType accept(SemanticVisitor* visitor) override {
        return visitor->visitExprNode(this);
    }
};

class VarASTNode : public ASTNode {
public:
    std::string name;
    VarASTNode(std::string n, int line) : name(n) { lineNo = line; }
    DataType accept(SemanticVisitor* visitor) override {
        return visitor->visitVarNode(this);
    }
};

class BreakASTNode : public ASTNode {
public:
    BreakASTNode(int line) { lineNo = line; }
    DataType accept(SemanticVisitor* visitor) override {
        return visitor->visitBreakNode(this);
    }
};

class ContinueASTNode : public ASTNode {
public:
    ContinueASTNode(int line) { lineNo = line; }
    DataType accept(SemanticVisitor* visitor) override {
        return visitor->visitContinueNode(this);
    }
};

class WhileASTNode : public ASTNode {
public:
    ASTNode* condition;
    ASTNode* body;
    WhileASTNode(ASTNode* cond, ASTNode* b, int line) : condition(cond), body(b) { lineNo = line; }
    DataType accept(SemanticVisitor* visitor) override {
        return visitor->visitWhileNode(this);
    }
};

class ForASTNode : public ASTNode {
public:
    ASTNode* condition;
    ASTNode* body;
    ForASTNode(ASTNode* cond, ASTNode* b, int line) : condition(cond), body(b) { lineNo = line; }
    DataType accept(SemanticVisitor* visitor) override {
        return visitor->visitForNode(this);
    }
};

class IfASTNode : public ASTNode {
public:
    ASTNode* condition;
    ASTNode* body;
    IfASTNode(ASTNode* cond, ASTNode* b, int line) : condition(cond), body(b) { lineNo = line; }
    DataType accept(SemanticVisitor* visitor) override {
        return visitor->visitIfNode(this);
    }
};

std::unordered_map<std::string, bool> symbolTable;

class ConcreteSemanticVisitor : public SemanticVisitor {
private:
    int loop_depth = 0;

public:
    DataType visitExprNode(ExprASTNode* node) override {
        return node->type;
    }

    DataType visitVarNode(VarASTNode* node) override {
        if (!symbolTable[node->name]) {
            std::cout << "Line " << node->lineNo << ": Error Variable '" << node->name << "' used before initialization.\n";
            return TYPE_ERROR;
        }
        return TYPE_BOOL;
    }

    DataType visitWhileNode(WhileASTNode* node) override {
        DataType condType = node->condition->accept(this);
        if (condType != TYPE_BOOL && condType != TYPE_INT) {
            std::cout << "Line " << node->lineNo << ": Error Loop condition must evaluate to boolean.\n";
        }
        loop_depth++;
        if (node->body) node->body->accept(this);
        loop_depth--;
        return TYPE_BOOL;
    }

    DataType visitForNode(ForASTNode* node) override {
        DataType condType = node->condition->accept(this);
        if (condType != TYPE_BOOL && condType != TYPE_INT) {
            std::cout << "Line " << node->lineNo << ": Error Loop condition must evaluate to boolean.\n";
        }
        loop_depth++;
        if (node->body) node->body->accept(this);
        loop_depth--;
        return TYPE_BOOL;
    }

    DataType visitBreakNode(BreakASTNode* node) override {
        if (loop_depth == 0) {
            std::cout << "Line " << node->lineNo << ": Error 'break' statement outside loop context.\n";
            return TYPE_ERROR;
        }
        return TYPE_BOOL;
    }

    DataType visitContinueNode(ContinueASTNode* node) override {
        if (loop_depth == 0) {
            std::cout << "Line " << node->lineNo << ": Error 'continue' statement outside loop context.\n";
            return TYPE_ERROR;
        }
        return TYPE_BOOL;
    }

    DataType visitIfNode(IfASTNode* node) override {
        DataType condType = node->condition->accept(this);
        if (condType != TYPE_BOOL && condType != TYPE_INT) {
            std::cout << "Line " << node->lineNo << ": Error Condition must evaluate to boolean.\n";
        }
        if (node->body) node->body->accept(this);
        return TYPE_BOOL;
    }
};

int main() {
    ConcreteSemanticVisitor visitor;
    symbolTable["a"] = false;

    std::cout << "Input Statement 1: Evaluated 'break' statement at Line 2 outside loop\n";
    BreakASTNode badBreak(2);
    badBreak.accept(&visitor);

    std::cout << "\nInput Statement 2: Evaluated uninitialized variable 'a' at Line 1\n";
    VarASTNode uninitVar("a", 1);
    uninitVar.accept(&visitor);

    std::cout << "\nInput Statement 3: Evaluated while loop at Line 3 with float condition\n";
    ExprASTNode floatCond(TYPE_FLOAT, 3);
    WhileASTNode badWhile(&floatCond, nullptr, 3);
    badWhile.accept(&visitor);

    std::cout << "\nLab No. 19 Name: Saugat Bikram Thapa /Roll No.: 80117731/ Section: A\n";
    return 0;
}