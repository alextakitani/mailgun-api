using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using Mailgun;

namespace Mailgun.RestSharp {

    public class MailgunRestSharpClient : MailgunBaseClient, IMailgunClient {

        private readonly IRestClient fRestClient;

        public MailgunRestSharpClient(string apiKey) {
            
            fRestClient = new RestClient(MailgunApiBaseUrl) { 
                Authenticator = new HttpBasicAuthenticator("api", apiKey) ,
                UserAgent = UserAgent,
            };
        }
              
        public string UserAgent {
            get {
                return "Mailgun API RestSharp Client"; ;
            }
        }

        public T Get<T>(string route, Dictionary<string, object> @params = null) where T : new() {

            RestRequest request = new RestRequest(route, Method.GET);

            if (@params != null) {
                foreach (var kvPair in @params) {
                    request.AddParameter(kvPair.Key, kvPair.Value);
                }
            }

            return fRestClient.Execute<T>(request).Data;

        }

    }
}
