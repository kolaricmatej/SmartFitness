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
    public partial class PopisUcenika : Form
    {
        public PopisUcenika()
        {
            InitializeComponent();
            PrikaziUcenike();
        }


        public void PrikaziUcenike()
        {           
            ucenikBindingSource.DataSource = ucenik.DohvatiUcenike();
            
        }

        private void btnNatrag_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                ucenik.DodajUcenika(txtIme.Text, txtPrezime.Text, Convert.ToInt32(txtRazred.Text));
                MessageBox.Show(@"Uspješno dodan učenik!");
                txtIme.Clear();
                txtPrezime.Clear();
                txtRazred.Clear();
            }
            catch
            {
                MessageBox.Show(@"Provjerite valjanost unesenih vrijednosti!");
            }
            PrikaziUcenike();
            
        }

        private void btnAzurirajObrisi_Click(object sender, EventArgs e)
        {
            
            var ucenik = dgvUcenici.SelectedRows[0].DataBoundItem as ucenik;
            if (ucenik !=null)
            {
                AzuriranjeUcenika frm = new AzuriranjeUcenika(ucenik);
                frm.ShowDialog();
                PrikaziUcenike();
            }
            
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            ucenik selektiraniUcenik = ucenikBindingSource.Current as ucenik;
            if (selektiraniUcenik != null)
            {
                if (MessageBox.Show("Da li ste sigurni?", "Upozorenje!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    ucenik.ObrisiUcenika(selektiraniUcenik);
                    PrikaziUcenike();
                }
            }
        }
    }
}

