using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos
{
    public class UserForRegisterDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Roles { get; set; }
        public string PhotoBase64 { get; set; }
    }
}
