using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFitness.Forms
{
    public partial class AzurirajOcijenuUcenika : Form
    {
        public ucenik Ucenik { get; set; }
        public sport Sport { get; set; }
        public sport_ucenik SportUcenik { get; set; } 

        public AzurirajOcijenuUcenika(ucenik ucenik, sport sport)
        {
            InitializeComponent();
            this.Ucenik = ucenik;
            this.Sport = sport;
            Postavi();
            DohvatiOcijene();
            DohvatiOcijenuSporta();
        }

        public void DohvatiOcijene()
        {
            for (int i = 1; i < 6; i++)
            {
                cboOcijena.Items.Add(i);
            }
        }

        public void Postavi()
        {
            txtUcenik.Text = Ucenik.ime + " " + Ucenik.prezime + " " + Ucenik.razred;
            txtSport.Text = Sport.naziv;
        }

        public void DohvatiOcijenuSporta()
        {
            try
            {
                this.SportUcenik = sport_ucenik.DohvatiSportIOcijenuUcenika(Ucenik, Sport);

                txtOpis.Text = SportUcenik.opis;
                cboOcijena.SelectedItem = SportUcenik.ocijena;
                dateVjezbanja.Value = SportUcenik.datum;
            }
            catch
            {
                MessageBox.Show(@"Morate dodati ocijenu uceniku kako bi ju mogli azurirati!");
                this.Close();
            }
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            try
            {
                var datum = dateVjezbanja.Value;
                var ocijena = int.Parse(cboOcijena.Text);
                var opis = txtOpis.Text;

                using (var db = new SmartFitnessEntities())
                {
                    var sportUcenika = sport_ucenik.DohvatiSportIOcijenuUcenika(Ucenik, Sport);
                    if (sportUcenika != null)
                    {
                        sport_ucenik.AzurirajOcijenuUcenika(sportUcenika, datum, ocijena, opis);
                        MessageBox.Show(@"Uspjesno azuriran!", @"Azuriranje");
                        this.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show(@"Provjerite valjanost unesenih vrijednosti!");
            }
        }
    }
}
