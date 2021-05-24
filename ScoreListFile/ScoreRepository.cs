using System;
using System.Collections.Generic;
using System.IO;

namespace ScoreRecord
{
    public class ScoreRepository
    {
        public List<ScoreEntity> Scores = new List<ScoreEntity>();

        public ScoreRepository()
        {
            FetchScoreInfoFromFile();
        }

        public void FetchScoreInfoFromFile()
        {
            try
            {
                var scoreInfoLines = File.ReadAllLines("ScoreList.txt");
                foreach (var scoreInfoLine in scoreInfoLines)
                {
                    var score = ScoreEntity.StringToScoreEntity(scoreInfoLine);
                    Scores.Add(score);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void GetScoreInfo()
        {
            foreach (var score in Scores)
            {
                Console.WriteLine($"Student Name: {score.StudentName}, English Score: {score.EnglishScore}, Maths Score: {score.MathScore}, Economics Score: {score.EconomicScore}");
            }
        }
        public List<ScoreEntity> ListScoreInfo()
        {
            return Scores;
        }

        public void AddStudentScores(string studentName, int englishScore, int mathScore, int economicScore)
        {
            var scoreExist = FindScoreByName(studentName);

            if (scoreExist != null)
            {
                Console.WriteLine($"Student with Name: {studentName} does not exist! ");
            }
            else
            {
                ScoreEntity score = new ScoreEntity(studentName, englishScore, mathScore, economicScore);

                Scores.Add(score);

                TextWriter writer = new StreamWriter("ScoreList.txt", true);
                writer.WriteLine(score.ToString());
                Console.WriteLine("Student score added successfully!");
                writer.Close();
            }
        }
        public void RefreshFile()
        {
            TextWriter writer = new StreamWriter("ScoreList.txt");
            foreach (var score in Scores)
            {
                writer.WriteLine(score);
            }
            writer.Flush();
            writer.Close();
        }
        public void DeleteScoreByName(string studentName)
        {
            Scores.RemoveAll(score => score.StudentName == studentName);
            RefreshFile();
            Console.WriteLine("Student Record Deleted Sucessfully!!");
        }
        public ScoreEntity FindScoreByName(string studentName)
        {
            return Scores.Find(s => s.StudentName == studentName);
        }
        public void FindScore()
        {
            Console.Write("Enter Full Name of the Student you want to Find: ");
            string studentName = Console.ReadLine().ToLower().Trim();

            var score = FindScoreByName(studentName);

            if (score == null)
            {
                Console.WriteLine($"Student with Name: {studentName} does not exist! ");
            }

            else
            {
                Console.WriteLine($"Student Name: {score.StudentName}, English Score: {score.EnglishScore}, Maths Score: {score.MathScore}, Economics Score: {score.EconomicScore}");
            }
        }
        public void UpdateScore(string studentName, int englishScore, int mathScore, int economicScore)
        {
            var score = FindScoreByName(studentName);

            if (score == null)
            {
                Console.WriteLine($"Student with Name: {studentName} does not exist! ");
            }
            else
            {
                score.EnglishScore = englishScore;
                score.MathScore = mathScore;
                score.EconomicScore = economicScore;
                Console.WriteLine("Score Updated Sucessfully!!");
            }
        }
        public void NumberOfStudentsAboveAverage()
        {
            int average = 0;
            foreach (var score in Scores)
            {
                if (score.EnglishScore + score.MathScore + score.EconomicScore > 100)
                {
                    average++;
                }
            }
            Console.WriteLine($"The number of Students that have their total score above average is: {average}");
        }

        public void BestOverallStudent()
        {
            List<int> TotalScores = new List<int>();

            foreach (var score in Scores)
            {
                int totalScore = score.EnglishScore + score.MathScore + score.EconomicScore;
                TotalScores.Add(totalScore);
            }

            int bestOverallStudent = TotalScores[0];

            for (int i = 0; i < TotalScores.Count; i++)
            {
                if (TotalScores[i] >= bestOverallStudent)
                {
                    bestOverallStudent = TotalScores[i];
                }
            }

            foreach (var score in Scores)
            {
                if(bestOverallStudent == score.EnglishScore + score.MathScore + score.EconomicScore)
                {
                    Console.WriteLine($"The Student with the overall best score is {score.StudentName}");
                }
            }
        }
    }
}
