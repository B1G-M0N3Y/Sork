namespace Sork;
public class SingCommand : ICommand
{
    public bool Handles(string userInput) => userInput == "sing";

    public CommandResult Execute()
    {
        Console.WriteLine("Play Freebird!");
        return new CommandResult { RequestExit = false, IsHandled = true };
    }
}
