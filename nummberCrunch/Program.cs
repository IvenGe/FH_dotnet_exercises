using System;
using System.Collections.Generic;
using System.Linq;

namespace Crunch_the_numbers
{
    class Program
    {
        private static double _ans = 0;
        private static VariableStore _variableStore = new VariableStore();
        private static ICalculator _calculator = new Calculator();
        private static CommandHandler _commandHandler = new CommandHandler();

static void Main(string[] args)
{
    Console.WriteLine("Welcome to Crunch the numbers calculator service. Type /help for instructions");
    while (true)
    {
        Console.Write(">");
        string input = Console.ReadLine();

        if (input.StartsWith("/"))
        {
            var commandResult = _commandHandler.HandleCommand(input, _variableStore, _ans);
            if (!commandResult.Handled)
            {
                Console.WriteLine("Bye!");
                break;
            }
            _ans = commandResult.NewAnsValue;
            continue;
        }

                // Variable assignment
                if (input.Contains("="))
                {
                    string[] tokens = input.Split('=');
                    if (tokens.Length == 2)
                    {
                        string variableName = tokens[0].Trim();
                        if (double.TryParse(tokens[1].Trim(), out double variableValue))
                        {
                            _variableStore[variableName] = variableValue;
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

                // Operations
                char[] operators = { '+', '-', '*', '/', '^' };
                char operatorSymbol = input.FirstOrDefault(op => operators.Contains(op));

                if (Array.IndexOf(operators, operatorSymbol) > -1)  // Checking if the operatorSymbol was found
                {
                    string[] operands = input.Split(operatorSymbol);
                    if (operands.Length == 2)
                    {
                        double operand1 = GetOperandValue(operands[0].Trim());
                        double operand2 = GetOperandValue(operands[1].Trim());

                        if (double.IsNaN(operand1) || double.IsNaN(operand2))
                        {
                            Console.WriteLine("Invalid operand");
                            continue;
                        }

                        _ans = PerformOperation(operand1, operand2, operatorSymbol);
                        Console.WriteLine($"Result: {_ans}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input format");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input format or operator not recognized");
                }
            }
        }

        static double GetOperandValue(string operandStr)
        {
            if (operandStr.Equals("[ans]", StringComparison.OrdinalIgnoreCase))
            {
                return _ans;
            }
            else if (operandStr.StartsWith("[") && operandStr.EndsWith("]") && _variableStore.Contains(operandStr.Substring(1, operandStr.Length - 2)))
            {
                return _variableStore[operandStr.Substring(1, operandStr.Length - 2)];
            }
            else if (double.TryParse(operandStr, out double value))
            {
                return value;
            }
            return double.NaN;
        }

        static double PerformOperation(double operand1, double operand2, char operatorSymbol)
        {
            switch (operatorSymbol)
            {
                case '+': return _calculator.Add(operand1, operand2);
                case '-': return _calculator.Subtract(operand1, operand2);
                case '*': return _calculator.Multiply(operand1, operand2);
                case '/': return _calculator.Divide(operand1, operand2);
                case '^': return _calculator.Power(operand1, operand2);
                default: return double.NaN;
            }
        }
    }
}
