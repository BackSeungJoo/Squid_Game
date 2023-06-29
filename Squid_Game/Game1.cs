using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Security.AccessControl;

namespace Squid_Game
{
    // 1. 딱치 치기
    public class Game1
    {
        public bool PlayGame_1(ref int player_Win_Count, ref int enemy_Win_Count)
        {
            // 맵 출력을 위한 변수
            int sceneEndLine_Y = 13;
            int sceneEndLine_X = 30;
            string[,] game1_Map = new string[sceneEndLine_Y, sceneEndLine_X];

            // 게임 승리를 위한 변수
            player_Win_Count = 0;
            enemy_Win_Count = 0;

            // 게임 1 대기실
            //StandByGame_1();
            Console.Clear();

            // 초기 맵 세팅
            Set_Map_Game1(ref game1_Map, sceneEndLine_Y, sceneEndLine_X);
            Console.CursorVisible = false;
            

            // 게임 시작
            while (true)
            {
                // 맵 출력
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(20, 1);
                Console.WriteLine("X를 눌러 딱지를 치세요!");
                Console.ResetColor();
                Console.SetCursorPosition(12, 2);
                Console.WriteLine("더 높은 수가 나온 참가자가 승리합니다.");
                Console.SetCursorPosition(12, 3);
                Console.WriteLine("5번을 먼저 이긴 참가자가 최종 승리합니다.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("플레이어가 이긴 횟수 [{0}]\t    [{1}] 상대방이 이긴 횟수", player_Win_Count, enemy_Win_Count);

                Console.SetCursorPosition(0, 6);
                Ptr_Map_Game1(game1_Map, sceneEndLine_Y, sceneEndLine_X);
                Action_Game1(ref game1_Map, ref player_Win_Count, ref enemy_Win_Count, sceneEndLine_Y, sceneEndLine_X);

                if ((player_Win_Count >= 5) || (enemy_Win_Count >= 5))
                {
                    if(player_Win_Count >= 5)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(10, 12);
                        Console.WriteLine("당신의 최종 승리입니다. 1 라운드 클리어!!");
                        Console.SetCursorPosition(10, 14);
                        Console.WriteLine("아무키나 눌러 메인 대기실로 돌아갑니다.");
                        Console.ReadKey();
                        Console.ResetColor();
                        break;
                    }
                    else if (enemy_Win_Count >= 5)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(10, 12);
                        Console.WriteLine("당신의 최종 패배입니다. 1 라운드 실패!!");
                        Console.SetCursorPosition(10, 14);
                        Console.WriteLine("아무키나 눌러 메인 대기실로 돌아갑니다.");
                        Console.ReadKey();
                        Console.ResetColor();
                        break;
                    }
                }
            }
            return false;
        }

        // 대기실
        public void StandByGame_1()
        {
            Console.Clear();
            Console.WriteLine("잠시 후 [ 1. 딱지치기 ] 게임을 시작합니다.");

            for (int i = 3; i > 0; i--)
            {
                Console.WriteLine();
                Thread.Sleep(1000);
                Console.WriteLine("\t\t{0}...", i);
            }
        }

        // 게임 맵 세팅
        public void Set_Map_Game1(ref string[,] game1_Map, int sceneEndLine_Y, int sceneEndLine_X)
        {
            int player_Ttakji_Count = 0;
            int enemy_Ttakji_Count = 0;

            for (int y = 0; y < sceneEndLine_Y; y++)
            {
                for (int x = 0; x < sceneEndLine_X; x++)
                {
                    // 맵 테두리 세팅
                    if ((y == 0) || (x == 0) || (y == sceneEndLine_Y - 1) || (x == sceneEndLine_X - 1))
                    {
                        game1_Map[y, x] = "■";
                        continue;
                    }
                    else
                    {
                        game1_Map[y, x] = "　";
                    }

                    // 참가자 딱지 
                    if (((4 <= y) && (y <= 9)) && ((5 <= x) && (x <= 10)))
                    {
                        game1_Map[y, x] = "■";
                        continue;
                    }

                    // 상대방 딱지
                    if (((4 <= y) && (y <= 9)) && ((19 <= x) && (x <= 24)))
                    {
                        game1_Map[y, x] = "■";
                        continue;
                    }

                    // 참가자 딱지 텍스트
                    if ((2 == y) && (5 <= x))
                    {
                        string[] player_Ttakji = { "참", "가", "자", "　", "딱", "지" };

                        if (player_Ttakji_Count < player_Ttakji.Length)
                        {
                            game1_Map[y, x] = player_Ttakji[player_Ttakji_Count];
                            player_Ttakji_Count++;
                        }
                    }

                    // 상대방 딱지 텍스트
                    if ((2 == y) && (19 <= x))
                    {
                        string[] enemy_Ttakji = { "상", "대", "방", "　", "딱", "지" };

                        if (enemy_Ttakji_Count < enemy_Ttakji.Length)
                        {
                            game1_Map[y, x] = enemy_Ttakji[enemy_Ttakji_Count];
                            enemy_Ttakji_Count++;
                        }
                    }

                }
            }
        }

        // 게임 맵 출력
        public void Ptr_Map_Game1(string[,] game1_Map, int sceneEndLine_Y, int sceneEndLine_X)
        {
            for (int y = 0; y < sceneEndLine_Y; y++)
            {
                for (int x = 0; x < sceneEndLine_X; x++)
                {
                    // 벽 색상 변경
                    if ((y == 0) || (x == 0) || (y == sceneEndLine_Y - 1) || (x == sceneEndLine_X - 1))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(game1_Map[y, x]);
                        Console.ResetColor();
                        continue;
                    }

                    // 참가자 딱지 색상 변경
                    if (((4 <= y) && (y <= 9)) && ((5 <= x) && (x <= 10)))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(game1_Map[y, x]);
                        Console.ResetColor();
                        continue;
                    }

                    // 상대방 딱지 색상 변경
                    if (((4 <= y) && (y <= 9)) && ((19 <= x) && (x <= 24)))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(game1_Map[y, x]);
                        Console.ResetColor();
                        continue;
                    }

                    Console.Write(game1_Map[y, x]);
                }
                Console.WriteLine();
            }
        }

        // X를 눌렀을 때 딱지 치기
        public void Action_Game1(ref string[,] game1_Map, ref int player_Win_Count, ref int enemy_Win_Count, int sceneEndLine_Y, int sceneEndLine_X)
        {
            int playerNum_ = default;
            int enemyNum_ = default;

            Random random = new Random();
            ConsoleKey action = Console.ReadKey(true).Key;
            
            if (action == ConsoleKey.X)
            {
                // 딱지 숫자 정하기
                playerNum_ = random.Next(1, 10);
                enemyNum_ = random.Next(1, 10);

                // 디버그 모드
                //playerNum_ = 1;
                //enemyNum_ = 5;

                // 딱지 숫자 세팅하기
                game1_Map[7, 12] = playerNum_.ToString();
                game1_Map[7, 18] = enemyNum_.ToString() + "　" ;
            }

            // 딱지 숫자 출력하기
            Console.SetCursorPosition(0, 6);
            Ptr_Map_Game1(game1_Map, sceneEndLine_Y, sceneEndLine_X);

            // 플레이어 승리
            if (enemyNum_ < playerNum_)
            {
                player_Win_Count++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(21, 20);
                Console.WriteLine("당신의 승리입니다!");
                Console.ResetColor();
                Console.ReadKey();
                Player_Win_Scene();
            }

            // 상대방 승리
            else if(playerNum_ < enemyNum_)
            {
                enemy_Win_Count++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(20, 20);
                Console.WriteLine("상대방의 승리입니다!");
                Console.ResetColor();
                Console.ReadKey();
                Enemy_Win_Scene();
            }

            // 비김
            else if (playerNum_ == enemyNum_)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(24, 20);
                Console.WriteLine("비겼습니다.");
                Console.ResetColor();
                Console.ReadKey();
                // Pass
            }

            // 숫자 제거
            game1_Map[7, 12] = "　";
            game1_Map[7, 18] = "　";
        }

        // 참가자 승리 연출
        public void Player_Win_Scene()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(26,10);
            Console.WriteLine("짝!!!");
            Console.SetCursorPosition(10, 12);
            Console.WriteLine("당신은 상대방의 뺨을 있는 힘껏 때렸습니다.\n\n");
            Console.SetCursorPosition(15, 14);
            Console.WriteLine("아무 키나 눌러 다시 딱지를 치세요.");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }

        // 상대방 승리 연출
        public void Enemy_Win_Scene()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(26, 10);
            Console.WriteLine("짝!!!");
            Console.SetCursorPosition(10, 12);
            Console.WriteLine("상대방은 당신의 뺨을 있는 힘껏 때렸습니다.\n\n");
            Console.SetCursorPosition(15, 14);
            Console.WriteLine("아무 키나 눌러 다시 딱지를 치세요.");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }


    }
}
