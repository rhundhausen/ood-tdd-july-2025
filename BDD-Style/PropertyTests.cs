namespace BDD
{
  [TestClass]
  public class RentTests
  {
    [TestMethod]
    public void BaseBoardwalk_UserLands_UserCharged50()
    {
      // Given
      var property = new Property(name: "Boardwalk", baseRent: 50);

      // When
      int rent = property.CalculateRent();

      // Then
      Assert.AreEqual(50, rent);
    }
  }
}