using EmployeeDemo.Domain.Employee;
using EmployeeDemo.EF;
using EmployeeDemo.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDemo.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private readonly IWebHostEnvironment Environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;        
        }
        public void ConfigureService(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<EmployeeDbContext>(option=>
                 option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<EmployeesService>();
            services.AddTransient<IEmployeesRepository, EmployeesRepository>();
            services.AddTransient<IEmployeesService ,EmployeesService>();



            services.AddAutoMapper(typeof(Startup).Assembly);
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employees}/{action=Index}/{id?}");
            app.Run();
        }
    }
}
