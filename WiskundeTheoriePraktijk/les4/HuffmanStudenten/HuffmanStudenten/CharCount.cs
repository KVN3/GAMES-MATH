using System;

namespace Huffman
{
    /// <summary>
    /// In deze class wordt per letter de bijbehorende binaire waarde en de frequentie opgeslagen.
    /// </summary>
    public class CharCount : IComparable
    {
        public int count;
        public char character;
        public string binaireWaarde = "";

        /// <summary>Constructor</summary>
        /// <param name="c">Karakter waarmee deze class moet werken.</param>
        public CharCount(char c)
        {
            character = c;
            count = 0;
        }

        public int CompareTo(object o)
        {
            CharCount c = (CharCount)o;
            if (c.count < this.count)
            {
                return 1;
            }
            else if (c.count == this.count)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}