using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Squid_Game
{
    public class Game4 // 밤에 생존하기
    {
        public bool PlayGame_4(ref int player_Win_Count)
        {
            Console.Clear();

            // 변수 선언
            int mapSize = 20; // 맵 사이즈
            int User_Position_Y = mapSize / 2;
            int User_Position_X = mapSize / 2;
            string[,] map = new string[mapSize, mapSize];

            List<int> enemyPostion_Y = new List<int>();
            List<int> enemyPostion_X = new List<int>();

            int moveCount = 0; // 움직인 횟수
            int enemyCount = 5; // 적의 수

            bool gameEnd = true;
                // 변수 선언 end

            // 초기 맵 세팅
            Set_Map(ref map, mapSize);  // 맵 세팅
            Set_maze(ref map, mapSize); // 미로 세팅
            Make_Enemy(ref map, mapSize, ref enemyPostion_Y, ref enemyPostion_X, ref moveCount, ref enemyCount); // 적 생성
                // 초기 맵 세팅 end

            // 게임 시작
            while (gameEnd)
            {
                // 적이 먼저 움직입니다.
                Move_EnemyPos(ref map, ref User_Position_Y, ref User_Position_X, ref enemyPostion_Y, ref enemyPostion_X, ref enemyCount);

                // 글씨 출력
                Console.CursorVisible = false;
                Console.SetCursorPosition(51, 2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("적에게 붙잡히지 않고 100번 이동하세요!!");
                Console.SetCursorPosition(51, 4);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("현재 움직인 횟수 [{0:D2}]", moveCount);
                Console.ResetColor();

                // 적과 부딪히면 패배
                for (int i = 0; i < enemyCount; i++)
                {
                    if ((User_Position_Y == enemyPostion_Y[i]) && (User_Position_X == enemyPostion_X[i]))
                    {
                        //Console.Clear();
                        Console.Clear();
                        Print_Map(map, mapSize);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(60, 5);
                        Console.WriteLine("적과 부딪혀 진실의 방으로 끌려갑니다...");
                        Console.SetCursorPosition(74, 7);
                        Console.WriteLine("Game End!!");
                        Console.SetCursorPosition(56, 10);
                        Console.WriteLine("4 라운드 탈락 입니다...\n");
                        Console.SetCursorPosition(56, 12);
                        Console.WriteLine("아무키나 눌러 메인 대기실로 돌아가세요...");
                        Console.ResetColor();
                        Console.ReadKey();
                        gameEnd = false;
                        break;
                    }
                }

                if(moveCount >= 100)
                {
                    Console.Clear();
                    player_Win_Count = 1;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("적에게 붙잡히지 않고 끝까지 생존했습니다!");
                    Console.WriteLine("축하합니다. 4 라운드 클리어입니다.\n");
                    Console.WriteLine("아무키나 눌러 메인 대기실로 돌아가세요.");
                    Console.ResetColor();
                    Console.ReadKey();
                    gameEnd = false;
                    break;
                }

                // 맵 출력
                Print_Map(map, mapSize);

                // 플레이어가 움직입니다.
                User_Move(ref map, ref User_Position_Y, ref User_Position_X, mapSize, ref enemyPostion_Y, ref enemyPostion_X, ref enemyCount);
                moveCount++;

                /* 디버그 모드 */
                //Console.SetCursorPosition(51, 22);
                //Console.WriteLine("플레이어의 좌표 {0:D2},{1:D2}  ", User_Position_Y, User_Position_X);

                //Console.SetCursorPosition(51, 24);
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine("현재 나타난 적 [{0}]", enemyCount);
                //Console.ResetColor();

                //for (int i = 0; i < enemyCount; i++)
                //{
                //    Console.Write("[적{0:D2}] 좌표({1:D2},{2:D2})  /", i, enemyPostion_Y[i], enemyPostion_X[i]);
                //}
                //      글씨 출력 end
            }
            
            return false;
        }
        // Main 함수 end

        // 초기 맵 세팅
        static void Set_Map(ref string[,] map, int mapSize)
        {
            for (int y = 0; y < mapSize; y++)
            {
                for (int x = 0; x < mapSize; x++)
                {
                    // 벽 생성
                    if (((y == 0) || (y == mapSize - 1)) || ((x == 0) || (x == mapSize - 1)))
                    {
                        map[y, x] = "■";
                        continue;
                    }

                    // 플레이어 생성
                    if ((y == mapSize / 2) && (x == mapSize / 2))
                    {
                        map[y, x] = "◎";
                        continue;
                    }

                    // 바닥 생성
                    map[y, x] = "□";
                }
            }
        }
        // 초기 맵 세팅 end

        // 미로 돌 생성
        static void Set_maze(ref string[,] map, int mapSize)
        {

            Random random = new Random();
            for (int i = 0; i < mapSize * 2; i++)
            {
                int randomY_ = random.Next(1, mapSize - 2);
                int randomX_ = random.Next(1, mapSize - 2);

                // 별이 하나라도 있어야함
                if ((map[randomY_, randomX_ + 1] == "□") ||
                        (map[randomY_, randomX_ - 1] == "□") ||
                        (map[randomY_ + 1, randomX_] == "□") ||
                        (map[randomY_ - 1, randomX_] == "□"))
                // 플레이어의 위치에 생성되면 안됨.
                {
                    if (map[randomY_, randomX_] != "◎")
                    {
                        map[randomY_, randomX_] = "▣";
                    }
                    else
                    {
                        i--;
                    }
                }

                else
                {
                    i--;
                }
            }
        }
        // 미로 돌 생성 end

        // 적 생성
        static void Make_Enemy(ref string[,] map, int mapSize, ref List<int> enemyPostion_Y, ref List<int> enemyPostion_X, ref int moveCount, ref int enemyCount)
        {
            Random random = new Random();
            int create_Enemy_Count = moveCount;

            for(int i = 0; i < enemyCount; i++)
            {
                int randomY_ = random.Next(2, mapSize - 2);
                int randomX_ = random.Next(2, mapSize - 2);

                // 생성되는 위치가 바닥이여야함
                if (map[randomY_, randomX_] == "□")
                {
                    map[randomY_, randomX_] = "＠";

                    enemyPostion_Y.Add(randomY_);
                    enemyPostion_X.Add(randomX_);

                }

                else { i--; }
            }

        }
        // 적 생성 end

        // 맵 출력
        static void Print_Map(string[,] map, int mapSize)
        {
            Console.SetCursorPosition(0, 0);

            for (int y = 0; y < mapSize; y++)
            {
                for (int x = 0; x < mapSize; x++)
                {
                    // 벽 색상 변경
                    if (map[y, x] == "■")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(map[y, x]);
                        Console.ResetColor();
                        continue;
                    }

                    // 플레이어 색상 변경
                    if (map[y, x] == "◎")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(map[y, x]);
                        Console.ResetColor();
                        continue;
                    }

                    // 미로 돌 색상 변경
                    if (map[y, x] == "▣")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(map[y, x]);
                        Console.ResetColor();
                        continue;
                    }

                    // 에너미 색상 변경
                    if (map[y, x] == "＠")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(map[y, x]);
                        Console.ResetColor();
                        continue;
                    }

                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(map[y, x]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
            // 맵 출력 end

        // 플레이어 이동
        static void User_Move(ref string[,] map, ref int User_Position_Y, ref int User_Position_X, int mapSize, ref List<int> enemyPostion_Y, ref List<int> enemyPostion_X, ref int enemyCount)
        {
            ConsoleKey user_Move = Console.ReadKey(true).Key;

            // A 입력 (왼쪽이동)
            if (user_Move == ConsoleKey.A)
            {
                Swap_Move_A(ref map, ref User_Position_Y, ref User_Position_X, mapSize, ref enemyPostion_Y, ref enemyPostion_X, ref enemyCount);
            }

            // D 입력 (오른쪽이동)
            else if (user_Move == ConsoleKey.D)
            {
                Swap_Move_D(ref map, ref User_Position_Y, ref User_Position_X, mapSize, ref enemyPostion_Y, ref enemyPostion_X, ref enemyCount);
            }

            // W 입력 (위쪽이동)
            else if (user_Move == ConsoleKey.W)
            {
                Swap_Move_W(ref map, ref User_Position_Y, ref User_Position_X, mapSize, ref enemyPostion_Y, ref enemyPostion_X, ref enemyCount);
            }

            // S 입력 (아래쪽이동)
            else if (user_Move == ConsoleKey.S)
            {
                Swap_Move_S(ref map, ref User_Position_Y, ref User_Position_X, mapSize, ref enemyPostion_Y, ref enemyPostion_X, ref enemyCount);
            }
        }
            // 플레이어 이동 end

        // 플레이어 이동 시 스왑
        #region
        // A 이동
        static void Swap_Move_A(ref string[,] map, ref int User_Position_Y, ref int User_Position_X, int mapSize, ref List<int> enemyPostion_Y, ref List<int> enemyPostion_X, ref int enemyCount)
        {
            // 벽이 아닐 경우 && 돌이 아닐 경우
            if ((map[User_Position_Y, User_Position_X - 1] != "■") && (map[User_Position_Y, User_Position_X - 1] != "▣"))
            {
                // 포탈일 때
                if (map[User_Position_Y, User_Position_X - 1] == "▣")
                {
                    // 플레이어 위치 반대편 포탈 앞으로 스왑
                    string temp_ = map[User_Position_Y, User_Position_X];
                    map[User_Position_Y, User_Position_X] = map[User_Position_Y, mapSize - 2];
                    map[User_Position_Y, mapSize - 2] = temp_;

                    User_Position_X = mapSize - 2;
                    //Reset_maze(ref map, mapSize);
                    //Set_maze(ref map, mapSize);
                }

                // 포탈이 아닐 때,
                else
                {
                    string temp_ = map[User_Position_Y, User_Position_X];
                    map[User_Position_Y, User_Position_X] = map[User_Position_Y, User_Position_X - 1];
                    map[User_Position_Y, User_Position_X - 1] = temp_;
                    User_Position_X--;
                }
            }

            else { }
        }
        // D 이동
        static void Swap_Move_D(ref string[,] map, ref int User_Position_Y, ref int User_Position_X, int mapSize, ref List<int> enemyPostion_Y, ref List<int> enemyPostion_X, ref int enemyCount)
        {
            // 벽이 아닐 경우 && 돌이 아닐 경우
            if ((map[User_Position_Y, User_Position_X + 1] != "■") && (map[User_Position_Y, User_Position_X + 1] != "▣"))
            {
                // 포탈일 때
                if (map[User_Position_Y, User_Position_X + 1] == "▣")
                {
                    // 플레이어 위치 반대편 포탈 앞으로 스왑
                    string temp_ = map[User_Position_Y, User_Position_X];
                    map[User_Position_Y, User_Position_X] = map[User_Position_Y, 1];
                    map[User_Position_Y, 1] = temp_;

                    User_Position_X = 1;
                    //Reset_maze(ref map, mapSize);
                    //Set_maze(ref map, mapSize);
                }

                // 포탈이 아닐 때,
                else
                {
                    string temp_ = map[User_Position_Y, User_Position_X];
                    map[User_Position_Y, User_Position_X] = map[User_Position_Y, User_Position_X + 1];
                    map[User_Position_Y, User_Position_X + 1] = temp_;
                    User_Position_X++;
                }
            }
            else { }
        }
        // W 이동
        static void Swap_Move_W(ref string[,] map, ref int User_Position_Y, ref int User_Position_X, int mapSize, ref List<int> enemyPostion_Y, ref List<int> enemyPostion_X, ref int enemyCount)
        {
            // 벽이 아닐 경우 && 돌이 아닐 경우
            if ((map[User_Position_Y - 1, User_Position_X] != "■") && (map[User_Position_Y - 1, User_Position_X] != "▣"))
            {
                // 포탈일 때
                if (map[User_Position_Y - 1, User_Position_X] == "▣")
                {
                    // 플레이어 위치 반대편 포탈 앞으로 스왑
                    string temp_ = map[User_Position_Y, User_Position_X];
                    map[User_Position_Y, User_Position_X] = map[mapSize - 2, User_Position_X];
                    map[mapSize - 2, User_Position_X] = temp_;

                    User_Position_Y = mapSize - 2;
                    //Reset_maze(ref map, mapSize);
                    //Set_maze(ref map, mapSize);
                }

                // 포탈이 아닐 때,
                else
                {
                    string temp_ = map[User_Position_Y, User_Position_X];
                    map[User_Position_Y, User_Position_X] = map[User_Position_Y - 1, User_Position_X];
                    map[User_Position_Y - 1, User_Position_X] = temp_;
                    User_Position_Y--;
                }
            }
            else { }
        }
        // S 이동
        static void Swap_Move_S(ref string[,] map, ref int User_Position_Y, ref int User_Position_X, int mapSize, ref List<int> enemyPostion_Y, ref List<int> enemyPostion_X, ref int enemyCount)
        {
            // 벽이 아닐 경우 && 돌이 아닐 경우
            if ((map[User_Position_Y + 1, User_Position_X] != "■") && (map[User_Position_Y + 1, User_Position_X] != "▣"))
            {
                // 포탈일 때
                if (map[User_Position_Y + 1, User_Position_X] == "▣")
                {
                    // 플레이어 위치 반대편 포탈 앞으로 스왑
                    string temp_ = map[User_Position_Y, User_Position_X];
                    map[User_Position_Y, User_Position_X] = map[1, User_Position_X];
                    map[1, User_Position_X] = temp_;

                    User_Position_Y = 1;
                    //Reset_maze(ref map, mapSize);
                    //Set_maze(ref map, mapSize);
                }

                // 포탈이 아닐 때,
                else
                {
                    string temp_ = map[User_Position_Y, User_Position_X];
                    map[User_Position_Y, User_Position_X] = map[User_Position_Y + 1, User_Position_X];
                    map[User_Position_Y + 1, User_Position_X] = temp_;
                    User_Position_Y++;
                }
            }
            else { }
        }
        #endregion      // 플레이어 이동 시 스왑 end

        // 에너미가 플레이어를 따라오는 로직
        static void Move_EnemyPos(ref string[,] map, ref int User_Position_Y, ref int User_Position_X, ref List<int> enemyPostion_Y, ref List<int> enemyPostion_X, ref int enemyCount)
        {
            Random random = new Random();
            int logicStart = random.Next(1, 5);
            for (int i = 0; i < enemyCount; i++)
            {
                if (logicStart == 1)
                {
                    // 에너미 x 위치가 플레이어 x 위치보다 클 경우
                    if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "■"))
                    {
                        // A 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] - 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] - 1] = temp_;
                        enemyPostion_X[i]--;
                    }

                    // A 쪽이 벽이고, w쪽이 벽이 아니면
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "■"))
                    {
                        // W 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] - 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]--;
                    }

                    // W 쪽이 벽이고, s쪽이 벽이 아니면
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "■"))
                    {
                        // S 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] + 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]++;
                    }

                    // S 쪽이 벽이고, D쪽이 벽이 아니면 
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "■"))
                    {
                        // D 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] + 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] + 1] = temp_;
                        enemyPostion_X[i]++;
                    }

                    // 에너미 x 위치가 플레이어 x 위치보다 작을 경우
                    else if ((enemyPostion_X[i] < User_Position_X) && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "■"))
                    {
                        // D 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] + 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] + 1] = temp_;
                        enemyPostion_X[i]++;
                    }

                    // D 쪽이 벽이고, W 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_X[i] < User_Position_X) && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "■"))
                    {
                        // W 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] - 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]--;
                    }

                    // W 쪽이 벽이고, S 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "■"))
                    {
                        // S 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] + 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]++;
                    }

                    // S 쪽이 벽이고, A 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "■"))
                    {
                        // A 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] - 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] - 1] = temp_;
                        enemyPostion_X[i]--;
                    }

                    // 에너미 Y 위치가 플레이어 Y 위치보다 클 경우
                    else if ((enemyPostion_Y[i] > User_Position_Y) && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "■"))
                    {
                        // W 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] - 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]--;
                    }
                    // W 쪽이 벽이고, A 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] > User_Position_Y) && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "■"))
                    {
                        // A 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] - 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] - 1] = temp_;
                        enemyPostion_X[i]--;
                    }

                    // A 쪽이 벽이고, D 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] > User_Position_Y) && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "■"))
                    {
                        // D 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] + 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] + 1] = temp_;
                        enemyPostion_X[i]++;
                    }
                    // D 쪽이 벽이고, S 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] > User_Position_Y) && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "■"))
                    {
                        // S 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] + 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]++;
                    }

                    // 에너미 Y 위치가 플레이어 Y 위치보다 작을 경우
                    else if ((enemyPostion_Y[i] < User_Position_Y) && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "■"))
                    {
                        // S 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] + 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]++;
                    }

                    // S 쪽이 벽이고, A 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] < User_Position_Y) && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "■"))
                    {
                        // A 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] - 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] - 1] = temp_;
                        enemyPostion_X[i]--;
                    }

                    // A 쪽이 벽이고, D 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] < User_Position_Y) && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "■"))
                    {
                        // D 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] + 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] + 1] = temp_;
                        enemyPostion_X[i]++;
                    }

                    // D 쪽이 벽이고, W 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] < User_Position_Y) && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "■"))
                    {
                        // W 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] - 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]--;
                    }
                }
                if (logicStart == 2)
                {
                    // 에너미 x 위치가 플레이어 x 위치보다 작을 경우
                    if ((enemyPostion_X[i] < User_Position_X) && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "■"))
                    {
                        // D 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] + 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] + 1] = temp_;
                        enemyPostion_X[i]++;
                    }

                    // D 쪽이 벽이고, W 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_X[i] < User_Position_X) && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "■"))
                    {
                        // W 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] - 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]--;
                    }

                    // W 쪽이 벽이고, S 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "■"))
                    {
                        // S 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] + 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]++;
                    }

                    // S 쪽이 벽이고, A 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "■"))
                    {
                        // A 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] - 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] - 1] = temp_;
                        enemyPostion_X[i]--;
                    }

                    // 에너미 Y 위치가 플레이어 Y 위치보다 클 경우
                    else if ((enemyPostion_Y[i] > User_Position_Y) && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "■"))
                    {
                        // W 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] - 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]--;
                    }
                    // W 쪽이 벽이고, A 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] > User_Position_Y) && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "■"))
                    {
                        // A 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] - 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] - 1] = temp_;
                        enemyPostion_X[i]--;
                    }

                    // A 쪽이 벽이고, D 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] > User_Position_Y) && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "■"))
                    {
                        // D 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] + 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] + 1] = temp_;
                        enemyPostion_X[i]++;
                    }
                    // D 쪽이 벽이고, S 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] > User_Position_Y) && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "■"))
                    {
                        // S 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] + 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]++;
                    }

                    // 에너미 Y 위치가 플레이어 Y 위치보다 작을 경우
                    else if ((enemyPostion_Y[i] < User_Position_Y) && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "■"))
                    {
                        // S 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] + 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]++;
                    }

                    // S 쪽이 벽이고, A 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] < User_Position_Y) && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "■"))
                    {
                        // A 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] - 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] - 1] = temp_;
                        enemyPostion_X[i]--;
                    }

                    // A 쪽이 벽이고, D 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] < User_Position_Y) && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "■"))
                    {
                        // D 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] + 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] + 1] = temp_;
                        enemyPostion_X[i]++;
                    }

                    // D 쪽이 벽이고, W 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] < User_Position_Y) && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "■"))
                    {
                        // W 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] - 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]--;
                    }

                    // 에너미 x 위치가 플레이어 x 위치보다 클 경우
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "■"))
                    {
                        // A 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] - 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] - 1] = temp_;
                        enemyPostion_X[i]--;
                    }

                    // A 쪽이 벽이고, w쪽이 벽이 아니면
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "■"))
                    {
                        // W 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] - 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]--;
                    }

                    // W 쪽이 벽이고, s쪽이 벽이 아니면
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "■"))
                    {
                        // S 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] + 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]++;
                    }

                    // S 쪽이 벽이고, D쪽이 벽이 아니면 
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "■"))
                    {
                        // D 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] + 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] + 1] = temp_;
                        enemyPostion_X[i]++;
                    }
                }
                if (logicStart == 3)
                {
                    // 에너미 Y 위치가 플레이어 Y 위치보다 클 경우
                    if ((enemyPostion_Y[i] > User_Position_Y) && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "■"))
                    {
                        // W 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] - 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]--;
                    }
                    // W 쪽이 벽이고, A 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] > User_Position_Y) && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "■"))
                    {
                        // A 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] - 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] - 1] = temp_;
                        enemyPostion_X[i]--;
                    }

                    // A 쪽이 벽이고, D 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] > User_Position_Y) && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "■"))
                    {
                        // D 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] + 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] + 1] = temp_;
                        enemyPostion_X[i]++;
                    }
                    // D 쪽이 벽이고, S 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] > User_Position_Y) && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "■"))
                    {
                        // S 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] + 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]++;
                    }

                    // 에너미 Y 위치가 플레이어 Y 위치보다 작을 경우
                    else if ((enemyPostion_Y[i] < User_Position_Y) && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "■"))
                    {
                        // S 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] + 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]++;
                    }

                    // S 쪽이 벽이고, A 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] < User_Position_Y) && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "■"))
                    {
                        // A 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] - 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] - 1] = temp_;
                        enemyPostion_X[i]--;
                    }

                    // A 쪽이 벽이고, D 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] < User_Position_Y) && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "■"))
                    {
                        // D 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] + 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] + 1] = temp_;
                        enemyPostion_X[i]++;
                    }

                    // D 쪽이 벽이고, W 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] < User_Position_Y) && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "■"))
                    {
                        // W 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] - 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]--;
                    }
                    // 에너미 x 위치가 플레이어 x 위치보다 클 경우
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "■"))
                    {
                        // A 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] - 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] - 1] = temp_;
                        enemyPostion_X[i]--;
                    }

                    // A 쪽이 벽이고, w쪽이 벽이 아니면
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "■"))
                    {
                        // W 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] - 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]--;
                    }

                    // W 쪽이 벽이고, s쪽이 벽이 아니면
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "■"))
                    {
                        // S 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] + 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]++;
                    }

                    // S 쪽이 벽이고, D쪽이 벽이 아니면 
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "■"))
                    {
                        // D 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] + 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] + 1] = temp_;
                        enemyPostion_X[i]++;
                    }

                    // 에너미 x 위치가 플레이어 x 위치보다 작을 경우
                    else if ((enemyPostion_X[i] < User_Position_X) && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "■"))
                    {
                        // D 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] + 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] + 1] = temp_;
                        enemyPostion_X[i]++;
                    }

                    // D 쪽이 벽이고, W 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_X[i] < User_Position_X) && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "■"))
                    {
                        // W 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] - 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]--;
                    }

                    // W 쪽이 벽이고, S 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "■"))
                    {
                        // S 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] + 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]++;
                    }

                    // S 쪽이 벽이고, A 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "■"))
                    {
                        // A 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] - 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] - 1] = temp_;
                        enemyPostion_X[i]--;
                    }
                }
                if (logicStart == 4)
                {
                    // 에너미 Y 위치가 플레이어 Y 위치보다 작을 경우
                    if ((enemyPostion_Y[i] < User_Position_Y) && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "■"))
                    {
                        // S 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] + 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]++;
                    }

                    // S 쪽이 벽이고, A 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] < User_Position_Y) && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "■"))
                    {
                        // A 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] - 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] - 1] = temp_;
                        enemyPostion_X[i]--;
                    }

                    // A 쪽이 벽이고, D 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] < User_Position_Y) && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "■"))
                    {
                        // D 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] + 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] + 1] = temp_;
                        enemyPostion_X[i]++;
                    }

                    // D 쪽이 벽이고, W 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] < User_Position_Y) && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "■"))
                    {
                        // W 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] - 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]--;
                    }
                    // 에너미 x 위치가 플레이어 x 위치보다 클 경우
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "■"))
                    {
                        // A 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] - 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] - 1] = temp_;
                        enemyPostion_X[i]--;
                    }

                    // A 쪽이 벽이고, w쪽이 벽이 아니면
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "■"))
                    {
                        // W 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] - 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]--;
                    }

                    // W 쪽이 벽이고, s쪽이 벽이 아니면
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "■"))
                    {
                        // S 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] + 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]++;
                    }

                    // S 쪽이 벽이고, D쪽이 벽이 아니면 
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "■"))
                    {
                        // D 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] + 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] + 1] = temp_;
                        enemyPostion_X[i]++;
                    }

                    // 에너미 x 위치가 플레이어 x 위치보다 작을 경우
                    else if ((enemyPostion_X[i] < User_Position_X) && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "■"))
                    {
                        // D 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] + 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] + 1] = temp_;
                        enemyPostion_X[i]++;
                    }

                    // D 쪽이 벽이고, W 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_X[i] < User_Position_X) && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "■"))
                    {
                        // W 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] - 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]--;
                    }

                    // W 쪽이 벽이고, S 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "■"))
                    {
                        // S 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] + 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]++;
                    }

                    // S 쪽이 벽이고, A 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_X[i] > User_Position_X) && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "■"))
                    {
                        // A 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] - 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] - 1] = temp_;
                        enemyPostion_X[i]--;
                    }

                    // 에너미 Y 위치가 플레이어 Y 위치보다 클 경우
                    else if ((enemyPostion_Y[i] > User_Position_Y) && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] != "■"))
                    {
                        // W 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] - 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] - 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]--;
                    }
                    // W 쪽이 벽이고, A 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] > User_Position_Y) && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] - 1] != "■"))
                    {
                        // A 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] - 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] - 1] = temp_;
                        enemyPostion_X[i]--;
                    }

                    // A 쪽이 벽이고, D 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] > User_Position_Y) && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "▣") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "＠") && (map[enemyPostion_Y[i], enemyPostion_X[i] + 1] != "■"))
                    {
                        // D 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i], enemyPostion_X[i] + 1];
                        map[enemyPostion_Y[i], enemyPostion_X[i] + 1] = temp_;
                        enemyPostion_X[i]++;
                    }
                    // D 쪽이 벽이고, S 쪽이 벽이 아닐 경우
                    else if ((enemyPostion_Y[i] > User_Position_Y) && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "▣") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "＠") && (map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] != "■"))
                    {
                        // S 쪽으로 이동
                        string temp_ = map[enemyPostion_Y[i], enemyPostion_X[i]];
                        map[enemyPostion_Y[i], enemyPostion_X[i]] = map[enemyPostion_Y[i] + 1, enemyPostion_X[i]];
                        map[enemyPostion_Y[i] + 1, enemyPostion_X[i]] = temp_;
                        enemyPostion_Y[i]++;
                    }
                }
            }
        }
    }
}
