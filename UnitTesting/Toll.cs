namespace UnitTesting
{
  public class TollCalculator
  {
    public decimal CalculateToll(string membershipLevel, string rateLevel, string tollPassed)
    {
      
      if (rateLevel == "") { throw new ArgumentException("Rate level cannot be empty."); }

      if (rateLevel == "Peak")
      {
        if (membershipLevel == "Silver" && tollPassed == "SPRNG-CRK")
          return 6m;
        if (membershipLevel == "Bronze" && tollPassed == "SPRNG-CRK")
          return 6m;
        if (membershipLevel == "None" && tollPassed == "SPRNG-CRK")
          return 10m;
      }

      if (rateLevel == "Normal")
      {
        if (membershipLevel == "Gold" && tollPassed == "SPRNG-CRK")
          return 2m;
        if (membershipLevel == "Silver" && tollPassed == "SPRNG-CRK")
          return 4m;
        if (membershipLevel == "None" && (tollPassed == "SPRNG-CRK" || tollPassed == "LGCY"))
          return 6m;
      }

      // Default or unhandled case
      return -1m;
    }
  }
}