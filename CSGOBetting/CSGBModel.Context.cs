﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSGOBetting
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbEntities : DbContext
    {
        public dbEntities()
            : base("name=dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<bet> bets { get; set; }
        public virtual DbSet<@event> events { get; set; }
        public virtual DbSet<match> matches { get; set; }
        public virtual DbSet<matchstatu> matchstatus { get; set; }
        public virtual DbSet<oddssource> oddssources { get; set; }
        public virtual DbSet<player> players { get; set; }
        public virtual DbSet<roster> rosters { get; set; }
        public virtual DbSet<team> teams { get; set; }
        public virtual DbSet<odd> odds { get; set; }
    }
}
