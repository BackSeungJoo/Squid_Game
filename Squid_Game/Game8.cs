using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Squid_Game
{
    public class Game8
    {
        public bool PlayGame_8(ref int player_Win_Count)
        {
            Console.Clear();
            // { 변수 선언
            // 맵 사이즈
            int sceneEndLine_Y = 25;
            int sceneEndLine_X = 50;
            string[,] game_Map8 = new string[sceneEndLine_Y, sceneEndLine_X];

            bool is_Game = true;

            // 텍스트 출력 y줄 을 위한 변수
            int text_PosY = 5;

            // { 텍스트 세팅 (엄청 김)
            // 1번 텍스트
            List<string> Text_One = new List<string>
            {"\t\t\t당신은 마지막까지 살아남았습니다.",
            " ",
            "\t\t\t   최종승리까지 남은 게임 ... 1",
            "\t\t\t                남은 상대 ... 1",
            " ",
            " ",
            "\t\t\t마지막 게임의 규칙은 간단합니다.",
            "\t\t\t 서로 짧은 칼 하나가 주어집니다.",
            "\t     그것으로 상대를 죽이면 게임을 승리하고 456억을 획득합니다.\n\n",
            " ",
            " ",
            "\t\t\t    마지막 게임 시작합니다..."};

            // 2번 텍스트
            List<string> Text_Two = new List<string>
            {"(쏴아아악.... )",
            " ",
            "운동장에 폭우가 쏟아집니다.",
            "운동장 주위로 게임 관계자 수십 명이 정렬해 서있습니다.",
            "현재 당신은 공격자로 지정되어 수비자인 상대방과 대치중입니다...",
            " ",
            " ",
            "상대방과의 거리는 점점 좁혀집니다.",
            "상대방의 얼굴을 제대로 볼 수 있을 정도로 둘은 가까워 졌습니다.",
            " ",
            " ",
            "!!!!! 당신은 깜짝 놀랐습니다.",
            "가까이에서 자세히 보니 상대방은 당신의 제일 친한 친구였습니다.",
            "당신의 친구 또한 당신을 알아보고 흠칫 놀랍니다.",
            " ",
            " ",
            "놀란 당신은 마음을 진정시키고 거리를 살짝 벌립니다.",
            "당신은 친구와 대화를 시작합니다."};

            // 3번 텍스트
            List<string> Text_Three = new List<string>
            {"친구의 얘기를 들어보니,,,",
            " ",
            "친구는 졸업 후 좋은 직장에 취업해서 남 부럽지 않은 삶을 살았습니다.",
            "그러다 지인으로 부터 좋은 주식 종목을 추천받았고, 처음에는 수익을 내다가 손실을 보았습니다.",
            "친구는 손실을 메꾸기 위해 빚을 지면서 계속 물타기를 해보았지만... ",
            " ",
            " ",
            "결국 해당 종목은 상장폐지가 되어 막대한 빚을 지게 되었습니다.",
            " ",
            "친구는 어렸을 적 부모님께서 이혼해 어머니와 단 둘이 지냈습니다.",
            "당신 또한 친구의 어렸을 때 부터 친구였기 때문에 친구의 힘든 사정들을 알고 있었습니다.",
            "당신은 이내 마음이 먹먹해 집니다."};

            // 4번 텍스트
            List<string> Text_Four = new List<string>
            {"친구는 지금은 나이가 많이 들어 거동조차 힘든 어머니를 ",
            "부양조차 하기 힘든 상태까지 내몰리다가 ",
            "결국... 이 게임에 참여하게 되었습니다.",
            " ",
            " ",
            "친구는 울면서 당신에게 게임을 포기하라고 말합니다.",
            " ",
            " ",
            "친구의 말을 들은 당신은 지금까지의 게임을 떠올립니다. ",
            "\'내가 어떻게 여기까지 왔는데... ...\'",
            " ",
            " ",
            "망설이는 당신을 향해 친구가 미안하단 말과 함께 짧은 칼을 휘두릅니다.",
            "당신은 본능적으로 칼을 한번,,, 두번,,,  세번,,, 피하고 결국 반격합니다.",
            " ",
            "서로의 몸에 상처가 나기 시작합니다."};

            // 5번 텍스트
            List<string> Text_Five = new List<string>
            {"시간이 얼마나 지났는지 서로의 몸은 피투성이가 되었습니다.",
            " ",
            " ",
            "(풀썩...)",
            "친구가 숨을 헐떡이며 쓰러집니다.",
            "당신은 당신이 승리했음을 알 수 있었습니다...",
            " ",
            "곧이어,",
            "쓰러진 친구를 향해 게임 관리자 5명이 총을 겨눕니다.",
            "당신이 마무리하지 않아도 곧 친구는 게임에서 탈락할 것입니다.",
            " ",
            " ",
            "마음이 약해진 당신은 고뇌에 빠집니다.",
            " ",
            "선택하세요. ",
            "- 1. 친구를 위해 게임을 포기합니다.",
            "- 2. 친구의 마지막 숨을 거둡니다.",
            "- 3. 친구를 놔두고 마지막 승리의 문으로 들어갑니다 ",
            " "};

            // 선택 분기 1 텍스트
            List<string> Text_Select_1 = new List<string>
            {"첫 번째 관리자가 친구를 향해 방아쇠를 당기려고 하는 순간",
            "당신은 다급하게 소리집니다.",
            " ",
            "\"포기!!!\"",
            "\"게임... 게임을 포기합니다!!! !!!\"",
            " ",
            "순간 운동장이 고요해졌습니다.",
            "(\"삐이이익!!!! 게임 종료!!!\")",
            " ... ... ... ... ...",
            " ",
            "\"고... 고마워..\"",
            "당신이 게임을 포기해 최종 승리자는 친구로 결정되었습니다.",
            "친구는 456억을 획득해 기쁜 마음으로 승리의 문을 나갑니다.",
            " ",
            "당신은 친구를 위해 456억을 포기하는 멋진 사람입니다.",
            "그렇지만 친구는 당신을 위해 한 푼도 나누어주지 않았습니다.",
            "당신은 빚 독촉에 시달리다 다시 오징어 게임에 참여합니다.",
            " "};

            // 선택 분기 2 텍스트
            List<string> Text_Select_2 = new List<string>
            {"\"미안...\"",
            "(푸욱)",
            " ",
            " ",
            "새빨간 피가 빗물을 타고 배수로를 향해 흐릅니다.",
            "당신의 최종 승리입니다.",
            "축하합니다. 당신이 최종 승리자입니다.",
            "456억을 획득하셨습니다."};

            // 선택 분기 3 텍스트
            List<string> Text_Select_3 = new List<string>
            {"( \" 탕.. 탕탕 \" )",
            " ",
            "당신은 차마 뒤돌아보지 못하고 문을 향해 걸어갑니다.",
            "당신의 최종 승리입니다.",
            "축하합니다. 당신이 최종 승리자입니다.",
            "456억을 획득하셨습니다."};

            // 맵 세팅
            Console.CursorVisible = false;
            Set_Map_Game8(ref game_Map8, sceneEndLine_Y, sceneEndLine_X);

            // 게임 시작
            while(is_Game)
            {
                // 맵 출력
                Console.SetCursorPosition(0, 0);
                Print_Map_Game8(game_Map8, sceneEndLine_Y, sceneEndLine_X);

                // 텍스트 1. 출력
                foreach (string ptr_text_ in Text_One)
                {
                    Console.SetCursorPosition(10, text_PosY);
                    for (int i = 0; i < ptr_text_.Length; i++)
                    {
                        if(( 11 <= text_PosY) && (text_PosY <= 13))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Thread.Sleep(30);
                            Console.Write(ptr_text_[i]);
                            Console.ResetColor();
                            continue;
                        }

                        Thread.Sleep(30);
                        Console.Write(ptr_text_[i]);
                    }
                    text_PosY++;
                    Console.WriteLine();
                }
                text_PosY = 3;  // 시작 줄 초기화
                anyKey_Next(game_Map8, sceneEndLine_Y, sceneEndLine_X); // 텍스트 지우기

                // 텍스트 2. 출력
                foreach (string ptr_text_ in Text_Two)
                {
                    Console.SetCursorPosition(16, text_PosY);
                    for (int i = 0; i < ptr_text_.Length; i++)
                    {
                        if ((10 <= text_PosY) && (text_PosY <= 12))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Thread.Sleep(30);
                            Console.Write(ptr_text_[i]);
                            Console.ResetColor();
                            continue;
                        }

                        Thread.Sleep(30);
                        Console.Write(ptr_text_[i]);
                    }
                    text_PosY++;
                    Console.WriteLine();
                }
                text_PosY = 3;  // 시작 줄 초기화
                anyKey_Next(game_Map8, sceneEndLine_Y, sceneEndLine_X);

                // 텍스트 3. 출력
                foreach (string ptr_text_ in Text_Three)
                {
                    Console.SetCursorPosition(4, text_PosY);
                    for (int i = 0; i < ptr_text_.Length; i++)
                    {
                        if ((12 <= text_PosY) && (text_PosY <= 14))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Thread.Sleep(30);
                            Console.Write(ptr_text_[i]);
                            Console.ResetColor();
                            continue;
                        }

                        Thread.Sleep(30);
                        Console.Write(ptr_text_[i]);
                    }
                    text_PosY++;
                    Console.WriteLine();
                }
                text_PosY = 3;  // 시작 줄 초기화
                anyKey_Next(game_Map8, sceneEndLine_Y, sceneEndLine_X);

                // 텍스트 4. 출력
                foreach (string ptr_text_ in Text_Four)
                {
                    Console.SetCursorPosition(8, text_PosY);
                    for (int i = 0; i < ptr_text_.Length; i++)
                    {
                        if ((8 <= text_PosY) && (text_PosY <= 16))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Thread.Sleep(30);
                            Console.Write(ptr_text_[i]);
                            Console.ResetColor();
                            continue;
                        }

                        Thread.Sleep(30);
                        Console.Write(ptr_text_[i]);
                    }
                    text_PosY++;
                    Console.WriteLine();
                }
                text_PosY = 3;  // 시작 줄 초기화
                anyKey_Next(game_Map8, sceneEndLine_Y, sceneEndLine_X);

                // 텍스트 5. 출력
                foreach (string ptr_text_ in Text_Five)
                {
                    Console.SetCursorPosition(8, text_PosY);
                    for (int i = 0; i < ptr_text_.Length; i++)
                    {
                        if ((18 <= text_PosY) && (text_PosY <= 20))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Thread.Sleep(30);
                            Console.Write(ptr_text_[i]);
                            Console.ResetColor();
                            continue;
                        }

                        Thread.Sleep(30);
                        Console.Write(ptr_text_[i]);
                    }
                    text_PosY++;
                    Console.WriteLine();
                }
                text_PosY = 3;  // 시작 줄 초기화
                Console.SetCursorPosition(60, 22);
                Console.WriteLine("▶ 숫자를 입력하세요 : ");
                

                // 엔딩 후 분기 선택
                while (true)
                {
                    Console.SetCursorPosition(85, 22);
                    string select_Num_ = Console.ReadLine();

                    if (int.TryParse(select_Num_, out int selectedNumber) && 1 <= selectedNumber && selectedNumber <= 3)
                    {
                        // 1번 분기 선택
                        if (selectedNumber == 1)
                        {
                            Console.Clear();
                            Print_Map_Game8(game_Map8, sceneEndLine_Y, sceneEndLine_X);

                            foreach (string ptr_text_ in Text_Select_1)
                            {
                                Console.SetCursorPosition(8, text_PosY);
                                for (int i = 0; i < ptr_text_.Length; i++)
                                {
                                    if ((5 <= text_PosY) && (text_PosY <= 6))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Thread.Sleep(30);
                                        Console.Write(ptr_text_[i]);
                                        Console.ResetColor();
                                        continue;
                                    }

                                    Thread.Sleep(30);
                                    Console.Write(ptr_text_[i]);
                                }
                                text_PosY++;
                                Console.WriteLine();
                            }
                            Console.SetCursorPosition(60, 22);
                            Console.WriteLine("▼ 아무키나 눌러 다음으로 넘어가세요.");
                            Console.ReadKey();
                            Console.Clear();
                            is_Game = false;
                            break;
                        }

                        // 2번 분기 선택
                        else if (selectedNumber == 2)
                        {
                            Console.Clear();
                            Print_Map_Game8(game_Map8, sceneEndLine_Y, sceneEndLine_X);

                            foreach (string ptr_text_ in Text_Select_2)
                            {
                                Console.SetCursorPosition(8, text_PosY);
                                for (int i = 0; i < ptr_text_.Length; i++)
                                {
                                    if ((5 <= text_PosY) && (text_PosY <= 6))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Thread.Sleep(30);
                                        Console.Write(ptr_text_[i]);
                                        Console.ResetColor();
                                        continue;
                                    }

                                    Thread.Sleep(30);
                                    Console.Write(ptr_text_[i]);
                                }
                                text_PosY++;
                                Console.WriteLine();
                            }
                            Console.SetCursorPosition(60, 22);
                            Console.WriteLine("▼ 아무키나 눌러 다음으로 넘어가세요.");
                            Console.ReadKey();
                            Console.Clear();
                            player_Win_Count++;
                            is_Game = false;
                            break;
                        }
                        // 3번 분기 선택
                        else if (selectedNumber == 3)
                        {
                            Console.Clear();
                            Print_Map_Game8(game_Map8, sceneEndLine_Y, sceneEndLine_X);

                            foreach (string ptr_text_ in Text_Select_2)
                            {
                                Console.SetCursorPosition(8, text_PosY);
                                for (int i = 0; i < ptr_text_.Length; i++)
                                {
                                    if ((5 <= text_PosY) && (text_PosY <= 6))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Thread.Sleep(30);
                                        Console.Write(ptr_text_[i]);
                                        Console.ResetColor();
                                        continue;
                                    }

                                    Thread.Sleep(30);
                                    Console.Write(ptr_text_[i]);
                                }
                                text_PosY++;
                                Console.WriteLine();
                            }
                            Console.SetCursorPosition(60, 22);
                            Console.WriteLine("▼ 아무키나 눌러 다음으로 넘어가세요.");
                            Console.ReadKey();
                            Console.Clear();
                            player_Win_Count++;
                            is_Game = false;
                            break;
                        }
                    }

                    // 다른 입력값이라면
                    else
                    {
                        Console.SetCursorPosition(60, 22);
                        Console.WriteLine("잘못 입력하셨습니다. [1, 2, 3] 숫자 중 하나를 입력하세요");
                    }
                }
            }   // 게임 종료

            return false;
        }   // 메인 end


        // 맵 세팅
        public void Set_Map_Game8(ref string[,] game_Map7, int sceneEndLine_Y, int sceneEndLine_X)
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

        // 맵 출력
        public void Print_Map_Game8(string[,] game_Map7, int sceneEndLine_Y, int sceneEndLine_X)
        {
            for (int y = 0; y < sceneEndLine_Y; y++)
            {
                for (int x = 0; x < sceneEndLine_X; x++)
                {
                    // 벽 색상 변경
                    if (game_Map7[y, x] == "■")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(game_Map7[y, x]);
                        Console.ResetColor();
                        continue;
                    }
                    Console.Write(game_Map7[y, x]);
                }
                Console.WriteLine();
            }
        }
        
        // 아무키나 눌러 다음으로 넘어가세요
        public void anyKey_Next(string[,] game_Map8, int sceneEndLine_Y, int sceneEndLine_X)
        {
            Console.SetCursorPosition(60, 22);
            Console.WriteLine("▼ 아무키나 눌러 다음으로 넘어가세요.");
            Console.ReadKey();
            Console.Clear();
            Print_Map_Game8(game_Map8, sceneEndLine_Y, sceneEndLine_X);
        }
        
    }
}
