using PrimAlgorithm.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimAlgorithm
{
    public partial class Form1 : Form
    {
        private List<Knoop> knopen = new List<Knoop>();
        private List<Kant> kanten = new List<Kant>();

        public Form1()
        {
            InitializeComponent();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // maak knopen aan (hardcoded) 
            Knoop h1 = new Knoop("H1");
            Knoop h2 = new Knoop("H2");
            Knoop h3 = new Knoop("H3");
            Knoop h4 = new Knoop("H4");
            Knoop h5 = new Knoop("H5");
            Knoop h6 = new Knoop("H6");
            Knoop h7 = new Knoop("H7");
            Knoop h8 = new Knoop("H8");
            Knoop h9 = new Knoop("H9");
            Knoop h10 = new Knoop("H10");

            knopen.Add(h1);
            knopen.Add(h2);
            knopen.Add(h3);
            knopen.Add(h4);
            knopen.Add(h5);
            knopen.Add(h6);
            knopen.Add(h7);
            knopen.Add(h8);
            knopen.Add(h9);
            knopen.Add(h10);

            // maak kanten aan (hardcoded) 
            kanten.Add(new Kant(h1, h2, 20));
            kanten.Add(new Kant(h1, h3, 45));
            kanten.Add(new Kant(h1, h10, 45));
            kanten.Add(new Kant(h2, h3, 30));
            kanten.Add(new Kant(h2, h5, 25));
            kanten.Add(new Kant(h2, h8, 100));
            kanten.Add(new Kant(h2, h10, 30));
            kanten.Add(new Kant(h3, h4, 45));
            kanten.Add(new Kant(h4, h5, 75));
            kanten.Add(new Kant(h4, h6, 40));
            kanten.Add(new Kant(h5, h6, 75));
            kanten.Add(new Kant(h5, h8, 90));
            kanten.Add(new Kant(h6, h7, 80));
            kanten.Add(new Kant(h6, h9, 40));
            kanten.Add(new Kant(h7, h8, 15));
            kanten.Add(new Kant(h8, h9, 45));
            kanten.Add(new Kant(h8, h10, 50));

            // bepaal 'Minimum Spanning Tree' via prim algoritme 
            MinimumSpanningTree mst = new MinimumSpanningTree();

            DataTable table = mst.BuildMatrixTable("PrimTable", knopen, kanten);
            FillGridView(table);

            List<Kant> geselecteerdeKanten = mst.Get(table, knopen, kanten);
            DisplayResult(geselecteerdeKanten);
        }

        private void DisplayResult(List<Kant> geselecteerdeKanten)
        {
            int total = 0;
            string arcsText = "";

            for (int i = 0; i < geselecteerdeKanten.Count; i++)
            { 
                total += geselecteerdeKanten[i].Lengte;
                arcsText += geselecteerdeKanten[i].KnoopA.Identifier.ToUpper() + "-" + geselecteerdeKanten[i].KnoopB.Identifier.ToUpper();

                if (i != (geselecteerdeKanten.Count - 1))
                    arcsText += ", ";
            }

            arcsText += " (" + total.ToString() + ")"; 

            label1.Text = arcsText;
            label1.Font = new Font("Arial", 16);
        }

        private void FillGridView(DataTable table)
        {
            // Add columns
            for (int i = 0; i < table.Columns.Count - 1; i++)
            {
                DataGridViewColumn imie = new DataGridViewComboBoxColumn();
                imie.HeaderText = knopen[i].Identifier;
                dataGridView1.Columns.Add(imie);
            }

            // Add rows
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.HeaderCell.Value = knopen[i].Identifier;

                // Create cells, add them to row
                for (int j = 0; j < knopen.Count; j++)
                {
                    DataGridViewCell cell = new DataGridViewTextBoxCell();
                    cell.Value = "-";

                    Kant kant = table.Rows[i].Field<Kant>(j);
                    if (kant != null)
                        cell.Value = kant.Lengte.ToString();


                    row.Cells.Add(cell);
                }

                dataGridView1.Rows.Add(row);
            }

            // Center text
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Sorting off
            dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
