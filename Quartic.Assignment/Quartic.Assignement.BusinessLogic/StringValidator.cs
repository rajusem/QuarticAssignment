using Quartic.Assignement.BusinessLogic.Interface;
using Quartic.Assignment.Model;
using System.Collections.Generic;

namespace Quartic.Assignement.BusinessLogic
{
    public class StringValidator : IValidator
    {
        public bool Validate(SignalModel signal, List<Rule> matchingRules)
        {
            bool isValid = true;

            foreach (var rule in matchingRules)
            {
                switch (rule.Operation)
                {
                    case Operation.Equal:
                        isValid = rule.Value.Equals(signal.Value);
                        break;

                    case Operation.NotEqual:
                        isValid = !rule.Value.Equals(signal.Value);
                        break;
                }

                if (!isValid)
                    break;
            }

            return isValid;
        }
    }

}
