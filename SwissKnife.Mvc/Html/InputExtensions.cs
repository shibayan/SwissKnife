using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace SwissKnife.Mvc.Html
{
    public static class InputExtensions
    {
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            throw new NotImplementedException();
        }

        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
