using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDesignPattern
{
/*
    Adapter lets classes work together by converting  the interface of a class
    into another interface clients expect that couldn't work otherwise because of incompatible interfaces. */
    class Program
    {
        static void Main(string[] args)
        {

            ITarget adapter = new BookAdapter();
            BookCatalog catalog = new BookCatalog(adapter);
            catalog.ShowBookList();

            Console.ReadKey();
        }
    }


    public interface ITarget
    {
        List<string> GetBookList();
    }

    public class BookCatalog
    {
        private ITarget _bookSource;

        public BookCatalog(ITarget bookSource)
        {
            _bookSource = bookSource;
        }

        public void ShowBookList()
        {
            List<string> books = _bookSource.GetBookList();

            Console.WriteLine("Book List: \n");

            foreach (var book in books)
            {
                Console.WriteLine(book);

            }
        }

    }



    public class LibarySystem
    {
        public string[][] GetBooks()
        {
            string[][] books = new string[5][];

            books[0] = new string[] { "Title: The Lord of the Rings", "Author: J. R. R. Tolkien", "Number of pages: 1437" };
            books[1] = new string[] { "Title: The Tiger's Wife", "Author: Téa Obreht", "Number of pages: 338" };
            books[2] = new string[] { "Title: The Fifth Season", "Author: N.K. Jemisin", "Number of pages: 468" };
            books[3] = new string[] { "Title: The Underground Railroad", "Author: Colson Whitehead", "Number of pages: 306" };
            books[4] = new string[] { "Title: The Sisters Brothers", "Author: Patrick Dewitt", "Number of pages: 328" };

            return books;
        }
    }



    public class BookAdapter : LibarySystem, ITarget
    {
        public List<string> GetBookList()
        {
            List<string> bookList = new List<string>();

            string[][] books = GetBooks();

            foreach (var book in books)
            {
                bookList.Add(book[0]);
                bookList.Add(book[1]);
                bookList.Add(book[2]);
                bookList.Add("\n");

            }

            return bookList;
        }
    }


}
