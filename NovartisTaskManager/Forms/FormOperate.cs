using NovartisTaskManager.BusinessClass;
using NovartisTaskManager.Model;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovartisTaskManager
{
    public partial class FormOperate : Form
    {

        private DBManage dbm;
        private User u1;
        private Model.Task t1;
        private Statement st1;
 
        public FormOperate(User u)
        {
            u1 = u;
            dbm = new DBManage();
            InitializeComponent();
            this.getCurrentStatus();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Text = "请输入原因";
        }

        private void FormOperate_Load(object sender, EventArgs e)
        {

        }

        private void getCurrentStatus()
        {
            //获取当前用户信息 总任务，已完成，已退回，已质检
            label5.Text=(dbm.getUserTotoalTasks("EDITORID", u1.ID)).ToString();
            label6.Text = (dbm.getUserTasksInfo("EDITORID", u1.ID, "complete").ToString());
            label7.Text = "0";
            label9.Text = (dbm.getUserTasksInfo("EDITORID", u1.ID, "passed").ToString());

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


        private void label3_Click(object sender, EventArgs e)
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
            string copypath = dbm.applyTaskforEditor("TID");

            if (copypath == "申请失败")
            {
                MessageBox.Show("没有新任务无法申请!");
            }
            else
            {
                MessageBox.Show("已经将地址复制到剪贴板" + copypath, "申请成功！");
                dbm.updateEDITORIDtoTask(u1, copypath);
                FormTimer ftimer = new FormTimer();
                ftimer.Show();
            }
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

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.getCurrentStatus();
        }
    }
}
