using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace KPI.Client
{
    internal class KPISecureClient : KPIClient
    {
        protected string ApiKey { get; private set; }

        internal KPISecureClient(string apiKey)
            : base()
        {
            this.ApiKey = apiKey;
        }

        protected override WebRequest CreateRequest(string method, string path, IDictionary<string, object> parameters, object body)
        {
            var req = base.CreateRequest(method, path, parameters, body);
            req.Headers.Add("Authorization", this.ApiKey);
            return req;
        }
    }
}
