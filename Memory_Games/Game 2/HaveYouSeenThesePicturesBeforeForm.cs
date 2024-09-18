using Memory_Games.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Memory_Games
{
    public partial class HaveYouSeenThesePicturesBeforeForm : Form
    {
        public HaveYouSeenThesePicturesBefore Game { get; private set; } = new HaveYouSeenThesePicturesBefore();
        private int _index;
        private DateTime _gameStart;
        private int _remainingTime;
        public HaveYouSeenThesePicturesBeforeForm()
        {
            InitializeComponent();
            panelOriginalSelectionOfPictures.Visible = false;
            pictureBoxPicturesToGuess.Visible = false;
            buttonYes.Visible = false;
            buttonNo.Visible = false;
            labelInstructions.Visible = false;
            panelCountdown.Visible = false;
            labelCorrectOrIncorrect.Visible = false;
        }

        private void GoBackToGameSelection_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void StartNewGame(object sender, EventArgs e)
        {
            gameDescription.Visible = false;
            labelInstructions.Visible = false;
            buttonStartNewGame.Location = new Point(162, 24);

            foreach (PictureBox p in panelOriginalSelectionOfPictures.Controls)
            {
                p.BackgroundImage = null;
            }
            panelOriginalSelectionOfPictures.Visible = true;
            pictureBoxPicturesToGuess.Visible = false;
            buttonYes.Visible = false;
            buttonNo.Visible = false;
            labelCorrectOrIncorrect.Visible = false;
            _index = 0;

            Game = new HaveYouSeenThesePicturesBefore();
            Game.SetUpGame();

            for (int i = 0; i < Game.OriginalSelectionOfPictures.Count(); i++)
            {
                panelOriginalSelectionOfPictures.Controls[i].BackgroundImage = Resources.ResourceManager.GetObject(Game.OriginalSelectionOfPictures[i]) as Bitmap;
            }
            _remainingTime = 30;
            labelRemainingTime.Text = $"{_remainingTime.ToString()} s";
            panelCountdown.Visible = true;
            timer.Enabled = true;
            await Task.Delay(30000);

            timer.Enabled = false;
            panelCountdown.Visible = false;
            panelOriginalSelectionOfPictures.Visible = false;
            pictureBoxPicturesToGuess.Visible = true;
            buttonYes.Visible = true;
            buttonNo.Visible = true;
            buttonNo.Enabled = true;
            buttonYes.Enabled = true;
            labelInstructions.Visible = true;

            if (Resources.ResourceManager.GetObject(Game.ListOfPicturesToShowToPlayer[_index]) is Bitmap)
            {
                _gameStart = DateTime.Now;
                pictureBoxPicturesToGuess.BackgroundImage = Resources.ResourceManager.GetObject(Game.ListOfPicturesToShowToPlayer[_index]) as Bitmap;
            }
        }

        private void SubmitAnswer(object sender, EventArgs e)
        {
            string playerAnswer = ((Button)sender).Text;
            if (playerAnswer == "Yes")
            {
                Game.PlayerAnswers[_index] = Game.ListOfPicturesToShowToPlayer[_index];
            }
            ShowIfPlayerGuessedCorrectly(_index);

            if (_index < Game.ListOfPicturesToShowToPlayer.Count() - 1)
            {
                pictureBoxPicturesToGuess.BackgroundImage = Resources.ResourceManager.GetObject(Game.ListOfPicturesToShowToPlayer[_index + 1]) as Bitmap;
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
        private void ShowIfPlayerGuessedCorrectly(int index)
        {
            if (Game.GameSolution[index] == Game.PlayerAnswers[index])
            {
                labelCorrectOrIncorrect.Text = "Correct!";
                labelCorrectOrIncorrect.ForeColor = Color.Green;
            }
            else
            {
                labelCorrectOrIncorrect.Text = "Incorrect!";
                labelCorrectOrIncorrect.ForeColor = Color.Red;
            }
            labelCorrectOrIncorrect.Visible = true;
        }

        private void ShowTopScores(object sender, EventArgs e)
        {
            TopScoresForm topScores = new TopScoresForm(Game.GameName);
            topScores.Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _remainingTime--;
            labelRemainingTime.Text = $"{ _remainingTime.ToString()} s";
        }
    }
}
