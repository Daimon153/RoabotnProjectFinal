using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roabotn.Model
{
    public partial class Worker
    {
        Core db = new Core();
        public int CountFailedTask
        {
            get
            {
                return db.context.TaskWorker.Where(x => x.IdWorker == IdWorker && x.Tasks.TaskStatus2.IdTaskStatus == 3).Count();

            }
        }
        public int CountFailedTaskMounth
        {
            get
            {
                int result = 0;
                foreach (var item in db.context.TaskWorker.ToList())
                {
                    int mounth = Convert.ToDateTime(item.Tasks.EndTime).Month;
                    int year = Convert.ToDateTime(item.Tasks.EndTime).Year;

                    if (item.IdWorker == IdWorker && item.Tasks.TaskStatus2.IdTaskStatus == 3 && mounth == DateTime.Now.Month && year == DateTime.Now.Year)
                    {
                        result++;

                    }
                }
                return result;

            }
        }
        public int CountFailedTaskYear
        {
            get
            {
                int result = 0;
                foreach (var item in db.context.TaskWorker.ToList())
                {
                    int years = Convert.ToDateTime(item.Tasks.EndTime).Year;

                    if (item.IdWorker == IdWorker && item.Tasks.TaskStatus2.IdTaskStatus == 3 && years == DateTime.Now.Year)
                    {
                        result++;

                    }
                }
                return result;

            }
        }
        public int CountForthcomingTask
        {
            get
            {
                return db.context.TaskWorker.Where(x => x.IdWorker == IdWorker && x.Tasks.TaskStatus2.IdTaskStatus == 2).Count();

            }
        }
        public int CountForthcomingTaskMounth
        {
            get
            {
                int result = 0;
                foreach (var item in db.context.TaskWorker.ToList())
                {
                    int mounth = Convert.ToDateTime(item.Tasks.EndTime).Month;
                    int year = Convert.ToDateTime(item.Tasks.EndTime).Year;

                    if (item.IdWorker == IdWorker && item.Tasks.TaskStatus2.IdTaskStatus == 2 && mounth == DateTime.Now.Month && year == DateTime.Now.Year)
                    {
                        result++;

                    }
                }
                return result;

            }
        }
        public int CountForthcomingTaskYear
        {
            get
            {
                int result = 0;
                foreach (var item in db.context.TaskWorker.ToList())
                {
                    int years = Convert.ToDateTime(item.Tasks.EndTime).Year;

                    if (item.IdWorker == IdWorker && item.Tasks.TaskStatus2.IdTaskStatus == 2 && years == DateTime.Now.Year)
                    {
                        result++;

                    }
                }
                return result;

            }
        }
        public int CountCompleteTask
        {
            get
            {
                return db.context.TaskWorker.Where(x => x.IdWorker == IdWorker && x.Tasks.TaskStatus2.IdTaskStatus == 1).Count();

            }
        }
        public int CountCompleteTaskMounth
        {
            get
            {
                int result = 0;
                foreach (var item in db.context.TaskWorker.ToList())
                {
                    int mounth = Convert.ToDateTime(item.Tasks.EndTime).Month;
                    int year = Convert.ToDateTime(item.Tasks.EndTime).Year;

                    if (item.IdWorker == IdWorker && item.Tasks.TaskStatus2.IdTaskStatus == 1 && mounth == DateTime.Now.Month && year == DateTime.Now.Year)
                    {
                        result++;

                    }
                }
                return result;

            }
        }
        public int CountCompleteTaskYear
        {
            get
            {
                int result = 0;
                foreach (var item in db.context.TaskWorker.ToList())
                {
                    int years = Convert.ToDateTime(item.Tasks.EndTime).Year;

                    if (item.IdWorker == IdWorker && item.Tasks.TaskStatus2.IdTaskStatus == 1 && years == DateTime.Now.Year)
                    {
                        result++;

                    }
                }
                return result;

            }
        }
        public int ColDep
        {
            get
            {

                return db.context.Worker.Count();
            }

        }
        public int Depart
        {
            get
            {
                return db.context.Worker.Where(x => x.IdWorker == x.Department.IdDepartment).Count();
            }
        }
        //public string DepartName
        //{
        //    get
        //    {
        //       string result = db.context.Department.Where(Department.NameDepartment=Department.NameDepartment);
        //      foreach(var item in db.context.Department.ToList())
        //        {
        //            if (Convert.ToString(item.IdDepartment) == item.NameDepartment)
        //            {
        //                result++;               
        //            }

        //        }
        //         return result;
        //    }
        //}
    }
}
