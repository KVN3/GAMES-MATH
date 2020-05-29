using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimAlgorithm.models
{
    public class MinimumSpanningTree
    {
        private Random random = new Random();
        private List<Knoop> geselecteerdeKnopen = new List<Knoop>();
        private List<Kant> geselecteerdeKanten = new List<Kant>();

        private void DeleteRow(Knoop knoop, DataTable matrixTable)
        {
            List<DataRow> toBeDeleted = new List<DataRow>();

            // Get the right row and add to the list
            foreach (DataRow dr in matrixTable.Rows)
            {
                if (dr["rowName"].ToString() == knoop.Identifier)
                    toBeDeleted.Add(dr);
            }

            // Delete
            foreach (DataRow dr in toBeDeleted)
                dr.Delete();
        }

        public List<Kant> Get(DataTable matrixTable, List<Knoop> knopen, List<Kant> kanten)
        {
            // 2) selecteer een willekeurige knoop en verwijder de betreffende rij 
            Knoop beginKnoop = knopen[random.Next(0, knopen.Count)];
            DeleteRow(beginKnoop, matrixTable);
            geselecteerdeKnopen.Add(beginKnoop);

            // 5) zolang niet alle knopen geselecteerd zijn, ga door... 
            while (matrixTable.Rows.Count != 0)
            {
                // 3a) selecteer vanuit de geselecteerde knopen (kolommen) de eindknoop met de laagste waarde 
                KantKnoop shortestResult = GetShortestArcUsingMatrixTable(matrixTable);

                // No new closest found, we done
                if (shortestResult.HasANull())
                    continue;

                // 3b) voeg de kant [kolomknoop, rijknoop] toe aan de lijst geselecteerde kanten 
                geselecteerdeKanten.Add(shortestResult.Kant);

                // 4) voeg de eindknoop toe aan de geselecteerde knopen en verwijder de betreffende rij uit de tabel
                DeleteRow(shortestResult.Knoop, matrixTable);
                geselecteerdeKnopen.Add(shortestResult.Knoop);
            }

            // 6) de lijst met geselecteerde kanten is de oplossing, toon deze lijst 
            return geselecteerdeKanten;
        }

        private KantKnoop GetShortestArcUsingMatrixTable(DataTable matrixTable)
        {
            int huidigeKortsteLengte = int.MaxValue;
            List<Knoop> dichtbijsteKnopen = new List<Knoop>();
            List<Kant> kortsteKanten = new List<Kant>();

            foreach (Knoop knoop in geselecteerdeKnopen)
            {
                string columnName = knoop.Identifier;

                foreach (DataRow dataRow in matrixTable.Rows)
                {
                    // Als er waarde in de cel van deze kolom zit
                    if (dataRow[columnName] is Kant)
                    {
                        Kant kant = (Kant)dataRow[columnName];

                        // Nieuwe laagste waarde gevonden, reset huidige lijst
                        if (huidigeKortsteLengte > kant.Lengte)
                        {
                            dichtbijsteKnopen.Clear();
                            kortsteKanten.Clear();
                        }

                        // Mag de lijst in
                        if (huidigeKortsteLengte >= kant.Lengte)
                        {
                            huidigeKortsteLengte = kant.Lengte;

                            if (knoop.Identifier == kant.KnoopA.Identifier)
                                dichtbijsteKnopen.Add(kant.KnoopB);
                            else
                                dichtbijsteKnopen.Add(kant.KnoopA);

                            kortsteKanten.Add(kant);
                        }
                    }
                }
            }

            // (bij meerdere ‘laagste waarden’ kies er één uit)
            int index = random.Next(0, dichtbijsteKnopen.Count);

            if (kortsteKanten.Count <= 0)
            {
                return new KantKnoop(null, null);
            }
            else
            {
                return new KantKnoop(dichtbijsteKnopen[index], kortsteKanten[index]);
            }
        }

        public DataTable BuildMatrixTable(string tableName, List<Knoop> knopen, List<Kant> kanten)
        {
            DataTable table = new DataTable(tableName);

            for (int i = 0; i < knopen.Count; i++)
            {
                table.Columns.Add(knopen[i].Identifier, typeof(Kant));
            }

            table.Columns.Add("rowName", typeof(string));

            foreach (Knoop knoop in knopen)
            {
                List<Kant> matches = kanten.FindAll(k => k.KnoopA.Identifier == knoop.Identifier || k.KnoopB.Identifier == knoop.Identifier);

                Kant[] slots = new Kant[knopen.Count];

                for (int i = 0; i < slots.Length; i++)
                {
                    slots[i] = null;
                }

                foreach (Kant kant in matches)
                {
                    string targetId = kant.KnoopA.Identifier;
                    if (targetId == knoop.Identifier)
                        targetId = kant.KnoopB.Identifier;

                    int index = knopen.FindIndex(k => k.Identifier == targetId);
                    slots[index] = kant;
                }


                table.Rows.Add(slots);
                table.Rows[table.Rows.Count - 1]["rowName"] = knoop.Identifier;
            }

            return table;
        }

        // Return object
        private class KantKnoop
        {
            public KantKnoop(Knoop knoop, Kant kant)
            {
                Kant = kant;
                Knoop = knoop;
            }

            public bool HasANull()
            {
                if (Knoop == null || Kant == null)
                    return true;
                else
                    return false;
            }

            public Knoop Knoop { get; private set; }
            public Kant Kant { get; private set; }
        }
    }
}
