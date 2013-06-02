using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace SwissKnife.WebPages
{
    public class CompositeDisplayMode : IDisplayMode
    {
        public CompositeDisplayMode(IEnumerable<IDisplayMode> modes)
        {
            _modes = modes;
        }

        private readonly IEnumerable<IDisplayMode> _modes;

        public bool CanHandleContext(HttpContextBase httpContext)
        {
            return _modes.Any(p => p.CanHandleContext(httpContext));
        }

        public DisplayInfo GetDisplayInfo(HttpContextBase httpContext, string virtualPath, Func<string, bool> virtualPathExists)
        {
            var transformedFilename = virtualPath;

            foreach (var displayMode in _modes.Where(p => p.CanHandleContext(httpContext)))
            {
                var displayInfo = displayMode.GetDisplayInfo(httpContext, transformedFilename, virtualPathExists);

                if (displayInfo != null)
                {
                    transformedFilename = displayInfo.FilePath;
                }
            }

            if (transformedFilename != virtualPath)
            {
                return new DisplayInfo(transformedFilename, this);
            }

            return null;
        }

        public string DisplayModeId
        {
            get { return "Composite"; }
        }
    }
}
