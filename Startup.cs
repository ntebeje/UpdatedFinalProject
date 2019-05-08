using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSC273_NTebeje_Final_Project.Models;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CSC237_NTebeje_Final_Project
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}



		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

			services.AddTransient<IItemRepository, itemRepository>();
			services.AddTransient<IFeedbackRepository, FeedbackRepository>();

			services.AddTransient<IPaymentRepository, PaymentRepository>();

			services.AddAuthentication().AddGoogle(o =>
			{
				o.ClientId = "152907171730-dd6lrkgpon1u7m5ss26aebqk0745kaf3.apps.googleusercontent.com";
				o.ClientSecret = "waNKzwMo2d6dJco1O80BPTou";
			});

			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseDeveloperExceptionPage();
			app.UseStatusCodePages();
			app.UseStaticFiles();

			

			app.UseAuthentication();


			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}"
					);
			}
			);
		}
	}
}
