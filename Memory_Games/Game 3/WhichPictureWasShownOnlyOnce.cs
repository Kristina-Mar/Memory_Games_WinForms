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
        public override string[] ListOfPicturesToShowToPlayer { get; protected set; } = new string[31];
        public override string[] GameSolution { get; protected set; } = new string[1];
        public override string[] PlayerAnswers { get; protected set; } = new string[1];
        public override double PlayerTime { get; set; } = 0;
        public override int PlayerCorrectAnswers { get; protected set; } = 0;
        public override PlayerScores PlayerScore { get; protected set; }
        public override void SetUpGame()
        {
            PlayerTime = 0;
            PlayerCorrectAnswers = 0;
            string newPicture;

            for (int i = 0; i < (ListOfPicturesToShowToPlayer.Length - 1); i += 2)
            {
                newPicture = PickNewPicture();
                while (ListOfPicturesToShowToPlayer.Contains(newPicture))
                {
                    newPicture = PickNewPicture();
                }
                ListOfPicturesToShowToPlayer[i] = newPicture;
                ListOfPicturesToShowToPlayer[i + 1] = newPicture;
            }

            newPicture = PickNewPicture();
            while (ListOfPicturesToShowToPlayer.Contains(newPicture))
            {
                newPicture = PickNewPicture();
            }
            ListOfPicturesToShowToPlayer[^1] = newPicture;
            GameSolution[0] = newPicture;

            Random randomOrderGenerator = new Random();
            for (int j = ListOfPicturesToShowToPlayer.Length - 1; j >= 0; j--)
            {
                string originalPicture = ListOfPicturesToShowToPlayer[j];
                int newIndex = randomOrderGenerator.Next(j + 1);
                ListOfPicturesToShowToPlayer[j] = ListOfPicturesToShowToPlayer[newIndex];
                ListOfPicturesToShowToPlayer[newIndex] = originalPicture;
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
