using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Role: IdEntity
    {
        public string Title { get; set; }
        private ICollection<UserRole> _userRoles;
        public ICollection<UserRole> UserRoles
        {
            get { return _userRoles ?? (_userRoles = new List<UserRole>()); }
            set { _userRoles = value; }
        }
    }
}
