using CalculatorApp.IServices;

namespace CalculatorApp.Services;

public class Repl(Calculator calculator) : IRepl
{
    private int _index = 0;

    public void Run()
    {
        while (true)
        {
            Console.Write(">> ");
            var line = Console.ReadLine()!.Trim();
            var ans = calculator.Eval(line);
            if (string.IsNullOrEmpty(ans)) continue;
            
            _index++;
            Console.WriteLine($"[{_index}] " + ans);
        }
    }
}