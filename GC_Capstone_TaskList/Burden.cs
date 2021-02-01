using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Capstone_TaskList
{
    class Burden
    {
        private string teamMemberName;
        private string description;
        private string dueDate;
        private bool isCompleted;

        //TODO
        // Strech goal: convert string to DateTime type each time one is entered or changed
        // You can do this in the Set block?

        // private DateTime dateTime;  

        private string status;
        private string falseTerm = "incomplete";    // also acceptable "still haunting you"
        private string trueTerm = "complete";       // also acceptable "finally over with" 

        public string TeamMemberName { get => teamMemberName; set => teamMemberName = value; }
        public string Description { get => description; set => description = value; }
        public string DueDate { get => dueDate; set => dueDate = value; }
        public string Status { get => status; }
        public bool IsCompleted
        {
            get { return isCompleted; }
            set
            {
                isCompleted = value;
                if (value == true)
                {
                    status = trueTerm;
                }
                else
                {
                    status = falseTerm;
                }
            }
        }

        public Burden(string teamMemberName, string description, string dueDate)
        {
            this.teamMemberName = teamMemberName;
            this.description = description;
            this.dueDate = dueDate;
            isCompleted = false;
            status = falseTerm;
        }
    }
}
