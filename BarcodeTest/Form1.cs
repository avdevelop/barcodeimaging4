using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BarcodeTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnScanCSharp_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && (!String.IsNullOrEmpty(openFileDialog1.FileName)))
            {
                pictureBox1.Image = Bitmap.FromFile(openFileDialog1.FileName);

                List<string> barCodes = BarcodeImaging.FullScanPage(new Bitmap(Bitmap.FromFile(openFileDialog1.FileName)), 100);

                StringWriter message = new StringWriter();

                foreach(String code in barCodes)
                {
                    message.WriteLine(code);
                }

                MessageBox.Show(message.ToString());
            }
        }
    }
}
