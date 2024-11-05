using CalculatorApp.DTO;
using CalculatorApp.IServices;

namespace CalculatorApp.Services;

public class Engin(IEnginRules rules) : IEngin
{
    public Result Compute(List<string> tokens)
    {
        try
        {
            var result = Evaluate(tokens);
            return Result.Ok($"{result}");
        }
        catch (Exception e)
        {
            return Result.Err(e.Message);
        }
    }

    private double Evaluate(List<string> tokens)
    {
        var operations = new Stack<char>();
        var values = new Stack<double>();

        foreach (var token in tokens)
        {
            if (double.TryParse(token, out var value))
            {
                values.Push(value);
                continue;
            }

            switch (token)
            {
                case "(":
                    operations.Push('(');
                    break;
                case ")":
                {
                    while (operations.Count > 0 && operations.Peek() != '(')
                    {
                        var val2 = values.Pop();
                        var val1 = values.Pop();
                        var op = operations.Pop();
                        values.Push(rules.ApplyOperation(val1, val2, op));
                    }

                    operations.Pop();
                    break;
                }
                default:
                {
                    if (rules.Operators.Contains(token[0]))
                    {
                        while (operations.Count > 0 &&
                               rules.Precedence(operations.Peek()) >= rules.Precedence(token[0]))
                        {
                            var val2 = values.Pop();
                            var val1 = values.Pop();
                            var op = operations.Pop();
                            values.Push(rules.ApplyOperation(val1, val2, op));
                        }

                        operations.Push(token[0]);
                    }

                    break;
                }
            }
        }

        while (operations.Count > 0)
        {
            var val2 = values.Pop();
            var val1 = values.Pop();
            var op = operations.Pop();
            values.Push(rules.ApplyOperation(val1, val2, op));
        }

        return values.Pop();
    }
}