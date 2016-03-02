using System;
using System.IO;
using System.Windows.Forms;

namespace NovartisTaskManager.Forms
{
    public partial class FormCopyFiles : Form
    {
        public FormCopyFiles()
        {
            InitializeComponent();
        }

        private void FormCopyFiles_Load(object sender, EventArgs e)
        {
            
        }

        private string getURL()//获取路径
        {
            string url = this.textBox1.Text;
            //if (url != string.Empty)
            //{
                return url;
            // }
            //else
            //{
            //    MessageBox.Show("URL 非法或不存在");
            //    textBox1.Clear();
            //    return getURL();
            //}
        }
        private bool checkPath(string url)
        {

            if (url != string.Empty)
            {
                DirectoryInfo folder = new DirectoryInfo(url);
                if (folder.Exists)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("路径不存在");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("URL 为空");
                textBox1.Focus();
                return false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.checkPath(this.getURL()))
            {
                //复制任务到当前directory
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
