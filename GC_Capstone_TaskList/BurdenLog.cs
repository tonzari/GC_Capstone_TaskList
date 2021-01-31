using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Capstone_TaskList
{
    class BurdenLog
    {
        private List<Burden> burdens; // initialized in contructor
        public List<Burden> Burdens { get => burdens; set => burdens = value; }

        public BurdenLog()
        {
            burdens = new List<Burden>();
        }

        public void AddBurden(Burden burden)
        {
            Burdens.Add(burden);
        }
    }
}
