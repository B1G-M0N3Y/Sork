using Sork.Commands;
using Sork.World;

namespace Sork.Tests;

[TestClass]
public sealed class DanceCommandTests
{
    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenInputIsCapitalized()
    {
        // Arrange
        var command = new DanceCommand(new UserInputOutput());

        // Act
        var result = command.Handles("DANCE");

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenInputIsLowerCased()
    {
        // Arrange
        var command = new DanceCommand(new UserInputOutput());

        // Act
        var result = command.Handles("dance");

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Execute_ShouldOutputMessage()
    {
        // Arrange
        var io = new TestInputOutput();
        var command = new DanceCommand(io);
        var gameState = GameState.Create(io);

        // Act
        var result = command.Execute("DANCE", gameState);

        // Assert
        Assert.AreEqual(1, io.Outputs.Count);
        Assert.AreEqual(" dance!", io.Outputs[0]);
        Assert.IsTrue(result.IsHandled);
        Assert.IsFalse(result.RequestExit);
    }
}