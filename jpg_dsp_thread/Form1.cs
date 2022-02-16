using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace jpg_dsp_thread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPEGファイル|*.jpg";
            DialogResult dr = openFileDialog1.ShowDialog();

            textBox1.Text = openFileDialog1.FileName;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.ImageLocation = textBox1.Text;


            Thread t = new Thread(new ThreadStart(ThreadProc2));

            t.Start();
        }

        public void ThreadProc2()
        {

            string s = textBox1.Text;
            string s3 = "";

            s3 = System.IO.Path.GetDirectoryName(s);


            string[] files = System.IO.Directory.GetFiles(
                s3, "*.jpg", System.IO.SearchOption.AllDirectories);


            try
            {
                foreach (string file in files)
                {

                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.ImageLocation = file;

                    Thread.Sleep(1000);
                }

            }
            catch (Exception a)
            {
                Console.WriteLine(a.ToString());
            }
        }

    }
}