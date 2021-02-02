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

        public SingleTask Add(string name, string category, string person)
        {
            SingleTask newTask = new SingleTask();
            newTask.Name = name;
            newTask.Category = category;
            newTask.Person = person;

            Add(newTask);

            return newTask;
        }

        public string DisplayString(bool showIndex)
        {
            string returnValue = String.Empty;

            int counter = 1;

            foreach (SingleTask task in tasks)
            {
                if (showIndex == true)
                {
                    returnValue += counter + ": ";
                }
                returnValue += task.ToString();

                counter++;
            }


            return returnValue;
        }

        public bool DeleteTask(int task)
        {
            tasks.RemoveAt(task);
            return true;
        }

        public string SearchTasks(string searchItem)
        {
            string returnValue = String.Empty;
            int matchCounter = 0;

            foreach (SingleTask task in tasks)
            {
                if(task.Name.IndexOf(searchItem,StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    matchCounter++;
                    returnValue += task.ToString();
                }
            }
            
            return $"There were {matchCounter} matches\n" + returnValue;
        }
    }
}
