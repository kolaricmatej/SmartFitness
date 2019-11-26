using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace SmartFitness.Forms
{
    public partial class Statistika : Form
    {
        public List<int> OstvarenoPonavljanja { get; set; } = null;
        public List<DateTime> Datum { get; set; } = null;

        public Statistika()
        {
            InitializeComponent();
            PrikaziUcenike();
            DohvatiTreninge();
            PotrebnaNorma();
        }
        public void PrikaziUcenike()
        {
            ucenikBindingSource.DataSource = ucenik.DohvatiUcenikeKojiSuNaVjezbama();
        }

        public void PrikaziVjezbe(int ucenikId)
        {
            vjezbaBindingSource.DataSource = vjezba.DohvatiVjezbeUcenika(ucenikId);
        }

        public void DohvatiTreninge()
        {
            try
            {
                OstvarenoPonavljanja = null;
                Datum = null;
                if (dgvUcenici.CurrentRow != null)
                {
                    int ucenikId = int.Parse(dgvUcenici.CurrentRow.Cells[3].Value.ToString());
                    int vjezbaId = int.Parse(cboVjezba.SelectedValue.ToString());
                    using (var db = new SmartFitnessEntities())
                    {
                        this.OstvarenoPonavljanja = vjezba_ucenik.DohvatiPonavljanjaOdabraneVjezbeIUcenika(ucenikId,vjezbaId);
                        this.Datum = vjezba_ucenik.DohvatiDatumeOdabraneVjezbeIUcenika(ucenikId, vjezbaId);
                    }
                }
            }
            catch{}
        }

        public void AzurirajGraf()
        {
            try
            {
                DohvatiTreninge();
                OcistiGraf();
                DohvatiGraf();
                UkupniNapredak();
                StardardnaDevijacija();
                PotrebnaNorma();
            }
            catch {}
            if (cboVjezba.Items.Count == 0)
            {
                txtProsjek.Text = "-";
                txtDnevniNapredak.Text = "-";
                txtUkupniNapredak.Text = "-";
                txtPotrebnoVjezbati.Text = "-";
            }
        }

        public void StardardnaDevijacija()
        {
            double average = OstvarenoPonavljanja.Average();
            double sumOfDerivation = 0;
            foreach (double value in OstvarenoPonavljanja)
            {
                sumOfDerivation += (value) * (value);
            }
            double sumOfDerivationAverage = sumOfDerivation / (OstvarenoPonavljanja.Count - 1);
            double rezultat = Math.Sqrt(sumOfDerivationAverage - (average * average));
            txtDnevniNapredak.Text = rezultat > 0 ? rezultat.ToString() : "-";
            txtProsjek.Text = average > 0 ? average.ToString() : "-";
        }

        public void UkupniNapredak()
        {
            txtUkupniNapredak.Text =
                (OstvarenoPonavljanja.Max() - OstvarenoPonavljanja.Min()) > 0
                    ? (OstvarenoPonavljanja.Max() - OstvarenoPonavljanja.Min()).ToString()
                    : "-";
        }

        private void dgvUcenici_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var tmp = dgvUcenici.SelectedCells[3].Value;
                PrikaziVjezbe((int) tmp);
            }
            catch {}
            AzurirajGraf();
        }

        private void cboVjezba_SelectedIndexChanged(object sender, EventArgs e)
        {
            AzurirajGraf();
        }

        public void DohvatiGraf()
        {
            for (int i = 0; i < OstvarenoPonavljanja.Count; i++)
            {
                this.chartStatistikaVjezbe.Series["Ostvareno"].Points.AddXY(this.Datum[i], this.OstvarenoPonavljanja[i]);
            }
        }

        public void OcistiGraf()
        {
            foreach (var series in chartStatistikaVjezbe.Series)
            {
                series.Points.Clear();
            }
        }

        public void PotrebnaNorma()
        {
            try
            {
                OstvarenoPonavljanja = null;
                Datum = null;
                if (dgvUcenici.CurrentRow != null)
                {
                    int ucenikId = int.Parse(dgvUcenici.CurrentRow.Cells[3].Value.ToString());
                    int vjezbaId = int.Parse(cboVjezba.SelectedValue.ToString());
                    txtNorma.Text = vjezba_ucenik.DohvatiNormuVjezbe(ucenikId, vjezbaId).ToString();
                }
                int norma = int.Parse(txtNorma.Text);
                double prosjek = txtProsjek.Text.Length > 0 ? double.Parse(txtProsjek.Text) : 0;
                txtPotrebnoVjezbati.Text = norma > prosjek ? "Da" : "Ne";
            }
            catch {}
        }
    }
}
