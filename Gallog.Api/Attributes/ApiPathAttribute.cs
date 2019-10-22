using System;

namespace Gallog.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class ApiPathAttribute : Attribute
    {
        internal string Path { get; set; }
        internal ApiPathAttribute(string path)
        {
            Path = path;
        }
    }
}
