using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static class global
        {
            public static List<string> nicks = new List<string> {"Snake","Ocelot","Raven","Wolf","Octopus","Mantis"};
        }
        
        static void Main()
        {

            Console.WriteLine("Enter your first name:");
            string Name1 = Console.ReadLine();
            Console.WriteLine("Enter your last name:");
            string Name2 = Console.ReadLine();
            Console.Clear();
            Draw(Name1, Name2);
        }
        static void Draw(string Name1, string Name2)
        {
            Console.WriteLine("Hello, " + Name1 + " '" + Randy() + "' " + Name2);
            Console.WriteLine("Enter an input to try a command.");
            Console.WriteLine("1: Change Name");
            Console.WriteLine("2: New Random Nickname");
            Console.WriteLine("3: Display all available nicknames");
            Console.WriteLine("4: Add a possible nickname");
            Console.WriteLine("5: Remove a nickname");
            Console.WriteLine("6. Close");
            int Input = Convert.ToInt32(Console.ReadLine());
            if (Input == 1)
            {
                Main();
            } else if (Input == 2)
            {
                Console.Clear();
                Randy();
                Draw(Name1, Name2);
            } else if (Input == 3)
            {
                Console.Clear();
                showAll();
                Draw(Name1, Name2);
            } else if (Input == 4)
            {
                Console.Write("What nickname would you like to add? ");
                global.nicks.Add(Console.ReadLine());
                Console.Clear();
                Draw(Name1, Name2);
            } else if (Input == 5)
            {
                if (global.nicks.Count == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Can't remove any more, there's only one left!");
                    Draw(Name1, Name2);
                }
                else
                {
                    
                    Console.WriteLine("Which one would you like to remove?");
                    string removed = Console.ReadLine();
                    if (global.nicks.Contains(removed))
                    {
                        global.nicks.Remove(removed);
                        Console.Clear();
                        Console.WriteLine(removed + " removed!");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(removed + " not found!");
                    }
                Draw(Name1, Name2);
                } 
            } else if (Input == 6)
            {
                System.Environment.Exit(0);
            } else
            {
                Console.WriteLine("not a valid prompt");
            }
        }
        static string Randy()
        {
            System.Random random = new System.Random();
            int rand = random.Next(global.nicks.Count);
            return global.nicks[rand];
        }
        static void showAll()
        {
                string allNicks = String.Join(", ", global.nicks);
                Console.WriteLine("The list of all nicknames is " + allNicks);
        }
    }
}