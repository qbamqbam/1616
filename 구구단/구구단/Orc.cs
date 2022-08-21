using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 구구단
{
    public class Orc : Character
    {
        int maxAng = 50;
        int ang = 50;
        public Orc() : base()
        {

        }
        string[] nameArray = { "오크1", "오크2", "오크3", "오크4", "오크5" };
        protected override void GenerateStastus()
        {
            base.GenerateStastus();
            ang = rand.Next() % 10;
            name = nameArray[rand.Next() % 5];
            strenth = rand.Next(5) + 15;
            maxHP = rand.Next(550, 601);
            hp = maxHP;

        }
        public override void TestPrintStatus()
        {
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine($"┃이름\t:{name}    ┃");
            Console.WriteLine($"┃HP\t:{hp,4}/{maxHP,4}┃");
            Console.WriteLine($"┃Anger\t:{ang,2}/{maxAng,2}    ┃");
            Console.WriteLine($"┃str\t:{strenth,2}       ┃");
            Console.WriteLine($"┃dex\t:{dexterity,2}       ┃");
            Console.WriteLine($"┃int\t:{intellegence,2}       ┃");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━┛");
        }

        public override void Attack(Character target)
        {
            int damage = strenth;
            if (hp < 150&&hp>50)
            {
                Console.WriteLine($"체력이 낮아진 오크가 강하게 공격합니다. {name}이 {target.name}에게 {damage *2}만큼의 피해를 입혔습니다.");
                target.TakeDamage(damage *2);
            }
            else if (hp < 51){
                Console.WriteLine($"체력이 더 낮아진 오크가 더 강하게 공격합니다!. {name}이 {target.name}에게 {damage * 3}만큼의 피해를 입혔습니다.");
                target.TakeDamage(damage * 3);
            }

            else
                base.Attack(target);
        }
        public void Heal(Character target)
        {
            if (ang > 30)
            {
                ang -= 30;
                HP += 90;
                Console.WriteLine($"오크가 분노를 30 소모하여 90만큼 체력을 회복합니다.");
            }
            else
            {
                Console.WriteLine("분노가 부족합니다. 일반공격 진행");
                Attack(target);
                
            }
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            ang += 5;
            if(!IsDead)
            Console.WriteLine("피격된 오크가 분노합니다. 분노 +5");
        }

        public void auto(Character target)
        {
            if (ang>30)
                Heal(target);
            else
                Attack(target);
        }

    }
}
