namespace BDD
{
  [TestClass]
  public class RentTests
  {
    [TestMethod]
    public void CalculateRent_ReturnsBaseRent_ForBoardwalk()
    {
      // Arrange
      var property = new Property(name: "Boardwalk", baseRent: 50);

      // Act
      int rent = property.CalculateRent();

      // Assert
      Assert.AreEqual(50, rent);
    }
  }
}