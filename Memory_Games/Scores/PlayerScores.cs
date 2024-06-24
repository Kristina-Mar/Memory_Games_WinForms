using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Memory_Games.Scores
{
    [DataContract]
    public class PlayerScores
    {
        [DataMember]
        public string GameName { get; private set; }
        [DataMember]
        public int CorrectAnswers { get; private set; }
        [DataMember]
        public double Time { get; private set; }
        [DataMember]
        public string PlayerName { get; set; }
        [DataMember]
        public static List<PlayerScores> TopScores { get; private set; } = new List<PlayerScores>();
        private static readonly string _scoresFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Memory_Games_data", "TopScores");
        private static string _topScoresFilePath = string.Empty;
        private static readonly DataContractSerializer serializer = new DataContractSerializer(typeof(List<PlayerScores>));
        public PlayerScores()
        {

        }

        public PlayerScores(string gameName, int correctAnswers, double time)
        {
            GameName = gameName;
            CorrectAnswers = correctAnswers;
            Time = time;
        }

        public bool IsScoreAmongTopScores()
        {
            TopScores = ReturnOrderedBestScoresForThisGame(GameName).ToList();
            if (TopScores.Count() < 5)
            {
                return true;
            }
            else if (CorrectAnswers > TopScores.Last().CorrectAnswers
                || (CorrectAnswers == TopScores.Last().CorrectAnswers && Time < TopScores.Last().Time))
            {
                RemoveLowestScore(GameName);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<PlayerScores> ReturnOrderedBestScoresForThisGame(string gameName)
        {
            TopScores = LoadBestScoresFromFile(gameName);
            if (TopScores.Count() == 0)
            {
            }
            else
            {
                TopScores.OrderByDescending(p => p.CorrectAnswers).ThenBy(p => p.Time);
            }
            return TopScores;
        }

        public void AddNewScoreToTopScores()
        {
            TopScores.Add(this);
            SaveBestScoresToFile(GameName);
        }

        private static void RemoveLowestScore(string gameName)
        // Only top 5 scores are saved.
        {
            TopScores = TopScores.OrderByDescending(p => p.CorrectAnswers).ThenBy(p => p.Time).ToList();
            TopScores.RemoveAt(TopScores.Count() - 1);
        }

        private static void SetValidTopScoreFilePath(string gameName)
        {
            if (!Directory.Exists(_scoresFolderPath))
            {
                Directory.CreateDirectory(_scoresFolderPath);
            }
            _topScoresFilePath = Path.Combine(_scoresFolderPath, $"{gameName}_TopScores.txt");
            if (!File.Exists(_topScoresFilePath))
            {
                File.Create(_topScoresFilePath).Close();
            }
        }

        private static List<PlayerScores> LoadBestScoresFromFile(string gameName)
        {
            SetValidTopScoreFilePath(gameName);
            if (File.ReadAllText(_topScoresFilePath).Length != 0)
            {
                using (FileStream fileStream = new FileStream(_topScoresFilePath, FileMode.Open))
                {
                    using (XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fileStream, new XmlDictionaryReaderQuotas()))
                    {
                        TopScores = (List<PlayerScores>)serializer.ReadObject(reader, true);
                    }
                }
            }
            else
            {
                TopScores.Clear(); // So that the program doesn't use top scores from another game.
            }
            return TopScores;
        }

        private static void SaveBestScoresToFile(string gameName)
        {
            SetValidTopScoreFilePath(gameName);
            if (!File.Exists(_topScoresFilePath))
            {
                File.Create(_topScoresFilePath).Close();
            }
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t",
            };
            using (XmlWriter writer = XmlWriter.Create(_topScoresFilePath, settings))
            {
                serializer.WriteObject(writer, TopScores);
            }
        }
    }
}
