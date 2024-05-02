member (sam, cs). 
course(java, cs). 
course(ai, cs).
member (bob, cs). 
course(c, cs). 
course(logic, cs). member (tom, cs). likes(sam, java). 
likes(sam, c).
likes(bob, java). 
likes(bob, ai).
likes(tom, ai). 
likes(tom, logic).

teaches(X, Y ) :- member(X, cs), course(Y, cs), likes(X, Y), not -teaches(X, Y).
-teaches(X, Y ) :- member(X, cs), course(Y, cs), teaches(X1, Y ), X1 != X.

some_course(X) :- member(X, cs), teaches(X, _).

:- member (X, cs), not some_course(X).
:- teaches(X, Y1), teaches(X, Y2), teaches(X, Y3), Y1 != Y2, Y1 != Y3, Y2 != Y3.
