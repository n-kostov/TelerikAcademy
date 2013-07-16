using _01.UsingEntityFrameworkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace _08.EmployeeExtensionToHaveTerritories
{
    public partial class Employees
    {
        private EntitySet<Territory> entityTerritories;

        public EntitySet<Territory> EntityTerritories
        {
            get
            {
                var employeeTerritories = this.EntityTerritories;
                EntitySet<Territory> entityTerritories = new EntitySet<Territory>();
                entityTerritories.AddRange(employeeTerritories);
                return entityTerritories;
            }
        }
    }
}
