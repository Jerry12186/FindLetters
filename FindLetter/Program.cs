using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            LettersMgr lm = new LettersMgr();
            lm.AddLetter(new List<char> { 'G', 'I', 'Z' });
            lm.AddLetter(new List<char> { 'U', 'E', 'K' });
            lm.AddLetter(new List<char> { 'Q', 'S', 'E' });

            LettersMgr.Position pos = new LettersMgr.Position
            {
                x = 2,
                y = 1
            };

            //lm.FindWord(new string[] { "GEEKS", "FOR", "QUIZ", "GO" ,"KEZ"}, pos);
            
            Console.ReadKey();
        }
    }
}
