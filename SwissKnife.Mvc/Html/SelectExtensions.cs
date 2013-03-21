using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
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
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            return DropDownListHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        private static MvcHtmlString DropDownListHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string name, IDictionary<string, object> htmlAttributes)
        {
            var fullName = htmlHelper.ViewData.TemplateInfo.GetFullHtmlFieldName(name);

            var tempValue = TypeHelpers.ToString(metadata);

            var selectList = htmlHelper.ViewData.Eval(name) as IEnumerable<SelectListItem>;

            if (selectList == null)
            {
                throw new InvalidOperationException();
            }

            var optionBuilder = new StringBuilder();

            foreach (var selectListItem in selectList)
            {
                optionBuilder.AppendLine(ListItemToOption(selectListItem));
            }

            var tagBuilder = new TagBuilder("select")
            {
                InnerHtml = optionBuilder.ToString()
            };

            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("name", fullName, true);

            throw new NotImplementedException();
        }

        private static string ListItemToOption(SelectListItem item)
        {
            var tagBuilder = new TagBuilder("option")
            {
                InnerHtml = item.Text
            };

            tagBuilder.MergeAttribute("value", item.Value);

            return tagBuilder.ToString(TagRenderMode.SelfClosing);
        }
    }
}
