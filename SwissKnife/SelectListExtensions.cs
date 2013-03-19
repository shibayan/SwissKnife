using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SwissKnife
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
    }
}
