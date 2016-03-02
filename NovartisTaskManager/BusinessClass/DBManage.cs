using NovartisTaskManager.BusinessClass;
using NovartisTaskManager.Model;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
// 数据库操作 ，User 表，Task表
namespace NovartisTaskManager
{
    public class DBManage

    {
        private OleDbConnection conn;
        private string constr;
        private User us;
        private Task t1;
        private DataTable dt1;
        

        public DBManage(){
            this.constr = ConfigurationManager.ConnectionStrings["dbConnection"].ToString();
            conn = new OleDbConnection(constr);
            }

        public void Close()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public void getConnection()
        {

            if (conn.State == ConnectionState.Closed) conn.Open();

        }

        #region QueryUser
        public User queryUser(string uid)
        {
            string sql = "select UID,UNAME,TYPE FROM [USER] where [UID]='" + uid + "'";
            this.getConnection();
            OleDbCommand oldbCom = new OleDbCommand(sql, conn);
            OleDbDataReader oldbReader = oldbCom.ExecuteReader();
            if (oldbReader.Read())
            {
                //us = new User(oldbReader.GetString(0), oldbReader.GetString(1), oldbReader.GetInt32(2));
                us = new User();
                us.ID = oldbReader.GetString(0);
                us.Name = oldbReader.GetString(1);
                us.type = oldbReader.GetInt32(2);
                return us;
            }
            else return null;
        }
        #endregion

        #region QueryTask
        public Task queryTaskbyPath(string tpath)// 按路径查询
        {
            string sql = "select * from [TASK] where tpath='" + tpath + "'";
            this.getConnection();
            OleDbCommand oldbCom = new OleDbCommand(sql, conn);
            OleDbDataReader oldbReader = oldbCom.ExecuteReader();
            if (oldbReader.Read())
            {
                t1 = new Task();
                this.Close();
                return t1;
            }

            else return null;
        }
        public void insertTask(string tname, string tpath)
        {
            //Task temp=this.queryTask(tpath);

            if (queryTaskbyPath(tpath) == null)
            {
                string date = System.DateTime.Now.ToString("yyyy-MM-dd");
                string sql = "insert into [TASK]([TNAME],[TPATH],[DATE]) values('" + tname + "','" + tpath + "','" + date + "')";
                this.getConnection();
                OleDbCommand oldbCom = new OleDbCommand(sql, conn);
                oldbCom.ExecuteNonQuery();
                this.Close();
            }

        }
        public void updateTask(string tpath, bool isDone)
        {
            string sql = "update";
            // insert into cxr(111, 222, 333, 444, 555) values('312312', '4332', '32132', '32132', '43242')
            this.getConnection();
            OleDbCommand oldbCom = new OleDbCommand(sql, conn);
            oldbCom.ExecuteReader();
            this.Close();
        }

        public DataTable queryTasksbyDate(string date)
        {
            string sql = "select * from TASK where DATE='" + date + "'";
            dt1 = new DataTable();
            this.getConnection();
            OleDbCommand comm = new OleDbCommand(sql, conn);
            OleDbDataReader reader = comm.ExecuteReader();
            if (reader.Read())
            {
                OleDbDataAdapter adt = new OleDbDataAdapter(sql, this.conn);
                adt.Fill(dt1);
                //adt.f
                this.Close();
                return dt1;
            }
            else
            {
                dt1 = null;
                Close();
                return dt1;
            }
        }
        #endregion

   
        public bool updateTaskCopyPath(string copypath,string publicpath)
        {
            string todaydate = System.DateTime.Now.ToString("yyyy-MM-dd");
            string realCopyPath = copypath + "\\" + todaydate;
            DirectoryInfo ctoday = new DirectoryInfo(realCopyPath);
            if (ctoday.Exists)
            {
                MessageBox.Show("exists");
                foreach (FileInfo finfo in ctoday.GetFiles()) {
                    //将新考入的文件地址更新到数据库
                    string finalcopypath = finfo.FullName;
                    string sql = "update TASK set [COPYPATH]='" + finalcopypath + "' where [Tname]='"  + finfo.Name + "' and [DATE]='"+todaydate+"'";
                    updateData(sql);
                    //MessageBox.Show(finfo.Name);// 成功
                }

            }


            return true;
        }

        public bool insertData(string str)
        {
            OleDbCommand odbc = new OleDbCommand(str, conn);
            odbc.ExecuteNonQuery();
            conn.Close();
            return true;
        }

        /// <summary>
        /// 更新数据库操作
        /// </summary>
        /// <param name="str"> SQL update语句</param>
        /// <returns></returns>
        public bool updateData(string str)
        {
            this.getConnection();
            OleDbCommand odbc = new OleDbCommand(str, conn);
            odbc.ExecuteNonQuery();
            
            conn.Close();
            return true;
        }

        public string applyTask(string conditon)
        {
            string path;
            string sql = "select TPAT from Task where complete = 'FALSE' and status='not occupied' order by'" + conditon + ",";
            OleDbCommand dbcom = new OleDbCommand(sql, conn);
            OleDbDataReader reader = dbcom.ExecuteReader();
            if (reader.Read())
            {
                path = reader.GetString(0);
                return path;
            }
            else
            {
                return "没结果";
            }
            
            
        }
        #region QC1
        int acount = 0;
        int pcount = 0;
        int bcount = 0;
        int alcount = 0;
        public int applyQC1() 
        {
            
            string sql = "select count(*) from STATEMENT where status='1'";
            OleDbCommand dbcom = new OleDbCommand(sql, conn);
            OleDbDataReader reader = dbcom.ExecuteReader();
            if(reader.Read())
            {
                acount = reader.GetInt32(0);
                alcount++;
                
            }
            return acount;
           
        }


        public int passQC1()
        {
            acount--;
            pcount++;
            return pcount;
        }
        public int backQC1()
        {
            acount--;
            bcount++;
            return bcount;
        }
        


        #endregion




    }
}
