using cs_crud.Models;
using cs_crud.Repository;
using Microsoft.AspNetCore.Mvc;

namespace cs_crud.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {
    private readonly IUserRepository repository;

    public UserController(IUserRepository repository)
    {
      this.repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var users = await this.repository.List();

      return users.Any() ? Ok(users) : NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var user = await this.repository.FindById(id);

      return user != null ? Ok(user) : NotFound("NotFound");
    }

    [HttpPost]
    public async Task<IActionResult> Post(User user)
    {
      this.repository.Add(user);

      return await this.repository.SaveChangesAsync() ? Ok("Ok") : BadRequest("Error");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, User user)
    {
      var userSearched = await this.repository.FindById(id);

      if (userSearched == null) return NotFound("NotFound");

      userSearched.name = user.name ?? userSearched.name;
      userSearched.birthday = user.birthday != new DateTime()
      ? user.birthday
      : userSearched.birthday;

      this.repository.Update(userSearched);

      return await this.repository.SaveChangesAsync() ? Ok("Ok") : BadRequest("Error");

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var user = await this.repository.FindById(id);

      if (user == null) return NotFound("NotFound");

      this.repository.Delete(user);

      return await this.repository.SaveChangesAsync() ? Ok("Ok") : BadRequest("Error");
    }
  }
}