using System;
using System.Collections.Generic;
using AutoMapper;
using CSharp.MongoDB.DTO;
using CSharp.MongoDB.Models;
using MongoDB.Driver;
namespace CSharp.MongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("school");

            var peopleDB = database.GetCollection<People>("people");

            var people = new People()
            {
                Id = "6089d0ab6c3db54c32838b99",
                Edad = 30,
                Nombre = "oscar cortez villca"
            };

            // peopleDB.InsertOne(people);

            List<People> lstPeople = peopleDB.Find(d => true).ToList();
            lstPeople.ForEach(person =>
            {
                Console.WriteLine($"id: {person.Id}, Nombre: {person.Nombre} Edad: {person.Edad}");
            });

            //peopleDB.ReplaceOne(
            //    d => d.Id == "6089d0ab6c3db54c32838b99",
            //    people
            //);

            //peopleDB.DeleteOne(d => d.Id == "6089d0ab6c3db54c32838b99");

            var PeopleConfig = new MapperConfiguration(cfg =>
                cfg.CreateMap<People, PeopleDTO>()
            );

            Mapper mapper = new Mapper(PeopleConfig);
            //var peopleDTO = mapper.Map<PeopleDTO>(people);

            var peopleDTO2 = mapper.Map<People, PeopleDTO>(people);

            Console.WriteLine($"nombre: {peopleDTO2.Nombre}, edad: {peopleDTO2.Edad}, id: {peopleDTO2.Id}");
        }
    }
}
