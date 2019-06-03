using System;
using System.Collections.Generic;
using System.Text;

namespace name_sorter
{
    public class Sorter
    {
        // List of sorted names
        List<Name> sortedList;

        // Output file path
        // Change as required
        private readonly string outputFile = "../sorted-names-list.txt";

        /*
         * Constructor
         * Receives string filename as argument-input
         * Retrieves names from file, then sorts it
         */
        public Sorter(string filename)
        {
            try
            {
                List<Name> unsortedNames = FileManager.readFile(filename);
                SortList(unsortedNames);
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /*
         * Sorts the list of names given as argument-input
         * Uses SortedList to sort list alphabetically
         * GetSortName is a reordered string derived from the initial name
         * Assigns sorted list to sortedList variable
         */
        public void SortList(List<Name> unsorted)
        {
            // Initialises SortedList; SortedList automatically sorts by the Key value (the name in this case)
            SortedList<string, Name> names = new SortedList<string, Name>();

            // Adds all unsorted names to the SortedList 'names'
            foreach (Name n in unsorted)
            {
                names.Add(n.GetSortName(), n);
            }

            sortedList = new List<Name>();

            // Uses for-each loop to reassign sorted values to List for easier printing
            foreach (KeyValuePair<string, Name> name in names)
            {
                sortedList.Add(name.Value);
            }
        }
        /*
         * Prints sorted list names to console and output file
         * Uses the hard-coded output filepath 'outputFile'
         */
        public void PrintNames()
        {
            // For-Each loops through the list to 
            foreach (Name n in sortedList)
            {
                Console.WriteLine(n.GetName());
            }
            // Uses FileManager to write sortedList to output file
            FileManager.writeNames(sortedList,outputFile);
        }

    }
}
