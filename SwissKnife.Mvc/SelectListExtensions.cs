using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace SwissKnife.Mvc
{
    public static class SelectListExtensions
    {
        public static IList<SelectListItem> ToSelectList<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source)
        {
            return source.Select(p => new SelectListItem
            {
                Value = p.Key.ToString(),
                Text = p.Value.ToString()
            }).ToList();
        }

        public static IList<SelectListItem> ToSelectList<TEnum>() where TEnum : struct
        {
            return Enum.GetValues(typeof(TEnum))
                       .Cast<TEnum>()
                       .Select(p => new SelectListItem
                       {
                           Value = p.ToString(),
                           Text = GetDisplayName(p)
                       }).ToList();
        }

        private static string GetDisplayName<TValue>(this TValue value) where TValue : struct
        {
            var field = typeof(TValue).GetField(value.ToString());

            if (field == null)
            {
                return "";
            }

            var attribute = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute), false) as DisplayAttribute;

            if (attribute == null)
            {
                return "";
            }

            return attribute.Name;
        }
    }
}
