using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Human humanOne = new Human("Billy", 10, 25, 24, 200);
            Console.WriteLine(humanOne.name);
            Console.WriteLine(humanOne.health);
            Console.WriteLine(humanOne.strength);
            Console.WriteLine(humanOne.intelligence);
            Console.WriteLine(humanOne.dexterity);
            Human humanTwo = new Human("Reggie", 12, 30, 12, 176);
            Console.WriteLine(humanTwo.health);
            humanOne.Attack(humanTwo);
            Console.WriteLine(humanTwo.health);

        }
    }
}
