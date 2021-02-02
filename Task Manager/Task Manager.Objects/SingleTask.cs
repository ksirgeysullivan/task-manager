using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_Manager.Objects
{
    public class SingleTask
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Person { get; set; }

        public Nullable<DateTime> DueDate { get; set; }

        public override string ToString()
        {
            if (DueDate.HasValue)
            {
                return $"{Name} {Category}, {Person}) {DueDate.Value.ToShortDateString()}\n";
            }
            else
            {
                return $"{Name} ({Category}, {Person})\n";
            }
        }
    }
}
