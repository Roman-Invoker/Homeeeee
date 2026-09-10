using System;

namespace OOPLab2
{
    public class Restaurant
    {
        // Приватні поля
        private string _name;
        private string _cuisine;
        private double _rating;

        // Публічні властивості
        public string Name
        {
            get => _name;
            set => _name = string.IsNullOrWhiteSpace(value) ? "Unnamed" : value;
        }

        public string Cuisine
        {
            get => _cuisine;
            set => _cuisine = string.IsNullOrWhiteSpace(value) ? "Mixed" : value;
        }

        public double Rating
        {
            get => _rating;
            set
            {
                if (value < 1 || value > 5)
                    throw new ArgumentOutOfRangeException(nameof(value), "Рейтинг повинен бути в межах від 1 до 5.");
                _rating = value;
            }
        }

        // Конструктор за замовчуванням, викликає параметризований через : this()
        public Restaurant() : this("Unnamed", "Mixed", 3.0)
        {
        }

        // Параметризований конструктор
        public Restaurant(string name, string cuisine, double rating)
        {
            Name = name;
            Cuisine = cuisine;
            Rating = rating;
            Console.WriteLine($"[Конструктор] Створено ресторан \"{Name}\".");
        }

        // Метод, що виконує дію, пов'язану з класом
        public void ServeDish(string dishName)
        {
            Console.WriteLine($"Ресторан \"{Name}\" ({_cuisine} кухня) подає страву: {dishName}. " +
                               $"Рейтинг закладу: {Rating:F1}");
        }

        // Деструктор (фіналізатор)
        ~Restaurant()
        {
            Console.WriteLine($"[Деструктор] Об'єкт Restaurant \"{_name}\" знищується збирачем сміття.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Creating objects ===");

            Restaurant r1 = new Restaurant(); // конструктор за замовчуванням
            Restaurant r2 = new Restaurant("La Pasta", "Italian", 4.7); // параметризований
            Restaurant r3 = new Restaurant("Sushi Time", "Japanese", 4.9);

            Console.WriteLine("\n=== Objects created ===\n");

            r1.ServeDish("House Salad");
            r2.ServeDish("Spaghetti Carbonara");
            r3.ServeDish("Salmon Nigiri");

            // Демонстрація валідації властивості
            try
            {
                r1.Rating = 10; // некоректне значення
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"\n[Валідація] Помилка: {ex.Message}");
            }

            Console.WriteLine("\n=== End of Main, preparing for GC ===");

            r1 = null;
            r2 = null;
            r3 = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("=== Program finished ===");
        }
    }
}