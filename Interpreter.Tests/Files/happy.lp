happy(Person) :- reasontobehappy(Person), not -unhappy(Person).
unhappy(Person) :- reasontobeunhappy(Person), not happy(Person).
sad(Person) :- reasontobehappy(Person), not reasontobeunhappy(Person).

reasontobehappy(alice).  
reasontobeunhappy(bob). 
:- happy(P), unhappy(P).