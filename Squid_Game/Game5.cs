using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Squid_Game
{
    public class Game5
    {
        public bool PlayGame_5(ref int player_Win_Count)
        {
            Console.Clear();
            // 변수 선언
            // 맵 사이즈
            int sceneEndLine_Y = 13;
            int sceneEndLine_X = 27;
            string[,] game_Map5 = new string[sceneEndLine_Y, sceneEndLine_X];
            List<string> quiz_WASD = new List<string>();
            List<string> user_WASD = new List<string>();

            bool is_game = true;
            int correct_Count = 0;  // 정답 횟수
            int wrong_Count = 0;    // 오답 횟수
            int end_Count = 10;     // 14면 플레이어 승리, 6이면 상대방 승리

            int startY = 3;                         // y 시작 위치
            int endY = game_Map5.GetLength(0) - 3;  // y 종료 위치
            int startX = 6;                         // x 시작 위치
            int endX = 20;                          // X 종료 위치
                // 변수 선언 end

            // 초기 맵 세팅
            Set_Map_Game5(ref game_Map5, sceneEndLine_Y, sceneEndLine_X);
            Console.CursorVisible = false;

            while(is_game)
            {
                // 맵 출력
                Console.SetCursorPosition(0, 2);
                Print_Map_Game5(game_Map5, sceneEndLine_Y, sceneEndLine_X);

                // 규칙 설명
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("[ 줄다리기 게임 ]에 오신 것을 환영합니다.");
                Console.SetCursorPosition(55, 2);
                Console.WriteLine("<  규칙  >");
                Console.SetCursorPosition(55, 4);
                Console.Write("숫자1 을 누르면  ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[ W A S D X ]");
                Console.ResetColor();
                Console.Write("가 랜덤하게 5개 등장합니다");
                Console.SetCursorPosition(55, 6);
                Console.WriteLine("무작위 5개의 글자는 1초 후에 사라집니다. 순서를 기억하세요!!");
                Console.ResetColor();
                Console.SetCursorPosition(55, 8);
                Console.WriteLine("글자가 사라진 뒤 ,,,");
                Console.SetCursorPosition(55, 10);
                Console.WriteLine("맞춘다면 참가자의 팀 쪽으로 줄을 잡아당깁니다.");
                Console.SetCursorPosition(55, 11);
                Console.WriteLine("틀린다면 참가자의 적 팀 쪽으로 줄을 잡아당깁니다.");
                Console.SetCursorPosition(55, 14);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("줄을 끝까지 당기면 승리합니다!");

                Console.SetCursorPosition(38, 18);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("이곳에 문자가 나타납니다. [숫자1]");
                Console.SetCursorPosition(10, 15);
                Console.ForegroundColor= ConsoleColor.Red;
                Console.Write("틀린 횟수 : {0:D2}", wrong_Count);
                Console.SetCursorPosition(31, 15);
                Console.ForegroundColor= ConsoleColor.Green;
                Console.Write("{0:D2} : 맞춘 횟수      ", correct_Count);
                Console.ResetColor();
                Console.SetCursorPosition(0, 0);


                // 퀴즈 출력 ( 숫자 1번을 누르면 게임 시작)
                ConsoleKey start = Console.ReadKey(true).Key;
                Quiz(ref game_Map5, ref quiz_WASD, ref user_WASD, start, ref correct_Count, ref wrong_Count, ref startY, ref endY, ref startX, ref endX, ref end_Count);

                // 승리
                if(end_Count >= 14)
                {
                    // 맞춘 횟수 재 출력
                    Console.SetCursorPosition(31, 15);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0} : 맞춘 횟수      ", correct_Count);

                    // 문자 출력한 곳 지우기
                    Console.SetCursorPosition(50, 20);
                    Console.WriteLine("　　　　　　　　　　　　　");
                    Console.SetCursorPosition(50, 21);
                    Console.WriteLine("　　　　　　　　　　　　　　　　　");
                    Console.SetCursorPosition(48, 22);
                    Console.WriteLine("　　　　　　　　　　　　　");
                    Console.SetCursorPosition(40, 24);
                    Console.WriteLine("　　　　　　　　　　　　　　　　　");
                    Console.SetCursorPosition(40, 26);
                    Console.WriteLine("　　　　　　　　　　　　　　　　　");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(48, 22);
                    Console.WriteLine("축 하 합 니 다 !");
                    Console.SetCursorPosition(37, 24);
                    Console.WriteLine("줄을 끝까지 당겨 5라운드 승리입니다.");
                    Console.SetCursorPosition(36, 26);
                    Console.WriteLine("아무키를 눌러 메인 대기실로 돌아가세요");
                    Console.ReadKey();
                    Console.ResetColor();
                    is_game = false;
                    player_Win_Count = 1;


                }

                // 패배
                if(end_Count <= 6)
                {
                    // 틀린 횟수 재 출력
                    Console.SetCursorPosition(10, 15);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("틀린 횟수 : {0}", wrong_Count);

                    // 문자 출력한 곳 지우기
                    Console.SetCursorPosition(50, 20);
                    Console.WriteLine("　　　　　　　　　　　　　");
                    Console.SetCursorPosition(50, 21);
                    Console.WriteLine("　　　　　　　　　　　　　　　　　");
                    Console.SetCursorPosition(48, 22);
                    Console.WriteLine("　　　　　　　　　　　　　");
                    Console.SetCursorPosition(40, 24);
                    Console.WriteLine("　　　　　　　　　　　　　　　　　");
                    Console.SetCursorPosition(40, 26);
                    Console.WriteLine("　　　　　　　　　　　　　　　　　");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(48, 22);
                    Console.WriteLine("탈 락 입 니 다 !");
                    Console.SetCursorPosition(39, 24);
                    Console.WriteLine("상대팀이 줄을 끝까지 당겼습니다.");
                    Console.SetCursorPosition(36, 26);
                    Console.WriteLine("아무키를 눌러 메인 대기실로 돌아가세요");
                    Console.ReadKey();
                    Console.ResetColor();
                    is_game = false;
                }
            }
            Console.Clear();
            return false;
        }

        // 초기 맵 세팅
        public void Set_Map_Game5(ref string[,] game_Map5, int sceneEndLine_Y, int sceneEndLine_X)
        {
            for (int y = 0; y < sceneEndLine_Y; y++)
            {
                for (int x = 0; x < sceneEndLine_X; x++)
                {
                    // 벽 세팅
                    if ((y == 0) || (x == 0) || (y == sceneEndLine_Y - 1) || (x == sceneEndLine_X - 1))
                    {
                        game_Map5[y, x] = "■";
                        continue;
                    }

                    // 줄 세팅
                    if ((y == sceneEndLine_Y / 2) && ((7 <= x) && (x <= 19)))
                    {
                        game_Map5[y, x] = "〓";
                        continue;
                    }

                    // 중간 끈 세팅
                    if ((y == (sceneEndLine_Y / 2) - 1) && (x == 13))
                    {
                        game_Map5[y, x] = "▼";
                        continue;
                    }

                    // 플레이어 세팅
                    if ((y == (sceneEndLine_Y / 2) - 1) && (x == 15))
                    {
                        game_Map5[y, x] = "◎";
                        continue;
                    }

                    // 플레이어 팀 세팅
                    if (((y == (sceneEndLine_Y / 2) - 1) && ((x == 17) || (x == 19))) || ((y == (sceneEndLine_Y / 2) + 1) && ((x == 16) || (x == 18))))
                    {
                        game_Map5[y, x] = "○";
                        continue;
                    }

                    // 적 팀 세팅
                    if (((y == (sceneEndLine_Y / 2) - 1) && ((x == 8) || (x == 10))) || ((y == (sceneEndLine_Y / 2) + 1) && ((x == 7) || (x == 9) || (x == 11))))
                    {
                        game_Map5[y, x] = "●";
                        continue;
                    }

                    game_Map5[y, x] = "□";
                }
            }
        }

        // 맵 출력
        public void Print_Map_Game5(string[,] game_Map5, int sceneEndLine_Y, int sceneEndLine_X)
        {
            for (int y = 0; y < sceneEndLine_Y; y++)
            {
                for (int x = 0; x < sceneEndLine_X; x++)
                {
                    // 벽 색상 변경
                    if (game_Map5[y, x] == "■")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(game_Map5[y, x]);
                        Console.ResetColor();
                        continue;
                    }

                    // 줄 색상 변경
                    if (game_Map5[y, x] == "〓")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(game_Map5[y, x]);
                        Console.ResetColor();
                        continue;
                    }

                    // 바닥 색상 변경
                    if (game_Map5[y, x] == "□")
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(game_Map5[y, x]);
                        Console.ResetColor();
                        continue;
                    }

                    // 끈 색상 변경
                    if (game_Map5[y, x] == "▼")
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(game_Map5[y, x]);
                        Console.ResetColor();
                        continue;
                    }

                    // 플레이어 세팅
                    if (game_Map5[y, x] == "◎")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(game_Map5[y, x]);
                        Console.ResetColor();
                        continue;
                    }

                    // 플레이어 팀 세팅
                    if (game_Map5[y, x] == "○")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(game_Map5[y, x]);
                        Console.ResetColor();
                        continue;
                    }

                    // 적 팀 세팅
                    if (game_Map5[y, x] == "●")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(game_Map5[y, x]);
                        Console.ResetColor();
                        continue;
                    }

                }
                Console.WriteLine();
            }
        }

        // 퀴즈 출력
        public void Quiz(ref string[,] game_Map5, ref List<string> quiz_WASD, ref List<string> user_WASD, ConsoleKey start, ref int correct_Count, ref int wrong_Count, ref int startY, ref int endY, ref int startX, ref int endX, ref int end_Count)
        {
            int sameCount_ = 0; // 리스트의 글자들이 같은지 비교할 때 사용

            if (start == ConsoleKey.D1)
            {
                // 문자 출력한 곳 지우기
                Console.SetCursorPosition(50, 20);
                Console.WriteLine("　　　　　　　　　　　　　");
                Console.SetCursorPosition(50, 21);
                Console.WriteLine("　　　　　　　　　　　　　　　　　");
                Console.SetCursorPosition(48, 22);
                Console.WriteLine("　　　　　　　　　　　　　");
                Console.SetCursorPosition(40, 24);
                Console.WriteLine("　　　　　　　　　　　　　　　　　");
                Console.SetCursorPosition(40, 26);
                Console.WriteLine("　　　　　　　　　　　　　　　　　");

                // 랜덤한 5개의 글자를 출력해서 리스트에 담습니다.
                Random random = new Random();

                for (int i = 0; i < 5; i++)
                {
                    int number_ = random.Next(0, 5);

                    if (number_ == 0)
                    {
                        quiz_WASD.Add("W");
                    }

                    else if (number_ == 1)
                    {
                        quiz_WASD.Add("A");
                    }

                    else if (number_ == 2)
                    {
                        quiz_WASD.Add("S");
                    }

                    else if (number_ == 3)
                    {
                        quiz_WASD.Add("D");
                    }

                    else if (number_ == 4)
                    {
                        quiz_WASD.Add("X");
                    }
                }

                //3,2,1 딜레이 출력
                Console.ForegroundColor = ConsoleColor.Green;

                for (int i = 3; i > 0; i--)
                {
                    Console.SetCursorPosition(54, 20);
                    Thread.Sleep(250);
                    Console.Write("{0}", i);
                }

                Thread.Sleep(200);
                Console.SetCursorPosition(50, 20);

                // 퀴즈 5글자가 여기서 출력 됨.
                foreach (string listnum in quiz_WASD)
                {
                    Console.Write("{0} ", listnum);
                }
                Console.ResetColor();

                // 아래에 3,2,1 딜레이 걸고 출력된 글자 없앰
                for (int i = 3; i > 0; i--)
                {
                    Console.SetCursorPosition(54, 21);
                    Thread.Sleep(250);
                    Console.Write("{0}.", i);
                }

                // 문자 출력한 곳 지우기
                Console.SetCursorPosition(50, 20);
                Console.WriteLine("　　　　　　　　　　　　　");
                Console.SetCursorPosition(50, 21);
                Console.WriteLine("　　　　　　　　　　　　　　　　　");
                Console.SetCursorPosition(48, 22);
                Console.WriteLine("　　　　　　　　　　　　　");
                Console.SetCursorPosition(40, 24);
                Console.WriteLine("　　　　　　　　　　　　　　　　　");
                Console.SetCursorPosition(40, 26);
                Console.WriteLine("　　　　　　　　　　　　　　　　　");

                Player_Answer(ref user_WASD);

                for (int i = 0; i < 5; i++)
                {
                    if (quiz_WASD[i] == user_WASD[i])
                    {
                        sameCount_++;
                    }
                }

                if (sameCount_ == 5)
                {
                    Jump_rope_D(ref game_Map5, startY, startX, endY, endX);
                    endX++;
                    startX++;
                    Console.SetCursorPosition(48, 22);
                    Console.WriteLine("정 답 입 니 다!");
                    Console.SetCursorPosition(42, 24);
                    Console.WriteLine("1번을 눌러 다시 시작하세요!");
                    Console.SetCursorPosition(60, 21);
                    quiz_WASD.Clear();
                    user_WASD.Clear();
                    correct_Count++;
                    end_Count++;
                }

                else
                {
                    Jump_rope_A(ref game_Map5, startY, startX, endY, endX);
                    endX--;
                    startX--;
                    Console.SetCursorPosition(48, 22);
                    Console.WriteLine("오 답 입 니 다!");
                    Console.SetCursorPosition(42, 24);
                    Console.WriteLine("1번을 눌러 다시 시작하세요!");
                    Console.SetCursorPosition(60, 21);
                    quiz_WASD.Clear();
                    user_WASD.Clear();
                    wrong_Count++;
                    end_Count--;
                }
            }


            // 5개의 리스트의 문자를 출력합니다.

            // 플레이어가 입력합니다.

            // 플레이어의 문자를 리스트에 담습니다.

            // 두 리스트가 동일하다면 퀴즈 성공, 아니면 실패
        }

        // 플레이어 입력
        public void Player_Answer(ref List<string> user_WASD)
        {
            for (int i = 0; i < 5; i++)
            {
                int x = 0;
                ConsoleKey userInput_ = Console.ReadKey(true).Key;

                user_WASD.Add(userInput_.ToString());

                Console.SetCursorPosition(52 + i + x, 20);
                Console.Write("{0} ", user_WASD[i]);
                x = x + 2;
            }
            
        }

        // 퀴즈 풀고 줄다리기 모션 연출
        public void Jump_rope_A(ref string[,] game_Map5, int startY, int startX, int endY, int endX)
        {
            string temp = game_Map5[startY, startX - 1];
            for (int y = startY; y <= endY; y++)
            {
                for (int x = startX; x <= endX; x++)
                {
                    game_Map5[y, x - 1] = game_Map5[y, x];
                }
            }
            game_Map5[startY, endX] = temp;
        }

        // 퀴즈 풀고 줄다리기 모션 연출
        public void Jump_rope_D(ref string[,] game_Map5, int startY, int startX, int endY, int endX)
        {
            string temp = game_Map5[startY, startX + 1];
            for (int y = startY; y <= endY; y++)
            {
                for (int x = endX; x >= startX; x--)
                {
                    game_Map5[y, x + 1] = game_Map5[y, x];
                }
            }
            game_Map5[startY, endX] = temp;
        }
    }
}
