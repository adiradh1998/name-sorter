using NUnit.Framework;
using System;
using name_sorter;
using System.Collections.Generic;

namespace Tests
{

    [TestFixture]
    public class Tests
    {

        Name _name;
        Sorter _sorter;


        List<Name> testList;
        List<Name> sortedTestList;
        string filepath;

        [SetUp]
        public void Setup()
        {
            string[] testName = { "James", "Hamis", "Williams" };
            string[] testName2 = { "Hendrick", "Hamis", "Williams" };
            string[] testName3 = { "James", "Hamis", "Jeffries" };
            string[] testName4 = { "Anne", "Cusies", "Adams" };

            filepath = "C:/Users/adith/source/repos/name-sorter/unsorted-names-list.txt";

            testList = new List<Name>() { new Name(testName), new Name(testName2), new Name(testName3), new Name(testName4) };
            sortedTestList = new List<Name>() { new Name(testName4), new Name(testName3), new Name(testName), new Name(testName2) };
            
        }

        [Test]
        public void ReadFileTest()
        {
            List<Name> result = FileManager.readFile(filepath);
            Assert.That(result, Has.Exactly(11).Items);
        }


        [Test]
        public void SorterTest()
        {
            _sorter = new Sorter(filepath);
            _sorter.PrintNames();
            Assert.Pass();

        }

        [Test]
        public void NameTest()
        {
            string[] testName = { "James", "Hamis", "Williams" };
            _name = new Name(testName);
            Assert.Pass();
        }

        [Test]
        public void SortNameTest()
        {
            string[] testName = { "James", "Hamis", "Williams" };
            Name test = new Name(testName);
            string sortname = _name.GetSortName();
            Assert.That(sortname, Is.EqualTo("WilliamsJamesHamis"));

        }

        [Test]
        public void GetNameTest()
        {
            string[] testName = { "James", "Hamis", "Williams" };
            Name test = new Name(testName);
            string actualName = test.GetName();
            Assert.That(actualName, Is.EqualTo("James Hamis Williams "));

        }

        

        [Test]
        public void WriteFileExceptionTest()
        {
            FileManager.writeNames(sortedTestList, "sorted-names-list.txt");
            Assert.Pass();

        }
    }
}