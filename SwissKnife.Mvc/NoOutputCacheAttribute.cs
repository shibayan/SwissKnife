using System;

namespace SwissKnife.Mvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class NoOutputCacheAttribute : Attribute
    {
    }
}
