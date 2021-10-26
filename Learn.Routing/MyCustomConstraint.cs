using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Learn.Routing
{
    public class MyCustomConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out var value))
            {
                if (value is string stringValue)
                {
                    return stringValue.StartsWith("0");
                }
            }

            return false;
        }
    }
}
