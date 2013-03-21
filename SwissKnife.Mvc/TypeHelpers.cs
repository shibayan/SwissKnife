using System;
using System.Web.Mvc;

namespace SwissKnife.Mvc
{
    internal static class TypeHelpers
    {
        public static string ToString(ModelMetadata metadata)
        {
            if (metadata.Model == null)
            {
                return "";
            }

            if (typeof(Enum).IsAssignableFrom(metadata.ModelType))
            {
                var underlyingType = Enum.GetUnderlyingType(metadata.ModelType);

                return Convert.ChangeType(metadata.Model, underlyingType).ToString();
            }

            return metadata.Model.ToString();
        }
    }
}
