using System;
using System.Collections.Generic;
using System.Linq;

namespace Mailgun {

    public interface IMailgunClient {

        string MailgunApiBaseUrl { get; }
        string UserAgent { get; }
        T Get<T>(string route, Dictionary<string, object> @params = null) where T : new();

    }
}