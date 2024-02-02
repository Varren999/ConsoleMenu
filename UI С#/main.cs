using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_С_;

class Program
{
    static void foo()
    {
        Console.WriteLine("Функция foo");
    }
    static void bar()
    {
        Console.WriteLine("Функция bar");
    }

    static void Main()
    {
        Menu menu = new Menu("Тестовое меню", new string[] { "foo", "bar" }, new List<Menu.delFunction> {foo, bar }) ;
        menu.Start();
    }
}
