using System.Web;
using System.Web.Mvc;

namespace SwissKnife.Mvc.Html
{
    public static class JavaScriptExtensions
    {
        public static MvcHtmlString JavaScriptStringEncode(this HtmlHelper htmlHelper, string value)
        {
            return MvcHtmlString.Create(HttpUtility.JavaScriptStringEncode(value));
        }
    }
}
