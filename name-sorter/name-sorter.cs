using System;
using System.Collections.Generic;

namespace name_sorter
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Attempts to find argument from comman line
            try
            {
                // Retrieves argument 
                string filename = args[0];

                // Initialises Sorter class
                Sorter sort = new Sorter(filename);
                // Prints sorted list to console and output file
                sort.PrintNames();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                // If argument not found, uses hard-coded default file path
                Console.WriteLine("Argument not found, attempting default filename");
                // Input filename; change as required
                string filename = "C:/Users/adith/source/repos/name-sorter/unsorted-names-list.txt";
                Sorter sort = new Sorter(filename);
                sort.PrintNames();
                Console.ReadLine();
            }
        }
    }
}
