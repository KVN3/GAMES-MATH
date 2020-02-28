using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Mazes
{
    public class Maze
    {

        #region attributes
        //cell filled with:
        //0 : all sides free
        //1 : left closed     0e bit
        //2 : top closed      1e bit
        //4 : right closed    2e bit
        //8 : bottom closed   3e bit
        //else: combination of sides closed (max=15 : all sides closed)
        private int[,] cellMatrix = null;           //the numbers define the edges of the corresponding cell to be closed or not
                                                    /*={
                                                            { 3,10,10,10,10,10,10, 6},
                                                            { 1,10, 6, 3, 6, 3,10,12},
                                                            { 1,14, 5, 5, 5, 9, 2, 6},
                                                            {13, 3, 8,12, 9,13, 5, 5},
                                                            {10,12, 3,10,10, 6, 5,13},
                                                            { 3, 6, 9,10, 6, 1,12, 3},
                                                            { 5, 9,10,10, 5, 9,14, 5},
                                                            { 9,10,10,10, 8,10,10,12}
                                                    };*/
        private int squareSizeH = 8;                //number of horizontal squares 
        private int squareSizeW = 8;                //number of vertical squares 
        private int squareDrawSize = 20;            //size of a square in the drawing
        private int x, y;                   //left-top corner of the puzzle
        private Graphics g = null;

        private bool[] pad;                 //contains the cell's investigated sofar by holding there position = rownumber * squareSizeW + column number;
        private int[] solutionPad;                  //contains a solution
        private int numberOfSolutionCells = 0;          //number of cells that form the solution-path
        private bool solutionFound = false;

        //properties:
        public int[,] IntMatrix
        {
            set
            {
                cellMatrix = value;
            }
        }

        public int SquareSizeH
        {
            set
            {
                squareSizeH = value;
                pad = new bool[squareSizeW * squareSizeH];      //contains the cell investigated sofar
                solutionPad = new int[squareSizeW * squareSizeH];   //contains a solution
                Init();
            }
        }

        public int SquareSizeW
        {
            set
            {
                squareSizeW = value;
                pad = new bool[squareSizeW * squareSizeH];      //contains the cell investigated sofar
                solutionPad = new int[squareSizeW * squareSizeH];   //contains a solution
                Init();
            }
        }

        public int SquareDrawSize
        {
            set
            {
                squareDrawSize = value;
            }
            get
            {
                return squareDrawSize;
            }
        }
        #endregion

        public Maze(int x, int y)
        {
            this.x = x;                                                                                         //left-top corner of the puzzle
            this.y = y;
            pad = new bool[squareSizeW * squareSizeH];          //contains the cells investigated sofar
            solutionPad = new int[squareSizeW * squareSizeH];       //contains a solution
            Init();
        }

        private void Init()
        {
            for (int r = 0; r < squareSizeW * squareSizeH; r++)
                pad[r] = false;
            numberOfSolutionCells = 0;
            solutionFound = false;
        }

        #region paint method's
        public void paint(Graphics g)
        {
            this.g = g;
            if (cellMatrix != null)
            {
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, squareSizeW * squareDrawSize + 1, squareSizeH * squareDrawSize + 1);
                for (int r = 0; r < squareSizeH; r++)
                    for (int c = 0; c < squareSizeW; c++)
                    {
                        int x0 = x + c * squareDrawSize;
                        int y0 = y + r * squareDrawSize;
                        //cell filled with:
                        //0 : all sides free
                        //1 : left closed
                        //2 : top closed
                        //4 : right closed
                        //8 : bottom closed
                        //else: combination of sides closed (max=15 : all sides closed)
                        //example : 13 in binary form is %1101. Binary "and" with %0001 gives %0001
                        if ((cellMatrix[r, c] & 1) > 0)//left side closed?
                            g.DrawLine(new Pen(Color.Blue, 1), x0, y0, x0, y0 + squareDrawSize);
                        if ((cellMatrix[r, c] & 2) > 0)//top side closed?
                            g.DrawLine(new Pen(Color.Blue, 1), x0, y0, x0 + squareDrawSize, y0);
                        if ((cellMatrix[r, c] & 4) > 0)//right side closed?
                            g.DrawLine(new Pen(Color.Blue, 1), x0 + squareDrawSize, y0, x0 + squareDrawSize, y0 + squareDrawSize);
                        if ((cellMatrix[r, c] & 8) > 0)//bottom side closed?
                            g.DrawLine(new Pen(Color.Blue, 1), x0, y0 + squareDrawSize, x0 + squareDrawSize, y0 + squareDrawSize);
                    }
            }
            paintSolution(g);
        }

        public void paintSolution(Graphics g)
        {
            for (int p = 0; p < numberOfSolutionCells; p++)
            {
                int px = (solutionPad[p] % squareSizeW) * squareDrawSize + squareDrawSize / 4;
                int py = (solutionPad[p] / squareSizeW) * squareDrawSize + squareDrawSize / 4;
                g.FillEllipse(new SolidBrush(Color.Red), x + px, y + py, squareDrawSize / 2, squareDrawSize / 2);
            }
        }
        #endregion

        #region solve
        public bool Solved()
        {
            return solutionFound;
        }

        public void Solve(int r, int c)
        {
            solutionFound = false;
            numberOfSolutionCells = 0;
            if (cellMatrix != null)
                Solve(0, r, c);
            this.paintSolution(g);
        }

        private void Solve(int level, int r, int c)
        {
            // Ben ik buiten de doolhof
            if (cellMatrix[r, c] == 0)
            {
                Solved();
            }
            else
            {
                //  Add this to the solution
                level++;
                solutionPad[level] = r * squareSizeW + c;

                // Ben ik hier nog niet geweest
                if (pad[r * squareSizeW + c] == false)
                {
                    // Markeer de cel als bezocht
                    pad[r * squareSizeW + c] = true;

                    // Go down       
                    if ((cellMatrix[r, c] & 3) != 1)
                    {
                        Solve(level, r, c - 1);
                    }

                    // Go right
                    if ((cellMatrix[r, c] & 2) != 1)
                    {
                        Solve(level, r + 1, c);
                    }

                    // Go up
                    if ((cellMatrix[r, c] & 1) != 1)
                    {
                        Solve(level, r, c + 1);
                    }

                    // Go left
                    if ((cellMatrix[r, c] & 0) != 1)
                    {
                        Solve(level, r - 1, c);
                    }
                }
            }
        }

        private bool IsBitSet(int value, int pos)
        {
            return (value & (1 << pos)) != 0;
        }
        #endregion

    }
}
