using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartanTextRPG_Jin.Data
{
    public enum ItemType
    {
        Weapon,
        Armor
    }
    public class Item
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public int AttackBonus { get; set; }
        public int DefenseBonus { get; set; }
        public string Description { get; set; } 
        public int Price { get; set; }
        public bool IsOwned { get; set; }
        public bool IsEquipped { get; set; }

       
    }
}
