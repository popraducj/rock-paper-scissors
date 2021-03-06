// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRoute.cs" company="Microsoft">
//   Copyright � 2016 Microsoft
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace App.RockPaperScissors.Web.Routing
{
    using System.Web.Routing;

    public class DefaultRoute : Route
    {
        public DefaultRoute()
            : base("{*path}", new DefaultRouteHandler())
        {
            this.RouteExistingFiles = false;
        }
    }
}
