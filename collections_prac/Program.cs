using System;
using System.Collections.Generic;

namespace collections_prac
{
    class Program
    {
        static void Main(string[] args)
        {
        int[] basic1 = new int[10] {0,1,2,3,4,5,6,7,8,9};
        Console.WriteLine(basic1[3]); //for testing
        Console.WriteLine(basic1[8]); //for testing
        
        string[] basic2 = new string[4] {"Tim", "Martin", "Nikki", "Sara"};
        foreach (string name in basic2) //for testing
        {
            Console.WriteLine("My name is {0}", name);
        }

        bool[] basic3 = new bool[10] {true, false, true, false, true, false, true, false, true, false};
        Console.WriteLine(basic3[0]); //for testing
        Console.WriteLine(basic3[1]); //for testing
        // another option without feeding in boolean values
        bool[] basic3option = new bool[10];
        for (int idx = 0; idx < basic3option.Length; idx++){
            if (idx % 2 == 0){
                basic3option[idx] = true;
            }
        }
        Console.WriteLine(basic3option[0]);
        Console.WriteLine(basic3option[1]);
        
        int[,] multTable = new int[10,10];
        for (int horizVal = 0; horizVal < 10; horizVal++){
           for (int vertVal = 0; vertVal < 10; vertVal++){
               multTable[horizVal, vertVal] = (horizVal + 1) * (vertVal + 1);
           }
        }
        for (int horizVal = 0; horizVal < 10; horizVal++){
            string display = "[ ";
            for (int vertVal = 0; vertVal < 10; vertVal++){
                display += multTable[horizVal, vertVal] + ", ";
                if (multTable[horizVal,vertVal] < 10){
                    display += " ";
                }
            }
            display += "]";
            Console.WriteLine(display);
        }

        List<string> iceCream = new List<string>();
        iceCream.Add("Roasted Banana");
        iceCream.Add("Fresh Mint");
        iceCream.Add("Strawberry Balsamic");
        iceCream.Add("Lavender");
        iceCream.Add("Pine");
        Console.WriteLine(iceCream.Count);
        for (int idx = 0; idx < iceCream.Count; idx++){
            Console.WriteLine(iceCream[idx]);
        }
        iceCream.RemoveAt(3);
        Console.WriteLine(iceCream.Count);

        Dictionary<string,string> iceCreamPairs = new Dictionary<string,string>();
        Random rand = new Random();
        foreach (string name in basic2){
            iceCreamPairs[name] = iceCream[rand.Next(iceCream.Count)];
        }
        foreach (var entry in iceCreamPairs){
                Console.WriteLine(entry.Key + "-" + entry.Value);
            }
        // iceCreamPairs.Add("Tim", iceCream[rand.Next(iceCream.Count)]);
        // iceCreamPairs.Add("Martin", iceCream[rand.Next(iceCream.Count)]);
        // iceCreamPairs.Add("Nikki", iceCream[rand.Next(iceCream.Count)]);
        // iceCreamPairs.Add("Sara", iceCream[rand.Next(iceCream.Count)]);
        }
           
    }
}
