namespace Doubles
{
  [TestClass]
  public class SpyTests
  {
    // Spy logger: records whether Log was called and with what
    private class SpyLogger : ILogger
    {
      public List<string> Calls { get; } = new List<string>();

      public void Log(string message)
      {
        Calls.Add(message);
      }

      public bool WasCalled => Calls.Count > 0;
      public bool WasCalledWith(string expected) =>
          Calls.Any(msg => msg.Contains(expected));
    }

    [TestMethod]
    public void CalculateRent_WithSpyLogger_TracksLoggingBehavior()
    {
      // Arrange
      var spyLogger = new SpyLogger();
      var game = new MonopolyGame();
      game.SetLogger(spyLogger); // Inject spy

      // Act
      int rent = game.CalculateRent("Illinois Avenue", 3);

      // Assert: verify rent is correct
      Assert.AreEqual(750, rent);

      // Assert: verify that logger was used
      Assert.IsTrue(spyLogger.WasCalled, "Logger should have been called.");
      Assert.IsTrue(spyLogger.WasCalledWith("Illinois Avenue"), "Logger should mention the property name.");
      Assert.IsTrue(spyLogger.WasCalledWith("Calculated rent: $750"), "Logger should log the correct rent.");
    }
  }
}