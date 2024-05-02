vehicle(bike).
vehicle(skateboard).

faster(bike, skateboard).

is_faster(X, Y) :- faster(X, Y).
is_faster(X, Y) :- 
    faster(X, Z), 
    is_faster(Z, Y).

fastest(X) :- vehicle(X), not is_faster(_, X).