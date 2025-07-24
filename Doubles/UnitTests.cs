namespace Doubles
{
  [TestClass]
  public class UnitTests
  {
    private MonopolyGame game;

    [TestInitialize]
    public void Setup()
    {
      game = new MonopolyGame();
    }

    [TestMethod]
    public void Rent_Boardwalk_With3Houses_ShouldBe1400()
    {
      int rent = game.CalculateRent("Boardwalk", 3);
      Assert.AreEqual(1400, rent);
    }

    [TestMethod]
    public void Rent_Mediterranean_With0Houses_ShouldBe2()
    {
      int rent = game.CalculateRent("Mediterranean Avenue", 0);
      Assert.AreEqual(2, rent);
    }

    [TestMethod]
    public void Rent_Illinois_With4Houses_ShouldBe925()
    {
      int rent = game.CalculateRent("Illinois Avenue", 4);
      Assert.AreEqual(925, rent);
    }

    [TestMethod]
    public void Rent_ParkPlace_WithHotel_ShouldBe1500()
    {
      int rent = game.CalculateRent("Park Place", 5);
      Assert.AreEqual(1500, rent);
    }

    [TestMethod]
    public void Rent_Tennessee_With1House_ShouldBe70()
    {
      int rent = game.CalculateRent("Tennessee Avenue", 1);
      Assert.AreEqual(70, rent);
    }

    [TestMethod]
    public void Rent_StJames_With2Houses_ShouldBe200()
    {
      int rent = game.CalculateRent("St. James Place", 2);
      Assert.AreEqual(200, rent);
    }

    [TestMethod]
    public void Rent_Pennsylvania_WithHotel_ShouldBe1400()
    {
      int rent = game.CalculateRent("Pennsylvania Avenue", 5);
      Assert.AreEqual(1400, rent);
    }

    [TestMethod]
    public void Rent_Baltic_With3Houses_ShouldBe180()
    {
      int rent = game.CalculateRent("Baltic Avenue", 3);
      Assert.AreEqual(180, rent);
    }

    // Sad Path Test: Invalid property name
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Rent_InvalidProperty_ShouldThrowException()
    {
      game.CalculateRent("Unknown Street", 2);
    }

    // Sad Path Test: Invalid number of buildings
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Rent_InvalidBuildingCount_ShouldThrowException()
    {
      game.CalculateRent("Boardwalk", 6);
    }
  }
}
