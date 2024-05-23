book(bookOne). book(bookTwo).
shelf(shelfOne). shelf(shelfTwo).

genre(bookOne, fiction). genre(bookTwo, nonfiction).
capacity(shelfOne, 1). capacity(shelfTwo, 2).

% Bücher den Regalen zuweisen
assign(B, S) :- book(B), shelf(S), genre(B, G), suitable(S, G).

% Jedes Buch muss einem Regal zugeordnet werden
:- book(B), not assign(B, _).

% Geeignetes Regal für jedes Genre
suitable(shelfOne, fiction). suitable(shelfTwo, nonfiction).