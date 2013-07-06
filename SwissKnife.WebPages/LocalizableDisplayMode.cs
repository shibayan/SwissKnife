using System;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.WebPages;

namespace SwissKnife.WebPages
{
    public class LocalizableDisplayMode : IDisplayMode
    {
        public bool CanHandleContext(HttpContextBase httpContext)
        {
            return true;
        }

        public DisplayInfo GetDisplayInfo(HttpContextBase httpContext, string virtualPath, Func<string, bool> virtualPathExists)
        {
            var transformedFilename = TransformPath(virtualPath, Thread.CurrentThread.CurrentCulture.Name);

            if (transformedFilename != null && virtualPathExists(transformedFilename))
            {
                return new DisplayInfo(transformedFilename, this);
            }

            return null;
        }

        public string DisplayModeId { get { return "Localizable"; } }

        private string TransformPath(string virtualPath, string suffix)
        {
            if (string.IsNullOrEmpty(suffix))
            {
                return virtualPath;
            }

            var extension = Path.GetExtension(virtualPath);

            return Path.ChangeExtension(virtualPath, suffix + extension);
        }
    }

}
