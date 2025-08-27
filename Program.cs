using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics;

namespace MyApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                Console.WriteLine("----------------------  Student grade:   -----------------------");
                Console.WriteLine("1- Insert a student");
                Console.WriteLine("2- Remove a student");
                Console.WriteLine("3- Search a student");
                Console.WriteLine("4- calculate average");
                Console.WriteLine("5- Diplay list");
                Console.WriteLine("6- exit");
                Console.Write("Please select an option:");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.Write("First name:");
                                string? fname = Console.ReadLine();
                                Console.Write("Last name:");
                                string? lname = Console.ReadLine();
                                Student student = new Student(fname, lname);
                                students.Add(student);
                                Console.Write("Enter the grade:");
                                double gradeInput;
                                if (double.TryParse(Console.ReadLine(), out gradeInput))
                                {
                                    student.grade = gradeInput;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input! Please enter a valid number.");
                                }
                                Console.WriteLine($"Student created succefully --\n {student}");
                                
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Enter id to delete:");
                                
                                string? delete = Console.ReadLine();
                                try { DeleteStudent(delete, students); }
                                catch
                                {
                                    Console.WriteLine("There was an erreur");
                                }
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Enter a name to look for:");
                                var searchName = Console.ReadLine();
                                Console.WriteLine(Student.Search(searchName, students)); 
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine($"Average is: {Student.Average(students)}");
                                break;
                            }
                        case 5:
                            {
                                foreach (var student in students)
                                {
                                    Console.WriteLine("-------------");
                                    Console.WriteLine(student);
                                }
                                break;
                            }
                        case 6:
                            {
                                Console.WriteLine("Goodbye!");
                                return; // Exit the program
                            }
                        default:
                            {
                                Console.WriteLine("Invalid choice. Please try again.\n");
                                break;
                            }
                    }
                }

            }
        }

        private static bool DeleteStudent(string? delete, List<Student> students)
        {
            if (delete == null) { return false; }
            if (students == null) { Console.WriteLine("The list is empty"); return false; }
            foreach(var student in students)
            {
                if (delete == student.lname || delete == student.fname)
                {
                    students.Remove(student);
                    return true;
                }                 
            }
            Console.WriteLine("student doesnt exist");
            return false;
        }
    } 
}
