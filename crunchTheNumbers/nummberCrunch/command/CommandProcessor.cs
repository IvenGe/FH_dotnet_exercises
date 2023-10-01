class CommandProcessor : ICommandProcessor
{
    private readonly ICalculator calculator;
    private readonly IVariableManager variableManager;

    public CommandProcessor(ICalculator calculator, IVariableManager variableManager)
    {
        this.calculator = calculator;
        this.variableManager = variableManager;
    }

    public void ProcessInput(string input)
    {
        if (input == "/help")
        {
            ShowHelp();
        }
        else if (input == "/list")
        {
            variableManager.ListVariables();
        }
        else if (input == "/clear")
        {
            variableManager.ClearVariables();
        }
        else if (IsVariableAssignment(input))
        {
            HandleVariableAssignment(input);
        }
        else
        {
            calculator.Calculate(input, variableManager);
        }
    }

    private bool IsVariableAssignment(string input)
    {
        return input.Contains("=");
    }

    private void HandleVariableAssignment(string input)
    {
        var parts = input.Split('=');
        string variableName = parts[0].Trim();
        if (double.TryParse(parts[1], out double value))
        {
            variableManager.AssignVariable(variableName, value);
        }
        else
        {
            Console.WriteLine("Invalid value.");
        }
    }

    private void ShowHelp()
    {

    Console.WriteLine("You can enter simple calculations like '1+2' and let them calculate by pressing enter.");
    Console.WriteLine("You can only use one operand at a time. If you want to use negative numbers, you need to store them in a variable first.");
    Console.WriteLine("The operands you can use are +, -, *, /, and ^. Furthermore, you can assign a variable a value by using a syntax like 'hello=15'.");
    Console.WriteLine("This would result in a variable called 'hello' with a value of 15.");
    Console.WriteLine("To simply use the variable within a calculation, use [] brackets: '[hello]*5'.");
    Console.WriteLine("The result of the last calculation will always be available under the variable 'ans'.");
    Console.WriteLine("You can display the variables with the command '/list'. You can clear them by using '/clear'.");
    Console.WriteLine("To stop the Crunch the Numbers calculation service, use '/stop'. To display this help text at any time use '/help'");
        
    }
}