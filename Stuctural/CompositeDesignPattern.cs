using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesignPattern
{
    class Program
    {
        // Compose objects into tree structures to represent part-whole hierarchies.
        //Composite pattern lets clients treat individual objects and compositions of objects evenly. 
        static void Main(string[] args)
        {
            ThisPC PCUser = new ThisPC { OS = "Windows", numberOfPartitions = 2 };

            Folder cPartition = new Folder { FolderName = "C", FolderSize = "600GB" };
            Folder dPartition = new Folder { FolderName = "D", FolderSize = "900GB" };
            
            PCUser.AddFolder(cPartition);
            PCUser.AddFolder(dPartition);

            Folder programming = new Folder { FolderName = "Programming", FolderSize = "200GB" };
            Folder games = new Folder { FolderName = "Games", FolderSize = "200GB" };
            Folder music = new Folder { FolderName = "Music", FolderSize = "50GB" };
            Folder pictures = new Folder { FolderName = "Pictures", FolderSize = "40GB" };

            cPartition.AddFolder(programming);
            dPartition.AddFolder(games);
            dPartition.AddFolder(music);
            cPartition.AddFolder(pictures);

            Folder CSharp = new Folder { FolderName = "C#", FolderSize = "100GB" };
            Folder JavaScript = new Folder { FolderName = "JavaScript", FolderSize = "50GB" };
            programming.AddFolder(CSharp);
            programming.AddFolder(JavaScript);
            Folder Pictures2020 = new Folder { FolderName = "Pictures2020", FolderSize = "39GB" };
            pictures.AddFolder(Pictures2020);


            Folder MOBA = new Folder { FolderName = "MOBA", FolderSize = "20GB" };
            Folder RPG = new Folder { FolderName = "RPG Games", FolderSize = "100GB" };

            games.AddFolder(MOBA);
            games.AddFolder(RPG);


            Console.WriteLine($"Partition name: {cPartition.FolderName} | Folder size: {cPartition.FolderSize}");
            foreach (var folder in cPartition)
            {
                folder.ShowFolderDetails(folder);
                
            }
            Console.WriteLine($"Folder name : {programming.FolderName}");
            foreach (var folder in programming)
            {
                folder.ShowFolderDetails(folder);
            }
            Console.WriteLine($"Folder name : {pictures.FolderName}");
            foreach (var folder in pictures)
            {
                folder.ShowFolderDetails(folder);

            }

            Console.WriteLine($"\nPartition name: {dPartition.FolderName} | Folder size: {dPartition.FolderSize}");
            foreach(var folder in dPartition)
            {
                folder.ShowFolderDetails(folder);
            }
            Console.WriteLine($"Folder name: {games.FolderName}");
            foreach (var folder in games)
            {
                folder.ShowFolderDetails(folder);
            }
            dPartition.RemoveFolder(music);




            Console.ReadKey();

        }
    }


    public interface IFolder
    {
        string FolderName { get; set; }
        string FolderSize { get; set; }

        void ShowFolderDetails(IFolder folder);

    }

    public class Folder : IFolder, IEnumerable<IFolder>
    {
        private List<IFolder> _folders = new List<IFolder>();

        public string FolderName { get; set; }
        public string FolderSize { get; set; }


        public void AddFolder(IFolder folder)
        {
            _folders.Add(folder);
        }

        public void RemoveFolder(IFolder folder)
        {
            _folders.Remove(folder);
        }


        public IEnumerator<IFolder> GetEnumerator()
        {
            foreach(IFolder folder in _folders)
            {
                yield return folder;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void ShowFolderDetails(IFolder folder)
        {
            Console.WriteLine($"- Folder name {folder.FolderName} | Folder size: {folder.FolderSize}");
        }
    }

    public interface IThisPC 
    {
        string OS { get; set; }
        int numberOfPartitions { get; set; }

    }

    public class ThisPC : Folder, IThisPC
    {
        public string OS { get; set; }
        public int numberOfPartitions { get; set; }

       
    }

}
