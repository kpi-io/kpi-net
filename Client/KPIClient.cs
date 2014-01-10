// Copyright (c) KPI.IO
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/kpi-io/kpi-net


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace KPI.Client
{
    internal class KPIClient
    {
        private string SerializeObject(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            return null;
        }

        protected virtual WebRequest CreateRequest(string method, string path, IDictionary<string, object> parameters, object body)
        {
            var url = this.Url(path);
            Console.WriteLine("Url : " + url);
            var req = HttpWebRequest.Create(url);
            req.Method = method;
            return req;
        }

        internal void Send(string method, string path, IDictionary<string, object> parameters, object body, OnErrorHandler onError, OnHttpSuccessHandler onSuccess)
        {
            var req = this.CreateRequest(method, path, parameters, body);

            if (body != null)
            {
                req.ContentType = "application/json";
                var str = JsonConvert.SerializeObject(body);
                byte[] byteArray = Encoding.UTF8.GetBytes(str);
                req.ContentLength = byteArray.Length;
                var requestStream = req.GetRequestStream();
                requestStream.Write(byteArray, 0, byteArray.Length);
                requestStream.Close();
            }

            var StreamDecode = Encoding.UTF8.GetDecoder();
            var res = req.GetResponse();
            var stream = res.GetResponseStream();
            JObject result = null;
            using(var reader = new StreamReader(stream))
            {
                var str = reader.ReadToEnd();
                Console.WriteLine("result : " + str);
                result = JObject.Parse(str);
                var code = result["response"]["code"].Value<int>();
                var message = result["response"]["message"].Value<string>();
                var tmp = result["result"];
                var resultData = tmp != null ? tmp.ToString() : null;

                if (result["response"]["code"].Value<int>() == 100)
                {
                    onSuccess(resultData);
                }
                else
                {
                    onError(new Exceptions.KPIException(code, message));
                }
            }
            res.Close();
        }

        internal virtual string Url(string path)
        {
            return KPIConstants.Url + path;
        }
    }
}
