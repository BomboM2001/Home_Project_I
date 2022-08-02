using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace homeproject
{
    class MainMenu 
    {
        public int MenuSelected = 0;
        public string[] MenuList = new string[]
        {
            "New Game","Leaderboard","Help","Exit"
        };
        public bool exitMenu = false;
        public void MenuMain()
        {
            while (exitMenu == false)
            {
                Console.Clear();
                MainMenuColor(MenuSelected);
                MainMenuList();
            }
        }
        public void MainMenuColor(int selectedMenu)
        {
            for (int i=0; i<MenuList.Length; i++)
            {
                if (i == selectedMenu)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.SetCursorPosition(0, 0+i);
                Console.WriteLine(MenuList[i]);
            }
        }

        public void MainMenuList()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    if (MenuSelected < MenuList.Length - 1)
                        MenuSelected++;
                    else
                        MenuSelected = 0;
                    break;
                case ConsoleKey.UpArrow:
                    if (MenuSelected > 0)
                        MenuSelected--;
                    else
                        MenuSelected = MenuList.Length - 1;
                    break;
                case ConsoleKey.LeftArrow:

                    break;
                case ConsoleKey.RightArrow:

                    break;
                case ConsoleKey.Enter:
                    switch (MenuSelected)
                    {
                        case 0:
                            exitMenu = true;
                            break;
                        case 1:
                            string[] data = File.ReadAllLines("LeaderBoard.txt");
                            for (int i=0; i<data.Length;i++)
                            {
                                Console.WriteLine(data[i]);
                            }
                            Console.ReadKey();
                            break;
                        case 2:
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                    }
                    break;
            }
        }

    }
}
