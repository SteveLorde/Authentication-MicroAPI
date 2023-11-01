using System.Text;
using EnterpriseAuthentication_MicroAPI.Data;
using EnterpriseAuthentication_MicroAPI.Services.DataAccess;
using EnterpriseAuthentication_MicroAPI.Services.JWT;
using EnterpriseAuthentication_MicroAPI.Services.PasswordHash;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Writers;
using AuthenticationService = EnterpriseAuthentication_MicroAPI.Services.Authentication.AuthenticationService;
using IAuthenticationService = EnterpriseAuthentication_MicroAPI.Services.Authentication.IAuthenticationService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddTransient<IJWT, Jwt>();
builder.Services.AddTransient<IDataAccessService, DataAccessService>();
builder.Services.AddTransient<IPasswordHash, PasswordHash>();
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,          
        ValidateAudience = true,        
        ValidateLifetime = true,        
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123456")),
        ValidIssuer = "your-issuer",
        ValidAudience = "your-audience"
    };
} );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var dbcontext = services.GetRequiredService<DataContext>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

dbcontext.Database.Migrate();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();