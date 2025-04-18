using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartanTextRPG_Jin.Screens
{
    public abstract class Screen
    {
        public abstract void Show();
        public abstract Screen HandleUserInput(string input);

    }
}
