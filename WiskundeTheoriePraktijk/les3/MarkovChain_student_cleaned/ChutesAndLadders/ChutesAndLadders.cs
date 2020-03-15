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
            PrintTransitionMatrix();

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

                // Fill the transition matrix.
                for (int rol = 1; rol < 7; rol++)
                {
                    int nieuwVakje = huidigVakje + rol;

                    // If you roll a number that puts you beyond 100, you stay in your original spot (ORIGINAL). In this case you'll jump to 100 instead (As per the example).
                    if (nieuwVakje > 100)
                        nieuwVakje = 100;

                    // Apply ladders and chutes rules.
                    int index = chutesAndladders.FindIndex(f => f.StartPosition == nieuwVakje);
                    if (index >= 0)
                        nieuwVakje = chutesAndladders[index].EndPosition;

                    // Update the chance in the matrix to go from 'huidigVakje' to 'nieuwVakje'.
                    transitionMatrix[huidigVakje, nieuwVakje] += (double)1 / 6;
                }
            }
        }

        /// <summary>Make the next move.</summary>
        public void NextMove()
        {
            double[] newPositionChances = new double[NumberOfPositions + 1];

            for (int j = 0; j < NumberOfPositions + 1; j++)
            {
                double actueleKans = 0;
                for (int i = 0; i < NumberOfPositions + 1; i++)
                {
                    double positieI = Position[i];
                    double kans = transitionMatrix[i, j];

                    actueleKans += positieI * kans;
                }

                newPositionChances[j] = actueleKans;
            }

            Position = newPositionChances;

            nrOfMoves++;
        }

        private void PrintTransitionMatrix()
        {
            int rowLength = transitionMatrix.GetLength(0);
            int colLength = transitionMatrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    if (transitionMatrix[i, j] > 0)
                        Console.Write(string.Format("{0}", j));

                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }

            Console.WriteLine("-----------------------------------------------------");

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    if (transitionMatrix[i, j] > 0)
                        Console.Write(string.Format("({0}){1} ", j, transitionMatrix[i, j]));

                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.ReadLine();
        }
    }
}