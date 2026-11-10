%{
#include <stdio.h>
int yylex(); void yyerror(const char *s) {}
%}
%token NUMBER ID INT
%left '+' '-'
%left '*' '/'
%%
stmt: expr { printf("Result = %d\n", $1); }
    | INT ID ';' { printf("Valid Declaration\n"); } ;
expr: expr '+' expr { $$ = $1 + $3; }
    | expr '-' expr { $$ = $1 - $3; }
    | expr '*' expr { $$ = $1 * $3; }
    | expr '/' expr { $$ = $1 / $3; }
    | NUMBER { $$ = $1; } ;
%%
int main() {
    printf("Enter expr/decl: "); yyparse();
    printf("\nLab No_Q.: 15 | Name: Saugat Bikram Thapa | Roll No./Sec: 80117731/A\n");
    return 0;
}