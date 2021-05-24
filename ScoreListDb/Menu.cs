using System;
using MySql.Data.MySqlClient;

namespace ScoreRecord
{
    public class Menu
    {
        static string connectionString = "server=localhost;user=root;database=studentscorerecord;port=3306;password=MARVELLOUS";
        static MySqlConnection conn = new MySqlConnection(connectionString);
        ScoreRepository scoreRepo = new ScoreRepository(conn);
        private void ContactMenu()
        {
            Console.WriteLine("0. Back");
            Console.WriteLine("1. Add Student Score");
            Console.WriteLine("2. List all Scores");
            Console.WriteLine("3. Find Student Record");
            Console.WriteLine("4. Update Score");
            Console.WriteLine("5. Delete Student Record");
            Console.WriteLine("6. Total Number of People above Average");
        }
        private void AddStudentRecord()
        {
            Console.Write("Enter Student Full Name: ");
            string studentName = Console.ReadLine().ToLower().Trim();

            Console.Write("English Score: ");
            int englishScore = int.Parse(Console.ReadLine().Trim());

            Console.Write("Math Score: ");
            int mathScore = int.Parse(Console.ReadLine().Trim());

            Console.Write("English Score: ");
            int economicScore = int.Parse(Console.ReadLine().Trim());

            scoreRepo.AddScores(studentName, englishScore, mathScore, economicScore);
        }
        private void UpdateStudentScore()
        {
            Console.Write("Enter Full Name of Student you want to Update: ");
            string studentName = Console.ReadLine().ToLower().Trim();

            Console.Write("Update English Score: ");
            int englishScore = int.Parse(Console.ReadLine().Trim());

            Console.Write("Update Math Score: ");
            int mathScore = int.Parse(Console.ReadLine().Trim());

            Console.Write("Update English Score: ");
            int economicScore = int.Parse(Console.ReadLine().Trim());

            scoreRepo.UpdateStudentScore(studentName, englishScore, mathScore, economicScore);
        }
        private void DeleteStudentScore()
        {
            Console.Write("Enter name of Student you want to Delete: ");
            string studentName = Console.ReadLine().ToLower().Trim();
            scoreRepo.DeleteStudentRecord(studentName);
        }
        public void MainMenu()
        {
            ContactMenu();
            Console.Write("Option: ");
            string option = Console.ReadLine().Trim();

            switch (option)
            {
                case "0":
                    break;
                case "1":
                    AddStudentRecord();
                    MainMenu();
                    break;
                case "2":
                    scoreRepo.ListAllRecords();
                    MainMenu();
                    break;
                case "3":
                    Console.Write("Enter Full Name of the Student you want to Find: ");
                    string eMail = Console.ReadLine().ToLower().Trim();
                    Console.WriteLine("");
                    scoreRepo.FindStudentScore(eMail);
                    MainMenu();
                    break;
                case "4":
                    UpdateStudentScore();
                    MainMenu();
                    break;
                case "5":
                    DeleteStudentScore();
                    MainMenu();
                    break;
                case "6":
                    scoreRepo.NumberOfStudentsAboveAverage();
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Option!");
                    break;
            }
        }
    }
}