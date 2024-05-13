
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Terms;

public class CommentLiteral(List<Variable> vars, List<string> strings) : Literal
{
    public List<Variable> Vars { get; } = vars;

    public override Literal Apply(Dictionary<string, Term> substitutions)
    {
        throw new NotImplementedException();
    }

    public override List<string> GetVariables()
    {
        List<string> va = [];
        foreach(var v in vars) {
            va.Add(v.Name);
        }
        return va;
    }

    public override bool HasVariables()
    {
        throw new NotImplementedException();
    }

    public override bool HasVariables(string variable)
    {
        throw new NotImplementedException();
    }

    public string GetText(List<string> variables) {
         var baseString = string.Join(" ", strings);
        for(int i = 0; i < vars.Count; i++) {
            baseString = baseString.Replace(i.ToString(), "" + variables[i] + "");
        }

        return baseString;
    }

    public override string ToString()
    {
        var baseString = string.Join(" ", strings);
        for(int i = 0; i < vars.Count; i++) {
            baseString = baseString.Replace(i.ToString(), "@(" + vars[i].Name + ")");
        }

        return baseString;
    }
}