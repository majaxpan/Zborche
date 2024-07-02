﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zborche
{
    public class DataHolder
    {
        public HashSet<string> wordsSet =
        [
            "среќа", "молив", "тажен", "книга", "буква",
            "лажго", "петел", "магла", "топка", "место"
        ];

        public List<string> wordsList;

        public DataHolder()
        {
            this.wordsList = new List<string>(wordsSet);
        }
    }
}
