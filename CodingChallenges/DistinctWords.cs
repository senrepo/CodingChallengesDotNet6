using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges
{
    public class DistinctWords
    {
        private string _line { get; set; }
        private List<string> _splitList = new List<string>() {" ", ",", "." };

        public DistinctWords(string line)
        {
            _line = line;
        }

        public List<string> GetWords()
        {
            /* Sudo code
             * 
             * distinct words       -       list
             * _line                -       [] <- get the line split by " "
             * []                   -       [] [] <- get the each workds split by next split char
             * []                   -       [] [] <- get each words split by next split char 
            */
            var distinctWords = new List<string>();
            foreach (var splitBy in _splitList)
            {
                var list = new List<string>();
                if (distinctWords.Count ==0)
                {
                    list = GetDistinctWords(_line, splitBy);
                } 
                else
                {
                    foreach(var word in distinctWords)
                    {
                        var words = GetDistinctWords(word, splitBy);
                        list.AddRange(words);
                    }
                }
                distinctWords = list;
            }
            return distinctWords;
        }


        private List<string> GetDistinctWords(string word, string splitBy)
        {
            var distinctWords = new HashSet<string>();
            var words = word.Split(splitBy);

            foreach (var item in words)
            {
                if (!string.IsNullOrWhiteSpace(item))
                    distinctWords.Add(item);
            }

            return distinctWords.ToList();

        }

       

      


    }
}
