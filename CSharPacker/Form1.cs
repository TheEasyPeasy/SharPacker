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

namespace CSharPacker
{
    public partial class Form1 : Form
    {
    public Form1()
        {
            InitializeComponent();
            this.Text = "SharPacker 1.0";
        }

        private void inputButton_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                inputPath.Text = openFileDialog.FileName;
            }
        }

        private void outputButton_Click(object sender, EventArgs e)
        {
            if(saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                outputPath.Text = saveFileDialog.FileName;
            }
        }

        private void packButton_Click(object sender, EventArgs e)
        {
            if(inputPath.Text == "(none)")
            {
                MessageBox.Show("Please choose input file!");
                return;
            }
            if (outputPath.Text == "(none)")
            {
                MessageBox.Show("Please choose input file!");
                return;
            }
            try
            {
                File.WriteAllBytes(outputPath.Text, PackerControl.Pack(outputPath.Text, inputPath.Text, "ABCDEFGHIJKLMNP", erasesections.Checked, antidebuggers.Checked));
                MessageBox.Show("Successful packaging input file!");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Something went wrong... " + exception.Message);
            }
        }
    }
}
