using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace 구구단
{
    public class Human : Character
    {
        int maxMP = 100;
        int mp = 100;
        protected bool isburn = false;
        public bool IsBurn => isburn;
        public int MP
        {
            get
            {
                return mp;
            }

            private set
            {
                mp = value;
                if (mp <= 0)
                {
                    Console.WriteLine("MP가 부족합니다");
                    isburn = true;
                }
                if (mp > maxMP)
                    mp = maxMP;
            }
        }
        public Human() : base()
        {

        }

        public Human(string _name)
        {

            name = _name;
         
        }

        protected override void GenerateStastus()
        {
            base.GenerateStastus();
            strenth = rand.Next(5) + 5;    // 1~20 사이를 랜덤하게 선택
            dexterity = rand.Next(20);
            intellegence = rand.Next(10,16);
            mp = rand.Next() % 50 + 30;
            maxHP = rand.Next(400, 501);
            hp = maxHP;

        }
        public override void TestPrintStatus()
        {
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine($"┃이름\t:{name}       ┃");
            Console.WriteLine($"┃HP\t:{hp,4}/{maxHP,4}┃");
            Console.WriteLine($"┃MP\t:{mp,3}/{maxMP,3}  ┃");
            Console.WriteLine($"┃str\t:{strenth,2}       ┃");
            Console.WriteLine($"┃dex\t:{dexterity,2}       ┃");
            Console.WriteLine($"┃int\t:{intellegence,2}       ┃");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━┛");

        }
        public override void Attack(Character target)
        {
            int damage = strenth;
            if (rand.Next() % 10 < 3)
            {
                Console.WriteLine($"크리티컬! {name}이 {target.name}에게 {damage * 2}만큼의 피해를 입혔습니다.");
                target.TakeDamage(damage * 2);
            }
            else
                base.Attack(target);
        }

        public void Skill(Character target)
        {
            if (mp < 25-intellegence)
            {
                Console.WriteLine("마나가 부족합니다. 일반공격 진행");
                Attack(target);
            }
            else
            {
                MP=MP-25+intellegence;
                Console.WriteLine("익스플로젼!");
                target.TakeDamage(dexterity*2);
                Console.WriteLine($"{name}이 {target.name}에게 {dexterity*2}만큼의 스킬피해를 입혔습니다.");
            }
        }

        public void IncStr(Character target)
        {
            if (MP >= 30-intellegence)
            {
                MP -= 30-intellegence;
                strenth += intellegence / 2;
                Console.WriteLine($"인간이 명상합니다. STR이 {intellegence / 2}만큼 증가합니다");
            }
            else
            {
                Console.WriteLine("마나가 부족합니다. 일반공격진행");
                Attack(target);
            }

        }
        public void IncMp()
        {
            MP += 15+intellegence;
            Console.WriteLine($"인간이 명상합니다. MP가 {15+intellegence}만큼 증가합니다");
        }

    }
}