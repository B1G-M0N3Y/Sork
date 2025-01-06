namespace Sork.Commands;
public class SingCommand : BaseCommand
{
    private readonly UserInputOutput io;
    public SingCommand(UserInputOutput io)
    {
        this.io = io;
    }
    public override bool Handles(string userInput) => GetCommandFromInput(userInput) == "sing";

    public override CommandResult Execute()
    {
        io.WriteMessageLine("Play Freebird!");
        return new CommandResult { RequestExit = false, IsHandled = true };
    }
}
