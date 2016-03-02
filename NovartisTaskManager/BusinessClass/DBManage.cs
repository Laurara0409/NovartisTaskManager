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
        private Statement st1;
        

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="userrole"> VALUE=EDITORIDorQCID</param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int getUserTasksInfo(string userrole, string uid, string status)
        {
            int res = 0;
            string sql = "select COUNT(*) from TASK where " + userrole + "='" + uid + "' and status ='" + status + "'";
            getConnection();
            OleDbCommand com = new OleDbCommand(sql, conn);
            OleDbDataReader reader = com.ExecuteReader();
            if (reader.Read()) {
                res = reader.GetInt32(0);
                return res;
            }


            return res;
        }
        public int getUserTotoalTasks(string userrole, string uid)
        {
            int res = 0;
            string sql = "select COUNT(*) from TASK where " + userrole + "='" + uid + "'" ;
            getConnection();
            OleDbCommand com = new OleDbCommand(sql, conn);
            OleDbDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                res = reader.GetInt32(0);
                reader.Close();
                conn.Close();
                return res;
            }


            return res;
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
        public void updateEDITORIDtoTask(User U,string path)
        {
            string sql = "update Task set EDITORID ='" + U.ID + "' where COPYPATH='" + path + "'";
            getConnection();
            OleDbCommand dbcom = new OleDbCommand(sql, conn);
            dbcom.ExecuteNonQuery();
        }
        public void updateQCIDtoTask(User U, string path)
        {
            string sql = "update Task set QCID ='" + U.ID + "' where COPYPATH='" + path + "'";
            getConnection();
            OleDbCommand dbcom = new OleDbCommand(sql, conn);
            dbcom.ExecuteNonQuery();
        }
        public string applyTaskforEditor(string conditon)
        {
            string path;
            string sql = "select TOP 1 COPYPATH from Task where status is NULL order by'" + conditon + "'";
            this.getConnection();
            OleDbCommand dbcom = new OleDbCommand(sql, conn);
            OleDbDataReader reader = dbcom.ExecuteReader();
            if (reader.Read())
            {
                path = reader.GetString(0);
                Clipboard.SetDataObject(path);
                updateTaskStatus(path, "occupied");
                conn.Close();
                return path;
            }
            else
            {
                return "申请失败";
            }


        }
        public string applyTaskforQC(string conditon)
        {
            string path;
            string sql = "select TOP 1 COPYPATH from Task where status = 'complete' order by'" + conditon + "'";
            this.getConnection();
            OleDbCommand dbcom = new OleDbCommand(sql, conn);
            OleDbDataReader reader = dbcom.ExecuteReader();
            if (reader.Read())
            {
                path = reader.GetString(0);
                Clipboard.SetDataObject(path);
                updateTaskStatus(path, "occupied");
                conn.Close();
                return path;
            }
            else
            {
                return "申请失败";
            }


        }

        private void updateTaskStatus(string path,string status)
        {
            string sql = "update TASK set STATUS = '" + status + "' where COPYPATH='" + path + "'";
            this.getConnection();
            OleDbCommand comm = new OleDbCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();

        }
        public int countTasksbyDate(string date)
        {
            int count = 0;
            string sql = "select COUNT(TID) from TASK where DATE='" + date + "'";
            this.getConnection();
            OleDbCommand oldcom = new OleDbCommand(sql, conn);
            OleDbDataReader reader = oldcom.ExecuteReader();
            if (reader.Read())
            {
                count = reader.GetInt32(0);
                reader.Close();
                conn.Close();
            }
            return count;
        }/// <summary>
         /// 计算已经完成，或者通过质检的当日任务数量
         /// </summary>
         /// <param name="status">为空，complete,passed,occupied</param>
         /// <returns></returns>
        public int countStatusTask(string status,string date)

        {
            int count = 0;
            string sql = "select COUNT(TID) from TASK where DATE='" + date + "' and STATUS = '"+status+"'";
            this.getConnection();
            OleDbCommand oldcom = new OleDbCommand(sql, conn);
            OleDbDataReader reader = oldcom.ExecuteReader();
            if (reader.Read())
            {
                count = reader.GetInt32(0);
                reader.Close();
                conn.Close();
            }
            return count;
        }

       


    }
}
