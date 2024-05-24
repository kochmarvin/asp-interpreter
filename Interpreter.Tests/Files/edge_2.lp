node(a). 
node(b). 
edge(a, b). 
color(red). 
color(blue).
:- edge(X, Y), color(C), color(C), not colored(X, C), not colored(Y, C).
