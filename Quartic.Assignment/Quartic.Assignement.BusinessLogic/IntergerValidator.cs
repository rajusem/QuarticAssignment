using Quartic.Assignement.BusinessLogic.Interface;
using Quartic.Assignment.Model;
using System.Collections.Generic;

namespace Quartic.Assignement.BusinessLogic
{
    public class IntergerValidator : IValidator
    {
        public bool Validate(SignalModel signal, List<Rule> matchingRules)
        {
            bool isValid = true;

            decimal signalValue = decimal.Parse(signal.Value);
            foreach (var rule in matchingRules)
            {

                decimal ruleValue = decimal.Parse(rule.Value);

                switch (rule.Operation)
                {
                    case Operation.Equal:
                        isValid = signalValue == ruleValue;
                        break;
                    case Operation.NotEqual:
                        isValid = signalValue != ruleValue;
                        break;
                    case Operation.GreaterThan:
                        isValid = signalValue > ruleValue;
                        break;
                    case Operation.LessThan:
                        isValid = signalValue < ruleValue;
                        break;
                }

                if (!isValid)
                    break;
            }

            return isValid;
        }
    }

}
