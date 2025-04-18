using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpartanTextRPG_Jin.Data;

namespace SpartanTextRPG_Jin.Screens
{
    class ShopPurchaseScreen : Screen
    {
        private Player _player;

        public ShopPurchaseScreen(Player player)
        {
            _player = player;
        }
        public override void Show()
        {
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
            var Shoplist = ItemLists.ShopItems;
            for (int i = 0; i < Shoplist.Count; i++)
            {
                var item = Shoplist[i];
                var ownedStatus = _player.Inventory.InventoryItems.Exists(x => x.Id == Shoplist[i].Id) ? "구매완료" : $"{item.Price} G";
                var bonus = item.Type == ItemType.Weapon ? $"공격력 + {item.AttackBonus}" : $"방어력 + {item.DefenseBonus}";
                Console.WriteLine($"- {i+1} {item.Name} | {bonus} | {item.Description} | {ownedStatus}");
            }
            Console.WriteLine() ;
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요. \n>> ");
        }
        public override Screen HandleUserInput(string input)
        {
            int value;
            bool isNumber = int.TryParse(input, out value);
            var Shoplist = ItemLists.ShopItems;
            if (!isNumber)
            {
                Console.WriteLine("숫자를 입력해주세요.");
                Thread.Sleep(1000);
                return this;
            }
            if (value == 0) return GameManager.GetScreen(5);
            else if (value < 1 || value > Shoplist.Count)
            {
                Console.WriteLine("존재하지않는아이템입니다.");
            }
            else if (_player.Inventory.InventoryItems.Exists(x => x.Id == Shoplist[value-1].Id))
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
            }
            else if(_player.Gold < Shoplist[value - 1].Price)
            {
                Console.WriteLine("골드가 부족합니다.");
            }
            else
            {
                Item chooseItem = Shoplist[value - 1];
                _player.Inventory.Buy(chooseItem);
                Console.WriteLine("구매완료하였습니다.");
            }
            //Console.WriteLine("계속하려면 아무 키나 누르세요...");
            //Console.ReadKey();
            
            Thread.Sleep(1000);

            return this;

            //상점아이템 리스트에서
            //상점 아이템 번호를 확인하고
            //해당 번호를 누르면 받아서 구매함. 이미 구매한 내용이라면 구매가안된다고 출력됌.
            //보유한 금액이 적다면 구매가안된다고 출력됌.
            //보유한 금액이 충분하다면 구매를 완료했다고 출력함.

            //_player.Inventory.Buy(value);




        }

    }
}
