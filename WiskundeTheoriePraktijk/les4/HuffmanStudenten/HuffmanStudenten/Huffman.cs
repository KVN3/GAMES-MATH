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
        private Knoop boom;                 // de boom met de (binaire) codes voor alle karakters in de boodschap

        public Huffman()
        {
            // voor elke letter/karakter wordt de bijbehorende binaire waarde en de frequentie opgeslagen
            charCount = new CharCount[MAXCHAR];
            for (int c = 0; c < MAXCHAR; c++)
                charCount[c] = new CharCount((char)c);
        }

        public string Codeer(string input, ListBox freqLijst)
        {
            // 1. verwerk de input letter voor letter en verhoog de betreffende index in (array) charCount
            foreach (char c in input)
                charCount[c].count++;

            Console.WriteLine("b count=" + charCount[98]);

            // 2. sorteer het array d.m.v. binary sort (de sorteer functie kan je hergebruiken uit een vorige opdracht) - dit werkt door de IComparable interface
            Array.Sort(charCount);
            Array.Reverse(charCount);

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
                laagsteKnopen[0] = (Knoop)knopen[knopen.Count - 1];
                laagsteKnopen[1] = (Knoop)knopen[knopen.Count - 2];
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
                knopen.Sort();
                knopen.Reverse();
            }

            // 5.
            // geef nu alle blaadjes in de boom (van het type Knoop dus) hun bijbehorende binaire waarde
            // dit kan je doen een recursieve methode te maken die als parameter de "huidige" binaire waarde heeft en hier
            // aan de linker-aanroep een extra "0" toevoegt en aan de rechter-aanroep een extra "1"
            //zijn zowel de linkerkant als de rechterkant null, dan zit je in een blaadje en kan de huidige waarde worden toegekend

            // Weer van laag naar hoog
            knopen.Sort();
            Knoop tree = (Knoop)knopen[0];
            

            // de tree is nu afgerond

            // 6. maak een loop over alle characters in input
            // hierbij kan je gebruik maken van de enumerator "IDictionaryEnumerator GetEnumerator" van de tree
            // zoek de knoop die hoort bij het huidige character
            // voeg de binaire waarde van de knoop toe aan een output string
            string outputStr = "";
            // ...

            // 7. loop over alle knopen in de tree
            // voeg aan de freqlijst.Items nieuwe items toe in het format: "count x character"
            // ...

            // return de output string
            return outputStr;
        }

        private void SetBinary()
        {

        }




        public string Decodeer(string input)
        {
            string str = "";

            // loop over alle énen en nullen in de string input
            // als de huidige char een 1 is
            // probeer verder te gaan vanuit de rechter knoop
            // als dat niet lukt zit je in een blad
            // voeg dan de character toe aan de output string en ga rechts vanaf de boom
            // else
            // probeer verder te gaan vanuit de linker knoop
            // als dat niet lukt zit je in een blad
            // voeg dan de character toe aan de output string en ga links vanaf de boom

            // return output string
            return str;
        }

        // zet hier je sorteren methode neer van week3
    }
}