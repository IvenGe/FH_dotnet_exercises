class VariableManager : IVariableManager
{
    private readonly Dictionary<string, double> variables = new Dictionary<string, double>();

    public void ListVariables()
    {
        foreach (var variable in variables)
        {
            Console.WriteLine($"{variable.Key} = {variable.Value}");
        }
    }

    public void ClearVariables()
    {
        variables.Clear();
        Console.WriteLine("All variables cleared.");
    }

    public void AssignVariable(string variableName, double variableValue)
    {
        variables[variableName] = variableValue;
        Console.WriteLine($"Variable '{variableName}' assigned the value {variableValue}");
    }

    public bool GetVariableValue(string variableName, out double value)
    {
        return variables.TryGetValue(variableName, out value);
    }
}
