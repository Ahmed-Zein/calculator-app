using CalculatorApp.DTO;

namespace CalculatorApp.IServices;

public interface IEngin
{
    Result Compute(List<string> tokens);
}
