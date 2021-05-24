using System;
using System.Collections.Generic;

namespace ScoreRecord
{
    public class Menu
    {
       static ScoreRepository scoreRepo = new ScoreRepository();

        private void ShowMenu()
        {
            Console.WriteLine("0. Back");
            Console.WriteLine("1. Add Student Score");
            Console.WriteLine("2. List all Scores");
            Console.WriteLine("3. Find Student Record");
            Console.WriteLine("4. Update Score");
            Console.WriteLine("5. Delete Student Record");
            Console.WriteLine("6. Total Number of People above Average");
            Console.WriteLine("7. Get Overall Best Student");
        }

        public void AddScoreDetails()
        {
            Console.Write("Enter Student Full Name: ");
            string studentName = Console.ReadLine().ToLower().Trim();

            Console.Write("English Score: ");
            int englishScore = int.Parse(Console.ReadLine().Trim());

            Console.Write("Math Score: ");
            int mathScore = int.Parse(Console.ReadLine().Trim());

            Console.Write("Economics Score: ");
            int economicScore = int.Parse(Console.ReadLine().Trim());

            scoreRepo.AddStudentScores(studentName, englishScore, mathScore, economicScore);
        }

        public void UpdateScoreDetails()
        {
            Console.Write("Enter Full Name of Student you want to Update: ");
            string studentName = Console.ReadLine().ToLower().Trim();

            Console.Write("Update English Score: ");
            int englishScore = int.Parse(Console.ReadLine().Trim());

            Console.Write("Update Math Score: ");
            int mathScore = int.Parse(Console.ReadLine().Trim());

            Console.Write("Update Economics Score: ");
            int economicScore = int.Parse(Console.ReadLine().Trim());

            scoreRepo.UpdateScore(studentName, englishScore, mathScore, economicScore);
            scoreRepo.RefreshFile();
        }

        public void DeleteStudentRecord()
        {
            Console.Write("Enter name of Student you want to Delete: ");
            string studentName = Console.ReadLine().ToLower().Trim();

            Console.Write("Are you sure you want to delete? (y/n) ");
            string option = Console.ReadLine().ToLower();

            if(option == "y")
            {
                scoreRepo.DeleteScoreByName(studentName);
            }

            else
            {
                ShowMenu();
            }
        }
        public void ShowScoreMenu()
        {
            ShowMenu();
            Console.Write("Option: ");
            string option = Console.ReadLine().Trim();

            switch (option)
            {
                case "0":
                    break;
                case "1":
                    AddScoreDetails();
                    ShowScoreMenu();
                    break;
                case "2":
                    scoreRepo.GetScoreInfo();
                    ShowScoreMenu();
                    break;

                case "3":
                    scoreRepo.FindScore();
                    ShowScoreMenu();
                    break;

                case "4":
                    UpdateScoreDetails();
                    ShowScoreMenu();
                    break;

                case "5":
                    DeleteStudentRecord();
                    ShowScoreMenu();
                    break;
                case "6":
                    scoreRepo.NumberOfStudentsAboveAverage();
                    ShowScoreMenu();
                    break;
                    case "7":
                    scoreRepo.BestOverallStudent();
                    break;
                default:
                    Console.WriteLine("Invalid Option!");
                    break;
            }
        }
    }
}