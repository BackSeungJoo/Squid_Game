using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squid_Game
{
    public class Program
    {

        static void Main(string[] args)
        {
            // 인스턴스 생성
            TitleScene titleScene = new TitleScene();   // 타이틀 씬
            Game1 game1 = new Game1();                  // 게임 1 딱지치기
            Game2 game2 = new Game2();                  // 게임 2 무궁화꽃이피었습니다
            Game3 game3 = new Game3();                  // 게임 3 달고나 뽑기
            Game4 game4 = new Game4();                  // 게임 4 밤에 생존하기
            Game5 game5 = new Game5();                  // 게임 5 줄다리기
            Game6 game6 = new Game6();                  // 게임 6 구슬 홀짝 게임
            Game7 game7 = new Game7();                  // 게임 7 징검다리 건너기
            Game8 game8 = new Game8();                  // 게임 8 오징어 게임
                                                        // 인스턴스 생성 end

            // 변수 선언
            string sceneLine = "■";
            int sceneEndLine_Y = 25;
            int sceneEndLine_X = 50;
            string[,] sceneArray = new string[sceneEndLine_Y, sceneEndLine_X];

            ConsoleKey select_Game = default;
            bool isgame = true;
            // 승리 라운드 체크
            int roundWin = 0;
            int player_Win_Count = 0;
            int enemy_Win_Count = 0;
            List<int> roundWin_List = new List<int>();
            // 변수 선언 end

            // 타이틀씬 출력
            Console.CursorVisible = false;
            titleScene.Print_TitleScene();
            PressAnyKeytoStart();
            Ptr_MainScene(ref roundWin_List, ref sceneArray, ref sceneLine, ref sceneEndLine_Y, ref sceneEndLine_X, ref roundWin);

            while (true)
            {
                // 메인씬 출력
                Console.SetCursorPosition(0, 0);
                Print_Map(ref roundWin_List, sceneEndLine_Y, sceneEndLine_X, sceneArray, roundWin);
                isgame = true;

                // 1 ~ 8 까지의 숫자를 누르면 해당 게임으로 넘어가기
                while (isgame)
                {
                    select_Game = Console.ReadKey(true).Key;

                    #region
                    // 게임 1. 딱지치기 시작
                    if (select_Game == ConsoleKey.D1)
                    {
                        game1.PlayGame_1(ref player_Win_Count, ref enemy_Win_Count);

                        // 플레이어가 최종 승리했다면 라운드 승리 1 추가
                        if (player_Win_Count >= 5)
                        {
                            // 라운드 승리 리스트에서 1을 찾습니다.
                            foreach (int check_Round_Win_ in roundWin_List)
                            {
                                // 1이 있다면 변수에 1을 더합니다.
                                if (check_Round_Win_ == 1)
                                {
                                    roundWin++;
                                }
                            }

                            // 리스트에 1이 없다면 라운드 리스트에 1을 추가합니다.
                            if (roundWin == 0)
                            {
                                roundWin_List.Add(1);
                                player_Win_Count = 0;
                                enemy_Win_Count = 0;
                            }

                            // 그 외라면 그냥 초기화합니다.
                            else
                            {
                                player_Win_Count = 0;
                                enemy_Win_Count = 0;
                            }

                        }
                        else { /*pass*/}
                        isgame = false;
                    }

                    // 게임 2. 무궁화 꽃이 피었습니다 시작
                    else if (select_Game == ConsoleKey.D2)
                    {
                        game2.PlayGame_2(ref player_Win_Count);

                        // 플레이어가 최종 승리했다면 라운드 승리 1 추가
                        if (player_Win_Count == 1)
                        {
                            // 라운드 승리 리스트에서 2을 찾습니다.
                            foreach (int check_Round_Win_ in roundWin_List)
                            {
                                // 2가 있다면 변수에 1을 더합니다.
                                if (check_Round_Win_ == 2)
                                {
                                    roundWin++;
                                }
                            }

                            // 리스트에 2가 없다면 라운드 리스트에 2를 추가합니다.
                            if (roundWin == 0)
                            {
                                roundWin_List.Add(2);
                                player_Win_Count = 0;
                                enemy_Win_Count = 0;
                            }

                            // 그 외라면 그냥 초기화합니다.
                            else
                            {
                                player_Win_Count = 0;
                                enemy_Win_Count = 0;
                            }

                        }
                        else { /*pass*/}

                        isgame = false;
                    }

                    // 게임 3. 달고나 뽑기
                    else if (select_Game == ConsoleKey.D3)
                    {
                        game3.PlayGame_3(ref player_Win_Count);

                        // 플레이어가 최종 승리했다면 라운드 승리 1 추가
                        if (player_Win_Count == 1)
                        {
                            // 라운드 승리 리스트에서 3을 찾습니다.
                            foreach (int check_Round_Win_ in roundWin_List)
                            {
                                // 3이 있다면 변수에 1을 더합니다.
                                if (check_Round_Win_ == 3)
                                {
                                    roundWin++;
                                }
                            }

                            // 리스트에 3이 없다면 라운드 리스트에 3을 추가합니다.
                            if (roundWin == 0)
                            {
                                roundWin_List.Add(3);
                                player_Win_Count = 0;
                                enemy_Win_Count = 0;
                            }

                            // 그 외라면 그냥 초기화합니다.
                            else
                            {
                                player_Win_Count = 0;
                                enemy_Win_Count = 0;
                            }

                        }
                        else { /*pass*/}

                        isgame = false;
                    }

                    // 게임 4. 밤에 생존하기
                    else if (select_Game == ConsoleKey.D4)
                    {
                        game4.PlayGame_4(ref player_Win_Count);

                        // 플레이어가 최종 승리했다면 라운드 승리 1 추가
                        if (player_Win_Count == 1)
                        {
                            // 라운드 승리 리스트에서 4을 찾습니다.
                            foreach (int check_Round_Win_ in roundWin_List)
                            {
                                // 4가 있다면 변수에 1을 더합니다.
                                if (check_Round_Win_ == 4)
                                {
                                    roundWin++;
                                }
                            }

                            // 리스트에 4가 없다면 라운드 리스트에 4을 추가합니다.
                            if (roundWin == 0)
                            {
                                roundWin_List.Add(4);
                                player_Win_Count = 0;
                                enemy_Win_Count = 0;
                            }

                            // 그 외라면 그냥 초기화합니다.
                            else
                            {
                                player_Win_Count = 0;
                                enemy_Win_Count = 0;
                            }

                        }
                        else { /*pass*/}

                        isgame = false;
                    }

                    // 게임 5. 줄다리기
                    else if (select_Game == ConsoleKey.D5)
                    {
                        game5.PlayGame_5(ref player_Win_Count);

                        // 플레이어가 최종 승리했다면 라운드 승리 1 추가
                        if (player_Win_Count == 1)
                        {
                            // 라운드 승리 리스트에서 5를 찾습니다.
                            foreach (int check_Round_Win_ in roundWin_List)
                            {
                                // 5가 있다면 변수에 1을 더합니다.
                                if (check_Round_Win_ == 5)
                                {
                                    roundWin++;
                                }
                            }

                            // 리스트에 5가 없다면 라운드 리스트에 5를 추가합니다.
                            if (roundWin == 0)
                            {
                                roundWin_List.Add(5);
                                player_Win_Count = 0;
                                enemy_Win_Count = 0;
                            }

                            // 그 외라면 그냥 초기화합니다.
                            else
                            {
                                player_Win_Count = 0;
                                enemy_Win_Count = 0;
                            }

                        }
                        else { /*pass*/}

                        isgame = false;

                    }

                    // 게임 6. 구슬 홀짝 게임
                    else if (select_Game == ConsoleKey.D6)
                    {
                        game6.PlayGame_6(ref player_Win_Count);

                        // 플레이어가 최종 승리했다면 라운드 승리 1 추가
                        if (player_Win_Count == 1)
                        {
                            // 라운드 승리 리스트에서 6을 찾습니다.
                            foreach (int check_Round_Win_ in roundWin_List)
                            {
                                // 6이 있다면 변수에 1을 더합니다.
                                if (check_Round_Win_ == 6)
                                {
                                    roundWin++;
                                }
                            }

                            // 리스트에 6이 없다면 라운드 리스트에 6을 추가합니다.
                            if (roundWin == 0)
                            {
                                roundWin_List.Add(6);
                                player_Win_Count = 0;
                                enemy_Win_Count = 0;
                            }

                            // 그 외라면 그냥 초기화합니다.
                            else
                            {
                                player_Win_Count = 0;
                                enemy_Win_Count = 0;
                            }

                        }
                        else { /*pass*/}

                        isgame = false;
                    }

                    // 게임 7. 징검다리 건너기
                    else if (select_Game == ConsoleKey.D7)
                    {
                        game7.PlayGame_7(ref player_Win_Count);

                        // 플레이어가 최종 승리했다면 라운드 승리 1 추가
                        if (player_Win_Count == 1)
                        {
                            // 라운드 승리 리스트에서 7을 찾습니다.
                            foreach (int check_Round_Win_ in roundWin_List)
                            {
                                // 7이 있다면 변수에 1을 더합니다.
                                if (check_Round_Win_ == 7)
                                {
                                    roundWin++;
                                }
                            }

                            // 리스트에 7이 없다면 라운드 리스트에 7을 추가합니다.
                            if (roundWin == 0)
                            {
                                roundWin_List.Add(7);
                                player_Win_Count = 0;
                                enemy_Win_Count = 0;
                            }

                            // 그 외라면 그냥 초기화합니다.
                            else
                            {
                                player_Win_Count = 0;
                                enemy_Win_Count = 0;
                            }

                        }
                        else { /*pass*/}

                        isgame = false;
                    }

                    // 게임 8. 오징어게임
                    else if ((select_Game == ConsoleKey.D8))
                    {
                        game8.PlayGame_8(ref player_Win_Count);

                        // 플레이어가 최종 승리했다면 라운드 승리 1 추가
                        if (player_Win_Count == 1)
                        {
                            // 라운드 승리 리스트에서 8을 찾습니다.
                            foreach (int check_Round_Win_ in roundWin_List)
                            {
                                // 8이 있다면 변수에 1을 더합니다.
                                if (check_Round_Win_ == 8)
                                {
                                    roundWin++;
                                }
                            }

                            // 리스트에 8이 없다면 라운드 리스트에 8을 추가합니다.
                            if (roundWin == 0)
                            {
                                roundWin_List.Add(8);
                                player_Win_Count = 0;
                                enemy_Win_Count = 0;
                            }

                            // 그 외라면 그냥 초기화합니다.
                            else
                            {
                                player_Win_Count = 0;
                                enemy_Win_Count = 0;
                            }

                        }
                        else { /*pass*/}

                        isgame = false;
                    }

                    else { /*pass*/ }
                    #endregion
                }
            }
        }

        // 아무키나 눌러 메인씬으로 이동합니다.
        public static void PressAnyKeytoStart()
        {
            Console.SetCursorPosition(40, 22);
            Console.WriteLine("PRESS ANY KEY TO START ... ");
            Console.ReadKey();
        }

        public static void Ptr_MainScene(ref List<int> roundWin_List, ref string[,] sceneArray, ref string sceneLine, ref int sceneEndLine_Y, ref int sceneEndLine_X, ref int roundWin)
        {
            // { 맵 출력
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Set_Map(sceneEndLine_Y, sceneEndLine_X, ref sceneArray, sceneLine, roundWin);
            Print_Map(ref roundWin_List, sceneEndLine_Y, sceneEndLine_X, sceneArray, roundWin);
            // } 맵 출력 end
        }

        // 맵 세팅
        public static void Set_Map(int sceneEndLine_Y, int sceneEndLine_X, ref string[,] sceneArray, string sceneLine, int roundWin)
        {
            // 문구 출력을 위한 변수들
            int wellComeMessage_Count1 = 0;
            int wellComeMessage_Count2 = 0;
            int str_PlayerName_Count = 0;
            int str_PlayerNum_Count = 0;
            int str_PlayerGame_Count = 0;
            int str_GameVariation_Count = 0;

            // 캐릭터 이름 랜덤 지정을 위한 변수들
            Random random = new Random();
            string[] name1 = { "　", "성", "기", "훈" };
            string[] name2 = { "　", "조", "상", "우" };
            string[] name3 = { "　", "오", "일", "남" };
            string[] name4 = { "　", "장", "덕", "수" };
            string[] name5 = { "　", "한", "미", "녀" };
            string[] name6 = { "　", "알", "리", "압", "둘" };
            string[] name7 = { "　", "이", "지", "영" };
            string[] name8 = { "　", "강", "새", "벽" };

            // 참가자 이름 랜덤 지정
            int player_Random_Name_Num = random.Next(1, 9);

            // 이름 디버그 모드
            // player_Random_Name_Num = 6;

            // 참가자 번호 랜덤 지정
            int player_Random_Number = random.Next(1, 457);

            // 번호 디버그 모드
            //player_Random_Number = 102;

            string[] str_player_Random_Number = player_Random_Number.ToString().Split(',');

            // 맵 테두리 세팅
            for (int y = 0; y < sceneEndLine_Y; y++)
            {
                for (int x = 0; x < sceneEndLine_X; x++)
                {
                    // 맵 테두리 세팅
                    if ((y == 0) || (x == 0) || (y == sceneEndLine_Y - 1) || (x == sceneEndLine_X - 1) || (x == 17))
                    {
                        sceneArray[y, x] = sceneLine;
                        continue;
                    }
                    else
                    {
                        sceneArray[y, x] = "　";
                    }

                    // 환영 메세지 출력
                    if ((3 <= x) && (x <= 15) && (y == 3))
                    {
                        string[] wellComeMessage_ = { "오", "징", "어", "　", "게", "임", "에", "　", "오", "신", "것", "을" };

                        if (wellComeMessage_Count1 < wellComeMessage_.Length)
                        {
                            sceneArray[y, x] = wellComeMessage_[wellComeMessage_Count1];
                            wellComeMessage_Count1++;
                        }
                    }
                    if ((6 <= x) && (x <= 11) && (y == 4))
                    {
                        string[] wellComeMessage2_ = { "환", "영", "　", "합", "니", "다", ". " };

                        if (wellComeMessage_Count2 < wellComeMessage2_.Length)
                        {
                            sceneArray[y, x] = wellComeMessage2_[wellComeMessage_Count2];
                            wellComeMessage_Count2++;
                        }
                    }

                    // 플레이어 정보 출력 (이름)
                    if ((3 <= x) && (y == 9))
                    {
                        List<string> str_PlayerName = new List<string> { "참", "가", "자", "　", "이", "름", " :" };

                        if (player_Random_Name_Num == 1)    // 1번 이름
                        {
                            for (int a_ = 0; a_ < name1.Length; a_++)
                            {
                                str_PlayerName.Add(name1[a_]);
                            }
                        }
                        else if (player_Random_Name_Num == 2)   // 2번 이름
                        {
                            for (int a_ = 0; a_ < name2.Length; a_++)
                            {
                                str_PlayerName.Add(name2[a_]);
                            }
                        }
                        else if (player_Random_Name_Num == 3)   // 3번 이름
                        {
                            for (int a_ = 0; a_ < name3.Length; a_++)
                            {
                                str_PlayerName.Add(name3[a_]);
                            }
                        }
                        else if (player_Random_Name_Num == 4)   // 4번 이름
                        {
                            for (int a_ = 0; a_ < name4.Length; a_++)
                            {
                                str_PlayerName.Add(name4[a_]);
                            }
                        }
                        else if (player_Random_Name_Num == 5)   // 5번 이름
                        {
                            for (int a_ = 0; a_ < name5.Length; a_++)
                            {
                                str_PlayerName.Add(name5[a_]);
                            }
                        }
                        else if (player_Random_Name_Num == 6)   // 6번 이름
                        {
                            for (int a_ = 0; a_ < name6.Length; a_++)
                            {
                                str_PlayerName.Add(name6[a_]);
                            }
                        }
                        else if (player_Random_Name_Num == 7)   // 7번 이름
                        {
                            for (int a_ = 0; a_ < name7.Length; a_++)
                            {
                                str_PlayerName.Add(name7[a_]);
                            }
                        }
                        else if (player_Random_Name_Num == 8)   // 8번 이름
                        {
                            for (int a_ = 0; a_ < name8.Length; a_++)
                            {
                                str_PlayerName.Add(name8[a_]);
                            }
                        }       // 참가자 이름 랜덤 지정 end

                        // 참가자 이름 출력
                        if (str_PlayerName_Count < str_PlayerName.Count)
                        {
                            sceneArray[y, x] = str_PlayerName[str_PlayerName_Count];
                            str_PlayerName_Count++;
                        }
                    }

                    // 참가자 정보 출력 (번호)
                    if ((3 <= x) && (y == 11))
                    {
                        List<string> str_PlayerNum = new List<string> { "참", "가", "자", "　", "번", "호", " :", "　" };
                        List<string> str_PlayerNum1 = new List<string> { "참", "가", "자", "　", "번", "호", " :", "　" };
                        List<string> str_PlayerNum2 = new List<string> { "참", "가", "자", "　", "번", "호", " :", "　" };

                        if (player_Random_Number < 10)           // 1 자릿수 일때, 출력
                        {

                            // 번호를 List에 추가
                            for (int a_ = 0; a_ < str_player_Random_Number.Length; a_++)
                            {
                                str_PlayerNum.Add(str_player_Random_Number[a_]);
                            }

                            str_PlayerNum.Add("　");
                            str_PlayerNum.Add("　 ");

                            // 참가자 번호 출력
                            if (str_PlayerNum_Count < str_PlayerNum.Count)
                            {
                                sceneArray[y, x] = str_PlayerNum[str_PlayerNum_Count];
                                str_PlayerNum_Count++;
                            }
                        }
                        else if (player_Random_Number < 100)     // 2 자릿수 일 때, 출력
                        {
                            // 번호를 List에 추가
                            for (int a_ = 0; a_ < str_player_Random_Number.Length; a_++)
                            {
                                str_PlayerNum1.Add(str_player_Random_Number[a_]);
                            }

                            // 참가자 번호 출력
                            if (str_PlayerNum_Count < str_PlayerNum1.Count)
                            {
                                sceneArray[y, x] = str_PlayerNum1[str_PlayerNum_Count];
                                str_PlayerNum_Count++;
                            }
                        }
                        else                                    // 3 자릿수 일 때, 출력
                        {
                            // 번호를 List에 추가
                            for (int a_ = 0; a_ < str_player_Random_Number.Length; a_++)
                            {
                                str_PlayerNum2.Add(str_player_Random_Number[a_]);
                            }
                            str_PlayerNum2.Add(" ");

                            // 참가자 번호 출력
                            if (str_PlayerNum_Count < str_PlayerNum2.Count)
                            {
                                sceneArray[y, x] = str_PlayerNum2[str_PlayerNum_Count];
                                str_PlayerNum_Count++;
                            }
                        }
                    }

                    // 참가자 정보 출력 (회차)
                    if ((4 <= x) && (y == 16))
                    {
                        string[] str_PlayerGame = { "라", "　", "운", "　", "드", "　", "회", "　", "차" };

                        if (str_PlayerGame_Count < str_PlayerGame.Length)
                        {
                            sceneArray[y, x] = str_PlayerGame[str_PlayerGame_Count];
                            str_PlayerGame_Count++;
                        }
                    }

                    // 게임 종류 텍스 문구 출력
                    if ((4 <= y) && (30 <= x))
                    {
                        string[] str_GameVariation = { "게", "　", "임", "　", "　", "종", "　", "류" };

                        if (str_GameVariation_Count < str_GameVariation.Length)
                        {
                            sceneArray[y, x] = str_GameVariation[str_GameVariation_Count];
                            str_GameVariation_Count++;
                        }
                    }
                    // 게임 종류 네모 출력
                    #region
                    // 게임 종류 출력 (1번 게임)
                    if (((8 <= y) && (y <= 13)) && ((20 <= x) && (x <= 25)))
                    {
                        sceneArray[y, x] = sceneLine;
                        continue;
                    }

                    // 게임 종류 출력 (2번 게임)
                    if (((8 <= y) && (y <= 13)) && ((27 <= x) && (x <= 32)))
                    {
                        sceneArray[y, x] = sceneLine;
                        continue;
                    }

                    // 게임 종류 출력 (3번 게임)
                    if (((8 <= y) && (y <= 13)) && ((34 <= x) && (x <= 39)))
                    {
                        sceneArray[y, x] = sceneLine;
                        continue;
                    }

                    // 게임 종류 출력 (4번 게임)
                    if (((8 <= y) && (y <= 13)) && ((41 <= x) && (x <= 46)))
                    {
                        sceneArray[y, x] = sceneLine;
                        continue;
                    }

                    // 게임 종류 출력 (5번 게임)
                    if (((16 <= y) && (y <= 21)) && ((20 <= x) && (x <= 25)))
                    {
                        sceneArray[y, x] = sceneLine;
                        continue;
                    }

                    // 게임 종류 출력 (6번 게임)
                    if (((16 <= y) && (y <= 21)) && ((27 <= x) && (x <= 32)))
                    {
                        sceneArray[y, x] = sceneLine;
                        continue;
                    }

                    // 게임 종류 출력 (7번 게임)
                    if (((16 <= y) && (y <= 21)) && ((34 <= x) && (x <= 39)))
                    {
                        sceneArray[y, x] = sceneLine;
                        continue;
                    }

                    // 게임 종류 출력 (8번 게임)
                    if (((16 <= y) && (y <= 21)) && ((41 <= x) && (x <= 46)))
                    {
                        sceneArray[y, x] = sceneLine;
                        continue;
                    }
                    #endregion
                    // 게임 종류 end
                }
            }
        }

        // 맵 출력
        public static void Print_Map(ref List<int> roundWin_List, int sceneEndLine_Y, int sceneEndLine_X, string[,] sceneArray, int roundWin)
        {
            for (int y = 0; y < sceneEndLine_Y; y++)
            {
                for (int x = 0; x < sceneEndLine_X; x++)
                {
                    // 리스트가 비어있지 않다면
                    if(roundWin_List.Count != 0)
                    {
                        // 1번 네모
                        if (((8 <= y) && (y <= 13)) && ((20 <= x) && (x <= 25)) && roundWin_List.Contains(1))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(sceneArray[y, x]);
                            Console.ResetColor();
                            continue;
                        }

                        // 2번 네모
                        if (((8 <= y) && (y <= 13)) && ((27 <= x) && (x <= 32)) && roundWin_List.Contains(2))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(sceneArray[y, x]);
                            Console.ResetColor();
                            continue;
                        }

                        // 3번 네모
                        if (((8 <= y) && (y <= 13)) && ((34 <= x) && (x <= 39)) && roundWin_List.Contains(3))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(sceneArray[y, x]);
                            Console.ResetColor();
                            continue;
                        }

                        // 4번 네모
                        if (((8 <= y) && (y <= 13)) && ((41 <= x) && (x <= 46)) && roundWin_List.Contains(4))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(sceneArray[y, x]);
                            Console.ResetColor();
                            continue;
                        }

                        // 5번 네모
                        if (((16 <= y) && (y <= 21)) && ((20 <= x) && (x <= 25)) && roundWin_List.Contains(5))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(sceneArray[y, x]);
                            Console.ResetColor();
                            continue;
                        }

                        // 6번 네모
                        if (((16 <= y) && (y <= 21)) && ((27 <= x) && (x <= 32)) && roundWin_List.Contains(6))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(sceneArray[y, x]);
                            Console.ResetColor();
                            continue;
                        }

                        // 7번 네모
                        if (((16 <= y) && (y <= 21)) && ((34 <= x) && (x <= 39)) && roundWin_List.Contains(7))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(sceneArray[y, x]);
                            Console.ResetColor();
                            continue;
                        }

                        // 8번 네모
                        if (((16 <= y) && (y <= 21)) && ((41 <= x) && (x <= 46)) && roundWin_List.Contains(8))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(sceneArray[y, x]);
                            Console.ResetColor();
                            continue;
                        }

                        Console.Write(sceneArray[y, x]);

                    }

                    // 리스트가 비어있다면 그냥 출력
                    else
                    {
                        Console.Write(sceneArray[y, x]);
                    }
                    
            }
            Console.WriteLine();
        }
    }

    }
}
