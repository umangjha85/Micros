using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace UIForMicro
{
    public static class GlobalVariables
    {
        public static HttpClient WebApiClent = new HttpClient();

        static GlobalVariables()
        {
            WebApiClent.BaseAddress = new Uri("https://localhost:44328/api/");
            WebApiClent.DefaultRequestHeaders.Clear();
            WebApiClent.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
