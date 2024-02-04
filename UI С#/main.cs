using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMenu;
using UI_С_;

class Program
{
    static void Main()
    {
        testClass test = new testClass();
        Menu menu = new Menu("Тестовое меню", new string[] { "foo", "bar" }, new List<Menu.delFunction> { test.foo, test.bar });
        menu.Start();

    }
}
