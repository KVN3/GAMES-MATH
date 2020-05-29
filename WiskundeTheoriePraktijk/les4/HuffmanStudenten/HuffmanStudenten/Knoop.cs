using System;
using System.Collections;

namespace Huffman
{
    /// <summary>
    /// Met deze class kan een boom (tree) opgezet worden van CharCount objecten.
    /// </summary>
    public class Knoop : IComparable
    {
        public CharCount userObject;
        public Knoop rechts, links;

        /// <summary>Constructor</summary>
        /// <param name="o">Het CharCount object dat in deze knoop opgeslagen moet worden.</param>
        public Knoop(CharCount o)
        {
            userObject = o;
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            return new KnoopIterator(this);
        }

        public void AddKnoopLinks(Knoop k)
        {
            links = k;
        }

        public void AddKnoopRechts(Knoop k)
        {
            rechts = k;
        }

        public int CompareTo(object o)
        {
            Knoop k = (Knoop)o;
            if (k.userObject.count < this.userObject.count)
            {
                return 1;
            }
            else if (k.userObject.count == this.userObject.count)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public int Count()
        {
            return userObject.count;
        }

        public bool IsLeaf()
        {
            if (rechts == null && links == null)
                return true;
            else
                return false;
        }
    }
}