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
    public partial class PopisVjezbi : Form
    {
        public PopisVjezbi()
        {
            InitializeComponent();
            DohvatiVjezbe();
        }

        public void DohvatiVjezbe()
        {
            vjezbaBindingSource.DataSource = vjezba.DohvatiVjezbe();
        }

        private void btnUnos_Click(object sender, EventArgs e)
        {
            try
            {
                var naziv = txtNaziv.Text;
                var opis = txtOpis.Text;
                var vrijemeVjezbanja = int.Parse(txtVrijeme.Text);
                var ponavljanja = int.Parse(txtPonavljanje.Text);

                vjezba.DodajVjezbu(naziv, opis, vrijemeVjezbanja, ponavljanja);
                DohvatiVjezbe();
            }
            catch
            {
                MessageBox.Show(@"Provjerite valjanost unesenih polja", @"Neispravan unos");
            }
           
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            if (dgvVjezbe.CurrentRow != null)
            {
                var azurirajVjezbu = new AzurirajVjezbu(dgvVjezbe.CurrentRow.DataBoundItem as vjezba);
                azurirajVjezbu.ShowDialog();
                DohvatiVjezbe();
            }
            else
            {
                MessageBox.Show(@"Provjerite ako je vjezba oznacena!", @"Greska");
            }
        }

        private void btnBrisi_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVjezbe.CurrentRow != null)
                {
                    vjezba vjezba = dgvVjezbe.CurrentRow.DataBoundItem as vjezba;
                    if (vjezba != null)
                    {
                        int vjezbaId = vjezba.id_vjezbe;
                        vjezba.ObrisiVjezbu(vjezbaId);

                        MessageBox.Show(@"Uspjesno obrisana vjezba", @"Obrisano");
                        DohvatiVjezbe();
                    }
                }
            }
            catch
            {
                MessageBox.Show(@"Dogodila se greska", @"Greska");
            }
        }
    }
}
