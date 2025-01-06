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

}
