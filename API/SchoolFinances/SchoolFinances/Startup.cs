using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SchoolFinances.Abstract;
using SchoolFinances.Models;
using SchoolFinances.Repositories;

namespace SchoolFinances
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
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
					.AddJwtBearer(options =>
					{
						options.RequireHttpsMetadata = false;
						options.TokenValidationParameters = new TokenValidationParameters
						{
							ValidateIssuer = true,
							ValidIssuer = AuthOptions.ISSUER,

							ValidateAudience = false,
							ValidAudience = AuthOptions.AUDIENCE,

							ValidateLifetime = true,

							IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),

							ValidateIssuerSigningKey = true,
						};
					});

			services.AddDbContext<ApplicationContext>(op => op.UseSqlServer(Configuration["ConnectionString:SchoolFinancesDB"], b => b.MigrationsAssembly("SchoolFinances")));

			services.AddScoped<IUserRepository<User>, DbUserRepository>();
			//services.AddScoped<IUserRepository<User>, MockUserRepository>();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseDefaultFiles();
			app.UseStaticFiles();

			app.UseAuthentication();

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
