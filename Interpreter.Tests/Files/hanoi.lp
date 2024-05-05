move(a, c) :- on(a, b), not on(x, c), not smaller(a, x).
move(a, b) :- on(a, c), not on(x, b), not smaller(a, x).
move(b, a) :- on(b, c), not on(x, a), not smaller(b, x).
move(b, c) :- on(b, a), not on(x, c), not smaller(b, x).
move(c, a) :- on(c, b), not on(x, a), not smaller(c, x).
move(c, b) :- on(c, a), not on(x, b), not smaller(c, x).

smaller(a, b).
smaller(a, c).
smaller(b, c).
smaller(X, Y) :- smaller(X, Z), smaller(Z, Y).

on(a, c).
on(b, c).
on(c, a).

:- move(X, Y), not legalmove(X, Y).

legalmove(X, Y) :- move(X, Y).
legalmove(X, Y) :- move(X, Z), legalmove(Z, Y).