using System;
using System.Windows.Forms;
using NovartisTaskManager.BusinessClass;

namespace NovartisTaskManager
{
    public partial class FormLogin : Form
    {

        private DBManage dbm;
        private User u1;

        public FormLogin()
        {
            InitializeComponent();
            dbm = new DBManage();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            dbm.getConnection();
            if (this.textBox1.Text == null)
            {
                MessageBox.Show("Account is not valid");
                return;
            }

            if (CheckLogin())
            {
  
                int usertype = u1.type;
                switch (usertype)
                {
                    case 0:
                        FormOperate fo = new FormOperate(u1);
                        fo.Show();
                        break;
                    case 1:
                        FormManage fm = new FormManage(u1);
                        fm.Show();
                        break;
                    case 2:
                        FormQC1 fmq = new FormQC1(u1);
                        fmq.Show();
                        break;
                    case 3:
                        FormQC1 fmq2 = new FormQC1(u1);
                        fmq2.Show();
                        break;
                    default:
                        FormApplyTask fat1 = new FormApplyTask();
                        fat1.Show();
                        break;
                }

                this.Hide();
            }
            else
            {
                
            }
            
        }

        private bool CheckLogin()

        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Input is not valid");
                return false;
            }
            else
            {
                dbm.getConnection();
                u1 = dbm.queryUser(this.textBox1.Text);
                if (u1 != null)
                {
                    dbm.Close();
                    return true;

                }
                else
                {
                    MessageBox.Show("用户不存在", "Warning", MessageBoxButtons.OK);
                    
                    textBox1.Text = String.Empty;
                    return false;
                }
                   


            }
        }


        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { 
            this.button1_Click(sender, e);
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormHelp f1 = new FormHelp();
            f1.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            dbm.getConnection();
            if (this.textBox1.Text == null)
            {
                MessageBox.Show("Account is not valid");
                return;
            }

            if (CheckLogin())
            {

                int usertype = u1.type;
                switch (usertype)
                {
                    case 0:
                        FormOperate fo = new FormOperate(u1);
                        fo.Show();
                        break;
                    case 1:
                        FormManage fm = new FormManage(u1);
                        fm.Show();
                        break;
                    case 2:
                        FormQC1 fmq = new FormQC1(u1);
                        fmq.Show();
                        break;
                    case 3:
                        FormQC1 fmq2 = new FormQC1(u1);
                        fmq2.Show();
                        break;
                    default:
                        FormApplyTask fat1 = new FormApplyTask();
                        fat1.Show();
                        break;
                }

                this.Hide();
            }
            else
            {

            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
