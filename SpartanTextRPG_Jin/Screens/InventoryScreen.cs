using SpartanTextRPG_Jin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartanTextRPG_Jin.Screens
{
    class InventoryScreen : Screen
    {
        private Player _player;
        
        public InventoryScreen(Player player)
        {
            _player = player;
        }
        public override void Show()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]\n");
            foreach (var item in _player.Inventory.InventoryItems)
            {
                var equipMark =item.IsEquipped? "[E]" : "  ";
                var bonus = item.Type == ItemType.Weapon ? $"공격력 + {item.AttackBonus}" : $"방어력 + {item.DefenseBonus}";
                Console.WriteLine($"-{equipMark}{item.Name} | {bonus} | {item.Description}");
            }
            Console.WriteLine();
            Console.WriteLine("1.장착 관리\n");
            Console.WriteLine("0.나가기\n");
            Console.Write("원하시는 행동을 입력해주세요. \n>> ");
        }
        public override Screen HandleUserInput(string input)
        {
            int value;
            bool isNumber = int.TryParse(input, out value);

            if (!isNumber)
            {
                Console.WriteLine("숫자를 입력해주세요.");
                Thread.Sleep(1000);
                return this;
            }

            switch (value)
            {
                case 0:
                    return GameManager.GetScreen(1);
                case 1:
                    return GameManager.GetScreen(4);
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                    return this;
            }
        }
    }
}
