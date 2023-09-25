using System;
using System.Collections.Generic;
using System.Linq;

class NumberCrunch
{
    static Dictionary<string, double> variables = new Dictionary<string, double>();
    static Dictionary<string, Func<double, double, double>> operations = new Dictionary<string, Func<double, double, double>>()
    {
        { "+", (a, b) => a + b },
        { "-", (a, b) => a - b },
        { "*", (a, b) => a * b },
        { "/", (a, b) => a / b },
        { "^", Math.Pow },
    };

    static void Main(string[] args)
    {
        Console.WriteLine("╭━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━╮");
        Console.WriteLine("     🌟 Welcome to the Number Cruncher 🌟      ");
        Console.WriteLine("         🚀 Let's Crunch Some Numbers! 🚀        ");
        Console.WriteLine("╰━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━╯");

        while (true)
        {
            Console.Write(">");
            string input = Console.ReadLine();

            if (input == "/stop")
            {
                Console.WriteLine("Bye!");
                break;
            }

            ProcessInput(input);
        }
    }

    static void ProcessInput(string input)
    {
        switch (input)
        {
            case "/help":
                ShowHelp();
                break;
            case "/list":
                ListVariables();
                break;
            case "/clear":
                ClearVariables();
                break;
            default:
                if (input.Contains("="))
                {
                    AssignVariable(input);
                }
                else if (input.StartsWith("[") && input.EndsWith("]"))
                {
                    CalculateWithVariable(input);
                }
                else
                {
                    Calculate(input);
                }
                break;
        }
    }

    static void ShowHelp()
    {
static void ShowHelp()
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

    static void ListVariables()
    {
        Console.WriteLine("Variables and their values:");
        foreach (var variable in variables)
        {
            Console.WriteLine($"{variable.Key} = {variable.Value}");
        }
    }

    static void ClearVariables()
    {
        variables.Clear();
        Console.WriteLine("All variables cleared.");
    }

    static void AssignVariable(string input)
    {
        string[] parts = input.Split('=');

        if (parts.Length == 2)
        {
            string variableName = parts[0].Trim();
            if (double.TryParse(parts[1], out double variableValue))
            {
                variables[variableName] = variableValue;
                Console.WriteLine($"Variable '{variableName}' assigned the value {variableValue}");
            }
            else
            {
                Console.WriteLine("Invalid variable assignment");
            }
        }
        else
        {
            Console.WriteLine("Invalid variable assignment");
        }
    }

static void Calculate(string input)
{
    input = input.Replace(" ", "");
    string[] parts = input.Split(new[] { '+', '-', '*', '/', '^' }, StringSplitOptions.RemoveEmptyEntries);

    if (parts.Length != 2)
    {
        Console.WriteLine("Invalid input.");
        return;
    }

    string operation = input[parts[0].Length].ToString();
    double operand1, operand2;

    if (double.TryParse(parts[0], out operand1))
    {
        if (double.TryParse(parts[1], out operand2))
        {
            PerformCalculation(operand1, operand2, operation);
        }
        else if (variables.ContainsKey(parts[1]))
        {
            operand2 = variables[parts[1]];
            PerformCalculation(operand1, operand2, operation);
        }
        else
        {
            Console.WriteLine("Invalid operand or variable.");
        }
    }
    else if (variables.ContainsKey(parts[0]))
    {
        operand1 = variables[parts[0]];

        if (double.TryParse(parts[1], out operand2))
        {
            PerformCalculation(operand1, operand2, operation);
        }
        else if (variables.ContainsKey(parts[1]))
        {
            operand2 = variables[parts[1]];
            PerformCalculation(operand1, operand2, operation);
        }
        else
        {
            Console.WriteLine("Invalid operand or variable.");
        }
    }
    else
    {
        Console.WriteLine("Invalid operand or variable.");
    }
}




    static void CalculateWithVariable(string input)
    {
        string expression = input.Trim('[', ']');
        double result = EvaluateExpression(expression);
        Console.WriteLine($"Result: {result}");
        variables["ans"] = result;
    }

    static double EvaluateExpression(string expression)
    {
        // Parse and evaluate a simple expression like 'variable*5'
        string[] parts = expression.Split('*');
        if (parts.Length == 2 && variables.ContainsKey(parts[0]))
        {
            if (double.TryParse(parts[1], out double multiplier))
            {
                double variableValue = variables[parts[0]];
                return variableValue * multiplier;
            }
        }
        return 0; 
    }

    static void PerformCalculation(double operand1, double operand2, string operation)
    {
        if (operations.TryGetValue(operation, out var operationFunction))
        {
            double result = operationFunction(operand1, operand2);
            Console.WriteLine($"Result: {result}");
            variables["ans"] = result;
        }
        else
        {
            Console.WriteLine("Invalid operation.");
        }
    }
}
