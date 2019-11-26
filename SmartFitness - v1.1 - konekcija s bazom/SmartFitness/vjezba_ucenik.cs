//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Windows.Forms;

namespace SmartFitness
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    public partial class vjezba_ucenik
    {
        public int id_vjezba_ucenik { get; set; }
        public int vjezba_id_vjezbe { get; set; }
        public int ucenik_id_ucenika { get; set; }
        public System.DateTime datum { get; set; }
        public int ostvareno_ponavljanja { get; set; }
    
        public virtual ucenik ucenik { get; set; }
        public virtual vjezba vjezba { get; set; }

        public static void DodajRezultatVjezbe(int vjezbaId, int ucenikId, DateTime datumVjezbanja, int brojPonavljanja)
        {
            using (var entities = new SmartFitnessEntities())
            {
                vjezba_ucenik vjezbaUcenik = new vjezba_ucenik
                {
                    vjezba_id_vjezbe = vjezbaId,
                    ucenik_id_ucenika = ucenikId,
                    datum = datumVjezbanja,
                    ostvareno_ponavljanja = brojPonavljanja
                };
                entities.vjezba_ucenik.Add(vjezbaUcenik);
                entities.SaveChanges();
            }
        }

        public static BindingList<vjezba_ucenik> DohvatiTreningeUcenika(int vjezbaId, ucenik ucenik)
        {
            BindingList<vjezba_ucenik> listaTreninga;
            using (var db = new SmartFitnessEntities())
            {
                var treninziUcenika =
                    db.vjezba_ucenik
                        .Where(t => t.vjezba_id_vjezbe == vjezbaId && t.ucenik_id_ucenika == ucenik.id_ucenika)
                        .ToList();
                listaTreninga = new BindingList<vjezba_ucenik>(treninziUcenika.ToList());
            }
            return listaTreninga;
        }

        public static void AzurirajTreningUcenika(vjezba_ucenik treningUcenika, DateTime datumVjezbanja, int ostvarenoPonavljanja)
        {
            using (var db = new SmartFitnessEntities())
            {
                var rezultat =
                    db.vjezba_ucenik.SingleOrDefault
                        (vu => vu.id_vjezba_ucenik == treningUcenika.id_vjezba_ucenik);
                if (rezultat != null)
                {
                    rezultat.datum = datumVjezbanja;
                    rezultat.ostvareno_ponavljanja = ostvarenoPonavljanja;
                    db.SaveChanges();
                }
            }
        }
        public static void ObrisiTreningUcenika(vjezba_ucenik trening)
        {
            using (var db = new SmartFitnessEntities())
            {

                db.vjezba_ucenik.Attach(trening);
                db.vjezba_ucenik.Remove(trening);
                db.SaveChanges();
            }
        }

        public static List<int> DohvatiPonavljanjaOdabraneVjezbeIUcenika(int ucenikId, int vjezbaId)
        {
            List<int> ostvarenoPonavljanja = null;
            using (var db = new SmartFitnessEntities())
            {
                ostvarenoPonavljanja = db.vjezba_ucenik
                    .Where(b => b.ucenik_id_ucenika == ucenikId && b.vjezba_id_vjezbe == vjezbaId)
                    .Select(u => u.ostvareno_ponavljanja).ToList();
            }
            return ostvarenoPonavljanja;
        }

        public static List<DateTime> DohvatiDatumeOdabraneVjezbeIUcenika(int ucenikId, int vjezbaId)
        {
            List<DateTime> datumi = null;
            using (var db = new SmartFitnessEntities())
            {
                datumi = db.vjezba_ucenik
                    .Where(b => b.ucenik_id_ucenika == ucenikId && b.vjezba_id_vjezbe == vjezbaId)
                    .Select(u => u.datum).ToList();
            }
            return datumi;
        }

        public static int? DohvatiNormuVjezbe(int ucenikId, int vjezbaId)
        {
            int? tmp = 0;
            using (var db = new SmartFitnessEntities())
            {
                tmp = db.vjezba_ucenik
                    .Where(b => b.ucenik_id_ucenika == ucenikId && b.vjezba_id_vjezbe == vjezbaId)
                    .Select(u => u.vjezba.ponavljanja).First();
            }
            return tmp;
        }
    }
}
