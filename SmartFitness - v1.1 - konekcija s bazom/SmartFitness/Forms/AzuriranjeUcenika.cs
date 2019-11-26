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
    public partial class AzuriranjeUcenika : Form
    {
        public ucenik Selektiraniucenik { get; set; }
        public AzuriranjeUcenika(ucenik ucenik)
        {
            InitializeComponent();
            this.Selektiraniucenik = ucenik;
            

            txtIme.Text = Selektiraniucenik.ime;
            txtPrezime.Text = Selektiraniucenik.prezime;
            txtRazred.Text = Selektiraniucenik.razred.ToString();
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            try
            {
                ucenik.AzurirajUcenika(txtIme.Text, txtPrezime.Text, Convert.ToInt32(txtRazred.Text),Selektiraniucenik);
                
                MessageBox.Show(@"Uspjesno izmjenjen učenik");
                
            }
            catch
            {
                MessageBox.Show(@"Provjerite valjanost unesenih vrijednosti!");
            }
            this.Close();
        }
    }
}
