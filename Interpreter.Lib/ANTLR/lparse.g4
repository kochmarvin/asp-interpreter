grammar Lparse;

// Lexer rules
NAF : 'not';
NUMBER : '0' | [1-9][0-9]* ;
ID : [a-z][A-Za-z_]*;

VARIABLE : [A-Z][A-Za-z0-9_]* ;
ANONYMOUS_VARIABLE : '_' ;
DOT : '.' ;
COMMA : ',' ;
QUERY_MARK : '?' ;
COLON : ':' ;
SEMICOLON : ';' ;
OR : '|' ;
CONS : ':-' ;
PLUS : '+' ;
MINUS : '-' ;
TIMES : '*' ;
DIV : '/' ;
AT : '@' ;
PAREN_OPEN : '(' ;
PAREN_CLOSE : ')' ;
SQUARE_OPEN : '[' ;
SQUARE_CLOSE : ']' ;
CURLY_OPEN : '{' ;
CURLY_CLOSE : '}' ;
EQUAL : '=' ;
UNEQUAL : '<>' | '!=' ;
LESS : '<' ;
GREATER : '>' ;
LESS_OR_EQ : '<=' ;
GREATER_OR_EQ : '>=' ;

// Lexer rules for skipping comments and whitespace
COMMENT : '%' (~[\r\n])* '\r'? '\n' -> skip ;
WS : [ \t\r\n]+ -> skip ;

// Parser rules
program : statements query? | query ;
statements : statement (statement)* ;

query : classical_literal QUERY_MARK ;

statement : CONS body? DOT
          | head CONS? body? DOT ;

head : disjunction | choice ;

body : (naf_literal | NAF? aggregate) (COMMA (naf_literal | NAF? aggregate))* ;

disjunction : classical_literal (OR classical_literal)* ;

choice : (term binop)? CURLY_OPEN choice_elements? CURLY_CLOSE (binop term)? ;

choice_elements : choice_element (SEMICOLON choice_element)* ;

choice_element : classical_literal (COLON naf_literals)? ;

aggregate : (term binop)? CURLY_OPEN aggregate_elements CURLY_CLOSE (binop term)? ;

aggregate_elements : aggregate_element (SEMICOLON aggregate_element)* ;

aggregate_element : terms COLON naf_literals
                  | terms                  
                  | COLON naf_literals ;   

naf_literals : naf_literal (COMMA naf_literal)* ;

naf_literal : NAF? classical_literal | builtin_atom ;

classical_literal : (MINUS)? ID (PAREN_OPEN terms? PAREN_CLOSE)? ;

builtin_atom : term binop term ;

binop : EQUAL | UNEQUAL | LESS | GREATER | LESS_OR_EQ | GREATER_OR_EQ ;

terms : term (COMMA term)* ;

term : ID (PAREN_OPEN terms PAREN_CLOSE)?
     | NUMBER
     | VARIABLE
     | ANONYMOUS_VARIABLE
     | PAREN_OPEN term PAREN_CLOSE
     | MINUS term
     | term arithop term ;

arithop : PLUS | MINUS | TIMES | DIV ;
