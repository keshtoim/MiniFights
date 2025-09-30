using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    internal class Program
    {
        private static readonly Random rand = new Random();
        private const int TOTAL_ENEMIES = 25;
        private const int STARTING_POTIONS = 3;
        private const float POTION_HEAL_AMOUNT = 25f;
        private const int BLOCK_REDUCTION_MIN = 30;
        private const int BLOCK_REDUCTION_MAX = 71;

        static void Main(string[] args)
        {
            Greeting();
            HowToPlay();

            float healthPlayer = 0;
            float armorPlayer = 0;
            float damagePlayer = 0;

            ClassChoice(out healthPlayer, out armorPlayer, out damagePlayer);
            Game(ref healthPlayer, ref armorPlayer, ref damagePlayer);

            Console.ReadKey();
        }

        private static void Greeting()
        {
            Console.WriteLine("Добро пожаловать, перерожденный!" +
                "\nТебе необходимо победить множество врагов на своем пути, чтобы победить Злого Владыку. " +
                "\nТвои враги сильны, но у тебя есть сила перерождения. Даже если ты погибнешь, ты всегда сможешь вернуться" +
                "\nНо помни, что перерождаешься ты не сразу, а спустя время. Пока ты копишь силы, твои враги наращивают мощь и пополняют ряды" +
                "\nСможешь ли ты победить?");
            Console.ReadKey();
        }

        private static void HowToPlay()
        {
            Console.Clear();
            Console.WriteLine("Как играть:");
            Console.WriteLine();
            Console.WriteLine("- После любого текстового сообщения нажмите любую клавишу, чтобы продолжить.");
            Console.WriteLine("- При выборе действия (например, класса или хода в бою) введите число и нажмите клавишу Enter.");
            Console.WriteLine("- В бою вы можете атаковать, блокировать удары или использовать зелье здоровья.");
            Console.WriteLine("- У вас есть 3 зелья здоровья на всё прохождение.");
            Console.WriteLine();
            Console.WriteLine("Готовы? Нажмите любую клавишу, чтобы начать выбор класса...");
            Console.ReadKey();
        }

        private struct PlayerClass
        {
            public string Name;
            public float Health;
            public float Armor;
            public float Damage;

            public PlayerClass(string name, float health, float armor, float damage)
            {
                Name = name;
                Health = health;
                Armor = armor;
                Damage = damage;
            }

            public void PrintInfo()
            {
                Console.WriteLine($"Характеристики класса '{Name}':" +
                                  $"\nНачальное здоровье: {Health}" +
                                  $"\nНачальная броня: {Armor}" +
                                  $"\nНачальный урон: {Damage}");
            }
        }

        private static readonly Dictionary<int, PlayerClass> AvailableClasses = new Dictionary<int, PlayerClass>
        {
            { 1, new PlayerClass("Воин", 100, 50, 25) },
            { 2, new PlayerClass("Берсерк", 175, 10, 30) },
            { 3, new PlayerClass("Ассасин", 110, 15, 40) },
            { 4, new PlayerClass("Вор", 90, 25, 35) },
            { 5, new PlayerClass("Простолюдин", 60, 10, 15) },
            { 6, new PlayerClass("Раб", 50, 0, 5) }
        };

        private static void ClassChoice(out float healthPlayer, out float armorPlayer, out float damagePlayer)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Перед новым путешествием необходимо выбрать путь героя.\n");

                foreach (var kvp in AvailableClasses)
                {
                    Console.WriteLine($"{kvp.Key}. {kvp.Value.Name}");
                }

                Console.WriteLine("\nДля выбора класса введите соответствующую цифру:");

                if (int.TryParse(Console.ReadLine(), out int choice) && AvailableClasses.TryGetValue(choice, out var selectedClass))
                {
                    selectedClass.PrintInfo();

                    healthPlayer = selectedClass.Health;
                    armorPlayer = selectedClass.Armor;
                    damagePlayer = selectedClass.Damage;

                    if (ClassChoiceRestart())
                        return;
                }
                else
                {
                    Console.WriteLine("\nНеверный выбор. Попробуйте снова.");
                    Console.ReadKey();
                }
            }
        }

        private static bool ClassChoiceRestart()
        {
            Console.WriteLine("Вы уверены в выборе класса?" +
                "\n1. Да" +
                "\n2. Нет");
            if (!int.TryParse(Console.ReadLine(), out int approval))
            {
                Console.WriteLine("Некорректный ввод.");
                return false;
            }

            switch (approval)
            {
                case 1:
                    return true;
                case 2:
                    return false;
                default:
                    Console.WriteLine("Выбран неверный ответ");
                    return false;
            }
        }

        private static void Game(ref float healthPlayer, ref float armorPlayer, ref float damagePlayer)
        {
            bool isPlayerAlive = true;
            int countOfPotions = STARTING_POTIONS;

            for (int i = 0; i < TOTAL_ENEMIES && isPlayerAlive; i++)
            {
                float healthEnemy = rand.Next(50, 101);
                float armorEnemy = rand.Next(25, 51);
                float damageEnemy = rand.Next(5, 31);
                bool isEnemyAlive = true;

                Console.Clear();
                Console.WriteLine($"Враг #{i + 1} из {TOTAL_ENEMIES} появился!");
                Console.ReadKey();

                while (isEnemyAlive && isPlayerAlive)
                {
                    Console.Clear();
                    Console.WriteLine($"Бой с врагом #{i + 1}");
                    PrintInfoAboutParticipantsOfTheBattle(healthPlayer, armorPlayer, damagePlayer,
                        healthEnemy, armorEnemy, damageEnemy);
                    Console.WriteLine($"\nЗелий осталось: {countOfPotions}");

                    SelectAction(
                        ref healthPlayer,
                        damagePlayer,
                        armorPlayer,
                        ref countOfPotions,
                        damageEnemy,
                        out float damageToEnemy,
                        out float damageToPlayer);

                    healthEnemy -= damageToEnemy;
                    healthPlayer -= damageToPlayer;

                    if (healthPlayer <= 0)
                    {
                        isPlayerAlive = false;
                        healthPlayer = 0;
                    }
                    if (healthEnemy <= 0)
                    {
                        isEnemyAlive = false;
                        healthEnemy = 0;
                    }

                    Console.Clear();
                    Console.WriteLine($"Бой с врагом #{i + 1}");
                    PrintInfoAboutParticipantsOfTheBattle(healthPlayer, armorPlayer, damagePlayer,
                        healthEnemy, armorEnemy, damageEnemy);

                    if (!isEnemyAlive)
                    {
                        Console.WriteLine("\nВы победили врага!");
                    }
                    else if (!isPlayerAlive)
                    {
                        Console.WriteLine("\nВы пали в бою...");
                    }
                    else
                    {
                        Console.WriteLine("\nБой продолжается...");
                    }

                    Console.ReadKey();
                }
            }

            Console.Clear();
            if (isPlayerAlive)
            {
                Console.WriteLine("Поздравляем! Вы одолели всех врагов и победили Злого Владыку!");
            }
            else
            {
                Console.WriteLine("Вы погибли в бою. Злой Владыка торжествует...");
            }
        }

        private static void PrintInfoAboutParticipantsOfTheBattle(
            float healthPlayer, float armorPlayer, float damagePlayer,
            float healthEnemy, float armorEnemy, float damageEnemy)
        {
            Console.WriteLine($"Данные игрока:" +
                $"\nЗдоровье: {healthPlayer:F0}" +
                $"\nБроня: {armorPlayer:F0}" +
                $"\nУрон: {damagePlayer:F0}" +
                $"\n" +
                $"\nДанные противника:" +
                $"\nЗдоровье: {healthEnemy:F0}" +
                $"\nБроня: {armorEnemy:F0}" +
                $"\nУрон: {damageEnemy:F0}");
        }

        private static void SelectAction(
            ref float healthPlayer,
            float damagePlayer,
            float armorPlayer,
            ref int countOfPotions,
            float damageEnemy,
            out float actualDamageToEnemy,
            out float actualDamageToPlayer)
        {
            actualDamageToEnemy = 0;
            actualDamageToPlayer = 0;

            Console.WriteLine($"Выберите действие:" +
                              $"\n1. Атака ({damagePlayer:F0} урона)" +
                              $"\n2. Блок (уменьшает получаемый урон)" +
                              $"\n3. Восстановить здоровье ({countOfPotions} зелий в наличии)");

            if (!int.TryParse(Console.ReadLine(), out int action))
            {
                Console.WriteLine("Некорректный ввод. По умолчанию выбрана атака.");
                action = 1;
            }

            switch (action)
            {
                case 1:
                    actualDamageToEnemy = damagePlayer;
                    actualDamageToPlayer = damageEnemy * (1 - armorPlayer / 100);
                    Console.WriteLine("Вы атакуете врага!");
                    break;

                case 2:
                    float blockFactor = rand.Next(BLOCK_REDUCTION_MIN, BLOCK_REDUCTION_MAX) / 100f;
                    actualDamageToEnemy = 0;
                    actualDamageToPlayer = damageEnemy * (1 - armorPlayer / 100) * (1 - blockFactor);
                    Console.WriteLine($"Вы блокируете атаку! Получено {actualDamageToPlayer:F0} урона.");
                    break;

                case 3:
                    if (countOfPotions > 0)
                    {
                        healthPlayer += POTION_HEAL_AMOUNT;
                        countOfPotions--;
                        Console.WriteLine("Вы выпили зелье здоровья! +25 HP");
                    }
                    else
                    {
                        Console.WriteLine("У вас нет зелий! Пропуск хода.");
                    }
                    actualDamageToEnemy = 0;
                    actualDamageToPlayer = 0;
                    break;

                default:
                    Console.WriteLine("Неизвестное действие. Атака по умолчанию.");
                    actualDamageToEnemy = damagePlayer;
                    actualDamageToPlayer = damageEnemy * (1 - armorPlayer / 100);
                    break;
            }

            Console.ReadKey();
        }
    }
}
