namespace Doubles
{
  [TestClass]
  public class IntegrationTests
  {
    private class TestLogger : ILogger
    {
      public string LastMessage { get; private set; }

      public void Log(string message)
      {
        LastMessage = message;
        Console.WriteLine(message); // Optional: output to test console
      }
    }

    [TestMethod]
    public void CalculateRent_ForValidPropertyWithHouses_ReturnsCorrectRent()
    {
      var logger = new TestLogger();
      var game = new MonopolyGame();
      game.SetLogger(logger);

      int rent = game.CalculateRent("Marvin Gardens", 4);

      Assert.AreEqual(1025, rent);
      Assert.IsTrue(logger.LastMessage.Contains("1025"));
    }

    [TestMethod]
    public void CalculateRent_LogsBeforeAndAfterCalculation()
    {
      var logger = new TestLogger();
      var game = new MonopolyGame();
      game.SetLogger(logger);

      game.CalculateRent("Connecticut Avenue", 3);

      // The last message should be the final rent result
      Assert.IsTrue(logger.LastMessage.Contains("Calculated rent: $300"));
    }

    [TestMethod]
    public void MultipleRentCalculations_AreConsistent()
    {
      var game = new MonopolyGame();

      int rent1 = game.CalculateRent("Illinois Avenue", 0); // 20
      int rent2 = game.CalculateRent("Illinois Avenue", 5); // 1100

      Assert.AreEqual(20, rent1);
      Assert.AreEqual(1100, rent2);
    }
  }
}
