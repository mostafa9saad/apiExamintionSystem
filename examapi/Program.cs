using examapi.Models;
using examapi.Services;
using examapi.Services.exam;
using examapi.Services.interfaces;
using examapi.Services.question;
using examapi.Services.test;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace examapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string txt = "hi";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddDbContext<examSystemContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
            builder.Services.AddScoped<IStudent, studentServises>();
            builder.Services.AddScoped<Itest, TestServcise>();
            builder.Services.AddScoped<IQuestions, QuestionsServices>();
            builder.Services.AddScoped<IExam, ExamServices>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(option =>
            {
                string Key = "hi iam mostafa ahmed mahmoud saad";
                var secertyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = secertyKey,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(txt,
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
            builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            builder.Services.AddAutoMapper(typeof(Program));
            //builder.Services.AddMvc()
            //      .AddJsonOptions(opt =>
            //      {
            //          opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            //      });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(txt);

            app.MapControllers();

            app.Run();
        }
    }
}