using System.Collections.Generic;
using System.Text;
using Mutations.Rules;

namespace Mutations
{
  public class Regulations
  {
    private List<Rule> rules = new List<Rule>();

    public string ValidationError
    {
      get
      {
        StringBuilder sb = new StringBuilder();
        rules.ForEach((r) => sb.AppendLine(r.ValidationError));
        return sb.ToString();
      }
    }

    public void Add(Rule rule)
    {
      rules.Add(rule);
    }

    public bool Accepts(string word)
    {
      var ok = rules.TrueForAll((r) => r.Evaluate(word));
      if (ok)
      {
        rules.ForEach((r) => r.OnAccepted(word));
      }
      return ok;
    }
  }
}