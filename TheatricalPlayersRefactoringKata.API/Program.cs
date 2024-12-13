using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using TheatricalPlayersRefactoringKata.API.Database;
using TheatricalPlayersRefactoringKata.Calculators;
using TheatricalPlayersRefactoringKata.Interface;
using TheatricalPlayersRefactoringKata.Models;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace TheatricalPlayersRefactoringKata.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var xmlPath = Path.Combine(AppContext.BaseDirectory, "TheatricalPlayersRefactoringKata.API.xml");
           
            // Add services to the container.

            // Add DbContext for Entity Framework
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 

            // Add services for controllers
            builder.Services.AddControllers();

            // Add Swagger/OpenAPI for API documentation
            builder.Services.AddEndpointsApiExplorer();
            
            builder.Services.AddSwaggerGen(options =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Theatrical Players API",
                    Version = "v1",
                    Description = "API to generate statements for a theater company.",
                });
            });

            // Register GenreCalculators and StatementFormatter as services
            builder.Services.AddScoped<IStatementFormatter, TextFormatter>(); 
            builder.Services.AddScoped<IGenreCalculator, TragedyCalculator>();
            
            builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
