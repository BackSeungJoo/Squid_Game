using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Squid_Game
{
    public class Game3  // 달고나 뽑기
    {
        public bool PlayGame_3(ref int player_Win_Count)
        {
            Console.Clear();

            // 변수 생성
            int mapSize_Game3 = 20;
            string[,] game2_map = new string[mapSize_Game3, mapSize_Game3];

            int player_PosY = 2;
            int player_PosX = 2;

            int change_Shape = 0;
            bool is_Sugar = false;
            string tempShape = default;
            bool is_game = true;

            int moveCount = 0;
            int loseCount = 57;
            // 변수 생성 end

            // 초기 맵 세팅
            Set_Map_Game3(ref game2_map, mapSize_Game3, ref player_PosY, ref player_PosX);
            Heart_Shape(ref game2_map, mapSize_Game3);

            while (is_game)
            {
                // 맵 출력
                Console.SetCursorPosition(0, 0);
                Print_Map_Game3(game2_map, mapSize_Game3);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(45, 1);
                Console.WriteLine("      달고나 게임에 오신 것을 환영합니다.");
                Console.SetCursorPosition(45, 3);
                Console.WriteLine("[W A S D] 를 이용해 모든 발판을 활성화 시키면 승리");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(45, 6);
                Console.WriteLine("이동 횟수 [{0}] 안에 달고나를 완성하세요.", loseCount);
                Console.SetCursorPosition(45, 7);
                Console.WriteLine("현재 이동 횟수 [{0}]", moveCount);
                Console.ResetColor();

                // 유저 이동
                User_Move(ref game2_map, ref player_PosY, ref player_PosX, ref change_Shape, ref is_Sugar, ref tempShape);
                moveCount++;

                // 패배 조건 확인
                decision_Lose(moveCount, loseCount, ref is_game);

                // 승리 조건 확인
                decision_Win(game2_map, mapSize_Game3, ref is_game, ref player_Win_Count);
            }

            return false;
        }

        // 맵 셋팅
        public void Set_Map_Game3(ref string[,] game2_map, int mapSize_Game3, ref int player_PosY, ref int player_PosX)
        {
            for (int y = 0; y < mapSize_Game3; y++)
            {
                for (int x = 0; x < mapSize_Game3; x++)
                {
                    // 벽 생성
                    if ((y == 0) || (x == 0) || (y == mapSize_Game3 - 1) || (x == mapSize_Game3 - 1))
                    {
                        game2_map[y, x] = "■";
                        continue;
                    }

                    // 플레이어 생성
                    if ((y == player_PosY) && (x == player_PosX))
                    {
                        game2_map[y, x] = "◎";
                        continue;
                    }

                    game2_map[y, x] = "　";
                }
            }
        }

        // 하트 달고나
        public void Heart_Shape(ref string[,] game2_map, int mapSize_Game3)
        {
            for (int y = 0; y < mapSize_Game3; y++)
            {
                for (int x = 0; x < mapSize_Game3; x++)
                {
                    // 한줄 씩 하트 조건 설정
                    if ((y == 4) && ((x == 6) || (x == 7) || (x == 12) || (x == 13)))
                    {
                        game2_map[y, x] = "□";
                        continue;
                    }
                    // 한줄 씩 하트 조건 설정
                    if ((y == 5) && ((x == 5) || (x == 8) || (x == 11) || (x == 14)))
                    {
                        game2_map[y, x] = "□";
                        continue;
                    }
                    // 한줄 씩 하트 조건 설정
                    if ((y == 6) && ((x == 4) || (x == 9) || (x == 10) || (x == 15)))
                    {
                        game2_map[y, x] = "□";
                        continue;
                    }
                    // 한줄 씩 하트 조건 설정
                    if (((7 <= y) && (y <= 10)) && ((x == 3) || (x == 16)))
                    {
                        game2_map[y, x] = "□";
                        continue;
                    }
                    // 한줄 씩 하트 조건 설정
                    if ((y == 11) && ((x == 4) || (x == 15)))
                    {
                        game2_map[y, x] = "□";
                        continue;
                    }
                    // 한줄 씩 하트 조건 설정
                    if ((y == 12) && ((x == 5) || (x == 14)))
                    {
                        game2_map[y, x] = "□";
                        continue;
                    }
                    // 한줄 씩 하트 조건 설정
                    if ((y == 13) && ((x == 6) || (x == 13)))
                    {
                        game2_map[y, x] = "□";
                        continue;
                    }
                    // 한줄 씩 하트 조건 설정
                    if ((y == 14) && ((x == 7) || (x == 12)))
                    {
                        game2_map[y, x] = "□";
                        continue;
                    }
                    if ((y == 15) && ((8 <= x) && (x <= 11)))
                    {
                        game2_map[y, x] = "□";
                        continue;
                    }
                }
            }
        }
       
        // 맵 출력
        public void Print_Map_Game3(string[,] game2_map, int mapSize_Game3)
        {
            for (int y = 0; y < mapSize_Game3; y++)
            {
                for (int x = 0; x < mapSize_Game3; x++)
                {
                    // 벽 생성
                    if (game2_map[y, x] == "■")
                    {
                        Console.Write(game2_map[y, x]);
                        continue;
                    }

                    if (game2_map[y, x] == "□")
                    {
                        Console.Write(game2_map[y, x]);
                        continue;
                    }

                    // 벽 앞 색상 변경
                    if ((y == 1) || (x == 1) || (y == mapSize_Game3 - 2) || (x == mapSize_Game3 - 2))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(game2_map[y, x]);
                        Console.ResetColor();
                        continue;
                    }

                    // 바닥 밟으면 색상 변경
                    if (game2_map[y, x] == "▣")
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(game2_map[y, x]);
                        Console.ResetColor();
                        continue;
                    }
                    // 플레이어 색상 변경
                    if (game2_map[y, x] == "◎")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(game2_map[y, x]);
                        Console.ResetColor();
                        continue;
                    }

                    Console.Write(game2_map[y, x]);
                }
                Console.WriteLine();
            }
        }


        // 플레이어 이동
        static public void User_Move(ref string[,] game2_map, ref int player_PosY, ref int player_PosX, ref int change_Shape, ref bool is_Sugar, ref string tempShape)
        {
            ConsoleKey user_Move = Console.ReadKey(true).Key;

            // A 입력 (왼쪽이동)
            if (user_Move == ConsoleKey.A)
            {
                // 벽일 땐 패스
                if (game2_map[player_PosY, player_PosX - 2] != "■")
                {
                    // 내가 지금 달고나 모양을 밟고 있나?
                    if (is_Sugar == true)   // yes
                    {
                        // 조건 1.내 뒤에 체크된게 있고 내 앞에 체크된게 있을 때
                        if (((game2_map[player_PosY, player_PosX + 1] == "▣") || (game2_map[player_PosY, player_PosX + 1] == "□"))
                            && ((game2_map[player_PosY, player_PosX - 1] == "▣") || (game2_map[player_PosY, player_PosX - 1] == "□")))
                        {
                            Swap_Move_A(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY, player_PosX + 1] = "▣";
                            is_Sugar = true;
                            Console.WriteLine("1");
                        }
                        // 조건 2.내 뒤에 체크된게 있고 내 앞에 체크된게 없을 때
                        else if (((game2_map[player_PosY, player_PosX + 1] == "▣") || (game2_map[player_PosY, player_PosX + 1] == "□")) && (game2_map[player_PosY, player_PosX - 1] == "　"))
                        {
                            // 스왑하고 내 뒤에있는 걸로 내가 빠져나온 공간을 채워넣음
                            tempShape = game2_map[player_PosY, player_PosX + 1];
                            Swap_Move_A(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY, player_PosX + 1] = "▣";
                            is_Sugar = false;
                            Console.WriteLine("2");
                        }
                        // 조건 3.내 뒤에 체크된게 없고 내 앞에 체크된게 있을 때
                        else if ((game2_map[player_PosY, player_PosX + 1] == "　") && ((game2_map[player_PosY, player_PosX - 1] == "▣") || (game2_map[player_PosY, player_PosX - 1] == "□")))
                        {
                            // 스왑하고 뒤에 있는거 삭제
                            Swap_Move_A(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY, player_PosX + 1] = "▣";
                            is_Sugar = true;
                            Console.WriteLine("3");
                        }
                        // 조건 4.내 뒤에 체크된게 없고 내 앞에 체크된게 없을 때
                        else if ((game2_map[player_PosY, player_PosX + 1] == "　") && (game2_map[player_PosY, player_PosX - 1] == "　"))
                        {
                            Swap_Move_A(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY, player_PosX + 1] = "▣";
                            is_Sugar = false;
                            Console.WriteLine("4");
                        }
                    }

                    else
                    {
                        // 조건 1.내 뒤에 체크된게 있고 내 앞에 체크된게 있을 때
                        if (((game2_map[player_PosY, player_PosX + 1] == "▣") || (game2_map[player_PosY, player_PosX + 1] == "□"))
                            && ((game2_map[player_PosY, player_PosX - 1] == "▣") || (game2_map[player_PosY, player_PosX - 1] == "□")))
                        {
                            Swap_Move_A(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY, player_PosX + 1] = "▣";
                            is_Sugar = true;
                            Console.WriteLine("5");
                        }
                        // 조건 2.내 뒤에 체크된게 있고 내 앞에 체크된게 없을 때
                        else if (((game2_map[player_PosY, player_PosX + 1] == "▣") || (game2_map[player_PosY, player_PosX + 1] == "□")) && (game2_map[player_PosY, player_PosX - 1] == "　"))
                        {
                            // 스왑하고 내 뒤에있는 걸로 내가 빠져나온 공간을 채워넣음
                            Swap_Move_A(ref game2_map, ref player_PosY, ref player_PosX);
                            is_Sugar = false;
                            Console.WriteLine("6");
                        }
                        // 조건 3.내 뒤에 체크된게 없고 내 앞에 체크된게 있을 때
                        else if ((game2_map[player_PosY, player_PosX + 1] == "　") && ((game2_map[player_PosY, player_PosX - 1] == "▣") || (game2_map[player_PosY, player_PosX - 1] == "□")))
                        {
                            // 스왑하고 뒤에 있는거 삭제
                            Swap_Move_A(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY, player_PosX + 1] = "　";
                            tempShape = "▣";
                            is_Sugar = true;
                            Console.WriteLine("7");
                        }
                        // 조건 4.내 뒤에 체크된게 없고 내 앞에 체크된게 없을 때
                        else if ((game2_map[player_PosY, player_PosX + 1] == "　") && (game2_map[player_PosY, player_PosX - 1] == "　"))
                        {
                            Swap_Move_A(ref game2_map, ref player_PosY, ref player_PosX);
                            is_Sugar = false;
                            Console.WriteLine("8");
                        }
                    }
                }

                else { /*pass*/ }
            }

            // D 입력 (오른쪽이동)
            if (user_Move == ConsoleKey.D)
            {
                // 벽일 땐 패스
                if (game2_map[player_PosY, player_PosX + 2] != "■")
                {
                    // 내가 지금 달고나 모양을 밟고 있나?
                    if (is_Sugar == true)   // yes
                    {
                        // 조건 1.내 뒤에 체크된게 있고 내 앞에 체크된게 있을 때
                        if (((game2_map[player_PosY, player_PosX - 1] == "▣") || (game2_map[player_PosY, player_PosX - 1] == "□"))
                            && ((game2_map[player_PosY, player_PosX + 1] == "▣") || (game2_map[player_PosY, player_PosX + 1] == "□")))
                        {
                            Swap_Move_D(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY, player_PosX - 1] = "▣";
                            is_Sugar = true;
                            Console.WriteLine("1");
                        }
                        // 조건 2.내 뒤에 체크된게 있고 내 앞에 체크된게 없을 때
                        else if (((game2_map[player_PosY, player_PosX - 1] == "▣") || (game2_map[player_PosY, player_PosX - 1] == "□")) && (game2_map[player_PosY, player_PosX + 1] == "　"))
                        {
                            // 스왑하고 내 뒤에있는 걸로 내가 빠져나온 공간을 채워넣음
                            tempShape = game2_map[player_PosY, player_PosX - 1];
                            Swap_Move_D(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY, player_PosX - 1] = "▣";
                            is_Sugar = false;
                            Console.WriteLine("2");
                        }
                        // 조건 3.내 뒤에 체크된게 없고 내 앞에 체크된게 있을 때
                        else if ((game2_map[player_PosY, player_PosX - 1] == "　") && ((game2_map[player_PosY, player_PosX + 1] == "▣") || (game2_map[player_PosY, player_PosX + 1] == "□")))
                        {
                            // 스왑하고 뒤에 있는거 삭제
                            Swap_Move_D(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY, player_PosX - 1] = "▣";
                            is_Sugar = true;
                            Console.WriteLine("3");
                        }
                        // 조건 4.내 뒤에 체크된게 없고 내 앞에 체크된게 없을 때
                        else if ((game2_map[player_PosY, player_PosX - 1] == "　") && (game2_map[player_PosY, player_PosX + 1] == "　"))
                        {
                            Swap_Move_D(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY, player_PosX - 1] = "▣";
                            is_Sugar = false;
                            Console.WriteLine("4");
                        }
                    }

                    else
                    {
                        // 조건 1.내 뒤에 체크된게 있고 내 앞에 체크된게 있을 때
                        if (((game2_map[player_PosY, player_PosX - 1] == "▣") || (game2_map[player_PosY, player_PosX - 1] == "□"))
                            && ((game2_map[player_PosY, player_PosX + 1] == "▣") || (game2_map[player_PosY, player_PosX + 1] == "□")))
                        {
                            Swap_Move_D(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY, player_PosX + 1] = "▣";
                            is_Sugar = true;
                            Console.WriteLine("5");
                        }
                        // 조건 2.내 뒤에 체크된게 있고 내 앞에 체크된게 없을 때
                        else if (((game2_map[player_PosY, player_PosX - 1] == "▣") || (game2_map[player_PosY, player_PosX - 1] == "□")) && (game2_map[player_PosY, player_PosX + 1] == "　"))
                        {
                            // 스왑하고 내 뒤에있는 걸로 내가 빠져나온 공간을 채워넣음
                            Swap_Move_D(ref game2_map, ref player_PosY, ref player_PosX);
                            is_Sugar = false;
                            Console.WriteLine("6");
                        }
                        // 조건 3.내 뒤에 체크된게 없고 내 앞에 체크된게 있을 때
                        else if ((game2_map[player_PosY, player_PosX - 1] == "　") && ((game2_map[player_PosY, player_PosX + 1] == "▣") || (game2_map[player_PosY, player_PosX + 1] == "□")))
                        {
                            // 스왑하고 뒤에 있는거 삭제
                            Swap_Move_D(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY, player_PosX - 1] = "　";
                            tempShape = "▣";
                            is_Sugar = true;
                            Console.WriteLine("7");
                        }
                        // 조건 4.내 뒤에 체크된게 없고 내 앞에 체크된게 없을 때
                        else if ((game2_map[player_PosY, player_PosX - 1] == "　") && (game2_map[player_PosY, player_PosX + 1] == "　"))
                        {
                            Swap_Move_D(ref game2_map, ref player_PosY, ref player_PosX);
                            is_Sugar = false;
                            Console.WriteLine("8");
                        }
                    }
                }
                else { /*pass*/ }
            }

            // W 입력 (위쪽이동)
            if (user_Move == ConsoleKey.W)
            {
                // 벽일 땐 패스
                if (game2_map[player_PosY - 2, player_PosX] != "■")
                {
                    // 내가 지금 달고나 모양을 밟고 있나?
                    if (is_Sugar == true)   // yes
                    {
                        // 조건 1.내 뒤에 체크된게 있고 내 앞에 체크된게 있을 때
                        if (((game2_map[player_PosY + 1, player_PosX] == "▣") || (game2_map[player_PosY + 1, player_PosX] == "□"))
                            && ((game2_map[player_PosY - 1, player_PosX] == "▣") || (game2_map[player_PosY - 1, player_PosX] == "□")))
                        {
                            Swap_Move_W(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY + 1, player_PosX] = "▣";
                            is_Sugar = true;
                            Console.WriteLine("1");
                        }
                        // 조건 2.내 뒤에 체크된게 있고 내 앞에 체크된게 없을 때
                        else if (((game2_map[player_PosY + 1, player_PosX] == "▣") || (game2_map[player_PosY + 1, player_PosX] == "□")) && (game2_map[player_PosY - 1, player_PosX] == "　"))
                        {
                            // 스왑하고 내 뒤에있는 걸로 내가 빠져나온 공간을 채워넣음
                            tempShape = game2_map[player_PosY, player_PosX + 1];
                            Swap_Move_W(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY + 1, player_PosX] = "▣";
                            is_Sugar = false;
                            Console.WriteLine("2");
                        }
                        // 조건 3.내 뒤에 체크된게 없고 내 앞에 체크된게 있을 때
                        else if ((game2_map[player_PosY + 1, player_PosX] == "　") && ((game2_map[player_PosY - 1, player_PosX] == "▣") || (game2_map[player_PosY - 1, player_PosX] == "□")))
                        {
                            // 스왑하고 뒤에 있는거 삭제
                            Swap_Move_W(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY + 1, player_PosX] = "▣";
                            is_Sugar = true;
                            Console.WriteLine("3");
                        }
                        // 조건 4.내 뒤에 체크된게 없고 내 앞에 체크된게 없을 때
                        else if ((game2_map[player_PosY + 1, player_PosX] == "　") && (game2_map[player_PosY - 1, player_PosX] == "　"))
                        {
                            Swap_Move_W(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY + 1, player_PosX] = "▣";
                            is_Sugar = false;
                            Console.WriteLine("4");
                        }
                    }

                    else
                    {
                        // 조건 1.내 뒤에 체크된게 있고 내 앞에 체크된게 있을 때
                        if (((game2_map[player_PosY + 1, player_PosX] == "▣") || (game2_map[player_PosY + 1, player_PosX] == "□"))
                            && ((game2_map[player_PosY - 1, player_PosX] == "▣") || (game2_map[player_PosY - 1, player_PosX] == "□")))
                        {
                            Swap_Move_W(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY + 1, player_PosX] = "▣";
                            is_Sugar = true;
                            Console.WriteLine("5");
                        }
                        // 조건 2.내 뒤에 체크된게 있고 내 앞에 체크된게 없을 때
                        else if (((game2_map[player_PosY + 1, player_PosX] == "▣") || (game2_map[player_PosY + 1, player_PosX] == "□")) && (game2_map[player_PosY - 1, player_PosX] == "　"))
                        {
                            // 스왑하고 내 뒤에있는 걸로 내가 빠져나온 공간을 채워넣음
                            Swap_Move_W(ref game2_map, ref player_PosY, ref player_PosX);
                            is_Sugar = false;
                            Console.WriteLine("6");
                        }
                        // 조건 3.내 뒤에 체크된게 없고 내 앞에 체크된게 있을 때
                        else if ((game2_map[player_PosY + 1, player_PosX] == "　") && ((game2_map[player_PosY - 1, player_PosX] == "▣") || (game2_map[player_PosY - 1, player_PosX] == "□")))
                        {
                            // 스왑하고 뒤에 있는거 삭제
                            Swap_Move_W(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY + 1, player_PosX] = "　";
                            tempShape = "▣";
                            is_Sugar = true;
                            Console.WriteLine("7");
                        }
                        // 조건 4.내 뒤에 체크된게 없고 내 앞에 체크된게 없을 때
                        else if ((game2_map[player_PosY + 1, player_PosX] == "　") && (game2_map[player_PosY - 1, player_PosX] == "　"))
                        {
                            Swap_Move_W(ref game2_map, ref player_PosY, ref player_PosX);
                            is_Sugar = false;
                            Console.WriteLine("8");
                        }
                    }
                }
                else { /*pass*/ }
            }

            // S 입력 (아래쪽이동)
            if (user_Move == ConsoleKey.S)
            {
                // 벽일 땐 패스
                if (game2_map[player_PosY + 2, player_PosX] != "■")
                {
                    // 내가 지금 달고나 모양을 밟고 있나?
                    if (is_Sugar == true)   // yes
                    {
                        // 조건 1.내 뒤에 체크된게 있고 내 앞에 체크된게 있을 때
                        if (((game2_map[player_PosY - 1, player_PosX] == "▣") || (game2_map[player_PosY - 1, player_PosX] == "□"))
                            && ((game2_map[player_PosY + 1, player_PosX] == "▣") || (game2_map[player_PosY + 1, player_PosX] == "□")))
                        {
                            Swap_Move_S(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY - 1, player_PosX] = "▣";
                            is_Sugar = true;
                            Console.WriteLine("1");
                        }
                        // 조건 2.내 뒤에 체크된게 있고 내 앞에 체크된게 없을 때
                        else if (((game2_map[player_PosY - 1, player_PosX] == "▣") || (game2_map[player_PosY - 1, player_PosX] == "□")) && (game2_map[player_PosY + 1, player_PosX] == "　"))
                        {
                            // 스왑하고 내 뒤에있는 걸로 내가 빠져나온 공간을 채워넣음
                            tempShape = game2_map[player_PosY - 1, player_PosX];
                            Swap_Move_S(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY - 1, player_PosX] = "▣";
                            is_Sugar = false;
                            Console.WriteLine("2");
                        }
                        // 조건 3.내 뒤에 체크된게 없고 내 앞에 체크된게 있을 때
                        else if ((game2_map[player_PosY - 1, player_PosX] == "　") && ((game2_map[player_PosY + 1, player_PosX] == "▣") || (game2_map[player_PosY + 1, player_PosX] == "□")))
                        {
                            // 스왑하고 뒤에 있는거 삭제
                            Swap_Move_S(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY - 1, player_PosX] = "▣";
                            is_Sugar = true;
                            Console.WriteLine("3");
                        }
                        // 조건 4.내 뒤에 체크된게 없고 내 앞에 체크된게 없을 때
                        else if ((game2_map[player_PosY - 1, player_PosX] == "　") && (game2_map[player_PosY + 1, player_PosX] == "　"))
                        {
                            Swap_Move_S(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY - 1, player_PosX] = "▣";
                            is_Sugar = false;
                            Console.WriteLine("4");
                        }
                    }

                    else
                    {
                        // 조건 1.내 뒤에 체크된게 있고 내 앞에 체크된게 있을 때
                        if (((game2_map[player_PosY - 1, player_PosX] == "▣") || (game2_map[player_PosY - 1, player_PosX] == "□"))
                            && ((game2_map[player_PosY + 1, player_PosX] == "▣") || (game2_map[player_PosY + 1, player_PosX] == "□")))
                        {
                            Swap_Move_S(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY + 1, player_PosX] = "▣";
                            is_Sugar = true;
                            Console.WriteLine("5");
                        }
                        // 조건 2.내 뒤에 체크된게 있고 내 앞에 체크된게 없을 때
                        else if (((game2_map[player_PosY - 1, player_PosX] == "▣") || (game2_map[player_PosY - 1, player_PosX] == "□")) && (game2_map[player_PosY + 1, player_PosX] == "　"))
                        {
                            // 스왑하고 내 뒤에있는 걸로 내가 빠져나온 공간을 채워넣음
                            Swap_Move_S(ref game2_map, ref player_PosY, ref player_PosX);
                            is_Sugar = false;
                            Console.WriteLine("6");
                        }
                        // 조건 3.내 뒤에 체크된게 없고 내 앞에 체크된게 있을 때
                        else if ((game2_map[player_PosY - 1, player_PosX] == "　") && ((game2_map[player_PosY + 1, player_PosX] == "▣") || (game2_map[player_PosY + 1, player_PosX] == "□")))
                        {
                            // 스왑하고 뒤에 있는거 삭제
                            Swap_Move_S(ref game2_map, ref player_PosY, ref player_PosX);
                            game2_map[player_PosY - 1, player_PosX] = "　";
                            tempShape = "▣";
                            is_Sugar = true;
                            Console.WriteLine("7");
                        }
                        // 조건 4.내 뒤에 체크된게 없고 내 앞에 체크된게 없을 때
                        else if ((game2_map[player_PosY - 1, player_PosX] == "　") && (game2_map[player_PosY + 1, player_PosX] == "　"))
                        {
                            Swap_Move_S(ref game2_map, ref player_PosY, ref player_PosX);
                            is_Sugar = false;
                            Console.WriteLine("8");
                        }
                    }
                }
                else { /*pass*/ }

                
            }
        }

        // A 이동
        static public void Swap_Move_A(ref string[,] game2_map, ref int player_PosY, ref int player_PosX)
        {
            // 벽이 아닐 경우
            if (game2_map[player_PosY, player_PosX - 1] != "■")
            {
                string temp_ = game2_map[player_PosY, player_PosX];
                game2_map[player_PosY, player_PosX] = game2_map[player_PosY, player_PosX - 1];
                game2_map[player_PosY, player_PosX - 1] = temp_;
                player_PosX--;
            }
            else { /*pass*/ }
        }
        // D 이동
        static public void Swap_Move_D(ref string[,] game2_map, ref int player_PosY, ref int player_PosX)
        {
            // 벽이 아닐 경우
            if (game2_map[player_PosY, player_PosX + 1] != "■")
            {
                string temp_ = game2_map[player_PosY, player_PosX];
                game2_map[player_PosY, player_PosX] = game2_map[player_PosY, player_PosX + 1];
                game2_map[player_PosY, player_PosX + 1] = temp_;
                player_PosX++;
            }
            else { /*pass*/ }
        }
        // W 이동
        static public void Swap_Move_W(ref string[,] game2_map, ref int player_PosY, ref int player_PosX)
        {
            // 벽이 아닐 경우
            if (game2_map[player_PosY - 1, player_PosX] != "■")
            {
                string temp_ = game2_map[player_PosY, player_PosX];
                game2_map[player_PosY, player_PosX] = game2_map[player_PosY - 1, player_PosX];
                game2_map[player_PosY - 1, player_PosX] = temp_;
                player_PosY--;
            }
            else { /*pass*/ }
        }
        // S 이동
        static public void Swap_Move_S(ref string[,] game2_map, ref int player_PosY, ref int player_PosX)
        {
            // 벽이 아닐 경우
            if (game2_map[player_PosY + 1, player_PosX] != "■")
            {
                string temp_ = game2_map[player_PosY, player_PosX];
                game2_map[player_PosY, player_PosX] = game2_map[player_PosY + 1, player_PosX];
                game2_map[player_PosY + 1, player_PosX] = temp_;
                player_PosY++;
            }
            else { /*pass*/ }
        }
        // 플레이어 이동 end

        // 승리 조건
        public void decision_Win (string[,] game2_map, int mapSize_Game3, ref bool is_game, ref int player_Win_Count)
        {
            int clear_ = 0;

            for (int y = 0; y < mapSize_Game3; y++)
            {
                for (int x = 0; x < mapSize_Game3; x++)
                {
                    if (game2_map[y,x] == "□")
                    {
                        clear_++;
                    }
                }
            }

            int final_Check_ = clear_;
            if (final_Check_ == 0)
            {
                Console.Clear();
                is_game = false;
                player_Win_Count = 1;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("제한 횟수 내에 달고나를 완성했습니다!");
                Console.WriteLine("축하합니다. 3 라운드 클리어입니다.\n");
                Console.WriteLine("아무키나 눌러 메인 대기실로 돌아가세요.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        // 패배 조건
        public void decision_Lose (int moveCount, int loseCount, ref bool is_game)
        {
            if(moveCount >= loseCount)
            {
                Console.Clear();
                is_game = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("제한 횟수 내에 달고나를 완성하지 못했습니다.");
                Console.WriteLine("3 라운드 탈락 입니다.\n");
                Console.WriteLine("아무키나 눌러 메인 대기실로 돌아가세요.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
    }
}
