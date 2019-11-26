using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.SqlServer;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFitness.Forms
{
    public partial class DodajRezultatVjezbe : Form
    {
        public DodajRezultatVjezbe()
        {
            InitializeComponent();
            PrikaziUcenike();
            PrikaziVjezbe();
        }

        public void PrikaziUcenike()
        {
            ucenikBindingSource.DataSource = ucenik.DohvatiUcenike();
        }

        public void PrikaziVjezbe()
        {
            vjezbaBindingSource.DataSource = vjezba.DohvatiVjezbe();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                int vjezbaId = int.Parse(cboVjezba.SelectedValue.ToString());
                if (dgvUcenici.CurrentRow != null)
                {
                    int ucenikId = int.Parse(dgvUcenici.CurrentRow.Cells[3].Value.ToString());
                    DateTime datumVjezbanja = dateVjezbanja.Value.Date;
                    int brojPonavljanja = int.Parse(txtPonavljanja.Text);
                
                    vjezba_ucenik.DodajRezultatVjezbe(vjezbaId, ucenikId, datumVjezbanja, brojPonavljanja);
                    MessageBox.Show(@"Uspjesno dodan trening uceniku");
                }
            }
            catch
            {
                MessageBox.Show(@"Provjerite valjanost unesenih vrijednosti!");
            }
        }
        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            try
            {
                var ucenik = dgvUcenici.SelectedRows[0].DataBoundItem as ucenik;
                var azurirajRezultatVjezbe = new AzurirajRezultatVjezbe(ucenik);
                azurirajRezultatVjezbe.ShowDialog();
            }
            catch {}
        }
    }
}
