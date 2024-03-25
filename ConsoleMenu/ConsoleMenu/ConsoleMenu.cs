//=================================================================================================
// version Menu 0.3
// создано: 31.10.23, последняя модернизация 25.03.24
//=================================================================================================

using System;
using System.Collections.Generic;

namespace ConsoleMenu
{
    /// <summary>
    /// Класс Menu создает одноуровневое меню для консольных приложений.
    /// </summary>
    public class Menu
    {       
        // Заголовок.
        private  readonly string title = "";

        // Курсор
        private const string CURSOR = " -> ";
        private const string EMPTY  = "    ";
        private string[] symbol = new string[10];

        // Текст пунктов меню;
        private string[] MenuItem = new string[10];

        // Количество пунктов меню.
        private int item = 0, move = 1;

        private bool enter = true, cycle = true, exitCycle = false;

        // Метод обрабатывает и выводит меню.
        private int PrintMenu()
        {
            enter = true;
            while (enter)
            {
                if (move >= 0 && move <= item)
                {
                    symbol[0] = symbol[1] = symbol[2] = symbol[3] = symbol[4] = symbol[5] = symbol[6] = symbol[7] = symbol[8] = symbol[9] = EMPTY;
                    symbol[move] = CURSOR;
                }
                Screen();
                Keyboard();
                Move();
            }
            return move;
        }

        // Метод для отрисовки меню.
        private void Screen()
        {
            Console.Clear();
            Console.WriteLine($"\t -=  {title}  =-");
            for (int i = 1; i <= item; i++)
            {
                Console.WriteLine(symbol[i] + MenuItem[i]);
            }
            Console.WriteLine(symbol[0] + MenuItem[0]);
            Console.WriteLine($"\n  Для навигации по меню нажимайте {(char)24} {(char)25}, для выбора пункта меню нажмите Enter или Пробел.");
        }

        //
        private void SetMenu(int menu)
        {
            Console.Clear();
            Console.WriteLine($"\t\t-=  {this.MenuItem[menu]}  =-");
            lsFunction[menu]();
            if(menu != 0)
                Return();
        }

        // Метод считывает и обрабатывает нажатия клавиш.
        private void Keyboard()
        {
            cycle = true;
            while (cycle)
            //if(Console.KeyAvailable)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            move--;
                            cycle = false;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        {
                            move++;
                            cycle = false;
                        }
                        break;

                    case ConsoleKey.Enter:
                        {
                            enter = false;
                            cycle = false;
                        }
                        break;

                    case ConsoleKey.Spacebar:
                         goto case ConsoleKey.Enter;
                        
                }
            }
        }

        // 
        private void Move()
        {
            if (move > item)
            {
                move = 0;
            }
            if (move < 0)
            {
                move = item;
            }
        }

        // Метод для выхода из подменю.
        private void Return()
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
        private void Exit()
        {
            Console.Clear();
            exitCycle = true;
        }

        // Метод для очиски экрана.
        //void Clear()
        //{
        //    string empty = "                                                                                                                      ";
        //    Console.SetCursorPosition(0, 0);
        //    try
        //    {
        //        for (int c = 0; c < param + 5; c++)
        //            Console.WriteLine(empty);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    Console.SetCursorPosition(0, 0);
        //}

        public delegate void delFunction();

        /// <summary>
        /// В lsFunction вы можете загрузить свои методы.
        /// </summary>
        public List<delFunction> lsFunction = new List<delFunction>();

        /// <summary>
        /// Конструктор Menu первым параметром загружается заголовок меню, вторым массив строк пунктов меню и третьим List делегатов на методы.
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="ItemMenu"></param>
        public Menu(string Title = "Меню версии 0.3", string[] ItemMenu = null, List<delFunction> LsFunction = null)
        {
            try
            {
                if (ItemMenu.Length != 0 && LsFunction.Count != 0)
                {
                    if (ItemMenu.Length == LsFunction.Count)
                    {
                        Console.Title = this.title = Title;
                        lsFunction.Add(Exit);
                        lsFunction.InsertRange(1, LsFunction);
                        MenuItem[0] = "Выход";
                        item = ItemMenu.Length;
                        for (int c = 0; c < ItemMenu.Length; c++)
                        {
                            MenuItem[c + 1] = ItemMenu[c];
                        }
                    }
                    else
                        throw new Exception($"Количество загруженых пунктов меню не соотвествует количеству загруженых методов");
                }
                else
                    throw new Exception($"В меню передано {ItemMenu.Length} пунктов");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                exitCycle = false;
            }
        }

        /// <summary>
        /// Используйте этот метод для запуска меню после того как создадите конструктор и добавите в lsFunction свои методы.
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
