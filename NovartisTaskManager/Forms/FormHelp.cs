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

namespace NovartisTaskManager
{
    public partial class FormHelp : Form
    {
        public FormHelp()
        {
            InitializeComponent();
            ReadTextFile(@"D:\Programming\Accenture\NovartisTaskManager\Help.txt");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void ReadTextFile(string file)
        {
            string[] lines = File.ReadAllLines(file, Encoding.GetEncoding("gb2312"));
            foreach(string line in lines)
            {
                
                TextBox1.AppendText(line + Environment.NewLine);
            }
        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
