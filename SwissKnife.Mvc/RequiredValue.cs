using System.ComponentModel.DataAnnotations;

namespace SwissKnife.Mvc
{
    public class RequiredValueAttribute : ValidationAttribute
    {
        public RequiredValueAttribute(object requiredValue)
        {
            _requiredValue = requiredValue;
        }

        private readonly object _requiredValue;

        public override bool IsValid(object value)
        {
            if (value.GetType() != _requiredValue.GetType())
            {
                return false;
            }

            if (!value.Equals(_requiredValue))
            {
                return false;
            }

            return true;
        }
    }
}
