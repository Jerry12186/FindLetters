/*
 * 有一个M * N的棋盘，每个格⼦上有一个字母，
 * 现在按照下⾯面的规则来构造单词：可以从任意⼀一个位置开始，
 * 接着向该位置相邻的8个位置中选取下⼀个(不能选取已经选取过的位置)，如此循环，构成⼀一个字⺟母序列列，⽣生成⼀一个单词。
 * 现在给你⼏几个单词，尝试判断这⼏几个单词是否能由此⽅方法⽣生成。
 * 例如： 输⼊入：dictionary[] = {"GEEKS", "FOR", "QUIZ", "GO"};
 * boggle[][]   = { {'G','I','Z'}, {'U','E','K'}, {‘Q','S','E'} };       
 * 输出：GEEKS、QUIZ
 */

using System.Collections.Generic;

namespace FindLetter
{
    class LettersMgr
    {

        public struct Position
        {
            public int x;
            public int y;
        };

        List<List<char>> boggle;//保存字母

        public LettersMgr()
        {
            boggle = new List<List<char>>();
        }

        /// <summary>
        /// 添加一行字母
        /// </summary>
        /// <param name="letter"></param>
        public void AddLetter(List<char> letter)
        {
            if (boggle.Count == 0)
                boggle.Add(letter);
            else
            {
                if (letter.Count != boggle[0].Count)
                    System.Console.WriteLine("添加的字母的个数不对，需要添加的个数为：" + boggle[0].Count);
                else
                    boggle.Add(letter);
            }
        }

        /// <summary>
        /// 获取字母的Map
        /// </summary>
        /// <returns></returns>
        public List<List<char>> GetLetterMap()
        {
            return boggle;
        }

        /// <summary>
        /// 查找单词
        /// </summary>
        /// <param name="words">单词数组</param>
        /// <param name="startX">开始查找的位置，X</param>
        /// <param name="startY">开始查找的位置，Y</param>
        public void FindWord(string[] words, Position pos)
        {
            if (pos.x < 0 || pos.y < 0)
            {
                System.Console.WriteLine("开始位置不能小于0");
            }
            else if (pos.y > boggle[0].Count || pos.x > boggle.Count)
            {
                System.Console.WriteLine("开始位置越界，startX最大值为：{0}，startY的最大值为：{1}", boggle.Count, boggle[0].Count);
            }
            else
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (CanConstituteWord(words[i]))
                    {

                    }
                }
            }
        }

        /// <summary>
        /// 判断该字母Map能否构成给定的单词
        /// </summary>
        /// <returns></returns>
        private bool CanConstituteWord(string word)
        {
            bool bConstitute = false;

            char[] letter = word.ToCharArray();
            int letterCount = 0;

            for (int j = 0; j < letter.Length; j++)
            {
                for (int k = 0; k < boggle.Count; k++)
                {
                    char c = boggle[k].Find((x) => { return x == letter[j]; });
                    if (c != '\0')
                    {
                        ++letterCount;
                        break;
                    }
                }
            }
            if (letterCount == letter.Length)
            {
                System.Console.WriteLine("该{0}单词可以用此字母Map组成", word);
                //能组成然后判断组成顺序
                bConstitute = true;
            }
            else
            {
                System.Console.WriteLine("此字母Map不组成组成单词：" + word);
                return false;
            }

            return bConstitute;
        }

        /// <summary>
        /// 查找字母所在的位置
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private void SeekLetter(char c, Position p)
        {
            Position pos = new Position();

            //if(p.x-1>0)

            //return pos;
        }

        /// <summary>
        /// 根据位置附近的所有查找字母
        /// </summary>
        /// <param name="pos">位置</param>
        /// <returns></returns>
        private List<char> FindLetterFromMap(Position pos)
        {
            List<char> letters = new List<char>();

            if (pos.y - 1 > -1)
            {
                if (pos.x - 1 > -1)
                    letters.Add(boggle[pos.x - 1][pos.y - 1]);
                letters.Add(boggle[pos.x][pos.y - 1]);
                if (pos.x + 1 < boggle[0].Count)
                    letters.Add(boggle[pos.x + 1][pos.y - 1]);
            }

            {
                if (pos.x - 1 > -1)
                    letters.Add(boggle[pos.x - 1][pos.y]);
                if (pos.x + 1 < boggle[0].Count)
                    letters.Add(boggle[pos.x + 1][pos.y]);
            }

            if (pos.y + 1 < boggle.Count)
            {
                if (pos.x - 1 > -1)
                    letters.Add(boggle[pos.x - 1][pos.y + 1]);
                letters.Add(boggle[pos.x][pos.y + 1]);
                if (pos.x + 1 < boggle[0].Count)
                    letters.Add(boggle[pos.x + 1][pos.y + 1]);
            }

            return letters;
        }
    }
}
