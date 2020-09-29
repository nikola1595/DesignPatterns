using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesignPattern
{
    class Program
    {
        /*
         * Defines a one-to-many dependency between objects so that when one object changes state,
         * all its dependents are notified and updated automatically. 
         */
        static void Main(string[] args)
        {
            Company Company1 = new Company("Digital Marketing", 50);
            Company1.AttachAttender(new Attender(1));
            Company1.AttachAttender(new Attender(2));
            Company1.AttachAttender(new Attender(3));

            Company1.Time = 45;
            Company1.Time = 25;
            Company1.Time = 15;

            Company1.Time = 0;

            Console.ReadKey();

        }
    }

    public interface IAttender
    {
        void Update(int time);

    }

    public class Attender : IAttender
    {
        private int AttenderID;

        public Attender(int Id)
        {
            AttenderID = Id;
        }



        public void Update(int time)
        {
            Console.WriteLine($"Notification for attender with number {AttenderID}.Presentation begins in {time} minutes");
        }
    }

    public class Presentation
    {
        private string PresentationName;
        private int TimeToPres;
        private List<IAttender> _attenders = new List<IAttender>();

        public Presentation(string presName, int timeToPres)
        {
            PresentationName = presName;
            TimeToPres = timeToPres;
        }

        public void AboutToBegin(string PresentationName)
        {
            Console.WriteLine($"Presentation {PresentationName} is about to begin.");
        }

        public void AttachAttender(IAttender attender)
        {
            _attenders.Add(attender);
        }

        public void DetachAttender(IAttender attender)
        {
            _attenders.Remove(attender);
        }


        public void NotifyAttender()
        {
            foreach (IAttender attender in _attenders)
            {
                attender.Update(TimeToPres);
            }

            Console.WriteLine("");
        }


        public int Time
        {
            get { return TimeToPres; }
            set
            {
                if (TimeToPres != value)
                {
                    TimeToPres = value;
                    NotifyAttender();
                }

                if (TimeToPres == 0)
                {
                    AboutToBegin(PresentationName);
                }

            }
        }

    }



    public class Company : Presentation
    {
        public Company(string presName, int time) : base(presName, time)
        {

        }
    }
}
