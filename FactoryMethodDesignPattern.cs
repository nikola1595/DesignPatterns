using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodDesignPattern
{
    /*
     *  Define an interface for creating an object,
     *  but let subclasses decide which class to instantiate.
     *  Factory Method lets a class defer instantiation to subclasses. 
     */
    class Program
    {
        static void Main(string[] args)
        {
            MaterialFactory factory = new ConcreteMaterialFactory();

            IFactory glass = factory.GetObject("Glass");
            glass.DrinkWater("glass");

            IFactory cup = factory.GetObject("Cup");
            cup.DrinkWater("cup");


            Console.ReadLine();
        }
    }


    public interface IFactory
    {
        void DrinkWater(string moldType);
    }

    public class Glass : IFactory
    {
        public void DrinkWater(string moldType)
        {
            Console.WriteLine($"Drinking water from {moldType}");
        }
    }


    public class Cup : IFactory
    {
        public void DrinkWater(string moldType)
        {
            Console.WriteLine($"Drinking water from {moldType}");
        }
    }

    public abstract class MaterialFactory
    {
        public abstract IFactory GetObject(string obj);
    }

    public class ConcreteMaterialFactory : MaterialFactory
    {
        public override IFactory GetObject(string obj)
        {
            switch (obj)
            {
                case "Glass":
                    return new Glass();
                case "Cup":
                    return new Cup();
                default:
                    throw new ApplicationException($"Object {obj} cannot be created");

            }
        }
    }




}
