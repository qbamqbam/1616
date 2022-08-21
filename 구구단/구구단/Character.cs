using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 구구단
{
    public class Character
    {
       public string name;
        protected int hp = 400;
        protected int maxHP = 400;
        protected int strenth = 10;
        protected int dexterity = 5;
        protected int intellegence = 7;
        protected bool isdead = false;
      
        public bool IsDead => isdead;
        public Random rand= new Random(DateTime.Now.Millisecond);

        string[] nameArray = { "가", "나", "다", "라", "마" };
        public int HP
        {
            get // 이 프로퍼티를 읽을 때 호출되는 부분. get만 만들면 읽기 전용 같은 효과가 있다.
            {
                return hp;
            }

            protected set // 이 프로퍼티에 값을 넣을 때 호출되는 부분. set에 private을 붙이면 쓰는 것은 나만 가능하다.
            {
                hp = value;
                if (hp > maxHP)
                {
                    hp = maxHP;
                }
                if (hp <= 0)
                {
                    Console.WriteLine($"{name}이 죽었습니다.");
                    isdead = true;
                }
            }
        }
        public Character()
        {
            
            int randomNumber = rand.Next(); // 랜덤 클래스 이용해서 0~21억 사이의 숫자를 랜덤으로 선택
            randomNumber %= 5;  //randomNumber = randomNumber % 5;  // 랜덤으로 고른 숫자를 0~4로 변경
            name = nameArray[randomNumber]; // 0~4로 변경한 값을 인덱스로 사용하여 이름 배열에서 이름 선택

            GenerateStastus();
            TestPrintStatus();

        }

        public Character(string _name)
        {
            
            GenerateStastus();
            name = _name;
            TestPrintStatus();
        }

        protected virtual void GenerateStastus()
        {
            maxHP = rand.Next(400, 501);    // 100에서 200 중에 랜덤으로 선택
            hp = maxHP;

            strenth = rand.Next(15) + 5;    // 1~20 사이를 랜덤하게 선택
            dexterity = rand.Next(15) + 5;
            intellegence = rand.Next(15) + 5;
        }
        public virtual void TestPrintStatus()
        {
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine($"┃이름\t:{name}       ┃");
            Console.WriteLine($"┃HP\t:{hp,4}/{maxHP,4}  ┃");
            Console.WriteLine($"┃str\t:{strenth, 2}       ┃");
            Console.WriteLine($"┃dex\t:{dexterity,2}       ┃");
            Console.WriteLine($"┃int\t:{intellegence,2}       ┃");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━┛");
        }

        public virtual void Attack(Character target)
        {
            int damage = strenth;
          
            Console.WriteLine($"{name}이 {target.name}에게 {damage}만큼의 피해를 입혔습니다.");
            target.TakeDamage(damage);
        }
        
        public virtual void TakeDamage(int damage)
        {
            HP -= damage;
        }
     }
}
