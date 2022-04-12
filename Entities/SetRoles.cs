using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static  class SetRoles
    {
        public const string SuperAdmin = "SuperAdmin";
        public const string Admin = "Admin";
        public const string Spectator = "Guest";
        public const string Member = "Member";
        public const string AdminMember = "Admin,Member";
        public const string SAdminMember = "Admin,Member,SuperAdmin";
        public const string SAdmin = "Admin,SuperAdmin";
        public const string Donator = "Donor,SuperAdmin,Admin";

    }
}
