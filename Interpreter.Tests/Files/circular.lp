mensch(marvin).

single(X) :- mensch(X), not married(X).
married(X) :- mensch(X), not single(X).