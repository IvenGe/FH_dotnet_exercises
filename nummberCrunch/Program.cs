namespace Crunch_the_numbers
{
    class Program
    {
        static double ans = 0;
        static Dictionary<string, double> variables = new Dictionary<string, double>();
        static void Main(string[] args)
        
        {
             Console.WriteLine("Welcome to Crunch the numbers calculator service. Type /help for instructions");
            while (true)
            {

                Console.Write(">");
                string input = Console.ReadLine();

                if (input.ToLower() == "/help")
                {
                    Console.WriteLine("Here are some instructions to help you use the app:");
                    Console.WriteLine("1. To perform a calculation, enter an expression in the format 'operand1 operator operand2', e.g., '5 + 3'.");
                    Console.WriteLine("The operators you can use are +, -, *, / and ^");
                    Console.WriteLine("You can only use one operand at a time. If you want to use negative numbers you need to store them in a variable first. (More of that further down)");
                    Console.WriteLine("2. To use the result of the last calculation in a new calculation, use '[ans]' as an operand, e.g., '[ans] * 2'.");
                    Console.WriteLine("3. To assign a value to a variable, enter an expression in the format 'variableName = value', e.g., 'x = 5'.");
                    Console.WriteLine("4. To use a variable in a calculation, enclose the variable name in square brackets, e.g., '[x] + 3'.");
                    Console.WriteLine("5. To list all saved variables and their values, enter the command '/list'.");
                    Console.WriteLine("6. To clear all saved variables, enter the command '/clear'.");
                    Console.WriteLine("7. To exit the app, enter the command '/stop'.");
                    continue;
                }

                if (input.ToLower() == "/list")
                {
                    Console.WriteLine($"ans = {ans}");
                    foreach (var variable in variables)
                    {
                        Console.WriteLine($"{variable.Key} = {variable.Value}");
                    }
                    continue;
                }

                if (input.ToLower() == "/clear")
                {
                    variables.Clear();
                    Console.WriteLine("All variables have been cleared");
                    continue;
                }

                if (input.ToLower() == "/stop")
                {
                    break;
                }

                if (input.Contains("="))
                {
                    string[] tokens = input.Split('=');
                    if (tokens.Length == 2)
                    {
                        string variableName = tokens[0].Trim();
                        double variableValue;
                        if (double.TryParse(tokens[1].Trim(), out variableValue))
                        {
                            variables[variableName] = variableValue;
                            Console.WriteLine($"Variable '{variableName}' set to {variableValue}");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Invalid value for variable assignment");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input format for variable assignment");
                        continue;
                    }
                }

                char[] operators = { '+', '-', '*', '/', '^' };
                char operatorSymbol = ' ';
                int operatorIndex = -1;

                foreach (char op in operators)
                {
                    operatorIndex = input.IndexOf(op);
                    if (operatorIndex != -1)
                    {
                        operatorSymbol = op;
                        break;
                    }
                }

                if (operatorIndex != -1)
                {
                    string leftOperandStr = input.Substring(0, operatorIndex).Trim();
                    string rightOperandStr = input.Substring(operatorIndex + 1).Trim();

                    double operand1 = 0;
                    double operand2 = 0;

                    if (leftOperandStr.ToLower() == "[ans]" ||
                    (leftOperandStr.StartsWith("[") &&
                    leftOperandStr.EndsWith("]") && variables.TryGetValue(leftOperandStr.Substring
                    (1, leftOperandStr.Length - 2), out operand1)))
                    {
                        operand1 = leftOperandStr.ToLower() == "[ans]" ? ans : operand1;
                    }
                    else
                    {
                        if (!double.TryParse(leftOperandStr, out operand1))
                        {
                            Console.WriteLine("Invalid left operand");
                            continue;
                        }
                    }

                    if (rightOperandStr.ToLower() == "[ans]" || 
                    (rightOperandStr.StartsWith("[") && rightOperandStr.EndsWith("]") && 
                    variables.TryGetValue(rightOperandStr.Substring
                    (1, rightOperandStr.Length - 2), out operand2)))
                    {
                        operand2 = rightOperandStr.ToLower() == "[ans]" ? ans : operand2;
                    }
                    else
                    {
                        if (!double.TryParse(rightOperandStr, out operand2))
                        {
                            Console.WriteLine("Invalid right operand");
                            continue;
                        }
                    }

                    double result = 0;
                    switch (operatorSymbol)
                    {
                        case '+':
                            result = operand1 + operand2;
                            break;
                        case '-':
                            result = operand1 - operand2;
                            break;
                        case '*':
                            result = operand1 * operand2;
                            break;
                        case '/':
                            result = operand1 / operand2;
                            break;
                        case '^':
                            result = Math.Pow(operand1, operand2);
                            break;
                        default:
                            Console.WriteLine("Invalid operator");
                            return;
                    }

                    ans = result;
                    Console.WriteLine("Result: " + result);
                }
                else
                {
                    Console.WriteLine("Invalid input format");
                }
            }
        }
    }
}