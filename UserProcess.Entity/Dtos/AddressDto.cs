using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProcess.Entity.Dtos
{
    public class AddressDto
    {
        public long Id { get; set; }
        public string City { get; set; }
        public string AddressLine { get; set; }
    }
}
