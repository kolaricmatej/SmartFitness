using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unos_sporta;

namespace SmartFitness
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }

        private void txtKorisnickoIme_Enter(object sender, EventArgs e)
        {
            if (txtKorisnickoIme.Text.Equals("Korisnicko ime"))
            {
                txtKorisnickoIme.Text = "";
                txtKorisnickoIme.ForeColor = Color.Black;
            }
        }

        private void txtKorisnickoIme_Leave(object sender, EventArgs e)
        {
            if (txtKorisnickoIme.Text == "")
            {
                txtKorisnickoIme.Text = "Korisnicko ime";
                txtKorisnickoIme.ForeColor = Color.Silver;
            }
        }

        private void txtLozinka_Enter(object sender, EventArgs e)
        {
            if (txtLozinka.Text == "Lozinka")
            {
                txtLozinka.Text = "";
                txtLozinka.ForeColor = Color.Black;
            }
        }

        private void txtLozinka_Leave(object sender, EventArgs e)
        {
            if (txtLozinka.Text == "")
            {
                txtLozinka.Text = "Lozinka";
                txtLozinka.ForeColor = Color.Silver;
            }
        }

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool ProvjeraKorisnika()
        {
            var korisnickoIme = txtKorisnickoIme.Text;
            var lozinka = txtLozinka.Text;
            return Unos_sporta.Prijava.ProvjeraPrijave(korisnickoIme,lozinka);
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            if (ProvjeraKorisnika())
            {
                PocetnaForma pocetnaForma = new PocetnaForma();
                this.Hide();
                pocetnaForma.ShowDialog();
                this.Show();
                txtKorisnickoIme.Text = "";
                txtLozinka.Text = "";
                SendKeys.Send("+{TAB}");
            }
            else
            {
                MessageBox.Show(@"Neispravan unos podataka", @"Greška", MessageBoxButtons.OK);
            }
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString().Equals("F1"))
            {
                string nazivDatoteke = "Pomoc.chm";
                string putanjaDoMape = Path.Combine(Environment.CurrentDirectory, @"Data\", nazivDatoteke);
                string pravaPutanja = Path.GetFullPath(Path.Combine(putanjaDoMape, @"..\..\..\..\..\" + "\\" + nazivDatoteke));
                Help.ShowHelp(this, pravaPutanja);
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Login_KeyDown);
        }

       
    }
}
