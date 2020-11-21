using System;
using static System.Console;

namespace KDZ
{
    public class Fighter : Human
    {
        protected int Damage; // Урон, который наносит персонаж противнику
        public int damage { get { return Damage; } set { Damage = value; } }
        protected int Guard; // Защита персонажа, не может принимать отрицательные значения
        public int guard { get { return Guard; } set { Guard = value; } }
        protected double Evade; // вероятность уклонения текущего персонажа от удара
        public double evade { get { return Evade; } set { Evade = value; } } 

        public virtual void Attack(ref Human enemy) // Процесс атаки
        {
            if (!(enemy is Samurai) && !(enemy is Ninja)) // Если текщий персонаж атакует файтера
            {
                    var defender = enemy as Fighter;
                    if (defender.guard > 0) // Если у персонажа всё еще есть защита, она действует
                    {
                        if (damage > defender.guard)
                        {
                            defender.healthy -= (damage - defender.guard); // Если атака сильнее защиты, отнимаем ХР
                        }
                        --defender.guard; // Защита уменьшается на единицу после атаки
                    }
                    else // Если защиты вообще нет, то отнимаем из здоровья урон
                    {
                        defender.healthy -= damage;
                    }
            }

            if (enemy is Ninja) // Если текущший персонаж атакует ниндзю
            {
                    var defender = enemy as Ninja;
                    Random rnd = new Random();
                    bool iskicked = true;

                    if (rnd.Next(0, 101) > defender.evade) // Если соперник уклонился от удара, ничего у него не отнимаем
                    {
                        iskicked = false;
                    }

                    if (iskicked == true)
                    {
                        if (defender.guard > 0) // Если у персонажа всё еще есть защита, она действует
                        {
                            if (damage > defender.guard)
                            {
                                defender.healthy -= (damage - defender.guard); // Если атака сильнее защиты, отнимаем ХР
                            }
                            --defender.guard; // Защита уменьшается на единицу после атаки
                        }
                        else // Если защиты вообще нет, то отнимаем из здоровья урон
                        {
                            defender.healthy -= damage;
                        }
                    }
            }

            if (enemy is Samurai)
            {
                    var defender = enemy as Samurai;
                    Random rnd = new Random();
                    bool iskicked = true;

                    if (rnd.Next(0, 101) > defender.retaliaton) // Если самурай бьет в ответ
                    {
                        WriteLine("Samurai will make a counterthrust after Fighter's kick! (If he will be alive)");
                        if (guard > 0) // Если у персонажа всё еще есть защита, она действует
                        {
                            if (defender.damage > guard)
                            {
                                healthy -= (defender.damage - guard); // Если атака сильнее защиты, отнимаем ХР
                            }
                            --guard; // Защита уменьшается на единицу после атаки
                        }
                        else // Если защиты вообще нет, то отнимаем из здоровья урон
                        {
                            healthy -= defender.damage;
                        }
                    }

                    if (rnd.Next(0, 101) > defender.evade && healthy > 0) // Если соперник уклонился от удара, ничего у него не отнимаем
                    {
                        iskicked = false;
                    }

                    if (iskicked == true && healthy > 0)
                    {
                        if (defender.guard > 0) // Если у персонажа всё еще есть защита, она действует
                        {
                            if (damage > defender.guard)
                            {
                                defender.healthy -= (damage - defender.guard); // Если атака сильнее защиты, отнимаем ХР
                            }
                            --defender.guard; // Защита уменьшается на единицу после атаки
                        }
                        else // Если защиты вообще нет, то отнимаем из здоровья урон
                        {
                            defender.healthy -= damage;
                        }
                    }

            }
        }

        public virtual void BattleCry()
        {
            WriteLine("\nHIIIIAAAAAAAAA!!!");
        }

        public Fighter() // Сразу определяем количество здоровья и тд, которое будет у этого персонажа
        {
            Random rnd = new Random();
            healthy = rnd.Next(50, 71); // Здоровье файтера
            guard = rnd.Next(3, 7); // Защита персонажа
            damage = rnd.Next(5, 11); // Урон, который наносит персонаж
        }
    }
}

