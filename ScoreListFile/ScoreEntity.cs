using System;
namespace ScoreRecord
{
    public class ScoreEntity
    {
        public string StudentName { get; set; }
        public int EnglishScore { get; set; }
        public int MathScore { get; set; }
        public int EconomicScore { get; set; }

        public ScoreEntity(string studentName, int englishScore, int mathScore, int economicScore)
        {
            StudentName = studentName;
            EnglishScore = englishScore;
            MathScore = mathScore;
            EconomicScore = economicScore;
        }

        public override string ToString()
        {
            return $"{StudentName}\t{EnglishScore}\t{MathScore}\t{EconomicScore}";
        }

        internal static ScoreEntity StringToScoreEntity(string scoreString)
        {
            var props = scoreString.Split("\t");

            int englishScore = int.Parse(props[1]);

            int mathScore = int.Parse(props[2]);

            int economicScore = int.Parse(props[3]);

            return new ScoreEntity(props[0], englishScore, mathScore, economicScore);
        }
    }

}