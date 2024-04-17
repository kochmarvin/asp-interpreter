node(1).
node(2).
node(3).
node(4).
node(5).
node(6).

knoten(X) :- node(X), X > 3.
knoten(X) :- node(X), X >= 3.
knoten(X) :- node(X), X <= 3.
knoten(X) :- node(X), X < 3.
knoten(X) :- node(X), X = 3.
knoten(X) :- node(X), X <> 3.