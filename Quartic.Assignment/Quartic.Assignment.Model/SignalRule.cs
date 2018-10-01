using System.Collections.Generic;

namespace Quartic.Assignment.Model
{
    public class SignalRule
    {
        public string SignalName { get; set; }
        public List<Rule> AvailableRules { get; set; }
    }
}
