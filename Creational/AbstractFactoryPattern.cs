using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDesignPattern
{
	/*Representing interface for creating 
       	dependent objects without specifying their concrete classes*/
    class Program
    {
        static void Main(string[] args)
        {
            AzzerothFactory azzeroth = new BattleFieldFactory();
            WarcraftWorld world = new WarcraftWorld(azzeroth);
            world.HvsOBattle();
            world.FinalVerdictH();


            Console.WriteLine("\n");


            world.OvsHBattle();
            world.FinalVerdictO();


            Console.ReadKey();

        }
    }

    abstract class Horde
    {
        public abstract void Battle(Aliance a);
        public abstract void Verdict(Aliance a);
    }


    abstract class Aliance
    {
        public abstract void Battle(Horde h);
        public abstract void Verdict(Horde h);
    }


    class Orc : Horde
    {
        public override void Battle(Aliance a)
        {
            Console.WriteLine(GetType().Name + " battles " + a.GetType().Name);
        }

        public override void Verdict(Aliance a)
        {
            Console.WriteLine(GetType().Name + " slains " + a.GetType().Name);
        }
    }


    class Human : Aliance
    {
        public override void Battle(Horde h)
        {
            Console.WriteLine(GetType().Name + " battles " + h.GetType().Name);
        }

        public override void Verdict(Horde h)
        {
            Console.WriteLine(GetType().Name + " slains " + h.GetType().Name);
        }
    }

    abstract class AzzerothFactory
    {
        public abstract Horde CreateHordePlayer();
        public abstract Aliance CreateAliancePlayer();

    }


    class BattleFieldFactory : AzzerothFactory
    {
        public override Aliance CreateAliancePlayer()
        {
            return new Human();
        }

        public override Horde CreateHordePlayer()
        {
            return new Orc();
        }
    }


    class WarcraftWorld
    {
        private Aliance _human;
        private Horde _orc;

        public WarcraftWorld(AzzerothFactory factory)
        {
            _human = factory.CreateAliancePlayer();
            _orc = factory.CreateHordePlayer();
        }

        public void HvsOBattle()
        {
            _human.Battle(_orc);
        }

        public void FinalVerdictH()
        {
            _human.Verdict(_orc);
        }

        public void OvsHBattle()
        {
            _orc.Battle(_human);
        }

        public void FinalVerdictO()
        {
            _orc.Verdict(_human);
        }


    }




}
