using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using ClassLibrary_Service1.Steps;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System.Collections.Generic;
using NUnit.Framework;
using System.Runtime.Remoting;

namespace ClassLibrary_Service1.Utility
{
    class APIUtil
    {
        private object objSpecflowq1;
        private object str;
        private static IEnumerable<object> getemployeesRequestObj;

        public static void processServiceDetails(string serviceName, string fileName, Hashtable servicedetails)
        {


            SpecFlowFeature1 objSpecflowq1 = new SpecFlowFeature1();

            if (fileName.Equals("ServiceDetail"))
            {
                var lines = File.ReadAllLines(@"C:\Users\amitava.chowdhary\source\repos\Service1\ClassLibrary_Service1\ClassLibrary_Service1\ServicesDetails\" + fileName + ".txt");
                for (var i = 0; i < lines.Length; i += 1)
                {
                    var line = lines[i];
                    if (line.Contains(serviceName))
                    {

                        objSpecflowq1.Urlsuffix = stringProcess(lines[i + 1]);
                        GlobalVeriableClass.SName = stringProcess(lines[i]);
                        GlobalVeriableClass.connectionvalues = stringProcess(lines[i + 2]);
                        GlobalVeriableClass.ContentType = stringProcess(lines[i + 3]);
                        GlobalVeriableClass.MethodType = stringProcess(lines[i + 4]);
                        GlobalVeriableClass.url = stringProcess(lines[i + 5]);
                        GlobalVeriableClass.Requestbody = stringProcess(lines[i + 6]);
                        GlobalVeriableClass.Params = stringProcess(lines[i + 7]);

                    }
                }
            }
            else if (fileName.Equals("ServiceData"))
            {


                Microsoft.Office.Interop.Excel.Application _excelApp = new Microsoft.Office.Interop.Excel.Application();
                _excelApp.Visible = true;

                string fileName1 = "C:\\ServicesData\\ServicesData.xlsx";

                //open the workbook
                Workbook workbook = _excelApp.Workbooks.Open(fileName1);

                //select the first sheet        
                Worksheet worksheet = (Worksheet)workbook.Worksheets[1];

                //find the used range in worksheet
                Range excelRange = worksheet.UsedRange;

                //get an object array of all of the cells in the worksheet (their values)
                object[,] valueArray = (object[,])excelRange.get_Value(
                            XlRangeValueDataType.xlRangeValueDefault);

                //access the cells
                for (int row = 1; row <= worksheet.UsedRange.Rows.Count; ++row)
                {
                    for (int col = 1; col <= worksheet.UsedRange.Columns.Count; ++col)
                    {
                        string val = valueArray[row, col].ToString();
                        if (val.Equals(serviceName))
                        {
                            servicedetails.Add("ServiceName", valueArray[row, col].ToString());
                            servicedetails.Add("Urlsuffix", valueArray[row + 1, col].ToString());
                            servicedetails.Add("Connectionvalues", valueArray[row + 2, col].ToString());
                            servicedetails.Add("ContentType", valueArray[row + 3, col].ToString());
                            servicedetails.Add("MethodType", valueArray[row + 4, col].ToString());
                            servicedetails.Add("RequestUrl", valueArray[row + 5, col].ToString());
                            servicedetails.Add("Requestbody", valueArray[row + 6, col].ToString());
                            servicedetails.Add("Params", valueArray[row + 7, col].ToString());

                            GlobalVeriableClass.url = valueArray[row + 5, col].ToString();
                            GlobalVeriableClass.SName = valueArray[row, col].ToString();
                            GlobalVeriableClass.connectionvalues = valueArray[row + 2, col].ToString();
                            GlobalVeriableClass.ContentType = valueArray[row + 3, col].ToString();
                            GlobalVeriableClass.MethodType = valueArray[row + 4, col].ToString();
                            GlobalVeriableClass.Requestbody = valueArray[row + 6, col].ToString();
                            GlobalVeriableClass.Params = valueArray[row + 7, col].ToString();
                        }
                    }
                }

                //clean up stuffs
                workbook.Close(false, Type.Missing, Type.Missing);
                Marshal.ReleaseComObject(workbook);

                _excelApp.Quit();
                Marshal.FinalReleaseComObject(_excelApp);


            }
            else if (fileName.Equals("ServiceDetailsJSONString"))
            {
                //  var lines = File.ReadAllLines(@"C:\Users\amitava.chowdhary\source\repos\Service1\ClassLibrary_Service1\ClassLibrary_Service1\ServiceDetailsJSONString\getemployees.json");
                //Console.WriteLine(lines);
                //   JObject json = JObject.Parse(lines);
                // Console.WriteLine(Createuser.Roles[1]);
                // StreamReader r = new StreamReader(@"C:\Users\amitava.chowdhary\source\repos\Service1\ClassLibrary_Service1\ClassLibrary_Service1\ServiceDetailsJSONString\getemployees.json");
                string json = File.ReadAllText(@"C:\Users\amitava.chowdhary\source\repos\Service1\ClassLibrary_Service1\ClassLibrary_Service1\ServiceDetailsJSONString\getemployees.json");
                //string json = r.ReadToEnd();
                //dynamic array = JsonConvert.DeserializeObject(json);
              //  JsonClass.getemployeesRequest.getemployeesRequest obj = JsonConvert.DeserializeObject<JsonClass.getemployeesRequest.getemployeesRequest>(json);
                //var obj = Activator.CreateInstance(Type.GetType("JsonClass"+ "." + serviceName + "." + "getemployeesRequest"));
               //var objjsonData = Activator.CreateInstance("JsonClass.getemployees.getemployeesRequest", "getemployees");
                //string obj = JsonConvert.SerializeObject(objjsonData);
               // Console.WriteLine("RequestUrl  :" + obj.IndexOf("RequestUrl"));
               // JObject jo = JObject.Parse(json);
               

               /* servicedetails.Add("ServiceName", obj.ServiceName.ToString());
                servicedetails.Add("Urlsuffix", obj.Urlsuffix.ToString());
                servicedetails.Add("Connectionvalues",obj.Connectionvalues.ToString());
                servicedetails.Add("ContentType", obj.ContentType.ToString());
                servicedetails.Add("MethodType", obj.MethodType.ToString());
                servicedetails.Add("RequestUrl", obj.RequestUrl.ToString());
                servicedetails.Add("Requestbody",obj.RequestBody.ToString());
                string json1 = JsonConvert.SerializeObject(obj.Params);
                servicedetails.Add("Params", json1);

                objSpecflowq1.Urlsuffix = obj.Urlsuffix.ToString();
                GlobalVeriableClass.SName = obj.ServiceName;
                GlobalVeriableClass.connectionvalues = obj.Connectionvalues;
                GlobalVeriableClass.ContentType = obj.ContentType;
                GlobalVeriableClass.MethodType = obj.MethodType;
                GlobalVeriableClass.url = obj.RequestUrl;
                GlobalVeriableClass.Requestbody = obj.RequestBody;
                GlobalVeriableClass.Params = obj.Params.ToString();*/
            }


           



                string stringProcess(string var1)
            {
                var result1 = "";
                var keyname = "";
                if (var1.Trim().Equals(""))
                {
                    Console.Write("empty string");
                    return var1;
                }
                else
                {

                    string[] val = var1.Split(new char[] { ':' }, 2);
                    keyname = val[0].Trim();
                    if (var1.Contains("Urlsuffix") || var1.Contains("ContentType") || var1.Contains("ServiceName") || var1.Contains("MethodType") || var1.Contains("RequestUrl"))
                    {
                        result1 = val[1].Remove(0, 2).Trim();
                    }
                    else
                    {
                        result1 = val[1].Remove(0, 1).Trim();
                    }
                }
                string result = result1.Remove(result1.Length - 1).Trim();
                servicedetails.Add(keyname, result);
                return result;
            }

        }

       
        public static void CallServiceWithModifiedParameter(string serviceType, Table table, Hashtable servicedetails, Hashtable paramdetails)
        {

            for (int i = 0; i <= table.Rows.Count - 1; i++)
            {

                var Veriable = table.Rows[i][0];
                var Value = table.Rows[i][1];

                ICollection keys = servicedetails.Keys;
                foreach (String k in keys)
                {
                    //string val1;
                    string val = servicedetails[k].ToString();
                    if (val.Contains("${" + Veriable + "}"))
                    {
                        StringBuilder builder = new StringBuilder(val);
                        builder.Replace("${" + Veriable + "}", Value);
                        val = builder.ToString();
                      //  Console.WriteLine(val.ToString());
                        servicedetails[k] = val;
                        break;
                    }

                }



            }

            ICollection keys1 = servicedetails.Keys;
            foreach (String k in keys1)
            {
                //string val1;
                string val = servicedetails[k].ToString();
                if (val.Contains("Params."))
                {
                    String[] spearator = { "Params." };
                    string[] paramval = val.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    string paramvalue = paramval[1].ToString();
                    val = paramdetails[paramvalue].ToString();
                    //Console.WriteLine(val.ToString());
                    servicedetails[k] = paramval[0].ToString() + val;
                    break;
                }

            }

        }


          public static void processParamDetails(RestSharp.IRestResponse response, Hashtable servicedetails, Hashtable paramdetails)
        {         

            var parkeyname = "";
            var parkeyvalue = "";
            foreach (string key in servicedetails.Keys)
            {
                string ParamVal = servicedetails["Params"].ToString();
                var jObject = JObject.Parse(response.Content);
                var json = JToken.Parse(jObject.ToString());
                var fieldsCollector = new JaonObject.JsonFieldsCollector(json);
                var fields = fieldsCollector.GetAllFields();
              
                if (ParamVal.Trim() != "")
                {
                   
                    string[] paramString = ParamVal.Split(',');
                    foreach (var word in paramString)
                    {
                        //  Console.WriteLine(word);
                        int flag = 0;
                        string[] val1 = word.Split(new char[] { ':' }, 2);
                        parkeyname = Regex.Replace(val1[0], "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);                      
                        var keyvalue1 = Regex.Replace(val1[1], "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                        foreach (var field in fields)
                        {
                           string servicekey = field.Key;
                            if (servicekey.ToString().Equals(keyvalue1))
                            {
                                parkeyvalue = field.Value.ToString();
                                paramdetails.Add(parkeyname, parkeyvalue);
                                flag = 1;
                                break;
                            }

                          
                        }
                        if (flag==1)
                        {
                            Console.WriteLine("Param Value" + parkeyvalue + "present in node");

                        }
                        else
                        {
                            Console.WriteLine("Param Value" + parkeyvalue + "NOT present in node");
                            Assert.Fail("Test Case failed");
                        }
                }
                    break;
                }


            }

        }

       


    }
}