using System.Text;
using CalculatorApp.IServices;

namespace CalculatorApp.Services;

public class Tokenizer(IEnginRules rules) : ITokenizer
{
    public List<string> Tokenize(string line)
    {
        var tokens = new List<string>();

        line = line.Replace(" ", string.Empty); // eat whitespaces
        var i = 0;
        while (i < line.Length)
        {
            if ('0' <= line[i] && line[i] <= '9' || line[i] == '.')
            {
                tokens.Add(ParseNumber(line, ref i));
            }
            else if (rules.Operators.Contains(line[i]))
            {
                tokens.Add(line[i].ToString());
                i++;
            }
            else if (line[i] == '(' || line[i] == ')')
            {
                tokens.Add(line[i].ToString());
                i++;
            }
            else
            {
                throw new FormatException($"Invalid character {line[i]}");
            }
        }

        return tokens;
    }

    private string ParseNumber(string line, ref int i)
    {
        var number = new StringBuilder();
        while (i < line.Length)
        {
            if ((line[i] == '.' || ('0' <= line[i] && line[i] <= '9')))
            {
                number.Append(line[i]);
                i++;
            }
            else
            {
                break;
            }
        }

        return number.ToString();
    }
}