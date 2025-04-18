using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartanTextRPG_Jin.Data
{
    public class Inventory
    {
        private Player _player;
        public List<Item> InventoryItems { get; set; }
        public int TotalAttackBonus
        {
            get
            {
                int total = 0;
                foreach (var item in InventoryItems)
                {
                    if(item.IsEquipped)
                    {
                        total += item.AttackBonus;
                    }
                }
                return total;
            }
        }
        public int TotalDefenseBonus
        {
            get
            {
                int total = 0;
                foreach (var item in InventoryItems)
                {
                    if (item.IsEquipped)
                    {
                        total += item.DefenseBonus;
                    }
                }
                return total;
            }
        }

        public Inventory(Player player)
        {
            _player = player;
            InventoryItems = new List<Item>();
        }

        public void Buy(Item item)
        {
            if (item == null || item.IsOwned) return;
            if (_player.Gold < item.Price) return;
            _player.Gold -= item.Price;
            item.IsOwned = true;
            InventoryItems.Add(item);

        }

        public void Sell(int idInput)
        {
            Item item = InventoryItems.Find(x => x.Id == idInput);
            if (item == null) return;
            _player.Gold += (int)(item.Price * 0.85);
            if (item.IsEquipped)
            {
                ToggleEquip(item.Id);

            }
            item.IsOwned = false;
            InventoryItems.Remove(item);
        }

        public void ToggleEquip(int id)
        {
           
            Item item = InventoryItems.Find(x => x.Id == id);
            if (item == null) return;
            if (!item.IsEquipped && item.Type == ItemType.Weapon)
            {
                var equippedItemCheck = _player.Inventory.InventoryItems;
                if (equippedItemCheck.Exists(x => x.IsEquipped && x.Type == ItemType.Weapon))
                {
                    foreach (var items in InventoryItems)
                    {
                        if (items.Type == ItemType.Weapon)
                        {
                            items.IsEquipped = false;
                        }

                    }
                }
                item.IsEquipped = true;
                _player.AttackStat += item.AttackBonus;
               // _player.DefenseStat += item.DefenseBonus;
            }
            else if(!item.IsEquipped && item.Type == ItemType.Armor)
            {
                var equippedItemCheck = _player.Inventory.InventoryItems;
                if (equippedItemCheck.Exists(x => x.IsEquipped && x.Type == ItemType.Armor))
                {
                    foreach (var items in InventoryItems)
                    {
                        if (items.Type == ItemType.Armor)
                        {
                            items.IsEquipped = false;
                        }

                    }
                }
                item.IsEquipped = true;
              //  _player.AttackStat += item.AttackBonus;
                _player.DefenseStat += item.DefenseBonus;

            }
           
                
            
            else if(item.IsEquipped) 
            {
                item.IsEquipped = false;
                _player.AttackStat -= item.AttackBonus;
                _player.DefenseStat -= item.DefenseBonus; 
            }

            
            
        }

        //다른걸 장착을 누를때, 이미 하나라도 weapon 타입을 장착중이라면 장착해제하고, 장착하도록. Armor 타입도 마찬가지
        //본인 장착을 누를때

    }
}
