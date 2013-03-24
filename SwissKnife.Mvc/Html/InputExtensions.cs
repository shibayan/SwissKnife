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

            var tempValue = TypeHelpers.ToString(metadata);

            if (selectList == null)
            {
                selectList = htmlHelper.ViewData.Eval(name) as IEnumerable<SelectListItem>;

                if (selectList == null)
                {
                    throw new InvalidOperationException();
                }
            }

            var checkBoxBuilder = new StringBuilder();

            foreach (var selectListItem in selectList)
            {
                var tagBuilder = new TagBuilder("input");

                tagBuilder.MergeAttributes(htmlAttributes);
                tagBuilder.MergeAttribute("type", "checkbox");
                tagBuilder.MergeAttribute("name", fullName, true);
                tagBuilder.MergeAttribute("value", selectListItem.Value);

                checkBoxBuilder.AppendLine(tagBuilder.ToString(TagRenderMode.SelfClosing));
            }

            return MvcHtmlString.Create(checkBoxBuilder.ToString());
        }

        public static MvcHtmlString RadioButtonFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value)
        {
            return RadioButtonFor(htmlHelper, expression, value, null);
        }

        public static MvcHtmlString RadioButtonFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value, object htmlAttributes)
        {
            return RadioButtonFor(htmlHelper, expression, value, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString RadioButtonFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value, IDictionary<string, object> htmlAttributes)
        {
            throw new NotImplementedException();
        }

        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return RadioButtonListFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return RadioButtonListFor(htmlHelper, expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            return RadioButtonListHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), htmlAttributes);
        }

        private static MvcHtmlString RadioButtonListHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string name, IDictionary<string, object> htmlAttributes)
        {
            var fullName = htmlHelper.ViewData.TemplateInfo.GetFullHtmlFieldName(name);

            var tempValue = TypeHelpers.ToString(metadata);

            var selectList = htmlHelper.ViewData.Eval(name) as IEnumerable<SelectListItem>;

            if (selectList == null)
            {
                throw new InvalidOperationException();
            }

            foreach (var selectListItem in selectList)
            {
                var tagBuilder = new TagBuilder("input");

                tagBuilder.MergeAttributes(htmlAttributes);
                tagBuilder.MergeAttribute("type", "radio");
                tagBuilder.MergeAttribute("name", fullName, true);
            }

            throw new NotImplementedException();
        }
    }
}
