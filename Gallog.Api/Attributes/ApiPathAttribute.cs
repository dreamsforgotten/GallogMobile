using System;
using System.Collections.Generic;
using System.Text;

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
