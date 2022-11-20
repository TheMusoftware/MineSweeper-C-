using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MineSweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Get name and Welcome screen
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("WELCOME!!! {0}", name);
            Console.WriteLine("Select a level \n1-Easy \n2-Hard \n3-Extreme");
            int level = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Let me for set mines :)");
            Thread.Sleep(3000);
            
            for (int i = 3; i > 0; i--)
            {
                Console.Clear();
                Console.WriteLine("Your game will be start in {0} second...",i);    
                Thread.Sleep(1000);
               
                
                
            }
            Console.WriteLine("Start!!!");
            Thread.Sleep(300);
            Console.Clear();



            //---------->Algorithm of the game

            //Set level
            switch (level)
            {
                case 1:
                    level = 5;
                    break;
                case 2:
                    level = 10;
                    break;
                default:
                    level = 15;
                    break;
            }

            //Point and others
            int point = 0;
            int minesCount = 0;
            int remainMines;
            int nonMinesCount = 25 - level;
            int randomLines, randomLocation;
            int maxPoint = nonMinesCount * 10;
            int lives = 3;

            //Arrays
            string[] firstLine = new string[5];
            string[] secondLine = new string[5];
            string[] thirdLine = new string[5];
            string[] fourthLine = new string[5];
            string[] fifthLine = new string[5];

            bool[] firstLineM = new bool[5];
            bool[] secondLineM = new bool[5];
            bool[] thirdLineM = new bool[5];
            bool[] fourthLineM = new bool[5];
            bool[] fifthLineM = new bool[5];

            //Fill Arrays
            for (int i = 0; i < firstLine.Length; i++)
            {
                firstLine[i] = "#";
                secondLine[i] = "#";
                thirdLine[i] = "#";
                fourthLine[i] = "#";
                fifthLine[i] = "#";


            }

            //------------------>Set mines
            Random random = new Random();


            do
            {
                randomLines = random.Next(5);
                randomLocation = random.Next(5);


                switch (randomLines)
                {
                    case 0:
                        if (!firstLineM[randomLocation])
                        {
                            firstLineM[randomLocation] = true;
                        }
                        else
                        {
                            minesCount--;
                        }
                        break;
                    case 1:
                        if (!secondLineM[randomLocation])
                        {
                            secondLineM[randomLocation] = true;
                        }
                        else
                        {
                            minesCount--;
                        }
                        break;

                    case 2:
                        if (!thirdLineM[randomLocation])
                        {
                            thirdLineM[randomLocation] = true;
                        }
                        else
                        {
                            minesCount--;
                        }
                        break;

                    case 3:
                        if (!fourthLineM[randomLocation])
                        {
                            fourthLineM[randomLocation] = true;
                        }
                        else
                        {
                            minesCount--;
                        }
                        break;
                    case 4:
                        if (!fifthLineM[randomLocation])
                        {
                            fifthLineM[randomLocation] = true;
                        }
                        else
                        {
                            minesCount--;
                        }
                        break;


                    default:
                        break;
                }
                minesCount++;

            } while (minesCount != level);
            remainMines = minesCount;
            //Algorithm

            //Lines Extensions
            int[] selected = new int[100];
            int selectedCount = 0, slc;

            for (int i = 0; i <= nonMinesCount; i++)
            {



                Console.Write("{0,36}", " ");
                for (int a = 1; a < 6; a++)
                {
                    Console.Write("{0,2}", a);
                }

                Console.WriteLine();
                Console.Write("{0,37}", " 1 ");
                for (int b = 0; b < firstLine.Length; b++)
                {
                    Console.Write(firstLine[b] + " ");

                }
                Console.WriteLine();
                Console.Write("{0,37}", " 2 ");
                for (int c = 0; c < secondLine.Length; c++)
                {
                    Console.Write(secondLine[c] + " ");

                }
                Console.WriteLine();
                Console.Write("{0,37}", " 3 ");
                for (int d = 0; d < thirdLine.Length; d++)
                {
                    Console.Write(thirdLine[d] + " ");

                }
                Console.WriteLine();
                Console.Write("{0,37}", " 4 ");
                for (int e = 0; e < fourthLine.Length; e++)
                {
                    Console.Write(fourthLine[e] + " ");

                }
                Console.WriteLine();
                Console.Write("{0,37}", " 5 ");
                for (int f = 0; f < fifthLine.Length; f++)
                {
                    Console.Write(fifthLine[f] + " ");

                }

                //Point
                string space = " ";
                point = i * 10;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("###################{0,41}###################", space);
                Console.WriteLine("#                 #{0,41}#                 #", space);
                Console.WriteLine("#                 #{0,41}#                 #", space);
                Console.WriteLine("    Point : {0,-50}Total Mines: {1}      ", point, level);
                Console.WriteLine("    Lives : {0,-50}Remain Mines {1}      ", lives, remainMines);
                Console.WriteLine("#                 #{0,41}#                 #", space);
                Console.WriteLine("#                 #{0,41}#                 #", space);
                Console.WriteLine("###################{0,41}###################", space);

                //Get Lines and column
                int x = 1, y = 1;
                bool getInfo = false;
                bool checkSame = false;


                do
                {
                    checkSame = false;

                    Console.Write("\nSelect line: ");
                    x = Int32.Parse(Console.ReadLine());
                    Console.Write("\nSelect column: ");
                    y = Convert.ToInt32(Console.ReadLine());
                    if (x < 1 || y < 1 || x > 5 || y > 5)
                    {
                        Console.WriteLine("\n!!!Please enter between and 1-5");
                        continue;
                    }

                    selected[selectedCount] = x;
                    selected[selectedCount + 1] = y;


                    //Check they are same
                    for (slc = 98; slc >= 0; slc -= 2)
                    {
                        if (!(slc == selectedCount))
                        {

                            if (selected[slc] == x && selected[slc + 1] == y)
                            {
                                checkSame = true;
                                Console.WriteLine("Ohhhh dude!! You're the most forgetful person in the world." +
                                    "\nYou have already selected this location ( {0},{1} )", x, y);
                                Console.WriteLine("\nPlease re-enter your location");
                                continue;
                            }
                        }

                    }
                    selectedCount += 2;


                    Console.WriteLine();




                } while (x < 1 || y < 1 || x > 5 || y > 5 || checkSame);

                y--;
                switch (x)
                {
                    case 1:
                        if (firstLineM[y])
                        {
                            firstLine[y] = "M";
                            getInfo = true;
                            break;
                        }
                        else
                        {
                            firstLine[y] = " ";
                        }
                        break;

                    case 2:
                        if (secondLineM[y])
                        {
                            secondLine[y] = "M";

                            getInfo = true;
                            break;
                        }
                        else
                        {
                            secondLine[y] = " ";
                        }
                        break;

                    case 3:
                        if (thirdLineM[y])
                        {
                            thirdLine[y] = "M";
                            getInfo = true;
                            break;
                        }
                        else
                        {
                            thirdLine[y] = " ";
                        }
                        break;

                    case 4:
                        if (fourthLineM[y])
                        {
                            fourthLine[y] = "M";
                            getInfo = true;
                            break;
                        }
                        else
                        {
                            fourthLine[y] = " ";
                        }
                        break;

                    case 5:
                        if (fifthLineM[y])
                        {
                            fifthLine[y] = "M";
                            getInfo = true;
                            break;
                        }
                        else
                        {
                            fifthLine[y] = " ";
                        }
                        break;
                    default:
                        break;
                }
                Console.Clear();

                if (getInfo)
                {
                    i--;
                    lives--;
                    remainMines--;

                    if (lives <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\n{2,25}Game OVER {1}, Mines WIN!!! \n" +
                            "{2,25}Point: {0}", point, name,space);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("               -=====-                         -=====-\r\n                _..._                           _..._\r\n              .~     `~.                     .~`     ~.\r\n      ,_     /          }                   {          \\     _,\r\n     ,_\\'--, \\   _.'`~~/                     \\~~`'._   / ,--'/_,\r\n      \\'--,_`{_,}    -(                       )-    {,_}`_,--'/\r\n       '.`-.`\\;--,___.'_                     _'.___,--;/`.-`.'\r\n         '._`/    |_ _{@}                   {@}_ _|    \\`_.'\r\n            /     ` |-';/           _       \\;'-| `     \\\r\n           /   \\    /  |       _   {@}_      |  \\    /   \\\r\n          /     '--;_       _ {@}  _Y{@}        _;--'     \\\r\n         _\\          `\\    {@}\\Y/_{@} Y/      /`          /_\r\n        / |`-.___.    /    \\Y/\\|{@}Y/\\|//     \\    .___,-'| \\\r\n^^^^^^^^^^`--`------'`--`^^^^^^^^^^^^^^^^^^^^^^^^^`--`'------`--`^^^^^^^");


                        break;
                    }


                }
                if (maxPoint - 10 == point)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n---------->Congratulations<----------" + "\n\nYou successfully escaped from all the mines, and this made you the best player");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n       {0} is the best player for this game thanks for your time...  ", name);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("/         \\\r\n" +
                        "    / _ \\\r\n" +
                        "   | / \\ |\r\n" +
                        "   ||   || _______\r\n" +
                        "   ||   || |\\     \\\r\n" +
                        "   ||   || ||\\     \\\r\n" +
                        "   ||   || || \\    |\r\n" +
                        "   ||   || ||  \\__/\r\n" +
                        "   ||   || ||   ||\r\n" +
                        "    \\\\_/ \\_/ \\_//\r\n" +
                        "   /   _     _   \\                  Don't forget to follow the white rabbit    \r\n" +
                        "  /               \\\r\n" +
                        "  |    O     O    |\r\n" +
                        "  |   \\  ___  /   |\r\n" +
                        " /     \\ \\_/ /     \\\r\n" +
                        "/  -----  |  -----  \\\r\n" +
                        "|     \\__/|\\__/     |\r\n" +
                        "\\       |_|_|       /\r\n" +
                        " \\_____       _____/\r\n" +
                        "       \\     /\r\n" +
                        "       |     |");
                    break;
                }








            }


            Console.ReadLine();
        }
    }
}
