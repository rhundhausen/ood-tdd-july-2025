using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reqnroll;

namespace ReqnrollDemo.StepDefinitions
{
  [Binding]
  public class RentCalculationForBoardwalkStepDefinitions
  {
    private string _property;
    private int _houseCount;
    private int _calculatedRent;

    [Given("the property is {string}")]
    public void GivenThePropertyIs(string property)
    {
      _property = property;
    }

    [Given("the number of houses on the property is {int}")]
    public void GivenTheNumberOfHousesOnThePropertyIs(int houseCount)
    {
      _houseCount = houseCount;
    }

    [Given("a player lands on the property")]
    public void GivenAPlayerLandsOnTheProperty()
    {
      // Nothing needed here for now
    }

    [When("rent is calculated")]
    public void WhenRentIsCalculated()
    {
      if (_property == "Boardwalk")
      {
        switch (_houseCount)
        {
          case 0:
            _calculatedRent = 50;
            break;
          case 1:
            _calculatedRent = 200;
            break;
          case 2:
            _calculatedRent = 600;
            break;
          case 3:
            _calculatedRent = 1400;
            break;
          case 4:
            _calculatedRent = 1700;
            break;
          default:
            _calculatedRent = 2000; // Hotel
            break;
        }
      }
      else
      {
        _calculatedRent = 0;
      }
    }

    [Then("the rent charged should be ${int}")]
    public void ThenTheRentChargedShouldBe(int expectedRent)
    {
      Assert.AreEqual(expectedRent, _calculatedRent);
    }
  }
}