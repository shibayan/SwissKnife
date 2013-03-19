using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace SwissKnife.Mvc.Html
{
    public static class SelectExtensions
    {
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
