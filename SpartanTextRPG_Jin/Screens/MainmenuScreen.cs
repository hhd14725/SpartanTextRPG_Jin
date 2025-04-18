using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SpartanTextRPG_Jin.Data;

namespace SpartanTextRPG_Jin.Screens
{
    class MainmenuScreen : Screen
    {
        private Player _player;

        public MainmenuScreen(Player player)
        {
            _player = player;
        }
        public override void Show()
        {
            
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("0. 종료");
            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요. \n>> ");
        }
        public override Screen HandleUserInput(string input)
        {
            int value;
            bool isNumber = int.TryParse(input, out value);

            if ( !isNumber)
            {
                Console.WriteLine("숫자를 입력해주세요.");
                Thread.Sleep(1000);
                return this;
            }

            switch (value)
            {
                case 1:
                    return GameManager.GetScreen(2);
                case 2:
                    return GameManager.GetScreen(3);
                case 3:                    
                    return GameManager.GetScreen(5);
                case 0:
                    return null;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                    return this;

            }


        

           
        }
    }
}
