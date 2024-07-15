using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        public class Book
        {
            public string Title;
            public string Author;
            public string BookId;
            public Book(string title, string author, string bookId)
            {
                Title = title;
                Author = author;
                BookId = bookId;
            }
            public void DisplayInfo()
            {
                Console.WriteLine($"Title: {Title}, Author: {Author}, Book ID: {BookId}");
            }
        }

        public class Person
        {
            public string Name;
            public int Age;
            public string PersonId;
            public Person(string name, int age, string personId)
            {
                Name = name;
                Age = age;
                PersonId = personId;
            }
        }

        public class Librarian : Person
        {
            public string EmpId;
            public List<Book> issued_books = new List<Book>();
            public Librarian(string name, int age, string personId, string empId) : base(name, age, personId)
            {
                EmpId = empId;
            }
            public void IssueBook(Book book, Person user)
            {
                if (book != null)
                {
                    issued_books.Add(book);
                    Console.WriteLine($"The book '{book.Title}' is issued to {user.Name}");
                }
                else
                {
                    Console.WriteLine($"The book is not present");
                }
            }

            public void ReturnBook(Book book, Person user)
            {
                if (book != null)
                {
                    issued_books.Remove(book);
                    Console.WriteLine($"The book '{book.Title}' is returned by {user.Name}");
                }
                else
                {
                    Console.WriteLine($"{user.Name} did not return the book");
                }
            }
        }

        public class Library
        {
            public string Name;
            public string ID;
            List<Book> books;
            Librarian librarian;
            public Library(string name, string id, Librarian librarian)
            {
                Name = name;
                ID = id;
                books = new List<Book>();
                this.librarian = librarian;
            }

            public void AddBook(Book book)
            {
                if (!books.Contains(book))
                {
                    books.Add(book);
                    Console.WriteLine($"Book '{book.Title}' added to the library.");
                }
                else
                {
                    Console.WriteLine($"The book '{book.Title}' already exists.");
                }
            }

            public void RemoveBook(string bookid)
            {
                Book BookToRemove=null;
                foreach(Book book in books)
                {
                    if (book.BookId == bookid)
                    {
                        BookToRemove = book;
                        break;
                    }
                }
                if(BookToRemove != null)
                {
                    books.Remove(BookToRemove);
                    Console.WriteLine($"{BookToRemove.Title} is removed.");
                }
                else
                {
                    Console.WriteLine($"Either the {BookToRemove.BookId} is not present in library or already removed.");
                }
            }

            public void ViewBooks()
            {
                Console.WriteLine("Books in the library:");
                foreach (Book book in books)
                {
                    book.DisplayInfo();
                }
            }
            public void SearchBook(string title)
            {
                bool found = false;
                foreach (Book book in books)
                {
                    if (book.Title==title)
                    {
                        book.DisplayInfo();
                        found = true; 
                        break;
                    }
                }
                if (!found)
                {
                    Console.WriteLine($"There is no book with the title '{title}' in the {Name} library.");
                }
            }

            public void ListIssuedBooks()
            {
                Console.WriteLine("Issued books:");
                foreach (Book book in librarian.issued_books)
                {
                    book.DisplayInfo();
                    Console.WriteLine("--------------------------------------------------");
                }
            }
        }

        static void Main(string[] args)
        {
            // Create books
            Book book1 = new Book("C sharp", "Junaid khlil", "Cure-1");
            Book book2 = new Book("HTML", "Hashim Khan", "Cure-2");
            Book book3 = new Book("CSS", "Hmmad Zafar", "Cure-3");
            book1.DisplayInfo(); 

            // Create librarian
            Librarian librarian = new Librarian("Ghulam Mustafa", 24, "5599", "5599-Ghulam Mustafa");

            // Create library
            Library library = new Library("National Library", "1", librarian);

            // Add books to the library
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);

            // Issue a book
            Person user = new Person("Khurram Aziz", 23, "5577");
            librarian.IssueBook(book1, user);

            // List issued books
            library.ListIssuedBooks();

            // Return a book
            librarian.ReturnBook(book1, user);

            // List issued books again
            library.ListIssuedBooks();

            // Search for a book by title
            library.SearchBook("CSS");

            // Remove a book from the library
            library.RemoveBook("Cure-2");

            // View books in the library again
            library.ViewBooks();
        }
    }
}
