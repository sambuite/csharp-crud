using cs_crud.Data;
using cs_crud.Models;
using Microsoft.EntityFrameworkCore;

namespace cs_crud.Repository
{
  public class UserRepository : IUserRepository
  {
    private readonly UserContext context;

    public UserRepository(UserContext context)
    {
      this.context = context;
    }

    public void Add(User user)
    {
      this.context.Add(user);
    }

    public void Delete(User user)
    {
      this.context.Remove(user);

    }

    public async Task<User> FindById(int id)
    {
      return await this.context.Users.
        Where(user => user.id == id).
        FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<User>> List()
    {
      return await this.context.Users.ToListAsync();
    }

    public void Update(User user)
    {
      this.context.Update(user);

    }

    public async Task<bool> SaveChangesAsync()
    {
      return await this.context.SaveChangesAsync() > 0;
    }
  }
}