using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace f
{
    public class RequestHandlerEuronews : libhbrd.RequestHandlerBase
    {
        protected override bool DoBeforeBrowse(CefSharp.IWebBrowser browser, CefSharp.IRequest request, CefSharp.NavigationType naigationvType, bool isRedirect)
        {
            Uri uri = new Uri(request.Url);
            if (!uri.Host.EndsWith("euronews.com")) return true; // true == cancel
            else return base.DoBeforeBrowse(browser, request, naigationvType, isRedirect);
        }
    }
}
