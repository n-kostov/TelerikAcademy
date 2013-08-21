using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using StudentSystem.DataLayer;
using StudentSystem.RepositoryLayer;
using StudentSystem.Model;
using StudentSystem.ServiceLayer.Controllers;
using StudentSystem.ServiceLayer.Models;

namespace StudentSystem.ServiceLayer.Resolvers
{
    public class DbDependencyResolver : IDependencyResolver
    {
        private static DbContext studentContext = new StudentSystemContext();

        private static IRepository<Student> studentRepository = new EfRepository<Student>(studentContext);
        private static IRepository<School> schoolRepository = new EfRepository<School>(studentContext);

        //public DbDependencyResolver()
        //{
        //    studentContext = new StudentSystemContext();
        //    studentContext.Database.CreateIfNotExists();
        //    repository = new EfRepository<Student>(studentContext);
        //}

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(StudentsController))
            {
                return new StudentsController(studentRepository);
            }
            else if (serviceType == typeof(SchoolsController))
            {
                return new SchoolsController(schoolRepository);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}