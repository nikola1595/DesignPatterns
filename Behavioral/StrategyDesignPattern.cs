using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDesignPattern
{
    /*
     * Define a family of algorithms, encapsulate each one, and make them interchangeable.
     * Strategy pattern lets the algorithm vary independently from clients that use it. 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Construct construct = new Construct();

            IConstruct townHall = new TownHall(200, 100, 50);
            IConstruct barracks = new Barracks(100, 150, 75);
            IConstruct tower = new Tower(50, 180, 30);
            construct.ConstructBuilding(townHall);
            construct.ConstructBuilding(barracks);
            construct.ConstructBuilding(tower);

            construct.BuildingCompleted(townHall);
            construct.BuildingCompleted(barracks);
            construct.BuildingCompleted(tower);

            Console.ReadKey();
        }
    }

    public interface IConstruct
    {
        int Gold { get; set; }
        int Stone { get; set; }
        int Wood { get; set; }
        void ConstructBuilding(int gold, int stone, int wood);
        void BuildingCompleted();
    }


    public class Construct
    {

        public void ConstructBuilding(IConstruct construct)
        {
            construct.ConstructBuilding(construct.Gold, construct.Stone, construct.Wood);
        }

        public void BuildingCompleted(IConstruct construct)
        {
            construct.BuildingCompleted();
        }
    }

    public class TownHall : IConstruct
    {
        public int Gold { get; set; }
        public int Stone { get; set; }
        public int Wood { get; set; }

        public TownHall(int gold, int stone, int wood)
        {
            this.Gold = gold;
            this.Stone = stone;
            this.Wood = wood;
        }

        public void ConstructBuilding(int gold, int stone, int wood)
        {
            Console.WriteLine($"Making Town hall....\n Resources used:  gold: {gold} stone: {stone} wood: {wood}");
        }

        public void BuildingCompleted()
        {
            Console.WriteLine("Tower Hall completed");
        }
    }

    public class Barracks : IConstruct
    {
        public int Gold { get; set; }
        public int Stone { get; set; }
        public int Wood { get; set; }

        public Barracks(int gold, int stone, int wood)
        {
            this.Gold = gold;
            this.Stone = stone;
            this.Wood = wood;
        }

        public void ConstructBuilding(int gold, int stone, int wood)
        {
            Console.WriteLine($"Making Barracks....\n Resources used:  gold: {gold} stone: {stone} wood: {wood}");
        }

        public void BuildingCompleted()
        {
            Console.WriteLine("Barracks completed");
        }
    }


    public class Tower : IConstruct
    {
        public int Gold { get; set; }
        public int Stone { get; set; }
        public int Wood { get; set; }

        public Tower(int gold, int stone, int wood)
        {
            this.Gold = gold;
            this.Stone = stone;
            this.Wood = wood;
        }

        public void ConstructBuilding(int gold, int stone, int wood)
        {
            Console.WriteLine($"Making Tower....\n Resources used:  gold: {gold} stone: {stone} wood: {wood}");
        }

        public void BuildingCompleted()
        {
            Console.WriteLine("Tower completed");
        }
    }
}
