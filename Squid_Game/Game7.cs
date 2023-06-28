using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squid_Game
{
    public class Game7
    {
        public void PlayGame_7()    // 징검다리 건너기
        {
            Console.Clear();
            // { 변수 선언
            // 맵 사이즈
            int sceneEndLine_Y = 14;
            int sceneEndLine_X = 27;
            string[,] game_Map7 = new string[sceneEndLine_Y, sceneEndLine_X];

            // 플레이어 위치
            int player_PosY = sceneEndLine_Y / 2;
            int player_PosX = 4;

            // 유리 체크
            int glass_Count = 7;    // 유리 라인의 총 갯수
            List<int> glass_Up = new List<int>(glass_Count);   // 위 유리     (7개의 숫자를 넣어줍니다. 0 과 1 둘 중에 하나)
            List<int> glass_Down = new List<int>(glass_Count); // 아래 유리

            // 게임 종료 변수
            bool is_Game = true;
                // } 변수 선언 end

            // { 초기 맵 생성
            Random rand = new Random();
            for (int i = 0; i < glass_Count; i++)
            {
                // 0과 1 랜덤 수 출력
                int number1_ = rand.Next(0, 2);
                int number2_ = rand.Next(0, 2);

                // 둘다 동일한 수가 나오면 안됨
                if(number1_ == number2_)
                {
                    i--;
                    continue;
                }

                // 위, 아래 유리에 0 또는 1을 넣어줍니다. (나중에 1인 곳만 지나갈 수 있게 할 예정)
                glass_Up.Add(number1_);
                glass_Down.Add(number2_);

                // Console.WriteLine("{0}, {1}", glass_Up[i], glass_Down[i]);
            }

            // 맵 세팅
            Set_Map_Game7(ref game_Map7, sceneEndLine_Y, sceneEndLine_X);
            Set_Road1(ref game_Map7, sceneEndLine_Y, sceneEndLine_X);
            Set_Road2(ref game_Map7, sceneEndLine_Y, sceneEndLine_X);
            Set_Road3(ref game_Map7, sceneEndLine_Y, sceneEndLine_X);
            Set_Glass(ref game_Map7, sceneEndLine_Y, sceneEndLine_X);
            Set_Player(ref game_Map7, ref player_PosY, ref player_PosX, sceneEndLine_Y, sceneEndLine_X);

            // 맵 출력
            Print_Map_Game6(game_Map7, sceneEndLine_Y, sceneEndLine_X);

                // } 초기 맵 생성 end

            // 게임 시작
            while(is_Game)
            {
                // 맵 출력
                Console.SetCursorPosition(0, 0);
                Print_Map_Game6(game_Map7, sceneEndLine_Y, sceneEndLine_X);

                // 플레이어 액션
                Player_Action(ref game_Map7, ref player_PosY, ref player_PosX, glass_Up, glass_Down, sceneEndLine_Y, sceneEndLine_X);
            }

            
        }

        // 맵 세팅
        public void Set_Map_Game7(ref string[,] game_Map7, int sceneEndLine_Y, int sceneEndLine_X)
        {
            for (int y = 0; y < sceneEndLine_Y; y++)
            {
                for (int x = 0; x < sceneEndLine_X; x++)
                {
                    // 벽 세팅
                    if ((y == 0) || (x == 0) || (y == sceneEndLine_Y - 1) || (x == sceneEndLine_X - 1))
                    {
                        game_Map7[y, x] = "■";
                        continue;
                    }

                    game_Map7[y, x] = "　";
                }
            }
        }

        // 징검다리 세팅 1 (큰 네모를 만들고 작은 네모 두개를 만들어 삭제하기)
        public void Set_Road1(ref string[,] game_Map7, int sceneEndLine_Y, int sceneEndLine_X)
        {
            for (int y = 0; y < sceneEndLine_Y; y++)
            {
                for (int x = 0; x < sceneEndLine_X; x++)
                {
                    // 다리 세팅 ((2 <= x) && (x <= 3) || (19 <= x) && (x <= 20))
                    if ((3 <= y) && (y <= 10) && (4 <= x) && (x <= 22))
                    {
                        game_Map7[y, x] = "■";
                        continue;
                    }
                }
            }
        }

        // 징검다리 세팅 2 (큰 네모를 만들고 작은 네모 두개를 만들어 삭제하기)
        public void Set_Road2(ref string[,] game_Map7, int sceneEndLine_Y, int sceneEndLine_X)
        {
            for (int y = 0; y < sceneEndLine_Y; y++)
            {
                for (int x = 0; x < sceneEndLine_X; x++)
                {
                    // 다리 세팅 ((2 <= x) && (x <= 3) || (19 <= x) && (x <= 20))
                    if ((3 <= y) && (y <= 5) && (6 <= x) && (x <= 20))
                    {
                        game_Map7[y, x] = "　";
                        continue;
                    }
                }
            }
        }

        // 징검다리 세팅 3 (큰 네모를 만들고 작은 네모 두개를 만들어 삭제하기)
        public void Set_Road3(ref string[,] game_Map7, int sceneEndLine_Y, int sceneEndLine_X)
        {
            for (int y = 0; y < sceneEndLine_Y; y++)
            {
                for (int x = 0; x < sceneEndLine_X; x++)
                {
                    // 다리 세팅 ((2 <= x) && (x <= 3) || (19 <= x) && (x <= 20))
                    if ((8 <= y) && (y <= 10) && (6 <= x) && (x <= 20))
                    {
                        game_Map7[y, x] = "　";
                        continue;
                    }
                }
            }
        }

        // 유리 세팅
        public void Set_Glass(ref string[,] game_Map7, int sceneEndLine_Y, int sceneEndLine_X)
        {
            for (int y = 0; y < sceneEndLine_Y; y++)
            {
                for (int x = 0; x < sceneEndLine_X; x++)
                {
                    // 유리 세팅
                    if (((6 <= y) && (y <= 7)) && ((7 <= x) && (x <= 20)) && (x % 2 == 1))
                    {
                        game_Map7[y, x] = "□";
                        continue;
                    }
                }
            }
        }

        // 플레이어 세팅
        public void Set_Player(ref string[,] game_Map7, ref int player_PosY, ref int plaeyr_PosX, int sceneEndLine_Y, int sceneEndLine_X)
        {
            for (int y = 0; y < sceneEndLine_Y; y++)
            {
                for (int x = 0; x < sceneEndLine_X; x++)
                {
                    // 플레이어 세팅
                    if ((y == player_PosY) && (x == plaeyr_PosX))
                    {
                        game_Map7[y, x] = "◎";
                        continue;
                    }
                }
            }
        }

        // 맵 출력
        public void Print_Map_Game6(string[,] game_Map7, int sceneEndLine_Y, int sceneEndLine_X)
        {
            for (int y = 0; y < sceneEndLine_Y; y++)
            {
                for (int x = 0; x < sceneEndLine_X; x++)
                {
                    if (game_Map7[y, x] == "■")
                    {
                        Console.Write(game_Map7[y, x]);
                        continue;
                    }

                    Console.Write(game_Map7[y, x]);
                }
                Console.WriteLine();
            }
        }

        // 플레이어 액션
        public void Player_Action(ref string[,] game_Map7, ref int player_PosY, ref int player_PosX, List<int> glass_Up, List<int> glass_Down, int sceneEndLine_Y, int sceneEndLine_X)
        {
            ConsoleKey user_Action = Console.ReadKey(true).Key;

            /* ( 뒤로 가는 것은 못하게 할 것임 ) */
            // A 입력 안돼!
            //if (user_Action == ConsoleKey.A)
            //{
            //    // 공백이 있으면 못가게
            //    if (game_Map7[player_PosY, player_PosX - 1] == "　")
            //    {
            //        /* pass */
            //    }
            //    else
            //    {
            //        Move_A(ref game_Map7, ref player_PosY, ref player_PosX);
            //    }
                
            //}

            // D 입력
            if (user_Action == ConsoleKey.D)
            {
                // 공백이 있으면 못가게
                if (game_Map7[player_PosY, player_PosX + 1] == "　")
                {
                    /* pass */
                }

                // 공백이 아니라면 이동
                else
                {
                    // 유리인지 체크
                    if(game_Map7[player_PosY, player_PosX + 1] == "□")
                    {
                        // 몇 번째 유리 인지 체크 ( 현재 x위치를 비교해서 )
                        // 1번째
                        if(player_PosX == 6)
                        {
                            // 위인지 아래인지 체크
                            if((player_PosY == 6) && (glass_Up[0] == 0)) // 위고 넘버가 0일 경우
                            {
                                // 지나갈 수 없음 x

                                // 유리를 부수고
                                game_Map7[player_PosY, player_PosX + 1] = "　";

                                // 플레이어 모양 스왑
                                string player_temp_ = game_Map7[player_PosY, player_PosX];
                                game_Map7[player_PosY, player_PosX] = "■";

                                // 플레이어의 위치 처음으로 초기화
                                player_PosY = sceneEndLine_Y / 2;
                                player_PosX = 4;

                                // 플레이어 모양 스왑 2
                                game_Map7[player_PosY, player_PosX] = player_temp_;
                            }

                            else if ((player_PosY == 6) && (glass_Up[0] == 1)) // 위고 넘버가 1일 경우
                            {
                                // 지나갈 수 있음 o
                                game_Map7[player_PosY, player_PosX + 1] = "■";
                                Move_D(ref game_Map7, ref player_PosY, ref player_PosX);
                            }

                            else if ((player_PosY == 7) && (glass_Down[0] == 0)) // 아래고 넘버가 0일 경우
                            {
                                // 유리를 부수고
                                game_Map7[player_PosY, player_PosX + 1] = "　";

                                // 플레이어 모양 스왑
                                string player_temp_ = game_Map7[player_PosY, player_PosX];
                                game_Map7[player_PosY, player_PosX] = "■";

                                // 플레이어의 위치 처음으로 초기화
                                player_PosY = sceneEndLine_Y / 2;
                                player_PosX = 4;

                                // 플레이어 모양 스왑 2
                                game_Map7[player_PosY, player_PosX] = player_temp_;
                            }

                            else if ((player_PosY == 7) && (glass_Down[0] == 1)) // 아래고 넘버가 1일 경우
                            {
                                // 지나갈 수 있음 o
                                game_Map7[player_PosY, player_PosX + 1] = "■";
                                Move_D(ref game_Map7, ref player_PosY, ref player_PosX);
                            }
                        }

                        // 2번째
                        if (player_PosX == 8)
                        {
                            // 위인지 아래인지 체크
                            if ((player_PosY == 6) && (glass_Up[1] == 0)) // 위고 넘버가 0일 경우
                            {
                                // 지나갈 수 없음 x

                                // 유리를 부수고
                                game_Map7[player_PosY, player_PosX + 1] = "　";

                                // 플레이어 모양 스왑
                                string player_temp_ = game_Map7[player_PosY, player_PosX];
                                game_Map7[player_PosY, player_PosX] = "■";

                                // 플레이어의 위치 처음으로 초기화
                                player_PosY = sceneEndLine_Y / 2;
                                player_PosX = 4;

                                // 플레이어 모양 스왑 2
                                game_Map7[player_PosY, player_PosX] = player_temp_;
                            }

                            else if ((player_PosY == 6) && (glass_Up[1] == 1)) // 위고 넘버가 1일 경우
                            {
                                // 지나갈 수 있음 o
                                game_Map7[player_PosY, player_PosX + 1] = "■";
                                Move_D(ref game_Map7, ref player_PosY, ref player_PosX);
                            }

                            else if ((player_PosY == 7) && (glass_Down[1] == 0)) // 아래고 넘버가 0일 경우
                            {
                                // 유리를 부수고
                                game_Map7[player_PosY, player_PosX + 1] = "　";

                                // 플레이어 모양 스왑
                                string player_temp_ = game_Map7[player_PosY, player_PosX];
                                game_Map7[player_PosY, player_PosX] = "■";

                                // 플레이어의 위치 처음으로 초기화
                                player_PosY = sceneEndLine_Y / 2;
                                player_PosX = 4;

                                // 플레이어 모양 스왑 2
                                game_Map7[player_PosY, player_PosX] = player_temp_;
                            }

                            else if ((player_PosY == 7) && (glass_Down[1] == 1)) // 아래고 넘버가 1일 경우
                            {
                                // 지나갈 수 있음 o
                                game_Map7[player_PosY, player_PosX + 1] = "■";
                                Move_D(ref game_Map7, ref player_PosY, ref player_PosX);
                            }
                        }

                        // 3번째
                        if (player_PosX == 10)
                        {
                            // 위인지 아래인지 체크
                            if ((player_PosY == 6) && (glass_Up[2] == 0)) // 위고 넘버가 0일 경우
                            {
                                // 지나갈 수 없음 x

                                // 유리를 부수고
                                game_Map7[player_PosY, player_PosX + 1] = "　";

                                // 플레이어 모양 스왑
                                string player_temp_ = game_Map7[player_PosY, player_PosX];
                                game_Map7[player_PosY, player_PosX] = "■";

                                // 플레이어의 위치 처음으로 초기화
                                player_PosY = sceneEndLine_Y / 2;
                                player_PosX = 4;

                                // 플레이어 모양 스왑 2
                                game_Map7[player_PosY, player_PosX] = player_temp_;
                            }

                            else if ((player_PosY == 6) && (glass_Up[2] == 1)) // 위고 넘버가 1일 경우
                            {
                                // 지나갈 수 있음 o
                                game_Map7[player_PosY, player_PosX + 1] = "■";
                                Move_D(ref game_Map7, ref player_PosY, ref player_PosX);
                            }

                            else if ((player_PosY == 7) && (glass_Down[2] == 0)) // 아래고 넘버가 0일 경우
                            {
                                // 유리를 부수고
                                game_Map7[player_PosY, player_PosX + 1] = "　";

                                // 플레이어 모양 스왑
                                string player_temp_ = game_Map7[player_PosY, player_PosX];
                                game_Map7[player_PosY, player_PosX] = "■";

                                // 플레이어의 위치 처음으로 초기화
                                player_PosY = sceneEndLine_Y / 2;
                                player_PosX = 4;

                                // 플레이어 모양 스왑 2
                                game_Map7[player_PosY, player_PosX] = player_temp_;
                            }

                            else if ((player_PosY == 7) && (glass_Down[2] == 1)) // 아래고 넘버가 1일 경우
                            {
                                // 지나갈 수 있음 o
                                game_Map7[player_PosY, player_PosX + 1] = "■";
                                Move_D(ref game_Map7, ref player_PosY, ref player_PosX);
                            }
                        }

                        // 4번째
                        if (player_PosX == 12)
                        {
                            // 위인지 아래인지 체크
                            if ((player_PosY == 6) && (glass_Up[3] == 0)) // 위고 넘버가 0일 경우
                            {
                                // 지나갈 수 없음 x

                                // 유리를 부수고
                                game_Map7[player_PosY, player_PosX + 1] = "　";

                                // 플레이어 모양 스왑
                                string player_temp_ = game_Map7[player_PosY, player_PosX];
                                game_Map7[player_PosY, player_PosX] = "■";

                                // 플레이어의 위치 처음으로 초기화
                                player_PosY = sceneEndLine_Y / 2;
                                player_PosX = 4;

                                // 플레이어 모양 스왑 2
                                game_Map7[player_PosY, player_PosX] = player_temp_;
                            }

                            else if ((player_PosY == 6) && (glass_Up[3] == 1)) // 위고 넘버가 1일 경우
                            {
                                // 지나갈 수 있음 o
                                game_Map7[player_PosY, player_PosX + 1] = "■";
                                Move_D(ref game_Map7, ref player_PosY, ref player_PosX);
                            }

                            else if ((player_PosY == 7) && (glass_Down[3] == 0)) // 아래고 넘버가 0일 경우
                            {
                                // 유리를 부수고
                                game_Map7[player_PosY, player_PosX + 1] = "　";

                                // 플레이어 모양 스왑
                                string player_temp_ = game_Map7[player_PosY, player_PosX];
                                game_Map7[player_PosY, player_PosX] = "■";

                                // 플레이어의 위치 처음으로 초기화
                                player_PosY = sceneEndLine_Y / 2;
                                player_PosX = 4;

                                // 플레이어 모양 스왑 2
                                game_Map7[player_PosY, player_PosX] = player_temp_;
                            }

                            else if ((player_PosY == 7) && (glass_Down[3] == 1)) // 아래고 넘버가 1일 경우
                            {
                                // 지나갈 수 있음 o
                                game_Map7[player_PosY, player_PosX + 1] = "■";
                                Move_D(ref game_Map7, ref player_PosY, ref player_PosX);
                            }
                        }

                        // 5번째
                        if (player_PosX == 14)
                        {
                            // 위인지 아래인지 체크
                            if ((player_PosY == 6) && (glass_Up[4] == 0)) // 위고 넘버가 0일 경우
                            {
                                // 지나갈 수 없음 x

                                // 유리를 부수고
                                game_Map7[player_PosY, player_PosX + 1] = "　";

                                // 플레이어 모양 스왑
                                string player_temp_ = game_Map7[player_PosY, player_PosX];
                                game_Map7[player_PosY, player_PosX] = "■";

                                // 플레이어의 위치 처음으로 초기화
                                player_PosY = sceneEndLine_Y / 2;
                                player_PosX = 4;

                                // 플레이어 모양 스왑 2
                                game_Map7[player_PosY, player_PosX] = player_temp_;
                            }

                            else if ((player_PosY == 6) && (glass_Up[4] == 1)) // 위고 넘버가 1일 경우
                            {
                                // 지나갈 수 있음 o
                                game_Map7[player_PosY, player_PosX + 1] = "■";
                                Move_D(ref game_Map7, ref player_PosY, ref player_PosX);
                            }

                            else if ((player_PosY == 7) && (glass_Down[4] == 0)) // 아래고 넘버가 0일 경우
                            {
                                // 유리를 부수고
                                game_Map7[player_PosY, player_PosX + 1] = "　";

                                // 플레이어 모양 스왑
                                string player_temp_ = game_Map7[player_PosY, player_PosX];
                                game_Map7[player_PosY, player_PosX] = "■";

                                // 플레이어의 위치 처음으로 초기화
                                player_PosY = sceneEndLine_Y / 2;
                                player_PosX = 4;

                                // 플레이어 모양 스왑 2
                                game_Map7[player_PosY, player_PosX] = player_temp_;
                            }

                            else if ((player_PosY == 7) && (glass_Down[4] == 1)) // 아래고 넘버가 1일 경우
                            {
                                // 지나갈 수 있음 o
                                game_Map7[player_PosY, player_PosX + 1] = "■";
                                Move_D(ref game_Map7, ref player_PosY, ref player_PosX);
                            }
                        }

                        // 6번째
                        if (player_PosX == 16)
                        {
                            // 위인지 아래인지 체크
                            if ((player_PosY == 6) && (glass_Up[5] == 0)) // 위고 넘버가 0일 경우
                            {
                                // 지나갈 수 없음 x

                                // 유리를 부수고
                                game_Map7[player_PosY, player_PosX + 1] = "　";

                                // 플레이어 모양 스왑
                                string player_temp_ = game_Map7[player_PosY, player_PosX];
                                game_Map7[player_PosY, player_PosX] = "■";

                                // 플레이어의 위치 처음으로 초기화
                                player_PosY = sceneEndLine_Y / 2;
                                player_PosX = 4;

                                // 플레이어 모양 스왑 2
                                game_Map7[player_PosY, player_PosX] = player_temp_;
                            }

                            else if ((player_PosY == 6) && (glass_Up[5] == 1)) // 위고 넘버가 1일 경우
                            {
                                // 지나갈 수 있음 o
                                game_Map7[player_PosY, player_PosX + 1] = "■";
                                Move_D(ref game_Map7, ref player_PosY, ref player_PosX);
                            }

                            else if ((player_PosY == 7) && (glass_Down[5] == 0)) // 아래고 넘버가 0일 경우
                            {
                                // 유리를 부수고
                                game_Map7[player_PosY, player_PosX + 1] = "　";

                                // 플레이어 모양 스왑
                                string player_temp_ = game_Map7[player_PosY, player_PosX];
                                game_Map7[player_PosY, player_PosX] = "■";

                                // 플레이어의 위치 처음으로 초기화
                                player_PosY = sceneEndLine_Y / 2;
                                player_PosX = 4;

                                // 플레이어 모양 스왑 2
                                game_Map7[player_PosY, player_PosX] = player_temp_;
                            }

                            else if ((player_PosY == 7) && (glass_Down[5] == 1)) // 아래고 넘버가 1일 경우
                            {
                                // 지나갈 수 있음 o
                                game_Map7[player_PosY, player_PosX + 1] = "■";
                                Move_D(ref game_Map7, ref player_PosY, ref player_PosX);
                            }
                        }

                        // 7번째
                        if (player_PosX == 18)
                        {
                            // 위인지 아래인지 체크
                            if ((player_PosY == 6) && (glass_Up[6] == 0)) // 위고 넘버가 0일 경우
                            {
                                // 지나갈 수 없음 x

                                // 유리를 부수고
                                game_Map7[player_PosY, player_PosX + 1] = "　";

                                // 플레이어 모양 스왑
                                string player_temp_ = game_Map7[player_PosY, player_PosX];
                                game_Map7[player_PosY, player_PosX] = "■";

                                // 플레이어의 위치 처음으로 초기화
                                player_PosY = sceneEndLine_Y / 2;
                                player_PosX = 4;

                                // 플레이어 모양 스왑 2
                                game_Map7[player_PosY, player_PosX] = player_temp_;
                            }

                            else if ((player_PosY == 6) && (glass_Up[6] == 1)) // 위고 넘버가 1일 경우
                            {
                                // 지나갈 수 있음 o
                                game_Map7[player_PosY, player_PosX + 1] = "■";
                                Move_D(ref game_Map7, ref player_PosY, ref player_PosX);
                            }

                            else if ((player_PosY == 7) && (glass_Down[6] == 0)) // 아래고 넘버가 0일 경우
                            {
                                // 유리를 부수고
                                game_Map7[player_PosY, player_PosX + 1] = "　";

                                // 플레이어 모양 스왑
                                string player_temp_ = game_Map7[player_PosY, player_PosX];
                                game_Map7[player_PosY, player_PosX] = "■";

                                // 플레이어의 위치 처음으로 초기화
                                player_PosY = sceneEndLine_Y / 2;
                                player_PosX = 4;

                                // 플레이어 모양 스왑 2
                                game_Map7[player_PosY, player_PosX] = player_temp_;
                            }

                            else if ((player_PosY == 7) && (glass_Down[6] == 1)) // 아래고 넘버가 1일 경우
                            {
                                // 지나갈 수 있음 o
                                game_Map7[player_PosY, player_PosX + 1] = "■";
                                Move_D(ref game_Map7, ref player_PosY, ref player_PosX);
                            }
                        }
                    }

                    // 유리가 아니라면 그냥 이동
                    else
                    {
                        Move_D(ref game_Map7, ref player_PosY, ref player_PosX);
                    }
                }
            }   // D 입력 end

            // W 입력
            else if (user_Action == ConsoleKey.W)
            {
                // 공백이 있으면 못가게
                if (game_Map7[player_PosY - 1, player_PosX] == "　")
                {
                    /* pass */
                }

                // 공백이 아니라면 이동
                else
                {
                    Move_W(ref game_Map7, ref player_PosY, ref player_PosX);
                }
            }

            // S 입력
            else if (user_Action == ConsoleKey.S)
            {
                // 공백이 있으면 못가게
                if (game_Map7[player_PosY + 1, player_PosX] == "　")
                {
                    /* pass */
                }

                // 공백이 아니라면 이동
                else
                {
                    Move_S(ref game_Map7, ref player_PosY, ref player_PosX);
                }
            }
        }
        // A 이동
        public void Move_A(ref string[,] game_Map7, ref int player_PosY, ref int player_PosX)
        {
            string temp_ = game_Map7[player_PosY, player_PosX];
            game_Map7[player_PosY, player_PosX] = game_Map7[player_PosY, player_PosX - 1];
            game_Map7[player_PosY, player_PosX - 1] = temp_;
            player_PosX--;
        }

        // D 이동
        public void Move_D(ref string[,] game_Map7, ref int player_PosY, ref int player_PosX)
        {
            string temp_ = game_Map7[player_PosY, player_PosX];
            game_Map7[player_PosY, player_PosX] = game_Map7[player_PosY, player_PosX + 1];
            game_Map7[player_PosY, player_PosX + 1] = temp_;
            player_PosX++;
            
        }

        // W 이동
        public void Move_W(ref string[,] game_Map7, ref int player_PosY, ref int player_PosX)
        {
            string temp_ = game_Map7[player_PosY, player_PosX];
            game_Map7[player_PosY, player_PosX] = game_Map7[player_PosY - 1, player_PosX];
            game_Map7[player_PosY - 1, player_PosX] = temp_;
            player_PosY--;

        }

        // S 이동
        public void Move_S(ref string[,] game_Map7, ref int player_PosY, ref int player_PosX)
        {
            string temp_ = game_Map7[player_PosY, player_PosX];
            game_Map7[player_PosY, player_PosX] = game_Map7[player_PosY + 1, player_PosX];
            game_Map7[player_PosY + 1, player_PosX] = temp_;
            player_PosY++;

        }
    }
}
