namespace SO_L_ID
{
  // ❌ Violates Liskov Substitution Principle
  // Subclass changes expected behavior of the base class
  public class Property_LSP_Base
  {
    public virtual double CalculateRent()
    {
      return 100;
    }
  }

  // This subclass overrides the method, but returns 0 rent
  // Substituting this where a normal property is expected may break logic
  public class FreeParkingProperty : Property_LSP_Base
  {
    public override double CalculateRent()
    {
      return 0;
    }
  }

  // Somewhere in code expecting rent >= 100
  public class RentCollector
  {
    public double Collect(Property_LSP_Base property)
    {
      // This assumes the property generates some rent
      double rent = property.CalculateRent();
      if (rent < 50)
      {
        throw new InvalidOperationException("Rent too low!");
      }
      return rent;
    }
  }


  // ✅ Follows Liskov Substitution Principle
  // Subclasses behave in a way that does not violate expectations

  public class Property_LSP_Correct
  {
    public virtual double CalculateRent()
    {
      return 100;
    }
  }

  public class PremiumProperty : Property_LSP_Correct
  {
    public override double CalculateRent()
    {
      return 150; // Still consistent with expected behavior
    }
  }

  public class Collector_LSP_Correct
  {
    public double Collect(Property_LSP_Correct property)
    {
      // All subclasses honor the expectation: rent >= 100
      return property.CalculateRent();
    }
  }
}
