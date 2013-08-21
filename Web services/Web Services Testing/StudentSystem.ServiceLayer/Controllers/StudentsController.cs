using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentSystem.RepositoryLayer;
using StudentSystem.Model;
using StudentSystem.ServiceLayer.Models;

namespace StudentSystem.ServiceLayer.Controllers
{
    public class StudentsController : ApiController
    {
        private readonly IRepository<Student> studentsRepository;

        public StudentsController(IRepository<Student> studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }

        // GET api/students
        public IEnumerable<StudentModel> Get()
        {
            var studentEntities = studentsRepository.All().Select(StudentModel.FromStudent);
            return studentEntities.ToList();
        }

        // GET api/students/5
        public StudentModel Get(int id)
        {
            var student = studentsRepository.Get(id);
            return new StudentModel
            {
                FirstName = student.FirstName,
                Age = student.Age,
                Grade = student.Grade,
                LastName = student.LastName,
                Marks = student.Marks,
                StudentId = student.StudentId,
                School = student.School == null ? null : new SchoolModel
                {
                    Name = student.School.Name,
                    SchoolId = student.School.SchoolId,
                    Location = student.School.Location
                }
            };
        }

        public IEnumerable<StudentModel> GetStudentsInGivenSubjectAndMark(string subject, double value)
        {
            var students = studentsRepository.All().Select(StudentModel.FromStudent);
            return students.Where(x => x.Marks.Any(y => y.Subject == subject && y.Value >= value)).ToList();
        }

        // POST api/students
        public HttpResponseMessage Post([FromBody]StudentModel value)
        {
            Student student = new Student()
            {
                FirstName = value.FirstName,
                LastName = value.LastName,
                Age = value.Age,
                Grade = value.Grade,
                Marks = value.Marks,
                SchoolId = value.SchoolId
            };

            if (value.School != null)
            {
                student.School = new School
                {
                    Name = value.School.Name,
                    Location = value.School.Location
                };
            }

            var createdStudent = studentsRepository.Add(student);

            var studentModel = new StudentModel()
            {
                FirstName = createdStudent.FirstName,
                Age = createdStudent.Age,
                Grade = createdStudent.Age,
                LastName = createdStudent.LastName,
                Marks = createdStudent.Marks,
                StudentId = createdStudent.StudentId
            };

            if (createdStudent.School != null)
            {
                studentModel.School = new SchoolModel
                {
                    Name = createdStudent.School.Name,
                    Location = createdStudent.School.Location,
                    SchoolId = createdStudent.School.SchoolId
                };
            }
            var response = Request.CreateResponse<StudentModel>(HttpStatusCode.Created, studentModel);
            var resourceLink = Url.Link("DefaultApi", new { id = studentModel.StudentId });

            response.Headers.Location = new Uri(resourceLink);
            return response;
        }
    }
}
