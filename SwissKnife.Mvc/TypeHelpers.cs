using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SwissKnife.Mvc
{
    internal static class TypeHelpers
    {
        public static string GetModelValue(ModelMetadata metadata)
        {
            if (metadata.Model == null)
            {
                return "";
            }

            return metadata.Model.ToString();
        }

        public static IList<string> GetModelValues(ModelMetadata metadata)
        {
            if (!IsCollection(metadata.Model))
            {
                throw new InvalidOperationException();
            }

            if (metadata.Model == null)
            {
                return new string[0];
            }

            return GetCollection(metadata.Model);
        }

        public static bool IsCollection(object value)
        {
            return value is IEnumerable;
        }

        public static IList<string> GetCollection(object value)
        {
            return ((IEnumerable)value).Cast<object>().Select(p => p.ToString()).ToList();
        }
    }
}
