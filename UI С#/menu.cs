//=================================================================================================
// version Menu 0.3
// создано: 31.10.23, последняя модернизация 1.02.24
//=================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_С_
{
    /// <summary>
    /// Класс Menu создает одноуровневое меню для консольных приложений.
    /// </summary>
    internal class Menu
    {       
        // Заголовок.
        string title = "";
        //string emptyScreen = "                                                                                                                                                                    ";

        // Курсор
        string cursor = " -> ";
        string empty = " -  ";
        string[] symbol = new string[10];

        // Текст пунктов меню;
        string[] MenuItem = new string[10];

        // Количество пунктов меню.
        int param = 0;

        bool enter = true;
        bool cycle = true;
        bool exitCycle = false;

        int move = 1;

        // Метод обрабатывает и выводит меню.
        int PrintMenu()
        {
            enter = true;
            while (enter)
            {
                if (move >= 0 && move <= param)
                {
                    symbol[0] = symbol[1] = symbol[2] = symbol[3] = symbol[4] = symbol[5] = symbol[6] = symbol[7] = symbol[8] = symbol[9] = empty;
                    symbol[move] = cursor;     
                }
                Screen();
                Move();
            }
            return move;
        }

        // Метод для отрисовки меню.
        void Screen()
        {
            Console.Clear();
            Console.WriteLine($"\t -=  {title}  =-");
            for (int i = 1; i <= param; i++)
            {
                Console.WriteLine(symbol[i] + MenuItem[i]);
            }
            Console.WriteLine(symbol[0] + MenuItem[0]);
            Console.WriteLine($"\n  Для навигации по меню нажимайте {(char)24} {(char)25}, для выбора пункта меню нажмите Enter или Пробел.");
        }

        //
        void SetMenu(int menu)
        {
            Console.Clear();
            Console.WriteLine($"\t\t-=  {this.MenuItem[menu]}  =-");
            setmenu[menu]();
            if(menu != 0)
                Return();           
        }

        // Метод считывает и обрабатывает нажатия клавиш.
        void Move()
        {
            cycle = true;
            while (cycle)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                    {
                        move--;
                        cycle = false;
                    } break;

                    case ConsoleKey.DownArrow:
                    {
                        move++;
                        cycle = false;
                    } break;

                    case ConsoleKey.Enter:
                    {
                        enter = false;
                        cycle = false;
                    } break;

                    case ConsoleKey.Spacebar:
                    {
                        enter = false;
                        cycle = false;
                    } break;
                }
            }
            if (move > param)
            {
                move = 0;
            }
            if (move < 0)
            {
                move = param;
            }
        }

        // Метод для выхода из подменю.
        void Return()
        {
            Console.WriteLine("Для выхода нажмите ESCAPE.");
            cycle = true;
            while (cycle)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Escape:
                    {
                        cycle = false;
                    } break;
                }
            }
        }

        // Метод для выхода из приложения.
        void Exit()
        {
            Console.Clear();
            exitCycle = true;
        }

        // Метод для очиски экрана.
        //void ClearScreen()
        //{
        //    Console.SetCursorPosition(0,0);
        //    for (int c = 0; c > 10; c++)
        //    {
        //        Console.WriteLine(emptyScreen);
        //    }
        //    Console.SetCursorPosition(0, 0);
        //}

        public delegate void setMenu();

        /// <summary>
        /// В setmenu вы можете загрузить свои методы.
        /// </summary>
        public List<setMenu> setmenu = new List<setMenu>();

        /// <summary>
        /// Конструктор Menu первым параметром загружается заголовок меню, вторым массив строк пунктов меню.
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="Menu"></param>
        public Menu(string Title = "Меню версии 0.3", string[]? Menu = null)
        {
            Console.Title = this.title = Title;
            setmenu.Add(Exit);
            MenuItem[0] = "Выход";
            param = Menu.Length;
            for(int c = 0; c < Menu.Length; c++)
            {
                MenuItem[c + 1] = Menu[c];
            }
        }

	    /// <summary>
        /// Используйте этот метод для запуска меню после того как создадите конструктор и добавите в setmenu свои методы.
        /// </summary>
	    public void Start()
        {
            while (!exitCycle)
            {
                SetMenu(PrintMenu());
            }
        }
    }
}
