using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoMapReduce;
using MongoSearch;

namespace MapReduce.UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void InsertProfile()
        {
            MongoMapReduce.MapReduce.Insert();
        }

        [TestMethod]
        public void GetProfile()
        {
            MongoMapReduce.MapReduce.GetProfile();
        }

        [TestMethod]
        public void AddMovies()
        {
            MongoMapReduce.MapReduce.AddMovies();
        }

        [TestMethod]
        public void GetMovies()
        {
            MongoMapReduce.MapReduce.GetMovies();
        }

        [TestMethod]
        public void AddEmployee()
        {
            Search.AddEmployee();
        }

        [TestMethod]
        public void GetEmployee()
        {
            Search.GetEmployee();
        }

        [TestMethod]
        public void GetProfiles()
        {
            MongoMapReduce.Manager.FindProfiles(new List<ProfileSearchAttributes>() { new ProfileSearchAttributes() { Name = "Country", Value = "Us" } });
        }

    }
}
