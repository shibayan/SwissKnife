using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace SwissKnife.Mvc.Html
{
    public static class InputExtensions
    {
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return CheckBoxListFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            return CheckBoxListFor(htmlHelper, expression, selectList, null);
        }

        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            return CheckBoxListFor(htmlHelper, expression, selectList, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            return CheckBoxListHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), selectList, htmlAttributes);
        }

        private static MvcHtmlString CheckBoxListHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string name, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
        {
            var fullName = htmlHelper.ViewData.TemplateInfo.GetFullHtmlFieldName(name);

            var tempValues = TypeHelpers.GetModelValues(metadata);

            if (selectList == null)
            {
                selectList = htmlHelper.ViewData.Eval(name) as IEnumerable<SelectListItem>;

                if (selectList == null)
                {
                    throw new InvalidOperationException();
                }
            }

            var checkBoxes = new StringBuilder();

            foreach (var selectListItem in selectList)
            {
                var id = fullName + "-" + selectListItem.Value;

                var checkBoxBuilder = new TagBuilder("input");

                checkBoxBuilder.MergeAttributes(htmlAttributes);
                checkBoxBuilder.MergeAttribute("type", "checkbox");
                checkBoxBuilder.MergeAttribute("name", fullName, true);
                checkBoxBuilder.MergeAttribute("value", selectListItem.Value);

                checkBoxBuilder.MergeAttribute("id", id);

                if (tempValues.Contains(selectListItem.Value))
                {
                    checkBoxBuilder.MergeAttribute("checked", "checked");
                }

                var labelBuilder = new TagBuilder("label")
                {
                    InnerHtml = checkBoxBuilder.ToString(TagRenderMode.SelfClosing) + htmlHelper.Encode(selectListItem.Text)
                };

                checkBoxes.AppendLine(labelBuilder.ToString(TagRenderMode.Normal));
            }

            return MvcHtmlString.Create(checkBoxes.ToString());
        }

        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return RadioButtonListFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            return RadioButtonListFor(htmlHelper, expression, null, null);
        }

        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            return RadioButtonListFor(htmlHelper, expression, selectList, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            return RadioButtonListHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), selectList, htmlAttributes);
        }

        private static MvcHtmlString RadioButtonListHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string name, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
        {
            var fullName = htmlHelper.ViewData.TemplateInfo.GetFullHtmlFieldName(name);

            var tempValue = TypeHelpers.GetModelValue(metadata);

            if (selectList == null)
            {
                selectList = htmlHelper.ViewData.Eval(name) as IEnumerable<SelectListItem>;

                if (selectList == null)
                {
                    throw new InvalidOperationException();
                }
            }

            var radioButtons = new StringBuilder();

            foreach (var selectListItem in selectList)
            {
                var id = fullName + "-" + selectListItem.Value;

                var radioButtonBuilder = new TagBuilder("input");

                radioButtonBuilder.MergeAttributes(htmlAttributes);
                radioButtonBuilder.MergeAttribute("type", "radio");
                radioButtonBuilder.MergeAttribute("name", fullName, true);
                radioButtonBuilder.MergeAttribute("value", selectListItem.Value);

                radioButtonBuilder.MergeAttribute("id", id);

                if (selectListItem.Selected || selectListItem.Value == tempValue)
                {
                    radioButtonBuilder.MergeAttribute("checked", "checked");
                }

                var labelBuilder = new TagBuilder("label")
                {
                    InnerHtml = radioButtonBuilder.ToString(TagRenderMode.SelfClosing) + htmlHelper.Encode(selectListItem.Text)
                };

                radioButtons.AppendLine(labelBuilder.ToString(TagRenderMode.Normal));
            }

            var hiddenBuilder = new TagBuilder("input");

            hiddenBuilder.MergeAttribute("type", "hidden");
            hiddenBuilder.MergeAttribute("name", fullName);
            hiddenBuilder.MergeAttribute("value", "");

            radioButtons.AppendLine(hiddenBuilder.ToString(TagRenderMode.SelfClosing));

            return MvcHtmlString.Create(radioButtons.ToString());
        }
    }
}
