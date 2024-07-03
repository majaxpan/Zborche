using System.Text.RegularExpressions;

namespace Zborche
{
    public partial class Zborche : Form
    {
        public int NumOfTries { get; set; }

        public string TryWord { get; set; } = string.Empty;

        public Game game { get; set; }

        public Zborche()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            game = new Game();
            NumOfTries = 0;
            TryWord = string.Empty;
            tbTryWord.Text = string.Empty;
            UpdateInfo("");
            ClearAllTryLetters();
            clearBackColor();
            //for testing purpose only
            lblTemp.Text = game.gameWord;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            TryWord = tbTryWord.Text;
            UpdateInfo("");

            if (!checkTryWord(TryWord)) 
            {
                UpdateInfo("Внесениот збор не постои во листата на зборови.");
            }
            else
            {
                if (!string.IsNullOrEmpty(TryWord) && TryWord.Length == 5)
                {
                    if (IsEnglishAlphabet())
                    {
                        UpdateInfo("Внесете збор со македонска поддршка!");
                    }
                    else
                    {
                        NumOfTries++;
                        game.checkWord(TryWord);
                        FillTry();
                    }
                }
                else
                {
                    UpdateInfo("Внесете збор кој содржи точно 5 букви!");
                }
            }
        }

        private bool checkTryWord(string word)
        {
            return game.holder.wordsList.Contains(word);
        }

        private void FillColors()
        {
            switch (this.NumOfTries)
            {
                case 1:
                    o1b1.BackColor = game.colors[0];
                    o1b2.BackColor = game.colors[1];
                    o1b3.BackColor = game.colors[2];
                    o1b4.BackColor = game.colors[3];
                    o1b5.BackColor = game.colors[4];
                    break;
                case 2:
                    o2b1.BackColor = game.colors[0];
                    o2b2.BackColor = game.colors[1];
                    o2b3.BackColor = game.colors[2];
                    o2b4.BackColor = game.colors[3];
                    o2b5.BackColor = game.colors[4];
                    break;
                case 3:
                    o3b1.BackColor = game.colors[0];
                    o3b2.BackColor = game.colors[1];
                    o3b3.BackColor = game.colors[2];
                    o3b4.BackColor = game.colors[3];
                    o3b5.BackColor = game.colors[4];
                    break;
                case 4:
                    o4b1.BackColor = game.colors[0];
                    o4b2.BackColor = game.colors[1];
                    o4b3.BackColor = game.colors[2];
                    o4b4.BackColor = game.colors[3];
                    o4b5.BackColor = game.colors[4];
                    break;
                case 5:
                    o5b1.BackColor = game.colors[0];
                    o5b2.BackColor = game.colors[1];
                    o5b3.BackColor = game.colors[2];
                    o5b4.BackColor = game.colors[3];
                    o5b5.BackColor = game.colors[4];
                    break;
                case 6:
                    o6b1.BackColor = game.colors[0];
                    o6b2.BackColor = game.colors[1];
                    o6b3.BackColor = game.colors[2];
                    o6b4.BackColor = game.colors[3];
                    o6b5.BackColor = game.colors[4];
                    break;
                default:
                    break;
            }
        }

        private void FillTry()
        {
            switch (this.NumOfTries)
            {
                case 1:
                    o1b1.Text = TryWord[0].ToString();
                    o1b2.Text = TryWord[1].ToString();
                    o1b3.Text = TryWord[2].ToString();
                    o1b4.Text = TryWord[3].ToString();
                    o1b5.Text = TryWord[4].ToString();
                    break;
                case 2:
                    o2b1.Text = TryWord[0].ToString();
                    o2b2.Text = TryWord[1].ToString();
                    o2b3.Text = TryWord[2].ToString();
                    o2b4.Text = TryWord[3].ToString();
                    o2b5.Text = TryWord[4].ToString();
                    break;
                case 3:
                    o3b1.Text = TryWord[0].ToString();
                    o3b2.Text = TryWord[1].ToString();
                    o3b3.Text = TryWord[2].ToString();
                    o3b4.Text = TryWord[3].ToString();
                    o3b5.Text = TryWord[4].ToString();
                    break;
                case 4:
                    o4b1.Text = TryWord[0].ToString();
                    o4b2.Text = TryWord[1].ToString();
                    o4b3.Text = TryWord[2].ToString();
                    o4b4.Text = TryWord[3].ToString();
                    o4b5.Text = TryWord[4].ToString();
                    break;
                case 5:
                    o5b1.Text = TryWord[0].ToString();
                    o5b2.Text = TryWord[1].ToString();
                    o5b3.Text = TryWord[2].ToString();
                    o5b4.Text = TryWord[3].ToString();
                    o5b5.Text = TryWord[4].ToString();
                    break;
                case 6:
                    o6b1.Text = TryWord[0].ToString();
                    o6b2.Text = TryWord[1].ToString();
                    o6b3.Text = TryWord[2].ToString();
                    o6b4.Text = TryWord[3].ToString();
                    o6b5.Text = TryWord[4].ToString();

                    //game ended, you either won or used all your tries
                    //gameOver(string message)
                    //GameOver("");
                    break;
                default:
                    break;
            }
            FillColors();
            tbTryWord.Text = string.Empty;

            if (game.checkColors())
                GameOver("You won!");
            else if(NumOfTries == 6 && !game.checkColors())
                GameOver("You lost!");
            
        }

        private void GameOver(string message)
        {
            message += " Do you want to play again?";
            DialogResult result = MessageBox.Show(message, "Prompt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Init();
            }
            else
            {
                Application.Exit();
            }
        }

        private void clearBackColor()
        {
            o1b1.BackColor = Color.White;
            o1b2.BackColor = Color.White;
            o1b3.BackColor = Color.White;
            o1b4.BackColor = Color.White;
            o1b5.BackColor = Color.White;

            o2b1.BackColor = Color.White;
            o2b2.BackColor = Color.White;           
            o2b3.BackColor = Color.White;
            o2b4.BackColor = Color.White;
            o2b5.BackColor = Color.White;

            o3b1.BackColor = Color.White;
            o3b2.BackColor = Color.White;
            o3b3.BackColor = Color.White;
            o3b4.BackColor = Color.White;
            o3b5.BackColor = Color.White;

            o4b1.BackColor = Color.White;
            o4b2.BackColor = Color.White;
            o4b3.BackColor = Color.White;
            o4b4.BackColor = Color.White;
            o4b5.BackColor = Color.White;

            o5b1.BackColor = Color.White;
            o5b2.BackColor = Color.White;
            o5b3.BackColor = Color.White;
            o5b4.BackColor = Color.White;
            o5b5.BackColor = Color.White;

            o6b1.BackColor = Color.White;
            o6b2.BackColor = Color.White;
            o6b3.BackColor = Color.White;
            o6b4.BackColor = Color.White;
            o6b5.BackColor = Color.White;
        }

        private void ClearAllTryLetters()
        {
            o1b1.Text = " ";
            o1b2.Text = " ";
            o1b3.Text = " ";
            o1b4.Text = " ";
            o1b5.Text = " ";

            o2b1.Text = " ";
            o2b2.Text = " ";
            o2b3.Text = " ";
            o2b4.Text = " ";
            o2b5.Text = " ";

            o3b1.Text = " ";
            o3b2.Text = " ";
            o3b3.Text = " ";
            o3b4.Text = " ";
            o3b5.Text = " ";

            o4b1.Text = " ";
            o4b2.Text = " ";
            o4b3.Text = " ";
            o4b4.Text = " ";
            o4b5.Text = " ";

            o5b1.Text = " ";
            o5b2.Text = " ";
            o5b3.Text = " ";
            o5b4.Text = " ";
            o5b5.Text = " ";

            o6b1.Text = " ";
            o6b2.Text = " ";
            o6b3.Text = " ";
            o6b4.Text = " ";
            o6b5.Text = " ";
        }

        private void UpdateInfo(string info)
        {
            tbInfo.Text = info;
        }

        private bool IsEnglishAlphabet()
        {
            // Regular expression to check if the word contains only English letters
            Regex regex = new Regex("^[a-zA-Z]+$");
            return regex.IsMatch(TryWord);
        }
    }
}
