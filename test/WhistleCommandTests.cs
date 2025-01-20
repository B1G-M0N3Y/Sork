using Sork.Commands;
using Sork.World;

namespace Sork.Tests;

[TestClass]
public sealed class WhistleCommandTests
{
    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenInputIsCapitalized()
    {
        // Arrange
        var command = new WhistleCommand(new UserInputOutput());

        // Act
        var result = command.Handles("WHISTLE");

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenInputIsLowerCased()
    {
        // Arrange
        var command = new WhistleCommand(new UserInputOutput());

        // Act
        var result = command.Handles("whistle");

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Execute_ShouldOutputMessage()
    {
        // Arrange
        var io = new TestInputOutput();
        var command = new WhistleCommand(io);
        var gameState = GameState.Create(io);

        // Act
        var result = command.Execute("WHISTLE", gameState);

        // Assert
        Assert.IsTrue(result.IsHandled);
        Assert.IsFalse(result.RequestExit);
        Assert.AreEqual(1, io.Outputs.Count);
        Assert.AreEqual(" whistle!", io.Outputs[0]);
    }
}