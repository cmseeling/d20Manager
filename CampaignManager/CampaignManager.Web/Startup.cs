using CampaignManager.Business.Interfaces;
using CampaignManager.Business.Repositories;
using CampaignManager.Business.ViewModels;
using CampaignManager.Data;
using CampaignManager.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CampaignManager.Web
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var connectionString = Startup.Configuration["connectionStrings:connectionStrings"];
            services.AddDbContext<CampaignContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<ICampaignRepository, CampaignRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, CampaignContext campaignContext)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            campaignContext.EnsureSeedDataForContext();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                #region Campaign
                //campaign read
                cfg.CreateMap<Campaign, CampaignViewModel>();
                cfg.CreateMap<Campaign, CampaignWithCharactersViewModel>();
                cfg.CreateMap<Campaign, EditCampaignViewModel>();
                //campaign write
                cfg.CreateMap<CreateCampaignViewModel, Campaign>();
                cfg.CreateMap<EditCampaignViewModel, Campaign>();
                #endregion

                #region Character
                //character read
                cfg.CreateMap<Character, CharacterViewModel>();
                //character write
                #endregion
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Application}/{action=Index}");
            });
        }
    }
}
