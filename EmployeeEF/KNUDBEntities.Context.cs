﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeEF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KNUDBEntities : DbContext
    {
        public KNUDBEntities()
            : base("name=KNUDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CATHEDRA> CATHEDRA { get; set; }
        public virtual DbSet<DEGREE> DEGREE { get; set; }
        public virtual DbSet<DEGREELIST> DEGREELIST { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENT { get; set; }
        public virtual DbSet<EMAIL> EMAIL { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEE { get; set; }
        public virtual DbSet<PHOTO> PHOTO { get; set; }
        public virtual DbSet<STATUS> STATUS { get; set; }
        public virtual DbSet<USERS> USERS { get; set; }
    }
}
