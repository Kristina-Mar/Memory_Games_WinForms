using Memory_Games.Properties;
using System.Collections;
using System.Globalization;
using System.Resources;

namespace Memory_Games
{
    public partial class GameSelection : Form
    {
        private List<string> AllWordsFromResources { get; set; } = new List<string>();
        public GameSelection()
        {
            InitializeComponent();

            foreach (DictionaryEntry v in Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true))
            {
                AllWordsFromResources.Add(v.Key.ToString());
            }
            BaseClassForAllGames.AllWords = AllWordsFromResources;
        }

        private void buttonGame1_Click(object sender, EventArgs e)
        {
            Form game1Form = new PicturesInCorrectOrderForm();
            game1Form.ShowDialog();
        }

        private void buttonGame2_Click(object sender, EventArgs e)
        {
            Form game2Form = new HaveYouSeenThesePicturesBeforeForm();
            game2Form.ShowDialog();
        }

        private void buttonGame3_Click(object sender, EventArgs e)
        {
            Form game3Form = new WhichPictureWasShownOnlyOnceForm();
            game3Form.ShowDialog();
        }

    }
}
