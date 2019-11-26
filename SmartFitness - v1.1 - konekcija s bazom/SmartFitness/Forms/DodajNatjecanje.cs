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
    public partial class DodajNatjecanje : Form
    {
        public DodajNatjecanje()
        {
            InitializeComponent();
            DohvatiNatjecanjaISport();
        }

        public void DohvatiNatjecanjaISport()
        {
            DohvatiNatjecanja();
            DohvatiSport();
        }

        public void DohvatiNatjecanja()
        {
            natjecanjeBindingSource.DataSource = natjecanje.DohvatiNatjecanja();
        }

        public void DohvatiSport()
        {
            BindingList<sport> listaSportova = sport.DohvatiSportove();
            sportBindingSource.DataSource = listaSportova;
            sportBindingSource1.DataSource = listaSportova;
        }

        private void btnDodajNatjecanje_Click(object sender, EventArgs e)
        {
            var opis = txtOpis.Text;
            var razina_natjecanja = txtRazina.Text;
            var mjesto_odrzavanja = txtMjesto.Text;
            var datum_vrijeme = dateVjezbanja.Value;
            var id_sporta = (int) cboSport.SelectedValue;
            try
            {
                natjecanje.DodajNatjecanje(opis, razina_natjecanja, mjesto_odrzavanja, datum_vrijeme, id_sporta);
                MessageBox.Show("Uspjesno dodano natjecanje!", "Dodano");
                DohvatiNatjecanja();
            }
            catch
            {
                MessageBox.Show("Provjerite popunjenost forme!", "Greska");
            }
            
        }

        private void btnAzurirajNatjecanje_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNatjecanja.CurrentRow != null)
                {
                    var azurirajNatjecanje = new AzurirajNatjecanje(dgvNatjecanja.CurrentRow.DataBoundItem as natjecanje);
                    azurirajNatjecanje.ShowDialog();
                    DohvatiNatjecanja();
                }
            }
            catch
            {
                MessageBox.Show(@"Niste odabrali natjecanje", @"Greska");
            }
            
        }

        private void btnObrisiNatjecanje_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNatjecanja.CurrentRow != null)
                {
                    var natjecanje = dgvNatjecanja.CurrentRow.DataBoundItem as natjecanje;
                    if (natjecanje != null)
                    {
                        natjecanje.ObrisiNatjecanje(natjecanje);
                    }
                }
            }
            catch
            {
                MessageBox.Show(@"Dogodila se greska provjerite popunjenost!", @"Greska!");
            }
        }
    }
}
