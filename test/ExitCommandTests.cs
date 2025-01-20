using Sork.Commands;

namespace Sork.Tests;

[TestClass]
public sealed class ExitCommandTests
{
    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenInputIsCapitalized()
    {
        // Arrange
        var command = new ExitCommand(new UserInputOutput());

        // Act
        var result = command.Handles("EXIT");

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenInputIsLowerCased()
    {
        // Arrange
        var command = new ExitCommand(new UserInputOutput());

        // Act
        var result = command.Handles("exit");

        // Assert
        Assert.IsTrue(result);
    }
}