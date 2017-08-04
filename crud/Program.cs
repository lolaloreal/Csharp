using System;
using System.Collections.Generic;
using DbConnection;


namespace crud
{
    class Program
    {

        static void Read()
        {
            var people = DbConnector.Query("SELECT * FROM Users");
            foreach (var person in people){
                    System.Console.WriteLine($"{person["first_name"]} {person["last_name"]} | Favorite Number: {person["fav_num"]} | ID: {person["userID"]} ");
                System.Console.WriteLine(" ");
                }
        }
        static void Create(string fname, string lname, int fav_num)
        {
            string f = fname;
            string l = lname;
            int fnum = fav_num;
            DbConnector.Execute($"INSERT INTO Users (first_name, last_name, fav_num) VALUES ('{f}', '{l}', '{fnum}')");
          
        }
        static void Update(string fname, string lname, int fav_num)
        {
            string f = fname;
            string l = lname;
            int fnum = fav_num;
            DbConnector.Execute($"UPDATE Users SET first_name = '{f}' last_name = '{l}' fav_num = '{fnum}' WHERE ");
            
        }
        static void Main(string[] args)
        {
            Read();
            System.Console.WriteLine("Please Enter First Name:");
            string fname = Console.ReadLine();
            System.Console.WriteLine("Please Enter Last Name:");
            string lname = Console.ReadLine();
            System.Console.WriteLine("Please Enter Favorite Number:");
            int fav_num = Int32.Parse(Console.ReadLine());
            Create(fname, lname, fav_num);
            Read();
            
        }
      

    }
}
