using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartanTextRPG_Jin.Data
{
    public class Player
    {
        public string Name { get;  set; }
        public JobType Job { get; set; }
        public int Level { get; set; }
        public int AttackStat { get; set; }
        public int DefenseStat { get; set; }
        public int Health { get; set; }
        public int Gold { get; set; }
        public Inventory Inventory { get; set; }

        public Player()
        {
            Level = 01;
            //Name = "";
            //Job = JobType.전사;
            AttackStat = 10;
            DefenseStat = 5;
            Health = 100;
            Gold = 1500;
            Inventory = new Inventory(this);
        }


    }
}
