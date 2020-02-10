using CsvHelper;
using Newtonsoft.Json;
using PortfolioPayments.Helpers;
using PortfolioPayments.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace PortfolioPayments
{
    class Program
    {
        static void Main(string[] args)
        {
            // parameters            
            string urlStub = @"https://focus.interview/api/v1.0/payments/";
            List<int> portfolios = new List<int>() { 100, 110, 155 };
            string outputDirectory = @"C:\BnppTest\";
            string outputCsvFile = "PortfolioPayments.csv";

            #region set up variables
            string outputCsvFilePath = Path.Combine(outputDirectory, outputCsvFile);
            string url;
            string json = "";
            string errorMessage = "";
            bool errorExists = false;
            List<Payment> payments = new List<Payment>();
            #endregion

            try
            {
                Utilities.CreateDirectoryIfNotExists(outputDirectory);

                #region iterate through portfolio urls and add data to object
                foreach (int portfolio in portfolios)
                {
                    url = urlStub + portfolio;

                    Utilities.Log("");
                    Utilities.Log("Get json for portfolio " + portfolio);

                    if (Utilities.GetJsonFromUrl(url, ref json, ref errorMessage))
                    {
                        List<Payment> portfolioPayments = JsonConvert.DeserializeObject<List<Payment>>(json);

                        Utilities.Log("Records found: " + portfolioPayments.Count);

                        foreach (Payment portfolioPayment in portfolioPayments)
                        {
                            payments.Add(portfolioPayment);
                        }
                    }
                    else
                    {
                        errorExists = true;
                        Utilities.Log("error accessing url " + url);
                        Utilities.Log("error message: " + errorMessage);
                    }
                }
                #endregion

                #region output object to csv file
                using (var streamWriter = new StreamWriter(outputCsvFilePath))
                using (var csv = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(payments);
                }
                #endregion

                #region display process status, prompt user to finish
                Utilities.Log("");
                if (errorExists)
                {
                    Utilities.Log("Process completed with errors");
                }
                else
                {
                    Utilities.Log("Process completed OK");
                }

                Utilities.Log("Press any key and output file " + outputCsvFilePath + " will be dsplayed");
                Console.ReadKey();
                #endregion

                #region show output csv file in notepad
                Process.Start("notepad.exe", outputCsvFilePath);
                #endregion

                return;

            }
            catch (Exception ex)
            {
                #region display error message and prompt user to finish

                Utilities.Log("");
                Utilities.Log(ex.Message);
                Utilities.Log("");
                Utilities.Log("Error in processing - see error message above");

                Utilities.Log("Press any to exit");
                Console.ReadKey();
                #endregion

                return;
            }
        }
    }
}
