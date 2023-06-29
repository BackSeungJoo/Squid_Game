using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Squid_Game
{
    public class Game2
    {
        public bool PlayGame_2(ref int player_Win_Count)
        {
            Clear();
            // { 변수 선언
            // 맵 출력을 위한 변수
            int sceneEndLine_Y = 13;
            int sceneEndLine_X = 50;
            string[,] game2_map = new string[sceneEndLine_Y, sceneEndLine_X];

            // 플레이어 위치 좌표
            int User_Position_Y = sceneEndLine_Y / 2;
            int User_Position_X = 1;

            // 무궁화꽃이피었습니다 글귀를 위한 변수
            int text_Count = 0;
            List<string> flower_Text = new List<string> { "　", "무", "궁", "화", "꽃", "이", "피", "었", "습", "니", "다!" };
            int cursorCount = 0;
            int noMove_Count = 0;
            bool is_game = true;

            // 초기 맵 세팅
            Set_Map_Game2(ref game2_map, sceneEndLine_Y, sceneEndLine_X, User_Position_Y, User_Position_X, noMove_Count);
            Set_Boss_State(ref game2_map, sceneEndLine_Y, sceneEndLine_X, User_Position_Y, User_Position_X, noMove_Count);
            Set_Stone(ref game2_map, sceneEndLine_Y, sceneEndLine_X);
            CursorVisible = false;


            // 게임 시작
            while (is_game == true)
            {
                SetCursorPosition(0, 0);

                SetCursorPosition(30, 2);
                WriteLine("WASD를 이용해서 골라인 까지 이동하세요!");
                SetCursorPosition(38, 4);
                WriteLine("X를 눌르면 대기합니다.");
                SetCursorPosition(16, 6);
                WriteLine("영희가 [ 무궁화 꽃이 피었습니다! ]를 모두 외쳤을 때 움직이면 탈락!!");

                // 대기 시간인지 판별
                if (noMove_Count > 0)
                {
                    Clear();
                    SetCursorPosition(15, 6);
                    WriteLine("대기시간, 대기시간, 움직이면 탈락합니다. X를 눌러 대기시간을 줄이세요. {0}", noMove_Count);
                }

                if (noMove_Count == 0)
                {
                    SetCursorPosition(14, 6);
                    WriteLine("　　영희가 [ 무궁화 꽃이 피었습니다! ]를 모두 외쳤을 때 움직이면 탈락!!　　　　　");
                }

                // 맵 출력
                Print_Map(game2_map, sceneEndLine_Y, sceneEndLine_X);

                // 플레이어 이동 & 액션
                User_Move(ref game2_map, sceneEndLine_Y, sceneEndLine_X, ref User_Position_Y, ref User_Position_X, ref noMove_Count, ref is_game, ref text_Count, ref cursorCount, ref player_Win_Count);

                // 무궁화 꽃이 ... 문구 출력
                Print_Flower_Text(flower_Text, ref text_Count, ref cursorCount, ref noMove_Count);

                // 영희 모습 변경
                Set_Boss_State(ref game2_map, sceneEndLine_Y, sceneEndLine_X, User_Position_Y, User_Position_X, noMove_Count);
            }
            return false;
        }

        // 게임 맵 세팅
        static public void Set_Map_Game2(ref string[,] game2_map, int sceneEndLine_Y, int sceneEndLine_X, int User_Position_Y, int User_Position_X, int noMove_Count)
        {
            for (int y = 0; y < sceneEndLine_Y; y++)
            {
                for (int x = 0; x < sceneEndLine_X; x++)
                {
                    // 맵 테두리 세팅
                    if ((y == 0) || (x == 0) || (y == sceneEndLine_Y - 1) || (x == sceneEndLine_X - 1))
                    {
                        game2_map[y, x] = "■";
                        continue;
                    }

                    // 플레이어 세팅
                    if ((y == User_Position_Y) && (x == User_Position_X))
                    {
                        game2_map[y, x] = "◎";
                        continue;
                    }

                    // 골 지점 세팅
                    if (((0 < y) && (y < sceneEndLine_Y - 1)) && (x == sceneEndLine_X - 7))
                    {
                        game2_map[y, x] = "＠";
                        continue;
                    }

                    // 바닥 생성
                    game2_map[y, x] = "□";
                }
            }
        }   // 게임 맵 세팅 end

        // 보스 영희 세팅
        static public void Set_Boss_State(ref string[,] game2_map, int sceneEndLine_Y, int sceneEndLine_X, int User_Position_Y, int User_Position_X, int noMove_Count)
        {
            for (int y = 0; y < sceneEndLine_Y; y++)
            {
                for (int x = 0; x < sceneEndLine_X; x++)
                {
                    // 영희 세팅 (뒤돌아 있을 때)
                    if (noMove_Count == 0)
                    {
                        if (((5 <= y) && (y <= 7)) && (x == 48))
                        {
                            game2_map[y, x] = "●";
                            continue;
                        }

                        if (((5 <= y) && (y <= 7)) && ((46 <= x) && (x <= 47)))
                        {
                            game2_map[y, x] = "○";
                            continue;
                        }
                    }
                    // 영희 세팅 (앞 보고 있을 때)
                    else if (noMove_Count > 0)
                    {
                        if (((5 <= y) && (y <= 7)) && (x == 46))
                        {
                            game2_map[y, x] = "●";
                            continue;
                        }

                        if (((5 <= y) && (y <= 7)) && ((47 <= x) && (x <= 48)))
                        {
                            game2_map[y, x] = "○";
                            continue;
                        }
                    }
                }
            }
        }   // 보스 영희 세팅 end

        // 미로 돌 세팅
        static public void Set_Stone(ref string[,] game2_map, int sceneEndLine_Y, int sceneEndLine_X)
        {
            for (int y = 0; y < sceneEndLine_Y; y++)
            {
                for (int x = 0; x < sceneEndLine_X; x++)
                {
                    // 미로 돌 세팅
                    if (((1 <= y) && (y <= sceneEndLine_Y - 2)) && (!(x <= 4) && (x % 3 == 0)) && !(x >= 42))
                    {
                        game2_map[y, x] = "▣";

                        if ((x % 6 == 0) && (y == 1))
                        {
                            game2_map[y, x] = "□";
                        }

                        if ((x % 6 == 3) && (y == sceneEndLine_Y - 2))
                        {
                            game2_map[y, x] = "□";
                        }
                    }
                }
            }
        }

        // 맵 출력
        static void Print_Map(string[,] game2_map, int sceneEndLine_Y, int sceneEndLine_X)
        {
            int startY = 10; // 시작 Y 좌표

            for (int y = 0; y < sceneEndLine_Y; y++)
            {
                SetCursorPosition(0, startY + y); // 시작 Y 좌표 설정

                for (int x = 0; x < sceneEndLine_X; x++)
                {
                    // 벽 색상 변경
                    if (game2_map[y, x] == "■")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(game2_map[y, x]);
                        Console.ResetColor();
                        continue;
                    }

                    // 플레이어 색상 변경
                    if (game2_map[y, x] == "◎")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(game2_map[y, x]);
                        Console.ResetColor();
                        continue;
                    }

                    // 골 지점 색상 변경
                    if(game2_map[y, x] == "＠")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(game2_map[y, x]);
                        Console.ResetColor();
                        continue;
                    }

                    // 영희 색상 변경
                    if (game2_map[y, x] == "●")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(game2_map[y, x]);
                        Console.ResetColor();
                        continue;
                    }

                    // 영희 색상 변경
                    if (game2_map[y, x] == "○")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write(game2_map[y, x]);
                        Console.ResetColor();
                        continue;
                    }

                    // 미로 색상 변경
                    if(game2_map[y, x] == "▣")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(game2_map[y, x]);
                        Console.ResetColor();
                        continue;
                    }
                    
                    // 바닥 색상 변경
                    if (game2_map[y, x] == "□")
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(game2_map[y, x]);
                        Console.ResetColor();
                        continue;
                    }
                }
                Console.WriteLine();
            }
        }
        // 맵 출력 end

        // 플레이어 이동
        static public void User_Move(ref string[,] game2_map, int sceneEndLine_Y, int sceneEndLine_X, ref int User_Position_Y, ref int User_Position_X, ref int noMove_Count, ref bool is_game, ref int text_Count, ref int cursorCount, ref int player_Win_Count)
        {
            ConsoleKey user_Move = Console.ReadKey(true).Key;

            // A 입력 (왼쪽이동)
            if (user_Move == ConsoleKey.A)
            {
                if (noMove_Count > 0)  // 대기시간 일 때 움직이면
                {
                    Print_Game_End(ref is_game);
                    is_game = false;
                }
                else
                {
                    Swap_Move_A(ref game2_map, ref User_Position_Y, ref User_Position_X, sceneEndLine_Y, sceneEndLine_X);
                }
                
            }

            // D 입력 (오른쪽이동)
            if (user_Move == ConsoleKey.D)
            {
                if (noMove_Count > 0)  // 대기시간 일 때 움직이면
                {
                    Print_Game_End(ref is_game);
                    is_game = false;
                }
                else
                { 
                    Swap_Move_D(ref game2_map, ref User_Position_Y, ref User_Position_X, sceneEndLine_Y, sceneEndLine_X, ref is_game, ref player_Win_Count);
                }
            }

            // W 입력 (위쪽이동)
            if (user_Move == ConsoleKey.W)
            {
                if (noMove_Count > 0)  // 대기시간 일 때 움직이면
                {
                    Print_Game_End(ref is_game);
                    is_game = false;
                }
                else
                {
                    Swap_Move_W(ref game2_map, ref User_Position_Y, ref User_Position_X, sceneEndLine_Y, sceneEndLine_X);
                }
                
            }

            // S 입력 (아래쪽이동)
            if (user_Move == ConsoleKey.S)
            {
                if (noMove_Count > 0)  // 대기시간 일 때 움직이면
                {
                    Print_Game_End(ref is_game);
                    is_game = false;
                }
                else
                {
                    Swap_Move_S(ref game2_map, ref User_Position_Y, ref User_Position_X, sceneEndLine_Y, sceneEndLine_X);
                }
                
            }

            // X 입력 (대기시간 해소)
            if (user_Move == ConsoleKey.X)
            {
                noMove_Count--;
                text_Count = 0;
                cursorCount = 0;
            }
        }

        // A 이동
        static public void Swap_Move_A(ref string[,] game2_map, ref int User_Position_Y, ref int User_Position_X, int sceneEndLine_Y, int sceneEndLine_X)
        {
            // 벽이 아닐 경우
            if ((game2_map[User_Position_Y, User_Position_X - 1] != "■") && (game2_map[User_Position_Y, User_Position_X - 1] != "▣"))
            {
                string temp_ = game2_map[User_Position_Y, User_Position_X];
                game2_map[User_Position_Y, User_Position_X] = game2_map[User_Position_Y, User_Position_X - 1];
                game2_map[User_Position_Y, User_Position_X - 1] = temp_;
                User_Position_X--;
            }

            else { /*pass*/ }
        }
        // D 이동
        static public void Swap_Move_D(ref string[,] game2_map, ref int User_Position_Y, ref int User_Position_X, int sceneEndLine_Y, int sceneEndLine_X, ref bool is_game, ref int player_Win_Count)
        {
            // 벽이 아닐 경우
            if ((game2_map[User_Position_Y, User_Position_X + 1] != "■") && (game2_map[User_Position_Y, User_Position_X + 1] != "▣"))
            {
                // 골지점이면 최종 승리
                if (game2_map[User_Position_Y, User_Position_X + 1] == "＠")
                {
                    Win_Game_End(ref is_game, ref player_Win_Count);
                }

                // 아닐 경우 그냥 이동
                else
                {
                    string temp_ = game2_map[User_Position_Y, User_Position_X];
                    game2_map[User_Position_Y, User_Position_X] = game2_map[User_Position_Y, User_Position_X + 1];
                    game2_map[User_Position_Y, User_Position_X + 1] = temp_;
                    User_Position_X++;
                }
                
            }

            else { /*pass*/ }
        }
        // W 이동
        static public void Swap_Move_W(ref string[,] game2_map, ref int User_Position_Y, ref int User_Position_X, int sceneEndLine_Y, int sceneEndLine_X)
        {
            // 벽이 아닐 경우
            if ((game2_map[User_Position_Y - 1, User_Position_X] != "■") && (game2_map[User_Position_Y - 1, User_Position_X] != "▣"))
            {
                string temp_ = game2_map[User_Position_Y, User_Position_X];
                game2_map[User_Position_Y, User_Position_X] = game2_map[User_Position_Y - 1, User_Position_X];
                game2_map[User_Position_Y - 1, User_Position_X] = temp_;
                User_Position_Y--;
            }

            else { /*pass*/ }
        }
        // S 이동
        static public void Swap_Move_S(ref string[,] game2_map, ref int User_Position_Y, ref int User_Position_X, int sceneEndLine_Y, int sceneEndLine_X)
        {
            // 벽이 아닐 경우
            if ((game2_map[User_Position_Y + 1, User_Position_X] != "■") && (game2_map[User_Position_Y + 1, User_Position_X] != "▣"))
            {
                string temp_ = game2_map[User_Position_Y, User_Position_X];
                game2_map[User_Position_Y, User_Position_X] = game2_map[User_Position_Y + 1, User_Position_X];
                game2_map[User_Position_Y + 1, User_Position_X] = temp_;
                User_Position_Y++;
            }

            else { /*pass*/ }
        }
        // 플레이어 이동 end

        // 무궁화 꽃이 피었습니다. 무한 반복
        static public void Print_Flower_Text(List<string> flower_Text, ref int text_Count, ref int cursorCount, ref int noMove_Count)
        {
            Random random = new Random();
            int ptr_Text = random.Next(0, 2);

            // 0일 때 무시
            if (ptr_Text == 0)
            {
                /*pass*/
            }

            // 1일 때 출력
            else if(ptr_Text == 1)
            {
                SetCursorPosition(30 + cursorCount, 8);

                // 현재 텍스트 출력
                Console.ForegroundColor = ConsoleColor.Red;
                Write("{0}", flower_Text[text_Count]);
                ResetColor();

                // 다음 텍스트를 위해 text_Count 증가
                text_Count++;


                if (text_Count >= flower_Text.Count)
                {
                    // 이때 움직이면 게임 종료
                    noMove_Count = 3;

                    text_Count = 0; // text_Count가 리스트 범위를 초과하면 처음으로 되돌아감
                    cursorCount = 0;
                }

                else
                {
                    cursorCount = cursorCount + 4;
                }

                
            }
        }

        // 게임 패배 종료
        static public void Print_Game_End(ref bool is_game)
        {
            Clear();
            is_game = false;
            ForegroundColor = ConsoleColor.Red;
            WriteLine("펑!");
            WriteLine("당신은 대기시간에 움직였습니다.");
            WriteLine("영희의 레이저에 맞아 폭발했습니다.\n");
            WriteLine("아무키나 눌러 메인 대기실로 돌아가세요.");
            ResetColor();
            ReadKey();
        }

        // 게임 최종 승리
        static public void Win_Game_End(ref bool is_game, ref int player_Win_Count)
        {
            Clear();
            is_game = false;
            player_Win_Count = 1;
            ForegroundColor = ConsoleColor.Green;
            WriteLine("!!!!!!!!");
            WriteLine("당신은 살아남았습니다.");
            WriteLine("축하합니다. 2 라운드 클리어입니다.\n");
            WriteLine("아무키나 눌러 메인 대기실로 돌아가세요.");
            ResetColor();
            ReadKey();
        }
    }
}
