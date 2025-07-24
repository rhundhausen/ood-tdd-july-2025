using System;

namespace Polymorphism
{
  class Program
  {
    static void Main(string[] args)
    {
      var player = new Player("Alice");

      List<IBoardSpace> spaces = new List<IBoardSpace>
      {
        new PropertySpace("Boardwalk", 400),
        new TaxSpace(200),
        new ChanceSpace()
      };

      foreach (var space in spaces)
      {
        space.LandOn(player);
      }

      Console.WriteLine($"{player.Name} has ${player.Money} left.");
    }
  }
}