using System.Linq;
using System.Web.Mvc;

namespace SwissKnife.Mvc
{
    public static class ModelStateExtensions
    {
        public static void RemovePrefix(this ModelStateDictionary modelState, string prefix)
        {
            var keys = modelState.Keys.Where(p => p.StartsWith(prefix)).ToArray();

            foreach (var key in keys)
            {
                modelState.Remove(key);
            }
        }
    }
}
