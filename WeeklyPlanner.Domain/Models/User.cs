using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyPlanner.Domain.Models
{
    public class User : BaseModel
    {

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string CompanyDomain { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }



    }
    
    public class Role 
    {
        public Role(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public override string ToString() => Name;

        public Role ProjectManager => new Role(nameof(ProjectManager));
        public Role SoftwareEnginner => new Role(nameof(SoftwareEnginner));
        public Role CTO => new Role(nameof(CTO));
        public Role ContentManager => new Role(nameof(ContentManager));


    }

}
