using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace 구구단
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wincount = 0;
            int losecount = 0;

            while (true)
            {
                Console.WriteLine("이름을 입력하세요:");
                string name = Console.ReadLine();
                if (name.Length < 0) { }




                Human player1 = new Human(name);
                Orc enemy1 = new Orc();

                int count = 1;


                while (!player1.IsDead && !enemy1.IsDead)
                {
                    int act;

                    Console.WriteLine($"{count}번째 턴");
                    Console.WriteLine("어떤 행동을 하시겠습니까?");
                    Console.WriteLine("1.일반공격 2.스킬공격 3.힘증가 4.마나증가");
                    while (true)
                    {
                        string stact = Console.ReadLine();
                        int.TryParse(stact, out act);
                        if (((act == 1 || act == 2) || act == 3) || act == 4)
                            break;
                        else
                            Console.WriteLine("잘못입력하셨습니다. 다시 입력해주세요");
                    }
                    switch (act)
                    {
                        case 1:
                            player1.Attack(enemy1);
                            break;
                        case 2:
                            player1.Skill(enemy1);
                            break;
                        case 3:
                            player1.IncStr(enemy1);
                            break;
                        case 4:
                            player1.IncMp();
                            break;

                    }
                    if (!enemy1.IsDead)
                        enemy1.auto(player1);

                    player1.TestPrintStatus();
                    enemy1.TestPrintStatus();
                    count++;


                }
              

                if (player1.IsDead)
                {
                    Console.WriteLine("패배하였습니다");
                    losecount++;
                }

                if (enemy1.IsDead)
                {
                    Console.WriteLine("승리하였습니다!");
                    wincount++;
                }
                Console.WriteLine($"전적 :{wincount+losecount}전 {wincount}승 {losecount}패 ");
                Console.WriteLine($"승률 : {((double)wincount/(wincount+losecount))*100:F0}%");
                Console.WriteLine("r을 입력하여 재시작하기");
                string con = Console.ReadLine();
                if (con == "r") { }
                else
                            break;
      
            }
            Console.ReadKey();
        }

        static void RCP(int n)
        {
           
        }
        static void Gugu(int num)
        {
            if (num < 2)
                Console.WriteLine("숫자가 너무 작습니다");
            else if (num > 9)
                Console.WriteLine("숫자가 너무 큽니다");
            else
            {
                int i;
                for (i = 1; i < 10; i++)
                {
                    Console.WriteLine($"{num}X{i}={num * i}");
                }
            }
        }
    }
}
