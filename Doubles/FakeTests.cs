namespace Doubles
{
  [TestClass]
  public class FakeTests
  {
    // Fake logger: behaves like a lightweight in-memory log system
    private class FakeLogger : ILogger
    {
      public string LogOutput { get; private set; } = string.Empty;

      public void Log(string message)
      {
        // Simulates appending to a real log
        LogOutput += $"{DateTime.Now}: {message}\n";
      }

      public bool ContainsMessage(string content)
      {
        return LogOutput.Contains(content);
      }
    }

    [TestMethod]
    public void CalculateRent_WithFakeLogger_AppendsFormattedMessages()
    {
      // Arrange
      var fakeLogger = new FakeLogger();
      var game = new MonopolyGame();
      game.SetLogger(fakeLogger); // Inject fake

      // Act
      int rent = game.CalculateRent("Virginia Avenue", 2);

      // Assert: rent correctness
      Assert.AreEqual(180, rent);

      // Assert: fake logger has a formatted message (like a real log)
      Assert.IsTrue(fakeLogger.ContainsMessage("Calculating rent for 'Virginia Avenue'"));
      Assert.IsTrue(fakeLogger.ContainsMessage("Calculated rent: $180"));
    }
  }
}
