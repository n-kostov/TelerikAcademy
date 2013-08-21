using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using CodeJewels.Data;
using CodeJewels.Repositories;
using CodeJewels.Models;
using CodeJewels.Services.Controllers;

namespace CodeJewels.Services.Resolvers
{
    public class DbDependencyResolver : IDependencyResolver
    {
        private static DbContext context = new CodeJewelDataContext();

        private static IRepository<CodeJewel> studentRepository = new EfRepository<CodeJewel>(context);

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(CodeJewelsController))
            {
                return new CodeJewelsController(studentRepository);
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