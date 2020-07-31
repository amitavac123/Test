using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_Service1.JsonClass
{
    public class RequestBody
    {
        public string name { get; set; }
        public string job { get; set; }
    }

    public class postCreateuserParams
    {
        public string NAME { get; set; }
    }

    public class postCreateuserRequest
    {
        public string ServiceName { get; set; }
        public string Urlsuffix { get; set; }
        public string Connectionvalues { get; set; }
        public string ContentType { get; set; }
        public string MethodType { get; set; }
        public string RequestUrl { get; set; }
        public RequestBody RequestBody { get; set; }
        public postCreateuserParams Params { get; set; }
    }


}
