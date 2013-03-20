using System.Web.Mvc;

namespace SwissKnife.Mvc
{
    public class OutputCacheExAttribute : OutputCacheAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var skipCaching = filterContext.ActionDescriptor.IsDefined(typeof(NoOutputCacheAttribute), true)
                              || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(NoOutputCacheAttribute), true);

            if (skipCaching)
            {
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
