using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SwissKnife.Mvc
{
    public class PostalCodeAttribute : DataTypeAttribute
    {
        public PostalCodeAttribute()
            : base(DataType.PostalCode)
        {
            // TODO:デフォルトのエラーメッセージを決める
            ErrorMessage = "郵便番号の値が不正です。";
        }

        private static readonly Regex _regex = new Regex(@"\d{3}-\d{4}", RegexOptions.Compiled);

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
