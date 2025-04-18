using SpartanTextRPG_Jin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SpartanTextRPG_Jin.Screens
{
    class StatusScreen : Screen
    {
        private Player _player;
        
        public StatusScreen(Player player)
        {
            _player = player;
            
        }
        public override void Show()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보가표시됩니다.");
            Console.WriteLine();
            Console.WriteLine($"LV.{_player.Level}");
            Console.WriteLine($"{_player.Name}({_player.Job})");
            if (_player.Inventory.InventoryItems.Exists(x => x.IsEquipped && x.Type == ItemType.Weapon))
            {
                Console.WriteLine($"공격력: {_player.AttackStat}({_player.Inventory.TotalAttackBonus})");
            }
            else
            {
                Console.WriteLine($"공격력: {_player.AttackStat}");
            }
            if (_player.Inventory.InventoryItems.Exists(x => x.IsEquipped && x.Type == ItemType.Armor))
            {
                Console.WriteLine($"방어력: {_player.DefenseStat}({_player.Inventory.TotalDefenseBonus})");
            }
            else
            {
                Console.WriteLine($"방어력: {_player.DefenseStat}");
            }            
            Console.WriteLine($"체력: {_player.Health}");
            Console.WriteLine($"Gold: {_player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요. \n>> ");


        }
        public override Screen HandleUserInput(string input)
        {
         
            if(input == "0")
            {
                return GameManager.GetScreen(1);
            }

            Console.Write("잘못된 입력입니다.");           
            Thread.Sleep(1000);
            
            return this;
                
        }
    }
}
