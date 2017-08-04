using System;
using System.Collections.Generic;

namespace basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] arr =  new int[4] {1,3,5,7};
            object[] arrString = new object[4] {-5,6,7,-9};
            // findMax(arr);
            // sqarArr(arr);
            // findAvg(arr);
            // greaterY(arr);
            // minMaxAvg(arr);
            // shiftArr(arr);
            // negStr(arrString);

            //print 1-255
            // for (int i = 1; i < 256; i++){
            //     Console.WriteLine(i);
            // }
            //print odd number between 1-255
            // for (int i = 1; i < 256; i++){
            //     if (i % 2 == 1){
            //         Console.WriteLine(i);
            //     }
            //print sum
            // int sum = 0;
            // for (int i = 0; i < 256; i++){
            //     sum += i;
            //     Console.WriteLine($"The number is {i} and the sum is {sum}");
            // }
            //iterating through an array
            // int[] x = new int[6] {1,3,5,7,9,13};
            // for (int i = 0; i < x.Length; i++){
            //     Console.WriteLine(x[i]);
            // }
            //make odd numbers in an array
            // List<int> y = new List<int>();
            // for (int i = 1; i < 256; i++){
            //     if (i % 2 == 1){
            //         y.Add(i);
            //         Console.WriteLine(i);
            //     }
            //     return y.ToArray();
            // }
            //arrays cannot have negatives //testing
            // int[] noNeg = int[4] {1,5,10,-2};
            // for (int i = 0; i < noNeg.Length; i++){
            //     if (arr[i] < 0){
            //         arr[i] = 0;
            //         Console.WriteLine(arr[i]);
            //     }
            // }
            
            
        }
        //find avg
        // static void findAvg(int[] arr){
        //     int avg = 0;
        //     for (int i = 0; i < arr.Length; i++){
        //         avg = arr[i] + avg;
        //     }
        //     Console.WriteLine(avg/arr.Length);
        // }
        //
        //find max
        // static void findMax(int[] arr){
        //     int max = arr[0];
        //     for (int i = 1; i < arr.Length; i++){
        //         if (arr[i] > max){
        //             max = arr[i];
        //         }
        //     }
        //     Console.WriteLine(max);
        // }
        //square array
        // static void sqarArr(int[] arr){
        //     for (int i = 0; i < arr.Length; i++){
        //         arr[i] = arr[i] * arr[i];
        //         Console.WriteLine($"The square is {arr[i]}");
        //     }
        // }
        //greater than Y
        // static void greaterY(int[] arr){
        //     int y = 3;
        //     int count = 0;
        //     for (int i = 0; i < arr.Length; i++){
        //         if (arr[i] > y){
        //             count++;
        //         }
        //     }
        //     Console.WriteLine(count);
        // }
        //min, max, avg in array
        // static void minMaxAvg(int[] arr){
        //     int min = arr[0];
        //     int max = arr[0];
        //     int avg = arr[0];
        //     for (int i = 1; i < arr.Length; i++){
        //         if (arr[i] > max){
        //             max = arr[i];
        //         } else if (arr[i] < min){
        //             min = arr[i];
        //         }
        //         avg = arr[i] + avg;
        //     }
        //     Console.WriteLine($"the average is {avg/arr.Length}");
        //     Console.WriteLine($"the max is {max}");
        //     Console.WriteLine($"the min is {min}");
        // }
        //shift array by one to the right add 0 to end
        // static void shiftArr(int[] arr){
        //     for (int i = 0; i < arr.Length - 1; i++){
        //         arr[i] = arr[i + 1];
        //         Console.WriteLine(arr[i]);
        //     }
        //     arr[arr.Length - 1] = 0;
        //     Console.WriteLine(arr[arr.Length - 1]);
        // }
        //negative to string
        // static void negStr(object[] arrString){
        //     for (int i = 0; i < arrString.Length; i++){
        //         if ((int)arrString[i] < 0){
        //             arrString[i] = "Dojo";
        //             Console.WriteLine(arrString[i]);
        //         }
        //     }
        // }

    }
}
