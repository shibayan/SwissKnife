using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace SwissKnife.Mvc.Html
{
    public static class DisplayExtensions
    {
        public static MvcHtmlString DisplaySelectFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return DisplaySelectFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString DisplaySelectFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            return DisplaySelectHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), selectList);
        }

        private static MvcHtmlString DisplaySelectHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string name, IEnumerable<SelectListItem> selectList)
        {
            var tempValue = TypeHelpers.GetModelValue(metadata);

            if (selectList == null)
            {
                selectList = htmlHelper.ViewData.Eval(name) as IEnumerable<SelectListItem>;

                if (selectList == null)
                {
                    throw new InvalidOperationException();
                }
            }

            var selectListItem = selectList.FirstOrDefault(p => p.Value == tempValue);

            if (selectListItem == null)
            {
                return MvcHtmlString.Empty;
            }

            return MvcHtmlString.Create(selectListItem.Text);
        }
    }
}
