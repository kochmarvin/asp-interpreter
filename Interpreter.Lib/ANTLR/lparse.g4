grammar Lparse;

// Lexer rules
NAF : 'not';
IS : 'is' ;
NUMBER : '0' | [1-9][0-9]* ;
ID : [a-z][A-Za-z_]*;

VARIABLE : [_A-Z][A-Za-z0-9_]* ;
DOT : '.' ;
DOTDOT : '..' ;
COMMA : ',' ;
QUERY_MARK : '?' ;
COLON : ':' ;
SEMICOLON : ';' ;
CONS : ':-' ;
PLUS : '+' ;
MINUS : '-' ;
TIMES : '*' ;
DIV : '/' ;
PAREN_OPEN : '(' ;
PAREN_CLOSE : ')' ;
SQUARE_OPEN : '[' ;
SQUARE_CLOSE : ']' ;
CURLY_OPEN : '{' ;
CURLY_CLOSE : '}' ;
UNIFICATION : '=' ;
EQUAL : '==' ;
UNEQUAL : '<>' | '!=' ;
LESS : '<' ;
GREATER : '>' ;
LESS_OR_EQ : '<=' ;
GREATER_OR_EQ : '>=' ;

// Lexer rules for skipping comments and whitespace
LINE_COMMENT : '%' ~[\r\n]* -> skip;

WS : [ \t\r\n]+ -> skip ;

// Parser rules
program : statements query? | query ;
statements : statement (statement)* ;

query : body (SEMICOLON body)* QUERY_MARK ;

statement : CONS bodies? DOT
          | head CONS? bodies? DOT ;

bodies : body (SEMICOLON body)*;

head : disjunction | choice | range ;

body : (naf_literal) (COMMA naf_literal)* ;

disjunction : classical_literal ;

range : range_literal;

choice : CURLY_OPEN choice_elements? CURLY_CLOSE ;

choice_elements : choice_element (SEMICOLON choice_element)* ;

choice_element : classical_literal;

naf_literal : is_operator | NAF? classical_literal | builtin_atom  ;

classical_literal : (MINUS)? ID (PAREN_OPEN terms? PAREN_CLOSE)? ;

range_literal : (MINUS)? ID (PAREN_OPEN range_binding PAREN_CLOSE);

range_binding : range_number DOTDOT range_number;

range_number : (MINUS)? NUMBER;

builtin_atom : term binop term ;

is_operator : VARIABLE IS operand arithop operand;
operand : (VARIABLE | NUMBER);

binop : UNIFICATION | EQUAL | UNEQUAL | LESS | GREATER | LESS_OR_EQ | GREATER_OR_EQ ;

terms : term (COMMA term)* ;

term : ID (PAREN_OPEN terms PAREN_CLOSE)?
     | (MINUS)? NUMBER
     | VARIABLE
     | PAREN_OPEN term PAREN_CLOSE
     ;
arithop : PLUS | MINUS | TIMES | DIV ;
