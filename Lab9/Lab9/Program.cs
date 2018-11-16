using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{

    class User
    {
        public delegate void UserControl(string str);


        public event UserControl Move;
        public event UserControl Compression;

        public string name;
        public int position = 0;
        public double size = 1;

        public User(string name)
        {
            this.name=name;
        }

        public void UserMove(int move)
        {
            position += move;

            if (Move != null)
            {
                Move($"Текущая позиция = {position}");
            }
            else
            {
                Console.WriteLine("Событие не привязано");
            }
        }

        public void UserCompression(double coef)
        {
            size *= coef;

            if (Compression != null)
            {
                Compression($"Текущий размер {coef}");
            }
            else
            {
                Console.WriteLine("Событие не привязано");
            }
        }

        public void info()
        {
            Console.WriteLine($"name: {name}");
            Console.WriteLine($"size: {size}");
            Console.WriteLine($"position: {position}");
            Console.WriteLine("\n");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            User userOne = new User("Vasya Pupkin");
            User userTwo = new User("Ivan Ivanov");
            User userThree = new User("Kanye West");
            User userFour = new User("Johny Cash");

            userOne.Move += Message;

            userTwo.Compression += Message;

            userThree.Move += Message;
            userThree.Compression += Message;

            userOne.UserCompression(0.5);
            userOne.UserMove(3);
            userOne.info();

            userTwo.UserCompression(0.9);
            userTwo.UserMove(5);
            userTwo.info();

            userThree.UserCompression(0.6);
            userThree.UserMove(-3);
            userThree.info();

            userFour.UserCompression(0.3);
            userFour.UserMove(-1);
            userFour.info();


            Action<string> action;
            string str = "A chto tut u nas takoe, a eto StrokA";
            action = ToUpperCase;
            action(str);

            action -= ToUpperCase;
            action += ToLowerCase;
            action(str);

            action -= ToLowerCase;
            action += ReplaceLiter;
            action(str);

            action -= ReplaceLiter;
            action += RemoveStr;
            action(str);

        }

        static public void Message(string message)
        {
            Console.WriteLine(message);
        }

        static public void ToUpperCase(string str)
        {
            str = str.ToUpper();
            Console.WriteLine(str);
        }

        static public void ToLowerCase(string str)
        {
            str = str.ToLower();
            Console.WriteLine(str);
        }

        static public void ReplaceLiter(string str)
        {
            str = str.Replace(',', ' ');
            Console.WriteLine(str);
        }

        static public void RemoveStr(string str)
        {
            str = str.Remove(7);
            Console.WriteLine(str);
        }
    }
    
}
