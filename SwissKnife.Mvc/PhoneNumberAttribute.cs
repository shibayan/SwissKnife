using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SwissKnife.Mvc
{
    public class PhoneNumberAttribute : DataTypeAttribute
    {
        public PhoneNumberAttribute()
            : base(DataType.PhoneNumber)
        {
            ErrorMessage = "電話番号の値が不正です。";
        }

        private static readonly Regex _regex = new Regex(@"[0-9]{2,4}-[0-9]{1,5}-[0-9]{4}", RegexOptions.ECMAScript | RegexOptions.Compiled);

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            
            var valueAsString = value as string;

            return valueAsString != null && _regex.IsMatch(valueAsString);
        }
    }
}
