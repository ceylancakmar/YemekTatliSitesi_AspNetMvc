﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CeylaninMutfagi
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class yemekTatliEntities : DbContext
    {
        public yemekTatliEntities()
            : base("name=yemekTatliEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tatli> tatli { get; set; }
        public virtual DbSet<tatliKategori> tatliKategori { get; set; }
        public virtual DbSet<yemek> yemek { get; set; }
        public virtual DbSet<yemekKategori> yemekKategori { get; set; }
    }
}