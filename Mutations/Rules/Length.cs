namespace Mutations.Rules
{
  public class Length : Rule
  {
    private const int ALLOWED_LENGTH = 4;

    public override void OnAccepted(string word)
    {
      base.OnAccepted(word);
    }

    protected override void OnRuleInValid(string word)
    {
      ValidationError = $"{word} must have {ALLOWED_LENGTH} letters!";
    }

    protected override bool IsValid(string word)
    {
      return word.Length == ALLOWED_LENGTH;
    }
  }
}