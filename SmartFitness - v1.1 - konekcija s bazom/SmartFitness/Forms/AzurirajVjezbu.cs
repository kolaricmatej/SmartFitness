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
    public partial class AzurirajVjezbu : Form
    {
        public vjezba Vjezba { get; set; }

        public AzurirajVjezbu(vjezba vjezba)
        {
            InitializeComponent();
            this.Vjezba = vjezba;
            PopuniFormu();
        }

        public void PopuniFormu()
        {
            txtNaziv.Text = Vjezba.naziv;
            txtOpis.Text = Vjezba.opis;
            txtVrijeme.Text = Vjezba.vrijeme_vjezbanja.ToString();
            txtPonavljanje.Text = Vjezba.ponavljanja.ToString();
        }

        public void Azuriraj()
        {
            try
            {
                var naziv = txtNaziv.Text;
                var opis = txtOpis.Text;
                var ponavljanja = int.Parse(txtPonavljanje.Text);
                var vrijeme_vjezbanja = int.Parse(txtVrijeme.Text);

                using (var db = new SmartFitnessEntities())
                {
                    vjezba vjezba = db.vjezbas.FirstOrDefault(o => o.id_vjezbe == Vjezba.id_vjezbe);
                    if (vjezba != null)
                    {
                        vjezba.naziv = naziv;
                        vjezba.opis = opis;
                        vjezba.ponavljanja = ponavljanja;
                        vjezba.vrijeme_vjezbanja = vrijeme_vjezbanja;
                        db.SaveChanges();
                        MessageBox.Show(@"Uspjesno azurirana vjezba!", @"Uspjesno dodana vjezba");
                        this.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show(@"Dogodila se greska", @"Greska");
            }
        }


    private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            Azuriraj();
        }
    }
}
