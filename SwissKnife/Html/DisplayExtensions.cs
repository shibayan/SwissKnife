using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace SwissKnife.Html
{
    public static class DisplayExtensions
    {
        public static MvcHtmlString DisplaySelectFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
