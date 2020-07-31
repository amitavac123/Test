using AventStack.ExtentReports;
using AventStack.ExtentReports.Configuration;
using AventStack.ExtentReports.Reporter;
using ClassLibrary_Service1.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp.Serialization.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace ClassLibrary_Service1.Steps
{
   

    [Binding]
    public  class SpecFlowFeature1
    {
        public Hashtable servicedetails = new Hashtable();
        public Hashtable paramdetails = new Hashtable();
        public Hashtable ProcessedServicedetails = new Hashtable();
        public List<string> Servicelogger = new List<string>();
        private object str;
        public string RequestUrl;
        public string Urlsuffix;
        public string ContentType;
        public string MethodType;
        public string Requestbody;
        public string Connectionvalues;
        public JObject jsonObj;
        public string ServiceName;
        private object _scenarioContext;
        public string Params;
        private object context;
        public JsonClass.getemployeesRequest getemployeesRequestObj;
        public JsonClass.getemployeesResponse getemployeesResponseObj;
        public JsonClass.postCreateuserRequest postCreateuserRequestObj;
        public JsonClass.postCreateuserResponse postCreateuserResponseObj;
        public static RestSharp.IRestResponse response;
        public static string json;
        public object APIUtils { get; private set; }
        public static string run_typ;
        public static string environment;
        public static string default_browser;
        public static string ServiceDetailsForReport;
        /*public string getServiceDetailsForReport()
        {
            return ServiceDetailsForReport;
        }
        public void SetServiceDetailsForReporte(string _ServiceDetailsForReport)
        {
            ServiceDetailsForReport = _ServiceDetailsForReport;
        }*/
    
        [Given(@"RestService ""(.*)"" with config in ""(.*)"" file")]
        public void GivenRestServiceWithConfigInFile(string serviceName, string fileName )
        {
        
            servicedetails.Clear();
            APIUtil.processServiceDetails(serviceName, fileName, servicedetails);
     

        }

        [Given(@"RestService ""(.*)"" with config in ""(.*)"" Json file")]
        public void GivenRestServiceInJsonStaringFile(string serviceName, string fileNam)
        {
            switch (serviceName)
            {
                case "getemployees":
                    StreamReader reader = new StreamReader(@"C:\Users\amitava.chowdhary\source\repos\Service1\ClassLibrary_Service1\ClassLibrary_Service1\ServiceDetailsJSONString\getemployees.json");
                    string json = reader.ReadToEnd();
                    getemployeesRequestObj = JsonConvert.DeserializeObject<JsonClass.getemployeesRequest>(json);
                    break;
                case "createuser":
                    StreamReader reader1 = new StreamReader(@"C:\Users\amitava.chowdhary\source\repos\Service1\ClassLibrary_Service1\ClassLibrary_Service1\ServiceDetailsJSONString\createuser.json");
                    string json1 = reader1.ReadToEnd();
                    postCreateuserRequestObj = JsonConvert.DeserializeObject<JsonClass.postCreateuserRequest>(json1);
                    break;
                default:
                    Console.WriteLine("No Data");
                    break;
            }
        }


        [Then(@"I call ""(.*)"" service ""(.*)"" with modified parameter")]
        public void ThenICallServiceWithModifiedParameter(string serviceType, string serviceName, Table table)
        {
            ServiceDetailsForReport = "";


            switch (serviceName)
            {
                case "getemployees":
                    RestApiHelper.SetUrl(getemployeesRequestObj.RequestUrl + getemployeesRequestObj.Urlsuffix);
                    RestApiHelper.CreateReqyest(getemployeesRequestObj.ContentType, getemployeesRequestObj.Connectionvalues, getemployeesRequestObj.MethodType, getemployeesRequestObj.RequestBody);

                    response = RestApiHelper.getResponse();
                    jsonObj = JObject.Parse(response.Content);
                    string json = jsonObj.ToString();

                    getemployeesResponseObj = JsonConvert.DeserializeObject<JsonClass.getemployeesResponse>(json);
                    Console.WriteLine("#################################################################");
                    Console.WriteLine("Service Details for the service : " + getemployeesRequestObj.ServiceName);
                    Console.WriteLine("#################################################################");
                    Console.WriteLine("Urlsuffix  : " + getemployeesRequestObj.Urlsuffix);
                    Console.WriteLine("Connectionvalues : " + getemployeesRequestObj.Connectionvalues);
                    Console.WriteLine("ContentType : " + getemployeesRequestObj.ContentType);
                    Console.WriteLine("MethodType : " + getemployeesRequestObj.MethodType);
                    Console.WriteLine("RequestUrl : " + getemployeesRequestObj.RequestUrl);
                    Console.WriteLine("RequestBody : " + getemployeesRequestObj.RequestBody);
                    Console.WriteLine("Response : " + response.Content.ToString());
                    Console.WriteLine("#################################################################");


                    ServiceDetailsForReport = "[#### Service Details for the service ####] ==>> " + getemployeesRequestObj.ServiceName  + " [#####   RequestUrl  #####] ==>> " + getemployeesRequestObj.RequestUrl + "  [#####  Response #####]  ==>> " + response.Content.ToString();
                   // Console.WriteLine(ServiceDetailsForReport);
                    break;
                case "createuser":
                    string ServiceBody = Newtonsoft.Json.JsonConvert.SerializeObject(postCreateuserRequestObj.RequestBody);
                    RestApiHelper.SetUrl(postCreateuserRequestObj.RequestUrl + postCreateuserRequestObj.Urlsuffix);
                    RestApiHelper.CreateReqyest(postCreateuserRequestObj.ContentType, postCreateuserRequestObj.Connectionvalues, postCreateuserRequestObj.MethodType, ServiceBody);

                    response = RestApiHelper.getResponse();
                    jsonObj = JObject.Parse(response.Content);
                    json = jsonObj.ToString();


                    string RequestBodyString = Newtonsoft.Json.JsonConvert.SerializeObject(postCreateuserRequestObj.RequestBody);

                    postCreateuserResponseObj = JsonConvert.DeserializeObject<JsonClass.postCreateuserResponse>(json);
                    Console.WriteLine("#################################################################");
                    Console.WriteLine("Service Details for the service : " + postCreateuserRequestObj.ServiceName);
                    Console.WriteLine("#################################################################");
                    Console.WriteLine("Urlsuffix  : " + postCreateuserRequestObj.Urlsuffix);
                    Console.WriteLine("Connectionvalues : " + postCreateuserRequestObj.Connectionvalues);
                    Console.WriteLine("ContentType : " + postCreateuserRequestObj.ContentType);
                    Console.WriteLine("MethodType : " + postCreateuserRequestObj.MethodType);
                    Console.WriteLine("RequestUrl : " + postCreateuserRequestObj.RequestUrl);
                    Console.WriteLine("RequestBody : " + RequestBodyString);
                    Console.WriteLine("Response : " + response.Content.ToString());
                    Console.WriteLine("#################################################################");

                
                    ServiceDetailsForReport = "[#### Service Details for the service ####] ==>> " + postCreateuserRequestObj.ServiceName + "  [#####   RequestUrl  #####] ==>> " + postCreateuserRequestObj.RequestUrl  + "  [#####  RequestBody #####] ==>> " + RequestBodyString + "  [#####  Response #####]  ==>> " + response.Content.ToString();

                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
               }



        }


        [Given(@"I call ""(.*)"" service with modified parameter")]
        public void GivenICallServiceWithModifiedParameter(string serviceType, Table table)
        {
           APIUtil.CallServiceWithModifiedParameter(serviceType, table, servicedetails, paramdetails);
          

            String endpoint = servicedetails["RequestUrl"].ToString() + servicedetails["Urlsuffix"].ToString();
            String ContentType = servicedetails["ContentType"].ToString();
            String Connectionvalues = servicedetails["Connectionvalues"].ToString();
            String MethodType = servicedetails["MethodType"].ToString();
            //String RequestBody = servicedetails["RequestBody"].ToString();
            String RequestBody = GlobalVeriableClass.Requestbody;

            RestApiHelper.SetUrl(endpoint);
            RestApiHelper.CreateReqyest(ContentType, Connectionvalues, MethodType, RequestBody);
            var response = RestApiHelper.getResponse();
            Servicelogger.Add("endpoint= " + endpoint);
            Servicelogger.Add("ContentType= " + ContentType);
            Servicelogger.Add("Connectionvalues= " + Connectionvalues);
            Servicelogger.Add("MethodType= " + MethodType);
            Servicelogger.Add("RequestBody= " + RequestBody);
            Servicelogger.Add("Response= " + response.Content.ToString());
            Console.WriteLine("#################################################################");
            Console.WriteLine("Service Details for the service : " + servicedetails["ServiceName"].ToString());
            Console.WriteLine("#################################################################");
            Servicelogger.ForEach(el => Console.WriteLine(el));
            Console.WriteLine("#################################################################");

            APIUtil.processParamDetails(response, servicedetails, paramdetails);
           // processParamDetailstest(response, servicedetails, paramdetails);

        }
  

        [Given(@"verify response should return (.*) as statuscode")]
        public void GivenVerifyResponseShouldReturnAsStatuscodeAsync(String status)
        {
            
             response = RestApiHelper.getResponse();
            if (response.StatusCode.Equals(status))
            {
                Console.Write("Test Passed");
            }
           

        }

        [Then(@"verify following response values")]
        public void ThenVerifyFollowingResponseValues(Table table)
        {
               ServiceDetailsForReport = "";
               response = RestApiHelper.getResponse();
               jsonObj = JObject.Parse(response.Content);
               RestApiHelper.verifyGivenNodeValue(table, jsonObj);
            

        }

              


        public void processParamDetailstest(RestSharp.IRestResponse response, Hashtable servicedetails, Hashtable paramdetails)
        {

            var jObject = JObject.Parse(response.Content);
            var json = JToken.Parse(jObject.ToString());
            var fieldsCollector = new JaonObject.JsonFieldsCollector(json);
            var fields = fieldsCollector.GetAllFields();

            foreach (var field in fields)
            {
                var key = field.Key;
                Console.WriteLine($"{field.Key}: '{field.Value}'");
            }
        

    }




}
}
