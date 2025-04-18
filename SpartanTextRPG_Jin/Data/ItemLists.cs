using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartanTextRPG_Jin.Data
{
    public class ItemLists
    {
        public static List<Item> ShopItems { get; private set; }
        public static List<Item> MasterItemLists { get; private set; }
        public static void UpdateMasterItemLists()
        {
            MasterItemLists = new List<Item>
            {
                new Item {Id = 1, Name = "낡은 검",       Type = ItemType.Weapon, AttackBonus = 1,  DefenseBonus = 0, Price = 100, Description= "쉽게 볼 수 있는 낡은 검입니다." },
                new Item {Id = 2, Name = "돌도끼",       Type = ItemType.Weapon, AttackBonus = 2,  DefenseBonus = 0, Price = 200 , Description= "원시적인 도끼입니다." },
                new Item {Id = 3, Name = "낡은 단창",     Type = ItemType.Weapon, AttackBonus = 3,  DefenseBonus = 0, Price = 300 ,Description= "쉽게 볼 수 있는 낡은 단창입니다." },
                new Item {Id = 4, Name = "무쇠 도끼",       Type = ItemType.Weapon, AttackBonus = 2,  DefenseBonus = 0, Price = 600 , Description = "튼튼한 무쇠 도끼입니다."},
                new Item {Id = 5, Name = "청동 도끼",     Type = ItemType.Weapon, AttackBonus = 5,  DefenseBonus = 0, Price = 1500 , Description = "어디선가 사용됐던것 같은 도끼입니다."},
                new Item {Id = 6, Name = "스파르타의 창", Type = ItemType.Weapon, AttackBonus = 7,  DefenseBonus = 0, Price = 2500 , Description = "스파르타 전사들이 사용했다는 전설의 창입니다."},
                new Item {Id = 7, Name = "가죽 방어구",   Type = ItemType.Armor,  AttackBonus = 0,  DefenseBonus = 3, Price = 200 , Description = "가죽으로 만들어진 방어구입니다."},
                new Item {Id = 8, Name = "무쇠갑옷", Type = ItemType.Armor,  AttackBonus = 0,  DefenseBonus = 8, Price = 1800 , Description = "무거운 무쇠로 된 튼튼한 갑옷입니다." },
                new Item {Id = 9, Name = "전사갑옷",      Type = ItemType.Armor,  AttackBonus = 0,  DefenseBonus = 9, Price = 2000 , Description = "숙련된 전사들이 입는 갑옷입니다."},
                new Item {Id = 10, Name = "종자의 옷",       Type = ItemType.Armor,  AttackBonus = 0,  DefenseBonus = 4, Price = 500 , Description = "종자들이나 입는 옷입니다."},
                new Item {Id = 11,  Name = "기사단장 방어구", Type = ItemType.Armor,  AttackBonus = 0,  DefenseBonus = 12, Price = 3000 , Description = "기사단장만이 입을 수 있는 훌륭한 갑옷입니다."},
                new Item {Id = 12,  Name = "강철 도끼",    Type = ItemType.Weapon, AttackBonus = 6,  DefenseBonus = 0, Price = 2000 , Description = "강철로 된 강력한 도끼입니다."},
                new Item {Id = 13,  Name = "사슬갑옷",    Type = ItemType.Armor,  AttackBonus = 0,  DefenseBonus = 6, Price = 1200 , Description = "촘촘하게 만들어진 사슬 갑옷입니다."},
                new Item {Id = 14,  Name = "무쇠검",       Type = ItemType.Weapon, AttackBonus = 4,  DefenseBonus = 0, Price = 800 , Description = "쓸만한 무쇠 검입니다."},
                new Item {Id = 15,  Name = "황금 도끼",       Type = ItemType.Weapon, AttackBonus = 9,  DefenseBonus = 0, Price = 3500 , Description = "전설의 전사가 사용했던 황금도끼입니다."},
                new Item {Id = 16,  Name = "기사갑옷",       Type = ItemType.Armor,  AttackBonus = 0,  DefenseBonus = 10, Price = 2500 , Description = "기사들이 입는 전용 갑옷입니다."},
                new Item {Id = 17,  Name = "기사의 검",      Type = ItemType.Weapon, AttackBonus = 5,  DefenseBonus = 0, Price = 1600 , Description = "기사들이 사용하는 전용 검입니다."},
                new Item {Id = 18,  Name = "기사 튜닉",    Type = ItemType.Armor,  AttackBonus = 0,  DefenseBonus = 2, Price = 700 , Description = "기사들이 덧대어 입는 쓸만한 옷입니다."}

            };
        }

        public static void UpdateShopItems()
        {
            //UpdateMasterItemLists(); 
            ShopItems = new List<Item>();
            Random random = new Random();
            var items = new List<Item>();
            foreach (var item in MasterItemLists)
            {
                items.Add(item);
            }
            items = items.OrderBy(x => random.Next(0, items.Count)).ToList();
            for (int i = 0; i < 6; i++)
            {
                ShopItems.Add(items[i]);
            }


        }

    }
}
