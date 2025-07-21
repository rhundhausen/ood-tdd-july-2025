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

  }
}