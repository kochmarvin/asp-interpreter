isFaster(X, Y) :- faster(X, Z), isFaster(Z, Y).
faster(marvin, werner).
faster(werner, niko).
faster(niko, michi).

isFaster(X, Y) :- faster(X, Y).