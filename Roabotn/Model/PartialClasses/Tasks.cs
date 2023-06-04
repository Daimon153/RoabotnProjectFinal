using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roabotn.Model
{
    public partial class Tasks
    {
        Core db=new Core();
        List<string> resultArray = new List<string>();
        string text = "";
        public string WorkerText
        {
            get
            {
                if (db.context.TaskWorker.Where(x=>x.IdTasks==IdTasks).Count()==0)
                {
                    return "Нет";
                }
              
                foreach (var item in db.context.TaskWorker.ToList())
                {
                    if (item.IdTasks==IdTasks)
                    {
                        resultArray.Add(item.Worker.lastname);

                       

                    }
                    
                }
                // text = item.Worker.lastname + ", ";
                text = String.Join(", ",resultArray);
                return text;
                

            }
        }
    }
}
