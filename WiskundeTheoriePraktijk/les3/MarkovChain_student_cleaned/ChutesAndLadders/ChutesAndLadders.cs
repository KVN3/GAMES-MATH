namespace MarkovChain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ChutesAndLadders
    {
        /// <summary>Ladders and chutes are 'ChuteLadder'.</summary>
        private class ChuteLadder
        {
            // ladder: end position will be higher than startposition
            // chute: end position will be lower than startposition
            public int StartPosition;
            public int EndPosition;

            public ChuteLadder(int start, int end)
            {
                StartPosition = start;
                EndPosition = end;
            }
        }

        private List<ChuteLadder> chutesAndladders = new List<ChuteLadder>();
        private const int NumberOfPositions = 100;
        private double[,] transitionMatrix = new double[NumberOfPositions + 1, NumberOfPositions + 1];
        public double[] Position = new double[NumberOfPositions + 1];
        private int nrOfMoves;

        public int NrOfMoves
        {
            get { return nrOfMoves; }
        }

        /// <summary>constructor</summary>
        public ChutesAndLadders()
        {
            InitChutesAndLadders();

            // initialize the transition matrix
            InitTransitionMatrix();

            // start at position 0
            Position[0] = 1;    // chance at 'off board position' is 100%
            nrOfMoves = 0;
        }

        /// <summary>Create chutes and ladders.</summary>
        private void InitChutesAndLadders()
        {
            // ladders (all ending at higher position)
            chutesAndladders.Add(new ChuteLadder(1, 38));
            chutesAndladders.Add(new ChuteLadder(4, 14));
            chutesAndladders.Add(new ChuteLadder(9, 31));
            chutesAndladders.Add(new ChuteLadder(21, 42));
            chutesAndladders.Add(new ChuteLadder(28, 84));
            chutesAndladders.Add(new ChuteLadder(36, 44));
            chutesAndladders.Add(new ChuteLadder(51, 67));
            chutesAndladders.Add(new ChuteLadder(71, 91));
            chutesAndladders.Add(new ChuteLadder(80, 100));

            // chutes (all ending at lower position)
            chutesAndladders.Add(new ChuteLadder(98, 78));
            chutesAndladders.Add(new ChuteLadder(95, 75));
            chutesAndladders.Add(new ChuteLadder(93, 73));
            chutesAndladders.Add(new ChuteLadder(87, 24));
            chutesAndladders.Add(new ChuteLadder(64, 60));
            chutesAndladders.Add(new ChuteLadder(62, 19));
            chutesAndladders.Add(new ChuteLadder(56, 53));
            chutesAndladders.Add(new ChuteLadder(49, 11));
            chutesAndladders.Add(new ChuteLadder(48, 26));
            chutesAndladders.Add(new ChuteLadder(16, 6));
        }

        /// <summary>Initializes the transition matrix.</summary>
        private void InitTransitionMatrix()
        {
            for (int huidigVakje = 0; huidigVakje < NumberOfPositions + 1; huidigVakje++)
            {
                // Set all chances to zero
                for (int vakje = 0; vakje < NumberOfPositions + 1; vakje++)
                {
                    transitionMatrix[huidigVakje, vakje] = 0;
                }

                // Dobbelsteen voor de komende 6 vakjes
                for (int vakje = huidigVakje + 1; vakje < 6; vakje++)
                {
                    int index = chutesAndladders.FindIndex(f => f.StartPosition == vakje);
                    if (index >= 0)
                        transitionMatrix[huidigVakje, chutesAndladders[index].EndPosition] = (double)1 / 6;
                    else
                        transitionMatrix[huidigVakje, vakje] = (double)1 / 6; // De kans om naar dit vakje te gaan
                }
            }
        }

        /// <summary>Make the next move.</summary>
        public void NextMove()
        {

            for (int x = 0; x < Position.Length; x++)
            {
                Position[x] = Position[x] * 1;
                for (int i = 0; i < NumberOfPositions + 1; i++)
                {
                    Position[5] = Position[x] * transitionMatrix[x, i];
                }
            }




            nrOfMoves++;
        }
    }
}