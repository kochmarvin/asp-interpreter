# Changes
>Interpreter.CLI\Commands\ExplainCommand.cs
> Explain logik wurde hinzugefügt
>
> Lparse.g4 Interpreter.Lib\ANTLR\Lparse.g4
> neuen Lexer Rules wurden hinzugefügt. Zeile 50 - 54
>
> Interpreter.CLI\Program.cs
>command wurde hinzugefügt zeile 34
>
> Interpreter.Lib\Results\Objects\Literals\CommentLiteral.cs 
> neues body literal für comment ganze file neu
>
> Interpreter.Lib\Visitors\StatementVisitor.cs
> statement visitor geupdates sodass er das neue versteht. Zeile 40 - 70

## minor changes
> Interpreter.CLI\CommandFactory\CommandFactory.cs
> auto generated antlr files


## usage
Im Interpreter.CLI Ordner
```
dotnet run
```
oder die .exe ausführen

Danach in der custom CLI die sich startet
```
:ex <filepath>
```

#### Limitationen
is und not darf nicht im Text vorkommen der Lexer greift diese als keywords auf
keine zahlen im head (nat2)

## requirements
> .NET 8.0 ! Important !