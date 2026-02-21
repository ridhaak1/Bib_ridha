using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace Bib_ridha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library myLibrary = new Library();
            myLibrary.AddBookFromCsv("test.csv");
            bool status = true;
            while (status)
            {
                Console.WriteLine($"Hoofdmenu – R - BIB");
                Console.WriteLine("1 - Een boek toevoegen (titel en auteur invoeren)");
                Console.WriteLine("2 - Informatie toevoegen aan een boek (ISBN)");
                Console.WriteLine("3 - Alle info van een boek te tonen op basis van ingeven titel en auteur");
                Console.WriteLine("4 - Alle boeken tonen (op basis van Genre)");
                Console.WriteLine("5 - Een boek verwijderen uit de bibliotheek");
                Console.WriteLine("6 - Alle boeken tonen in de bibliotheek");
                Console.WriteLine("7 - csv-bestand in te lezen");
                Console.WriteLine("8 - Een krant of maandblad toe te voegen");
                Console.WriteLine("9 - Alle kranten tonen");
                Console.WriteLine("10 - Alle maanbladen te tonen");
                Console.WriteLine("11 - De aanwinste van de leeszaal op te vragen ");
                Console.WriteLine("12 - Een boek ontlenen");
                Console.WriteLine("13 - Een boek terugbrengen");
                Console.WriteLine("0 - Afsluiten");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        Console.Write("Geef de titel van het boek: ");
                        string title = Console.ReadLine();
                        Console.Write("Geef de auteur van het boek: ");
                        string author = Console.ReadLine();
                        Console.Write("Geef de genre van het boek: ");
                        Genre genre = Enum.TryParse(Console.ReadLine(), out Genre tempGenre) ? tempGenre : Genre.Roman;
                        Book newBook = new Book(title, author, genre, myLibrary);
                        break;
                    case "2":
                        Console.WriteLine("Geef de titel van het boek: ");
                        string titleBook = Console.ReadLine();
                        Console.WriteLine("Geef de auteur van het boek: ");
                        string authorBook = Console.ReadLine();
                        Book foundBook = myLibrary.FindBookByTitleAndAuthor(titleBook, authorBook);
                        if (foundBook != null)
                        {
                            Console.WriteLine("ISBN moet 10 cijfers bevatten!");
                            Console.WriteLine("Geef de ISBN van het boek: ");
                            string isbnBook = Console.ReadLine();
                            foundBook.Isbn = isbnBook;
                            Console.WriteLine("ISBN succesvol toegevoegd!");
                        }
                        else
                        {
                            Console.WriteLine("Boek niet gevonden!");
                        }
                        
                        break;
                    case "3":
                        Console.WriteLine("Geef de titel van het boek: ");
                        string foundTitle = Console.ReadLine();
                        Console.WriteLine("Geef de auteur van het boek: ");
                        string foundAuthor = Console.ReadLine();
                        Book foundedBook = myLibrary.FindBookByTitleAndAuthor(foundTitle, foundAuthor);
                        foundedBook.ShowBoekInfo();
                        break;
                    case "4":
                        Console.WriteLine("Kies een Genre: ");
                        foreach (string genreName in Enum.GetNames(typeof(Genre)))
                        {
                            Console.WriteLine($" - {genreName}");
                        }
                        Console.Write("Geef het genre:");
                        string inputGenre = Console.ReadLine();
                        Genre choiseGenre = (Genre)Enum.Parse(typeof(Genre), inputGenre, true);
                        List<Book> foundedbooks = myLibrary.FindBooksByGenre(choiseGenre);
                        foreach (Book book in foundedbooks)
                        {
                            Console.WriteLine($"Titel: {book.Title} - {book.Author}");
                        }
                        break;
                    case "5":
                        Console.Write("Geet de titel van het boek: ");
                        string bookToRemove = Console.ReadLine();
                        Console.Write("Geet de auteur van het boek: ");
                        string authorBookToRemove = Console.ReadLine();
                        Book deleteBook = myLibrary.FindBookByTitleAndAuthor(bookToRemove, authorBookToRemove);
                        myLibrary.DeleteBook(deleteBook);
                        Console.Write("Boek succesvol verwijderd! ");
                        break;
                    case "6":
                        myLibrary.ShowAllBooks();
                        break;
                    case "7":
                        Console.WriteLine("Geef het pad van het CSV-bestand:");
                        string filePath = Console.ReadLine();
                        myLibrary.AddBookFromCsv(filePath);
                        break;
                    case "8":
                        Console.WriteLine("1 - Krant Toevoegen");
                        Console.WriteLine("2 - Maandblad Toevoegen");
                        int choise = Convert.ToInt32(Console.ReadLine());
                        switch (choise)
                        {
                            case 1: myLibrary.AddNewsPaper();
                                break;
                            case 2:
                                myLibrary.AddMagazine();
                                break;
                            default: Console.WriteLine("Vul enkel de getal 1 of 2");
                                break;
                        }
                        break;
                    case "9":
                        myLibrary.ShowAllNewspapers();
                        break;
                    case "10":
                        myLibrary.ShowAllMagazines();
                        break;
                    case "11":
                        myLibrary.AcquisitionsReadingRoomToday();
                        break;
                    case "12":
                        Console.Write("Geef de titel van het boek dat je wilt ontlenen: ");
                        string titleBorrow = Console.ReadLine();
                        Console.Write("Geef de auteur van het boek: ");
                        string authorBorrow = Console.ReadLine();
                        Book boekToBorrow = myLibrary.FindBookByTitleAndAuthor(titleBorrow, authorBorrow);
                        if (boekToBorrow != null)
                        {
                            boekToBorrow.Borrow();
                        }
                        else
                        {
                            Console.WriteLine("Boek niet gevonden.");
                        }
                        break;
                    case "13":
                        Console.Write("Geef de titel van het boek dat je wilt terugbrengen: ");
                        string titleReturn = Console.ReadLine();
                        Console.Write("Geef de auteur van het boek: ");
                        string authorReturn = Console.ReadLine();
                        Book boekToReturn = myLibrary.FindBookByTitleAndAuthor(titleReturn, authorReturn);
                        if (boekToReturn != null)
                        {
                            boekToReturn.Return();
                        }
                        else
                        {
                            Console.WriteLine("Boek niet gevonden.");
                        }
                        break;
                    case "0":
                        status = false;
                        break;

                } 
            }


        }
    }
}
