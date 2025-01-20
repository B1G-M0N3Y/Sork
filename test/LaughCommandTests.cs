using Sork.Commands;
using Sork.World;

namespace Sork.Tests;

[TestClass]
public sealed class LaughCommandTests
{
    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenInputIsCapitalized()
    {
        // Arrange
        var command = new LaughCommand(new UserInputOutput());

        // Act
        var result = command.Handles("LOL");

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenInputIsLowerCased()
    {
        // Arrange
        var command = new LaughCommand(new UserInputOutput());
    
        // Act
        var result = command.Handles("lol");

        // Assert
        Assert.IsTrue(result);
    }   

    [TestMethod]
    public void Execute_ShouldOutputMessage()
    {
        // Arrange
        var io = new TestInputOutput();
        var command = new LaughCommand(io);
        var gameState = GameState.Create(io);

        // Act
        var result = command.Execute("LOL", gameState);

        // Assert
        Assert.AreEqual(1, io.Outputs.Count);
        Assert.AreEqual(" laugh out loud!", io.Outputs[0]);
        Assert.IsTrue(result.IsHandled);
        Assert.IsFalse(result.RequestExit);
    }
}
