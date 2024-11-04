namespace CalculatorApp.Exceptions;

public class ActionKeyError(string key) : Exception($"ActionKeyError: {key}");