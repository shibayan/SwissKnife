using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace SwissKnife.Mvc.Html
{
    public static class SelectExtensions
    {
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return DropDownListFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            throw new NotImplementedException();
        }
    }
}
