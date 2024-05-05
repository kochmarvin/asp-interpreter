number_one(20).
number_two(4).
result(X) :- number_one(Y), number_two(Z), X is Y - Z.