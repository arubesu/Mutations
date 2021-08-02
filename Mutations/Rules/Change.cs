using System;

namespace Mutations.Rules
{
  public class Change : Rule
  {
    private const int ALLOWED_CHANGES = 1;
    private string _currentWord = String.Empty;

    private bool onechange(string word)
    {
      int nrOfChanges = 0;
      for (var i = 0; i < _currentWord.Length; i++)
      {
        if (i >= word.Length || _currentWord[i] != word[i])
        {
          nrOfChanges++;
        }
      }
      return nrOfChanges == ALLOWED_CHANGES;
    }

    public override void OnAccepted(string word)
    {
      _currentWord = word;
      base.OnAccepted(word);
    }

    protected override void OnRuleInValid(string word)
    {
      ValidationError = $"{word} is invalid, exactly {ALLOWED_CHANGES} letter must be changed!";
    }

    protected override bool IsValid(string word)
    {
      bool firstTry = _currentWord == String.Empty;
      bool changeOk = onechange(word);

      return firstTry || changeOk;
    }
  }
}