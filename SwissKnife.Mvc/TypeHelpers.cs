using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
            if (!IsCollection(metadata.ModelType))
            {
                throw new InvalidOperationException();
            }

            if (metadata.Model == null)
            {
                return new string[0];
            }

            return GetCollection(metadata.Model);
        }

        public static bool IsComplexType(Type type)
        {
            return !TypeDescriptor.GetConverter(type).CanConvertFrom(typeof(string));
        }

        public static bool IsCollection(Type type)
        {
            if (type.IsGenericType)
            {
                var genericTypeDefinition = type.GetGenericTypeDefinition();

                if (genericTypeDefinition == typeof(List<>))
                {
                    return true;
                }

                if (genericTypeDefinition == typeof(IEnumerable<>) || genericTypeDefinition == typeof(ICollection<>) || genericTypeDefinition == typeof(IList<>))
                {
                    return true;
                }
            }

            return false;
        }

        public static IList<string> GetCollection(object value)
        {
            return ((IEnumerable)value).Cast<object>().Select(p => p.ToString()).ToList();
        }
    }
}
