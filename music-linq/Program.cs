using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist FromMtVernon = Artists.Where(artists => artists.Hometown == "Mount Vernon").Single();
            System.Console.WriteLine($"The artist {FromMtVernon.ArtistName} from Mt Vernon is {FromMtVernon.Age} years old.");
            System.Console.WriteLine(FromMtVernon);
            //Who is the youngest artist in our collection of artists?
            Artist Youngest = Artists.OrderBy(artists => artists.Age).First();
            System.Console.WriteLine($"The artist {Youngest.ArtistName} is {Youngest.Age} years old.");
            //Display all artists with 'William' somewhere in their real name
            List<Artist> Williams = Artists.Where(artist => artist.RealName.Contains("Williams")).ToList();
            System.Console.WriteLine("The Williams are:");
            foreach (var artist in Williams){
                Console.WriteLine($"{artist.ArtistName} - {artist.RealName}");
            }
            //Display all groups with less than eight characters
            List<Group> Eight = Groups.Where(group => group.GroupName.Length < 8).ToList();
            foreach (var group in Eight){
                Console.WriteLine($"The Groups are: {group.GroupName}");
            }
            //Display the 3 oldest artist from Atlanta
            List<Artist> Old = Artists.Where(artist => artist.Hometown == "Atlanta").OrderByDescending(artist => artist.Age).Take(3).ToList();
            foreach (var artist in Old){
                Console.WriteLine($"The Old are: {artist.ArtistName} - {artist.Age}");
            }
            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            List<Artist> WU = Artists.Where(artist => artist.GroupId == 1).ToList();
            foreach (var artist in WU){
                Console.WriteLine($"The WU are: {artist.ArtistName}");
            }
            // List<Group> WU = Groups.Where(group => group.GroupName == "Wu-Tang Clan").ToList();
            // foreach(var name in WU){
            //     Console.WriteLine($"I am a WU {name.Members}");
            // }
            // List<Artist> BEE = Artists.Select(artist => artist.GroupId == WU.Id).ToList();
        }
    }
}
