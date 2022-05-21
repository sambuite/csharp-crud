using cs_crud.Models;
using Microsoft.AspNetCore.Mvc;

namespace cs_crud.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {
    private static List<User> Users()
    {
      return new List<User>{
        new User{ name = "Murilo", id = 1, birthday = new DateTime(2000,7,16) }
      };
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Ok(Users());
    }

    [HttpPost]
    public IActionResult Post(User user)
    {
      var users = Users();
      users.Add(user);

      return Ok(users);
    }
  }
}