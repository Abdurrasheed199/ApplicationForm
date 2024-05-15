using ApplicationForm.Context;

namespace ApplicationForm.Configure
{
    public class StartUpClass
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString));
            return services;

        }
    }
}
