using System;

namespace Mutations.Rules
{
  public abstract class Rule
  {
    public string ValidationError { get; protected set; }

    protected abstract void OnRuleInValid(string word);

    protected abstract bool IsValid(string word);

    public bool Evaluate(string word)
    {
      var ok = IsValid(word);
      if (!ok)
      {
        OnRuleInValid(word);
      }
      return ok;
    }

    public virtual void OnAccepted(string word)
    {
      ValidationError = String.Empty;
    }
  }
}