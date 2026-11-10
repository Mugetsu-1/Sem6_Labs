# Compiler Design and Construction — Lab 1 & Lab 2 (Parts 1 & 2)

This folder contains C++ programs, Flex specifications, and Bison grammar files for **Compiler Design and Construction Lab 1 (Part 1)** and **Lab 2 (Part 2)**.

## Lab 1 (Part 1) — Q1–Q15: Compiler Front-End Topics

- **Finite Automata (DFAs)**: Q1A-Q1C — DFAs for pattern matching, substring acceptance, etc.
- **Lexical Analysis**: Q2-Q6 — C/C++ identifier validation, keyword checking, simple lexical analyzers, Flex specifications
- **Grammar Transformations**: Q7 — Left recursion removal and left factoring
- **FIRST/FOLLOW Computation**: Q8 — Computing FIRST and FOLLOW sets for context-free grammars
- **Parser Construction**: Q9-Q15 — LL(1) parsing tables, top-down stack-based parsers, shift-reduce parsing, SLR/LR(1)/LALR(1) parsing tables, Flex/Bison integration

## Lab 2 (Part 2) — Q16–Q26: Semantic Analysis and Back-End Topics

- **Symbol Tables**: Q16-Q17 — Implementation with multi-level scope management
- **Type Checking**: Q18 — Expression and assignment type checking
- **Semantic Rules**: Q19 — Control structure semantics (if/while)
- **Intermediate Code Generation**: Q20-Q22 — Quadruples, three-address code, function parameter handling
- **Code Generation**: Q23 — 8086-style assembly code generation from quadruples
- **Code Optimization**: Q24-Q26 — Constant folding/propagation, dead-code elimination, peephole optimization

## Requirements

Install the following tools before running the programs:

- `g++` or another C++ compiler
- `gcc` for generated C files
- Flex
- Bison

On Windows, WinFlexBison or MSYS2 can be used (this setup uses MSYS2 UCRT64). After installing, make sure `flex`, `bison`, `gcc`, and `g++` are available from the terminal.

## Running C++ Programs

Compile any `.cpp` file with `g++`, then run the generated executable.

```powershell
g++ DFA_Start01.cpp -o program.exe
.\program.exe
```

## Running a Flex File

Use this for standalone `.l` files such as `Lexer.l`.

```powershell
flex Lexer.l
gcc lex.yy.c -o lexer.exe
.\lexer.exe
```

After running the lexer, enter the input text. To finish input:

- **Windows**: press `Enter`, then `Ctrl + Z`, then `Enter`
- **Linux/macOS**: press `Ctrl + D`

## Running the Flex and Bison Parser

Use this for the parser files `F1_parser.l` and `F2_parser.y`.

```powershell
bison -d F2_parser.y
flex F1_parser.l
gcc F2_parser.tab.c lex.yy.c -o parser.exe
.\parser.exe
```

If your Bison installation generates a different output name, compile the generated `.tab.c` file shown in your folder.

> Note: the `.vscode/` folder is intentionally not committed — it contains machine-specific build/run configs (MSYS2 paths, `active_cpp_run.exe` output).

## Submission Note

Generated files such as `.exe`, `lex.yy.c`, and Bison output files are ignored by `.gitignore`. The folder is intended to keep only the lab source files (`.cpp`, `.l`, `.y`) along with this README and `.gitignore`.

Student: Saugat Bikram Thapa  
Roll No./Section: 80117731/A
