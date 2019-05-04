using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace f
{
    public class WWW
    {
        public static string InternetIsUnavailable = "No connection to the internet"; // is available";

        public static bool IsOnline()
        {
            try
            {
                string host = "google.com";
                IPHostEntry entry = Dns.GetHostEntry(host);
                return entry != null;

            //    PingReply reply = (new Ping()).Send(host); //"74.125.232.20");
            //    if (reply.Status == IPStatus.Success)
            //        return true;
            //    else
            //    {
            //        reply = (new Ping()).Send(host);
            //        return reply.Status == IPStatus.Success;
            //    }
            //// string url = "http://www.google.com";
            ////    string mes;
            ////    ServiceExists(url, true, out mes);
            ////    return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool TryOnline(Control window)
        {
            bool f = IsOnline();
            if (!f)
                MessageBox.Show(window, WWW.InternetIsUnavailable, "Communication message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return f;
        }

        #region unused
        // http://stackoverflow.com/questions/330496/how-do-i-test-connectivity-to-an-unknown-web-service-in-c
        // http://www.geekpedia.com/code11_Check-if-HTTP-connection-to-website-is-available.html
        public static bool ServiceExists(string url, bool throwExceptions, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;

                // try accessing the web service directly via it's URL
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Timeout = 1000;

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception("Error locating web service");
                }

                // try getting the WSDL?
                // asmx lets you put "?wsdl" to make sure the URL is a web service
                // could parse and validate WSDL here

            }
            catch (WebException ex)
            {
                // decompose 400- codes here if you like
                errorMessage = string.Format("Error testing connection to web service at \"{0}\":\r\n{1}", url, ex);
                Trace.TraceError(errorMessage);
                if (throwExceptions)
                    throw new Exception(errorMessage, ex);
            }
            catch (Exception ex)
            {
                errorMessage = string.Format("Error testing connection to web service at \"{0}\":\r\n{1}", url, ex);
                Trace.TraceError(errorMessage);
                if (throwExceptions)
                    throw new Exception(errorMessage, ex);
                return false;
            }

            return true;
        }
 
	    #endregion    
    }
}
