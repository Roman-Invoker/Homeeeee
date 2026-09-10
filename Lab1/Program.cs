using System;

namespace Lab1
{
    // Реалізація класу згідно з Варіантом 1
    public class Book
    {
        // Приватні поля
        private string title;
        private string author;

        // Публічна властивість
        public int Year { get; set; }

        // Публічні властивості для доступу до приватних полів
        public string Title
        {
            get => title;
            set => title = value;
        }

        public string Author
        {
            get => author;
            set => author = value;
        }

        // Конструктор для ініціалізації об'єкта
        public Book(string title, string author, int year)
        {
            this.title = title;
            this.author = author;
            Year = year;
        }

        // Метод класу, що повертає рядок із даними книги
        public string GetInfo()
        {
            return $"Книга: \"{title}\" | Автор: {author} | Рік видання: {Year}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створення 3 об'єктів класу Book
            Book book1 = new Book("Кобзар", "Тарас Шевченко", 1840);
            Book book2 = new Book("Тіні забутих предків", "Михайло Коцюбинський", 1911);
            Book book3 = new Book("Місто", "Валер'ян Підмогильний", 1928);

            // Виклик методів та виведення результатів у консоль
            Console.WriteLine(book1.GetInfo());
            Console.WriteLine(book2.GetInfo());
            Console.WriteLine(book3.GetInfo());
        }
    }
}
