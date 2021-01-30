using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager.Objects
{
    public class TaskCollection
    {
        private List<SingleTask> tasks;
        public TaskCollection()
        {
            tasks = new List<SingleTask>();
        }

        public int Count
        {
            get { return tasks.Count; }
        }

        public void Add(SingleTask task)
        {
            tasks.Add(task);

            //Call database method
        }

        public void Add(string name, string category)
        {
            SingleTask newTask = new SingleTask();
            newTask.Name = name;
            newTask.Category = category;

            Add(newTask);
        }

        public string DisplayString(bool showIndex)
        {
            string returnValue = String.Empty;

            int counter = 1;

            foreach(SingleTask task in tasks)
            {
                if(showIndex == true)
                {
                    returnValue += counter + ": ";
                }
                returnValue += $"{task.Name} ({task.Category})\n";
                counter++;
            }


            return returnValue;
        }

        public bool DeleteTask(int task)
        {
            tasks.RemoveAt(task);
            return true;
        }
    }
}
