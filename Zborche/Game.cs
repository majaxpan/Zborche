using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Zborche
{
    public class Game
    {
        public DataHolder holder { get; set; }

        public WordPicker picker { get; set; }

        public string gameWord { get; set; }

        public Color[] colors { get; set; }

        public Game()
        {
            holder = new DataHolder();
            picker = new WordPicker();
            gameWord = picker.pickWord(holder.wordsSet);
            colors = new Color[5];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = Color.LightGray;
            }
        }

        //главната логика во играта
        //која одредува дали внесените букви во зборот
        //се среќаваат во зборот селектиран од играта
        public void checkWord(string tryWord)
        {
            bool[] matched = new bool[gameWord.Length];
            Dictionary<char, int> letterCount = new Dictionary<char, int>();

            //броење на појавувања за секоја буква во избраниот збор
            foreach (char c in gameWord)
            {
                if (letterCount.ContainsKey(c))
                {
                    letterCount[c]++;
                }
                else
                {
                    letterCount[c] = 1;
                }
            }

            // Прва проверка
            // точна буква и точна позиција
            // ги маркира и обојува
            for (int i = 0; i < colors.Length; i++)
            {
                if (tryWord[i] == gameWord[i])
                {
                    colors[i] = Color.LightGreen;
                    matched[i] = true;
                    letterCount[tryWord[i]]--;
                }
                else
                {
                    colors[i] = Color.LightGray;
                }
            }

            // Втора проверка
            // точна буква и погрешна позиција
            // споредува со преостанатите
            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i] == Color.LightGreen)
                {
                    continue; // Прескокни ги зелените букви (точните букви на точна позиција)
                }

                if (letterCount.ContainsKey(tryWord[i]) && letterCount[tryWord[i]] > 0)
                {
                    int tryLetterCount = tryWord.Count(c => c == tryWord[i]);
                    int gameLetterCount = gameWord.Count(c => c == tryWord[i]);

                    if (tryLetterCount > 1 && gameLetterCount > 1)
                    {
                        colors[i] = Color.LightYellow; // повеќе појавувања во tryWord и gameWord на буква
                        letterCount[tryWord[i]]--; 
                    }
                    else if (tryLetterCount == 1 && gameLetterCount > 1)
                    {
                        colors[i] = Color.LightBlue; // повеќе појавувања во gameWord но едно појавување во tryWord на буква
                        letterCount[tryWord[i]]--; 
                    }
                    else
                    {
                        colors[i] = Color.LightYellow;
                        letterCount[tryWord[i]]--; 
                    }
                }
                else
                {
                    colors[i] = Color.LightGray;
                }
            }

            //повеќе појавувања на една буква во tryWord, а се среќава во помалку појавувања во game word
            Dictionary<char, int> tryWordLetterCount = new Dictionary<char, int>();
            for (int i = 0; i < tryWord.Length; i++)
            {
                if (!tryWordLetterCount.ContainsKey(tryWord[i]))
                {
                    tryWordLetterCount[tryWord[i]] = 1;
                }
                else
                {
                    tryWordLetterCount[tryWord[i]]++;
                    if (tryWordLetterCount[tryWord[i]] > gameWord.Count(c => c == tryWord[i]))
                    {
                        colors[i] = Color.LightGray; // повеќе појавувања во tryWord отколку во gameWord
                    }
                }
            }
        }

        //метод кој се повикува
        //кога се врши проверка 
        //дали е погоден зборот
        public bool checkColors()
        {
            int flag = 0;
            foreach(Color c in colors)
            {
                if (c.Equals(Color.LightGreen))
                    flag++;
            }
            return flag == 5;
        }


        //проверка дали сите внесени карактери се всушност букви
        private bool easyValidate(string word)
        {
            foreach (char c in word)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        //проверка дали играчот се обидува да одреди 
        //на која точно позиција се наоѓа одредена буква
        //притоа внесувајќи ја само истата на сите позиции
        private bool mediumValidate(string word)
        {
            for (int i = 0; i <= word.Length - 3; i++)
            {
                //ги земаме буквата на позиција i, и буквите на следните 2 позиции
                char currentChar = word[i];
                char nextChar1 = word[i + 1];
                char nextChar2 = word[i + 2];

                //проверуваме дали 3те карактери се исти
                if (currentChar == nextChar1 && nextChar1 == nextChar2)
                {
                    //Ако постои таков случај, враќа погрешно
                    return false;
                }
            }
            return true;
        }

        //проверка на зборот според избран режим 
        //и валидација дека се внесени само букви
        public bool validateTryWord(string word, string mode)
        {
            word = word.ToLower();
            if (mode.ToLower() == "easy")
            {
                return easyValidate(word);
            }
            else if (mode.ToLower() == "medium")
            {
                return easyValidate(word) && mediumValidate(word);
            }
            else if (mode.ToLower() == "hard")
            {
                //во тежок режим, за да се погоди зборот
                //играчот може да внесува само зборови кои се наоѓаат во листата
                return easyValidate(word) && holder.wordsSet.Contains(word);
            }
            return false;
        }

        //проверка дали внесениот збор
        //е внесен со латинични симболи
        public bool IsEnglishAlphabet(string word)
        {
            //Проверка дали внесените букви се латинични?
            Regex regex = new Regex("^[a-zA-Z]+$");
            return regex.IsMatch(word);
        }
    }
}
