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
    public partial class AzurirajNatjecanje : Form
    {
        public natjecanje Natjecanje { get; set; }
        public AzurirajNatjecanje(natjecanje natjecanje)
        {
            InitializeComponent();            this.Natjecanje = natjecanje;
            DohvatiSportove();
            PostaviVrijednosti();
        }

        public void PostaviVrijednosti()
        {
            txtOpis.Text = Natjecanje.opis;
            txtRazina.Text = Natjecanje.razina_natjecanja;
            txtMjesto.Text = Natjecanje.mjesto_odrzavanja;
            dateVjezbanja.Value = Natjecanje.datum_vrijeme;
            cboSport.SelectedValue = Natjecanje.id_sporta;
        }

        public void DohvatiSportove()
        {
            cboSport.DataSource = sport.DohvatiSportove();
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            try
            {
                var opis = txtOpis.Text;
                var razina_natjecanja = txtRazina.Text;
                var mjesto_odrzavanja = txtMjesto.Text;
                var datum_vrijeme = dateVjezbanja.Value;
                var id_sporta = (int)cboSport.SelectedValue;
                natjecanje natjecanje = natjecanje.DohvatiNatjecanjePomocuId(Natjecanje.id_natjecanja);
                if (natjecanje != null)
                {
                    natjecanje.AzurirajNatjecanje(natjecanje, opis, razina_natjecanja, mjesto_odrzavanja, datum_vrijeme,
                        id_sporta);

                    MessageBox.Show("Uspjesno azuriran!", "Azuriranje");
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show(@"Provjerite valjanost unesenih vrijednosti!");
            }
        }
    }
}
