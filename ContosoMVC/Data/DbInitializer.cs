using ContosoMVC.Models;

namespace ContosoMVC.Data
{
    public static class DbInitializer
    {
        public static Student[] SeedStudents() => 
            [
                new() {FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new() {FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new() {FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new() {FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new() {FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
                new() {FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new() {FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            ];

        public static Course[] SeedCourses() =>
            [
                new() {CourseID=1050,Title="Chemistry",Credits=3},
                new() {CourseID=4022,Title="Microeconomics",Credits=3},
                new() {CourseID=4041,Title="Macroeconomics",Credits=3},
                new() {CourseID=1045,Title="Calculus",Credits=4},
                new() {CourseID=3141,Title="Trigonometry",Credits=4},
                new() {CourseID=2021,Title="Composition",Credits=3},
                new() {CourseID=2042,Title="Literature",Credits=4}
            ];

        public static Enrollment[] SeedEnrollments() =>
            [
                new() {StudentID=1,CourseID=1050,Grade=Grade.A},
                new() {StudentID=1,CourseID=4022,Grade=Grade.C},
                new() {StudentID=1,CourseID=4041,Grade=Grade.B},
                new() {StudentID=2,CourseID=1045,Grade=Grade.B},
                new() {StudentID=2,CourseID=3141,Grade=Grade.F},
                new() {StudentID=2,CourseID=2021,Grade=Grade.F},
                new() {StudentID=3,CourseID=1050},
                new() {StudentID=4,CourseID=1050},
                new() {StudentID=4,CourseID=4022,Grade=Grade.F},
                new() {StudentID=5,CourseID=4041,Grade=Grade.C},
                new() {StudentID=6,CourseID=1045},
                new() {StudentID=7,CourseID=3141,Grade=Grade.A},
            ];
    }
}
