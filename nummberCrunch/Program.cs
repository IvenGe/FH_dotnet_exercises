using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, Func<double, double, double>> operations = new Dictionary<string, Func<double, double, double>>()
    {
        { "+", (a, b) => a + b },
        { "-", (a, b) => a - b },
        { "*", (a, b) => a * b },
        { "/", (a, b) => a / b },
        { "^", Math.Pow },
    };

    static Dictionary<string, double> variables = new Dictionary<string, double>();
    static double ans;

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Crunch the Numbers!");
        Console.WriteLine("Type /help for instructions or /stop to exit.");

        while (true)
        {
            Console.Write(">");
            string input = Console.ReadLine();

            if (input == "/stop")
            {
                Console.WriteLine("Goodbye!");
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
        Console.WriteLine("Available commands:");
        Console.WriteLine("/add, /subtract, /multiply, /divide, /power - Perform math operations.");
        Console.WriteLine("/list - List all variables and their values.");
        Console.WriteLine("/clear - Clear the list of variables.");
        Console.WriteLine("/stop - Exit the program.");
    }

    static void ListVariables()
    {
        if (variables.Count == 0)
        {
            Console.WriteLine("No variables defined.");
        }
        else
        {
            foreach (var kvp in variables)
            {
                Console.WriteLine($"[{kvp.Key}]: {kvp.Value}");
            }
        }
    }

    static void ClearVariables()
    {
        variables.Clear();
        Console.WriteLine("Variables cleared.");
    }

    static void AssignVariable(string input)
    {
        string[] parts = input.Split('=');
        if (parts.Length == 2)
        {
            string variableName = parts[0].Trim();
            if (!variables.ContainsKey(variableName))
            {
                double value;
                if (double.TryParse(parts[1].Trim(), out value))
                {
                    variables[variableName] = value;
                    Console.WriteLine($"={value}");
                }
                else
                {
                    Console.WriteLine("Invalid value for assignment.");
                }
            }
            else
            {
                Console.WriteLine("Variable already exists.");
            }
        }
        else
        {
            Console.WriteLine("Invalid assignment syntax.");
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

        if (!double.TryParse(parts[0], out operand1) || !double.TryParse(parts[2], out operand2))
        {
            Console.WriteLine("Invalid operands.");
            return;
        }

        if (operations.TryGetValue(operation, out var operationFunction))
        {
            ans = operationFunction(operand1, operand2);
            Console.WriteLine($"={ans}");
        }
        else
        {
            Console.WriteLine("Invalid operation.");
        }
    }
}
