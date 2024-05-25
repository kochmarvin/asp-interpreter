vertex(0).
vertex(1).
vertex(2).
vertex(3).
vertex(4).
edge(0, 1).
edge(1, 2).
edge(2, 3).
edge(3, 4).
edge(4, 0).
edge(4, 1).
edge(4, 2).
edge(4, 3).

other(U, V) :- vertex(U), vertex(V), vertex(W), V != W, chosen(U, W).
chosen(U, V) :- vertex(U), vertex(V), edge(U, V), not other(U, V).

reachable(0) :- chosen(_, 0).
reachable(V) :- chosen(U, V), reachable(U).

:- vertex(U), not reachable(U).
:- chosen(U, W), chosen(V, W), U != V.
