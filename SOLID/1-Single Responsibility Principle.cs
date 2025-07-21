namespace _S_OLID
{
  // ❌ Violates Single Responsibility Principle
  public class Property_ManyResponsibilities
  {
    public string? Name { get; set; }
    public double Price { get; set; }
    public Player? Player { get; set; }

    public double CalculateRent()
    {
      return Price * 0.1;
    }

    public void Purchase(Player player)
    {
      if (Player == null && player.Cash >= Price)
      {
        player.Cash -= Price;
        Player = player;
      }
    }

    public string DisplayInfo()
    {
      return $"{Name} - ${Price} - Owned by {(Player?.Name ?? "No one")}";
    }
  }


  // ✅ Follows Single Responsibility Principle

  public class Property_SingleResponsibility
  {
    public string? Name { get; set; }
    public double Price { get; set; }
    public Player? Owner { get; set; }
  }

  public class RentCalculator_SingleResponsibility
  {
    public double Calculate(Property_SingleResponsibility property)
    {
      return property.Price * 0.1;
    }
  }

  public class PropertyService_SingleResponsibility
  {
    public void Purchase(Property_SingleResponsibility property, Player player)
    {
      if (property.Owner == null && player.Cash >= property.Price)
      {
        player.Cash -= property.Price;
        property.Owner = player;
      }
    }
  }

  public class PropertyFormatter_SingleResponsibility
  {
    public string Format(Property_SingleResponsibility property)
    {
      return $"{property.Name} - ${property.Price} - Owned by {(property.Owner?.Name ?? "No one")}";
    }
  }

  public class Player
  {
    public string? Name { get; set; }
    public double Cash { get; set; }
  }
}
