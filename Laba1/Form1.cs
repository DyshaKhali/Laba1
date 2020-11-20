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
using System.Diagnostics;

namespace Laba1
{
    public partial class Array : Form

    {
        int[] array1;
        int[,] array2;
        readonly string mydocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        FileStream file = null;

        public Array()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool parsed = int.TryParse(textBox1.Text, out int range);
            Random rand = new Random();

            if (parsed)
            {
                textBox4.Text = "";
                array1 = new int[range];
                for (int i = 0; i < range; i++)
                {
                    array1[i] = rand.Next(10);
                    textBox4.Text += $"[{array1[i]}] ";
                }
            }
            else
            {
                MessageBox.Show($"{textBox1.Text} - не является допустимым значением");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            array1 = null;
            textBox4.Text = "Массив очищен";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool parsedX = int.TryParse(textBox2.Text, out int rangeX);
            bool parsedY = int.TryParse(textBox3.Text, out int rangeY);
            Random rand = new Random();

            file = new FileStream(mydocs + @"\Array2.txt", FileMode.OpenOrCreate);

            if (parsedX && parsedY)
            {
                file.SetLength(0);
                //string[] tempString = new string[rangeX];

                array2 = new int[rangeX, rangeY];

                for (int i = 0; i < rangeX; i++)
                {
                    string tempString = "";
                    for (int j = 0; j < rangeY; j++)
                    {
                        array2[i, j] = rand.Next(10);
                        tempString += $"[{array2[i, j]}] ";
                    }
                    tempString += "\n";
                    byte[] tempBytes = Encoding.Default.GetBytes(tempString);
                    file.Write(tempBytes, 0, tempBytes.Length);

                }

                Process.Start(mydocs + @"\Array2.txt");

            }
            else
            {
                MessageBox.Show("не являются допустимыми значениями");
            }

            if (file != null)
                file.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            file = new FileStream(mydocs + @"\Array2.txt", FileMode.OpenOrCreate);
            file.SetLength(0);
            array2 = null;
            Process.Start(mydocs + @"\Array2.txt");
            if (file != null)
                file.Close();
        }
    }
}
