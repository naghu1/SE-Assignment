using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;


namespace WindowsFormsApp1
{
    class Calculation
    {
        double result;
        //calculate method which performs mathmetical operations
        public void calculate(string filePath)
        {



            string[] fileEntries = Directory.GetFiles(filePath);
            string newCalcFile = filePath + "\\answer.answ";
            StreamWriter sw = File.CreateText(newCalcFile);
            for (int i = 0; i < fileEntries.Length; i++)
            {

                //Only .calc files are retreived
                if (Path.GetExtension(fileEntries[i]) == ".calc")
                {
                    string[] calcwords = File.ReadAllLines(fileEntries[i]);

                    foreach (string Calcword in calcwords)
                    {
                        String pattern = @"(\d+)+([-+*/])+(\d+)";

                        foreach (Match m in Regex.Matches(Calcword, pattern))
                        {
                            double value1 = Int32.Parse(m.Groups[1].Value);
                            double value2 = Int32.Parse(m.Groups[3].Value);
                            switch (m.Groups[2].Value)
                            {
                                case "+":
                                    result = value1 + value2;
                                    break;
                                case "-":
                                    result = value1 - value2;
                                    break;
                                case "*":
                                    result = value1 * value2;
                                    break;
                                case "/":
                                    result = value1 / value2;
                                    break;
                                case "^":
                                    result = Math.Pow(value1, value2);
                                    break;
                            }
                            sw.WriteLine(Calcword + "=" + result);


                        }
                    }
                    
                }


            }
            sw.Close();
        }
    }
}
