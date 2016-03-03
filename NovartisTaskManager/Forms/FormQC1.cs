using NovartisTaskManager.BusinessClass;
using System;
using System.Windows.Forms;

namespace NovartisTaskManager
{
    public partial class FormQC1 : Form
    {

        private User u1;
        private DBManage dbm;
        //private Timer t1;
        public FormQC1()
        {
            InitializeComponent();
            //判断用户类型 显示/隐藏 某些特殊模块
            
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
        private void getCurrentStatus()
        {
            //获取当前用户信息 总任务，已完成，已退回，已质检
            label11.Text = (dbm.getUserTotoalTasks("QCID", u1.ID)).ToString();
            label13.Text = (dbm.getUserTasksInfo("QCID", u1.ID, "complete").ToString());
            label15.Text = (dbm.getUserTasksInfo("QCID", u1.ID, "passed").ToString());
            label17.Text = (dbm.getUserTasksInfo("EDITORID", u1.ID, "notpassed").ToString());

        }
        //申请
        private void button8_Click(object sender, EventArgs e)
        {
            
            string copypath = dbm.applyTaskforQC("TID");//查询需要质检的文件路径
            if (copypath == "申请失败")
            {
                MessageBox.Show("没有任务需要质检，无法申请!");
            }
            else
            {
                MessageBox.Show("已经将地址复制到剪贴板" + copypath, "申请成功！");
                dbm.updateQCIDtoTask(u1, copypath);
                label1.Text = "计时开始";
                resetTimer();
                timer2.Enabled = true;
            }
        }
        private void resetTimer()
        {
            this.sec = 0;
            this.min = 0;
            this.hr = 0;
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
        private int sec = 0, min = 0, hr = 0;
        public string getTimeRunning()
        {
            string timecost = null;
            if (this.timer2.Enabled == true)
            {
                sec++;
                if (sec == 60)
                {
                    sec = 0;
                    min += 1;
                }
                if (min == 60)
                {
                    hr += 1;
                    min = 0;
                }

            }
            timecost = hr + ":" + min + ":" + sec;
            return timecost;
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
        //流转
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        //完成
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
        //User
        private void label10_Click(object sender, EventArgs e)
        {

        }
        //总任务
        private void label11_Click(object sender, EventArgs e)
        {

        }
        //已质检
        private void label13_Click(object sender, EventArgs e)
        {

        }
        //质检通过
        private void label15_Click(object sender, EventArgs e)
        {

        }
        //质检未通过
        private void label17_Click(object sender, EventArgs e)
        {

        }

        #region
        private void applyTaskbyDefault()
        {
            string date = System.DateTime.Now.ToString();

        }
        #endregion

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer2.Enabled = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            timer2.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.getCurrentStatus();
        }
        public bool checkLunchTime()
        {
            bool lunchtime = true;

            return lunchtime;
        }
        //public string getTimeCost()
        //{
        //    t1 = new BusinessClass.Timer();
        //    return null;
        //}
    }
}
