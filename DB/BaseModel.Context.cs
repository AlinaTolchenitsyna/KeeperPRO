﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KeeperPRO.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KeeperPROEntities : DbContext
    {
        public KeeperPROEntities()
            : base("name=KeeperPROEntities")
        {
        }

        private static KeeperPROEntities _context;

        public static KeeperPROEntities GetContext()
        {
            if (_context == null)
            {
                _context = new KeeperPROEntities();

            }
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<LogAutho> LogAutho { get; set; }
        public virtual DbSet<Purpose> Purpose { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Visitor> Visitor { get; set; }
    }
}
