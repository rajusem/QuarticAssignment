using Quartic.Assignment.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quartic.Assignement.BusinessLogic.Interface
{
    public interface IValidator
    {
        bool Validate(SignalModel signal, List<Rule> matchingRules);
    }
}
