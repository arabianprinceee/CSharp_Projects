using System;
using static System.Console;

namespace KDZ
{
    public class Samurai : Fighter
    {
        protected double Retaliaton; // Вероятность, с которой самурай наносит ответный удар
        public double retaliaton { get { return Retaliaton; } set { Retaliaton = value; } }

        public override void Attack(ref Human enemy)
        {
            if (!(enemy is Samurai) && !(enemy is Ninja))
            {
                    var defender = enemy as Fighter;

                    if (defender.guard > 0) // Если у персонажа всё еще есть защита, она действует
                    {
                        if (damage > defender.guard)
                        {
                            defender.healthy -= damage - defender.guard; // Если атака сильнее защиты, отнимаем ХР
                        }
                        else
                        {
                            defender.healthy -= 0; // Если защита больше атаки, ничего не отнимаем
                        }
                        --defender.guard; // Защита уменьшается на единицу после атаки
                    }
                    else // Если защиты вообще нет, то отнимаем из здоровья урон
                    {
                        defender.healthy -= damage;
                    }
            }

            if (enemy is Ninja)
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
                                defender.healthy -= damage - defender.guard; // Если атака сильнее защиты, отнимаем ХР
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

                    if (rnd.Next(0, 101) > defender.evade) // Если соперник уклонился от удара, ничего у него не отнимаем
                    {
                        iskicked = false;
                    }

                    if (rnd.Next(0, 101) > defender.retaliaton) // Если самурай бьет в ответ
                    {
                        WriteLine("Samurai will make a counterthrust after attack! (If he will be alive)");
                        if (guard > 0) // Если у персонажа всё еще есть защита, она действует
                        {
                            if (defender.damage > guard)
                            {
                                healthy -= defender.damage - guard; // Если атака сильнее защиты, отнимаем ХР
                            }
                            else
                            {
                                healthy -= 0; // Если защита больше атаки, ничего не отнимаем
                            }
                            --guard; // Защита уменьшается на единицу после атаки
                        }
                        else // Если защиты вообще нет, то отнимаем из здоровья урон
                        {
                            healthy -= defender.damage;
                        }
                    }

                    if (iskicked == true && healthy > 0)
                    {
                        if (defender.guard > 0) // Если у персонажа всё еще есть защита, она действует
                        {
                            if (damage > defender.guard)
                            {
                                defender.healthy -= damage - defender.guard; // Если атака сильнее защиты, отнимаем ХР
                            }
                            else
                            {
                                defender.healthy -= 0; // Если защита больше атаки, ничего не отнимаем
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

        public override void BattleCry()
        {
            WriteLine("\nCHUAAAAAAAAA!!!");
        }

        public Samurai() // Сразу определяем количество здоровья и тд, которое будет у этого персонажа
        {
            Random rnd = new Random();
            healthy = rnd.Next(70, 86);
            damage = rnd.Next(7, 13); // Урон, который наносит персонаж
            guard = rnd.Next(4, 7); // Защита персонажа
            evade = rnd.Next(30, 51); // Вероятность, что он уклонится
            retaliaton = rnd.Next(30, 51); // Вероятность, что он ударит в ответ
        }
    }
}
