using System;
using System.Globalization;

class GestionStudenti
{
    static string[] studenti = { "Anna", "Luca", "Maya", "Rami", "Zoe" };
    static string[] materie = { "Matematica", "Italiano", "Inglese", "Storia" };
    static int[,] voti = new int[5, 4];
    static List<string>[] noteStudente = new List<string>[studenti.Length];

    public static void Main(string[] args)
    {
        InizializzazioneVoti();

        bool continua = true;
        while (continua)
        {
            Console.WriteLine($"----Menu----");
            Console.WriteLine($"1-Visualizza registro");
            Console.WriteLine($"2-Inserisci/Aggiorna voto");
            Console.WriteLine($"3-Statistiche");
            Console.WriteLine($"4-Note & Log");
            Console.WriteLine($"5-Ricerca");
            Console.WriteLine($"6-Borsa di studio");
            Console.WriteLine($"0-Esci");

            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    break;
                case 2:
                    GestisciVoto();
                    break;
                case 3:
                    //Statistiche(studenti, materie, voti);
                    break;
                case 4:
                    //Log();
                    break;
                case 5:
                    // Ricerca(studente, voto);
                    break;
                case 6:
                    BorsaDiStudio();
                    break;
                case 0:
                    continua = false;
                    break;
                default:
                    Console.WriteLine($"Selezione errata.");
                    break;
            }
        }
    }

    public static void InizializzazioneVoti()
    {
        Random r = new();

        for (int i = 0; i < studenti.Length; i++)
        {
            for (int j = 0; j < materie.Length; j++)
            {
                voti[i, j] = r.Next(1, 11);
            }
        }
    }

    public static void GestisciVoto()
    {
        Console.WriteLine($"Seleziona studente: ");
        //elenco gli studenti
        for (int i = 0; i < studenti.Length; i++)
        {
            Console.WriteLine($"{i} - {studenti[i]}");
        }
        int indiceStudente = int.Parse(Console.ReadLine());

        Console.WriteLine($"Seleziona materia: ");
        //elenco le materie
        for (int j = 0; j < materie.Length; j++)
        {
            Console.WriteLine($"{j} - {materie[j]}");
        }
        int indiceMateria = int.Parse(Console.ReadLine());

        Console.WriteLine($"Inserisci voto: ");
        int votoInserito = int.Parse(Console.ReadLine());

        voti[indiceStudente, indiceMateria] = votoInserito;
        Console.WriteLine($"Voto inserito!");
    }

    public static void BorsaDiStudio()
    {
        double soglia = 6;

        Console.WriteLine($"Studenti meritevoli di borsa di studio: ");

        for (int i = 0; i < studenti.Length; i++)
        {
            bool insufficienza = false;
            double totale = 0;

            for (int j = 0; j < materie.Length; j++)
            {
                totale += voti[i, j];
                if (voti[i, j] < 6)
                {
                    insufficienza = true;
                }
            }

            double media = totale / materie.Length;

            if (media >= soglia && insufficienza == false)
            {
                Console.WriteLine($"{studenti[i]} - {media}");
            }
        }
    }
}


