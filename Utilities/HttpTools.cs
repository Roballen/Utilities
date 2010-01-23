using System.IO;
using System.Net;
using System.Text;

namespace Utilities
{
    public class HttpTools
    {
        /// <summary>
        /// Makes an HTTP POST to specified URI and returns the response.
        /// </summary>
        /// <param name="URI"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public static string Post(string URI, string Parameters)
        {
            WebRequest request = WebRequest.Create(URI);
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(Parameters);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }

        /// <summary>
        /// Makes an HTTP GET to specified URI and returns response.
        /// </summary>
        /// <param name="URI"></param>
        /// <returns></returns>
        public static string Get(string URI)
        {
            WebRequest request = WebRequest.Create(URI);
            request.Credentials = CredentialCache.DefaultCredentials;
            var response = (HttpWebResponse) request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
    }
}