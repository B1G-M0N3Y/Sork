namespace Sork;
public class DanceCommand : ICommand
{
    public bool Handles(string userInput) => userInput == "dance";

    public CommandResult Execute()
    {
        Console.WriteLine("Cha cha cha");
        return new CommandResult { RequestExit = false, IsHandled = true };
    }
}