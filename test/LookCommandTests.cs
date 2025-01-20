using System.IO.Pipelines;
using Sork.Commands;
using Sork.World;

namespace Sork.Tests;

[TestClass]
public class LookCommandTests
{
    [TestMethod]
    public void Handles_ReturnsTrue_WhenInputIsLook()
    {
        var command = new LookCommand(new UserInputOutput());
        Assert.IsTrue(command.Handles("look"));
    }

    [TestMethod]
    public void Execute_ShouldDisplayRoomInfo()
    {
        var io = new TestInputOutput();
        var command = new LookCommand(io);
        var gameState = GameState.Create(io);
        
        gameState.Player.Location = new Room { Name = "Tavern", Description = "You are in the Tavern." };
        gameState.Player.Location.Exits.Add("down", new Room { Name = "Dungeon", Description = "You are in the dungeon." });
        gameState.Player.Location.Inventory.Add(new Item { Name = "Sword", Description = "A sword" });

        var result = command.Execute("look", gameState);

        Assert.IsTrue(result.IsHandled);
        Assert.IsFalse(result.RequestExit);
        Assert.AreEqual(8, io.Outputs.Count);
        // Assert.AreEqual("Tavern", io.Outputs[0]);
        // Assert.AreEqual("", io.Outputs[1]);
        // Assert.AreEqual("You are in the Tavern.", io.Outputs[2]);
        // Assert.AreEqual("", io.Outputs[3]);
        // Assert.AreEqual("Exits:", io.Outputs[4]);
        // Assert.AreEqual("down - You are in the dungeon.", io.Outputs[5]);
        // Assert.AreEqual("", io.Outputs[5]);
        // Assert.AreEqual("Inventory:", io.Outputs[7]);
        // Assert.AreEqual("Sword - A sword", io.Outputs[8]);
    }
}