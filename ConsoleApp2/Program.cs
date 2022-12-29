using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Com1=0; int Com2=0; int MyCard=0;
            TrumpCard_ tc = new TrumpCard_();
            tc.SetupTrumpCards();
            int player = 10000;
            while(true)
            {

                Com1 = tc.ReRollCard_();
                Com2 = tc.ReRollCard_();


                // { 베팅
                int betP = default;
                Console.WriteLine("현재 포인트 : {0}", player);
                while (true)
                {
                Console.Write("배팅 포인트 입력 : ");
                int.TryParse(Console.ReadLine(), out betP);

                if(betP<0||betP>player)
                {
                    Console.WriteLine("입력 값을 확인해주세요");
                }
                else { break; }
                }

                player = player - betP;


                // } 베팅

                // { 플레이어 카드 뽑기
                MyCard = tc.ReRollCard_();
                // } 플레이어 카드 뽑기

                // { 라운드 결과 체크
                // 변수 두개 선언해서
                int bigger, smaller;
                // 큰수 작은수 넣어준 다음에
                if (Com1 > Com2)
                {
                    bigger = Com1;
                    smaller = Com2;
                }
                else
                {
                    smaller = Com1;
                    bigger = Com2;
                }
                // 작은 수 < 플레이어 < 큰수 이거 조건 확인
                if (smaller<MyCard&&MyCard<bigger) 
                {
                    Console.WriteLine("승");
                    player = (betP * 2) + player;
                }
                else
                {
                    Console.WriteLine("패");
                }
                // } 라운드 결과 체크
                Console.WriteLine("남은 포인트 : {0}", player);
                
                if (player <= 0 || player >= 100000)
                {
                    break;
                }
                
                //빠져나갈거
                Console.WriteLine("\n\nPress any key");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}