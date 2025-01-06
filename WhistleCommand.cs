namespace Sork;
public class WhistleCommand : ICommand
{
    public bool Handles(string userInput) => userInput == "whistle";

    public CommandResult Execute()
    {
        Console.WriteLine("What a lovely tune");
        return new CommandResult { RequestExit = false, IsHandled = true };
    }
}