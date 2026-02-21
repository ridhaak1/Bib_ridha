using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Bib_ridha
{
    internal class Library
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        List<Book> allBooks = new List<Book>();

        private Dictionary<DateTime, ReadingRoomItem> allReadingRoom = new Dictionary<DateTime, ReadingRoomItem>();
        public Dictionary<DateTime, ReadingRoomItem> AllReadingRoom
        {
            get {return allReadingRoom; }
        }
        
        public Library(string name)
        {
            Name = name;
            allBooks = new List<Book>();
        }

        public Library(): this ("R - Library")
        {
        }

        public void AddBook(Book book)
        {
            allBooks.Add(book);
        }

        public void DeleteBook(Book book)
        {
            allBooks.Remove(book);
        }

        public Book FindBookByISBN(string isbn)
        {
            foreach (var book in allBooks)
            {
                if(isbn == book.Isbn)
                {
                    return book;
                }
            }
            return null;
        }

        public Book FindBookByTitleAndAuthor(string title, string author)
        {
            foreach (Book book in allBooks)
            {
                if (book.Title.ToLower() == title.ToLower() && book.Author.ToLower() == author.ToLower())
                {
                    return book;
                }

            }
            return null;
        }

        public List<Book> AllAuthorBooks(string author)
        {
            List<Book> authorBooks = new List<Book>();
            foreach (var book in allBooks)
            {    
                if (author == book.Author)
                {
                    authorBooks.Add(book);
                }
            }
            if (authorBooks.Count == 0)
            {
                Console.WriteLine("Geen boeken gevonden voor deze auteur.");
            }
            return authorBooks;
        }

        public List<Book> FindBooksByGenre(Genre genre)
        {
            List<Book> genreBooks = new List<Book>();
            foreach (var book in allBooks)
            {
                if (genre == book.Genre)
                {
                    genreBooks.Add(book);
                }
            }
            if (genreBooks.Count == 0)
            {
                Console.WriteLine("Geen boeken gevonden voor deze Genre.");
            }
            return genreBooks;
        }

        public void ShowAllBooks()
        {
            foreach (Book book in allBooks)
            {
                book.ShowBoekInfo();
                Console.WriteLine("-------------------------------------------");
            }
        }

        public void AddBookFromCsv(string bestand)
        {
            string[] lijnen = File.ReadAllLines(bestand);
            for (int i = 0; i < lijnen.Length; i++)
            {
                string[] values = lijnen[i].Split(',');
                string bookName = values[0];
                string bookAuthor = values[1];
                string bookIsbn = values[2];
                string bookLanguage = values[3];
                int bookPages = Convert.ToInt32(values[4]);
                double bookPrice = Convert.ToDouble(values[5].Replace('.', ','));
                Genre bookGenre = (Genre)Enum.Parse(typeof(Genre), values[6]);
                Book newBook = new Book(bookName, bookAuthor, bookGenre, this);
                newBook.Isbn = bookIsbn;
                newBook.Language = bookLanguage;
                newBook.PageCount = bookPages;
                newBook.Price = bookPrice;
                newBook.Genre = bookGenre;
            } 
        }

        public void AddNewsPaper()
        {
            Console.WriteLine("Wat is de naam van de krant?");
            string title = Console.ReadLine();
            Console.WriteLine("Wat is de datum van de krant?");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Wat is de uitgeverij van de krant?");
            string publisher = Console.ReadLine();
            NewsPaper newNewsPaper = new NewsPaper(title, publisher, date);
            allReadingRoom.Add(date, newNewsPaper);
        }

        public void AddMagazine()
        {
            Console.WriteLine("Wat is de naam van het maandblad?");
            string title = Console.ReadLine();
            Console.WriteLine("Wat is de maand van het maandblad?");
            byte month = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Wat is het jaar van het maandblad?");
            uint year = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("Wat is de uitgeverij van het maandblad?");
            string publisher = Console.ReadLine();
            Magazine newMagazine = new Magazine(title, publisher, month, year);
            allReadingRoom.Add(DateTime.Now, newMagazine);
        }

        public void ShowAllMagazines()
        {
            Console.WriteLine("Alle maandbladen uit de leeszaal");
            foreach (var magazine in AllReadingRoom)
            {
                if (magazine.Value is Magazine)
                {
                    Console.WriteLine($"- {magazine.Value.Title} van {magazine.Key.ToString("dddd d MMMM yyyy")} van uitgeverij {magazine.Value.Publisher}");
                }
            }
        }

        public void ShowAllNewspapers()
        {
            Console.WriteLine("Alle maandbladen uit de leeszaal");
            foreach (var npaper in AllReadingRoom)
            {
                if (npaper.Value is NewsPaper)
                {
                    Console.WriteLine($"- {npaper.Value.Title} van {npaper.Key.ToString("dddd d MMMM yyyy")} van uitgeverij {npaper.Value.Publisher}");
                }
            }
        }

        public void AcquisitionsReadingRoomToday()
        {
            Console.WriteLine($"Aanwinsten in de leeszaal van {DateTime.Now.ToString("dddd d MMMM yyyy")}");
            foreach (var npaper in AllReadingRoom)
            {
                if (npaper.Value is NewsPaper && npaper.Key.Date == DateTime.Today)
                {
                    Console.WriteLine($"{npaper.Value.Title} met id {npaper.Value.Identification}");
                }
            }
            foreach (var magazine in AllReadingRoom)
            {
                if (magazine.Value is Magazine && magazine.Key.Date == DateTime.Today)
                {
                    Console.WriteLine($"{magazine.Value.Title} met id {magazine.Value.Identification}");
                }
            }
        }
    }
}
