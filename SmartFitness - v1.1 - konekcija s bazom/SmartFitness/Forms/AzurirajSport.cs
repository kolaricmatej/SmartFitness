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
    public partial class AzurirajSport : Form
    {
        public sport Selektiranisport { get; set; }
        public AzurirajSport(sport sport)
        {
            InitializeComponent();
            this.Selektiranisport = sport;
            txtDisciplina.Text = Selektiranisport.disciplina;
            txtNaziv.Text = Selektiranisport.naziv;
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            try
            {

                sport.AzuriranjeSporta(txtNaziv.Text, txtDisciplina.Text, Selektiranisport);
                MessageBox.Show(@"Uspjesno izmjenjen sport");
                
            }
            catch
            {
                MessageBox.Show(@"Provjerite valjanost unesenih vrijednosti!");
            }
            this.Close();
        }
    }
}
