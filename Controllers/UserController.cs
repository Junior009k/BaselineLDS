using blogBlazor.Components.DB;
using Microsoft.AspNetCore.Mvc;


[Route("api/")]
[ApiController]


public class UserController : ControllerBase
{
    Auth myAuthDB= new Auth();
    
    [HttpPost]
    public IActionResult PostAuthenticate(userModel data)
    {
        data.password = myAuthDB.GetMD5(data.password);
        return Ok(new { Token = myAuthDB.Authenticate(data), message = "ok" });
    }
    [HttpPost]
    public IActionResult PostRegister([FromBody] userModel data)
    {
        data.password = myAuthDB.GetMD5(data.password);
        myAuthDB.Register(data);
        return Ok(new { id = data.id, name = data.name, username = data.username, message = "Creado Satisfactoriamente" });
    }

}
