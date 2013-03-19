using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace SwissKnife.Mvc
{
    public class ContainsAttribute : ValidationAttribute
    {
        public ContainsAttribute(Type type, string propertyName)
        {
            _type = type;
            _propertyName = propertyName;
        }

        private readonly Type _type;
        private readonly string _propertyName;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var selectList = (IEnumerable<SelectListItem>)_type.GetProperty(_propertyName).GetValue(null);

            if (selectList == null)
            {
                throw new InvalidOperationException();
            }

            var tempValue = value.ToString();

            if (selectList.All(p => p.Value != tempValue))
            {
                return new ValidationResult(ErrorMessage);
            }

            return null;
        }
    }
}
