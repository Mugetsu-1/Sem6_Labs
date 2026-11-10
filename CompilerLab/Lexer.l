%{
#include <stdio.h>
int line_no = 1;
%}

%%
\n          { line_no++; }
[ \t]+      ;
"//".*      ;
"/*"([^*]|\*+[^/*])*"*"+"/" { for (int i = 0; yytext[i]; i++) if (yytext[i] == '\n') line_no++; }

"auto"|"break"|"case"|"char"|"const"|"continue"|"default"|"do"|"double"|"else"|"enum"|"extern"|"float"|"for"|"goto"|"if"|"int"|"long"|"register"|"return"|"short"|"signed"|"sizeof"|"static"|"struct"|"switch"|"typedef"|"union"|"unsigned"|"void"|"volatile"|"while" { printf("<KEYWORD, %s, %d>\n", yytext, line_no); }
[a-zA-Z_][a-zA-Z0-9_]*                    { printf("<IDENTIFIER, %s, %d>\n", yytext, line_no); }
[0-9]+\.[0-9]+                            { printf("<FLOAT_CONST, %s, %d>\n", yytext, line_no); }
[0-9]+                                    { printf("<INT_CONST, %s, %d>\n", yytext, line_no); }
"+"|"-"|"*"|"/"|"%"                       { printf("<ARITHMETIC_OPERATOR, %s, %d>\n", yytext, line_no); }
";"|","|"("|"}"|"{"|")"                   { printf("<DELIMITER, %s, %d>\n", yytext, line_no); }
.                                         { printf("<UNKNOWN, %s, %d>\n", yytext, line_no); }
%%

int main() {
    yylex();
    printf("\nLab No_Q.: 6 | Name: Saugat Bikram Thapa | Roll No./Sec: 80117731/A\n");
    return 0;
}

int yywrap() {
    return 1;
}
