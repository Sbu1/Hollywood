using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodAssessment.Common.Interfaces;
using HollywoodAssessment.Data.Models;
using HollywoodAssessment.Service.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace HollywoodAssessment
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

      services.AddDbContext<HollywoodAssessmentDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("HollywoodAssessmentDb")));
      services.AddTransient<ITournamentService, TournamentService>();
      services.AddTransient<IEventsService, EventService>();
      services.AddTransient<IEventDetailService, EventDetailsService>();

      services.AddSwaggerGen(x =>
      {
        x.SwaggerDoc("v1", new Info
        {
          Title = "Hollywood",
          Version = "v1",
          Description = "To be updated",
          Contact = new Contact
          {
            Email = "sbuddaz@gmail.com",
            Name = "Sibusiso Sikhakhane"
          }
        });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseStaticFiles();
      app.UseSwagger();
      app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.json", "Hollywood API v1"); } );


      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}
