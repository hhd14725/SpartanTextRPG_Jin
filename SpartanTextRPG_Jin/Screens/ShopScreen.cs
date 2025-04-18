using SpartanTextRPG_Jin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SpartanTextRPG_Jin.Screens
{
    class ShopScreen : Screen
    {
        private Player _player;

        public ShopScreen(Player player)
        {
            _player = player;
        }
        public override void Show()
        {
            ItemLists.UpdateShopItems();
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{_player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();
            //foreach(var item in Item.ShopItems)
            //{
            //    var ownedStatus = item.IsOwned ? "구매완료" : $"{item.Price} G";
            //    var bonus = item.Type == ItemType.Weapon? $"공격력 + {item.AttackBonus}" : $"방어력 + {item.DefenseBonus}";
            //    Console.WriteLine($"-{item.Name} | {bonus} | {item.Description} | {ownedStatus} ");
            //}
            var Shoplist = ItemLists.ShopItems;
            for (int i = 0; i < Shoplist.Count; i++)
            {
                var item = Shoplist[i];
                var ownedStatus = _player.Inventory.InventoryItems.Exists(x => x.Id == Shoplist[i].Id) ? "구매완료" : $"{item.Price} G";
                var bonus = item.Type == ItemType.Weapon ? $"공격력 + {item.AttackBonus}" : $"방어력 + {item.DefenseBonus}";
                Console.WriteLine($"- {item.Name} | {bonus} | {item.Description} | {ownedStatus}");
            }
            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
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
                    return GameManager.GetScreen(6);
                case 2:
                    return GameManager.GetScreen(7);
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                    return this;
            }
        }
    }
}
