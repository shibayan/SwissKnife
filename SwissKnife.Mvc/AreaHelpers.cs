using System.Web.Mvc;
using System.Web.Routing;

namespace SwissKnife.Mvc
{
    public static class AreaHelpers
    {
        private const string DataTokenAreaKey = "area";

        public static bool IsInArea(this UrlHelper urlHelper, string areaName)
        {
            var nowAreaName = GetAreaName(urlHelper.RequestContext.RouteData);

            return nowAreaName == areaName;
        }

        private static string GetAreaName(RouteData routeData)
        {
            object area;

            if (routeData.DataTokens.TryGetValue(DataTokenAreaKey, out area))
            {
                return (string)area;
            }

            var routeWithArea = routeData.Route as IRouteWithArea;

            if (routeWithArea != null)
            {
                return routeWithArea.Area;
            }

            return null;
        }
    }
}
