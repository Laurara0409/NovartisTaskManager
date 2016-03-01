using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovartisTaskManager
{
    public partial class FormApplyTask : Form
    {
        public FormApplyTask()
        {
            InitializeComponent();
        }

        private void FormApplyTask_Load(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            FormTimer ftimer = new FormTimer();
            ftimer.Show();
            // 管理数据库 Statement 
        }
    }
}
