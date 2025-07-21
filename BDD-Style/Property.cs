public class Property
{
  public string Name { get; }
  public int BaseRent { get; }

  public Property(string name, int baseRent)
  {
    Name = name;
    BaseRent = baseRent;
  }

  public int CalculateRent()
  {
    return BaseRent;
  }
}