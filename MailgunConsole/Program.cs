using Mailgun;
using Mailgun.RestSharp;
using Mailgun.ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailgunConsole {
    class Program {
        static void Main(string[] args) {

            string key = "YOUR MAILGUN API KEY HERE";
            string domain = "your.domain.here";

            // Using ServiceStack
            var ssClient = new MailgunServiceStackClient(key);
            GetLogs(ssClient, domain);

            // Using RestSharp
            var rsClient = new MailgunRestSharpClient(key);
            GetLogs(rsClient, domain);

            Console.ReadKey();

        }
        
        private static void GetLogs(IMailgunClient mailgunClient, string domain) {

            Action<MailgunEventResponse> print = (response) => {

                foreach (var item in response.Items) {
                    Console.WriteLine("Timestamp : {0}; Event : {1}", item.Timestamp.UnixTimeStampToDateTime(), item.Event);
                }
            };

            var events = new MailgunEvents(mailgunClient, domain);

            var eqb = new EventQueryBuilder()
                .Or(MailgunEvent.Accepted.ToOperand(), MailgunEvent.Delivered.ToOperand(), MailgunEvent.Opened.ToOperand());
            var result = eqb.Build();

            var eventParams = new MailgunEventParams() {
                Limit = 10,
                Pretty = true,
                FilterFieldType = result.FilterFieldType,
                FilterFieldValue = result.FilterValue,
            };

            var eventsResponse1 = events.Get(eventParams);
            var i = 1;
            while (eventsResponse1.Items.Count() > 0) {
                Console.WriteLine("Printing Page {0}", i++);
                print(eventsResponse1);
                eventsResponse1 = events.Next();
            }
        }
    }
}
