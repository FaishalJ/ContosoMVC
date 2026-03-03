using ContosoMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace ContosoMVC.StartUpExtensions
{
    public static class DbContextService
    {
        public static void AddDbContextService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SchoolContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .UseSeeding((context, _) =>
                {
                    var dbContext = (SchoolContext)context;

                    if (!dbContext.Students.Any())
                        dbContext.Students.AddRange(DbInitializer.SeedStudents());

                    if (!dbContext.Courses.Any())
                        dbContext.Courses.AddRange(DbInitializer.SeedCourses());

                    if (!dbContext.Enrollments.Any())
                        dbContext.Enrollments.AddRange(DbInitializer.SeedEnrollments());

                    dbContext.SaveChanges();
                })
                .UseAsyncSeeding(async (context, _, cancellationToken) =>
                {
                    var dbContext = (SchoolContext)context;

                    // seed students
                    if (!dbContext.Students.Any())
                    {
                        dbContext.Students.AddRange(DbInitializer.SeedStudents());
                    }

                    // seed courses
                    if (!dbContext.Courses.Any())
                    {
                        dbContext.Courses.AddRange(DbInitializer.SeedCourses());
                    }

                    // seed enrollments
                    if (!dbContext.Enrollments.Any())
                    {
                        dbContext.Enrollments.AddRange(DbInitializer.SeedEnrollments());
                    }
                    await dbContext.SaveChangesAsync(cancellationToken);
                }));

            /*
             * The AddDatabaseDeveloperPageExceptionFilter provides helpful error information in the development environment.
             */
            services.AddDatabaseDeveloperPageExceptionFilter();
        }
    }
}
