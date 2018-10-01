using Quartic.Assignement.BusinessLogic;
using Quartic.Assignement.BusinessLogic.Interface;
using ValueType = Quartic.Assignment.Model.ValueType;

namespace Quartic.Assignment.BusinessLogic
{
    public class ValidatorFactory
    {
        public static IValidator GetValidator(ValueType valueType)
        {
            IValidator validator = null;

            switch (valueType)
            {
                case ValueType.Datetime:
                    validator = new DateTimeValidator();
                    break;
                case ValueType.String:
                    validator = new StringValidator();
                    break;
                case ValueType.Integer:
                    validator = new IntergerValidator();
                    break;
            }
            return validator;
        }
    }

}
