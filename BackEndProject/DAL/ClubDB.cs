using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BackEndProject.DAL
{
    public class ClubDB : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Cupon> Cupon { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Trainers> Trainers { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<Calendar> Calendar { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Package> Package { get; set; }
        public DbSet<Info> Info { get; set; }
        public DbSet<SystemUsers> SystemUsers { get; set; }
        public ClubDB():base("Club")
        {
               
        }
    }
}