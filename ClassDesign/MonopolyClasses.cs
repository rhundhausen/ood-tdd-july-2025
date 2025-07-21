namespace ClassDesign
{
  public class Board
  {
    public List<Space>? Spaces { get; set; }
    public Jail? JailSpace { get; set; }
    public Go? GoSpace { get; set; }

    public Space? GetSpaceAtPosition(int position)
    {
      return null;
    }

    public int GetPositionOf(Space space)
    {
      return -1;
    }
  }

  public abstract class Space
  {
    public string? Name { get; set; }
    public int Position { get; set; }

    public abstract void LandOn();
  }

  public class Chance : Space
  {
    public Deck? Deck { get; set; }

    public override void LandOn()
    {
    }
  }

  public class CommunityChest : Space
  {
    public Deck? Deck { get; set; }

    public override void LandOn()
    {
    }
  }

  public class TaxSpace : Space
  {
    public int TaxAmount { get; set; }

    public override void LandOn()
    {
    }
  }

  public class Jail : Space
  {
    public override void LandOn()
    {
    }

    public void SendToJail()
    {
    }
  }

  public class Go : Space
  {
    public int RewardAmount { get; set; }

    public override void LandOn()
    {
    }
  }

  public class GoToJail : Space
  {
    public Jail? JailReference { get; set; }

    public override void LandOn()
    {
    }
  }

  public class FreeParking : Space
  {
    public override void LandOn()
    {
    }
  }

  public class Card
  {
    public string? Description { get; set; }

    public void Apply()
    {
    }
  }

  public class Deck
  {
    public Queue<Card>? Cards { get; set; }

    public void Shuffle()
    {
    }

    public Card? Draw()
    {
      return null;
    }
  }

  public class Bank
  {
    public int Funds { get; set; }

    public void Credit(int amount)
    {
    }

    public void Debit(int amount)
    {
    }
  }
}
