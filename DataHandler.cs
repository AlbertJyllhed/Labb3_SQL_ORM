using Labb3_SQL_ORM.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Labb3_SQL_ORM
{
    internal class DataHandler
    {
        // Method to fetch all students in the database
        internal static void FetchStudents(bool sortByFirstName = true, bool ascending = true)
        {
            using (var context = new Labb2Context())
            {
                var studentQuery = (from s in context.Students select s);
                List<Student> students;

                if (sortByFirstName)
                {
                    students = SortStudentsByFirstName(studentQuery, ascending);
                }
                else
                {
                    students = SortStudentsByLastName(studentQuery, ascending);
                }

                foreach (var student in students)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName}, " +
                        $"Personnummer: {student.PersonalNumber}");
                }
            }
        }

        private static List<Student> SortStudentsByFirstName(IQueryable<Student> students, bool ascending = true)
        {
            if (ascending)
            {
                students = students.OrderBy(s => s.FirstName);
            }
            else
            {
                students = students.OrderByDescending(s => s.FirstName);
            }

            return students.ToList();
        }

        private static List<Student> SortStudentsByLastName(IQueryable<Student> students, bool ascending = true)
        {
            if (ascending)
            {
                students = students.OrderBy(s => s.LastName);
            }
            else
            {
                students = students.OrderByDescending(s => s.LastName);
            }

            return students.ToList();
        }

        // Method to fetch all available classes for the user to choose from
        internal static List<Class> FetchClasses()
        {
            var classes = new List<Class>();

            using (var context = new Labb2Context())
            {
                classes = context.Classes.ToList();
            }

            return classes;
        }

        // Method to fetch students of a specific class
        internal static void FetchStudentsInClass(string className, bool sortByFirstName = true, bool ascending = true)
        {
            using (var context = new Labb2Context())
            {
                var studentClassesQuery = (from s in context.Students
                                           join c in context.Classes
                                           on s.ClassId equals c.Id
                                           where c.ClassName == className
                                           select s);
                List<Student> students;

                if (sortByFirstName)
                {
                    students = SortStudentsByFirstName(studentClassesQuery, ascending);
                }
                else
                {
                    students = SortStudentsByLastName(studentClassesQuery, ascending);
                }

                Console.WriteLine($"Students in {className}:");

                foreach (var s in students)
                {
                    Console.WriteLine($"{s.FirstName} {s.LastName}, " +
                        $"Personnummer: {s.PersonalNumber}");
                }
            }
        }

        // Method to add a new employee into the database
        internal static void AddEmployee(string firstName, string lastName, bool isAdmin)
        {
            using (var context = new Labb2Context())
            {
                var newEmployee = new Employee
                {
                    FirstName = firstName,
                    LastName = lastName
                };

                context.Employees.Add(newEmployee);

                if (isAdmin)
                {
                    var newAdmin = new Administrator();

                    newAdmin.Employee = newEmployee;
                    context.Administrators.Add(newAdmin);
                }
                else
                {
                    var newTeacher = new Teacher();

                    newTeacher.Employee = newEmployee;
                    context.Teachers.Add(newTeacher);
                }

                context.SaveChanges();
            }
        }
    }
}
