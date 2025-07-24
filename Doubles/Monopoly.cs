namespace Doubles
{

  // Simple logger interface
  public interface ILogger
  {
    void Log(string message);
  }

  // Default null logger (does nothing)
  public class NullLogger : ILogger
  {
    public void Log(string message) { }
  }

  public class MonopolyProperty
  {
    public string Name { get; set; }
    public string ColorGroup { get; set; }
    public int[] Rents { get; set; } // Index: 0 = no house, 1-4 = houses, 5 = hotel

    public MonopolyProperty(string name, string colorGroup, int[] rents)
    {
      Name = name;
      ColorGroup = colorGroup;
      Rents = rents;
    }

    public int GetRent(int buildings)
    {
      if (buildings < 0 || buildings > 5)
        throw new ArgumentException("Buildings must be between 0 (no house) and 5 (hotel).");

      return Rents[buildings];
    }
  }

  public class MonopolyGame
  {
    private List<MonopolyProperty> properties;
    private ILogger logger = new NullLogger(); // default logger

    public MonopolyGame()
    {
      InitializeProperties();
    }

    public void SetLogger(ILogger customLogger)
    {
      if (customLogger != null)
        logger = customLogger;
    }

    private void InitializeProperties()
    {
      properties = new List<MonopolyProperty>
    {
      new MonopolyProperty("Mediterranean Avenue", "Brown", new int[] {2, 10, 30, 90, 160, 250}),
      new MonopolyProperty("Baltic Avenue", "Brown", new int[] {4, 20, 60, 180, 320, 450}),
      new MonopolyProperty("Oriental Avenue", "Light Blue", new int[] {6, 30, 90, 270, 400, 550}),
      new MonopolyProperty("Vermont Avenue", "Light Blue", new int[] {6, 30, 90, 270, 400, 550}),
      new MonopolyProperty("Connecticut Avenue", "Light Blue", new int[] {8, 40, 100, 300, 450, 600}),
      new MonopolyProperty("St. Charles Place", "Pink", new int[] {10, 50, 150, 450, 625, 750}),
      new MonopolyProperty("States Avenue", "Pink", new int[] {10, 50, 150, 450, 625, 750}),
      new MonopolyProperty("Virginia Avenue", "Pink", new int[] {12, 60, 180, 500, 700, 900}),
      new MonopolyProperty("St. James Place", "Orange", new int[] {14, 70, 200, 550, 750, 950}),
      new MonopolyProperty("Tennessee Avenue", "Orange", new int[] {14, 70, 200, 550, 750, 950}),
      new MonopolyProperty("New York Avenue", "Orange", new int[] {16, 80, 220, 600, 800, 1000}),
      new MonopolyProperty("Kentucky Avenue", "Red", new int[] {18, 90, 250, 700, 875, 1050}),
      new MonopolyProperty("Indiana Avenue", "Red", new int[] {18, 90, 250, 700, 875, 1050}),
      new MonopolyProperty("Illinois Avenue", "Red", new int[] {20, 100, 300, 750, 925, 1100}),
      new MonopolyProperty("Atlantic Avenue", "Yellow", new int[] {22, 110, 330, 800, 975, 1150}),
      new MonopolyProperty("Ventnor Avenue", "Yellow", new int[] {22, 110, 330, 800, 975, 1150}),
      new MonopolyProperty("Marvin Gardens", "Yellow", new int[] {24, 120, 360, 850, 1025, 1200}),
      new MonopolyProperty("Pacific Avenue", "Green", new int[] {26, 130, 390, 900, 1100, 1275}),
      new MonopolyProperty("North Carolina Avenue", "Green", new int[] {26, 130, 390, 900, 1100, 1275}),
      new MonopolyProperty("Pennsylvania Avenue", "Green", new int[] {28, 150, 450, 1000, 1200, 1400}),
      new MonopolyProperty("Park Place", "Dark Blue", new int[] {35, 175, 500, 1100, 1300, 1500}),
      new MonopolyProperty("Boardwalk", "Dark Blue", new int[] {50, 200, 600, 1400, 1700, 2000}),
    };
    }

    public void DisplayAllRents()
    {
      foreach (var prop in properties)
      {
        Console.WriteLine($"{prop.Name} ({prop.ColorGroup}):");
        Console.WriteLine($"  No Houses: ${prop.GetRent(0)}");
        for (int i = 1; i <= 4; i++)
          Console.WriteLine($"  {i} House(s): ${prop.GetRent(i)}");
        Console.WriteLine($"  Hotel: ${prop.GetRent(5)}\n");
      }
    }

    public int CalculateRent(string propertyName, int buildings)
    {
      logger.Log($"Calculating rent for '{propertyName}' with {buildings} building(s).");

      var prop = properties.Find(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));
      if (prop == null)
      {
        logger.Log($"Property '{propertyName}' not found.");
        throw new ArgumentException("Property not found.");
      }

      int rent = prop.GetRent(buildings);
      logger.Log($"Calculated rent: ${rent}");
      return rent;
    }
  }
}