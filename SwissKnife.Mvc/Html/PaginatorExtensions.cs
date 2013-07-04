using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace SwissKnife.Mvc.Html
{
    public static class PaginatorExtensions
    {
        public static MvcHtmlString PaginatorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string templateName)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            var paginatedList = metadata.Model as IPaginatedList;

            if (paginatedList == null)
            {
                throw new InvalidOperationException();
            }

            var info = new PaginateInfo(paginatedList);

            return htmlHelper.Partial(templateName, info);
        }
    }
}
