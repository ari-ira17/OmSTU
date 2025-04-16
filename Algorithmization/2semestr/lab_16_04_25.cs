using System;

struct Book
{
    public string Surname;
    public string Name;
    public string Patronymic;
    public string Book_Title;
    public string Book_Year;
    public string Book_Publisher;
    public string[] Book_Movements;

    public Book(string surname, string name, string patronymic, string book_t, string book_y, string book_p)
    {
        Surname = surname;
        Name = name;
        Patronymic = patronymic;
        Book_Title = book_t;
        Book_Year =  book_y;
        Book_Publisher = book_p;
        Book_Movements = new string[2];
    }

    public void Add_Movements()
    {
        Console.WriteLine("Введите дату, когда книгу взяли");
        Book_Movements[0] = Console.ReadLine();
        Console.WriteLine("Введите дату, когда книгу отдали");
        Book_Movements[1] = Console.ReadLine();
        Console.WriteLine("Перемещения книги записаны!");
        Console.WriteLine();
    }
}

class Functions
{
    public static void Non_Read(List<Book> books)
    {
        foreach (Book book in books)
        {
            if (book.Book_Movements[0] == "" && book.Book_Movements[1] == "")
            {
                Console.WriteLine("Книга {0} не была взята", book.Book_Title);
                Console.WriteLine("Автор: {0} {1} {2}", book.Surname, book.Name, book.Patronymic);
                Console.WriteLine("Издательство: {0}", book.Book_Publisher);
                Console.WriteLine("Год выпуска: {0}", book.Book_Year);
                Console.WriteLine();
            }
        }
    }

    public static void Reading_Now(List<Book> books)
    {
        foreach (Book book in books)
        {
            if (book.Book_Movements[1] == "" && book.Book_Movements[0] != "")
            {
                Console.WriteLine("Книга {0} на руках", book.Book_Title);
                Console.WriteLine("Автор: {0} {1} {2}", book.Surname, book.Name, book.Patronymic);
                Console.WriteLine("Издательство: {0}", book.Book_Publisher);
                Console.WriteLine("Год выпуска: {0}", book.Book_Year);
                Console.WriteLine();
            }
        }
    }
}

class Laboratory_10
{
    static void Main()
    {
        Console.Clear();

        List<Book> books = new List<Book>();
        
        Book book_1 = new Book("Пушкин", "Александр", "Сергеевич", "Дубровский", "2021", "АСТ");
        Console.WriteLine("Заполните передвижения о book_1");
        book_1.Add_Movements();

        Book book_2 = new Book("Достоевский", "Федор", "Михайлович", "Идиот", "2016", "Эксмо");
        Console.WriteLine("Заполните передвижения о book_2");
        book_2.Add_Movements();

        books.Add(book_1);
        books.Add(book_2);

        Functions.Non_Read(books);
        Functions.Reading_Now(books);
    }
}