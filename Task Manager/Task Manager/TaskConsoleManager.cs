using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Manager.Objects;

namespace Task_Manager
{
    class TaskConsoleManager
    {
        private TaskCollection taskCollection;
        
        public TaskConsoleManager()
        {
            taskCollection = new TaskCollection();
            taskCollection.Add("bathe Mark", "chore");
            taskCollection.Add("feed Mark", "chore");
            taskCollection.Add("shower with Kat", "pleasure");
        }
        
        public void ShowMenu()
        {
            char menuOption;

            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("MENU");
                Console.WriteLine("Type in the number of the action you wish to perform.");
                Console.WriteLine("1. Add a task");
                Console.WriteLine("2. Delete a task");
                Console.WriteLine("3. View the tasks");
                Console.WriteLine("4. Exit the app");
                menuOption = Console.ReadKey().KeyChar;

                Console.WriteLine("\n\n");
                switch(menuOption)
                {
                    case '1':
                        AddTaskUI();
                        break;

                    case '2':
                        DeleteTaskUI();
                        break;

                    case '3':
                        ViewTasksUI();
                        break;
                }


            } while (menuOption != '4');
        }

        private void ViewTasksUI()
        {
            Console.WriteLine($"{taskCollection.Count} tasks in your collection\n");

            Console.WriteLine(taskCollection.DisplayString(false));
        }

        private void DeleteTaskUI()
        {
            Console.WriteLine("DELETE TASK SELECTED");

            Console.WriteLine(taskCollection.DisplayString(true));

            Console.Write("Select the task you wish to delete: ");
            string task = Console.ReadLine();
            int taskInt;
            if( !Int32.TryParse(task, out taskInt))
            {
                Console.WriteLine("ERROR: You must enter a number");
                return;
            }

            if(taskInt < 1 || taskInt > taskCollection.Count)
            {
                Console.WriteLine("ERROR: You must enter a valid task number");
                return;
            }

            taskCollection.DeleteTask(taskInt-1);

            Console.WriteLine("Task deleted successfully");
        }

        private void AddTaskUI()
        {
            Console.WriteLine("ENTER TASK DETAILS");
            Console.Write("    Task Name: ");
            string taskName = Console.ReadLine();
            Console.Write("    Task Category: ");
            string category = Console.ReadLine();

            if((String.IsNullOrWhiteSpace(taskName)) || (String.IsNullOrWhiteSpace(category)))
            {
                Console.WriteLine("ERROR: Both name and category are required");
                return;
            }

            taskCollection.Add(taskName, category);

            Console.WriteLine("Task added successfully");           
        }
    }
}
