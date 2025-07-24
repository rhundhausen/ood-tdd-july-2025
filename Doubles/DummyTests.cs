namespace Doubles
{
  [TestClass]
  public class DummyTests
  {
    // Dummy object: satisfies the ILogger dependency but is not used
    private class DummyLogger : ILogger
    {
      public void Log(string message)
      {
        // Intentionally left blank – dummy does nothing
      }
    }

    [TestMethod]
    public void CalculateRent_WithDummyLogger_ReturnsCorrectValue()
    {
      // Arrange
      var dummyLogger = new DummyLogger();
      var game = new MonopolyGame();
      game.SetLogger(dummyLogger); // Inject dummy

      // Act
      int rent = game.CalculateRent("Boardwalk", 2);

      // Assert
      Assert.AreEqual(600, rent); // This test only cares about the rent
    }
  }
}