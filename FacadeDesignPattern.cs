using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesignPattern
{
    class Program
    {
        /*
         *  Provide a uniformed interface to a set of interfaces in a subsystem.
         *  Facade defines a higher-level interface making subsystems easier to use. 
         */
        static void Main(string[] args)
        {
            HouseFacade facade = new HouseFacade();
            facade.CreateHouse();

            Console.ReadKey();
        }
    }


    public class HouseFoundation
    {
        public void SetFoundation()
        {
            Console.WriteLine("- Making foundation of the house");
        }

    }

    public class Walls
    {
        public void SetWalls()
        {
            Console.WriteLine("- Setting up walls");
        }
    }

    class Windows
    {
        public void SetWindows()
        {
            Console.WriteLine("- Setting up house windows");
        }
    }


    public class Furniture
    {
        public void SetUpFurniture()
        {
            Console.WriteLine("- Setting up furniture");
        }
    }

    public class Roof
    {
        public void SetUpRoof()
        {
            Console.WriteLine("- Setting up roof");
        }
    }



    public class HouseFacade
    {
        readonly HouseFoundation foundation;
        readonly Walls walls;
        readonly Windows windows;
        readonly Furniture furniture;
        readonly Roof roof;


        public HouseFacade()
        {
            foundation = new HouseFoundation();
            walls = new Walls();
            windows = new Windows();
            furniture = new Furniture();
            roof = new Roof();
        }


        public void CreateHouse()
        {
            Console.WriteLine("***Building house***");
            foundation.SetFoundation();
            walls.SetWalls();
            windows.SetWindows();
            furniture.SetUpFurniture();
            roof.SetUpRoof();

            Console.WriteLine("***House is completed!***");
        }
    }
}
