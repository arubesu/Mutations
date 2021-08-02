using System.Collections.Generic;

namespace Mutations
{
  class Program
  {
    static void Main(string[] args)
    {
      var players = new List<Player>();
      string[] alice = new string[] { "plat", "rend", "bear", "soar", "mare", "pare", "flap", "neat", "clan", "pore" };
      string[] bob = new string[] { "boar", "clap", "farm", "lend", "near", "peat", "pure", "more", "plan", "soap" };
      string word = "maze";
      int turn = (int)MutationsPlayers.Alice;

      players.Add(new Player((int)MutationsPlayers.Alice, alice));
      players.Add(new Player((int)MutationsPlayers.Bob, bob));

      var game = new Game(players, word, turn);

      System.Console.WriteLine(game.GetResult());
    }
  }
}
