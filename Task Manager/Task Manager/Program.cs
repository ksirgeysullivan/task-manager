﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskConsoleManager firstManager = new TaskConsoleManager();
            firstManager.ShowMenu();

        }
    }
}
