using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
  [TestClass]
  public class TollTests
  {
    [TestMethod]
    public void CalculateToll_None_Normal_SpringCreek_Returns6()
    {
      // Arrange
      var calculator = new TollCalculator();

      // Act
      var result = calculator.CalculateToll("None", "Normal", "SPRNG-CRK");

      // Assert
      Assert.AreEqual(6.0m, result);
    }

    [TestMethod]
    public void CalculateToll_None_Normal_LGCY_Returns6()
    {
      var calculator = new TollCalculator();
      var result = calculator.CalculateToll("None", "Normal", "LGCY");
      Assert.AreEqual(6.0m, result);
    }

    [TestMethod]
    public void CalculateToll_Silver_Normal_SpringCreek_Returns4()
    {
      var calculator = new TollCalculator();
      var result = calculator.CalculateToll("Silver", "Normal", "SPRNG-CRK");
      Assert.AreEqual(4.0m, result);
    }

    [TestMethod]
    public void CalculateToll_Gold_Normal_SpringCreek_Returns2()
    {
      var calculator = new TollCalculator();
      var result = calculator.CalculateToll("Gold", "Normal", "SPRNG-CRK");
      Assert.AreEqual(2.0m, result);
    }

    [TestMethod]
    public void CalculateToll_None_Peak_SpringCreek_Returns10()
    {
      var calculator = new TollCalculator();
      var result = calculator.CalculateToll("None", "Peak", "SPRNG-CRK");
      Assert.AreEqual(10.0m, result);
    }

    [TestMethod]
    public void CalculateToll_Silver_Peak_SpringCreek_Returns6()
    {
      var calculator = new TollCalculator();
      var result = calculator.CalculateToll("Silver", "Peak", "SPRNG-CRK");
      Assert.AreEqual(6.0m, result);
    }
  }
}
