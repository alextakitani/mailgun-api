using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ServiceStack;

namespace Mailgun.ServiceStack {

    public class MailgunServiceStackClient : MailgunBaseClient, IMailgunClient {

        private readonly CredentialCache fCredentialCache;

        public MailgunServiceStackClient(string apiKey) {
            fCredentialCache = new CredentialCache();
            Uri url = new Uri(MailgunApiBaseUrl);
            fCredentialCache.Add(url, "Basic", new NetworkCredential("api", apiKey));
        }

        public string UserAgent {
            get {
                return "Mailgun API ServiceStack Client";
            }
        }

        public T Get<T>(string route, Dictionary<string, object> @params = null) where T : new() {

            var url = string.Format("{0}{1}", MailgunApiBaseUrl, route);

            if (@params != null) {
                foreach(var kvPair in @params) {
                    url = url.AddQueryParam(kvPair.Key, kvPair.Value);
                }
            }
        
            return url.GetJsonFromUrl(requestFilter: req => {
                    req.Credentials = fCredentialCache;
                    req.UserAgent = UserAgent;
                })
                .FromJson<T>();
        }

    }
}
