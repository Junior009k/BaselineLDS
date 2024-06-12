using blogBlazor.Components.DB;
using Microsoft.AspNetCore.Mvc;


[Route("api/")]
[ApiController]


public class UserController : ControllerBase
{
    Auth myAuthDB = new Auth();
    [HttpPost]
    public IActionResult PostAuthenticate(userModel data)
    {
        data.password = myAuthDB.GetMD5(data.password);
        string response = myAuthDB.Authenticate(data);
        Console.WriteLine(response.Length);
        if(response.Length == 22 || response.Length == 35)
        {
            return Ok(new { message = response });
        }

        return Ok(new { Token = response, message = "ok" });
    }
    [HttpPost]
    public IActionResult PostRegister([FromBody] userModel data)
    {
        data.password = myAuthDB.GetMD5(data.password);
        myAuthDB.Register(data);
        return Ok(new { id = data.id, name = data.name, username = data.username, message = "Creado Satisfactoriamente" });
    }

    [HttpPut]
    public IActionResult PutChangePassword([FromBody] userModel data)
    {
        data.password = myAuthDB.GetMD5(data.password);
        string response=myAuthDB.changePassword(data);
        Console.WriteLine(response.Length);
        if (response.Length == 19)
        {
            return Ok(new { message = response });
        }
        return Ok(new { id = data.id,  username = data.username, message =response });
    }

    [HttpPut]
    public IActionResult PutChangeName([FromBody] userModel data)
    {
        string response = myAuthDB.changeName(data);
        if (response.Length == 19)
        {
            return Ok(new { message = response });
        }
        return Ok(new { id = data.id, username = data.username, message = response });
    }

    [HttpDelete]
    public IActionResult DeleteUser([FromBody] userModel data)
    {
        string response = myAuthDB.deleteUser(data);
        Console.WriteLine(response.Length);
        if (response.Length == 17)
        {
            return Ok(new { message = response });
        }
        return Ok(new { id = data.id, username = data.username, message = response });
    }
}
