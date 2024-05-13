nat(X) :: @(X) ist a natural number.
nat(0).
nat(s(N)) :- nat(N).

natTwo(X) :: @(X) ist a natural number.
natTwo(X) :- X = 0.
natTwo(X) :- X = s(N), nat(N).

edge(X,Y) :: @(X) and @(Y) are directly connected.
edge(a,b).
edge(b,c).
edge(c,d).

path(X,Y) :: there existts a path from @(X) to @(Y).
path(X,Y) :- edge(X,Y).
path(X,Y) :- edge(X,Z), path(Z,Y).

other(0).

another(X) :: @(X) ist awesome.
another(X) :- other(X).

someNot(ZZ) :: @(ZZ) ist stupid.
someNot(ZZ) :- not another(ZZ), not nat(ZZ).

someNeg(Y) :: @(Y) makes sense.
someNeg(Y) :- -nat(Y).