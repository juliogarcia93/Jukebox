﻿
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MusicContainer : DbContext
    {
        public MusicContainer()
            : base("name=MusicContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Song> Songs { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
    }
}