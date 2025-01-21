using Sork.World;
namespace Sork.Commands;
public class DropCommand : BaseCommand
{
    private readonly IUserInputOutput io;
    public DropCommand(IUserInputOutput io)
    {
        this.io = io;
    }
    public override bool Handles(string userInput)
    {
        return GetCommandFromInput(userInput) == "drop";
    }
    public override CommandResult Execute(string userInput, GameState gameState)
    {
        var parameters = GetParametersFromInput(userInput);
        
        if (parameters.Length == 0)
        {
            io.WriteMessageLine("You must specify an item to drop.");
            return new CommandResult { RequestExit = false, IsHandled = false };
        }
        
        var item = gameState
            .Player
            .Inventory
            .FirstOrDefault(i => i.Name.ToLower() == parameters[0].ToLower());
        
        if (item == null)
        {
            io.WriteMessageLine("You don't have that item.");
            return new CommandResult { RequestExit = false, IsHandled = false };
        }
        
        gameState.Player.Location.Inventory.Add(item);
        gameState.Player.Inventory.Remove(item);
        return new CommandResult { RequestExit = false, IsHandled = true };
    }
}