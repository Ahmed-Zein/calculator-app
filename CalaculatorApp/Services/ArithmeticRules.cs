namespace CalculatorApp.Services;

public interface IEnginRules
{
    HashSet<char> Operators { get; }
    double ApplyOperation(double a, double b, char op);
    int Precedence(char op);
}

public class ArithmeticEnginRules : IEnginRules
{
    public HashSet<char> Operators { get; } = ['*', '/', '+', '-'];

    public double ApplyOperation(double a, double b, char op)
    {
        switch (op)
        {
            case '*': return a * b;
            case '/':
                if (b == 0) throw new DivideByZeroException();
                return a / b;
            case '+': return a + b;
            case '-': return a - b;
            default: throw new InvalidOperationException($"Unsupported operator {op}");
        }
    }

    public int Precedence(char op)
    {
        return op switch
        {
            ('+' or '-') => 1,
            ('*' or '/') => 2,
            _ => -1
        };
    }
}