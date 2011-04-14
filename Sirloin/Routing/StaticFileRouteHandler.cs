using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Sirloin.Routing
{
    internal sealed class StaticFileRouteHandler : IRouteHandler
    {
        private string virtualPath;

        public StaticFileRouteHandler(string VirtualPath)
        {
            // make sure something was passed in
            if (string.IsNullOrEmpty(VirtualPath))
            {
                throw new ArgumentNullException("VirtualPath");
            }

            virtualPath = VirtualPath;
        }

        public System.Web.IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            HttpContext.Current.RewritePath(virtualPath);
            return new DefaultHttpHandler();
        }

    }
}