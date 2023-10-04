    public class CommandHandler
    {
        public (bool Handled, double NewAnsValue) HandleCommand(string command, VariableStore variableStore, double currentAns)

        
        {
            switch (command.ToLower())
            {
                case "/help":
                    DisplayHelp();
                    return (true, currentAns);
                case "/list":
                    ListVariables(variableStore, currentAns);
                    return (true, currentAns);
                case "/clear":
                    variableStore.Clear();
                    Console.WriteLine("All variables have been cleared");
                    return (true, currentAns);
                case "/stop":
                    return (false, currentAns);
                default:
                    Console.WriteLine("Invalid command");
                    return (true, currentAns);
            }
        }

        private void DisplayHelp()
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

        private void ListVariables(VariableStore variableStore, double ansValue)
        {
            Console.WriteLine($"ans = {ansValue}");
            foreach (var variable in variableStore.GetAll())
            {
                Console.WriteLine($"{variable.Key} = {variable.Value}");
            }
        }
    }