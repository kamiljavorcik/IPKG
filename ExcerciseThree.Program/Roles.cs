using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseThree.Program
{
    public class Roles : Lib.IRoles
    {
        Role role { get; set; }

        public Roles(Role role)
        {
            this.role = role;
        }

        public void check(string path)
        {
            if (path.ToLower().Contains("role") && role != Role.Admin)
                throw new Exception("Insufficient privileges.");
        }

        public enum Role
        { 
            Admin,
            User
        }
    }
}
