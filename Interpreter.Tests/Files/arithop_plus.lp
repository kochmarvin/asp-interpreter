num_one(20).
num_two(4).
result(X) :- num_one(Y), num_two(Z), X is Y + Z.