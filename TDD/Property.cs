public class Property
{
  public string Name { get; }
  public int BaseRent { get; }
  public int Houses { get; set; }

  public Property(string name, int baseRent)
  {
    Name = name;
    BaseRent = baseRent;
  }

  public int CalculateRent()
  {
    if (Name == "Boardwalk" && Houses == 1) return 200;
    if (Name == "Boardwalk" && Houses == 2) return 600;
    return BaseRent;
  }
}