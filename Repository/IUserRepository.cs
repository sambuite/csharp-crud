using cs_crud.Models;

namespace cs_crud.Repository
{
  public interface IUserRepository
  {
    Task<IEnumerable<User>> List();
    Task<User> FindById(int id);
    void Add(User user);
    void Update(User user);
    void Delete(User user);
    Task<bool> SaveChangesAsync();
  }
}