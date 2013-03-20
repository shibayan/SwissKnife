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
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var name = ExpressionHelper.GetExpressionText(expression);

            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            var selectList = htmlHelper.ViewData.Eval(name) as IEnumerable<SelectListItem>;

            if (selectList == null)
            {
                throw new InvalidOperationException();
            }

            // TODO:Enum 型の場合は数値にキャストしてから文字列変換
            var tempValue = metadata.Model.ToString();

            var selectListItem = selectList.FirstOrDefault(p => p.Value == tempValue);

            if (selectListItem == null)
            {
                return MvcHtmlString.Empty;
            }

            return MvcHtmlString.Create(selectListItem.Text);
        }
    }
}
