using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory_Games.Scores;

namespace Memory_Games
{
    public partial class GetPlayerNameAndSaveTheirScoreForm : Form
    {
        private PlayerScores PlayerScore { get; set; }
        public GetPlayerNameAndSaveTheirScoreForm(PlayerScores playerScore)
        {
            InitializeComponent();
            labelWarning.Visible = false;
            PlayerScore = playerScore;
        }

        private void SubmitNameAndAddScoreToBestScores(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPlayerName.Text))
            {
                labelWarning.Visible = true;
            }
            else
            {
                PlayerScore.PlayerName = textBoxPlayerName.Text.ToString();
                PlayerScore.AddNewScoreToTopScores();
                Close();
            }
        }

        private void ShowTopScoresAfterClosing(object sender, FormClosedEventArgs e)
        {
            TopScoresForm topScores = new TopScoresForm(PlayerScore.GameName);
            topScores.Show();
        }

        private void textBoxPlayerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               buttonSubmitName.PerformClick();
            }
        }
    }
}
