using System;
using System.Collections.Generic;

namespace Mutations.Rules
{
  public class AlreadyUsed : Rule
  {
    private List<string> _usedWords = new List<string>();

    public void AddUsedWord(string word)
    {
      _usedWords.Add(word);
    }

    public override void OnAccepted(string word)
    {
      _usedWords.Add(word);
      base.OnAccepted(word);
    }

    protected override void OnRuleInValid(string word)
    {
      ValidationError = $"{word} is already used!";
    }

    protected override bool IsValid(string word)
    {
      return !_usedWords.Contains(word);
    }
  }
}