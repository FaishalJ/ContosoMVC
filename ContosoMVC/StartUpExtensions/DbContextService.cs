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

                    var student = dbContext.Students;
                    var instructor = dbContext.Instructors;
                    var department = dbContext.Departments;
                    var course = dbContext.Courses;

                    // 1. Seed Students
                    if (!dbContext.Students.Any())
                    {
                        dbContext.Students.AddRange(DbInitializer.SeedStudents());
                        dbContext.SaveChanges();
                    }

                    // 2. Seed Instructors
                    if (!dbContext.Instructors.Any())
                    {
                        dbContext.Instructors.AddRange(DbInitializer.SeedInstructors());
                        dbContext.SaveChanges();
                    }

                    // 3. Seed Departments
                    if (!dbContext.Departments.Any())
                    {
                        dbContext.Departments.AddRange(DbInitializer.SeedDepartments(instructor.ToList()));
                        dbContext.SaveChanges();
                    }

                    // 4. Seed Courses
                    if (!dbContext.Courses.Any())
                    {
                        dbContext.Courses.AddRange(DbInitializer.SeedCourses(department.ToList()));
                        dbContext.SaveChanges();
                    }

                    // 5. Seed Office Assignments
                    if (!dbContext.OfficeAssignments.Any())
                    {
                        dbContext.OfficeAssignments.AddRange(DbInitializer.SeedOfficeAssignments(instructor.ToList()));
                        dbContext.SaveChanges();
                    }

                    //  6. Seed Enrollments
                    if (!dbContext.Enrollments.Any())
                    {
                        dbContext.Enrollments.AddRange(DbInitializer.SeedEnrollments(student.ToList(), course.ToList()));
                        dbContext.SaveChanges();
                    }

                    // 7. Seed Course Assignments
                    if (!dbContext.CourseAssignments.Any())
                    {
                        dbContext.CourseAssignments.AddRange(DbInitializer.SeedCourseAssignments(course.ToList(), instructor.ToList()));
                        dbContext.SaveChanges();
                    }

                    //dbContext.SaveChanges();
                })
                .UseAsyncSeeding(async (context, _, cancellationToken) =>
                {
                    var dbContext = (SchoolContext)context;

                    var student = dbContext.Students;
                    var instructor = dbContext.Instructors;
                    var department = dbContext.Departments;
                    var course = dbContext.Courses;

                    // 1. seed students
                    if (!dbContext.Students.Any())
                    {
                        dbContext.Students.AddRange(DbInitializer.SeedStudents());
                        await dbContext.SaveChangesAsync(cancellationToken);
                    }

                    // 2. seed Instructors
                    if (!dbContext.Instructors.Any())
                    {
                        dbContext.Instructors.AddRange(DbInitializer.SeedInstructors());
                        await dbContext.SaveChangesAsync(cancellationToken);
                    }

                    // 3. Seed Departments
                    if (!dbContext.Departments.Any())
                    {
                        dbContext.Departments.AddRange(DbInitializer.SeedDepartments(instructor.ToList()));
                        await dbContext.SaveChangesAsync(cancellationToken);
                    }

                    // 4. seed courses
                    if (!dbContext.Courses.Any())
                    {
                        dbContext.Courses.AddRange(DbInitializer.SeedCourses(department.ToList()));
                        await dbContext.SaveChangesAsync(cancellationToken);
                    }

                    // 5. Seed OfficeAssignments
                    if (!dbContext.OfficeAssignments.Any())
                    {
                        dbContext.OfficeAssignments.AddRange(DbInitializer.SeedOfficeAssignments(instructor.ToList()));
                        await dbContext.SaveChangesAsync(cancellationToken);
                    }

                    // 6. seed enrollments
                    if (!dbContext.Enrollments.Any())
                    {
                        dbContext.Enrollments.AddRange(DbInitializer.SeedEnrollments(student.ToList(), course.ToList()));
                        await dbContext.SaveChangesAsync(cancellationToken);
                    }

                    // 7. Seed Course Assignments
                    if (!dbContext.CourseAssignments.Any())
                    {
                        dbContext.CourseAssignments.AddRange(DbInitializer.SeedCourseAssignments(course.ToList(), instructor.ToList()));
                        await dbContext.SaveChangesAsync(cancellationToken);
                    }

                }));

            /*
             * The AddDatabaseDeveloperPageExceptionFilter provides helpful error information in the development environment.
             */
            services.AddDatabaseDeveloperPageExceptionFilter();
        }
    }
}
