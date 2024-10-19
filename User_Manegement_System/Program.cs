
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using User_Manegement_System.Data;

namespace User_Manegement_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            
            // SQL Connection To Context
            builder.Services.AddDbContext<MyContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DataBaseConnectionString"));
            });
          
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // Encode Token and Check is Token is correct or not
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) 
           .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "JwtAuthApi",
            ValidAudience = "InternalServices",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Xy2@#S8wL!29uD&f^$%Qo9*VWsM1Pb^R"))
        };
    });


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll");

            app.UseHttpsRedirection(); // HTTPS

            app.UseAuthentication(); // Authentication
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
