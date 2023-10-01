class Calculator : ICalculator
{
    private readonly Dictionary<string, Func<double, double, double>> operations = new Dictionary<string, Func<double, double, double>>()
    {
        { "+", (a, b) => a + b },
        { "-", (a, b) => a - b },
        { "*", (a, b) => a * b },
        { "/", (a, b) => a / b },
        { "^", Math.Pow }
    };

public void Calculate(string input, IVariableManager variableManager)
{
    string[] parts = input.Split(new[] { '+', '-', '*', '/', '^' }, StringSplitOptions.RemoveEmptyEntries);

    if (parts.Length != 2)
    {
        Console.WriteLine("Invalid input.");
        return;
    }

    string operation = input[parts[0].Length].ToString();
    double operand1, operand2;

    if (!TryGetOperandValue(parts[0], variableManager, out operand1) || !TryGetOperandValue(parts[1], variableManager, out operand2))
    {
        Console.WriteLine("Invalid operands.");
        return;
    }

    if (operations.TryGetValue(operation, out Func<double, double, double> op))
    {
        double result = op(operand1, operand2);
        Console.WriteLine($"Result: {result}");
        variableManager.AssignVariable("ans", result);
    }
    else
    {
        Console.WriteLine("Invalid operation.");
    }
}

private bool TryGetOperandValue(string operand, IVariableManager variableManager, out double value)
{
    if (double.TryParse(operand, out value))
    {
        return true;
    }

    return variableManager.GetVariableValue(operand, out value);
}

    private string ReplaceVariableWithValue(string potentialVariable, IVariableManager variableManager)
    {
        if (potentialVariable.StartsWith("[") && potentialVariable.EndsWith("]") || potentialVariable == "ans")
        {
            string variableName = potentialVariable.Trim('[', ']');

            if (variableManager.GetVariableValue(variableName, out double value))
            {
                return value.ToString();
            }
        }
        return potentialVariable;
    }
}