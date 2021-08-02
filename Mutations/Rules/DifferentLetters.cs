using System.Collections.Generic;

namespace Mutations.Rules
{
  public class DifferentLetters : Rule
  {
    private const int ALLOWED_CHANGES = 1;

    public override void OnAccepted(string word)
    {
      base.OnAccepted(word);
    }

    protected override void OnRuleInValid(string word)
    {
      ValidationError = $"{word} is invalid, all letters in word must be different!";
    }

    protected override bool IsValid(string word)
    {
      return word.Length == new HashSet<char>(word).Count;
    }
  }
}