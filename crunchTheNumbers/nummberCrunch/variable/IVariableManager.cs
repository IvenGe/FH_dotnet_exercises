interface IVariableManager
{
    void ListVariables();
    void ClearVariables();
    void AssignVariable(string variableName, double variableValue);
    bool GetVariableValue(string variableName, out double value);
}