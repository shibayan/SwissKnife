using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SwissKnife.Mvc
{
    public class PostalCodeAttribute : DataTypeAttribute
    {
        public PostalCodeAttribute()
            : base(DataType.PostalCode)
        {
            ErrorMessage = "郵便番号の値が不正です。";
        }

        private static readonly Regex _regex = new Regex(@"[0-9]{3}-[0-9]{4}", RegexOptions.ECMAScript | RegexOptions.Compiled);

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
