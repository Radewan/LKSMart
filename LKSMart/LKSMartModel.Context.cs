﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LKSMart
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class lks_martEntities : DbContext
    {
        public lks_martEntities()
            : base("name=lks_martEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_barang> tbl_barang { get; set; }
        public virtual DbSet<tbl_log> tbl_log { get; set; }
        public virtual DbSet<tbl_pelanggan> tbl_pelanggan { get; set; }
        public virtual DbSet<tbl_transaksi> tbl_transaksi { get; set; }
        public virtual DbSet<tbl_user> tbl_user { get; set; }
    }
}
