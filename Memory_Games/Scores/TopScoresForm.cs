using Memory_Games.Scores;
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
    public partial class TopScoresForm : Form
    {
        private Panel[] _scorePanels = new Panel[5];
        public TopScoresForm(string gameName)
        {
            InitializeComponent();
            _scorePanels = [panelScore1, panelScore2, panelScore3, panelScore4, panelScore5];
            foreach (var panel in _scorePanels)
            {
                panel.Visible = false;
            }
            if (PlayerScores.ReturnOrderedBestScoresForThisGame(gameName).Count() != 0)
            {
                var orderedScores = PlayerScores.ReturnOrderedBestScoresForThisGame(gameName).OrderByDescending(p => p.CorrectAnswers).ThenBy(p => p.Time);
                for (int i = 0; i < orderedScores.Count(); i++)
                {
                    (_scorePanels[i].Controls[0] as Label).Text = orderedScores.ElementAt(i).PlayerName;
                    (_scorePanels[i].Controls[1] as Label).Text = orderedScores.ElementAt(i).CorrectAnswers.ToString();
                    (_scorePanels[i].Controls[2] as Label).Text = TimeFormatting.FormatTime(orderedScores.ElementAt(i).Time);
                    _scorePanels[i].Visible = true;
                }
            }
        }
    }
}
