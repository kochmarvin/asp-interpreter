on(a, b).
on(b, c).
clear(a).
clear(d).
handempty.

pickup(X) :- clear(X), handempty, ontable(X).

puton(X, Y) :- clear(X), handempty, clear(Y).

move(X, Y) :- clear(X), handempty, on(X, Z), puton(X, Y), clear(Z).

stacked(X) :- on(X, _).