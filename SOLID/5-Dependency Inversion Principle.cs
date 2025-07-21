namespace SOLI_D_
{
  // ❌ Violates Dependency Inversion Principle
  // High-level class depends on a concrete implementation
  public class RentManager_Broken
  {
    private readonly StandardProperty_Broken _property;

    public RentManager_Broken()
    {
      _property = new StandardProperty_Broken(); // tight coupling
    }

    public double CollectRent()
    {
      return _property.CalculateRent();
    }
  }

  public class StandardProperty_Broken
  {
    public double CalculateRent() => 100;
  }


  // ✅ Follows Dependency Inversion Principle
  // High-level class depends on an abstraction

  // Abstraction (could also be an interface if preferred later)
  public abstract class PropertyBase
  {
    public abstract double CalculateRent();
  }

  public class StandardProperty_Correct : PropertyBase
  {
    public override double CalculateRent() => 100;
  }

  public class LuxuryProperty_Correct : PropertyBase
  {
    public override double CalculateRent() => 200;
  }

  public class RentManager_Correct
  {
    private readonly PropertyBase _property;

    // Dependency is injected from outside (constructor injection)
    public RentManager_Correct(PropertyBase property)
    {
      _property = property;
    }

    public double CollectRent()
    {
      return _property.CalculateRent();
    }
  }
}
