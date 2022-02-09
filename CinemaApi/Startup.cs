using Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using Persistence.Data;
using System;
using System.Text;
using System.Text.Json.Serialization;

namespace CinemaApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CinemaDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //dbContext.Database.EnsureCreated(); 
            // solo sirve cuando queremos crear de entrada por unica vez la base de datos
            //si después la actualizamos o actualizamos algun modelo no nos va a servir.

            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureApplicationServices();
            //services.ConfigureInfrastructureServices(Configuration); Si agregamos los mails por ahora no
            services.ConfigurePersistenceServices();
            services.AddAuthorization();
            services.AddHealthChecks();
            services.AddControllers();
               /* .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler =
                    ReferenceHandler.IgnoreCycles;
                }); */
               /* .AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);*/
            services.AddSwaggerGen();

           /* services.AddDbContext<CinemaDbContext>(option => 
            option.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CinemaDB;Integrated Security = True"));*/

            services.AddMvc().AddXmlSerializerFormatters(); 
            //para que nos puedan devolver el contenido en el formato que querramos
            //por ejemplo xml
            

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Tokens:Issuer"],
                        ValidAudience = Configuration["Tokens:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                        ClockSkew = TimeSpan.Zero,
                    };
                });
            
        }
    }
}
