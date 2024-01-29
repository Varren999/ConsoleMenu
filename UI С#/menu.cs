//=================================================================================================
// version Menu 0.2
// создано: 31.10.23, последняя модернизация 12.01.24
//=================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_С_
{
    /// <summary>
    /// 
    /// </summary>
    internal class Menu
    {
        public delegate void setMenu();
        
        // Заголовок.
        string title = "";

        // Курсор
        string cursor = " -> ";
        string empty = " -  ";
        string emptyScreen = "                                                                                                                                                                    ";
        string[] symbol = new string[10];

        // Тескт меню;
        string[] menu = new string[9];
        string exit = "Выход";

        // Количество пунктов меню.
        int param = 0;

        bool enter = true;
        bool escape = false;
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
                //ClearScreen();
                Console.Clear();
                Console.WriteLine($"\t -=  {title}  =-");
                for (int i = 0; i < param; i++)
                {
                     Console.WriteLine(symbol[i + 1] + GetMenu(i));
                }
                Console.WriteLine(symbol[0] + GetExit());
                Console.WriteLine($"\n  Для навигации по меню нажимайте {(char)24} {(char)25}, для выбора пункта меню нажмите Enter.");
                Move();
                if (move > param)
                {
                     move = 0;
                }
                if (move < 0)
                {
                     move = param;
                }
            }
            return move;
        }

        //
        void SetMenu(int menu)
        {
            switch (menu)
            {
                case 0: { Exit(); } break;
                case 1: { SetMenu1(); } break;
                case 2: { SetMenu2(); } break;
                case 3: { SetMenu3(); } break;
                case 4: { SetMenu4(); } break;
                case 5: { SetMenu5(); } break;
                case 6: { SetMenu6(); } break;
                case 7: { SetMenu7(); } break;
                case 8: { SetMenu8(); } break;
                case 9: { SetMenu9(); } break;
                default: { Console.WriteLine("Ошибка."); Console.ReadKey(true); } break;
            }
        }

        string GetMenu(int num) => menu[num];
        string GetExit() => exit;

        // Метод для навигации по меню.
        void Move()
        {
            bool cycle = true;
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
                }
            }
        }

        // Метод для выхода из подменю.
        void Return()
        {
            Console.WriteLine("Для выхода нажмите ESCAPE.");
            bool cycle = true;
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

        //
        void Exit() => exitCycle = true;

        void SetMenu1()
        {
            //ClearScreen();
            Console.Clear();
            Console.WriteLine($"\t\t-=  { this.menu[0]}  =-");
            
            Return();
        }

        void SetMenu2()
        {
            Console.Clear();
            Console.WriteLine($"\t\t-=  {this.menu[1]}  =-");

            Return();
        }

        void SetMenu3()
        {
            Console.Clear();
            Console.WriteLine($"\t\t-=  {this.menu[2]}  =-");

            Return();
        }

        void SetMenu4()
        {
            Console.Clear();
            Console.WriteLine($"\t\t-=  {this.menu[3]}  =-");

            Return();
        }

        void SetMenu5()
        {
            Console.Clear();
            Console.WriteLine($"\t\t-=  {this.menu[4]}  =-");

            Return();
        }

        void SetMenu6()
        {
            Console.Clear();
            Console.WriteLine($"\t\t-=  {this.menu[5]}  =-");

            Return();
        }

        void SetMenu7()
        {
            Console.Clear();
            Console.WriteLine($"\t\t-=  {this.menu[6]}  =-");

            Return();
        }

        void SetMenu8()
        {
            Console.Clear();
            Console.WriteLine($"\t\t-=  {this.menu[7]}  =-");

            Return();
        }

        void SetMenu9()
        {
            Console.Clear();
            Console.WriteLine($"\t\t-=  {this.menu[8]}  =-");

            Return();
        }

        // Метод подсчитывет не пустые строки
        bool Is_Empty(string text)
        {
            if (text.Length != 0)
            {
                this.param++;
                return true;
            }
            else
                return false;
        }

        //
        void ClearScreen()
        {
            Console.SetCursorPosition(0,0);
            for (int c = 0; c > 10; c++)
            {
                Console.WriteLine(emptyScreen);
            }
            Console.SetCursorPosition(0, 0);
        }

        public setMenu setmenu = null;

        public Menu(string Title = "Меню версии 0.4", string Menu1 = "", string Menu2 = "", string Menu3 = "",
            string Menu4 = "", string Menu5 = "", string Menu6 = "", string Menu7 = "", string Menu8 = "", string Menu9 = "")
        {
            Console.Title = Title;            
            this.title = Title;
            setmenu += Exit;
            if (Is_Empty(Menu1))
                this.menu[0] = Menu1;
            if (Is_Empty(Menu2))
                this.menu[1] = Menu2;
            if (Is_Empty(Menu3))
                this.menu[2] = Menu3;
            if (Is_Empty(Menu4))
                this.menu[3] = Menu4;
            if (Is_Empty(Menu5))
                this.menu[4] = Menu5;
            if (Is_Empty(Menu6))
                this.menu[5] = Menu6;
            if (Is_Empty(Menu7))
                this.menu[6] = Menu7;
            if (Is_Empty(Menu8))
                this.menu[7] = Menu8;
            if (Is_Empty(Menu9))
                this.menu[8] = Menu9;
        }

	// Метод для запуска меню.
	public void Start()
        {
            while (!exitCycle)
            {
                SetMenu(PrintMenu());
            }
        }
    }
}
