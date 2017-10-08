using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class User: IdEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string Image { get; set; }
        private ICollection<UserRole> _userRoles;
        public ICollection<UserRole> UserRoles
        {
            get { return _userRoles ?? (_userRoles = new List<UserRole>());  }
            set { _userRoles = value; }
        }
    }
}
