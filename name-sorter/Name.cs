using System;
using System.Collections.Generic;
using System.Text;

namespace name_sorter
{
    public class Name
    {
        // array of names that make up the full name
        private string[] names; 

        // sortName is the re-ordered names within the full name for easier sorting
        private string sortName; 

        /*
         * Constructor
         * Receives array of names as argument-input
         * Finds and assigns the sortName
         */
        public Name(string[] _names)
        {
            names = _names;
            sortName = CalcSortName();
        }

        /*
         * Formulates the sortName for the full name
         * Re-orders the names in the following order of sorting:
         * Last Name, First Name, Middle Names
         * This can then be alphabetically ordered as required
         * Returns the sortName
         */
        private string CalcSortName()
        {
            string returnName = "";

            // Adds the Last name
            returnName += names[names.Length - 1];

            // Adds the First name
            returnName += names[0];

            // Loops through any present middle names and assigns them as well
            // Doesn't run if no middle names, as i = 1 and names.Length -1 = 1
            for (int i = 1; i < names.Length - 1; i++)
            {
                returnName += names[i];
            }

            return returnName;
        }


        /*
         * Returns the re-formed name from the string array
         */
        public string GetName()
        {
            string actualName = "";

            foreach (string s in names)
            {
                actualName += s + " ";
            }

            return actualName;
        }

        /*
         * Returns the sortName
         */
        public string GetSortName()
        {
            return sortName;
        }
    }
}
