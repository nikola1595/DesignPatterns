using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorDesignPattern
{
    /*
     * Represents tool for sequentially accessing
     * elements of an aggregate object without 
     * exposing its underlying representation.   
     */
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteCollection collection = new ConcreteCollection();

            collection.AddStudent(new Student("H123T", "John Doe", "Kansas"));
            collection.AddStudent(new Student("H1213", "Marc Stevenson", "L.A."));
            collection.AddStudent(new Student("H5632", "Ana Marie", "San Francisco"));
            collection.AddStudent(new Student("H12387", "Suzane Thompson", "Houston"));
            collection.AddStudent(new Student("HG213", "Tommy Peterson", "N.Y."));

            Iterator iterator = collection.CreateIterator();

            Console.WriteLine("Iterating over collection of students: \n");

            
            for(Student stud = iterator.First(); !iterator.IsCompleted; stud = iterator.Next())
            {
                Console.WriteLine($"Index number: {stud.IndexNum} | Student name: {stud.StudentName} | City: {stud.City} ");
            }

            Console.ReadKey();
        }
    }


    public class Student
    {
        public string IndexNum { get; set; }
        public string StudentName { get; set; }
        public string City { get; set; }


        public Student(string index, string name, string city)
        {
            IndexNum = index;
            StudentName = name;
            City = city;
        }
    }


    public interface AbstractIterator
    {
        Student First();
        Student Next();
        bool IsCompleted { get; }
    }

    public interface IAbstractCollection
    {
        Iterator CreateIterator();
    }


    public class ConcreteCollection : IAbstractCollection
    {
        private List<Student> studentList = new List<Student>();

        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }

        public int Count
        {
            get { return studentList.Count; }
        }

        public void AddStudent(Student student)
        {
            studentList.Add(student);
        }

        public Student GetStudent(int index)
        {
            return studentList[index];
        }
    }

    public class Iterator : AbstractIterator
    {

        private ConcreteCollection _collection;
        private int current = 0;
        private int step = 1;

        public Iterator(ConcreteCollection collection)
        {
            _collection = collection;
        }

        public bool IsCompleted
        {
            get { return current >= _collection.Count; }
        }

        public Student First()
        {
            current = 0;
            return _collection.GetStudent(current);
        }

        public Student Next()
        {
            current += step;
            if(IsCompleted == false)
            {
                return _collection.GetStudent(current);
            }
            else
            {
                return null;
            }
        }
    }
}
