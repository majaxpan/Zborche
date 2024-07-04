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

        public void checkWord(string tryWord)
        {
            bool[] matched = new bool[gameWord.Length];

            //Прва проверка
            //точна буква и точна позиција
            //ги маркира и обојува
            for (int i = 0; i < colors.Length; i++)
            {
                if (tryWord[i] == gameWord[i])
                {
                    colors[i] = Color.LightGreen;
                    matched[i] = true;
                }
                else
                {
                    colors[i] = Color.LightGray;
                }
            }

            //Втора проверка
            //точна буква и погрешна позиција
            //споредува со преостанатите
            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i] == Color.LightGreen)
                {
                    continue; //Прескокни ги зелените букви (точните букви на точна позиција)
                }

                for (int j = 0; j < gameWord.Length; j++)
                {
                    if (!matched[j] && tryWord[i] == gameWord[j])
                    {
                        colors[i] = Color.LightYellow;
                        matched[j] = true;
                        break;
                    }
                }
            }
        }


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

        public bool checkTryWord(string word)
        {
            //првичниот план ми беше да се внесуваат зборови 
            //кои ги има во играта со цел да не се трошат обиди
            //меѓутоа во тој случај многу е ограничен влезот 

            //return holder.wordsSet.Contains(word);

            //поради некои граматички правила, за да направам валидација
            //и да се осигурам дека нема да се внесуваат исти букви повеќе пати со цел да се осигура позиција, 
            //правам проверка дали одредена буква 3 пати со ред се повторува
            string lowerCaseWord = word.ToLower();

            //Проверка дали одредена буква се појавува 3 пати со ред
            for (int i = 0; i <= lowerCaseWord.Length - 3; i++)
            {
                //ги земаме буквата на позиција i, и буквите на следните 2 позиции
                char currentChar = lowerCaseWord[i];
                char nextChar1 = lowerCaseWord[i + 1];
                char nextChar2 = lowerCaseWord[i + 2];

                //проверуваме дали 3те карактери се исти
                if (currentChar == nextChar1 && nextChar1 == nextChar2)
                {
                    //Ако постои таков случај, враќа погрешно
                    return false;
                }
            }

            //Доколку нема 3 исти букви со ред, се враќа точно
            return true;
        }

        public bool IsEnglishAlphabet(string word)
        {
            //Проверка дали внесените букви се латинични?
            Regex regex = new Regex("^[a-zA-Z]+$");
            return regex.IsMatch(word);
        }
    }
}
