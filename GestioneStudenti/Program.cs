using System;

class GestionStudenti
{
    static string[] studenti = { "Anna", "Luca", "Maya", "Rami", "Zoe" };
    static string[] materie = { "Matematica", "Italiano", "Inglese", "Storia" };
    static int[,] voti = new int[5, 4];

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
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 0:
                    continua = false;
                    break;
                default:
                    Console.WriteLine($"Selezione errata. ");
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
}


