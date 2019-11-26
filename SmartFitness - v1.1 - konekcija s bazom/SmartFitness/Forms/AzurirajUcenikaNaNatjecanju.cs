using System;
using System.Linq;
using System.Windows.Forms;

namespace SmartFitness.Forms
{
    public partial class AzurirajUcenikaNaNatjecanju : Form
    {
        public int UcenikId { get; set; }
        public ucenik Ucenik { get; set; }
        public AzurirajUcenikaNaNatjecanju(int ucenikId)
        {
            InitializeComponent();
            this.UcenikId = ucenikId;
            DohvatiUcenika();
            DohvatiNatjecanjaUcenika();
            txtUcenik.Text = Ucenik.ime + @" " + Ucenik.prezime + @" " + Ucenik.razred;
        }

        private void DohvatiNatjecanjaUcenika()
        {
            dgvUcenikNatjecanje.DataSource = natjecanje_ucenik.DohvatiNatjecanjaUcenika(UcenikId);
            dgvUcenikNatjecanje.Columns[5].Visible = false;
        }

        public void DohvatiUcenika()
        {
            this.Ucenik = ucenik.DohvatiUcenikaPoIdu(UcenikId);
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUcenikNatjecanje.CurrentRow != null)
                {
                    int natjecanjeId = (int) dgvUcenikNatjecanje.SelectedRows[0].Cells[5].Value;
                    var natjecanjeUcenika = natjecanje_ucenik.DohvatiNatjecanjePoIdu(natjecanjeId);
                    if (natjecanjeUcenika != null)
                    {
                        natjecanje_ucenik.ObrisiNatjecanjeUcenika(natjecanjeUcenika);
                        MessageBox.Show(@"Uspjesno obrisano natjecanje ucenika!", @"Uspjesno");
                        DohvatiNatjecanjaUcenika();
                    }
                }
            }
            catch
            {
                MessageBox.Show(@"Dogodila se greska provjerite ako je natjecanje selektirano!", @"Greska");
            }
        }
    }
}
