parent(bob, alice). 
parent(bob, charlie).
parent(alice, david). 
parent(charlie, emma).
ancestor(X, Y) :- parent(X, Y).
ancestor(X, Y) :- parent(X, Z), ancestor(Z, Y).