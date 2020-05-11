using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordFrequency
{
    public partial class Form1 : Form
    {
        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                string fileText = "";
                string lowercaseFileText = "";

                StreamReader inputFile;

                if(openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    inputFile = File.OpenText(openFileDialog1.FileName);

                    while (!inputFile.EndOfStream)
                    {
                        fileText = inputFile.ReadLine();
                    }
                    inputFile.Close();

                    lowercaseFileText = fileText.ToLower();
                    string[] tokens = lowercaseFileText.Split(new char[] {' ', '.', ','});

                    foreach (string s in tokens)
                    {
                        for (int i = 0; i < tokens.Length; i++)
                        {
                            if (s == tokens[i])
                            {
                                wordCount.Add(s, +1);
                            }
                        }
                    }


                    //for (int i = 0; i<tokens.Length; i++)
                    //{
                    //    foreach(string s in tokens)
                    //    {
                    //        if (s == tokens[i])
                    //        {
                    //            wordCount.Add(s, +1);
                    //        }
                    //    }
                    //}


                } else
                {
                    MessageBox.Show("Operation cancelled.");
                }
                
            }
            catch
            {

            }
        }
    }
}
