using System;
using static System.Console;

namespace KDZ
{
    public class Ninja : Fighter
    {
        protected double poison { get; set; } // Вероятность отравить соперника

        public override void Attack(ref Human enemy) // Процесс атаки
        {
            if (!(enemy is Samurai) && !(enemy is Ninja))
            {
                    var defender = enemy as Fighter;
                    Random rnd = new Random();

                    if (rnd.Next(0, 101) > poison) // Если ниндзя отравил соперника
                    {
                        WriteLine("Ninja poisones enemy");
                        if ((0.07 * defender.healthy) >= 5) // У соперника не может отняться менее 5 единиц при отравлении
                        {
                            defender.healthy -= 0.07 * defender.healthy; // Отнимаем 7% ХР у соперника при отравлении
                        }
                        else
                        {
                            defender.healthy -= 5;
                        }
                    }

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

            if (enemy is Ninja)
            {
                    var defender = enemy as Ninja;
                    Random rnd = new Random();
                    bool iskicked = true;

                    if (rnd.Next(0, 101) > poison) // Если ниндзя отравил соперника
                    {
                        WriteLine("Ninja poisones enemy");
                        if ((0.07 * defender.healthy) >= 5) // У соперника не может отняться менее 5 единиц при отравлении
                        {
                            defender.healthy -= 0.07 * defender.healthy; // Отнимаем 7% ХР у соперника при отравлении
                        }
                        else
                        {
                            defender.healthy -= 5;
                        }
                    }

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

                    if (rnd.Next(0, 101) > poison) // Если ниндзя отравил соперника
                    {
                        WriteLine("Ninja poisones enemy");
                        if ((0.07 * defender.healthy) >= 5) // У соперника не может отняться менее 5 единиц при отравлении
                        {
                            defender.healthy -= 0.07 * defender.healthy; // Отнимаем 7% ХР у соперника при отравлении
                        }
                        else
                        {
                            defender.healthy -= 5;
                        }
                    }

                    if (rnd.Next(0, 101) > defender.retaliaton) // Если самурай бьет в ответ
                    {
                        WriteLine("Samurai will make a counterthrust after Ninja's kick! (If he will be alive)");
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

                    if (rnd.Next(0, 101) > defender.evade) // Если соперник уклонился от удара, ничего у него не отнимаем
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

        public override void BattleCry()
        {
            WriteLine("\nKIIIIAAAAAAAAA!!!");
        }

        public Ninja() // Сразу определяем количество здоровья и тд, которое будет у этого персонажа
        {
            Random rnd = new Random();
            healthy = rnd.Next(60, 76);
            damage = rnd.Next(8, 16); // Урон, который наносит персонаж
            guard = rnd.Next(4, 6); // Защита персонажа
            evade = rnd.Next(40, 61); // Вероятность уклонения
            poison = rnd.Next(30, 61); // Вероятность отравить соперника
        }
    }
}
