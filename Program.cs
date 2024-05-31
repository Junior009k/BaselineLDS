using blogBlazor.Components;
using blogBlazor.Components.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

UserController userController = new UserController();

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();



// Configure the HTTP request pipeline.

builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
{
    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asdfsdafjdaslkfadshasdfkjhasdflkasfdjasdfl="));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = securityKey
    };
});
var app = builder.Build();
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();
app.MapPost("/api/auth/login", ([FromBody] userModel jsonstring) => userController.PostAuthenticate(jsonstring));
app.MapPost("/api/auth/register", ([FromBody] userModel jsonstring) => userController.PostRegister(jsonstring));

app.MapPut("/api/auth/changePassword", ([FromBody] userModel jsonstring) => userController.PutChangePassword(jsonstring))
    .RequireAuthorization();
app.Run();
app.MapPut("/api/auth/changeName", ([FromBody] userModel jsonstring) => userController.PutChangeName(jsonstring));
app.MapDelete("/api/auth/deleteUser", ([FromBody] userModel jsonstring) => userController.DeleteUser(jsonstring));

