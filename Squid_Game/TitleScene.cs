using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Squid_Game
{
    public class TitleScene
    {
        public void Print_TitleScene()
        {
            // 맵 사이즈 설정
            int titleEndLine_Y = 27;
            int titleEndLine_X = 52;
            string[,] titleArray = new string[titleEndLine_Y, titleEndLine_X];

            // 맵 셋팅
            for(int y = 0; y < titleEndLine_Y; y++)
            {
                for (int x = 0; x < titleEndLine_X; x++)
                {
                    // 벽 셋팅
                    if(y == 0 || x == 0 || y == titleEndLine_Y - 1 || x == titleEndLine_X - 1)
                    {
                        titleArray[y, x] = "■";
                        continue;
                    }
                    titleArray[y, x] = "　";
                }
            }

            //// 맵 출력
            //for (int y = 0; y < titleEndLine_Y; y++)
            //{
            //    for (int x = 0; x < titleEndLine_X; x++)
            //    {
            //        // 벽 셋팅
            //        if (titleArray[y, x] == "■")
            //        {
            //            Console.ForegroundColor = ConsoleColor.Magenta;
            //            Console.Write(titleArray[y, x]);
            //            Console.ResetColor();
            //            continue;
            //        }

            //        Console.Write(titleArray[y, x]);
            //    }
            //    Console.WriteLine();
            //}

            //맵 제목 출력

            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(2, 2);
            Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");
            Console.SetCursorPosition(2, 3);
            Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⢹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠈⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠁⠀⠀⢸⣿⣿⣿");
            Console.SetCursorPosition(2, 4);
            Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⡿⠋⠁⠀⠀⠀⠀⠀⠉⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⢸⣿⣿⣿⣿⡿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⢸⣿⣿⣿");
            Console.SetCursorPosition(2, 5);
            Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⣼⣿⠛⠁⠀⠀⠀⠈⠛⢿⣿⣿⣿⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠋⠀⠀⠀⠀⠙⠻⣿⣿⣿⣿⣿⠀⠀⠀⢸⣿⣿⣿");
            Console.SetCursorPosition(2, 6);
            Console.WriteLine("⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⣰⣶⣶⣦⡀⠀⠀⠀⠸⣿⠟⠋⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⢻⣿⡇⠀⠀⠀⣽⠃⠀⠀⠀⣀⡀⠀⠀⠈⠉⠉⠉⠀⠀⠀⠀⣿⣿⣿⣿⣿⡟⠛⠛⠛⠛⠛⠛⠛⠛⡟⠋⠉⠙⣿⠛⠉⠉⢻⡟⠀⠀⠀⢀⣀⠀⠀⠀⢻⣿⣿⣿⣿⠀⠀⠀⢸⣿⣿⣿");
            Console.SetCursorPosition(2, 7);
            Console.WriteLine("⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⣿⣿⣿⣿⠃⠀⠀⠀⠀⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⡇⠀⠀⠀⢸⠆⠀⠀⠘⠿⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⣸⡇⠀⠀⠀⣿⠀⠀⠀⢸⡇⠀⠀⠀⠿⠿⠀⠀⠀⢸⣿⣿⣿⣿⠀⠀⠀⢸⣿⣿⣿");
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠙⠛⠁⠀⠀⠀⠀⢸⣿⣿⣿⣿⡏⠀⠀⠀⠀⠈⢿⣿⣿⣿⣿⡇⠀⠀⠀⢸⣧⡀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣶⣶⡖⠀⠀⠀⠰⠿⠃⠀⠀⠀⣿⠀⠀⠀⢸⣿⡄⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⠀⠀⠀⢸⣿⣿⣿");
            Console.SetCursorPosition(2, 9);
            Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⣿⠏⠀⠀⠀⠀⠀⠀⠈⢻⣿⣿⣿⡗⠀⠀⠀⢸⣿⣿⣶⣤⣤⣤⣶⣾⣿⣿⣿⣿⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠀⢸⣿⣿⣶⣦⣤⠀⠐⠒⠛⠛⠛⠛⠛⠛⠂⠀⠀⢸⣿⣿⣿");
            Console.SetCursorPosition(2, 10);
            Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣦⡔⠀⠀⠀⣤⣶⣿⣿⣿⣿⣿⠏⠀⠀⠀⠀⠆⠀⠀⠀⠀⢻⡿⠿⠇⠀⣀⣀⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣄⣀⣀⣠⣿⣿⣿⣿⣿⣿⡏⠀⠀⠀⢰⣶⣶⣶⡆⠀⠀⠀⣿⠀⠀⠀⢸⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿");
            Console.SetCursorPosition(2, 11);
            Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⣿⣿⣿⣿⣿⣿⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠀⠀⠀⣠⣿⣿⣿⣿⡇⠀⠀⠀⣿⠀⠀⠀⢸⣿⣿⣿⣿⣿⠀⠀⠀⠀⢀⣀⣀⣀⠀⠀⠀⠀⢸⣿⣿⣿");
            Console.SetCursorPosition(2, 12);
            Console.WriteLine("⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣇⣀⣀⣀⣀⣀⣀⣀⣀⣀⡀⠀⠀⠀⣠⣤⡀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⢸⣿⣿⣿⣿⣿⠀⠀⠀⠀⢸⣿⣿⣿⠂⠀⠀⠀⢸⣿⣿⣿");
            Console.SetCursorPosition(2, 13);
            Console.WriteLine("⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣇⠀⠀⠀⠙⠛⠁⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣄⣀⣀⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⢸⣿⣿⣿⣿⣿⠀⠀⠀⠀⠘⠛⠻⠿⡄⠀⠀⠀⢸⣿⣿⣿");
            Console.SetCursorPosition(2, 14);
            Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⡀⠀⠀⠀⠀⢀⣠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⢸⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿");
            Console.SetCursorPosition(2, 15);
            Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⣶⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣶⣾⣿⣿⣿⣿⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⢸⣿⣿⣿");
            Console.SetCursorPosition(2, 16);
            Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");
            Console.ResetColor();
        }
        
    }

    
}
