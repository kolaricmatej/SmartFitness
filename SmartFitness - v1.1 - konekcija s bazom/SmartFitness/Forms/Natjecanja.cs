﻿using System;
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
    public partial class Natjecanja : Form
    {
        public int UcenikId { get; set; }
        public int NatjecanjeId { get; set; }
        public Natjecanja()
        {
            InitializeComponent();
            DohvatiSportove();
            DohvatiNajboljeOcijeneSportova((int)cboSport.SelectedValue);
            txtGodina.Text = DateTime.Now.Year.ToString();
            DohvatiNatjecanja();
            DohvatiUcenikeNaOdabranomNatjecanju();
        }

        void dgvStudentiKojiSeNatjecu_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudentiKojiSeNatjecu.SelectedCells.Count > 0)
                dgvStudentiKojiSeNatjecu.ClearSelection();
        }

        public void DohvatiNatjecanja()
        {
            int godina = int.Parse(txtGodina.Text);
            int sportId = (int) cboSport.SelectedValue;

            natjecanjeBindingSource.DataSource = natjecanje.DohvatiNatjecanjaPoGodiniISportu(godina, sportId);
        }

        public void DohvatiSportove()
        {
            sportBindingSource.DataSource = sport.DohvatiSportove();
        }

        public void DohvatiNajboljeOcijeneSportova(int sportId)
        {
                dgvSportUcenik.DataSource = ucenik.DohvatiNajboljeUcenikeNaOdabranomSportu(sportId);
                dgvSportUcenik.Columns[0].Visible = false;
        }

        private void cboSport_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int sportId = (int) cboSport.SelectedValue;
                DohvatiNajboljeOcijeneSportova(sportId);
                DohvatiNatjecanja();
                DohvatiUcenikeNaOdabranomNatjecanju();
            }
            catch {}
        }

        private void btnDodajNaNatjecanje_Click(object sender, EventArgs e)
        {
            try
            {
                this.UcenikId = (int) dgvSportUcenik.SelectedRows[0].Cells[0].Value;
                this.NatjecanjeId = (int) dgvNatjecanja.SelectedRows[0].Cells[5].Value;
                int godinaSudjelovanja = int.Parse(txtGodina.Text);

                var provjeraNatjecanja = natjecanje_ucenik.DohvatiNatjecanjeUcenika(UcenikId, NatjecanjeId);
                if (provjeraNatjecanja != null)
                {
                    MessageBox.Show(@"Ucenik je vec dodan na odabrano natjecanje", @"Greska");
                    return;
                }
                natjecanje_ucenik.DodajUcenikaNaNatjecanje(UcenikId, godinaSudjelovanja, NatjecanjeId);
                
                MessageBox.Show(@"Uspjesno dodan ucenik na natjecanje", @"Dodano");
                DohvatiUcenikeNaOdabranomNatjecanju();
            }
            catch
            {
                MessageBox.Show(@"Dogodila se greska prilikom dodavanja ucenika na natjecanje", @"Greska");
            }
            

        }

        public void DohvatiUcenikeNaOdabranomNatjecanju()
        {
            try
            {
                int natjecanjeId = (int)dgvNatjecanja.SelectedRows[0].Cells[5].Value;
                if (dgvNatjecanja.SelectedRows.Count > 0)
                {
                    dgvStudentiKojiSeNatjecu.DataSource = ucenik.DohvatiSveUcenikeNaOdabranomNatjecanju(natjecanjeId);
                }
                else
                {
                    dgvStudentiKojiSeNatjecu.DataSource = null;
                }
            }
            catch
            {
                dgvStudentiKojiSeNatjecu.DataSource = null;
            }
        }

        private void btnAzurirajUcenikaNaNatjecanju_Click(object sender, EventArgs e)
        {
            try
            {
                this.UcenikId = (int) dgvSportUcenik.SelectedRows[0].Cells[0].Value;
                var azurirajUcenikaNaNatjecanju = new AzurirajUcenikaNaNatjecanju(UcenikId);
                azurirajUcenikaNaNatjecanju.ShowDialog();
                DohvatiUcenikeNaOdabranomNatjecanju();
            }
            catch
            {
                MessageBox.Show(@"Dogodila se greska, provjerite da li je ucenik oznacen!", @"Greska");
            }
            
        }

        private void dgvNatjecanja_SelectionChanged(object sender, EventArgs e)
        {
            DohvatiUcenikeNaOdabranomNatjecanju();
        }
    }
}
