using SpartanTextRPG_Jin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartanTextRPG_Jin.Screens
{
    class EquipScreen : Screen
    {
        private Player _player;

        public EquipScreen(Player player)
        {
            _player = player;
        }
        public override void Show()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]\n");
            var list = _player.Inventory.InventoryItems;
            for (int i = 0; i< list.Count; i++)
            {
                var item = list[i];
                var equipMark = item.IsEquipped ? "[E]" : "  ";
                var bonus = item.Type == ItemType.Weapon ? $"공격력 + {item.AttackBonus}" : $"방어력 + {item.DefenseBonus}";
                Console.WriteLine($"- {i+1}{equipMark}{item.Name} | {bonus} | {item.Description}");
            }
            if (list.Count == 0) Console.WriteLine("보유한 아이템이 없습니다.");
            Console.WriteLine();
            Console.WriteLine("0.나가기\n");
            Console.Write("원하시는 행동을 입력해주세요. \n>> ");

        }
        public override Screen HandleUserInput(string input)
        {
            int value;
            bool isNumber = int.TryParse(input, out value);
            var list = _player.Inventory.InventoryItems;
            if (!isNumber)
            {
                Console.WriteLine("숫자를 입력해주세요.");
                Thread.Sleep(1000);
                return this;
            }

            if (value == 0) return GameManager.GetScreen(3);
            if (value < 1 || value > list.Count) return this;
            Item playerItem = list[value-1];
            _player.Inventory.ToggleEquip(playerItem.Id);
            Console.WriteLine(playerItem.IsEquipped ? "장착됌" : "장착해제");
            Thread.Sleep(1000);
            return this;
   
        }
    }
}
