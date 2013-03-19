using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace SwissKnife.Mvc.Html
{
    public static class InputExtensions
    {
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return CheckBoxListFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            throw new NotImplementedException();
        }

        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return RadioButtonListFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var fullName = htmlHelper.ViewData.TemplateInfo.GetFullHtmlFieldName(name);

            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            var selectList = htmlHelper.ViewData.Eval(name) as IEnumerable<SelectListItem>;

            if (selectList == null)
            {
                throw new InvalidOperationException();
            }

            foreach (var selectListItem in selectList)
            {
                var tagBuilder = new TagBuilder("input");

                tagBuilder.MergeAttribute("type", "radio");
            }

            throw new NotImplementedException();
        }
    }
}
