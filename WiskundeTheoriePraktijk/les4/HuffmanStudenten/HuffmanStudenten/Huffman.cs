using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Huffman
{
    /// <summary>
    /// Class that implements the Huffman encoding algorithm.
    /// </summary>
    public class Huffman
    {
        private const int MAXCHAR = 256;    // maximaal 256 verschillende letters in de ASCII-tabel

        private CharCount[] charCount;      // array met voor elke karakter een CharCount object
        private Knoop tree;                 // de boom met de (binaire) codes voor alle karakters in de boodschap

        public Huffman()
        {
            Reset();
        }

        private void Reset()
        {
            // voor elke letter/karakter wordt de bijbehorende binaire waarde en de frequentie opgeslagen
            charCount = new CharCount[MAXCHAR];
            for (int c = 0; c < MAXCHAR; c++)
                charCount[c] = new CharCount((char)c);
        }

        public string Codeer(string input, ListBox freqLijst)
        {
            // Skip without input
            if (input.Equals(String.Empty))
                return "";

            Reset();

            // 1. verwerk de input letter voor letter en verhoog de betreffende index in (array) charCount
            foreach (char c in input)
                charCount[c].count++;

            // 2. sorteer het array d.m.v. binary sort (de sorteer functie kan je hergebruiken uit een vorige opdracht) - 
            // dit werkt door de IComparable interface
            Array.Sort(charCount);

            // 3. maak voor alle relevante klassen in charCount knopen aan met als userObject de betreffende charCount
            // en plaats deze in een nieuw ArrayList (een ArrayList kun je dynamisch verkleinen, dat straks nodig is)
            ArrayList knopen = new ArrayList();
            for (int c = 0; c < MAXCHAR; c++)
            {
                if (charCount[c].count == 0)
                    continue;

                knopen.Add(new Knoop(charCount[c]));
            }

            // 4. herhaal nu (zolang de gesorteerde ArrayList met knopen groter is dan 1):
            while (knopen.Count > 1)
            {
                //  maak een nieuwe knoop die de 2 knopen met laagste count als kinderen heeft en
                //  deze 2 knopen vervolgens vervangt in de array(list) (de letter 0 als char, de som van de counts als count)
                Knoop[] laagsteKnopen = new Knoop[2];
                laagsteKnopen[0] = (Knoop)knopen[0];
                laagsteKnopen[1] = (Knoop)knopen[1];
                Array.Sort(laagsteKnopen);

                CharCount newCharCount = new CharCount('0');
                newCharCount.count = laagsteKnopen[0].userObject.count + laagsteKnopen[1].userObject.count;

                Knoop newKnoop = new Knoop(newCharCount);
                newKnoop.links = laagsteKnopen[0];
                newKnoop.rechts = laagsteKnopen[1];

                //  zorg er voor dat deze vervangende knoop op de juiste positie komt in de array en
                // dat de array 1 item kleiner wordt
                knopen.Remove(laagsteKnopen[0]);
                knopen.Remove(laagsteKnopen[1]);
                knopen.Add(newKnoop);

                // Sort zet alles weer op de goede plek
                knopen.Sort();
            }

            // 5.
            // geef nu alle blaadjes in de boom (van het type Knoop dus) hun bijbehorende binaire waarde
            // dit kan je doen een recursieve methode te maken die als parameter de "huidige" binaire waarde heeft en hier
            // aan de linker-aanroep een extra "0" toevoegt en aan de rechter-aanroep een extra "1"
            tree = (Knoop)knopen[knopen.Count - 1];
            SetBinary(tree, "");

            // de tree is nu afgerond


            string outputStr = "";

            // 6. maak een loop over alle characters in input
            foreach (char character in input)
            {
                KnoopIterator iterator = (KnoopIterator)tree.GetEnumerator();

                // zoek de knoop die hoort bij het huidige character
                while (iterator.MoveNext())
                {
                    CharCount charCount = (CharCount)iterator.Value;

                    // voeg de binaire waarde van de knoop toe aan een output string en exit de while -> volgende character
                    if (charCount.character.Equals(character))
                    {
                        outputStr += charCount.binaireWaarde;
                        break;
                    }
                }
            }

            // 7. loop over alle knopen in de tree
            KnoopIterator knoopIterator = (KnoopIterator)tree.GetEnumerator();
            while (knoopIterator.MoveNext())
            {
                CharCount charCount = (CharCount)knoopIterator.Value;

                // voeg aan de freqlijst.Items nieuwe items toe in het format: "count x character"
                if (!charCount.character.Equals('0'))
                    freqLijst.Items.Add(charCount.count + " x " + charCount.character);
            }

            // return de output string
            return outputStr;
        }

        private void SetBinary(Knoop currentKnoop, string currentBinaryValue)
        {
            if (currentKnoop.links != null)
                SetBinary(currentKnoop.links, currentBinaryValue + "0");
            if (currentKnoop.rechts != null)
                SetBinary(currentKnoop.rechts, currentBinaryValue + "1");

            //zijn zowel de linkerkant als de rechterkant null, dan zit je in een blaadje en kan de huidige waarde worden toegekend
            if (currentKnoop.links == null && currentKnoop.rechts == null)
                currentKnoop.userObject.binaireWaarde = currentBinaryValue;
        }




        public string Decodeer(string input)
        {
            string str = "";
            Knoop currentKnoop = tree;

            // loop over alle énen en nullen in de string input
            foreach (char character in input)
            {

                // als de huidige char een 1 is
                if (character.Equals('1'))
                {
                    // probeer verder te gaan vanuit de rechter knoop
                    // als dat niet lukt zit je in een blad
                    // voeg dan de character toe aan de output string en ga rechts vanaf de boom
                    currentKnoop = currentKnoop.rechts;

                    if (currentKnoop.IsLeaf())
                    {
                        str += currentKnoop.userObject.character;
                        currentKnoop = tree;
                    }

                }
                else if (character.Equals('0'))
                {
                    // probeer verder te gaan vanuit de linker knoop
                    // als dat niet lukt zit je in een blad
                    // voeg dan de character toe aan de output string en ga links vanaf de boom
                    currentKnoop = currentKnoop.links;

                    if (currentKnoop.IsLeaf())
                    {
                        str += currentKnoop.userObject.character;
                        currentKnoop = tree;
                    }
                }
                else
                {
                    // Invalid character in input
                }
            }

            // return output string
            return str;
        }

        // zet hier je sorteren methode neer van week3
        // ??
    }
}