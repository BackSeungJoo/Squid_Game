using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Squid_Game
{
    public class Game6
    {
        public bool PlayGame_6(ref int player_Win_Count)
        {
            // 구슬을 숨기는 턴    - 숨길 구슬은 1 ~ 5개 사이에서 정합니다.
            // 홀짝 정하기 턴      - 구슬을 숨긴 뒤 상대방은 홀 짝을 정합니다.
            // 공개 턴            - 구슬을 공개하고 홀짝을 판별한 뒤 점수를 냅니다.

            Console.Clear();

            // {변수 선언
            int mapSize_Y = 25;
            int mapSize_X = 31;
            string[,] game_Map6 = new string[mapSize_Y, mapSize_X];

            // 초기 구슬 갯수
            int player_bead = 10;
            int enemy_bead = 10;
            int temp_bead = 0;  // 이곳에 구슬을 저장한 뒤 구슬 공개 턴이 지난 뒤 승리 참가자에게 지급됩니다.

            int player_OddEven = default; // 플레이어의 홀짝을 체크
            int enemy_OddEven = default;  // 상대방의 홀짝을 체크

            // 턴 횟수
            int turn_Count = 0;

            // 게임 종료 변수
            bool is_game = true;
                // }변수 선언 end

            // 초기 맵 세팅
            Set_Map_Game6(ref game_Map6, mapSize_Y, mapSize_X);
            Console.CursorVisible = false;

            while(is_game)
            {
                // 초기 맵 출력 
                Console.SetCursorPosition(0, 0);
                Print_Map_Game6(game_Map6, mapSize_Y, mapSize_X);
                Console.SetCursorPosition(70, 2);
                Console.WriteLine("턴 횟수 [{0}]", turn_Count);

                Console.SetCursorPosition(20, 3);
                Console.WriteLine("상대방의 구슬 갯수 [ ? ]");

                Console.SetCursorPosition(18, mapSize_Y - 4);
                Console.WriteLine("참가자의 구슬 갯수 [ {0:D2} ]", player_bead);
                // 초기 맵 출력 end

                #region
                // 플레이어의 턴인 것을 표시
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(6, 3);
                Console.WriteLine("　　　");
                Console.SetCursorPosition(6, mapSize_Y - 4);
                Console.WriteLine("▶ 턴");
                Console.SetCursorPosition(18, mapSize_Y - 4);
                Console.WriteLine("참가자의 구슬 갯수 [ {0:D2} ]", player_bead);
                Console.ResetColor();

                // 플레이어턴 1턴
                Player_First_Turn(ref player_bead, ref temp_bead);

                // 구슬의 갯수 바뀐 것을 출력
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(18, mapSize_Y - 4);
                Console.WriteLine("참가자의 구슬 갯수 [ {0:D2} ]", player_bead);
                Console.ResetColor();

                Console.SetCursorPosition(74, 10);
                Console.WriteLine("상대방이 홀짝을 정하는 중입니다...");

                //3,2,1 딜레이
                for (int i = 3; i > 0; i--)
                {
                    Thread.Sleep(250);
                    Console.SetCursorPosition(90, 12);
                    Console.Write("{0}", i);
                }

                // 플레이어턴 2턴 상대방
                Computer_Second_Turn(ref enemy_OddEven);

                // 플레이어턴 3턴
                Player_Third_Turn(ref player_bead, ref enemy_bead, ref temp_bead, enemy_OddEven);
                Console.ReadKey();

                // 턴 종료 후 출력된 문자 지우기
                Clear_Message();

                // 턴 종료 후 가진 갯수 표현
                Console.SetCursorPosition(18, mapSize_Y - 4);
                Console.WriteLine("참가자의 구슬 갯수 [ {0:D2} ]", player_bead);

                // 승리 패배 조건 확인
                Win_Lose(player_bead, enemy_bead, ref is_game, ref player_Win_Count);
                #endregion

                #region
                // 상대방의 턴 인 것을 표시
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(6, mapSize_Y - 4);
                Console.WriteLine("　　　");
                Console.SetCursorPosition(6, 3);
                Console.WriteLine("▶ 턴");
                Console.SetCursorPosition(20, 3);
                Console.WriteLine("상대방의 구슬 갯수 [ ? ]");
                Console.ResetColor();

                // 상대방턴 1턴
                Enemy_First_Turn(ref enemy_bead, ref temp_bead);

                // 상대방턴 2턴 플레이어
                Player_Second_Turn(ref player_OddEven);

                // 상대방턴 3턴
                Enemy_Third_Turn(ref player_bead, ref enemy_bead, ref temp_bead, player_OddEven);
                Console.ReadKey();

                // 턴 종료 후 출력된 문자 지우기
                Clear_Message();

                // 턴 종료 후 가진 갯수 표현
                Console.SetCursorPosition(18, mapSize_Y - 4);
                Console.WriteLine("참가자의 구슬 갯수 [ {0:D2} ]", player_bead);
                #endregion

                // 승리 패배 조건 확인
                Win_Lose(player_bead, enemy_bead, ref is_game, ref player_Win_Count);

                // 턴 횟수 증가
                turn_Count++;

                // 만약에 턴 횟수가 5 이상이라면 올인 대전
                if(turn_Count >= 5)
                {
                    // 턴 종료 후 출력된 문자 지우기
                    Clear_Message();

                    // 올인 턴 시작
                    All_In_Turn(ref player_bead, ref enemy_bead);
                }

                // 승리 패배 조건 확인
                Win_Lose(player_bead, enemy_bead, ref is_game, ref player_Win_Count);
                
            }

            Console.Clear();
            return false;
        }

        // 초기 맵 세팅
        public void Set_Map_Game6(ref string[,] game_Map6, int mapSize_Y, int mapSize_X)
        {
            for (int y = 0; y < mapSize_Y; y++)
            {
                for (int x = 0; x < mapSize_X; x++)
                {
                    // 벽 세팅
                    if ((y == 0) || (x == 0) || (y == mapSize_Y - 1) || (x == mapSize_X - 1))
                    {
                        game_Map6[y, x] = "■";
                        continue;
                    }

                    // 숨김 구슬 주머니 (가운데 네모 테두리 만들기)
                    if ((y == 5) && (5 <= x) && (x <= mapSize_X - 6)                 // 가로 (위)
                        || (y == mapSize_Y - 6) && (5 <= x) && (x <= mapSize_X - 6)  // 가로 (아래)
                        || (x == 5) && (5 <= y) && (y <= mapSize_Y - 6)              // 세로 (왼쪽)
                        || (x == mapSize_X - 6) && (5 <= y) && (y <= mapSize_Y - 6)) // 세로 (오른쪽)
                    {
                        game_Map6[y, x] = "■";
                        continue;
                    }

                    game_Map6[y, x] = "　";
                }
            }
        }

        // 맵 출력
        public void Print_Map_Game6(string[,] game_Map6, int mapSize_Y, int mapSize_X)
        {
            for (int y = 0; y < mapSize_Y; y++)
            {
                for (int x = 0; x < mapSize_X; x++)
                {
                    Console.Write(game_Map6[y, x]);
                }
                Console.WriteLine();
            }
        }

        // 숨기기 플레이어 턴
        public void Player_First_Turn(ref int player_bead, ref int temp_bead)
        {
            // 구슬을 몇개 숨길건지
            Console.SetCursorPosition(70, 5);
            Console.WriteLine("구슬을 몇개 숨기실 건가요? (2 ~ 5 사이)");
            Console.SetCursorPosition(90, 7);
            string str_hideBeat_ = Console.ReadLine();

            int i_hideBeat_;
            
            // 잘못된 입력을 받는지 체크
            while (!int.TryParse(str_hideBeat_, out i_hideBeat_) || i_hideBeat_ < 2 || i_hideBeat_ > 5 || i_hideBeat_ > player_bead)
            {
                // 출력된 문구 지우기
                Console.SetCursorPosition(70, 7);
                Console.WriteLine("                                               ");
                Console.SetCursorPosition(66, 10);
                Console.WriteLine("                                                     ");
                Console.SetCursorPosition(68, 12);
                Console.WriteLine("                                               ");

                // 문구 출력하기
                Console.SetCursorPosition(70, 7);
                Console.WriteLine("                                               ");
                Console.SetCursorPosition(66, 10);
                Console.WriteLine("잘못된 입력입니다. 1 - 5 사이의 숫자를 입력해주세요");
                Console.SetCursorPosition(68, 12);
                Console.WriteLine("또는, 현재 가진 갯수보다 많이 입력하셨습니다.");
                Console.SetCursorPosition(90, 7);
                str_hideBeat_ = Console.ReadLine();
            }

            // 출력된 문구 지우기
            Console.SetCursorPosition(70, 7);
            Console.WriteLine("                                               ");
            Console.SetCursorPosition(66, 10);
            Console.WriteLine("                                                     ");
            Console.SetCursorPosition(68, 12);
            Console.WriteLine("                                               ");

            // 구슬을 이곳에 저장한 뒤 구슬 공개 턴에 승리자에게 지급됨
            temp_bead = i_hideBeat_;
            player_bead = player_bead - temp_bead;


            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(22, 11);
            Console.WriteLine("내가 숨긴 구슬 갯수");
            Console.SetCursorPosition(28, 12);
            Console.WriteLine(" [ {0} ]", temp_bead);
            Console.ResetColor();
        }

        // 숨기기 상대방 턴
        public void Enemy_First_Turn(ref int enemy_bead, ref int temp_bead)
        {
            Random random = new Random();
            // 상대방이 구슬을 몇개 숨길건지
            Console.SetCursorPosition(72, 5);
            Console.WriteLine("상대방이 구슬을 숨기는 중입니다...");

            // 3,2,1 딜레이
            for (int i = 3; i > 0; i--)
            {
                Thread.Sleep(250);
                Console.SetCursorPosition(90, 7);
                Console.Write("{0}", i);
            }

            // 구슬을 이곳에 저장한 뒤 구슬 공개 턴에 승리자에게 지급됨
            while(true)
            {
                int temp_ = random.Next(2, 6);

                if (temp_ <= enemy_bead)
                {
                    temp_bead = temp_;
                    enemy_bead = enemy_bead - temp_bead;
                    break;
                }

                else { /*pass*/ }
            }
            
            Console.SetCursorPosition(70, 5);
            Console.WriteLine("상대방이 구슬을 숨겼습니다. (2 ~ 5 사이)");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(20, 11);
            Console.WriteLine("상대가 숨긴 구슬 갯수");
            Console.SetCursorPosition(28, 12);
            Console.WriteLine(" [ ? ]");
            Console.ResetColor();
        }

        // 플레이어 홀짝 결정 턴 (플레이어가 플레이 하는 것임)
        public void Player_Second_Turn(ref int player_OddEven)
        {
            Console.SetCursorPosition(68, 7);
            Console.WriteLine("숨긴 구슬의 갯수가 홀인지 짝인지 선택하세요.");
            Console.SetCursorPosition(84, 9);
            Console.WriteLine("[0] 짝 / [1] 홀");
            Console.SetCursorPosition(90, 11);
            string decide_Num_ = Console.ReadLine();
            int int_decide_Num_;

            // 잘못된 입력을 받는지 체크
            while (!int.TryParse(decide_Num_, out int_decide_Num_) || int_decide_Num_ != 0 && int_decide_Num_ != 1)
            {
                // 출력된 문구 지우기
                Console.SetCursorPosition(90, 11);
                Console.WriteLine("           ");
                Console.SetCursorPosition(65, 13);
                Console.WriteLine("                                                     ");

                // 문구 출력하기
                Console.SetCursorPosition(66, 13);
                Console.WriteLine("잘못된 입력입니다. 0 또는 1의 숫자를 입력해주세요");

                Console.SetCursorPosition(90, 11);
                decide_Num_ = Console.ReadLine();
            }
           
            // 출력된 문구 지우기
            Console.SetCursorPosition(90, 11);
            Console.WriteLine("           ");
            Console.SetCursorPosition(65, 13);
            Console.WriteLine("                                                     ");

            player_OddEven = int_decide_Num_;
        }

        // 컴퓨터 홀짝 결정 턴 (상대방이 플레이 하는 것임)
        public void Computer_Second_Turn(ref int enemy_OddEven)
        {
            Random random = new Random();
            int com_Num = random.Next(0, 2);    // 0이면 짝 | 1이면 홀

            enemy_OddEven = com_Num;
        }

        // 플레이어 구슬 공개 턴 
        public void Player_Third_Turn(ref int player_bead, ref int enemy_bead, ref int temp_bead, int enemy_OddEven)
        {
            string ptr_Odd_Even_;
            int check_HideBead_OddEven_;

            // 홀 짝 출력하기 위해 문자 넣기
            if(enemy_OddEven == 0)
            {
                ptr_Odd_Even_ = "짝";
            }
            else
            {
                ptr_Odd_Even_ = "홀";
            }

            // 상대방이 홀/짝 중에 어떤 것을 선택했는지 출력
            Clear_Message();
            Console.SetCursorPosition(76, 8);
            Console.WriteLine("상대방은 [{0}] 을 선택했습니다.", ptr_Odd_Even_);
            
            // 상대방이 내가 숨긴 구슬의 홀짝을 맞춘다면
            // 우선 내가 숨긴 구슬이 홀짝인지 판단,
            if(temp_bead % 2 == 0)
            {
                check_HideBead_OddEven_ = 0;    // 내가 숨긴 구슬이 [짝]
            }
            else
            {
                check_HideBead_OddEven_ = 1;    // 내가 숨긴 구슬이 [홀]
            }

            // 상대방이 정답을 맞춘다면? 숨긴 구슬을 상대방에게 지급
            if(enemy_OddEven == check_HideBead_OddEven_)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(66, 10);
                Console.WriteLine("상대방이 정답을 맞췄습니다. 숨긴 구슬을 빼앗깁니다.");
                Console.ResetColor();

                enemy_bead = enemy_bead + temp_bead;
            }
            // 틀린다면 나에게 지급
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(66, 10);
                Console.WriteLine("상대방이 정답을 틀렸습니다. 숨긴 구슬을 되찾습니다.");
                Console.ResetColor();

                player_bead = player_bead + temp_bead;
            }

        }

        // 상대방 구슬 공개 턴 
        public void Enemy_Third_Turn(ref int player_bead, ref int enemy_bead, ref int temp_bead, int player_OddEven)
        {
            string ptr_Odd_Even_ = default;
            int check_HideBead_OddEven_;

            // 홀 짝 출력하기 위해 문자 넣기
            if (player_OddEven == 0)
            {
                ptr_Odd_Even_ = "짝";
            }
            else if (player_OddEven == 1)
            {
                ptr_Odd_Even_ = "홀";
            }

            // 플레이어가 홀/짝 중에 어떤 것을 선택했는지 출력
            Clear_Message();
            Console.SetCursorPosition(78, 8);
            Console.WriteLine("당신은 [{0}] 을 선택했습니다.", ptr_Odd_Even_);

            // 플레이어가 상대방의 숨긴 구슬의 홀짝을 맞춘다면
            // 우선 상대방이 숨긴 구슬이 홀짝인지 판단,
            if (temp_bead % 2 == 0)
            {
                check_HideBead_OddEven_ = 0;    // 상대방이 숨긴 구슬이 [짝]
            }
            else
            {
                check_HideBead_OddEven_ = 1;    // 상대방이 숨긴 구슬이 [홀]
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(20, 11);
            Console.WriteLine("상대가 숨긴 구슬 갯수");
            Console.SetCursorPosition(28, 12);
            Console.WriteLine(" [ {0} ]", temp_bead);
            Console.ResetColor();


            // 플레이어이 정답을 맞춘다면? 숨긴 구슬을 플레이어에게 지급
            if (player_OddEven == check_HideBead_OddEven_)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(66, 10);
                Console.WriteLine("당신이 정답을 맞췄습니다. 숨긴 구슬을 가져옵니다.");
                Console.ResetColor();

                player_bead = player_bead + temp_bead;
            }
            // 틀린다면 상대방에게 지급
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(66, 10);
                Console.WriteLine("당신은 정답을 틀렸습니다. 숨긴 구슬을 돌려줍니다.");
                Console.ResetColor();

                enemy_bead = enemy_bead + temp_bead;
            }
        }

        // 출력 문구들 지우기
        public void Clear_Message()
        {
            Console.SetCursorPosition(64, 5);
            Console.WriteLine("                                                        ");
            Console.SetCursorPosition(64, 6);
            Console.WriteLine("                                                        ");
            Console.SetCursorPosition(64, 7);
            Console.WriteLine("                                                        ");
            Console.SetCursorPosition(64, 8);
            Console.WriteLine("                                                        ");
            Console.SetCursorPosition(64, 9);
            Console.WriteLine("                                                        ");
            Console.SetCursorPosition(64, 10);
            Console.WriteLine("                                                        ");
            Console.SetCursorPosition(64, 11);
            Console.WriteLine("                                                        ");
            Console.SetCursorPosition(64, 12);
            Console.WriteLine("                                                        ");
            Console.SetCursorPosition(64, 13);
            Console.WriteLine("                                                        ");
            Console.SetCursorPosition(64, 14);
            Console.WriteLine("                                                        ");
        }

        // 승리 패배 조건
        public void Win_Lose(int player_bead, int enemy_bead, ref bool is_game, ref int player_Win_Count)
        {
            // 승리
            if (player_bead >= 20)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(70, 5);
                Console.WriteLine("상대방의 모든 구슬을 빼앗았습니다.");
                Console.SetCursorPosition(70, 7);
                Console.WriteLine("축하합니다.");
                Console.SetCursorPosition(70, 7);
                Console.WriteLine("6 라운드 클리어 입니다.");
                Console.ResetColor();
                Console.ReadKey();
                is_game = false;
                player_Win_Count = 1;
            }

            // 패배
            else if(enemy_bead >= 20)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(70, 5);
                Console.WriteLine("모든 구슬을 빼앗겼습니다.");
                Console.SetCursorPosition(70, 7);
                Console.WriteLine("6 라운드 탈락 입니다.");
                Console.ResetColor();
                Console.ReadKey();
                is_game = false;
            }
        }

        // 올인 턴
        public void All_In_Turn(ref int player_bead, ref int enemy_bead)
        {
            // 상대방이 구슬을 숨깁니다.
            Random random = new Random();

            int all_In_Bead_ = player_bead + enemy_bead;    // 올인을 위한 변수
            player_bead = 0;
            enemy_bead = 0;

            // 상대방이 구슬을 몇개 숨길건지
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(70, 2);
            Console.WriteLine("5턴 이상이 되어서 올인 턴 시작합니다.");
            Console.ResetColor();

            Console.SetCursorPosition(72, 5);
            Console.WriteLine("상대방이 구슬을 숨기는 중입니다...");

            // 3,2,1 딜레이
            for (int i = 3; i > 0; i--)
            {
                Thread.Sleep(250);
                Console.SetCursorPosition(90, 7);
                Console.Write("{0}", i);
            }

            // 숨긴 구슬 (1 ~ 5)
            int temp_ = random.Next(3, 6);

            Console.SetCursorPosition(70, 5);
            Console.WriteLine("상대방이 구슬을 숨겼습니다. (3 ~ 5 사이)");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(20, 11);
            Console.WriteLine("상대가 숨긴 구슬 갯수");
            Console.SetCursorPosition(28, 12);
            Console.WriteLine(" [ ? ]");
            Console.ResetColor();

            // 플레이어가 홀짝을 정합니다.
            Console.SetCursorPosition(68, 7);
            Console.WriteLine("숨긴 구슬의 갯수가 홀인지 짝인지 선택하세요.");
            Console.SetCursorPosition(84, 9);
            Console.WriteLine("[0] 짝 / [1] 홀");

            Console.SetCursorPosition(90, 11);
            string decide_Num_ = Console.ReadLine();
            int int_decide_Num_;

            // 잘못된 입력을 받는지 체크
            while (!int.TryParse(decide_Num_, out int_decide_Num_) || int_decide_Num_ != 0 && int_decide_Num_ != 1)
            {
                // 출력된 문구 지우기
                Console.SetCursorPosition(90, 11);
                Console.WriteLine("           ");
                Console.SetCursorPosition(65, 13);
                Console.WriteLine("                                                     ");

                // 문구 출력하기
                Console.SetCursorPosition(66, 13);
                Console.WriteLine("잘못된 입력입니다. 0 또는 1의 숫자를 입력해주세요");

                Console.SetCursorPosition(90, 11);
                decide_Num_ = Console.ReadLine();
            }

            // 출력된 문구 지우기
            Console.SetCursorPosition(90, 11);
            Console.WriteLine("           ");
            Console.SetCursorPosition(65, 13);
            Console.WriteLine("                                                     ");

            string ptr_Odd_Even_ = default;
            int check_HideBead_OddEven_;

            // 홀 짝 출력하기 위해 문자 넣기
            if (int_decide_Num_ == 0)
            {
                ptr_Odd_Even_ = "짝";
            }
            else if (int_decide_Num_ == 1)
            {
                ptr_Odd_Even_ = "홀";
            }

            // 플레이어가 홀/짝 중에 어떤 것을 선택했는지 출력
            Clear_Message();
            Console.SetCursorPosition(78, 13);
            Console.WriteLine("당신은 [{0}] 을 선택했습니다.", ptr_Odd_Even_);

            // 플레이어가 상대방의 숨긴 구슬의 홀짝을 맞춘다면
            // 우선 상대방이 숨긴 구슬이 홀짝인지 판단,
            if (temp_ % 2 == 0)
            {
                check_HideBead_OddEven_ = 0;    // 상대방이 숨긴 구슬이 [짝]
            }
            else
            {
                check_HideBead_OddEven_ = 1;    // 상대방이 숨긴 구슬이 [홀]
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(20, 11);
            Console.WriteLine("상대가 숨긴 구슬 갯수");
            Console.SetCursorPosition(28, 12);
            Console.WriteLine(" [ {0} ]", temp_);
            Console.ResetColor();


            // 플레이어이 정답을 맞춘다면? 숨긴 구슬을 플레이어에게 지급
            if (int_decide_Num_ == check_HideBead_OddEven_)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(80, 14);
                Console.WriteLine("당신은 정답을 맞췄습니다.");
                Console.ResetColor();

                player_bead = all_In_Bead_;
            }
            // 틀린다면 상대방에게 지급
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(80, 14);
                Console.WriteLine("당신은 정답을 틀렸습니다.");
                Console.ResetColor();

                enemy_bead = all_In_Bead_;
            }
        }
    }
}
