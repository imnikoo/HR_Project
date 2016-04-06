﻿using System.Data.Entity;
using BotLibrary.Entities;
using BotLibrary.Entities.Setup;
using System.Diagnostics;
using System.Reflection;

namespace BotData.EFData
{
    public class BOTContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Candidate>  Candidates { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }

        public BOTContext() : base()
        {
        }
    }
}
