using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace name_sorter
{
    public class FileManager
    {
        /*
         * Reads the file from the filename received as argument-input
         * Formats the content into a List of Names 
         * Returns the List for sorting
         */
        public static List<Name> readFile(string filename)
        {
            //List for names to be added to
            List<Name> names = new List<Name>();

            /*
             * We try and read the file from the filepath given
             * A for-each loop is used to split each line into single names
             */
            try
            {
                // The content of the file is returned as a string array
                string[] lines = File.ReadAllLines(filename);

                // We loop through each line so the names can be formatted
                foreach (string s in lines)
                {
                    // We split each line by the ' ' character so we have a string array with each name
                    string[] seg_names = s.Split(' ');

                    /* The string array of indivdiual names is used to initialise a new Name object
                     * and add it to the list
                     */
                    names.Add(new Name(seg_names));
                }
                
            } catch(FileNotFoundException fe )
            {
                // FileNotFoundExceptions are recognised and defined for easy error identificaiton
                Console.WriteLine("File Not Found \n" + fe.StackTrace);

            } catch(Exception e)
            {
                // All other Exceptions are output as strings
                Console.WriteLine(e.ToString());
            }
            return names;
        }

        /*
         * Writes the sorted list to the output file
         */
        public static void writeNames(List<Name> names, string filename)
        {
            /*
             * try-catch used to catch any possible exceptions
             */
            try
            {
                // Checks if the file already exists, and deletes if found
                if (File.Exists(filename))
                {
                    File.Delete(filename);

                }

                // Initialises the StreamWriter to write to the file
                using (StreamWriter tofile = File.CreateText(filename))
                {
                    /*
                     * for-each Name, the re-formed full name is retrieved and written to the file
                     */
                    foreach (Name n in names)
                    {
                        tofile.WriteLine(n.GetName());
                    }

                    // Closes the StreamWriter
                    tofile.Close();
                }

            }
            catch (Exception e)
            {
                // Outputs the Exception string
                Console.WriteLine(e.ToString());
            }

        }

    }
}
