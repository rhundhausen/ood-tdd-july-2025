namespace Doubles
{
  [TestClass]
  public class StubTests
  {
    // Stub logger: captures log messages for inspection
    private class StubLogger : ILogger
    {
      public List<string> LoggedMessages { get; } = new List<string>();

      public void Log(string message)
      {
        LoggedMessages.Add(message);
      }
    }

    [TestMethod]
    public void CalculateRent_WithStubLogger_LogsExpectedMessages()
    {
      // Arrange
      var stubLogger = new StubLogger();
      var game = new MonopolyGame();
      game.SetLogger(stubLogger); // Inject stub

      // Act
      int rent = game.CalculateRent("Park Place", 1);

      // Assert: verify correct rent
      Assert.AreEqual(175, rent);

      // Assert: verify log messages were written
      Assert.IsTrue(stubLogger.LoggedMessages.Any(msg => msg.Contains("Calculating rent for 'Park Place'")));
      Assert.IsTrue(stubLogger.LoggedMessages.Any(msg => msg.Contains("Calculated rent: $175")));
    }
  }
}
