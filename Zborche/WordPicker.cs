using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zborche
{
    public class WordPicker
    {
        Random random = new Random();

        public WordPicker()
        {
        }

        public string pickWord(List<string> list)
        {
            return list.ElementAt(random.Next(0, list.Count));
        }
    }
}
