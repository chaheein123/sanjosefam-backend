using System;
using Microsoft.EntityFrameworkCore;
using sanjosefam_backend.Models;

namespace sanjosefam_backend.Data
{
  public class MainContext : DbContext
  {
    public MainContext(DbContextOptions<MainContext> opt) : base(opt)
    {
    }

    public DbSet<User> Users { get; set; }
  }
  //public class MainContext : IdentityContext
  //{

  //}
}
