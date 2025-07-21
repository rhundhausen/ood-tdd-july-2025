namespace SOL_I_D
{
  // ❌ Violates Interface Segregation Principle
  // This interface forces all properties to implement features they may not need
  public interface IProperty_Broken
  {
    double CalculateRent();
    void BuildHouse();
    void Mortgage();
  }

  // This class is fine — it supports all features
  public class StandardProperty_Broken : IProperty_Broken
  {
    public double CalculateRent() => 100;
    public void BuildHouse() { /* build logic */ }
    public void Mortgage() { /* mortgage logic */ }
  }

  // But this class shouldn't be forced to support houses
  public class UtilityProperty_Broken : IProperty_Broken
  {
    public double CalculateRent() => 75;

    // These methods do nothing or throw, which is a red flag
    public void BuildHouse()
    {
      throw new NotSupportedException("Utilities can't have houses.");
    }

    public void Mortgage()
    {
      // valid logic here
    }
  }


  // ✅ Follows Interface Segregation Principle
  // Interfaces are small and focused on specific responsibilities

  public interface IRentable
  {
    double CalculateRent();
  }

  public interface IHouseBuildable
  {
    void BuildHouse();
  }

  public interface IMortgageable
  {
    void Mortgage();
  }

  // Standard property uses all features
  public class StandardProperty_Correct : IRentable, IHouseBuildable, IMortgageable
  {
    public double CalculateRent() => 100;
    public void BuildHouse() { /* build logic */ }
    public void Mortgage() { /* mortgage logic */ }
  }

  // Utility property only uses what's relevant
  public class UtilityProperty_Correct : IRentable, IMortgageable
  {
    public double CalculateRent() => 75;
    public void Mortgage() { /* mortgage logic */ }
  }
}
