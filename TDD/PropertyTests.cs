namespace TDD
{
  [TestClass]
  public class RentTests
  {
    [TestMethod]
    public void CalculateRent_ReturnsBaseRent_ForBoardwalk()
    {
      var property = new Property(name: "Boardwalk", baseRent: 50);
      int rent = property.CalculateRent();
      Assert.AreEqual(50, rent);
    }

    [TestMethod]
    public void CalculateRent_ReturnsBaseRent_ForMediterraneanAve()
    {
      var property = new Property(name: "Mediterranean Avenue", baseRent: 2);
      int rent = property.CalculateRent();
      Assert.AreEqual(2, rent);
    }

    [TestMethod]
    public void CalculateRent_ReturnsCorrectRent_ForBoardwalkWithOneHouse()
    {
      var property = new Property(name: "Boardwalk", baseRent: 50);
      property.Houses = 1;
      int rent = property.CalculateRent();
      Assert.AreEqual(200, rent); // 1 house on Boardwalk
    }

    [TestMethod]
    public void CalculateRent_ReturnsCorrectRent_ForBoardwalkWithTwoHouses()
    {
      var property = new Property(name: "Boardwalk", baseRent: 50);
      property.Houses = 2;
      int rent = property.CalculateRent();
      Assert.AreEqual(600, rent); // 1 house on Boardwalk
    }
  }
}