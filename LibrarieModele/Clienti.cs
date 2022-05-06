using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Clienti
    {
        private const char Separator_Principal_Fisier = ';';

        private const int ID = 0;
        private const int Nume = 1;
        private const int Prenume = 2;

       // private int idClient;
       //private string nume;
       //private string prenume;

        //Proprietati auto-implemented
        public int idClient { get; set; }
        public string nume { get; set; }
        public string prenume { get; set; }

        public Clienti()
        {
            nume = prenume = string.Empty;
        }

        public Clienti(int id, string nume, string prenume)
        {
            this.idClient = idClient;
            this.nume = nume;
            this.prenume = prenume;
        }

        public Clienti(string linieFisier)
        {
            var dateFisier = linieFisier.Split(Separator_Principal_Fisier);

            idClient = Convert.ToInt32(dateFisier[ID]);
            nume = dateFisier[Nume];
            prenume = dateFisier[Prenume];
        }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectClientiPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                Separator_Principal_Fisier,
                idClient.ToString(),
                (nume ?? " NECUNOSCUT "),
                (prenume ?? " NECUNOSCUT "));

            return obiectClientiPentruFisier;
        }

        public int GetIdClienti()
        {
            return idClient;
        }

        public string GetNume()
        {
            return nume;
        }

        public string GetPrenume()
        {
            return prenume;
        }

        public void SetIdClienti(int idClient)
        {
            this.idClient = idClient;
        }
    }
}