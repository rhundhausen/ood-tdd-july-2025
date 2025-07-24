namespace Inheritance
{
  public class BoardElement
  {
    public string? Name { get; set; }
  }

  public class PropertyBase : BoardElement
  {
    public int Position { get; set; }
  }
}