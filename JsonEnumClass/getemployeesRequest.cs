using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_Service1.JsonClass
{
    public class Params
    {
        public string STREET { get; set; }
        public string ID { get; set; }
    }

    public class getemployeesRequest
    {
        public string ServiceName { get; set; }
        public string Urlsuffix { get; set; }
        public string Connectionvalues { get; set; }
        public string ContentType { get; set; }
        public string MethodType { get; set; }
        public string RequestUrl { get; set; }
        public string RequestBody { get; set; }
        public Params Params { get; set; }
    }


}
