node(1).
hallo(X) :- R is 3 + 4.
hey(X) :- node(X), R is 3 + X.
test(X) :- node(X), R is X + 3.
both(X) :- node(X), node(Y), R is X + Y.