using System;
using System.Collections.Generic;

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
                else
                {
                    Calculate(input);
                }
                break;
        }
    }

    static void ShowHelp()
    {
Console.WriteLine("╭━━━━━━━━━━━━━━━━━━━━━━━━━━╮");
Console.WriteLine("    🌟 Crunch the Numbers 🌟    ");
Console.WriteLine("  🚀 Available Commands 🚀  ");
Console.WriteLine("╰━━━━━━━━━━━━━━━━━━━━━━━━━━╯");
Console.WriteLine("📜  /list    - List Variables");
Console.WriteLine("🗑️  /clear   - Clear Variables");
Console.WriteLine("❓  /help    - Show Help");
Console.WriteLine("🛑  /stop    - Exit Program");
Console.WriteLine("╰━━━━━━━━━━━━━━━━━━━━━━━━━━╯");
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
        string[] parts = input.Split(' ');

        if (parts.Length != 3)
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        string operation = parts[1];
        double operand1, operand2;

        if (double.TryParse(parts[0], out operand1))
        {
            if (double.TryParse(parts[2], out operand2))
            {
                PerformCalculation(operand1, operand2, operation);
            }
            else if (variables.ContainsKey(parts[2]))
            {
                operand2 = variables[parts[2]];
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

            if (double.TryParse(parts[2], out operand2))
            {
                PerformCalculation(operand1, operand2, operation);
            }
            else if (variables.ContainsKey(parts[2]))
            {
                operand2 = variables[parts[2]];
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

    static void PerformCalculation(double operand1, double operand2, string operation)
    {
        if (operations.TryGetValue(operation, out var operationFunction))
        {
            double result = operationFunction(operand1, operand2);
            Console.WriteLine($"{result}");
        }
        else
        {
            Console.WriteLine("Invalid operation.");
        }
    }
}
