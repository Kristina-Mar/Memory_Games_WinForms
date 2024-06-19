using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memory_Games.Scores;

namespace Memory_Games
{
    public class WhichPictureWasShownOnlyOnce : BaseClassForAllGames
    {
        public override string GameName { get; } = "Game 3";
        public override string[] ListOfWordsToShowToPlayer { get; protected set; } = new string[31];
        public override string[] GameSolution { get; protected set; } = new string[1];
        public override string[] PlayerAnswers { get; protected set; } = new string[1];
        public override double PlayerTime { get; set; } = 0;
        public override int PlayerCorrectAnswers { get; protected set; } = 0;
        public override PlayerScores PlayerScore { get; protected set; }
        public override void SetUpGame()
        {
            PlayerTime = 0;
            PlayerCorrectAnswers = 0;
            string newWord;

            for (int i = 0; i < (ListOfWordsToShowToPlayer.Length - 1); i += 2)
            {
                newWord = PickAWordFromListOfAllWords();
                while (ListOfWordsToShowToPlayer.Contains(newWord))
                {
                    newWord = PickAWordFromListOfAllWords();
                }
                ListOfWordsToShowToPlayer[i] = newWord;
                ListOfWordsToShowToPlayer[i + 1] = newWord;
            }

            newWord = PickAWordFromListOfAllWords();
            while (ListOfWordsToShowToPlayer.Contains(newWord))
            {
                newWord = PickAWordFromListOfAllWords();
            }
            ListOfWordsToShowToPlayer[^1] = newWord;
            GameSolution[0] = newWord;

            Random randomOrderGenerator = new Random();
            for (int j = ListOfWordsToShowToPlayer.Length - 1; j >= 0; j--)
            {
                string originalWord = ListOfWordsToShowToPlayer[j];
                int newIndex = randomOrderGenerator.Next(j + 1);
                ListOfWordsToShowToPlayer[j] = ListOfWordsToShowToPlayer[newIndex];
                ListOfWordsToShowToPlayer[newIndex] = originalWord;
            }
        }

        public override void CheckPlayerAnswers()
        {
            if (PlayerAnswers[0] == GameSolution[0])
            {
                PlayerCorrectAnswers = 1;
            }
            PlayerScore = new PlayerScores(GameName, PlayerCorrectAnswers, PlayerTime);
        }

        public override string ShowPlayerScore()
        {
            if (PlayerCorrectAnswers == 1)
            {
                return $"You're right, congratulations! Your time: {TimeFormatting.FormatTime(PlayerTime)}.";
            }
            else
            {
                return $"Incorrect :( Better luck next time!";
            }
        }
    }
}
