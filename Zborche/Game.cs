using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            gameWord = picker.pickWord(holder.wordsList);
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
                    colors[i] = Color.LightGray; // Initialize to gray
                }
            }

            //Втора проверка
            //точна буква и погрешна позиција
            //споредува со преостанатите
            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i] == Color.LightGreen)
                {
                    continue; // Skip already matched (green) letters
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
    }
}
