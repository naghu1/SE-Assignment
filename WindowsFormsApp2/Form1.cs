using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
        List<string> allDirectories = new List<string>();
        List<string> sortedFiles = new List<string>();

        public Form1()
		{
			InitializeComponent();

		}
		private void button1_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog FolderBrowserDialog = new FolderBrowserDialog();
			string startfile = string.Empty;
			string[] filePaths = { "" };

			if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				startfile = FolderBrowserDialog.SelectedPath;
				filePaths = Directory.GetFiles(FolderBrowserDialog.SelectedPath);
				MessageBox.Show(startfile);
			}
			char[] splitting = { ' ', '.' };
			foreach (string filename in filePaths)
			{
				StreamReader file1 = new StreamReader(filename);
				string[] list = new string[15];
				string s;            

				s = file1.ReadToEnd();
				list = s.Split(splitting);
				Array.Sort(list);
					

				string file = Path.GetFileName(filename);
				string str = startfile + "\\sorted" + file.ToString();

				string extension = Path.GetExtension(filename);
				if (extension == ".txt")
				{

					if (!File.Exists(str))
					{
						File.Copy(filename, str);
					}
				}
                 file1.Close();



                var dict = new Dictionary<string, int>();
                //count number of occurences of string
                foreach (var word in list)
                {
                    if (dict.ContainsKey(word))
                        dict[word]++;
                    else
                        dict[word] = 1;
                }


                for (int index = 0; index < dict.Count; index++)
                {
                    var item = dict.ElementAt(index);
                    string itemKey = item.Key;
                    int itemValue = item.Value;

                    using (StreamWriter sw = new StreamWriter(str))
                    {
                        /**
                        foreach (string x in list)
                        {sw.WriteLine(x);
                            Console.WriteLine(x);
                        }**/
                        foreach (var pair in dict)
                        {
                            if (!string.IsNullOrEmpty(item.Key))
                            {
                                sw.WriteLine("{0}{1}{2}", pair.Key, ",", pair.Value);
                            }
                        }
                        sw.Close();
                    }
                }
               
                //Adding all sorted files
                sortedFiles.Add("sorted"+file);


			}
			//Adding all the directories to list
			allDirectories.Add(startfile);

		}



		private void button3_Click(object sender, EventArgs e)
        {
            //Iterating list and displaying on text area
            string line = string.Empty;
            foreach (var directories in allDirectories) {
                line = line +Environment.NewLine+directories;
            }
            //Displaying in text Area
            textBox5.Text = line;
        }

        private void button4_Click(object sender, EventArgs e)
        {
			        
			//Iterating list and displaying on text area
            string line = string.Empty;
            foreach (var sortedFile in sortedFiles)
            {
                line = line + Environment.NewLine + sortedFile;
            }
            //Displaying in text Area
            textBox5.Text = line;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog file = new FolderBrowserDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                string strfoldername = file.SelectedPath;
                Calculation calc = new Calculation();
                calc.calculate(strfoldername);

            }

        }
    }

	}