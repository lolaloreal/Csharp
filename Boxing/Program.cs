using System;
using System.Collections.Generic;

namespace Boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

        List<object> box = new List<object>();
        box.Add(7);
        box.Add(28);
        box.Add(-1);
        box.Add(true);
        box.Add("chair");
        foreach (object item in box){
            Console.WriteLine(item);
            }
        int sum = 0;
        foreach (var item in box){
            if (item is int){
                sum += (int)item;       
            }  
        }
        Console.WriteLine(sum); 
    }
}
}
