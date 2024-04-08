using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Util
{
    public static class LogGenerator
    {
        private static string _OutputPath = "C\\Deploy\\Logs";

        public static void CreateLogError(Exception ex, string application) 
        {
            var logObj = new 
            { 
                ApplicationName = application, 
                Type = ex.GetType(), 
                Message = ex.Message, 
                StackTrace = ex.StackTrace 
            };

            string json = JsonConvert.SerializeObject(logObj);
            string filePathOut = Path.Combine(_OutputPath, $"{application}.json");

            if(!Directory.Exists(_OutputPath))
                Directory.CreateDirectory(_OutputPath);

            var file =  File.Open(filePathOut, FileMode.OpenOrCreate);
            byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(json);
            file.Write(jsonBytes, 0, jsonBytes.Length);
            file.Close();
        }  
    }
}
