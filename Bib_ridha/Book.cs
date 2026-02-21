using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_ridha
{
    enum Genre
    {
        Roman,
        Thriller,
        ScienceFiction,
        Fantasy,
        Biography,
        Philosophy,
        History,
        Children,
        Drama,
        Romance,
        Mystery,
        SelfHelp,
        Poetry,
        Detective,
        Classic,
        Adventure,
        Horror,
        Spiritual,
        Inspirational,
        Crime,
        Schoolbook
    }
    internal class Book : ILendable
    {
		private string title;
		public string Title
		{
			get { return title; }
            set
            {
                if (value == "" || value == null)
                { throw new ArgumentException("Title mag niet leeg!"); }
               title = value;
            }
        }

		private string author;
		public string Author
        {
			get { return author; }
            set
            {
                if (value == "" || value == null)
                {
					throw new ArgumentException("Auther mag niet leeg!");
				}
                 author = value; 
            }
        }

		// isbn string zo dat ik length kan tellen
		private string isbn;
		public string Isbn
		{
			get { return isbn; }
			set { 
					if(value.Length != 10)
					{ throw new InvalidIsbnException("ISBN moet 10 cijfers bevatten!");}
					isbn = value; 
				}
		}

		private string language;
		public string Language
		{
			get { return language; }
			set { language = value; }
		}

		private DateTime publicationYear;
		public DateTime PublicationYear
		{
			get { return publicationYear; }
			set { publicationYear = value; }
		}

		private int pageCount;
		public int PageCount
		{
			get { return pageCount; }
			set {
					if(value < 0) { throw new NegativeValueException("Aantal paginas mag niet Nigatief!"); }
					pageCount = value;
				}
		}

		private double price;
		public double Price
		{
			get { return price; }
            set
            {
                if (value < 0) {throw new NegativeValueException("Prijs paginas mag niet Nigatief!"); }
                price = value; 
            }
        }

		private Genre genre;
		public Genre Genre
		{
			get { return genre; }
			set { genre = value; }
		}

        private bool isAvailable;

        public bool IsAvailable
        {
            get { return isAvailable; }
            set { isAvailable = value; }
        }

        private DateTime borrowingDate;

        public DateTime BorrowingDate
        {
            get { return borrowingDate; }
            set { borrowingDate = value; }
        }

        private int borrowDays;

        public int BorrowDays
        {
            get { return borrowDays; }
            set { borrowDays = value; }
        }

        public Book(string title, string author, Genre genre, Library library)
        {
            Title = title;
            Author = author;
            library.AddBook(this);
            IsAvailable = true;
            this.Genre = genre;
            if (genre == Genre.Schoolbook)
            {
                BorrowDays = 10;
            }
            else
            {
                BorrowDays = 20;
            }
        }

        public void ShowBoekInfo()
		{
			Console.WriteLine($"Book Details: \n" +
							$"Titel: {title}\n" +
							$"Auteur: {author}\n" +
							$"ISBN: {isbn}\n" +
							$"Taal: {language}\n" +
							$"Publicatiejaar: {publicationYear}\n" +
							$"Aantal paginas: {pageCount}\n" +
							$"Prijs: {price}\n"+
                            $"Genre: {genre}\n" +
                            $"Beschikbaar: {(IsAvailable ? "Ja" : "Nee")}");
        }

        public void Borrow()
        {
            if (IsAvailable)
            {
                BorrowingDate = DateTime.Now;
                IsAvailable = false;
                Console.WriteLine($"Het boek moet ten laatste teruggebracht worden op {BorrowingDate.AddDays(BorrowDays)}");
            }
            else
            {
                Console.WriteLine("Het boek is momenteel niet beschikbaar");
            }
        }

        public void Return()
        {
            IsAvailable = true;
            if (DateTime.Now > BorrowingDate.AddDays(BorrowDays))
            {
                Console.WriteLine("Het boek is te laat binnengebracht");
            }
            else
            {
                Console.WriteLine("Het boek is op tijd binnengebracht");
            }
        }
    }
}
