using System;
using System.IO;

namespace homeproject
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Leaderboard[] leaderboard = new Leaderboard[5];
            for (int i = 0; i < leaderboard.Length; i++)
            {
                leaderboard[i] = new Leaderboard("Name", 1000000, "ID");     //Set first value for leaderboard
            }

            MainMenu menu = new MainMenu();
            menu.MenuMain();

            int x = 1, y = 0, time = 0;
            Random rd = new Random();
            string[] array = new string[5];
            array[0] = "map_1.in.txt";
            array[1] = "map_2.in.txt";
            array[2] = "map_3.in.txt";
            array[3] = "map_4.in.txt";
            array[4] = "map_5.in.txt";
            string IDmap = array[rd.Next(0, 4)];
            string Map = File.ReadAllText(IDmap);         //ID map
            Object[,] map = new Object[11, 21];           //create map
            string[] newMap = Map.Split("\r\n");
            Player player = new Player(x, y, "P");        // position of player start
            Player playerEnd = new Player(9, 20, "K");   // position of player end


            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Object clientMap = new Object(newMap[i][j].ToString());
                    map[i, j] = clientMap;                                           //print P into map
                }
            }

            map[player.x, player.y].newObject = player.newObject;
            map[playerEnd.x, playerEnd.y].newObject = playerEnd.newObject;
            Print(map); // print map 

            // control
            while (player.x != 10 && player.y != 20)
            {
                map[player.x, player.y].newObject = " ";                 //replace old P by space
                Move(player, map);
                Console.Clear();
                time += 1;
                map[player.x, player.y].newObject = player.newObject;    //change position of P
                Console.WriteLine($"Timer:" + time);
                Print(map);
            }
            EndGame(player, playerEnd);
            Console.WriteLine($"Completed in " + time + " seconds");
            CheckBoard(leaderboard, time,IDmap);
            for (int i=0; i<leaderboard.Length; i++)
            {
                Console.WriteLine(leaderboard[i].AllData);
            }
            Console.ReadKey();
        }

        static void sort(Leaderboard[] arr)
        {
            int n = arr.Length;
            // One by one move boundary of unsorted subarray 
            for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element in unsorted array 
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j].time < arr[min_idx].time)
                        min_idx = j;
                // Swap the found minimum element with the first element
                int temp1 = arr[min_idx].time;
                arr[min_idx].time = arr[i].time;
                arr[i].time = temp1;
                
                string temp2 = arr[min_idx].name;
                arr[min_idx].name = arr[i].name;
                arr[i].name = temp2.ToString();
                
                string temp3 = arr[min_idx].IDmap;
                arr[min_idx].IDmap = arr[i].IDmap;
                arr[i].IDmap = temp3.ToString();
            }
        }


        static void CheckBoard(Leaderboard[] leaderboards, int time, string IDmap)
        {
            for (int i=0; i<leaderboards.Length; i++)
            {
                if (leaderboards[i].time > time)
                {
                    leaderboards[leaderboards.Length - 1].time = time;          //Assign the new time to the last element in leaderboard
                    leaderboards[leaderboards.Length - 1].IDmap = IDmap;        //Assign the new ID map to the last element in leaderboard
                    Console.Write("Give name: ");
                    string Name = Console.ReadLine();
                    leaderboards[leaderboards.Length - 1].name = Name;          //Assign the new name to the last element in leaderboard
                    sort(leaderboards);                                         //sort all of it 
                    File.WriteAllText("LeaderBoard.txt", leaderboards[i].AllData + "\n");
                    File.AppendAllText("LeaderBoard.txt", leaderboards[i+1].AllData + "\n");
                    File.AppendAllText("LeaderBoard.txt", leaderboards[i+2].AllData + "\n");
                    File.AppendAllText("LeaderBoard.txt", leaderboards[i+3].AllData + "\n");
                    File.AppendAllText("LeaderBoard.txt", leaderboards[i+4].AllData + "\n");
                    break;
                }
            }
        }

        static void Print(Object[,] map)                         //print map
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j].newObject);
                }
                Console.WriteLine();
            }
        }

        static string EndGame(Player player, Player playerEnd)           //print "Completed!" when end game
        {
            string a = "";
            if (player.x == playerEnd.x && player.y == playerEnd.y)
            {
                a = $"Completed";
            }
            return a;
        }

        static ConsoleKeyInfo KeyInput;
        static void Move(Player player, Object[,] map)              //move player
        {
            KeyInput = Console.ReadKey(true);
            switch (KeyInput.Key)
            {
                case ConsoleKey.UpArrow:
                    if (map[player.x - 1, player.y].newObject != "+" && map[player.x - 1, player.y].newObject != "-" && map[player.x - 1, player.y].newObject != "|")    //move without block
                    {
                        player.x--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (map[player.x + 1, player.y].newObject != "+" && map[player.x + 1, player.y].newObject != "-" && map[player.x + 1, player.y].newObject != "|")
                    {
                        player.x++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (map[player.x, player.y - 1].newObject != "+" && map[player.x, player.y - 1].newObject != "-" && map[player.x, player.y - 1].newObject != "|")
                    {
                        player.y--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (map[player.x, player.y + 1].newObject != "+" && map[player.x, player.y + 1].newObject != "-" && map[player.x, player.y + 1].newObject != "|")
                    {
                        player.y++;
                    }
                    break;
            }
        }
    }
}


