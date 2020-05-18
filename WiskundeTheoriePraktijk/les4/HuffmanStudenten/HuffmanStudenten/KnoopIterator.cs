using System;
using System.Collections;

namespace Huffman
{
    /// <summary>
    /// Summary description for KnoopIterator.
    /// </summary>
    public class KnoopIterator : IDictionaryEnumerator
    {
        // m.b.v. deze enumerator ben je in staat de binaire boom , entry voor entry, door te lopen.
        //(eerst de wortel, dan de linker boom en dan de rechterboom)
        private Stack stack = new Stack();
        public Knoop pos;

        public KnoopIterator(Knoop k)
        {
            pos = k;
            stack = new Stack();
            stack.Push(k);
        }

        public bool MoveNext()
        {
            pos = null;
            try
            {
                pos = (Knoop)stack.Pop();
            }
            catch { }
            if (pos != null)
            {
                if (pos.rechts != null)
                    stack.Push(pos.rechts);
                if (pos.links != null)
                    stack.Push(pos.links);
            }
            return pos != null;
        }
        public void Reset()
        {
            Knoop p2 = (Knoop)stack.Pop();
            while (p2 != null)
            {
                pos = p2;
                p2 = (Knoop)stack.Pop();
            }
        }
        public DictionaryEntry Entry
        {
            get
            {
                return (DictionaryEntry)Current;
            }
        }
        public object Key
        {
            get
            {
                return null;//not used in a binary tree
            }
        }
        public object Value
        {
            get
            {
                return pos.userObject;
            }
        }
        public object Current
        {
            get
            {
                return pos;
            }
        }
    }
}