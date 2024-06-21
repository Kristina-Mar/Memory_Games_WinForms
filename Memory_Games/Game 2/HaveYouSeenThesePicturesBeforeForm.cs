using Memory_Games.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Games
{
    public partial class HaveYouSeenThesePicturesBeforeForm : Form
    {
        public HaveYouSeenThesePicturesBefore Game { get; private set; } = new HaveYouSeenThesePicturesBefore();
        private int _index;
        private DateTime _gameStart;
        public HaveYouSeenThesePicturesBeforeForm()
        {
            InitializeComponent();
            panelAllCards.Visible = false;
            pictureBoxPicturesToGuess.Visible = false;
            buttonYes.Visible = false;
            buttonNo.Visible = false;
            labelInstruction.Visible = false;
        }

        private void GoBackToGameSelection_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void StartNewGame(object sender, EventArgs e)
        {
            gameDescription.Visible = false;
            labelInstruction.Visible = false;
            buttonStartNewGame.Location = new Point(162, 24);

            foreach (PictureBox p in panelAllCards.Controls)
            {
                p.BackgroundImage = null;
            }
            panelAllCards.Visible = true;
            pictureBoxPicturesToGuess.Visible = false;
            buttonYes.Visible = false;
            buttonNo.Visible = false;
            _index = 0;

            Game = new HaveYouSeenThesePicturesBefore();
            Game.SetUpGame();

            for (int i = 0; i < Game.ListOfWordsToShowToPlayer.Count(); i++)
            {
                panelAllCards.Controls[i].BackgroundImage = Resources.ResourceManager.GetObject(Game.ListOfWordsToShowToPlayer[i]) as Bitmap;
            }

            await Task.Delay(30000);

            panelAllCards.Visible = false;
            pictureBoxPicturesToGuess.Visible = true;
            buttonYes.Visible = true;
            buttonNo.Visible = true;
            buttonNo.Enabled = true;
            buttonYes.Enabled = true;
            labelInstruction.Visible = true;

            if (Resources.ResourceManager.GetObject(Game.GameSolution[_index]) is Bitmap)
            {
                _gameStart = DateTime.Now;
                pictureBoxPicturesToGuess.BackgroundImage = Resources.ResourceManager.GetObject(Game.GameSolution[_index]) as Bitmap;
            }

            if (Game.ListOfWordsToShowToPlayer.Contains(Game.GameSolution[_index]))
            {
                Game.GameSolution[_index] = "Y";
            }
            else
            {
                Game.GameSolution[_index] = "N";
            }
            _index++;
        }

        private void SubmitAnswer(object sender, EventArgs e)
        {
            switch (((Button)sender).Text)
            {
                case "Yes":
                    Game.PlayerAnswers[_index - 1] = "Y";
                    break;
                case "No":
                    Game.PlayerAnswers[_index - 1] = "N";
                    break;
            }

            if (_index < Game.GameSolution.Count())
            {
                pictureBoxPicturesToGuess.BackgroundImage = Resources.ResourceManager.GetObject(Game.GameSolution[_index]) as Bitmap;
                if (Game.ListOfWordsToShowToPlayer.Contains(Game.GameSolution[_index]))
                {
                    Game.GameSolution[_index] = "Y";
                }
                else
                {
                    Game.GameSolution[_index] = "N";
                }
                _index++;
            }
            else
            {
                Game.PlayerTime = (DateTime.Now - _gameStart).TotalSeconds;
                buttonNo.Enabled = false;
                buttonYes.Enabled = false;
                Game.CheckPlayerAnswers();
                MessageBox.Show(Game.ShowPlayerScore());
                if (Game.PlayerCorrectAnswers > 0 && Game.DidPlayerMakeItToTopScores())
                {
                    GetPlayerNameAndSaveTheirScoreForm getPlayerName = new GetPlayerNameAndSaveTheirScoreForm(Game.PlayerScore);
                    getPlayerName.Show();
                }
            }
        }

        private void ShowTopScores(object sender, EventArgs e)
        {
            TopScoresForm topScores = new TopScoresForm(Game.GameName);
            topScores.Show();
        }
    }
}
