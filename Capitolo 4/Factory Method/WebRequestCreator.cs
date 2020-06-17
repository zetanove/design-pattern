using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    public abstract class WebRequestCreator
    {
        protected abstract IWebRequest Create(string uri);

        public string SendRequest(string uri)
        {
            var req = this.Create(uri);
            var result = req.GetResponse();
            return result;
        }
    }

    public class HttpRequestCreator : WebRequestCreator
    {
        protected override IWebRequest Create(string uri)
        {
            return new HttpWebRequest(uri);
        }
    }

    public interface IWebRequest
    {
        string GetResponse();
    }

    public class HttpWebRequest : IWebRequest
    {
        public string Uri { get; set; }
        public HttpWebRequest(string uri)
        {
            Uri = uri;
        }
        public string GetResponse()
        {
            return "Response from " + Uri;
        }
    }
}
