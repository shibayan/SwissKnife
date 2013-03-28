using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace SwissKnife.Mvc.Html
{
    public static class SelectExtensions
    {
        public static MvcHtmlString DropDownListExFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return DropDownListExFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString DropDownListExFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            return DropDownListExFor(htmlHelper, expression, selectList, null);
        }

        public static MvcHtmlString DropDownListExFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            return DropDownListExFor(htmlHelper, expression, selectList, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString DropDownListExFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            return DropDownListHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), selectList, htmlAttributes);
        }

        private static MvcHtmlString DropDownListHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string name, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
        {
            var fullName = htmlHelper.ViewData.TemplateInfo.GetFullHtmlFieldName(name);

            var tempValue = TypeHelpers.ToString(metadata);

            if (selectList == null)
            {
                selectList = htmlHelper.ViewData.Eval(name) as IEnumerable<SelectListItem>;

                if (selectList == null)
                {
                    throw new InvalidOperationException();
                }
            }

            var optionBuilder = new StringBuilder();

            foreach (var selectListItem in selectList)
            {
                optionBuilder.AppendLine(ListItemToOption(selectListItem, tempValue));
            }

            var tagBuilder = new TagBuilder("select")
            {
                InnerHtml = optionBuilder.ToString()
            };

            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("name", fullName, true);

            tagBuilder.GenerateId(fullName);

            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }

        private static string ListItemToOption(SelectListItem item, string selectedValue)
        {
            var tagBuilder = new TagBuilder("option")
            {
                InnerHtml = item.Text
            };

            tagBuilder.MergeAttribute("value", item.Value);

            if (item.Selected || item.Value == selectedValue)
            {
                tagBuilder.MergeAttribute("selected", "selected");
            }

            return tagBuilder.ToString(TagRenderMode.Normal);
        }
    }
}
