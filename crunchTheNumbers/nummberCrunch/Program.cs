using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("╭━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━╮");
        Console.WriteLine("     🌟 Welcome to the Number Cruncher 🌟      ");
        Console.WriteLine("         🚀 Let's Crunch Some Numbers! 🚀        ");
        Console.WriteLine("╰━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━╯");

        ICalculator calculator = new Calculator();
        IVariableManager variableManager = new VariableManager();
        ICommandProcessor processor = new CommandProcessor(calculator, variableManager);

        while (true)
        {
            Console.Write(">");
            string input = Console.ReadLine();

            if (input == "/stop")
            {
                Console.WriteLine("Bye!");
                break;
            }

            processor.ProcessInput(input);
        }
    }
}










