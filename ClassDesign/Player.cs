using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDesign
{
  public class Player
  {
    private string _name = string.Empty;
    private decimal _cash;
    private short _experience;

    public string Name
    {
      get => _name;
      set
      {
        _name = value ?? string.Empty;
      }
    }

    public decimal Cash
    {
      get => _cash;
      set
      {
        _cash = value;
      }
    }

    public short Experience
    {
      get => _experience;
      set
      {
        _experience = value;
      }
    }
  }
}