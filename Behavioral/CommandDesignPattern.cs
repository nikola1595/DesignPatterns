using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDesignPattern
{
    /*
     * Encapsulate a request as an object, thereby letting you parameterize clients with different requests,
     * queue or log requests, and supports operations which effect can be canceled. 
     * */
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Taking up remote controller... ");
            Console.WriteLine("Options [ON/OFF]");
            string command;
            while(true)
            {
                command = Console.ReadLine();

                AirConditioner ac = new AirConditioner();
                ICommand turnOn = new TurnOnCommand(ac);
                ICommand turnOff = new TurnOffCommand(ac);

                RemoteController remote = new RemoteController();

                switch (command)
                {
                    case "ON":
                        remote.ExecuteCommand(turnOn);
                        break;
                    case "OFF":
                        remote.ExecuteCommand(turnOff);
                        break;
                    default:
                        Console.WriteLine("Please enter ON or OFF commands");
                        break;
                }
                
            }

        }
    }


    public interface ICommand
    {
        void ExecuteCommand();
    }



    public class RemoteController
    {
        private List<ICommand> _commands = new List<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            _commands.Add(command);
            command.ExecuteCommand();
        }
    }

    public class AirConditioner
    {
        public void TurnOn()
        {
            Console.WriteLine("Air conditioner is turned ON");
        }

        public void TurnOff()
        {
            Console.WriteLine("Air conditioner is turned OFF");
        }


    }

    public class TurnOnCommand : ICommand
    {
        private AirConditioner _ac;

        public TurnOnCommand(AirConditioner ac)
        {
            _ac = ac;
        }
        public void ExecuteCommand()
        {
            _ac.TurnOn();
        }


    }


    public class TurnOffCommand : ICommand
    {
        private AirConditioner _ac;

        public TurnOffCommand(AirConditioner ac)
        {
            _ac = ac;
        }


        public void ExecuteCommand()
        {
            _ac.TurnOff();
        }
    }
}
