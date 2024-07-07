using System.Text.RegularExpressions;

namespace Zborche
{
    public partial class Zborche : Form
    {
        public int NumOfTries { get; set; }

        public string TryWord { get; set; } = string.Empty;

        public Game game { get; set; }

        public string mode { get; set; }

        public Zborche()
        {
            InitializeComponent();
            Init();
            
        }

        public void Init()
        {
            CheckModeSelection();
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

        //поставување на режим
        //според изборот во првата форма
        private void CheckModeSelection()
        {
            using (var modeForm = new ModeSelectionForm())
            {
                if (modeForm.ShowDialog() == DialogResult.OK)
                {
                    mode = modeForm.gameMode;
                }
                else
                {
                    mode = "easy";
                }
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            TryWord = tbTryWord.Text;
            UpdateInfo("");
            EmptyTryWord();

            //валидација дали е внесен соодветен збор од корисникот
            if (!string.IsNullOrEmpty(TryWord) && TryWord.Length == 5)
            {
                if (game.IsEnglishAlphabet(TryWord))
                {
                    UpdateInfo("Внесете збор со македонска поддршка!");
                }
                //валидација според одбраниот режим
                else if (!game.validateTryWord(TryWord, this.mode))
                {
                    if (mode.ToLower() == "hard")
                        UpdateInfo("Внесениот збор не постои во листата со зборови.");
                    else UpdateInfo("Обидот не се прифаќа. Обидете се повторно!");
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

        //метод кој го пополнува обидот доколку 
        //внесениот збор ги поминал сите валидации
        private void FillTry()
        {
            TryWord = TryWord.ToUpper();
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
                    break;
                default:
                    break;
            }
            //поставување соодветни бои
            FillColors();
            EmptyTryWord();

            //известување кон играчот
            statusUpdate();

            //проверка дали играчот победил
            if (Won())
            {
                ifWon();
            }

            //проверка дали играчот изгубил
            else if (Lost())
            {
                ifLost();
            }
        }

        private void statusUpdate()
        {
            //метод за потсетување на корисникот
            //уште колку обиди му преостануваат
            if (NumOfTries < 5)
            {
                UpdateInfo($"Ви преостануваат уште {6 - NumOfTries} обиди.");
            }
            else
            {
                UpdateInfo($"Ви преостанува уште 1 обид.");
            }
        }

        private bool Lost()
        {
            //доколку се искористил и последниот (6) обид,
            //а не се погодил зборот 
            //(зборот е погоден кога сите полиња се зелени)
            //играчот губи
            return NumOfTries == 6 && !game.checkColors();
        }
        private bool Won()
        {
            //доколку сите полиња се зелени
            //играчот победува
            return game.checkColors();
        }

        private void ifLost()
        {
            //ако изгуби играчот
            //се испишува бараниот збор
            //и се повикува методот за крај на играта
            string word = game.gameWord.ToUpper();
            UpdateInfo($"Бараниот збор беше: {word}.");
            GameOver($"Изгубивте!\n");
        }

        private void ifWon()
        {
            //доколку играчот победи
            //се известува во колку обиди го открил зборот
            //и се повикува методот за крај на игра, со порака за честитки
            if (NumOfTries == 1)
            {
                UpdateInfo($"Браво. Го погодивте зборот во {NumOfTries} обид.");
            }
            else
            {
                UpdateInfo($"Браво. Го погодивте зборот во {NumOfTries} обиди.");
            }
            GameOver("Честитки! Победивте.\n");
        }

        //метод кој нуди нова игра или излегува од играта
        private void GameOver(string message)
        {
            message += "Дали сакате да играте повторно?";
            DialogResult result = MessageBox.Show(message, "Крај на играта", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Init();
            }
            else
            {
                Application.Exit();
            }
        }

        //метод кој ја чисти бојата на полињата за сите обиди
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

        //метод кој ги чисти полињата за сите обиди
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

        private void EmptyTryWord()
        {
            tbTryWord.Text = string.Empty;
        }
    }
}
