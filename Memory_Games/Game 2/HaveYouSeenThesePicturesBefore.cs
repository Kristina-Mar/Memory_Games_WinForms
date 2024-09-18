using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memory_Games.Scores;

namespace Memory_Games
{
    public class HaveYouSeenThesePicturesBefore : BaseClassForAllGames
    {
        public override string GameName { get; } = "Game 2";
        public string[] OriginalSelectionOfPictures { get; protected set; } = new string[30];
        public override string[] ListOfPicturesToShowToPlayer { get; protected set; } = new string[10];
        public override string[] GameSolution { get; protected set; } = new string[10];
        public override string[] PlayerAnswers { get; protected set; } = new string[10];
        public override int PlayerCorrectAnswers { get; protected set; } = 0;
        public override double PlayerTime { get; set; } = 0;
        public override PlayerScores PlayerScore { get; protected set; }

        public override void SetUpGame()
        {
            PlayerCorrectAnswers = 0;
            PlayerTime = 0;
            string newPicture = PickNewPicture();
            for (int i = 0; i < OriginalSelectionOfPictures.Length; i++)
            {
                while (OriginalSelectionOfPictures.Contains(newPicture))
                {
                    newPicture = PickNewPicture();
                }
                OriginalSelectionOfPictures[i] = newPicture;
            }

            newPicture = PickNewPicture();
            for (int i = 0; i < ListOfPicturesToShowToPlayer.Length; i++)
            {
                while (ListOfPicturesToShowToPlayer.Contains(newPicture))
                {
                    newPicture = PickNewPicture();
                }
                ListOfPicturesToShowToPlayer[i] = newPicture;

                if(OriginalSelectionOfPictures.Contains(newPicture))
                {
                    GameSolution[i] = newPicture;
                }
            }
        }

        public override void CheckPlayerAnswers()
        {
            for (int i = 0; i < PlayerAnswers.Length; i++)
            {
                if (PlayerAnswers[i] == GameSolution[i])
                {
                    PlayerCorrectAnswers++;
                }
            }
            PlayerScore = new PlayerScores(GameName, PlayerCorrectAnswers, PlayerTime);
        }

        public override string ShowPlayerScore()
        {
            if (PlayerCorrectAnswers == 0)
            {
                return "No correct answers :( Better luck next time!";
            }
            else
            {
                return $"Correct answers: {PlayerCorrectAnswers}, time: {TimeFormatting.FormatTime(PlayerTime)}.";
            }
        }
    }
}
