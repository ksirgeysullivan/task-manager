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
            taskCollection.Add("bathe Mark", "chore", "Kat");
            taskCollection.Add("feed Mark", "chore", "Kat");
            taskCollection.Add("shower with Kat", "pleasure", "Mark");
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
                Console.WriteLine("4. Search for a task");
                Console.WriteLine("5. Exit the app");
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

                    case '4':
                        SearchTasksUI();
                        break;
                }


            } while (menuOption != '5');
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

            if (ValidateTaskIndexEntry(task, out int taskInt))
            {
                taskCollection.DeleteTask(taskInt - 1);

                Console.WriteLine("Task deleted successfully");
            }
        }


        private bool ValidateTaskIndexEntry(string taskIndexString, out int indexValue)
        {
            if (!Int32.TryParse(taskIndexString, out indexValue))
            {
                Console.WriteLine("ERROR: You must enter a number");
                return false;
            }

            if (indexValue < 1 || indexValue > taskCollection.Count)
            {
                Console.WriteLine("ERROR: You must enter a valid task number");
                return false;
            }

            return true;
        }

        private void AddTaskUI()
        {
            Console.WriteLine("ENTER TASK DETAILS");
            Console.Write("    Task Name: ");
            string taskName = Console.ReadLine();
            Console.Write("    Task Category: ");
            string category = Console.ReadLine();
            Console.Write("    Task Person: ");
            string person = Console.ReadLine();

            if((String.IsNullOrWhiteSpace(taskName)) || (String.IsNullOrWhiteSpace(category)) || (String.IsNullOrWhiteSpace(person)))
            {
                Console.WriteLine("ERROR: Name, category, and person are required");
                return;
            }

            SingleTask newTask = taskCollection.Add(taskName, category, person);

            
            Console.Write("    Due Date (Optional): ");
            string dateString = Console.ReadLine();
            

            if(!String.IsNullOrWhiteSpace(dateString))
            {
                DateTime dueDate = new DateTime();
                if (DateTime.TryParse(dateString, out dueDate))
                {
                    newTask.DueDate = dueDate;
                }
                else
                {
                    Console.WriteLine("Unable to parse your date.");
                }
            }

            


            Console.WriteLine("Task added successfully");           
        }

        private void SearchTasksUI()
        {
            Console.Write("Type your search item here: ");
            string searchItem = Console.ReadLine();

            if(String.IsNullOrWhiteSpace(searchItem))
            {
                Console.WriteLine("Please enter a word or phrase.");
            } else
            {
                Console.WriteLine(taskCollection.SearchTasks(searchItem));
            }
        }
    }
}
