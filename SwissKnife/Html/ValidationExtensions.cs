using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SwissKnife.Html
{
    public static class ValidationExtensions
    {
        public static bool IsValidationError(this HtmlHelper htmlHelper)
        {
            return !htmlHelper.ViewData.ModelState.IsValid;
        }

        public static IEnumerable<string> GetValidationMessages(this HtmlHelper htmlHelper)
        {
            return htmlHelper.ViewData.ModelState.SelectMany(p => p.Value.Errors).Select(p => p.ErrorMessage);
        }
    }
}
