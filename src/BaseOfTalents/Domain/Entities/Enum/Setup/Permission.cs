﻿using Domain.Entities.Enum;
using System.Collections.Generic;

namespace Domain.Entities.Setup
{
    public class Permission : BaseEntity
    {
        public Permission()
        {
            Roles = new List<Role>();
        }

        public string Description { get; set; }
        public AccessRights AccessRights { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}