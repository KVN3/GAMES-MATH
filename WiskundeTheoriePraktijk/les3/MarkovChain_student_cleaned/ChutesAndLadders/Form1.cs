using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarkovChain
{
  public partial class Form1 : Form
  {
    const int CELLWIDTH = 50;

    private ChutesAndLadders cl;

    public Form1()
    {
      InitializeComponent();
    }

    private void Form2_Load(object sender, EventArgs e)
    {
      cl = new ChutesAndLadders();
      CreateBoard();
      //cl.NextMove();  // don't make  a move yet, start 'off board'
      UpdateBoard();
    }

    private void CreateBoard()
    {
      // create panel for all positions
      for (int r = 1; r <= 10; r++)
      {
        for (int c = 1; c <= 10; c++)
        {
          Panel pnl = new Panel();
          pnl.BorderStyle = BorderStyle.FixedSingle;
          pnl.Name = String.Format("pnl-{0}-{1}", r, c);
          pnl.Width = CELLWIDTH - 1;
          pnl.Height = CELLWIDTH - 1;
          if (r % 2 == 1)
            // 1st, 3rd, 5th, ... row => from left to right
            pnl.Left = c * CELLWIDTH;
          else
            // 2nd, 4th, 6th, ... row => from right to left
            pnl.Left = (11 * CELLWIDTH - c * CELLWIDTH);
          pnl.Top = 20 + 10 * CELLWIDTH - r * CELLWIDTH;  // start from bottom
          pnl.BackColor = Color.Red;
          this.Controls.Add(pnl);

          // add label to each panel
          Label lbl = new Label();
          lbl.Name = String.Format("lbl-{0}-{1}", r, c);
          // position?
          pnl.Controls.Add(lbl);
        }
      }
    }

    private void UpdateBoard()
    {
      double[] position = this.cl.Position;

      for (int r = 1; r <= 10; r++)
      {
        for (int c = 1; c <= 10; c++)
        {
          // get panel
          string panelName = String.Format("pnl-{0}-{1}", r, c);
          Panel pnl = (Panel)this.Controls.Find(panelName, false)[0];

          // change backgrond color of panel
          int index = (r - 1) * 10 + (c - 1) + 1; // +1 to skip start position 'off board'
          pnl.BackColor = Color.FromArgb((int)(position[index] * 255), 255, 0, 0);

          // get label
          string labelName = String.Format("lbl-{0}-{1}", r, c);
          Label lbl = (Label)pnl.Controls.Find(labelName, false)[0];

          // set chance (%) in label
          lbl.Text = position[index].ToString("0.0000 %");

        }
      }

      // display number of moves
      lblNrOfMoves.Text = cl.NrOfMoves.ToString();
    }

    private void btnStap_Click(object sender, EventArgs e)
    {
      this.cl.NextMove();
      UpdateBoard();
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < 100; i++)
      {
        this.cl.NextMove();
        UpdateBoard();
        Refresh();
        System.Threading.Thread.Sleep(100);
      }
    }
  }
}