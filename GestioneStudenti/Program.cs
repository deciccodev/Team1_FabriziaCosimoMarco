using System;


//punto 2

class GestionStudenti
{
    public static void Main(string[] args)
    {
    }

    public static void VisualizzaRegistro()
    {
        Console.WriteLine(new string('=', 30));
        for (int i = 0; i < voti.GetLength(0); i++)
        {
            Console.WriteLine($"Scheda Ricerca: {studenti[i]}");
            Console.WriteLine(new string('-', 30));
            for (int j = 0; j < voti.GetLength(1); j++)
            {
                // Ciclo tutte le colonne di "voti" per stampare la materia attuale (usando j) e i voti
                Console.WriteLine($"{materie[j], 2}: {voti[i,j], 2}");
            }
            Console.WriteLine(new string('=', 30));
        }

        Console.WriteLine("\nPremere un tasto per continuare...");
        Console.ReadKey(true);
        Console.Clear();
    }

    public static void Ricerca(string studente, int sogliaVoto)
    {
        if (string.IsNullOrEmpty(studente) || sogliaVoto is < 1 or > 10)
        {
            Console.WriteLine("Errore: Inserire un nome valido e un voto tra 1 e 10.");
        }

        studente = char.ToUpper(studente[0]) + studente.Substring(1).ToLower();
        int idxStudente = Array.IndexOf(studenti, studente);

        if (idxStudente is -1) 
        {
            Console.WriteLine("Non è stato trovato nessuno studente che rispetti i filtri forniti.");
            Console.WriteLine("\nPremere un tasto per continuare...");
            Console.ReadKey(true);
            Console.Clear();
        }

        Dictionary<string, int> materieVoti = [];

        for (int j = 0; j < voti.GetLength(1); j++)
        {
            if (voti[idxStudente, j] >= sogliaVoto) { materieVoti.Add(materie[j], voti[idxStudente, j]); }
        }

        if (materieVoti.Count > 0) {
            Console.WriteLine(new string('=', 30));
            Console.WriteLine($"Scheda Ricerca: {studente}");
            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"Filtro: Voto ≥ {sogliaVoto}");
            Console.WriteLine(new string('-', 30));
            foreach (var materiaVoto in materieVoti) { 
                Console.WriteLine($"{materiaVoto.Key} => {materiaVoto.Value}");
            }
        } else {
            Console.WriteLine("Non è stato trovato nessuno studente che rispetti i filtri forniti.");     
        }

        Console.WriteLine(new string('=', 30));
        Console.WriteLine("\nPremere un tasto per continuare...");
        Console.ReadKey(true);
        Console.Clear();
    }

    public static void Media(string[] studenti, string[] materie, int[,] voti)
    {
        int numStudenti = studenti.Length;
        int numMaterie = materie.Length;

        float[] mediaStudenti = new float[numStudenti];
        float[] mediaMaterie = new float[numMaterie];

        int votoMin = voti[0, 0];
        int votoMax = voti[0, 0];

        int minI = 0, minJ = 0;
        int maxI = 0, maxJ = 0;

        for (int i = 0; i < numStudenti; i++)
        {
            for (int j = 0; j < numMaterie; j++)
            {
                int voto = voti[i, j];

                // Somme per medie
                mediaStudenti[i] += voto;
                mediaMaterie[j] += voto;

                if (voto < votoMin)
                {
                    votoMin = voto;
                    minI = i;
                    minJ = j;
                }

                if (voto > votoMax)
                {
                    votoMax = voto;
                    maxI = i;
                    maxJ = j;
                }
            }
        }

        for (int i = 0; i < numStudenti; i++)
            mediaStudenti[i] /= numMaterie;

        for (int j = 0; j < numMaterie; j++)
            mediaMaterie[j] /= numStudenti;

        // Stampa risultati
        Console.WriteLine("Media per studente:");
        for (int i = 0; i < numStudenti; i++)
            Console.WriteLine(studenti[i] + ": " + mediaStudenti[i]);

        Console.WriteLine("\nMedia per materia:");
        for (int j = 0; j < numMaterie; j++)
            Console.WriteLine(materie[j] + ": " + mediaMaterie[j]);

        Console.WriteLine("\nVoto minimo: " + votoMin +
            " (" + studenti[minI] + ", " + materie[minJ] + ")");

        Console.WriteLine("Voto massimo: " + votoMax +
            " (" + studenti[maxI] + ", " + materie[maxJ] + ")");
    }

    public static void Log()
    {
        List<string> note = new List<string>();
        List<string> log = new List<string>();
        bool continua = true;

        do
        {
            Console.WriteLine("1. Inserisci Nota");
            Console.WriteLine("2. Visualizza Note Presenti");
            Console.WriteLine("3. Ricerca Nota");
            Console.WriteLine("4. Log (ultime 10 azioni)");
            Console.WriteLine("5. Torna Indietro");

            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.Write("Inserisci il nome dello studente: ");
                    string s = Console.ReadLine();

                    Console.Write("Inserisci la nota: ");
                    string n = Console.ReadLine();

                    string nota = $"{s} - {n}";
                    note.Add(nota);

                    AggiungiLog(log, $"Inserita nota per lo studente: {s}");
                    break;
                case "2":
                    if (note.Count > 0)
                    {
                        Console.WriteLine("Note presenti nel sistema:");
                        foreach (var item in note)
                            Console.WriteLine(item);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Non sono presenti note nel sistema!\n");
                    }

                    AggiungiLog(log, "Visualizzate note nel sistema");
                    break;
                case "3":
                    Console.Write("Inserisci il nome dello studente: ");
                    string nome = Console.ReadLine();

                    bool trovato = false;

                    foreach (var item in note)
                    {
                        if (item.StartsWith(nome + " -"))
                        {
                            Console.WriteLine(item);
                            trovato = true;
                        }
                    }

                    if (!trovato)
                    {
                        Console.WriteLine($"Non sono presenti note per lo studente: {nome}!\n");
                    }

                    AggiungiLog(log, "Effettuata ricerca nota");
                    break;
                case "4":
                    Console.WriteLine("Ultime azioni:");
                    foreach (var item in log)
                        Console.WriteLine(item);
                    Console.WriteLine();

                    AggiungiLog(log, "Visualizzazione lista log");
                    break;
                case "5":
                    AggiungiLog(log, "Tornato al menu precedente");
                    Console.WriteLine("Ritorno al menu precedente...\n");
                    continua = false;
                    break;

                default:
                    Console.WriteLine("Errore, selezione opzione!\n");
                    break;
            }

        } while (continua);
    }

    private static void AggiungiLog(List<string> log, string messaggio)
    {
        if (log.Count == 10)
            log.RemoveAt(0);

        log.Add(messaggio);
    }
}