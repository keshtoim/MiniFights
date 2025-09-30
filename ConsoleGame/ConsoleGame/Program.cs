using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            greeting();

            float healthPlayer = 0;
            float armorPlayer = 0;
            float damagePlayer = 0;

            classChoise(out healthPlayer, out armorPlayer, out damagePlayer);
            game(ref healthPlayer, ref armorPlayer, ref damagePlayer); 

            Console.ReadKey();
        }

        static void greeting()
        {
            Console.WriteLine("Добро пожаловать, перерожденный!" +
                "\nТебе необходимо победить множество врагов на своем пути, чтобы победить Злого Владыку. " +
                "\nТвои враги сильны, но у тебя есть сила перерождения. Даже если ты погибнешь, ты всегда сможешь вернуться" +
                "\nНо помни, что перерождаешься ты не сразу, а спустя время. Пока ты копишь силы, твои враги наращивают мощь и пополняют ряды" +
                "\nСможешь ли ты победить?");
            Console.ReadKey();
        }

        struct PlayerClass
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

        static void classChoise(out float healthPlayer, out float armorPlayer, out float damagePlayer)
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

                    if (classChoiseRestart())
                        return; // Успешный выбор — выходим из метода
                }
                else
                {
                    Console.WriteLine("\n❌ Неверный выбор. Попробуйте снова.");
                    Console.ReadKey();
                }
            }
        }
        
        static bool classChoiseRestart()
        {
            Console.WriteLine("Вы уверены в выборе класса?" +
                "\n1. Да" +
                "\n2. Нет");
            int approval;
            if (!int.TryParse(Console.ReadLine(), out approval))
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

        static void game(ref float healthPlayer, ref float armorPlayer, ref float damagePlayer)
        {
            bool isPlayerAlive = true;
            Random rand = new Random();
            int totalEnemies = 25;
            int countOfPotions = 3;

            for (int i = 0; i < totalEnemies && isPlayerAlive; i++)
            {
                float healthEnemy = rand.Next(50, 101);
                float armorEnemy = rand.Next(25, 51);
                float damageEnemy = rand.Next(5, 31);
                bool isEnemyAlive = true;

                Console.Clear();
                Console.WriteLine($"Враг #{i + 1} из {totalEnemies} появился!");
                Console.ReadKey();

                while (isEnemyAlive && isPlayerAlive)
                {
                    Console.Clear();
                    Console.WriteLine($"Бой с врагом #{i + 1}");
                    printInfoAboutParticipantsOfTheBattle(healthPlayer, armorPlayer, damagePlayer,
                        healthEnemy, armorEnemy, damageEnemy);
                    Console.WriteLine($"\nЗелий осталось: {countOfPotions}");

                    selectAction(
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
                    printInfoAboutParticipantsOfTheBattle(healthPlayer, armorPlayer, damagePlayer,
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

        static void printInfoAboutParticipantsOfTheBattle(float healthPlayer, float armorPlayer, float damagePlayer,
            float healthEnemy, float armorEnemy, float damageEnemy)
        {
            Console.WriteLine($"Данные игрока:" +
            $"\nЗдоровье: {healthPlayer:F0}" +
            $"\nБроня: {armorPlayer:F0}" +
            $"\nУрон: {damagePlayer:F0}" +
            $"\n" +
            $"\nДанные противника:" +
            $"\nЗдоровье: {healthEnemy:F0}" +
            $"\nnБроня: {armorEnemy:F0}" +
            $"\nУрон: {damageEnemy:F0}");
        }

        static int newGame(bool isPlayerAlive, float healthEnemy)
        {
            if (isPlayerAlive && healthEnemy <= 0)
                return 1; // Победа
            if (isPlayerAlive && healthEnemy > 0)
                return 0; // Бой продолжается
            if (!isPlayerAlive)
            {
                Console.WriteLine("Боги не одарили Вас победой. Переродиться?" +
                    "\n1 - Я смогу (начать заново)" +
                    "\n2 - Я сдаюсь (закончить игру)");

                string input = Console.ReadLine();
                return input == "1" ? -2 : -1; // -2 = перерождение, -1 = выход
            }
            return -1;
        }
        static void selectAction(ref float healthPlayer, float damagePlayer, float armorPlayer, ref int countOfPotions, float damageEnemy, 
            out float actualDamageToEnemy, out float actualDamageToPlayer)
        {
            actualDamageToEnemy = 0;
            actualDamageToPlayer = 0;

            Console.WriteLine($"Выберите действие:" +
                              $"\n1. Атака ({damagePlayer:F0} урона)" +
                              $"\n2. Блок (уменьшает получаемый урон)" +
                              $"\n3. Восстановить здоровье ({countOfPotions} зелий в наличии)");

            int action;
            if (!int.TryParse(Console.ReadLine(), out action))
            {
                Console.WriteLine("Некорректный ввод. По умолчанию выбрана атака.");
                action = 1;
            }

            switch (action)
            {
                case 1: // Атака
                    actualDamageToEnemy = damagePlayer;
                    actualDamageToPlayer = damageEnemy * (1 - armorPlayer / 100);
                    Console.WriteLine("Вы атакуете врага!");
                    break;

                case 2: // Блок
                        // Блок уменьшает получаемый урон на 30–70%
                    Random rand = new Random();
                    float blockFactor = rand.Next(30, 71) / 100f; // 0.3 – 0.7
                    actualDamageToEnemy = 0; // при блоке не атакуем
                    actualDamageToPlayer = damageEnemy * (1 - armorPlayer / 100) * (1 - blockFactor);
                    Console.WriteLine($"Вы блокируете атаку! Получено {actualDamageToPlayer:F0} урона.");
                    break;

                case 3: // Зелье
                    if (countOfPotions > 0)
                    {
                        healthPlayer += 25; // восстанавливаем 25 HP
                        countOfPotions--;
                        Console.WriteLine("Вы выпили зелье здоровья! +25 HP");
                    }
                    else
                    {
                        Console.WriteLine("У вас нет зелий! Пропуск хода.");
                    }
                    actualDamageToEnemy = 0;
                    actualDamageToPlayer = 0; // при использовании зелья враг не бьёт? Или бьёт?
                                              // ⚠️ Решение: обычно враг бьёт всегда, даже если ты лечишься.
                                              // Поэтому, возможно, стоит всё равно применить урон от врага.
                                              // Но для простоты пока — без урона при зелье.
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
