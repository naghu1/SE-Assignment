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

				using (StreamWriter sw = new StreamWriter(str))
				{
					foreach (string x in list)
					{sw.WriteLine(x);
						Console.WriteLine(x);
					}
					sw.Close();
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			
		}
	}
}