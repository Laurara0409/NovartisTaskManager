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
    public partial class Dialog : Form
    {
        private int Total=0;
        private int Done=0;
        public Dialog()
        {
            InitializeComponent();
        }

        private void Dialog_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            this.LoadData();
        }
        private void LoadData()
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (DialogResult.OK == MessageBox.Show("AA", "BB", MessageBoxButtons.OK))
            {
                this.Hide();
            }
                
        }
    }
}
