using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace SwissKnife.Mvc.Html
{
    public static class PaginatorExtensions
    {
        public static MvcHtmlString Paginator(this HtmlHelper htmlHelper, string templateName)
        {
            throw new NotImplementedException();

            var info = new PaginateInfo(1, 10, 0);

            return htmlHelper.Partial(templateName, info);
        }
    }
}
