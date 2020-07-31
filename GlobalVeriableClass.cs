using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_Service1
{
    class GlobalVeriableClass
    {

        private static string v_url = "";
        public static string url
        {
            get { return v_url; }
            set { v_url = value; }
            
        }
        private static string v_SName = "";
        public static string SName
        {
            get { return v_SName; }
            set { v_SName = value; }

        }
        private static string v_urlsuffix = "";
        public static string urlsuffix
        {
            get { return v_urlsuffix; }
            set { v_urlsuffix = value; }

        }
        private static string v_connectionvalues = "";
        public static string connectionvalues
        {
            get { return v_connectionvalues; }
            set { v_connectionvalues = value; }

        }
        private static string v_ContentType= "";
        public static string ContentType
        {
            get { return v_ContentType; }
            set { v_ContentType = value; }

        }
        private static string v_MethodType = "";
        public static string MethodType
        {
            get { return v_MethodType; }
            set { v_MethodType = value; }

        }
        private static string v_Requestbody = "";
        public static string Requestbody
        {
            get { return v_Requestbody; }
            set { v_Requestbody = value; }

        }
        private static string v_Params = "";
        public static string Params
        {
            get { return v_Params; }
            set { v_Params = value; }

        }
    }
}
