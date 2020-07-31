using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ClassLibrary_Service1
{
    class RestApiHelper
    {

        public static RestClient client;
        public static RestRequest restrequest;

        public static RestClient SetUrl(string endpoint)
        {

            return client = new RestClient(endpoint);
        }

        public static RestRequest CreateReqyest(string ContentType, string Connectionvalues, string MethodType, string RequestBody)
        {
            if (MethodType.Equals("GET"))
            {
                restrequest = new RestRequest(Method.GET);
                restrequest.AddHeader(Connectionvalues, ContentType);
                //  return restrequest;
            }
            else if (MethodType.Equals("POST"))
            {
                restrequest = new RestRequest(Method.POST);
                restrequest.AddHeader(Connectionvalues, ContentType);
                restrequest.AddJsonBody(RequestBody);
                //return restrequest;

            }

            return restrequest;

        }
        public static IRestResponse getResponse()
        {

            return client.Execute(restrequest);
        }



        public static void verifyGivenNodeValue(Table table, JObject jsonObj)
        {

            for (int i = 0; i <= table.Rows.Count - 1; i++)
            {
                string actualValue = "";

                var servicePath = table.Rows[i][0];
                var expecterValue = table.Rows[i][1];

                var json = JToken.Parse(jsonObj.ToString());
                var fieldsCollector = new JaonObject.JsonFieldsCollector(json);
                var fields = fieldsCollector.GetAllFields();
                int flag = 0;
                foreach (var field in fields)
                {
                    string servicekey = field.Key;
                    if (servicekey.ToString().Equals(servicePath))
                    {
                        actualValue = field.Value.ToString();
                        Assert.AreEqual(expecterValue.ToString(), actualValue.ToString());
                        Console.WriteLine("Expected value " + expecterValue + "is present in respone");
                        break;
                    }


                }
               
         

               
             
            }
        }

      

    }
}
