using NovartisTaskManager.BusinessClass;
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
    public partial class FormOperate : Form
    {

        private DBManage dbm;
        private User u1;
 
        public FormOperate(User u)
        {
            InitializeComponent();

            //this.textBox6.Text = u.getUserName();
            switch (u.type)
            {
                case 0:
                    string utype = "业务员";
                    //this.textBox7.Text = "业务员";
                    this.label8.Text = "用户组：" + "N/A" + ", 用户名：" + u.Name + ", 用户类型：" + utype;
                    break;
                case 1:
                    string utype1 = "负责人";
                    //this.textBox7.Text = "负责人";
                    this.label8.Text = "用户组：" + "N/A" + ", 用户名：" + u.Name + ", 用户类型：" + utype1;
                    break;
                default:
                    break;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //查询文件路径，显示文件路径，更新TASK 数据库

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Text = "请输入原因";
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FormOperate_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void getCurrentStatus(User U)
        {
            //获取当前用户信息 总任务，已完成，已退回，已质检
        }

        private void button2_Click(object sender, EventArgs e)//完成任务
        {
            //更新当前打开文件的数据库信息 
            // 调取 getCurrentStatus（U） 方法，更新用户信息
        }

        private void button3_Click(object sender, EventArgs e)//退回按钮
        {
            //更新当前文件数据库
            //调取 getCurrentStatus（U） 方法，更新用户信息
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //暂停计时器

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //dbm.applyTask("排序条件");//查询任务 显示任务路径
            //FormTimer ftimer = new FormTimer();//计时器开始计时
            FormTimer ftimer = new FormTimer();
            ftimer.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
        private void finishTask(string TID) {
            //更新任务数据库信息
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
        private void retreatTask(string tid)
        {
            // 退回当前任务，更新数据库信息
        }
    }
}
