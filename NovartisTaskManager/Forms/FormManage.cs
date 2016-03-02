using System;
using System.IO;
using System.Windows.Forms;
using NovartisTaskManager.BusinessClass;
using System.Data;
using System.Configuration;


/*
 数据是以TPATH为主键的，不同日期存入相同文件是不可以的。
 刷新按钮只能查询当天的任务。
*/

namespace NovartisTaskManager
{
    public partial class FormManage : Form
    {

        private User user;
        private DBManage dbm;
        private DataTable dt;

        #region Parameters
        public FormManage(User u)
        {
            this.user = u;
            InitializeComponent();
            initialUSer();

            dbm = new DBManage();
        }
        /// <summary>
        /// 初始化用户信息
        /// </summary>
         private void initialUSer()
        {

            switch (user.type)
            {
                case 0:
                    string type = "业务员";
                    this.label3.Text = "用户组：" + "N/A" + ",用户名：" + user.Name + ",用户类型：" + type;
                    break;
                case 1:
                    string type1 = "负责人";
                    this.label3.Text = "用户组：" + "N/A" + ",用户名：" + user.Name + ",用户类型：" + type1;
                    break;
                default:
                    break;
            }
        }
        #endregion
        #region Functions
         private void CopyDirectory(string srcdir, string desdir)
         {
             string folderName = srcdir.Substring(srcdir.LastIndexOf("\\") + 1);//截取文件夹文件名
             
             string desfolderdir = desdir + "\\" + folderName;//设置目标文件夹目录
             if (desdir.LastIndexOf("\\") == (desdir.Length - 1))//如果最后的\ 是最后的字符
             { //就把文件夹名放到目标地址后面
                 desfolderdir = desdir + folderName; 
             }
            else{
                desfolderdir = desdir + "\\" + folderName;
            }
             string[] filenames = Directory.GetFileSystemEntries(srcdir);
             foreach (string file in filenames)// 遍历所有的文件和目录        
             {
                 if (Directory.Exists(file))// 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件            
                 {
                     string currentdir = desfolderdir + "\\" + file.Substring(file.LastIndexOf("\\") + 1);
                     if (!Directory.Exists(currentdir))
                     {
                         Directory.CreateDirectory(currentdir);
                     }
                     CopyDirectory(file, desfolderdir);//如果内部嵌套文件夹，递归
                }
                 else // 否则直接copy文件             
                 {
                     string srcfileName = file.Substring(file.LastIndexOf("\\") + 1);
                     srcfileName = desfolderdir + "\\" + srcfileName;
                     if (!Directory.Exists(desfolderdir))
                     {
                         Directory.CreateDirectory(desfolderdir);
                     }
                    if (File.Exists(srcfileName)) { 
                         File.Copy(file, srcfileName);
                    }
                }
             }//foreach       
         }
        /// <summary>
        /// 存放到以今天时间命名的文件夹下面
        /// </summary>
        /// <param name="srcdir">源文件路径</param>
         private void copytoTodayFolder(string srcdir,string desdir)
         {
             string today = System.DateTime.Now.ToString("yyyy-MM-dd");
            //string foldername = resdir.Substring(resdir.IndexOf("\\") + 1);
            string realDesDir = null;
            if (desdir.LastIndexOf("\\")==desdir.Length-1){

                realDesDir = desdir + today;

            }
            else
            {
                realDesDir = desdir + "\\" + today;
                
            }
            string[] filenames = Directory.GetFileSystemEntries(srcdir);
            foreach (string file in filenames)// 遍历所有的文件和目录        
            {
                if (Directory.Exists(file))// 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件            
                {
                    
                    string currentdir = realDesDir+ "\\" + file.Substring(file.LastIndexOf("\\") + 1);
                    if (!Directory.Exists(currentdir))
                    {
                        Directory.CreateDirectory(currentdir);
                    }
                    copytoTodayFolder(file, realDesDir);//如果内部嵌套文件夹，递归
                }
                else // 否则直接copy文件             
                {
                    string srcfileName = file.Substring(file.LastIndexOf("\\") + 1);
                    srcfileName = realDesDir+ "\\" + srcfileName;
                    if (!Directory.Exists(realDesDir))
                    {
                        Directory.CreateDirectory(realDesDir);
                    }

                    if (!File.Exists(srcfileName))
                    {
                        File.Copy(file, srcfileName);
                    }
            }
            }//foreach   
        }
        public void updateDataGrid()//查询当天所有文件
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            
            Object obj = new Object();
            obj = dbm.queryTasksbyDate(date);
            if (obj != null)
            {
                this.dt = dbm.queryTasksbyDate(date);
                this.dataGridView1.DataSource = dt;
                
            }
            else MessageBox.Show("无任何内容","警告");
            this.label5.Text = (dbm.countTasksbyDate(date)).ToString();
            this.label7.Text = dbm.countStatusTask("complete", date).ToString();
            this.label9.Text = dbm.countStatusTask("passed", date).ToString();

        }
        public void getTasksFromFolder(string url)
        {
            //打开指定url 文件夹，将文件信息导入到数据库
        }
        public void getTasksInfo(string sql)
        {
            //将导入到数据库后的信息 读取到datagridviewer 
        }
        private int GetTaskType(ref string FolderName)
        {
            string Fletter = FolderName.Substring(0, 1);
            int Res;
            //Check The Normal Task
            if (int.TryParse(Fletter, out Res))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        #endregion
        #region Events
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void FormManage_Load(object sender, EventArgs e)
        {

        }




        private void timer1_Tick(object sender, EventArgs e)//每分钟更新数据表
        {
            this.updateDataGrid();

        }



        /// <summary>        /// 拷贝文件夹        /// </summary>       
        ///  /// <param name="srcdir"></param>       
        ///  /// <param name="desdir"></param>       

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }//function end
        //导入文件夹信息到列表
        private void button1_Click(object sender, EventArgs e)
        {

            string path = this.textBox1.Text;
            //dbm = new DBManage();
            if (path == String.Empty)
            {
                MessageBox.Show("输入非法", "警告");
                textBox1.Focus();
            }
            else
            {
                DirectoryInfo folder = new DirectoryInfo(path);
                //List<Task> FileList = new List<Task>();
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                string copypath = ConfigurationManager.ConnectionStrings["copypath"].ToString();
                DirectoryInfo c2 = new DirectoryInfo(copypath);
                if (folder.Exists && c2.Exists)
                {

                    this.copytoTodayFolder(path, copypath);
                    //将子文件复制到“copypath"文件夹(directory)内的以当体日期（yyyy-MM-dd)命名的文件夹内

                    foreach (FileInfo files in folder.GetFiles())//获取子文件列表
                    {
                        dbm.insertTask(files.Name, files.FullName);//将每一条数据插入到数据库中

                    }
                    dbm.updateTaskCopyPath(copypath, path);

                    MessageBox.Show("复制成功,保存路径：" + copypath);
                    this.updateDataGrid();
                }
                else
                {
                    MessageBox.Show("路径不存在", "错误");
                    textBox1.Focus();
                }
            }

        }
        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int rowindes = e.RowIndex;
            int columindex = e.ColumnIndex;
            string cotent = this.dataGridView1.Rows[rowindes].Cells[columindex].Value.ToString();
            if (cotent != string.Empty)
            {
                Clipboard.SetDataObject(cotent);
                MessageBox.Show("已复制地址到剪贴板");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.updateDataGrid();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
