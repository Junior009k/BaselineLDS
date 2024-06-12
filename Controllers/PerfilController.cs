using BaselineLDS.Model;
using blogBlazor.Components.DB;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static BaselineLDS.Model.Perfil;


namespace BaselineLDS.Controllers
{
    public class PerfilController : ControllerBase
    {

        Perfil myPerfilDB = new Perfil();
        [HttpGet]
        public IActionResult getPerfil()
        {
            
            string response = myPerfilDB.getPerfil();
            
            if (response.Length == 22 || response.Length == 35)
            {
                return Ok(new { message = response });
            }

            return Ok(new {  response, message = "ok" });
        }
    }
}
