using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_С_;

class Program
{
    static void Main()
    {
        Menu menu = new Menu("Тестовое меню","foo","bar");
        void foo()
        {
            Console.WriteLine("Функция foo");
        }
        void bar()
        {
            Console.WriteLine("Функция bar");
        }
        menu.setmenu += foo;
        menu.setmenu += bar;
        menu.Start();
    }
}
