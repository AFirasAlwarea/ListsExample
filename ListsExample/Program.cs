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
            // Initializing two lists of studetns names and grades
            List<string> names = new List<string> { "Stefan", "James", "Leo", "Samir", "Taha" };
            List<int> grades = new List<int>();

            // Let the user enter grades of the students
            EnterGrades(names, grades);

            // Printing all the students
            PrintAllStudents(names, grades);


            // Printing the average and the max grades
            int avg = Avrg(grades);
            int max = grades.Max();
            Console.WriteLine("The average grade in your class is {0}\r\nThe highest grade is {1}"
                , avg, max);
            // Printing the best students
            BestStuents(names, grades);

            // Make the user select to add or remove a student, or exit

            // A boolean to exit from the menu
            bool getOut = false;
            do
            {
                Console.WriteLine("What do you want to do (Enter a number from the list below):");
                Console.WriteLine(" 1 - Enter new students \r\n 2 - Remove on student \r\n 3 - exit");
                int choice = GetNumber();
                switch (choice)
                {
                    // Let the user enter new students
                    case 1:
                        EnterNewStudents(names, grades);
                        Console.WriteLine("The new list of student looks like");

                        // Printing all the students after the addition of the new students
                        PrintAllStudents(names, grades);

                        Console.WriteLine("The new average is: {0}, and the new highest grade is {1}", Avrg(grades), grades.Max());

                        BestStuents(names, grades);
                        break;
                    // Let the user remove one student
                    case 2:
                        bool removed = RemoveOneStudent(names, grades);

                        if (removed)
                        {
                            Console.WriteLine("Your class after removal");
                            PrintAllStudents(names, grades);

                            Console.WriteLine("The new average grade in your class is {0}\r\nThe new highest grade is {1}"
                            , Avrg(grades), grades.Max());
                        }
                        break;
                    // Exit
                    case 3:
                        getOut = true;
                        break;
                    default:
                        Console.WriteLine("Please from 1 to 3 only");
                        break;
                }
            } while (!getOut);
        }

        #region Enter Grades Method
        /// <summary>
        /// Enter the grades for the students
        /// </summary>
        /// <param name="names"></param>
        /// <param name="grades"></param>
        private static void EnterGrades(List<string> names, List<int> grades)
        {
            Console.WriteLine("Enter the students grades");
            foreach (var item in names)
            {
                Console.WriteLine(item);
                int oneGrade = GetNumber();
                grades.Add(oneGrade);
            }
        }
        #endregion

        #region Remove One Student
        /// <summary>
        /// Get a name of a student and remove it with is grade from the class
        /// </summary>
        /// <param name="names"></param>
        /// <param name="grades"></param>
        /// <returns>Boolean that a student has been removed</returns>
        private static bool RemoveOneStudent(List<string> names, List<int> grades)
        {
            // Boolean tells that a student has been removed
            bool removed = false;

            // Ask the user if he wants to remove a student
            Console.WriteLine("Do you want to remove one of your students? (Y) for yes, any button else will exit");
            string remove = Console.ReadLine();
            // Check if the user entered y that he wants to remove
            if (remove == "y" || remove == "Y")
            {
                Console.WriteLine("Enter the name of the student that you want to remove");
                string removeStudent = Console.ReadLine().ToLower();
                // Check if the user did enter a valid string for a name
                if (!string.IsNullOrEmpty(removeStudent))
                {
                    // Search for the name of the student
                    for (int i = 0; i < names.Count; i++)
                    {
                        // There are better ways to check strings matching
                        if (removeStudent == names[i].ToLower())
                        {
                            // Ask the user if he is sure to remove the student
                            Console.WriteLine("I found {0}. Are you sure you want to remove?", names[i]);
                            string sure = Console.ReadLine();
                            if (sure.Contains("y") || sure.Contains("Y"))
                            {
                                names.Remove(names[i]);
                                grades.Remove(grades[i]);
                                removed = true;
                            }
                        }
                    }
                    // If there is no student matching the name, so he is not removed and not found in the class
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
        #endregion

        #region Best Students
        /// <summary>
        /// Creating a list of best students
        /// </summary>
        /// <param name="names"></param>
        /// <param name="grades"></param>
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
        #endregion

        #region New Students
        /// <summary>
        /// Get a number of new students and add it to both lists of names and grades
        /// </summary>
        /// <param name="names"></param>
        /// <param name="grades"></param>
        private static void EnterNewStudents(List<string> names, List<int> grades)
        {
            Console.WriteLine("Enter the number of the students that you want to add");
            int newStudentsNumber = GetNumber();
            Console.WriteLine("Enter each new student name then the grade");
            for (int i = 0; i < newStudentsNumber; i++)
            {
                Console.WriteLine("Name:");
                string newName = Console.ReadLine();
                names.Add(newName);
                Console.WriteLine("Grade:");
                int newGrade = GetNumber();
                grades.Add(newGrade);
            }
        }
        #endregion

        #region Printing Names and Grades
        private static void PrintAllStudents(List<string> names, List<int> grades)
        {
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine("Student {0} has a grade of {1}", names[i], grades[i]);
            }
        }
        #endregion

        #region Average Calculations
        /// <summary>
        /// Calculating the average grade in the class
        /// </summary>
        /// <param name="grades"></param>
        /// <returns>integar of average</returns>
        private static int Avrg(List<int> grades)
        {
            int sum = grades.Sum();
            int avg = sum / grades.Count;
            return avg;
        }
        #endregion

        #region Getting Integer
        /// <summary>
        /// Let the user enter an integer and check it, handling errors
        /// </summary>
        /// <returns></returns>
        private static int GetNumber()
        {
            int number = 0;
            bool succeeded = false;

            do
            {
                string sNumber = Console.ReadLine();
                try
                {
                    number = int.Parse(sNumber);
                    succeeded = true;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("You entered too big number, try again!");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("You entered nothing, try again!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("You should enter only integer numbers, try again!");
                }
            } while (!succeeded);
            return number;
        }
        #endregion
    }
}