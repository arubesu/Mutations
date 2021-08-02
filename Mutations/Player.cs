using System.Collections.Generic;

namespace Mutations
{
  public class Player
  {
    private List<string> _memory;
    public int Id { get; private set; }

    public bool Out { get; private set; }

    public Player(int id, string[] memory)
    {
      _memory = new List<string>(memory);
      Id = id;
    }

    public bool CanRespond(Regulations regulations)
    {
      foreach (var word in _memory)
      {
        if (regulations.Accepts(word))
        {
          return true;
        }
      }
      Out = true;
      return false;
    }

  }
}