using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPattern
{
//Decouple an abstraction from its implementation so that the same building process can vary independently. 
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("***Character Inventory***");

            var set1 = new CharacterInventory(new PreviousSet());
            set1.EquipSet();
            set1.GetItems();

            Console.WriteLine("\nEquiping new set: ");

            var set2 = new CharacterInventory(new NewSet());
            set2.EquipSet();
            set2.GetItems();

            Console.ReadKey();
        }
    }

    public class Items
    {
        public string HeadSlot { get; set; }
        public string ChestSlot { get; set; }
        public string LegsSlot { get; set; }
        public string HandsSlot { get; set; }
        public string PrimaryWeapon { get; set; }
        public string SecondaryWeapon { get; set; }

    }



    public interface ICharacterInventory
    {
        void EquipHeadSlot();
        void EquipChestSlot();
        void EquipHandsSlot();
        void EquipLegsSlot();
        void EquipPrimaryWeapon();

        void EquipSecondaryWeapon();

        void GetItems();
    }


    public class PreviousSet : ICharacterInventory
    {
        Items items = new Items();

        List<string> previousItemList = new List<string>();
        public void EquipChestSlot()
        {
            items.ChestSlot = "True Warrior Chestplate";
        }

        public void EquipHandsSlot()
        {
            items.HandsSlot = "True Warrior Hands";
        }

        public void EquipHeadSlot()
        {
            items.HeadSlot = "True Warrior Helmet";
        }

        public void EquipLegsSlot()
        {
            items.LegsSlot = "True Warrior Leggings";
        }

        public void EquipPrimaryWeapon()
        {
            items.PrimaryWeapon = "Bare-Handed";
        }

        public void EquipSecondaryWeapon()
        {
            items.SecondaryWeapon = "Guardian Shield";
        }

        public void GetItems()
        {
            previousItemList.Add(items.ChestSlot);
            previousItemList.Add(items.HandsSlot);
            previousItemList.Add(items.HeadSlot);
            previousItemList.Add(items.LegsSlot);

            previousItemList.Add(items.PrimaryWeapon);
            previousItemList.Add(items.SecondaryWeapon);

            foreach(var item in previousItemList)
            {
                Console.WriteLine(item);
            }
        }
    }


    public class NewSet : ICharacterInventory
    {
        Items items = new Items();

        List<string> newItemList = new List<string>();
        public void EquipChestSlot()
        {
            items.ChestSlot = "Ivaldi's Chest of Deadly Mist";
        }

        public void EquipHandsSlot()
        {
            items.HandsSlot = "Ivaldi's Gauntlets of Deadly Mist";
        }

        public void EquipHeadSlot()
        {
            items.HeadSlot = "Ivaldi's Helmet of Deadly Mist";
        }

        public void EquipLegsSlot()
        {
            items.LegsSlot = "Ivaldi's Leggings of Deadly Mist";
        }

        public void EquipPrimaryWeapon()
        {
            items.PrimaryWeapon = "Leviathan Axe";
        }

        public void EquipSecondaryWeapon()
        {
            items.SecondaryWeapon = "Blades of Chaos";
        }

        public void GetItems()
        {
            newItemList.Add(items.ChestSlot);
            newItemList.Add(items.HandsSlot);
            newItemList.Add(items.HeadSlot);
            newItemList.Add(items.LegsSlot);

            newItemList.Add(items.PrimaryWeapon);
            newItemList.Add(items.SecondaryWeapon);

            foreach (var item in newItemList)
            {
                Console.WriteLine(item);
            }
        }
    }


    public class CharacterInventory
    {
        private ICharacterInventory _charInventory;

        public CharacterInventory(ICharacterInventory charInventory)
        {
            _charInventory = charInventory;
        }


        public void EquipSet()
        {
            _charInventory.EquipChestSlot();
            _charInventory.EquipHandsSlot();
            _charInventory.EquipLegsSlot();
            _charInventory.EquipHeadSlot();

            _charInventory.EquipPrimaryWeapon();
            _charInventory.EquipSecondaryWeapon();
        }


        public void GetItems()
        {
           _charInventory.GetItems();
        }
    }
}
