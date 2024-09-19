using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memory_Games.Properties;
using Memory_Games.Scores;

namespace Memory_Games
{
    public abstract class BaseClassForAllGames
    {
        public static List<string> AllPictures = new List<string>();

        public abstract string GameName { get; }
        public abstract string[] ListOfPicturesToShowToPlayer { get; protected set; }
        public abstract string[] GameSolution { get; protected set; }
        public abstract string[] PlayerAnswers { get; protected set; }
        public abstract double PlayerTime { get; set; }
        public abstract int PlayerCorrectAnswers { get; protected set; }
        public abstract PlayerScores PlayerScore { get; protected set; }

        private Random _randomIndexGenerator = new Random();

        protected string PickNewPicture()
        {
            int i = _randomIndexGenerator.Next(AllPictures.Count);
            return AllPictures[i];
        }

        public abstract void SetUpGame();
        public abstract void CheckPlayerPoints();
        public abstract string ShowPlayerScore();
        public virtual bool DidPlayerMakeItToTopScores()
        {
            return PlayerScore.IsScoreAmongTopScores();
        }
    }
}
