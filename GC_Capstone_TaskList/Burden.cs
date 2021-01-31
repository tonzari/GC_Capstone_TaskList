using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Capstone_TaskList
{
    class Burden
    {
        private string teamMemberName;
        private string description;
        private DateTime dueDate;
        private bool isCompleted;

        public string TeamMemberName { get => teamMemberName; set => teamMemberName = value; }
        public string Description { get => description; set => description = value; }
        public DateTime DueDate { get => dueDate; set => dueDate = value; }
        public bool IsCompleted { get => isCompleted; set => isCompleted = value; }

        public Burden(string teamMemberName, string description, DateTime dueDate, bool isCompleted)
        {
            this.teamMemberName = teamMemberName;
            this.description = description;
            this.dueDate = dueDate;
            this.isCompleted = isCompleted;
        }

    }
}
