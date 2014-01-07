using System;

namespace SwissKnife.Mvc
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class ConditionalAttribute : Attribute
    {
        public ConditionalAttribute(string propertyName, object value)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException("propertyName");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            _propertyName = propertyName;
            _value = value;
        }

        private readonly string _propertyName;
        private readonly object _value;

        public string PropertyName
        {
            get { return _propertyName; }
        }

        public object Value
        {
            get { return _value; }
        }
    }
}
