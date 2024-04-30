using DocumentFormat.OpenXml.Wordprocessing;
using MiNET.Effects;

namespace Base;

public class Program
{

    private static void Main(string[] args)
    {
        //
        // ВОЗВРАТИТЬ ЗНАЧЕНИЕ ИЗ Fight
        //
    }

    public class FightArbiter
    {
        private readonly BaseShip _first;
        private readonly BaseShip _second;

        public void Fight()
        {
            var random = new Random();
            var Flipcoin = random.Next(0, 100);
            var result = Flipcoin % 2 == 0;


            //
            // НУЖНО ВЕРНУТЬ ЗНАЧЕНИЕ МЕТОДОВ "FirstAttack" и "SecondAttack"
            //


        }

        public void FirstAttack()
        {
            var FirstDamage = _first.Damage;
            var count = 0;

            while (FirstDamage > 0)
            {
                var SecondShipShield = _second.Shield - FirstDamage;
                if (_second.Shield == 0)
                {
                    var SecondShipHealth = _second.Health - FirstDamage;
                    if (_second.Health > _second.Health / 2)
                    {
                        var SecondHealthRegen = _second.Health + 25;
                        if (_second.Health == 0)
                        {
                            Console.WriteLine($"1й кораболь уничтожил 2й, на это ему понадобилось {FirstDamage * count} урона");
                            break;
                        }
                    }
                }
                count++;
            }
        }
        public void SecondAttack()
        {
            var SecondDamage = _second.Damage;
            var count = 0;

            while (SecondDamage > 0)
            {
                var FirstShipShield = _first.Shield - SecondDamage;
                if (_first.Shield == 0)
                {
                    var FirstShipHealth = _first.Health - SecondDamage;
                    if (_first.Health > _first.Health / 2)
                    {
                        var FirstHealthRegen = _second.Health + 25;
                        if (_first.Health == 0)
                        {
                            Console.WriteLine($"2й кораболь уничтожил 1й, на это ему понадобилось {SecondDamage * count} урона");
                            break;
                        }
                    }
                }
                count++;
            }
        }




        public class BaseShip
        {
            public string Name { get; set; }
            public int Speed { get; set; }
            public int Damage { get; set; }
            public int CriticalDamage { get; set; }
            public int Health { get; set; }
            public int HealthRegen { get; set; }
            public int Shield { get; set; }
            public int VisionRange { get; set; }
            public int VisibilityRange { get; set; }
            public int AttackRange { get; set; }


        }
        public class Twins : BaseShip
        {
            public Twins()
            {
                Name = "Twins"; //твинс на мамонте
                Speed = 40;
                Damage = 15;
                Health = 150;
                Shield = 100;
                HealthRegen = Health + 25;
                VisionRange = 100;
                VisibilityRange = 80;

            }
        }
        public class Railgun : BaseShip
        {
            public Railgun()
            {
                Name = "Railgun"; //рельса на хорнете
                Speed = 65;
                Damage = 35;
                Health = 90;
                Shield = 100;
                HealthRegen = Health + 15;
                VisionRange = 100;
                VisibilityRange = 65;
            }
        }
    }
}
