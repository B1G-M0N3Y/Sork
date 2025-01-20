using Sork.Commands;
using Sork.World;

namespace Sork.Tests;

[TestClass]
public sealed class SingCommandTests
{
    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenInputIsCapitalized()
    {
        // Arrange
        var command = new SingCommand(new UserInputOutput());

        // Act
        var result = command.Handles("SING");

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenInputIsLowerCased()
    {
        // Arrange
        var command = new SingCommand(new UserInputOutput());

        // Act
        var result = command.Handles("sing");

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Execute_ShouldOutputMessage()
    {
        // Arrange
        var io = new TestInputOutput();
        var command = new SingCommand(io);
        var gameState = GameState.Create(io);

        // Act
        var result = command.Execute("SING", gameState);

        // Assert
        Assert.AreEqual(1, io.Outputs.Count);
        Assert.AreEqual(" sing!", io.Outputs[0]);
        Assert.IsTrue(result.IsHandled);
        Assert.IsFalse(result.RequestExit);
    }
}