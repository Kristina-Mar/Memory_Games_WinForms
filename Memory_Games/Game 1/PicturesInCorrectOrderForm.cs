using Memory_Games.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Games
{
    public partial class PicturesInCorrectOrderForm : Form
    {
        public PictureBox sourcePictureBox { get; private set; } = new PictureBox();
        public PictureBox[] pictureBoxAnswers { get; private set; } = new PictureBox[10];
        public PictureBox[] pictureBoxOptions { get; private set; } = new PictureBox[10];
        public PicturesInCorrectOrder Game { get; private set; } = new PicturesInCorrectOrder();

        private DateTime _gameStart;

        public PicturesInCorrectOrderForm()
        {
            InitializeComponent();

            pictureBoxAnswers = [ pictureBoxAnswer1, pictureBoxAnswer2, pictureBoxAnswer3, pictureBoxAnswer4, pictureBoxAnswer5,
            pictureBoxAnswer6, pictureBoxAnswer7, pictureBoxAnswer8, pictureBoxAnswer9, pictureBoxAnswer10];

            foreach (PictureBox p in panelAnswers.Controls)
            {
                p.AllowDrop = true;
            }

            pictureBoxOptions = [ pictureBoxOption1, pictureBoxOption2, pictureBoxOption3, pictureBoxOption4, pictureBoxOption5,
            pictureBoxOption6, pictureBoxOption7, pictureBoxOption8, pictureBoxOption9, pictureBoxOption10];

            panelAnswers.Visible = false;
            panelOptions.Visible = false;
            buttonSubmitAnswers.Visible = false;
            pictureBoxShowingImages.Visible = false;
            labelInstruction.Visible = false;
        }

        private void GoBackToGameSelection(object sender, EventArgs e)
        {
            Close();
        }

        private async void StartNewGame(object sender, EventArgs e)
        {
            panelAnswers.Visible = false;
            panelOptions.Visible = false;
            buttonSubmitAnswers.Visible = false;
            pictureBoxShowingImages.Visible = true;
            buttonStartNewGame.Location = new Point(137, 45);
            gameDescription.Visible = false;
            labelInstruction.Visible = false;

            foreach (PictureBox p in panelAnswers.Controls)
            {
                p.BackgroundImage = null;
                p.Tag = null;
            }

            Game = new PicturesInCorrectOrder();
            Game.SetUpGame();

            foreach (string word in Game.ListOfWordsToShowToPlayer)
            {
                if (Resources.ResourceManager.GetObject(word) is Bitmap)
                {
                    pictureBoxShowingImages.BackgroundImage = Resources.ResourceManager.GetObject(word) as Bitmap;
                    await Task.Delay(2000);
                }
            }
            pictureBoxShowingImages.Visible = false;
            panelOptions.Visible = true;
            panelAnswers.Visible = true;

            var orderedList = Game.ListOfWordsToShowToPlayer.Order();

            for (int i = 0; i < 10; i++)
            {
                pictureBoxOptions[i].BackgroundImage = Resources.ResourceManager.GetObject(orderedList.ElementAt(i)) as Bitmap;
                pictureBoxOptions[i].Tag = orderedList.ElementAt(i);
            }
            buttonSubmitAnswers.Visible = true;
            labelInstruction.Visible = true;
            _gameStart = DateTime.Now;
        }

        private void pictureBoxSource_MouseDown_DoDragDrop(object sender, MouseEventArgs e)
        {
            sourcePictureBox = (PictureBox)sender;
            if (sourcePictureBox.BackgroundImage != null)
            {
                DoDragDrop(sourcePictureBox.BackgroundImage, DragDropEffects.Move);
            }
        }

        private void pictureBoxTarget_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void pictureBoxTarget_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox destination = (PictureBox)sender;
            if (destination.BackgroundImage == null)
            {
                destination.BackgroundImage = (Bitmap)e.Data.GetData(typeof(Bitmap));
                destination.Tag = sourcePictureBox.Tag;
                sourcePictureBox.BackgroundImage = null;
                sourcePictureBox.Tag = null;
                sourcePictureBox = null;
            }
        }

        private void SubmitAnswers(object sender, EventArgs e)
        {
            Game.PlayerTime = (DateTime.Now - _gameStart).TotalSeconds;
            for (int i = 0; i < 10; i++)
            {
                if (pictureBoxAnswers[i].Tag is not null)
                {
                    Game.PlayerAnswers[i] = pictureBoxAnswers[i].Tag.ToString();
                }
                else
                {
                    Game.PlayerAnswers[i] = "";
                }
            }
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
