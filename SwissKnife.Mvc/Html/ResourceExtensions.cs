using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Web.WebPages;

namespace SwissKnife.Mvc.Html
{
    public static class ResourceExtensions
    {
        static ResourceExtensions()
        {
            _rootNamespace = "";
        }

        private static readonly string _rootNamespace;
        private static readonly Dictionary<string, ResourceManager> _resourceManagers = new Dictionary<string, ResourceManager>();

        public static string Resource(this TemplateFileInfo info, string name, params object[] args)
        {
            var resourcePath = GetResourcePath(info.VirtualPath);

            if (resourcePath == null)
            {
                return null;
            }

            ResourceManager resourceManager;

            if (!_resourceManagers.TryGetValue(resourcePath, out resourceManager))
            {
                resourceManager = new ResourceManager(resourcePath, Assembly.GetCallingAssembly());

                _resourceManagers.Add(resourcePath, resourceManager);
            }

            var format = resourceManager.GetString(name, Thread.CurrentThread.CurrentUICulture);

            if (format == null)
            {
                return null;
            }

            return string.Format(format, args);
        }

        private static string GetResourcePath(string virtualPath)
        {
            if (virtualPath == null)
            {
                return null;
            }

            var tokens = virtualPath.Substring(2, virtualPath.Length - 9).Split('/');

            if (tokens.Length == 0)
            {
                return null;
            }

            var textInfo = CultureInfo.InvariantCulture.TextInfo;

            return string.Format("{0}.Resources.{1}", _rootNamespace, string.Join(".", tokens.Select(textInfo.ToTitleCase)));
        }

    }
}
