using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string> { "Stefan", "James", "Leo", "Samir", "Taha" };

            List<int> grades = new List<int>();

            Console.WriteLine("Enter the students grades");

            foreach (var item in names)
            {
                Console.WriteLine(item);
                int oneGrade = int.Parse(Console.ReadLine());
                grades.Add(oneGrade);
            }

            PrintAllStudents(names, grades);


            int avg = Avrg(grades);
            int max = grades.Max();
            Console.WriteLine("The average grade in your class is {0}\r\nThe highest grade is {1}"
                , avg, max);

            EnterNewStudents(names, grades);

            Console.WriteLine("The new list of student looks like");
            PrintAllStudents(names, grades);

            Console.WriteLine("The new average is: {0}", Avrg(grades));

            BestStuents(names, grades);

            bool removed = RemoveOneStudent(names, grades);

            if (removed)
            {
                Console.WriteLine("Your class after removal");
                PrintAllStudents(names, grades);

                Console.WriteLine("The new average grade in your class is {0}\r\nThe new highest grade is {1}"
                , Avrg(grades), grades.Max());
            }

            Console.ReadKey();
        }

        private static bool RemoveOneStudent(List<string> names, List<int> grades)
        {
            bool removed = false;
            Console.WriteLine("Do you want to remove one of your students? (Y) for yes, any button else will exit");
            string remove = Console.ReadLine();

            if (remove == "y" || remove == "Y")
            {
                Console.WriteLine("Enter the name of the student that you want to remove");
                string removeStudent = Console.ReadLine().ToLower();

                if (!string.IsNullOrEmpty(removeStudent))
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (removeStudent == names[i].ToLower())
                        {
                            Console.WriteLine("I found {0}. Are you sure you want to remove?" , names[i]);
                            string sure = Console.ReadLine();
                            if (sure.Contains("y") || sure.Contains("Y"))
                            {
                                names.Remove(names[i]);
                                grades.Remove(grades[i]);
                                removed = true;
                            }
                        }
                    }
                    if (!removed)
                    {
                        Console.WriteLine("I didn't find {0} in your class", removeStudent);
                    }
                }
                else
                {
                    Console.WriteLine("You entered an invalid name");
                }
            }
            return removed;
        }

        private static void BestStuents(List<string> names, List<int> grades)
        {
            List<string> bestStudents = new List<string>();

            int bestGrade = grades.Max();

            for (int i = 0; i < grades.Count; i++)
            {
                if (grades[i] == bestGrade)
                {
                    bestStudents.Add(names[i]);
                }
            }

            Console.WriteLine("You have the highest grade in your class of {0}", bestGrade);
            Console.WriteLine("The following students have this grade:");
            foreach (var item in bestStudents)
            {
                Console.WriteLine(item);
            }
        }

        private static void EnterNewStudents(List<string> names, List<int> grades)
        {
            Console.WriteLine("Enter the number of the students that you want to add");
            int newStudentsNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter each new student name then the grade");
            for (int i = 0; i < newStudentsNumber; i++)
            {
                Console.WriteLine("Name:");
                string newName = Console.ReadLine();
                names.Add(newName);
                Console.WriteLine("Grade:");
                int newGrade = int.Parse(Console.ReadLine());
                grades.Add(newGrade);
            }
        }

        private static void PrintAllStudents(List<string> names, List<int> grades)
        {
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine("Student {0} has a grade of {1}", names[i], grades[i]);
            }
        }

        private static int Avrg(List<int> grades)
        {
            int sum = grades.Sum();
            int avg = sum / grades.Count;
            return avg;
        }
    }
}