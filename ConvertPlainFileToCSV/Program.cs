using System;
using System.IO;
using System.Linq;

namespace ConvertPlainFileToCSV
{
    public class Program
    {
        static void Main(string[] args)
        {
            string textFilePath = @"c:\POC\DemoPOC\SampleText.txt";
            string csvfilePath = @"c:\POC\DemoPOC\output.csv";

            int index = 0;
            int[] arr = { 9,3,10,6,4,5,10,1,16,35,6,1,26,1,9,1,16,1,16,2,8,1,2,1,16,1,16,1,5,1,4,1,8,1,20,1,8,1 };
            string fieldNames = "LUW ID,Record Type,Source ID,Run Number,Company ID,Event ID,Fund Code,Filler01,AMOUNTSTR,TRANSDATESTR,Cheque Number,Filler02,Payee Name,Filler03,Payee Postcode,Filler04,Payee Reference,Filler05,Agent ID,Filler06,Treaty ID,Filler07,Premium Type,Filler08,Scheme ID,Filler09,Wrapper Number,Filler10,Reason Code,Filler11,PRAS Scheme,Filler12,Product Code,Filler13,Incident Number,Filler14,Suspense Entry ID,Filler15,Claim Bonus Type,Filler16,Payroll Class Id,Filler17,PCRN,Filler18,Unique Receipt No,Filler19,Claim Reference,Filler20,Payment Plan Reference ,Filler21,Payroll ID,Filler22";
            
            // Adding all fields name in csv file as per the GL Detail Record .
            File.AppendAllText(csvfilePath, fieldNames);
            File.AppendAllText(csvfilePath, Environment.NewLine);

            //reading all text file lines
            var lines = System.IO.File.ReadAllLines(textFilePath);

            //removing last line from the text file.
            lines = lines.Take(lines.Length - 1).ToArray();
            foreach (string line in lines)
            {
               
                if (!string.IsNullOrEmpty(line))
                {

                    for (int i = 0; i <= arr.Length; i++)
                    {
                        if (i == arr.Length)
                        {
                            var results = line.Substring(index, arr[arr.Length - 1]);
                            File.AppendAllText(csvfilePath, results);
                        }
                        else
                        {
                            var results = line.Substring(index, arr[i]);
                            index = index + arr[i];
                            File.AppendAllText(csvfilePath, results + ",");

                        }

                    }
                    System.Console.WriteLine(line);
                    index = 0;
                }

                // adding new line once one line reading completed.
                File.AppendAllText(csvfilePath, Environment.NewLine);

            } 
            System.Console.ReadLine();
        }
    }
}
