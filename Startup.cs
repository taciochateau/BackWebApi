using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyApp.Infrastructure.Data.Relational;
using MyApp.Infrastructure.Data.NoSql;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Services;

var sqlConnection = Configuration.GetConnectionString("DefaultConnection");
var mongoConnection = Configuration.GetConnectionString("MongoDbConnection");

namespace MyApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configure relational database (Entity Framework)
            services.AddDbContext<AppDbContext>();

            // Configure NoSQL database (MongoDB)
            services.AddSingleton<MongoDbContext>(provider =>
                new MongoDbContext(
                    Configuration.GetConnectionString("MongoDbConnection"),
                    Configuration["MongoDbDatabaseName"]
                ));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp",
                    builder => builder.WithOrigins("http://localhost:4200")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod());
            });

            // Dependency injection for repositories and services
            services.AddScoped<IClientRepository, EFClientRepository>();
            services.AddScoped<IClientService, ClientService>();

            // Add controllers and services
            services.AddControllers();

            // Add Swagger for API documentation
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyApp API v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("AllowAngularApp");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
