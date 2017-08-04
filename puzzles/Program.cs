using System;
using System.Linq;

namespace puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RandomArray();
            TossCoin();
            // TossMultipleCoins(10);
        }

        static void RandomArray(){ //void can be changed to what will be returned (int, string, etc.)
            int[] myArray = new int[10];
            Console.WriteLine(myArray);
            Random randObj = new Random();
            for (int i = 0; i < myArray.Length; i++){
                myArray[i] = randObj.Next(5,26);
            }
            System.Console.WriteLine(myArray[0]);
            System.Console.WriteLine(myArray[5]);
            // System.Console.WriteLine(myArray.Max());
            // System.Console.WriteLine(myArray.Min());
            // System.Console.WriteLine(myArray.Sum());
        }

        static string TossCoin(Random randObj){
            Random randObj = new Random();
            int coinToss = randObj.Next(0,2);
            string result = "Tails";
            if (coinToss == 0){
                System.Console.WriteLine("Heads");
            } else {
                System.Console.WriteLine("Tails");
                result = "Tails";
            }
            return result;
            }
        }

        // static Double TossMultipleCoins(int Num){
        //     int CountHeads = 0;
        //     Random r = new Random();
        //     for (int i = 0; i < Num; i++){
        //         if(TossCoin(r) == "Heads"){
        //             CountHeads++;
        //         }
        //     }
        //     System.Console.WriteLine(CountHeads);
        //     return (Double)CountHeads/Num;
        // }

        // static string[] Names(){

        // }


    
}
