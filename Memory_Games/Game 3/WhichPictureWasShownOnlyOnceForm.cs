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
    public partial class WhichPictureWasShownOnlyOnceForm : Form
    {
        public WhichPictureWasShownOnlyOnce Game { get; private set; } = new WhichPictureWasShownOnlyOnce();
        private DateTime _gameStart;
        public WhichPictureWasShownOnlyOnceForm()
        {
            InitializeComponent();
            panelOptions.Visible = false;
            pictureBoxShowingPictures.Visible = false;
            labelPictureNumber.Visible = false;
            labelInstructions.Visible = false;
        }

        private void GoBackToGameSelection(object sender, EventArgs e)
        {
            Close();
        }

        private async void StartNewGame(object sender, EventArgs e)
        {
            gameDescription.Visible = false;
            buttonStartNewGame.Location = new Point(155, 20);
            foreach (PictureBox p in panelOptions.Controls)
            {
                p.BackgroundImage = null;
            }
            panelOptions.Visible = false;
            pictureBoxShowingPictures.Visible = true;
            labelPictureNumber.Visible = true;
            labelInstructions.Visible = false;

            Game = new WhichPictureWasShownOnlyOnce();
            Game.SetUpGame();

            for (int i = 0; i < Game.ListOfPicturesToShowToPlayer.Count(); i++)
            {
                if (Resources.ResourceManager.GetObject(Game.ListOfPicturesToShowToPlayer[i]) is Bitmap)
                {
                    pictureBoxShowingPictures.BackgroundImage = Resources.ResourceManager.GetObject(Game.ListOfPicturesToShowToPlayer[i]) as Bitmap;
                }
                pictureBoxShowingPictures.Refresh();
                labelPictureNumber.Text = $"Picture number {i + 1}:";
                await Task.Delay(2000);
            }

            pictureBoxShowingPictures.Visible = false;
            labelPictureNumber.Visible = false;
            panelOptions.Visible = true;
            panelOptions.Enabled = true;

            List<string> uniqueValues = Game.ListOfPicturesToShowToPlayer.Distinct().Order().ToList();
            for (int i = 0; i < uniqueValues.Count; i++)
            {
                if (Resources.ResourceManager.GetObject(uniqueValues[i]) is Bitmap)
                {
                    panelOptions.Controls[i].BackgroundImage = Resources.ResourceManager.GetObject(uniqueValues[i]) as Bitmap;
                    panelOptions.Controls[i].Tag = uniqueValues[i];
                }
            }
            labelInstructions.Visible = true;
            _gameStart = DateTime.Now;
        }

        private void SubmitAnswerByClickingOnPicture(object sender, EventArgs e)
        {
            Game.PlayerTime = (DateTime.Now - _gameStart).TotalSeconds;
            panelOptions.Enabled = false;
            Game.PlayerAnswers[0] = ((PictureBox)sender).Tag.ToString();
            Game.CheckPlayerAnswers();
            MessageBox.Show(Game.ShowPlayerScore());
            if (Game.PlayerCorrectAnswers > 0 && Game.DidPlayerMakeItToTopScores())
            {
                GetPlayerNameAndSaveTheirScoreForm getPlayerName = new GetPlayerNameAndSaveTheirScoreForm(Game.PlayerScore);
                getPlayerName.Show();
            }
        }

        private void ShowTopScores(object sender, EventArgs e)
        {
            TopScoresForm topScores = new TopScoresForm(Game.GameName);
            topScores.Show();
        }
    }
}
