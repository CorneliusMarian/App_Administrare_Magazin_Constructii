using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NivelStocareDate;
using LibrarieModele;
using System.Configuration;

namespace Proiect_PIU
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            AdministrareClienti_FisierText adminClienti = new AdministrareClienti_FisierText(numeFisier);
            Clienti clientNou = new Clienti();
            int nrClienti = 0;
            adminClienti.GetClienti(out nrClienti);


            string optiune;
            do
            {
                Console.WriteLine("C. Citire clienti de la tastatura");
                Console.WriteLine("A. Afisarea ultimului client introdus");
                Console.WriteLine("F. Afisare clienti din fisier");
                Console.WriteLine("S. Salvare client in fisier");
                // Console.WriteLine("L. Problema nr. 4");

                Console.WriteLine("E. Afisarea furnizorilor");
                Console.WriteLine("X. Inchidere program");
                Console.Write("Alegeti o optiune: ");
                optiune = Console.ReadLine();

                switch (optiune.ToUpper())
                {
                    case "C":
                        clientNou = CitireClientiTastatura();
                        break;

                    case "A":
                        AfisareClienti(clientNou);
                        break;

                    case "F":
                        Clienti[] clienti = adminClienti.GetClienti(out nrClienti);
                        AfisareClienti(clienti, nrClienti);
                        break;

                    case "S":
                        int idClienti = nrClienti + 1;
                        clientNou.SetIdClienti(idClienti);
                        //adaugare masina in fisier
                        adminClienti.AddClient(clientNou);

                        nrClienti = nrClienti + 1;
                        break;

                    case "B":

                        break;

                    case "X":
                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta!");
                        break;
                }
            }
            while (optiune.ToUpper() != "X");

            Console.ReadLine();
        }

        public static Clienti CitireClientiTastatura()
        {
            Console.WriteLine("Introduceti numele");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti prenumele");
            string prenume = Console.ReadLine();

            Clienti client = new Clienti(0, nume, prenume);

            return client;
        }

        public static void AfisareClienti(Clienti clienti)
        {
            string infoClienti = string.Format("Clientul cu id-ul #{0} are numele: {1} {2}",
                   clienti.GetIdClienti(),
                   clienti.GetNume() ?? " NECUNOSCUT ",
                   clienti.GetPrenume() ?? " NECUNOSCUT ");

            Console.WriteLine(infoClienti);
        }

        public static void AfisareClienti(Clienti[] clienti, int nrClienti)
        {
            Console.WriteLine(" Clientii  sunt:");
            for (int contor = 0; contor < nrClienti; contor++)
            {
                AfisareClienti(clienti[contor]);
            }
        }
    }
}
