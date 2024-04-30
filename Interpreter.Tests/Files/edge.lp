edge(a, b).
edge(a, c).
edge(b, c).
edge(b, d).
edge(c, d).

color(red).
color(blue).
color(green).

coloring(X, Color) :- vertex(X), color(Color), not neighbor_color(X, Color).

neighbor_color(X, Color) :- edge(X, Y), coloring(Y, Color).

vertex(X) :- edge(X, Y); edge(Y, X).