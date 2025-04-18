using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpartanTextRPG_Jin.Data;

namespace SpartanTextRPG_Jin.Screens
{
    class ShopSellScreen : Screen
    {
        private Player _player;

        public ShopSellScreen(Player player)
        {
            _player = player;
        }
        public override void Show()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("상점 - 판매하기");
            Console.WriteLine("보유 중인 아이템을 판매합니다.\n");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{_player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("[아이템 보유 목록]\n");
            Console.WriteLine();
            var list = _player.Inventory.InventoryItems;
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                var equipMark = item.IsEquipped ? "[E]" : "  ";
                var bonus = item.Type == ItemType.Weapon ? $"공격력 + {item.AttackBonus}" : $"방어력 + {item.DefenseBonus}";
                Console.WriteLine($"- {i + 1} {equipMark}{item.Name} | {bonus} | {item.Description} | {item.Price * 0.85} G");
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

            if (value == 0) return GameManager.GetScreen(5);
            if (value < 1 || value > list.Count) return this;
            Item playerItem = list[value - 1];
            _player.Inventory.Sell(playerItem.Id);
            Console.WriteLine("판매 완료하였습니다.");
            //Console.ReadKey();
            Thread.Sleep(1000);
            return this;

        }
    }
}
