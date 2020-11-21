using System;
using System.Threading;
using static System.Console;

namespace KDZ
{
    // В этом классе хранятся различные полезные методы, которые будут использоваться в мейне

    public class Helper
    {
        public static void InfoAboutGame(int turn)
        {
            if (turn == 0)
            {
                Thread.Sleep(700);
                WriteLine("\nYour team is going to attack first!");
                Thread.Sleep(150);
            }
            else
            {
                Thread.Sleep(750);
                WriteLine("\nComputer's team is going to attack first!");
                Thread.Sleep(150);
            }
        }

        public static void Wishing()
        {
            Thread.Sleep(900);
            WriteLine("Good luck!");
            Thread.Sleep(500);
        }


        public static void DeleteDeadPlayers(ref Human[] humen, ref bool gameover) // Удаляем из массива умерших игроков
        {
            for (int i = 0; i < humen.Length; ++i)
            {
                if (humen[i].healthy <= 0)
                {
                    humen[i] = humen[humen.Length - 1];
                    Array.Resize(ref humen, humen.Length - 1);
                }
            }

            if (humen.Length == 0) // Если остался нулевой массив, значит все игроки умерли
            {
                gameover = true;
            }
        }


        public static int EnterN() // Проверка ввода в самом начале
        {
            if (!int.TryParse(ReadLine(), out int n) || (n != 1 && n != 2))
                {
                WriteLine("Your input is wrong, tap ENTER to try again or tap ESC to exit!\n");

                if (ReadKey().Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
                else
                {
                    MainClass.Main(); // Возвращаемся в старт
                }
            }
            return n;
        }



        public static void ForN2(ref Human[] ComputerTeam, ref Human[] UserTeam) // Если пользователь выбрал 2-ой способ
        {
            RandomTeam(ref ComputerTeam);

            double MoneyToChoose = 10; // Количество денег у пользователя на создание своей команды

            WriteLine("You have 10 points to buy your team's characters. Here is the price list : \n");
            WriteLine("1. Fighter - 1 point\n" +
                      "2. Ninja   - 1.5 points\n" +
                      "3. Samurai - 2 points\n");

            UserChooseTeam(ref UserTeam, MoneyToChoose);

            Thread.Sleep(500);
            Write("\nLoading the game, wait a bit");
            Thread.Sleep(400);
            Write(".");
            Thread.Sleep(400);
            Write(".");
            Thread.Sleep(400);
            Write(".\n");
            Thread.Sleep(1000);

            WriteLine("\nHERE IS THE COMPUTER'S TEAM : \n");
            ShowTeam(ComputerTeam); // Показываем пользователю команду соперника

            Thread.Sleep(1500);

            WriteLine("\nHERE IS YOUR TEAM : \n");
            ShowTeam(UserTeam); // Показываем пользователю его команду
        }



        public static void ForN1(ref Human[] ComputerTeam, ref Human[] UserTeam) // Если пользователь выбрал 1-ый способ
        {
            WriteLine("\nVery nice!");
            Thread.Sleep(1000);
            WriteLine("Now you don't need to do anything.");
            Thread.Sleep(1000);
            WriteLine("Relax and enjoy.");
            Thread.Sleep(1000);
            Write("\nLoading the game, wait a bit");
            Thread.Sleep(500);
            Write(".");
            Thread.Sleep(500);
            Write(".");
            Thread.Sleep(500);
            Write(".\n");
            Thread.Sleep(1000);

            RandomTeam(ref ComputerTeam); // Создаём команду компьютера
            RandomTeam(ref UserTeam); // Создаем команду пользователя

            WriteLine("\nCOMPUTER TEAM IS READY : \n");
            ShowTeam(ComputerTeam); // Показываем пользователю команду соперника

            Thread.Sleep(1500);

            WriteLine("\nYOUR TEAM IS READY : \n");
            ShowTeam(UserTeam); // Показываем пользователю его команду
        }



        public static void Hello() // Просто приветствие
        {
            WriteLine("Now you are in the game! \n\nThere are two options of playing : \n" +
                    "1) Make a random team of 10 fighters. \n" +
                    "2) Build your own team. \n\nChoose the option by input '1' or '2'.");
        }



        public static void Loading() // Просто загрузка игры
        {
            Thread.Sleep(1150);
            WriteLine();
            Write("    3");
            Thread.Sleep(1100);
            Write("    2");
            Thread.Sleep(1100);
            Write("    1\n");
            Thread.Sleep(1100);
            WriteLine("\nThe Great War STARTS RIGHT NOW!");
            Thread.Sleep(1600);
        }



        public static void AlivePlayers(Human[] humen, Human[] humen1, ref int[] aliveCT, ref int[] aliveUT) // Здесь будем исключать из игры умерших персонажей
        {
            for (int i = 0; i < humen.Length; ++i) // 1 - живой персонаж, умерших заменяем на нули
            {
                aliveCT[i] = 1;
            }
            for (int i = 0; i < humen1.Length; ++i) // 1 - живой персонаж, умерших заменяем на нули
            {
                aliveUT[i] = 1;
            }
        }



        public static void RandomTeam(ref Human[] humen) // Метод, который заполняет команду рандомными персонажами
        {
            for (int i = 0; i < 10; ++i)
            {
                Random rnd = new Random();
                int j = rnd.Next(1, 101);

                // [1;45] – Fighter
                // [46;75] – Ninja
                // [76;100] – Samurai

                if (j <= 45)
                {
                    humen[i] = new Fighter();
                }
                if (j >= 46 && j <= 75)
                {
                    humen[i] = new Ninja();
                }
                if (j >= 76)
                {
                    humen[i] = new Samurai();
                }
            }
        }



        public static void ShowTeam(Human[] humen) // Метод, показывающий всех участников данной команды
        {
            for (int i = 0; i < humen.Length; ++i)
            {
                var s = humen[i].ToString();
                string player = s.Replace("KDZ.", "");
                
                Write($"{player}      ");

                Thread.Sleep(200);

                if (i % 2 != 0)
                {
                    WriteLine();
                }
                if (humen.Length % 2 != 0 && i == humen.Length - 1)
                {
                    Write("\n");
                }
            }
        }



        public static void UserChooseTeam(ref Human[] UserTeam, double MoneyToChoose) // Метод, через который пользователь выбирает команду
        {
            int i = 0, quantityOfcharacters = 0;
            bool possibletobuy = true;
            while (possibletobuy != false) // Здесь пользователь будет набирать себе персонажей в команду
            {
                WriteLine("Input the number of fighter that you want to add." +
                    $"\nYou still have {MoneyToChoose} points!");

                if (!int.TryParse(ReadLine(), out int character) || (character != 1 && character != 2 && character != 3))
                {
                    WriteLine("\nWrong enter! Try again or tap ESC to exit the game!\n");

                    if (ReadKey().Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        MoneyToChoose = 10;
                        i = 0;
                        quantityOfcharacters = 0;
                        possibletobuy = true;
                        Clear();
                        WriteLine("Now you are in the game again!\n");
                        WriteLine("You have 10 points to buy your team's characters. Here is the price list : \n");
                        WriteLine("1. Fighter - 1 point\n" +
                                  "2. Ninja   - 1.5 points\n" +
                                  "3. Samurai - 2 points\n");
                        continue;
                    }
                }

                if (character == 1 && MoneyToChoose >= 1)
                {
                    WriteLine("\nFIGHTER SUCCESFULLY JOINED YOUR TEAM!\n");
                    MoneyToChoose -= 1;
                    UserTeam[i] = new Fighter();
                    ++i;
                    ++quantityOfcharacters;

                    if (MoneyToChoose < 1)
                    {
                        WriteLine("\nNow you don't have enough money to add anyone!");
                        Thread.Sleep(500);
                        break;
                    }
                    continue;
                }
                if (character == 1 && MoneyToChoose < 1)
                {
                    WriteLine("You can't buy someone else!\n");
                    possibletobuy = false;
                    Thread.Sleep(500);
                }
                if (character == 2 && MoneyToChoose >= 1.5)
                {
                    WriteLine("\nNINJA SUCCESFULLY JOINED YOUR TEAM!\n");
                    MoneyToChoose -= 1.5;
                    UserTeam[i] = new Ninja();
                    ++i;
                    ++quantityOfcharacters;
                    if (MoneyToChoose < 1)
                    {
                        WriteLine("Now you don't have enough money to add anyone!");
                        Thread.Sleep(500);
                        break;
                    }
                    continue;
                }
                if (character == 2 && MoneyToChoose < 1.5)
                {
                    if (MoneyToChoose >= 1)
                    {
                        WriteLine("\nYou can't choose this character!\nYou still able to buy Fighter!\n");
                        --i;
                    }
                    else
                    {
                        WriteLine("You can't buy someone else!\n");
                        possibletobuy = false;
                        Thread.Sleep(500);
                    }
                }
                if (character == 3 && MoneyToChoose >= 2)
                {
                    WriteLine("\nSAMURAI SUCCESFULLY JOINED YOUR TEAM!\n");
                    MoneyToChoose -= 2;
                    UserTeam[i] = new Samurai();

                    ++i;
                    ++quantityOfcharacters;

                    if (MoneyToChoose < 1)
                    {
                        Thread.Sleep(250);
                        WriteLine("Now you don't have enough money to add anyone!");
                        Thread.Sleep(500);
                        break;
                    }
                    continue;
                }
                if (character == 3 && MoneyToChoose < 2)
                {
                    WriteLine("\nYou can't choose this character!");
                    if (MoneyToChoose >= 1.5)
                    {
                        WriteLine("You still able to buy Ninja or Fighter!\n");
                        --i;
                    }
                    if (MoneyToChoose < 1.5 && MoneyToChoose >= 1)
                    {
                        WriteLine("You still able to buy Fighter!\n");
                        --i;
                    }
                    if (MoneyToChoose < 1)
                    {
                        WriteLine("You can't buy someone else!");
                        possibletobuy = false;
                        Thread.Sleep(500);
                    }
                }
                ++i;
            }
            Array.Resize(ref UserTeam, quantityOfcharacters);
        }
    }
}
