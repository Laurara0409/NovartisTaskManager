using NovartisTaskManager.BusinessClass;
using System;
using System.Windows.Forms;

namespace NovartisTaskManager
{
    public partial class FormQC1 : Form
    {

        private User u1;
        private DBManage dbm;
        public FormQC1()
        {
            InitializeComponent();
            //判断用户类型 显示/隐藏 某些特殊模块
            
        }

        private void checkUserType(User u1)
        {
            switch (u1.type)
            {
                case 2:
                    //this.textBox8.Text = "部门1质检员";
                    this.label10.Text = "用户组：" + "N/A" + ", 用户名：" + u1.Name + ", 用户类型：" + "部门1质检员";
                    break;
                case 3:
                    //this.textBox8.Text = "部门2质检员";
                    this.label10.Text = "用户组：" + "N/A" + ", 用户名：" + u1.Name + ", 用户类型：" + "部门2质检员";
                    break;
                default:
                    break;
            }
        }
        public FormQC1(User u1)
        {
            this.u1 = u1;
            dbm = new DBManage();
            InitializeComponent();
            //判断用户类型 显示/隐藏 某些特殊模块
            if (u1.type != 3) this.groupBox1.Hide();
            //textBox6.Text = u1.getUserName();
            checkUserType(u1);

        }
       //申请
        private void button8_Click(object sender, EventArgs e)
        {

        }
        //提交
        private void button2_Click(object sender, EventArgs e)
        {

        }
        //通过
        private void button7_Click(object sender, EventArgs e)
        {

        }
        //退回
        private void button6_Click(object sender, EventArgs e)
        {

        }
        //暂停
        private void button1_Click(object sender, EventArgs e)
        {

        }
        //退回原因
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //暂停原因
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           // groupBox1.
        }

        private void FormQC1_Load(object sender, EventArgs e)
        {

        }

       
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            foreach(Control ctr in this.Controls)
            {
                if(ctr is RadioButton)
                {
                    RadioButton rb = ctr as RadioButton;
                    if (rb.Checked){
                        //this.label1.Text = rb.Text;
                        MessageBox.Show(rb.Text);
                        /////3.1日修改
                        }
                }
            }
        }
        private string GetRadioButton(GroupBox gb)
        {
            System.Windows.Forms.Control.ControlCollection rbColl = gb.Controls;
            foreach (Control radioButton in rbColl)
            {
                RadioButton rb = (RadioButton)radioButton;
                if (rb.Checked)
                {
                    string result = rb.Text;
                    MessageBox.Show(result);
                    return rb.Text;
                }

            }
            return null;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.GetRadioButton(groupBox1);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
        #region
        private void applyTaskbyDefault()
        {
            string date = System.DateTime.Now.ToString();

        }
        #endregion
    }
}
