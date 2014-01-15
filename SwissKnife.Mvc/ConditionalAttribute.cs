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

            Inverse = false;
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

        public bool Inverse { get; set; }

        internal bool IsMatch(object value)
        {
            if (Inverse)
            {
                return !Value.Equals(value);
            }

            return Value.Equals(value);
        }
    }
}
