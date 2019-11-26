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
    public partial class PopisSportova : Form
    {
        public PopisSportova()
        {
            InitializeComponent();
            PrikaziSportove();
        }

        public void PrikaziSportove()
        {
            
            sportBindingSource.DataSource = sport.DohvatiSportove();
        }

        private void btnNatrag_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(txtNaziv.Text=="" && txtDisciplina.Text==""))
                {
                    sport.DodavanjeSporta(txtNaziv.Text, txtDisciplina.Text);
                    MessageBox.Show(@"Uspješno dodan sport");
                    txtDisciplina.Clear();
                    txtNaziv.Clear();
                }
                else
                {
                    MessageBox.Show(@"Imate prazna polja!");
                }
                

            }
            catch
            {
                MessageBox.Show(@"Provjerite valjanost unesenih vrijednosti!");
            }
            PrikaziSportove();
            
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            
            var sport = dgvSportovi.SelectedRows[0].DataBoundItem as sport;
            if (sport!=null)
            {
                AzurirajSport frm = new AzurirajSport(sport);
                frm.ShowDialog();
                PrikaziSportove();
            }
            
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            sport selektiraniSport = sportBindingSource.Current as sport;
            if (selektiraniSport != null)
            {
                if (MessageBox.Show("Da li ste sigurni?", "Upozorenje!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    sport.BrisanjeSporta(selektiraniSport);
                    PrikaziSportove();
                }
            }
        }
    }
}
