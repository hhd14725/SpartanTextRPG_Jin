using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SpartanTextRPG_Jin.Data;
using SpartanTextRPG_Jin.Screens;

namespace SpartanTextRPG_Jin
{
    public static class GameManager
    {
        public static Player Player { get; set; }
        private static Dictionary<KeyofScreen, Screen> Screens;
        //static GameManager()
        //{
        // 정적 생성자, 처음 참조되기 직전에 초기화해줌
        // 여기에서 Player, Dictionary를 new 해줄 수 도 있음
        //}

        public enum KeyofScreen
        {
            MainMenu = 1,
            Status,
            Inventory,
            Equip,
            Shop,
            ShopPurchase,
            ShopSell
        }

        public static void Initialize()
        {
            Player = new Player();
            Console.WriteLine("용사의 이름을 입력하세요.");
            string name = Console.ReadLine();
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("직업을 선택해주세요: 1. 전사 | 2. 마법사 | 3. 궁수 ");
            JobType job;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "1") { job = JobType.전사; break; }
                if (input == "2") { job = JobType.마법사; break; }
                if (input == "3") { job = JobType.궁수; break; }
                Console.WriteLine("잘못된 입력입니다.");
            }

            
            Player.Name = name;
            Player.Job = job;

            ItemLists.UpdateMasterItemLists();
            Screens = new Dictionary<KeyofScreen, Screen>
            {
                { KeyofScreen.MainMenu,     new MainmenuScreen(Player) },
                { KeyofScreen.Status,       new StatusScreen(Player) },
                { KeyofScreen.Inventory,    new InventoryScreen(Player) },
                { KeyofScreen.Equip,        new EquipScreen(Player) },
                { KeyofScreen.Shop,         new ShopScreen(Player) },
                { KeyofScreen.ShopPurchase, new ShopPurchaseScreen(Player) },
                { KeyofScreen.ShopSell,     new ShopSellScreen(Player) }
            };
        }

        public static Screen GetScreen(int key)
        {
            if ( key < (int)KeyofScreen.MainMenu || key > (int)KeyofScreen.ShopSell)
            {
                return null; 
            }
            KeyofScreen enumkey = (KeyofScreen)key;
            if(Screens.ContainsKey(enumkey))
            {
                return Screens[enumkey];
            }
            else
            {
                return null;
            }
                     
        }

       




    }






}
