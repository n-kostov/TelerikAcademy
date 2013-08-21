using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MongoDictionary
{
    class DictionaryEntry
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Word { get; set; }
        public string Translation { get; set; }

        [BsonConstructor]
        public DictionaryEntry(string word, string translation)
        {
            this.Word = word;
            this.Translation = translation;
        }

        public override string ToString()
        {
            return "Dictionary entry: " + this.Word + " => " + this.Translation;
        }
    }

    class LocalMongoDictionary
    {
        public static void AddEntry(string word, string translation, MongoCollection collection)
        {
            DictionaryEntry entry = new DictionaryEntry(word, translation);
            collection.Insert(entry);
        }

        public static List<DictionaryEntry> ListEntries(MongoCollection collection)
        {
            var entries = collection.FindAllAs<DictionaryEntry>().ToList();

            return entries;
        }

        public static string FindTranslation(string word, MongoCollection collection)
        {
            var query = Query.EQ("Word", word);
            DictionaryEntry entry = collection.FindAs<DictionaryEntry>(query).First();
            return entry.Translation;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var mongoClient = new MongoClient("mongodb://localhost/");
            var mongoServer = mongoClient.GetServer();
            var dictionaryDb = mongoServer.GetDatabase("dictionaryDB");
            var dictionaryEntries = dictionaryDb.GetCollection("entries");

            //LocalMongoDictionary.AddEntry("fish", "riba", dictionaryEntries);

            var entries = LocalMongoDictionary.ListEntries(dictionaryEntries);

            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }

            Console.WriteLine(LocalMongoDictionary.FindTranslation("fish", dictionaryEntries));
        }
    }
}
