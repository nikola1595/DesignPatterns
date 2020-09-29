using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignPattern
{
    /*
     * Ensures that a class has only one instance and provides global point of access to it. 
     */
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 3; i ++)
            {
                Book.Instance.ShowDetails();
            }

            Console.ReadKey();
        }
    }


    //singleton class
    public class Book
    {
        private static Book instance = null;
        private string BookName { get; set; }
        public int NumberOfPages { get; set; }

        private Book()
        {
            BookName = "The Lord of The Rings";
            NumberOfPages = 1137;
        }

        private static object syncLock = new object();

        public static Book Instance
        {
            get
            {
                lock(syncLock)
                {
                    if(instance == null)
                    {
                        instance = new Book();
                    }
                }
                return instance;
            }
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Book {BookName} has {NumberOfPages} pages");
        }


    }




}
