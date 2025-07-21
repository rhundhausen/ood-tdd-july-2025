namespace S_O_LID
{
  // ❌ Violates Open/Closed Principle
  // Requires modification when adding new rent types
  public class Property_OCP_Broken
  {
    public string? Name { get; set; }
    public double Price { get; set; }
    public string? Type { get; set; }

    public double CalculateRent()
    {
      if (Type == "Standard")
        return Price * 0.1;
      else if (Type == "Luxury")
        return Price * 0.2;
      else
        return 0;
    }
  }


  // ✅ Follows Open/Closed Principle
  // New rent logic is added by extending the base class

  public abstract class PropertyBase
  {
    public string? Name { get; set; }
    public double Price { get; set; }

    public virtual double CalculateRent()
    {
      return 0;
    }
  }

  public class StandardProperty : PropertyBase
  {
    public override double CalculateRent()
    {
      return Price * 0.1;
    }
  }

  public class LuxuryProperty : PropertyBase
  {
    public override double CalculateRent()
    {
      return Price * 0.2;
    }
  }

  public class DoubleWideProperty : PropertyBase
  {
    public override double CalculateRent()
    {
      return Price * 0.5;
    }
  }
}
