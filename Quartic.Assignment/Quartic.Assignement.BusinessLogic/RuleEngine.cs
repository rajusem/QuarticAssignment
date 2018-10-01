using Quartic.Assignement.BusinessLogic.Interface;
using Quartic.Assignment.BusinessLogic;
using Quartic.Assignment.Model;
using System.Collections.Generic;
using System.Linq;

namespace Quartic.Assignement.BusinessLogic
{
    public class RuleEngine
    {
        public List<SignalModel> ValidateSignalAgainstRule(List<SignalModel> signals, List<SignalRule> signalRules)
        {
            List<SignalModel> badData = new List<SignalModel>();

            foreach (var signal in signals)
            {
                SignalRule signalRule = signalRules.FirstOrDefault(q => q.SignalName == signal.Signal);

                if (signalRule != null && signalRule.AvailableRules != null)
                {
                    List<Rule> matchingRules = signalRule.AvailableRules.Where(q => q.ValueType == signal.Value_type).ToList();
                    if (matchingRules != null)
                    {
                        IValidator validator = ValidatorFactory.GetValidator(signal.Value_type);
                        bool isValid = validator.Validate(signal, matchingRules);
                        if (!isValid)
                            badData.Add(signal);
                    }
                }
            }
            return badData;
        }
    }
}
