using System;
using System.ComponentModel.DataAnnotations;

namespace SwissKnife.Mvc
{
    public class RequiredValueAttribute : ValidationAttribute
    {
        public RequiredValueAttribute(object requiredValue)
        {
            if (requiredValue == null)
            {
                throw new ArgumentNullException("requiredValue");
            }

            _requiredValue = requiredValue;

            ErrorMessage = "指定された値と一致していません。";
        }

        private readonly object _requiredValue;

        public override bool IsValid(object value)
        {
            if (value.GetType() != _requiredValue.GetType())
            {
                throw new InvalidOperationException();
            }

            return _requiredValue.Equals(value);
        }
    }
}
