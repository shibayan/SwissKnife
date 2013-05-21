using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.WebPages;

namespace SwissKnife.Mvc
{
    public class DisplayModeAttribute : ActionMethodSelectorAttribute
    {
        public DisplayModeAttribute(string displayModeId)
        {
            _displayModeId = displayModeId;
        }

        private readonly string _displayModeId;

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            var displayMode = DisplayModeProvider.Instance.GetAvailableDisplayModesForContext(controllerContext.HttpContext, controllerContext.DisplayMode).FirstOrDefault();

            if (displayMode == null)
            {
                return true;
            }

            return displayMode.DisplayModeId == _displayModeId;
        }
    }
}
