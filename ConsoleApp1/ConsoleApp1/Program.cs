using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "너굴맨";
            int level = 2;
            int hp = 10;
            int maxHP = 20;
            float exp = 0.1f;
            float maxExp = 1.0f;
            PrintCharacter(name, level, hp);
            Test();
            
            Console.ReadKey();

        }
        static void PrintCharacter(string name, int level, int hp)
        {
            Console.WriteLine($"이름은 {name}\n레벨은 {level}\n피는 {hp}");
        }
        static int Sum(int a, int b)
        {
            int result = a + b;
            return result;
        }
       static void Test()
        {
            Console.WriteLine("이범규");

            //  string str = Console.ReadLine(); - 문자열을 읽는
            //   Console.WriteLine(str);
            //string str1 = "Hello";
            //string str2 = "안녕";
            //int a = 10;
            //string str3 = $"안녕 {a}";
            //string str4 = str1 + str2;
            //Console.WriteLine(str3);

            int level = 10;
            int hp = 100;
            float exp = 0.5f;
            string name = "이범규";
            string temp;

            //Console.Write("이름을 입력하세요: ");
            //name = Console.ReadLine();

            //Console.Write($"{name}의 레벨을 입력하세요: ");
            //string temp = Console.ReadLine();
            ////level = int.Parse(temp);//문자열을 숫자로 변환 간단하지만 위험
            //int.TryParse(temp, out level);//string을 int로 변경 숫자로 바꿀수 없으면 0으로 받음.
            //                              //level = Convert.ToInt32(temp); 세세하게 변경

            //Console.Write($"{name}의 HP를 입력하세요: ");
            //temp = Console.ReadLine();
            //int.TryParse(temp, out hp);

            //Console.Write($"{name}의 경험치를 입력하세요: ");
            //temp = Console.ReadLine();
            //float.TryParse(temp, out exp);

            Console.WriteLine($"이름:{name}\nHp:{hp}\n레벨:{level}\n경험치:{exp * 100:F2}%");

            //변수 끝 -----------------------------------------------------------------------------

            //제어문
            //실행되는 코드 라인을 변경할 수 있는 코드

            //Console.WriteLine("경험치를 추가합니다.");
            //Console.Write("추가할 경험치 : ");
            //temp = Console.ReadLine();
            //float addexp;
            //float.TryParse(temp, out addexp);

            //if (exp + addexp >= 1)
            //    Console.WriteLine("레벨업!");
            //else
            //    Console.WriteLine($"경험치의 합은 {(exp + addexp) * 100:F2}%");
            float addexp;
            while (exp < 1f)
            {
                Console.Write("추가경험치 입력:");
                temp = Console.ReadLine();
                float.TryParse(temp, out addexp);
                exp += addexp;
                Console.WriteLine($"현재경험치 {exp}");
            }

            Console.WriteLine("레벨업!");

            Console.ReadKey();

        }
    }
}

  

    

