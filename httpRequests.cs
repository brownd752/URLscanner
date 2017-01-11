using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//addded
using System.Net;
using System.Net.Http;

namespace DirectoryScan
{
    class httpRequests
    {
        HttpStatusCode statuscode;

        /// <summary>
        /// Creates a connection to the URL.
        /// </summary>
        /// <param name="url"></param>
        public void connection(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Timeout = 3000;
                request.AllowAutoRedirect = true; // find out if this site is up and don't follow a redirector
                request.Method = "HEAD";
                //Console.WriteLine(url);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                statuscode = response.StatusCode;
                response.Close();
            }
            catch (WebException)
            {
                Console.WriteLine("URL returned a code of 5xx or other");

            }

        }

        public Boolean statusOK()
        {
            if (statuscode == HttpStatusCode.OK)
            {
                return true;
            } else
            {
                return false;
            }
        }

        /// <summary>
        /// returns the status code from the connection method.
        /// </summary>
        /// <returns>HttpStatusCode</returns>
        private HttpStatusCode getStatusCode()
        {
            return statuscode;
        }

        /// <summary>
        /// This method is used to get content from pages.
        /// while not used in the program could be usefull for other applications.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public async void getPageContent(string url)
        {
            // sends a request to url to get conent
            HttpClient client = new HttpClient();
            HttpResponseMessage res = await client.GetAsync(url);
            HttpContent content = res.Content;
        }

        public Boolean pingURL(string url)
        {
            try
            {
                Console.WriteLine("Pinging URL");
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Timeout = 3000;
                request.AllowAutoRedirect = false; // find out if this site is up and don't follow a redirector
                request.Method = "HEAD";

                using (var response = request.GetResponse())
                {
                    Console.WriteLine("URL Active");
                    return true;
                }

            }
            catch
            {
                Console.WriteLine("Could not reach host");
                return false;
               
            }

        }

    }
}
