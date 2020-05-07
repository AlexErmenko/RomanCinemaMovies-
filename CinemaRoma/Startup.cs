using CinemaRoma.Models;
using CinemaRoma.Properties;


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CinemaRoma
{
  public class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration) { Configuration = configuration; }


    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddRazorPages();
      services.AddDbContext<MovieContext>(options =>
      {
        options.UseSqlServer("Data Source=banking-sqlserver.database.windows.net;Initial Catalog=CinemaNetwork;User ID=sqlserver;Password=BankingSystem08");
        options.UseLazyLoadingProxies();
      });


      services.AddMvc()
              .AddDataAnnotationsLocalization(options =>
               {
                 options.DataAnnotationLocalizerProvider = (type, factory) =>
                         factory.Create(typeof(Resources));
               });
    }


    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); } else
      {
        app.UseExceptionHandler("/Error");


        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
    }
  }
}