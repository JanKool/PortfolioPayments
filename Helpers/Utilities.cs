using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace PortfolioPayments.Helpers
{
    public static class Utilities
    {
        public static void Log(string message)
        {
            Console.WriteLine(message);
        }

        public static bool GetJsonFromUrl(string url, ref string json, ref string errorMessage)
        {
            bool success = true;
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    json = webClient.DownloadString(url);
                }
                catch (WebException e)
                {
                    errorMessage = e.Message;
                    success = false;
                }
            }
            return success;
        }

        public static void CreateDirectoryIfNotExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
