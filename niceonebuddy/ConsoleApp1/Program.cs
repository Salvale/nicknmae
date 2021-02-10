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
            //initialize default nickname list
            public static List<string> nicks = new List<string> {"Snake","Ocelot","Raven","Wolf","Octopus","Mantis"};
        }
        
        static void Main()
        {
            //Gets first and last names
            Console.WriteLine("Enter your first name:");
            string Name1 = Console.ReadLine();
            Console.WriteLine("Enter your last name:");
            string Name2 = Console.ReadLine();
            Console.Clear();
            Draw(Name1, Name2);
        }
        static void Draw(string Name1, string Name2)
        {
            //write all relevant info, automatically begin with a random nickname
            Console.WriteLine("Hello, " + Name1 + " '" + Randy() + "' " + Name2);
            Console.WriteLine("Enter an input to try a command.");
            Console.WriteLine("1: Change Name");
            Console.WriteLine("2: New Random Nickname");
            Console.WriteLine("3: Display all available nicknames");
            Console.WriteLine("4: Add a possible nickname");
            Console.WriteLine("5: Remove a nickname");
            Console.WriteLine("6. Close");
            //get and scan command
            int Input = Convert.ToInt32(Console.ReadLine());
            if (Input == 1)
            {
                //re-run main to get first and last name all over again
                Main();
            } else if (Input == 2)
            {
                //restart the current function for a new random nickname
                Console.Clear();
                Randy();
                Draw(Name1, Name2);
            } else if (Input == 3)
            {
                //Clear console and write all available nicknames
                Console.Clear();
                showAll();
                Draw(Name1, Name2);
            } else if (Input == 4)
            {
                //get input and add to the list of possible nicknames
                Console.Write("What nickname would you like to add? ");
                global.nicks.Add(Console.ReadLine());
                Console.Clear();
                Draw(Name1, Name2);
            } else if (Input == 5)
            {
                //prevent all values from being removed
                if (global.nicks.Count == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Can't remove any more, there's only one left!");
                    Draw(Name1, Name2);
                }
                else
                {
                   //get input for list item to remove
                    Console.WriteLine("Which one would you like to remove?");
                    string removed = Console.ReadLine();
                    //Check if input is valid
                    if (global.nicks.Contains(removed))
                    {
                        //valid
                        global.nicks.Remove(removed);
                        Console.Clear();
                        Console.WriteLine(removed + " removed!");
                    }
                    else
                    {
                        //invalid
                        Console.Clear();
                        Console.WriteLine(removed + " not found!");
                    }
                Draw(Name1, Name2);
                } 
            } else if (Input == 6)
            {
                //kill the program
                System.Environment.Exit(0);
            } else
            {
                //failsafe for invalid command
                Console.WriteLine("not a valid prompt");
            }
        }
        static string Randy()
        {
            //get random list item
            System.Random random = new System.Random();
            int rand = random.Next(global.nicks.Count);
            return global.nicks[rand];
        }
        static void showAll()
        {
            //Put all the list items together into a string
                string allNicks = String.Join(", ", global.nicks);
                Console.WriteLine("The list of all nicknames is " + allNicks);
        }
    }
}
