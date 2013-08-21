using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using StudentSystem.Model;
using StudentSystem.DataLayer;
using StudentSystem.ServiceLayer.Models;
using StudentSystem.RepositoryLayer;

namespace StudentSystem.ServiceLayer.Controllers
{
    public class SchoolsController : ApiController
    {
        private readonly IRepository<School> studentsRepository;

        public SchoolsController(IRepository<School> studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }

        // GET api/students
        public IEnumerable<SchoolModel> Get()
        {
            var schools = studentsRepository.All().Select(SchoolModel.FromSchool);
            return schools.ToList();
        }

        // GET api/students/5
        public SchoolModel Get(int id)
        {
            var schools = studentsRepository.All();
            var student = schools.Where(x => x.SchoolId == id).Select(SchoolModel.FromSchool).FirstOrDefault();
            return student;
        }

        // POST api/students
        public void Post([FromBody]SchoolModel value)
        {
            School school = new School()
            {
                Name = value.Name,
                Location = value.Location,
                Students = value.Students.Select(x => new Student
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    Grade = x.Grade,
                    Marks = x.Marks
                }).ToList(),
            };

            studentsRepository.Add(school);
        }
    }
}