using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFights
{
    internal class Program
    {
        static int newGame(bool isPlayerAlive, float healthEnemy)
        {
            if (isPlayerAlive && healthEnemy <= 0)
                return 1; // Победа
            if (isPlayerAlive && healthEnemy > 0)
                return 0; // Бой продолжается
            if (!isPlayerAlive)
            {
                Console.WriteLine("Боги не одарили Вас победой. Переродиться?" +
                    "\n1 - Я смогу (да)" +
                    "\n2 - Я сдаюсь (нет)");

                string input = Console.ReadLine();
                return input == "1" ? -2 : -1; // -2 = перерождение, -1 = выход
            }
            return -1;
        }
        static void Main(string[] args)
        {
            // Приветствие:
            Console.WriteLine("Добрро пожаловать, перерожденный!" +
                "\nТебе необходимо победить множество врагов на своем пути, чтобы победить Злого Владыку. " +
                "\nТвои враги сильны, но у тебя есть сила перерождения. Даже если ты погибнешь, ты всегда сможешь вернуться" +
                "\nНо помни, что перерождаешься ты не сразу, а спустя время. Пока ты копишь силы, твои враги наращивают мощь и пополняют ряды" +
                "\nСможешь ли ты победить?");
            Console.ReadKey();
            // Начальные данные игрока:
            float healthPlayer = 100;
            float armorPlayer = 50;
            float damagePlayer = 15;
            bool isPlayerAlive = true;

            int procentForDamage = 100;

            // Игра:
            Random rand = new Random();
            while (isPlayerAlive == true)
            {
            newEnemy:// Новый враг:
                float healthEnemy = rand.Next(50, 100 + 1);
                float armorEnemy = rand.Next(25, 50 + 1);
                float damageEnemy = rand.Next(5, 30 + 1);

            attack:// Атака:
                healthEnemy -= damagePlayer * (1 - armorEnemy / procentForDamage);
                healthPlayer -= damageEnemy * (1 - armorPlayer / procentForDamage);

                // Проверка здоровья игрока: если здоровье <= 0, игрок умирает
                if (healthPlayer <= 0) isPlayerAlive = false;

                // Вывод данных бойцов:
                Console.WriteLine(new String('-', 15));
                Console.WriteLine($"Данные игрока:" +
                    $"\nЗдоровье: {healthPlayer}" +
                    $"\nБроня: {armorPlayer}" +
                    $"\nУрон: {damagePlayer}");

                Console.WriteLine();
                Console.WriteLine($"Данные противника:" +
                    $"\nЗдоровье: {healthEnemy}" +
                    $"\nБроня: {armorEnemy}" +
                    $"\nУрон: {damageEnemy}");

                int result = newGame(isPlayerAlive, healthEnemy);

                if (result == 0) // Продолжение поединка
                {
                    Console.WriteLine("\nПротивники обмениваются ударами.");
                    Console.WriteLine("\nРаны оказались несмертельны для обоих - бой продолжается" +
                        "\nНажмите любую клавишу.");
                    Console.ReadKey();
                    goto attack;
                }
                else if (result == 1) // Победа
                {
                    Console.WriteLine("\nВы победили врага! Пора двигаться дальше!");
                    Console.ReadKey();
                    goto newEnemy;
                }
                else if (result == -2) // Перерождение
                {
                    Console.WriteLine("\nПерерождение...");
                    healthPlayer = 100;
                    isPlayerAlive = true;
                    goto newEnemy;
                }
                else // result == -1 — выход
                {
                    Console.WriteLine("\nСпасибо за игру!");
                    break;
                }
            }
        }
    }
}