namespace FileTransfer
{

    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Security;
    using System.Windows.Forms;
    using static System.Runtime.InteropServices.JavaScript.JSType;


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string fileContent;

        public void GetFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.InitialDirectory = "C:\\Users\\2400328\\Desktop\\轉檔程式練習";

            openFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";


            if (openFile.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                //var filePath = openFile.SafeFileName; // 檔名 + 副檔名
                //var filePath = openFile.FileName; // 路徑 + 檔名 + 副檔名


                //Read the contents of the file into a stream

                var fileStream = openFile.OpenFile();

                StreamReader reader = new StreamReader(fileStream);

                fileContent = reader.ReadToEnd(); 
            }
        }

        

        private void Transfer_Click(object sender, EventArgs e)
        {
            if (fileContent != null)
            {
                MessageBox.Show(fileContent);

                int[] value = new int[] { 8, 6, 1, 4, 9, 10, 3, 1, 3, 4, 3, 1, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 10, 8, 2 };

                string[,] Info = new string[fileContent.Length / value.Sum(), value.Length];

                int num = 0;

                try
                {
                    for (int i = 0; i < fileContent.Length; i = i + value.Sum() + 2) //+2 -> "\r\n"
                    {
                        string Data = fileContent.Substring(i, value.Sum() + 2);

                        //MessageBox.Show(Data);

                        int index = 0;

                        for (int j = 0; j < value.Length; j++)
                        {
                            Info[num, j] = Data.Substring(index, value[j]);

                            index += value[j];

                        }   num++;
                    }
                    MessageBox.Show(Info.ToString());
                }

                catch (ArgumentOutOfRangeException error)
                {
                    Console.WriteLine(error.Message);

                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("請先選取一個檔案！");
            }
        }



        private void Finish_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
