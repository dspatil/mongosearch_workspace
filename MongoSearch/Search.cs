using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace MongoSearch
{
    public class Search
    {
        public static void AddEmployee()
        {
            var collection = MongoConfig.GetCollection<Employee>("Employee");

            var list = GetEmployeeList();

            foreach (var employee in list)
            {
                collection.Insert(employee);
            }
        }

        private static List<Employee> GetEmployeeList()
        {
            return new List<Employee>() { new Employee() { Name = "Deepak", Team = new Team() { Name = "clts" }, Address = "Kop" }, new Employee() { Name = "Ajit", Team = new Team() { Name = "rovia" }, Address = "Pune" }, new Employee() { Name = "Sameer", Team = new Team() { Name = "ims" }, Address = "Mumbai" } };
        }


        public static void GetEmployee()
        {
            var emplst1 = new List<Employee>();
            var emplst2 = new List<Employee>();
            var emplst3 = new List<Employee>();
            var collection = MongoConfig.GetCollection<Employee>("Employee");

            var query1 = Query.Text("deepak");
            var employeeResult1 = collection.Find(query1);
            foreach (var employee in employeeResult1)
            {
                emplst1.Add(employee);
            }

            var query2 = Query.EQ("Team.Name", "clts");
            var employeeResult2 = collection.Find(query2);
            foreach (var employee in employeeResult2)
            {
                emplst2.Add(employee);
            }

            var query = collection.Find(
                Query.Or(
                    Query.EQ("Name", "deepak"),
                    Query.EQ("Team.Name", "clts")
                    ));

            foreach (var employee in query)
            {
                emplst3.Add(employee);
            }

            var query4 = Query.ElemMatch("Employee", Query.EQ("Team.Name", "clts"));
            var employeeResult4 = collection.Find(query4);
            foreach (var employee in employeeResult4)
            {
                emplst3.Add(employee);
            }

            var query5 = Query.ElemMatch("Team", Query.EQ("Name", "clts"));
            var employeeResult5 = collection.Find(query5);
            foreach (var employee in employeeResult5)
            {
                emplst3.Add(employee);
            }
        }
    }
}
