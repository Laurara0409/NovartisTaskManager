using NovartisTaskManager.BusinessClass;
using System;
using System.Windows.Forms;

namespace NovartisTaskManager
{
    public partial class FormQC1 : Form
    {

        private User u1;
        private DBManage dbm;

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
            dbm.getConnection();
            int count = dbm.applyQC1();
            this.label11.Text=count.ToString();
            MessageBox.Show("申请成功");
        }

        //通过
        private void button7_Click_1(object sender, EventArgs e)
        {
            //设置QCSTATUS=1,质检通过count+1显示在label15,标记为已经操作完成还是需要流转到下一个组
            if (radioButton1.Checked == true && radioButton2.Checked == false)
            {
                //存到2组文件夹

            }
            else if (radioButton1.Checked == false && radioButton2.Checked == true)
            {
                //完成，

            }
            else MessageBox.Show("请选择通过方式");

            dbm.getConnection();
            int count = dbm.passQC1();
            this.label15.Text = count.ToString();
            MessageBox.Show("已通过");
            
        }
        //退回
        private void button6_Click(object sender, EventArgs e)
        {
            //设置QCSTATUS=2,质检未通过count+1显示在label17,打回给操作者本人，并附上未通过原因
            dbm.getConnection();
            int count = dbm.backQC1();
            this.label17.Text = count.ToString();
            MessageBox.Show("已退回");
        }
        //暂停
        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        //退回原因
        private void textBox1_Enter(object sender, EventArgs e)
        {
            this.textBox1.Text = string.Empty;
        } 
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            //读出textbox的内容，退回原因存入数据库？？？
            string backreason = textBox1.Text;

        }
        //暂停原因
        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            //读出textbox的内容，暂停原因存入数据库？？？
            string pausereason = textBox2.Text;
        }
        private void groupBox1_Enter_1(object sender, EventArgs e)
        {
        }
        private void FormQC1_Load(object sender, EventArgs e)
        {

        }
  
        //private string GetRadioButton(GroupBox gb)
        //{
        //    System.Windows.Forms.Control.ControlCollection rbColl = gb.Controls;
        //    foreach (Control radioButton in rbColl)
        //    {
        //        RadioButton rb = (RadioButton)radioButton;
        //        if (rb.Checked)
        //        {
        //            string result = rb.Text;
        //            MessageBox.Show(result);
        //            return rb.Text;
        //        }

        //    }
        //    return null;
        //}
        //流转
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }
        //完成
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
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
