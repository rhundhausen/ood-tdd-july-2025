namespace Polymorphism
{
  // Interface representing a space on the board that a player can land on
  public interface IBoardSpace
  {
    void LandOn(Player player);
  }

  // Represents a player in the game, with a name and money balance
  public class Player
  {
    public string Name { get; set; }
    public int Money { get; set; } = 1500;

    public Player(string name)
    {
      Name = name;
    }
  }

  // A board space that represents a property a player can buy (costs money)
  public class PropertySpace : IBoardSpace
  {
    public string Name { get; set; }
    public int Price { get; set; }

    public PropertySpace(string name, int price)
    {
      Name = name;
      Price = price;
    }

    public void LandOn(Player player)
    {
      player.Money -= Price;  // Deduct property price from player’s money
    }
  }

  // A board space that charges the player a fixed tax amount
  public class TaxSpace : IBoardSpace
  {
    public int TaxAmount { get; set; }

    public TaxSpace(int amount)
    {
      TaxAmount = amount;
    }

    public void LandOn(Player player)
    {
      player.Money -= TaxAmount;  // Deduct tax from player’s money
    }
  }

  // A board space that gives the player a bonus (like drawing a lucky card)
  public class ChanceSpace : IBoardSpace
  {
    public void LandOn(Player player)
    {
      player.Money += 100;  // Add bonus to player’s money
    }
  }
}