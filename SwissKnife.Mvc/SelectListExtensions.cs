using System;
using System.Collections.Generic;
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
                           Value = Convert.ToInt32(p).ToString(),
                           Text = p.ToString()
                       }).ToList();
        }
    }
}
