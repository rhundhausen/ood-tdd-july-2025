namespace UnitTesting
{
  [TestClass]
  public class TollTestsDataDriven
  {
    // Can also use [DynamicData] (with a method or property source)
    // [DataSource] (for legacy, external sources)

    [DataTestMethod]
    [DataRow("None", "Normal", "SPRNG-CRK", 6.0)]
    [DataRow("None", "Normal", "LGCY", 6.0)]
    [DataRow("Silver", "Normal", "SPRNG-CRK", 4.0)]
    [DataRow("Gold", "Normal", "SPRNG-CRK", 2.0)]
    [DataRow("None", "Peak", "SPRNG-CRK", 10.0)]
    [DataRow("Silver", "Peak", "SPRNG-CRK", 6.0)]
    public void CalculateToll_ReturnsExpectedAmount(
      string membershipLevel,
      string rateLevel,
      string tollPassed,
      double expectedCharge)
    {
      var calculator = new TollCalculator();

      var result = calculator.CalculateToll(membershipLevel, rateLevel, tollPassed);

      Assert.AreEqual((decimal)expectedCharge, result);
    }
  }
}