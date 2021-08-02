using System;
using System.Collections.Generic;
using System.Linq;
using Mutations.Rules;

namespace Mutations
{
  public class Game
  {
    public const int TIE_RESULT = -1;
    private Regulations regulations;
    private List<Player> participants = new List<Player>();

    private int first;

    private bool gameOver = false;

    private int currentResult = TIE_RESULT;

    private Func<Player, bool> stillPlaying = (p) => !p.Out;

    private void PlayRound()
    {
      foreach (var player in participants.Where(stillPlaying).OrderByDescending((p) => p.Id == first))
      {
        if (player.CanRespond(regulations))
        {
          currentResult = player.Id;
        }
      }

      if (participants.Count(stillPlaying) < 2)
      {
        gameOver = true;
      }
    }

    private void SetupRegulations(string initialWord)
    {
      regulations = new Regulations();
      regulations.Add(new Length());
      regulations.Add(new DifferentLetters());
      regulations.Add(new Change());
      regulations.Add(new AlreadyUsed());

      if (!regulations.Accepts(initialWord))
      {
        throw new ArgumentException(regulations.ValidationError);
      }
    }

    public Game(List<Player> players, string initialWord, int firstPlayer)
    {
      if (players.Count((p) => p.Id == firstPlayer) == 0)
      {
        throw new ArgumentException($"No player with id equal firstPlayer {firstPlayer} in players!");
      }
      participants = players;
      first = firstPlayer;
      SetupRegulations(initialWord);
    }

    public int GetResult()
    {
      while (!gameOver)
      {
        PlayRound();
      }

      return currentResult;
    }
  }
}