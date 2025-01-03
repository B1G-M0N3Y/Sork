using System;

namespace Sork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ICommand lol = new LaughCommand();
            ICommand exit = new ExitCommand();
            ICommand dance = new DanceCommand();
            ICommand sing = new SingCommand();
            ICommand whistle = new WhistleCommand();
            List<ICommand> commands = new List<ICommand> { lol, dance, sing, whistle, exit };
            var result = new CommandResult { RequestExit = false, IsHandled = false };
            var handled = false;
            do
            {
                Console.Write(">");
                string input = Console.ReadLine();
                input = input.ToLower();
                input = input.Trim();
                foreach (var command in commands)
                {
                    if (command.Handles(input))
                    {
                        handled = true;
                        result = command.Execute();
                        if (result.RequestExit)
                        {
                            break;
                        }
                    }
                }
                if (result.RequestExit)
                {
                    break;
                }
                if (!handled)
                {
                    Console.WriteLine("Unknown command");
                }
            } while (true);
        }
    }

    public class CommandResult
    {
        public bool RequestExit { get; set; }
        public bool IsHandled { get; set; }
    }

    public interface ICommand
    {
        bool Handles(string userInput);
        CommandResult Execute();
    }

    public class ExitCommand : ICommand
    {
        public bool Handles(string userInput) => userInput == "exit";

        public CommandResult Execute() => new CommandResult { RequestExit = true, IsHandled = true };
    }


    public class LaughCommand : ICommand
    {
        public bool Handles(string userInput)
        {
            return userInput == "lol";
        }

        public CommandResult Execute()
        {
            Console.WriteLine("You laugh out loud");
            return new CommandResult { RequestExit = false, IsHandled = true };
        }
    }

    public class DanceCommand : ICommand
    {
        public bool Handles(string userInput) => userInput == "dance";

        public CommandResult Execute()
        {
            Console.WriteLine("Cha cha cha");
            return new CommandResult { RequestExit = false, IsHandled = true };
        }
    }

    public class SingCommand : ICommand
    {
        public bool Handles(string userInput) => userInput == "sing";

        public CommandResult Execute()
        {
            Console.WriteLine("Play Freebird!");
            return new CommandResult { RequestExit = false, IsHandled = true };
        }
    }

    public class WhistleCommand : ICommand
    {
        public bool Handles(string userInput) => userInput == "whistle";

        public CommandResult Execute()
        {
            Console.WriteLine("What a lovely tune");
            return new CommandResult { RequestExit = false, IsHandled = true };
        }
    }
}
