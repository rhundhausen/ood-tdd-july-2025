namespace Doubles
{
  [TestClass]
  public class MockTests
  {
    // Manual mock: verifies interactions with the logger
    private class MockLogger : ILogger
    {
      public List<string> MessagesLogged { get; } = new List<string>();
      public int LogCallCount => MessagesLogged.Count;

      public void Log(string message)
      {
        MessagesLogged.Add(message);
      }

      public void VerifyCalledWith(string expected)
      {
        if (!MessagesLogged.Any(msg => msg.Contains(expected)))
        {
          throw new AssertFailedException($"Expected a log message containing: '{expected}'");
        }
      }

      public void VerifyCallCount(int expected)
      {
        if (LogCallCount != expected)
        {
          throw new AssertFailedException($"Expected {expected} calls, but got {LogCallCount}");
        }
      }
    }

    [TestMethod]
    public void CalculateRent_WithManualMock_VerifiesLoggerInteraction()
    {
      // Arrange
      var mockLogger = new MockLogger();
      var game = new MonopolyGame();
      game.SetLogger(mockLogger); // Inject mock

      // Act
      int rent = game.CalculateRent("Boardwalk", 5);

      // Assert: rent correctness
      Assert.AreEqual(2000, rent);

      // Verify mock interactions
      mockLogger.VerifyCalledWith("Calculating rent for 'Boardwalk'");
      mockLogger.VerifyCalledWith("Calculated rent: $2000");
      mockLogger.VerifyCallCount(2);
    }
  }
}
