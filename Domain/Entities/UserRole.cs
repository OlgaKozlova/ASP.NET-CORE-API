﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class UserRole: Entity
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
