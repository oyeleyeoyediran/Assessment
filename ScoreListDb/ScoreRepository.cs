using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ScoreRecord
{
    public class ScoreRepository
    {
        MySqlConnection conn;

        public static List<ScoreEntity> Scores = new List<ScoreEntity>();

        public ScoreRepository(MySqlConnection connection)
        {
            conn = connection;
        }
        public bool AddScores(string studentName, int englishScore, int mathScore, int economicScore)
        {
            try
            {
                conn.Open();
                string addScore = "Insert into studentscoretable (studentName, englishScore, mathScore, economicScore)values ('" + studentName + "', '" + englishScore + "', '" + mathScore + "', '" + economicScore + "')";
                MySqlCommand command = new MySqlCommand(addScore, conn);
                Console.WriteLine("Score Added Sucessfully!");
                int Count = command.ExecuteNonQuery();
                if (Count > 0)
                {
                    conn.Close();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return false;
        }
        public ScoreEntity FindStudentScore(string studentName)
        {
            ScoreEntity student = null;
            try
            {
                conn.Open();
                string studentQuery = "Select studentName, englishScore, mathScore, economicScore from studentscoretable where studentName = '" + studentName + "'";
                MySqlCommand command = new MySqlCommand(studentQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    {
                        int englishScore = reader.GetInt32(1);
                        int mathScore = reader.GetInt32(2);
                        int economicScore = reader.GetInt32(3);
                        student = new ScoreEntity(studentName, englishScore, mathScore, economicScore);
                    }
                    Console.WriteLine($"Student Name: {reader[0]}, English Score: {reader[1]}, Maths Score: {reader[2]}, Economics Score: {reader[3]}");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return student;
        }
        public bool UpdateStudentScore(string studentName, int englishScore, int mathScore, int economicScore)
        {
            var student = FindStudentScore(studentName);
            if (student == null)
            {
                Console.WriteLine($"Student with Name: {studentName} does not exist");
            }
            try
            {
                conn.Open();
                string updateScoreQuery = "update studentscoretable set englishScore ='" + englishScore + "', mathScore = '" + mathScore + "' , economicScore = '" + economicScore + "' where studentName = '" + studentName + "'";
                MySqlCommand command = new MySqlCommand(updateScoreQuery, conn);
                int Count = command.ExecuteNonQuery();
                Console.WriteLine("Student Score Update Sucessfull!");
                if (Count > 0)
                {
                    conn.Close();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return false;
        }
        public bool DeleteStudentRecord(string studentName)
        {
            if (studentName == null)
            {
                Console.WriteLine($"Student with Name: {studentName} does not exist");
            }
            try
            {
                conn.Open();
                string deleteStudentQuery = "delete from studentscoretable where studentName = '" + studentName + "'";
                MySqlCommand command = new MySqlCommand(deleteStudentQuery, conn);
                Console.WriteLine("Student Record Deleted Sucessfully!");
                int Count = command.ExecuteNonQuery();
                if (Count > 0)
                {
                    conn.Close();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return false;
        }
        public void ListAllRecords()
        {
            List<ScoreEntity> Scores = new List<ScoreEntity>();
            try
            {
                conn.Open();
                string scoreQuery = "Select studentName, englishScore, mathScore, economicScore from studentscoretable";
                MySqlCommand command = new MySqlCommand(scoreQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Student Name: {reader[0]}, English Score: {reader[1]}, Maths Score: {reader[2]}, Economics Score: {reader[3]}");
                }
                reader.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void NumberOfStudentsAboveAverage()
        {
            List<ScoreEntity> Scores = new List<ScoreEntity>();
            try
            {
                int average =0;
                conn.Open();
                string scoreQuery = "Select studentName, englishScore, mathScore, economicScore from studentscoretable where englishScore+mathScore+economicScore > '" + 150 + "'";
                MySqlCommand command = new MySqlCommand(scoreQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    average++;
                }
                Console.WriteLine($"The number of Students that have their total score above average is: {average}");
                reader.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}