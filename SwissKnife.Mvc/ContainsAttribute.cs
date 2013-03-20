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

            ErrorMessage = "";
        }

        private readonly Type _type;
        private readonly string _propertyName;

        public override bool IsValid(object value)
        {
            var propertyInfo = _type.GetProperty(_propertyName);

            if (propertyInfo == null)
            {
                throw new InvalidOperationException();
            }

            var selectList = propertyInfo.GetValue(null) as IEnumerable<SelectListItem>;

            if (selectList == null)
            {
                throw new InvalidOperationException();
            }

            var tempValue = value.ToString();

            return selectList.Any(p => p.Value == tempValue);
        }
    }
}
