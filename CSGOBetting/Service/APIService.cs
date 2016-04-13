using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CSGOBetting.App_Code;
using CSGOBetting.Exceptions;

namespace CSGOBetting.Service
{
    public class APIService
    {
        private static DateTime _lastcall;
        private string APIUrl { get; set; }

        public APIService(string apiUrl)
        {
            APIUrl = apiUrl;
        }

        public string GetResponse()
        {
            DateTime utcnow = DateTime.UtcNow;
            using (var client = new WebClient())
            {
                if (_lastcall > utcnow.Subtract(TimeSpan.FromSeconds(10)))
                {
                    try
                    {
                        string response = client.DownloadString(APIUrl);
                        _lastcall = utcnow;
                        return response;
                    }
                    catch
                    {
                        throw new APIExceptions.APIFailureToCommunicateException("The API failed in some way.");
                    }
                }
                else
                {
                    throw new APIExceptions.APIRateLimitException("Last call within 10 seconds. Please wait.");
                }
            }
        }
    }
}
