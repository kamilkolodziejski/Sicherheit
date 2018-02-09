using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SicherheitCore.Repository.Abstract;
using SicherheitCore.Repository.SqlConcret;
using SicherheitCore.Services;
using SicherheitCore.Services.Abstract;
using SicherheitCore.Services.Concret;

namespace SicherheitCore
{
    public class Startup
    {
        private readonly ILogger _logger;

        public Startup(IConfiguration configuration)
        {
            _logger = new SimplyLogger();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _logger.Log($"Configuration Services...");
            services.AddScoped<IUserRepository, SqlUserRepository>();
            services.AddScoped<ITaskRepository, SqlTaskRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddSingleton<ILogger, SimplyLogger>();
            _logger.Log("Adding DbContext...");
            services.AddDbContext<SicherheitCoreContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "home",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            _logger.Log($"Starting initialize database...");
            InitDatabase(app);
        }

        private void InitDatabase(IApplicationBuilder app)
        {
            try
            {
                var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
                using (var scope = scopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<SicherheitCoreContext>();

                    if (context == null)
                    {
                        throw new Exception("DbContext object cannot be null.");
                    }

                    _logger.Log($"Generating database objects...");
                    DbInitializer.Initialize(context);
                }
            }
            catch (Exception e)
            {
                _logger.Debug($" ERROR  - Handled exception in 'initDatabase' Startup's object\n {e.StackTrace}");
            }
        }
    }
}
