using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpartanTextRPG_Jin.Data;
using SpartanTextRPG_Jin.Screens;



namespace SpartanTextRPG_Jin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager.Initialize();
                                      
            Screen currentScreen = GameManager.GetScreen(1);
            
            while (currentScreen != null)
            {
                currentScreen.Show();
                string input = Console.ReadLine();
                currentScreen = currentScreen.HandleUserInput(input);

            }


        }
    }
}
