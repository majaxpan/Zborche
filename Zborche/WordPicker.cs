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

        public string pickWord(HashSet<string> set)
        {
            return set.ElementAt(random.Next(0, set.Count));
        }
    }
}
