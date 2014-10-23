using System;
using System.Collections.Generic;
using System.Linq;

namespace Mailgun {

    public class MailgunEvents {

        private readonly IMailgunClient fClient;
        private readonly string fDomain;
        private string fPrevious;
        private string fNext;

        public MailgunEvents(IMailgunClient client, string domain) {
            fClient = client;
            fDomain = domain;
            fPrevious = "";
            fNext = "";
        }

        private string GetUrl(string paging) {
            return (string.IsNullOrEmpty(paging)) ? string.Format("{0}/events", fDomain) : string.Format("{0}/events/{1}", fDomain, paging);
        }

        public MailgunEventResponse Get(MailgunEventParams eventParams = null, string paging = null) {
            
            var @params = new Dictionary<string, object>();
            var url = GetUrl(paging);

            if (eventParams != null) {
                if (eventParams.Begin.HasValue) 
                    @params.Add("begin", eventParams.Begin.Value);
                if (eventParams.End.HasValue) 
                    @params.Add("end", eventParams.End.Value);
                if (eventParams.Limit.HasValue) 
                    @params.Add("limit", eventParams.Limit.Value);
                if (eventParams.Ascending.HasValue) 
                    @params.Add("ascending", eventParams.Ascending.Value.ToYesNo());
                if (eventParams.Pretty.HasValue) 
                    @params.Add("pretty", eventParams.Pretty.Value.ToYesNo());

                if (eventParams.FilterFieldType.HasValue) 
                    @params.Add(eventParams.FilterFieldType.ToName(), (string.IsNullOrEmpty(eventParams.FilterFieldValue)) ? "" : eventParams.FilterFieldValue);
            }

            var response = fClient.Get<MailgunEventResponse>(url, @params);
            if (response != null)
                ExtractPaging(response);
            return response;

        }

        public MailgunEventResponse Next() {
            return Get(null, fNext);
        }

        public MailgunEventResponse Previous() {
            return Get(null, fPrevious);
        }

         private void ExtractPaging(MailgunEventResponse response) {
            this.fNext = response.Paging.Next.Split('/')[6]; 
            this.fPrevious = response.Paging.Previous.Split('/')[6]; 
         }

    }
}
