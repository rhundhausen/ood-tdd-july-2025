//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;

//namespace UnitTesting
//{
//  [TestClass]
//  public class TollCalculator_UnhappyPathTests
//  {
//    private TollCalculator calculator;

//    [TestInitialize]
//    public void Setup()
//    {
//      calculator = new TollCalculator();
//    }

//    // 1. Invalid Membership Level
//    [TestMethod]
//    [ExpectedException(typeof(ArgumentException))]
//    public void CalculateToll_InvalidMembership_ThrowsArgumentException()
//    {
//      calculator.CalculateToll("Platinum", "Normal", "SPRNG-CRK");
//    }

//    // 2. Null Membership Level
//    [TestMethod]
//    [ExpectedException(typeof(ArgumentNullException))]
//    public void CalculateToll_NullMembership_ThrowsArgumentNullException()
//    {
//      calculator.CalculateToll(null, "Normal", "SPRNG-CRK");
//    }

//    // 3. Empty Rate Level
//    [TestMethod]
//    [ExpectedException(typeof(ArgumentException))]
//    public void CalculateToll_EmptyRateLevel_ThrowsArgumentException()
//    {
//      calculator.CalculateToll("None", "", "SPRNG-CRK");
//    }

//    // 4. Unknown Toll Name
//    [TestMethod]
//    [ExpectedException(typeof(ArgumentException))]
//    public void CalculateToll_UnknownTollName_ThrowsArgumentException()
//    {
//      calculator.CalculateToll("Gold", "Normal", "UNKNOWN-TOLL");
//    }

//    // 5. Lowercase Membership Level (Case Sensitivity)
//    [TestMethod]
//    public void CalculateToll_LowercaseMembership_HandledGracefullyOrFails()
//    {
//      // Depending on your implementation, this might pass or throw.
//      // You can assert expected behavior.
//      try
//      {
//        var result = calculator.CalculateToll("gold", "Normal", "SPRNG-CRK");
//        // If allowed, check the value
//        Assert.AreEqual(2.0m, result); // Only if your method normalizes input
//      }
//      catch (ArgumentException)
//      {
//        Assert.IsTrue(true); // Acceptable if invalid inputs are not normalized
//      }
//    }

//    // 6. Invalid Combination (Valid values but not compatible)
//    [TestMethod]
//    [ExpectedException(typeof(InvalidOperationException))]
//    public void CalculateToll_InvalidCombination_ThrowsInvalidOperationException()
//    {
//      calculator.CalculateToll("Gold", "Night", "SPRNG-CRK"); // Assuming "Night" is not a valid rate level
//    }

//    // 7. Null Toll Name
//    [TestMethod]
//    [ExpectedException(typeof(ArgumentNullException))]
//    public void CalculateToll_NullTollName_ThrowsArgumentNullException()
//    {
//      calculator.CalculateToll("Silver", "Normal", null);
//    }

//    // 8. Injection Attack String
//    [TestMethod]
//    [ExpectedException(typeof(ArgumentException))]
//    public void CalculateToll_SQLInjectionInput_ThrowsArgumentException()
//    {
//      calculator.CalculateToll("None", "Normal", "'; DROP TABLE TollRates; --");
//    }

//    // 9. Long Invalid Input String
//    [TestMethod]
//    [ExpectedException(typeof(ArgumentException))]
//    public void CalculateToll_VeryLongTollName_ThrowsArgumentException()
//    {
//      var longInput = new string('A', 1000);
//      calculator.CalculateToll("None", "Normal", longInput);
//    }
//  }
//}
