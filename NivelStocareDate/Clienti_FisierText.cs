using System;
using LibrarieModele;
using System.IO;

namespace NivelStocareDate
{
    public class AdministrareClienti_FisierText
    {
        private const int NR_MAX_CLIENTI = 50;
        private string numeFisier;

        public AdministrareClienti_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddClient(Clienti client)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(client.ConversieLaSir_PentruFisier());
            }
        }

        public Clienti[] GetClienti(out int nrClienti)
        {
            Clienti[] clienti = new Clienti[NR_MAX_CLIENTI];

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrClienti = 0;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    clienti[nrClienti++] = new Clienti(linieFisier);
                }
            }

            return clienti;
        }
    }
}
