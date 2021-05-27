using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using PSA_Furikae.Algorithm;

namespace PSA_Furikae
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("err: no argument provided");
                Console.WriteLine("usage: .\\PSA_Furikae.exe filepath.txt");
                return;
            }
            FileInfo f = new FileInfo(args[0]);
            if (!f.Exists)
            {
                Console.WriteLine($"err: file {f.FullName} cannot be found.");
                return;
            }


            List<double[]> resultData = new List<double[]>();
            // parsing file:
            using (StreamReader sr = new StreamReader(f.FullName, Encoding.UTF8))
            {
                string singleLine;
                while ((singleLine = sr.ReadLine()) != null)
                {
                    string[] lineStringData = singleLine.Split('\t');
                    List<double> lineData = new List<double>();
                    foreach (string data in lineStringData)
                    {
                        if (data.Contains('-'))
                        {
                            lineData.Add(0);
                        }
                        else if (double.TryParse(data, out double parseResult))
                        {
                            lineData.Add(parseResult);
                        }
                    }

                    resultData.Add(lineData.ToArray());
                }
            }

            Solution s = new Solution();
            double[][] result = s.GetFuriKaeData(resultData.ToArray());
            Console.WriteLine(" >>>> Info <<<< File Data Read complete");
            Console.WriteLine($" >>>> Info <<<< row={resultData.Count},col={resultData[0].Length}");

            string outputFilename = DateTime.Now.ToString("yyyyMMdd_HHmmss_") + "output_result.txt";

            using (StreamWriter sw = new StreamWriter(outputFilename, false, Encoding.UTF8))
            {
                for (int i = 0; i < result.Length; i++)
                {
                    for (int j = 0; j < result[0].Length; j++)
                    {
                        sw.Write(result[i][j].ToString());
                        sw.Write('\t');
                    }
                    sw.WriteLine();
                }
            }
            Console.WriteLine("Program Run Completed.");
        }
    }
}
