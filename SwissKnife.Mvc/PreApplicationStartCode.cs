using System.ComponentModel;
using System.Web.Mvc;
using System.Web.WebPages.Razor;

namespace SwissKnife.Mvc
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class PreApplicationStartCode
    {
        private static bool _startWasCalled;

        public static void Start()
        {
            if (_startWasCalled)
            {
                return;
            }

            _startWasCalled = true;

            ModelBinders.Binders.DefaultBinder = new ConditionalModelBinder();

            WebPageRazorHost.AddGlobalImport("SwissKnife.Mvc.Html");
        }
    }
}
