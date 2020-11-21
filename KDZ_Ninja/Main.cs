using System;
using System.Threading;
using static System.Console;

namespace KDZ
{
    class MainClass
    {
        public static void Main()
        {
            do
            {
                Clear();
                Helper.Hello();
                int n = Helper.EnterN();

                Human[] ComputerTeam = new Human[10];
                Human[] UserTeam = new Human[10];

                if (n == 1) 
                {
                    try
                    {
                        Helper.ForN1(ref ComputerTeam, ref UserTeam); // При таком n обе команды создаются рандомным способом
                    }
                    catch (OutOfMemoryException ex)
                    {
                        WriteLine(ex.Message);
                        WriteLine(ex.StackTrace);
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        WriteLine(ex.Message);
                        WriteLine(ex.StackTrace);
                    }
                    catch (ArrayTypeMismatchException ex)
                    {
                        WriteLine(ex.Message);
                        WriteLine(ex.StackTrace);
                    }
                    catch (Exception ex)
                    {
                        WriteLine(ex.Message);
                        WriteLine(ex.StackTrace);
                    }
                }

                if (n == 2) 
                {
                    try
                    {
                        Helper.ForN2(ref ComputerTeam, ref UserTeam); // При таком n игрок сам выбирает себе команду
                    }
                    catch (OutOfMemoryException ex)
                    {
                        WriteLine(ex.Message);
                        WriteLine(ex.StackTrace);
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        WriteLine(ex.Message);
                        WriteLine(ex.StackTrace);
                    }
                    catch (ArrayTypeMismatchException ex)
                    {
                        WriteLine(ex.Message);
                        WriteLine(ex.StackTrace);
                    }
                    catch (Exception ex)
                    {
                        WriteLine(ex.Message);
                        WriteLine(ex.StackTrace);
                    }
                }

                Random whoisfirst = new Random(); // Рандомайзим, кто начинает игру
                int turn = whoisfirst.Next(0, 2);

                bool gameover = false;

                Helper.InfoAboutGame(turn);

                Helper.Wishing(); // Имитация загрузки игры

                Helper.Loading(); // Имитация загрузки игры

                // Далее – игровой процесс

                while (gameover != true)
                {
                    try
                    {
                        if (turn % 2 == 0)
                        {
                            Random rnd = new Random();
                            int whoAttack = rnd.Next(0, UserTeam.Length); // Индекс атакующего игрока
                            int whoDeffend = rnd.Next(0, ComputerTeam.Length); // Индекс защищающегося игрока

                            if (!(UserTeam[whoAttack] is Ninja) && !(UserTeam[whoAttack] is Samurai)) // Если атакующий игрок - файтер
                            {
                                var attacker = UserTeam[whoAttack] as Fighter;
                                double healthBeforeAttack = ComputerTeam[whoDeffend].healthy; // Здоровье защищающегося до атаки
                                attacker.BattleCry();
                                attacker.Attack(ref ComputerTeam[whoDeffend]);
                                WriteLine($"{attacker.ToString().Replace("KDZ.", "")} from UserTeam attacked {ComputerTeam[whoDeffend].ToString().Replace("KDZ.", "")} from ComputerTeam\n" +
                                    $"Health loss is : {healthBeforeAttack - ComputerTeam[whoDeffend].healthy} points");

                                if (attacker.healthy <= 0) // Если атакующий игрок умер
                                {
                                    WriteLine($"{attacker.ToString().Replace("KDZ.", "")} from UserTeam just died...");
                                }

                                if (ComputerTeam[whoDeffend].healthy <= 0) // Если защищающийся игркок умер
                                {
                                    WriteLine($"{ComputerTeam[whoDeffend].ToString().Replace("KDZ.", "")} from ComputerTeam just died...");
                                }

                            }

                            if (UserTeam[whoAttack] is Ninja) // Если атакующий игрок - ниндзя
                            {
                                var attacker = UserTeam[whoAttack] as Ninja;
                                double healthBeforeAttack = ComputerTeam[whoDeffend].healthy; // Здоровье защищающегося до атаки
                                attacker.BattleCry();
                                attacker.Attack(ref ComputerTeam[whoDeffend]);
                                WriteLine($"{attacker.ToString().Replace("KDZ.", "")} from UserTeam attacked {ComputerTeam[whoDeffend].ToString().Replace("KDZ.", "")} from ComputerTeam\n" +
                                    $"Health loss is : {healthBeforeAttack - ComputerTeam[whoDeffend].healthy} points");

                                if (attacker.healthy <= 0)  // Если атакующий игрок умер
                                {
                                    WriteLine($"{attacker.ToString().Replace("KDZ.", "")} from UserTeam just died...");
                                }

                                if (ComputerTeam[whoDeffend].healthy <= 0) // Если защищающийся игркок умер
                                {
                                    WriteLine($"{ComputerTeam[whoDeffend].ToString().Replace("KDZ.", "")} from ComputerTeam just died...");
                                }
                            }

                            if (UserTeam[whoAttack] is Samurai) // Если атакующий игрок - самурай
                            {
                                var attacker = UserTeam[whoAttack] as Samurai;
                                double healthBeforeAttack = ComputerTeam[whoDeffend].healthy; // Здоровье защищающегося до атаки
                                attacker.BattleCry();
                                attacker.Attack(ref ComputerTeam[whoDeffend]);
                                WriteLine($"{attacker.ToString().Replace("KDZ.", "")} from UserTeam attacked {ComputerTeam[whoDeffend].ToString().Replace("KDZ.", "")} from ComputerTeam\n" +
                                    $"Health loss is : {healthBeforeAttack - ComputerTeam[whoDeffend].healthy} points");

                                if (attacker.healthy <= 0)  // Если атакующий игрок умер
                                {
                                    WriteLine($"{attacker.ToString().Replace("KDZ.", "")} from UserTeam just died...");
                                }

                                if (ComputerTeam[whoDeffend].healthy <= 0) // Если защищающийся игркок умер
                                {
                                    WriteLine($"{ComputerTeam[whoDeffend].ToString().Replace("KDZ.", "")} from ComputerTeam just died...");
                                }
                            }

                            Helper.DeleteDeadPlayers(ref UserTeam, ref gameover); // Проверка, что есть живые игроки
                            Helper.DeleteDeadPlayers(ref ComputerTeam, ref gameover); // Проверка, что есть живые игроки

                            ++turn;
                            Thread.Sleep(10);
                            continue;
                        }

                        if (turn % 2 != 0)
                        {
                            Random rnd = new Random();
                            int whoAttack = rnd.Next(0, ComputerTeam.Length);
                            int whoDeffend = rnd.Next(0, UserTeam.Length);

                            if (!(ComputerTeam[whoAttack] is Ninja) && !(ComputerTeam[whoAttack] is Samurai))
                            {
                                var attacker = ComputerTeam[whoAttack] as Fighter;
                                double healthBeforeAttack = UserTeam[whoDeffend].healthy;
                                attacker.BattleCry();
                                attacker.Attack(ref UserTeam[whoDeffend]);
                                WriteLine($"{attacker.ToString().Replace("KDZ.", "")} from ComputerTeam attacked {UserTeam[whoDeffend].ToString().Replace("KDZ.", "")} from UserTeam\n" +
                                    $"Health loss is : {healthBeforeAttack - UserTeam[whoDeffend].healthy} points");

                                if (attacker.healthy <= 0)  // Если атакующий игрок умер
                                {
                                    WriteLine($"{attacker.ToString().Replace("KDZ.", "")} from ComputerTeam dies...");
                                }

                                if (UserTeam[whoDeffend].healthy <= 0) // Если защищающийся игркок умер
                                {
                                    WriteLine($"{UserTeam[whoDeffend].ToString().Replace("KDZ.", "")} from UserTeam dies...");
                                }
                            }

                            if (ComputerTeam[whoAttack] is Ninja)
                            {
                                var attacker = ComputerTeam[whoAttack] as Ninja;
                                double healthBeforeAttack = UserTeam[whoDeffend].healthy;
                                attacker.BattleCry();
                                attacker.Attack(ref UserTeam[whoDeffend]);
                                WriteLine($"{attacker.ToString().Replace("KDZ.", "")} from ComputerTeam attacked {UserTeam[whoDeffend].ToString().Replace("KDZ.", "")} from UserTeam\n" +
                                    $"Health loss is : {healthBeforeAttack - UserTeam[whoDeffend].healthy} points");

                                if (attacker.healthy <= 0)  // Если атакующий игрок умер
                                {
                                    WriteLine($"{attacker.ToString().Replace("KDZ.", "")} from ComputerTeam dies...");
                                }

                                if (UserTeam[whoDeffend].healthy <= 0) // Если защищающийся игркок умер
                                {
                                    WriteLine($"{UserTeam[whoDeffend].ToString().Replace("KDZ.", "")} from UserTeam dies...");
                                }
                            }

                            if (ComputerTeam[whoAttack] is Samurai)
                            {
                                var attacker = ComputerTeam[whoAttack] as Samurai;
                                double healthBeforeAttack = UserTeam[whoDeffend].healthy;
                                attacker.BattleCry();
                                attacker.Attack(ref UserTeam[whoDeffend]);
                                WriteLine($"{attacker.ToString().Replace("KDZ.", "")} from ComputerTeam attacked {UserTeam[whoDeffend].ToString().Replace("KDZ.", "")} from UserTeam\n" +
                                    $"Health loss is : {healthBeforeAttack - UserTeam[whoDeffend].healthy} points");

                                if (attacker.healthy <= 0)  // Если атакующий игрок умер
                                {
                                    WriteLine($"{attacker.ToString().Replace("KDZ.", "")} from ComputerTeam dies...");
                                }

                                if (UserTeam[whoDeffend].healthy <= 0) // Если защищающийся игркок умер
                                {
                                    WriteLine($"{UserTeam[whoDeffend].ToString().Replace("KDZ.", "")} from UserTeam dies...");
                                }
                            }

                            try
                            {
                                Helper.DeleteDeadPlayers(ref UserTeam, ref gameover); // Проверка, что есть живые игроки
                                Helper.DeleteDeadPlayers(ref ComputerTeam, ref gameover); // Проверка, что есть живые игроки
                            }
                            catch (ArgumentException ex)
                            {
                                WriteLine(ex.Message);
                                WriteLine(ex.StackTrace);
                            }
                            catch (IndexOutOfRangeException ex)
                            {
                                WriteLine(ex.Message);
                                WriteLine(ex.StackTrace);
                            }
                            catch (OutOfMemoryException ex)
                            {
                                WriteLine(ex.Message);
                                WriteLine(ex.StackTrace);
                            }

                            ++turn;
                            Thread.Sleep(20);
                            continue;
                        }
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        WriteLine(ex.Message);
                        WriteLine(ex.StackTrace);
                    }
                    catch (ArgumentException ex)
                    {
                        WriteLine(ex.Message);
                        WriteLine(ex.StackTrace);
                    }
                    catch (OutOfMemoryException ex)
                    {
                        WriteLine(ex.Message);
                        WriteLine(ex.StackTrace);
                    }
                    catch (Exception ex)
                    {
                        WriteLine(ex.Message);
                        WriteLine(ex.StackTrace);
                    }
                }

                WriteLine("\nThis is the end of Great War!");
                if (UserTeam.Length == 0 && ComputerTeam.Length != 0)
                {
                    WriteLine($"\nComputerTeam won after {turn} moves!\nBut don't worry, you will have another chance!\nComputerTeam has {ComputerTeam.Length} alive players after the game!\n");
                }

                if (UserTeam.Length != 0 && ComputerTeam.Length == 0)
                {
                    WriteLine($"\nUserTeam won after {turn} moves! Congratulations!\nUserTeam has {UserTeam.Length} alive players after the game!\n");
                }
                WriteLine("This is the end of game. Tap ENTER to restart or ESC to exit!");
            }
            while (ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
