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
    public partial class FormTimer : Form
    {

        private bool running = true;//0 timer stops,1 timer continue
        private int sec = 0;
        private int min = 0;
        private int hr = 0;
        //private int temp = 10;
        public FormTimer()
        {
            InitializeComponent();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.running = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string abc = this.getTimeCost();
            output("计时进行中: " + abc + " ; 当前时间:" + DateTime.Now.ToString("T"));
        }

        public bool checkLunchTime()
        {
            bool lunchtime = true;

            return lunchtime;
        }
        public string getTimeCost()
        {
            string timecost = null;
            if (running == true )
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

        private void FormTimer_Load(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {//continue
            this.running = true; ;
            //output("Start");
        }
        private void output(string x)
        {
           // textBox1.AppendText(x+"\n");
            textBox1.Text = x ;
            //if (textBox1.GetLineFromCharIndex(textBox1.Text.Length) > 15) textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.running = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.running = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
