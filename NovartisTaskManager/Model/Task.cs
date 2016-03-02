using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovartisTaskManager.Model
{
    public class Task
    {
        public string tid, tname, tpath,copypath;
        public bool isDone;

        public Task() { }
        public Task(string tname, string tpath, bool done)
        {
            
            this.tname = tname;
            this.tpath = tpath;
            this.isDone = done;

        }
        public Task(string id, string tname, string tpath, bool done)
        {
            this.tid = id;
            this.tname = tname;
            this.tpath = tpath;
            this.isDone = done;
        }
        //public string TaskName
        //{
        //    get {
        //       return  TaskName ;
        //            }
        //    set
        //    {
        //        TaskName = tname;
        //    }
        //}
        //public string TaskPath
        //{
        //    get
        //    {
        //        return TaskPath;
        //    }
        //    set
        //    {
        //        TaskPath = tpath;
        //    }
        //}

    }
}
