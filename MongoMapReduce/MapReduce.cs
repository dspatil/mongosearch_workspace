using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace MongoMapReduce
{
    public class MapReduce
    {
        public static void Insert()
        {
            PopulateData();
        }

        private static void PopulateData()
        {
            var collection = MongoConfig.GetCollection<Profile>("Profile");
            collection.Insert(GetProfile(4));
        }

        private static Profile GetProfile(int i)
        {
            var profile = new Profile()
            {
                _id = i.ToString(),
                Address = new AddressSection() { Addresses = new List<Address>() { new Address() { AddressLine1 = "NY1", AddressLine2 = "NY2", City = "NewYork", Country = "Us", State = "Michigan", Zip = "416500" } } },
                Affiliation = new AffiliationSection() { Affiliations = new List<Affiliation>() { new Affiliation() { AffiliatedBy = "Tavisca", Name = "Af1", Type = "Af", Value = "Af122121" } } },
                StatusMessage = new StatusMessageSection() { StatusText = "Welcome F4 User" },
                Contact = new ContactSection() { Contacts = new List<Contact>() { new Contact() { AreaCode = "04444", CountryCode = "91", IsDefault = true, Value = "444444" } } },
                Membership = new MembershipSection() { Memberships = new List<Membership>() { new Membership() { Category = "Activity", Code = "AV12", EndDate = DateTime.UtcNow.AddMonths(2), PreferenceOrder = 1, ProviderName = "EMIRITES", ProviderCode = "Emi", Type = "Business" } } },
                Media = new MediaSection() { MediaItems = new List<MediaItem>() { new MediaItem() { Type = "Image", Url = "cdn.tavisca.com/Img02.jpg" } } },
                FormOfPayment = new FormOfPaymentSection() { Payments = new List<FormOfPayment>() { new FormOfPayment() { Type = "BankAccount", AccountNumber = "0539112200", BankName = "HDfc", BranchCode = "0539", BranchName = "Kalyaninagar1" } } },
                AdditionalData = new List<KeyValueState>() { new KeyValueState() { Key = "key44", Value = "value44" }, new KeyValueState() { Key = "key43", Value = "value43" } }

            };

            return profile;
        }


        public static void AddMovies()
        {
            var collection = MongoConfig.GetCollection<Movie>("Movie");
            var movies = new List<Movie>()
            {
                new Movie
                {
                    Title = "The Perfect Developer",
                    Category = "SciFi",
                    Minutes = 118
                },
                new Movie
                {
                    Title = "Lost In Frankfurt am Main",
                    Category = "Horror",
                    Minutes = 122
                },
                new Movie
                {
                    Title = "The Infinite Standup",
                    Category = "Horror",
                    Minutes = 341
                }
            };
            collection.InsertBatch(movies);
        }

        public static void GetMovies()
        {

            string map = @"function() 
                                    {   var movie = this;
                                        emit(movie.Category, { count: 1, totalMinutes: movie.Minutes });
                                    }";
            string reduce = @"function(key, values)
                                    {
                                        var result = {count: 0, totalMinutes: 0 };
                                        values.forEach(function(value)
                                           {               
                                            result.count += value.count;
                                            result.totalMinutes += value.totalMinutes;
                                            });

                                            return result;
                                     }";

            string finalize = @"function(key, value)
                                {
                                  value.average = value.totalMinutes / value.count;
                                  return value;
                                }";


            var collection = MongoConfig.GetCollection<Movie>("Movie");
            var options = new MapReduceOptionsBuilder();
            options.SetFinalize(finalize);
            options.SetOutput(MapReduceOutput.Inline);
            var results = collection.MapReduce(map, reduce, options);

            foreach (var result in results.GetResults())
            {
                Console.WriteLine(result.ToJson());
            }
        }

        public static void GetProfile()
        {
            var query = Query.EQ("_id", "3");
            var collection = MongoConfig.GetCollection<Profile>("Profile");
            var userProfile = collection.FindOne(query);
        }

    }
}
