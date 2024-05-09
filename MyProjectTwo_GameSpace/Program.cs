using static Base.Program.FightArbiter;

namespace Base;

public class Program
{

    private static void Main(string[] args)
    {
        var first = new Twins();
        var second = new Railgun();
        var win = new FightArbiter(first, second);
 

        var firstWins = win.FirstAttack();
        Console.WriteLine(firstWins);

        //var secondWins = win.SecondAttack();
        //Console.WriteLine(secondWins);


    }

    public class FightArbiter
    {
        private readonly BaseShip _first;
        private readonly BaseShip _second;

        public FightArbiter(BaseShip first, BaseShip second)
        {
            _first = first;
            _second = second;
        }


        public string Fight()
        {
            var random = new Random();
            var Flipcoin = random.Next(0, 100);
            var result = Flipcoin % 2 == 0;

            if (result) //  -> ходит 1й
            {
                var firstWins = FirstAttack();
                Console.WriteLine("Wins Twins");
                return firstWins;

            }
            else
            {
                var secondWin = SecondAttack();
                Console.WriteLine("Wins Twins");
                return secondWin;
            }
        }

        public string FirstAttack()
        {
            var count = 0;
            while (true)
            {
                count++;
                if ((_second.Shield <= 0) & (_second.Health <= 0))
                {
                    Console.WriteLine("Победа Twins");
                    return $"1й кораболь уничтожил 2й, на это ему понадобилось {_first.Damage * count} урона";
                }
                else
                {
                    if ((_second.Shield > 0) || (_second.Health > 0))
                    {
                        if (_second.Shield > 0)
                        {
                            _second.Shield = _second.Shield - _first.Damage;

                            if (_second.Shield == _first.Damage)
                            {
                                _second.Shield = _second.Shield - _first.Damage;
                            }
                            else
                                continue;
                        }
                        else
                        {
                            _second.Health = _second.Health - _first.Damage;

                            if (_second.Health == _first.Damage)
                            {
                                _second.Health = _second.Health - _first.Damage;
                            }
                            else
                                continue;
                        }

                    }
                }
            }
        }

        public string SecondAttack()
        {
            var count = 0;
            while (true)
            {
                count++;
                if ((_first.Shield <= 0) & (_first.Health <= 0))
                {
                    Console.WriteLine("Победа Railgun");
                    return $"2й кораболь уничтожил 1й, на это ему понадобилось {_second.Damage * count} урона";
                }
                else
                {
                    if ((_first.Shield > 0) || (_first.Health > 0))
                    {
                        if (_first.Shield > 0)
                        {
                            _first.Shield = _first.Shield - _second.Damage;

                            if (_first.Shield == _first.Damage)
                            {
                                _first.Shield = _first.Shield - _second.Damage;
                            }
                            else
                                continue;
                        }
                        else
                        {
                            _first.Health = _first.Health - _second.Damage;

                            if (_first.Health == _second.Damage)
                            {
                                _first.Health = _first.Health - _second.Damage;
                            }
                            else
                                continue;
                        }

                    }
                }
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
            public Twins() //         1й
            {
                Name = "Twins"; //твинс на мамонте
                Speed = 40;
                Damage = 15;
                Health = 150;
                Shield = 100;
                //HealthRegen = Health + 25;
                VisionRange = 100;
                VisibilityRange = 80;

            }
        }
        public class Railgun : BaseShip
        {
            public Railgun() //            2й
            {
                Name = "Railgun"; //рельса на хорнете
                Speed = 65;
                Damage = 35;
                Health = 90;
                Shield = 100;
                //HealthRegen = Health + 15;
                VisionRange = 100;
                VisibilityRange = 65;
            }
        }
    }
}
