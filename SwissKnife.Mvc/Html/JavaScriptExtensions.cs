using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SwissKnife.Mvc.Html
{
    public static class JavaScriptExtensions
    {
        public static MvcHtmlString JavaScriptStringEncode(this HtmlHelper htmlHelper, string value)
        {
            return JavaScriptStringEncode(htmlHelper, value, false);
        }

        public static MvcHtmlString JavaScriptStringEncode(this HtmlHelper htmlHelper, string value, bool addDoubleQuote)
        {
            return MvcHtmlString.Create(HttpUtility.JavaScriptStringEncode(value, addDoubleQuote));
        }

        public static MvcHtmlString Json(this HtmlHelper htmlHelper, object value)
        {
            var serializer = new JavaScriptSerializer();

            return MvcHtmlString.Create(serializer.Serialize(value));
        }
    }
}
