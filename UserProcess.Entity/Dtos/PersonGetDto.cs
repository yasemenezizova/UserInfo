using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProcess.Entity.Dtos
{
    public class PersonGetDto
    {
        public long Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
    }
}
