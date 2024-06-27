using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    //options.DefaultAuthenticateScheme = "second-cookie";
    //options.DefaultChallengeScheme = "second - cookie";
}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.Cookie = new CookieBuilder()
    {
        Name = "sieuphamcookie"//,
        //Domain = "localhost"
    };


    options.LoginPath = "api/Authen/unauthorized";
    options.LogoutPath = "api/Authen/logout";
    options.AccessDeniedPath = "api/Authen/forbidden";

    //options.Events.OnValidatePrincipal = (context) => 
    //{  
    //    return Task.CompletedTask; 
    //};
});//.AddCookie("second-cookie", options =>
//{
//   options.LoginPath = "api/authen/unauthorized-v2";
    //options.Events.OnValidatePrincipal = (context) =>
    //{
    //    return Task.CompletedTask;
    //};
//});
//builder.Services.AddAuthorization(options =>
//{
//    var defaultAuthorzationPolicyBuilder = new AuthorizationPolicyBuilder(
//    CookieAuthenticationDefaults.AuthenticationScheme,
//     "second-cookie"

//        );
//    defaultAuthorzationPolicyBuilder = defaultAuthorzationPolicyBuilder.RequireAuthenticatedUser();
//    options.DefaultPolicy= defaultAuthorzationPolicyBuilder.Build();
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
