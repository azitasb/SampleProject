using Sabahat.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sabahat.Common;
using System.Web;


namespace Sabahat.Business
{
    public class ServiceHandler
    {
        public static string CallApi(string uri, FormUrlEncodedContent content, Common.HttpRequest request)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var baseUrl = string.Format("{0}://{1}{2}{3}",
                                               HttpContext.Current.Request.Url.Scheme,
                                               HttpContext.Current.Request.Url.Host,
                                               HttpContext.Current.Request.Url.Port == 80 ? string.Empty : ":" + HttpContext.Current.Request.Url.Port,
                                               HttpContext.Current.Request.ApplicationPath);
                    uri = string.Format(uri, baseUrl);
                    client.BaseAddress = new Uri(uri);
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = new HttpResponseMessage();
                    if (request == Common.HttpRequest.HttpGet)
                    {
                        var w = client.GetAsync(uri);
                        w.Wait();
                        response = w.Result;
                    }
                    else if (request == Common.HttpRequest.HttpPost)
                    {
                        var w = client.PostAsync(uri, content);
                        w.Wait();
                        response = w.Result;
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync();
                        result.Wait();
                        return result.Result;
                    }
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
