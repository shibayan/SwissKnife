using System.Web.Mvc;

namespace SwissKnife.Mvc
{
    public class OutputCacheExAttribute : OutputCacheAttribute
    {
        private bool _skipCaching;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _skipCaching = filterContext.ActionDescriptor.IsDefined(typeof(NoOutputCacheAttribute), true)
                           || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(NoOutputCacheAttribute), true);

            if (_skipCaching)
            {
                return;
            }

            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (_skipCaching)
            {
                return;
            }

            base.OnResultExecuting(filterContext);
        }
    }
}
