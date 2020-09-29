using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyDesignPattern
{
    class Program
    {
        /*
         *  Represents a substitution for another object to control access to it.

         */
        static void Main(string[] args)
        {
            Server server = new Server();

            Console.WriteLine("Client: Executing the client code with a real subject:");

            Object realObj = new Object();
            server.ClientRequest(realObj);

            Console.WriteLine("\nClient: Executing the same client code with a proxy: ");

            Proxy proxy = new Proxy(realObj);
            server.ClientRequest(proxy);

            Console.ReadKey();

        }


        public interface IObject
        {
            void HandlingRequest();
        }

        public class Object : IObject
        {
            public void HandlingRequest()
            {
                Console.WriteLine("Chrome: Handling Request.");
            }
        }


        public class Proxy : IObject
        {
            private Object _obj;

            public Proxy(Object obj)
            {
                _obj = obj;
            }

            public bool CheckAccess()
            {
                Console.WriteLine("Proxy: Checking access prior to firing a real request.");

                return true;
            }

            public void HandlingRequest()
            {
                if (CheckAccess())
                {
                    _obj.HandlingRequest();

                    LogAccess();
                }
            }

            public void LogAccess()
            {
                Console.WriteLine("Logging time of handling request");
            }

            
        }


        public class Server
        {
            public void ClientRequest(IObject obj)
            {
                obj.HandlingRequest();
            }
        }



        
    }
}
