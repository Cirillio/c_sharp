namespace LAB3_Events
{
    internal class Program
    {
        // Объект аргументов события
        public class UserEnteredNumberEventArgs
        {
            public int Input { get; set; }
            public DateTime EnteredAt { get; set; }
        }

        // Событие
        public static event EventHandler<UserEnteredNumberEventArgs> UserEnteredNumber;

        // Функция вывода числа введенного пользователем
        private static void PrintUserEnteredNumber(object sender, UserEnteredNumberEventArgs e)
        {
            Console.WriteLine($"\nПользователь ввел число {e.Input} в {e.EnteredAt}\n");
        }

        // Основная функция
        static void Main(string[] args)
        {
            // Объявление переменных
            string input;
            int number;

            // Подписка на событие
            UserEnteredNumber += PrintUserEnteredNumber;

            // Бесконечный цикл для чтения пользовательского ввода
            while (true)
            {
                // Вывод сообщения о вводе
                Console.Write("Введите число > ");

                // Чтение строки с консоли 
                input = Console.ReadLine();

                // Проверка что строка является числом
                if (int.TryParse(input, out number))
                {
                    // Вызываем событие с объектом аргументов
                    UserEnteredNumber?.Invoke(null, new UserEnteredNumberEventArgs{ Input = number, EnteredAt = DateTime.Now });
                }
            }
        }
    }
}
