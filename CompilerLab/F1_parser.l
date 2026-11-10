%{
#include "F2_parser.tab.h"
%}
%%
[0-9]+                 { yylval = atoi(yytext); return NUMBER; }
"int"                  { return INT; }
[a-zA-Z_][a-zA-Z0-9_]* { return ID; }
[\t ]+                 ;
\n                     { return 0; }
.                      { return yytext[0]; }
%%
int yywrap() { return 1; }