using System;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;

namespace SwissKnife.Mvc
{
    public class ConditionalModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = base.BindModel(controllerContext, bindingContext);

            var properties = GetModelProperties(controllerContext, bindingContext);

            foreach (PropertyDescriptor property in properties)
            {
                var conditional = property.Attributes.OfType<ConditionalAttribute>().FirstOrDefault();

                if (conditional == null)
                {
                    continue;
                }

                var value = GetPropertyValue(model, bindingContext.ModelType, conditional.PropertyName);

                if (value == null)
                {
                    continue;
                }

                if (value.Equals(conditional.Value))
                {
                    continue;
                }

                var prefix = bindingContext.FallbackToEmptyPrefix ? property.Name : bindingContext.ModelName + "." + property.Name;
                
                bindingContext.ModelState.RemovePrefix(prefix);
            }

            return model;
        }

        private static object GetPropertyValue(object model, Type modelType, string propertyName)
        {
            var propertyInfo = modelType.GetProperty(propertyName);

            if (propertyInfo == null)
            {
                return null;
            }

            return propertyInfo.GetValue(model);
        }
    }
}
