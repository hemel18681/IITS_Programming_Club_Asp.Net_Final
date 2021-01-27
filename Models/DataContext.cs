using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Data;
using IITS_Programming_Club.Models;

namespace IITS_Programming_Club.Models
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Admin> admin_info { get; set; }
        public DbSet<StudentInfo> student_info { get; set; }
        public DbSet<Notice> notice { get; set; }
        public DbSet<ClassSchedule> class_info { get; set; }
        public DbSet<Complain> complain_info { get; set; }
        public DbSet<Event> event_info { get; set; }
        public DbSet<ToDoList> todolist { get; set; }
        public DbSet<Programmer> prog_of_week { get; set; }
        public DbSet<Home> Home { get; set; }
    }
}
