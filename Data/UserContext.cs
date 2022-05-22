using cs_crud.Models;
using Microsoft.EntityFrameworkCore;

namespace cs_crud.Data
{
  public class UserContext : DbContext
  {
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
  }
}