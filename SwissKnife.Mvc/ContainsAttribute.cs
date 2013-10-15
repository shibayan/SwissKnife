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
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (propertyName == null)
            {
                throw new ArgumentNullException("propertyName");
            }

            _type = type;
            _propertyName = propertyName;

            ErrorMessage = "選択された値が不正です。";
        }

        private readonly Type _type;
        private readonly string _propertyName;

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

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

            var valueType = value.GetType();

            if (TypeHelpers.IsCollection(valueType))
            {
                var tempValues = TypeHelpers.GetCollection(value);

                return tempValues.All(p => selectList.Any(q => q.Value == p));
            }
            
            var tempValue = value.ToString();

            return selectList.Any(p => p.Value == tempValue);
        }
    }
}
