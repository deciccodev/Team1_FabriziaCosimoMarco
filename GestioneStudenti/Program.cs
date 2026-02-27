using System;
using System.Globalization;

class GestionStudenti
{
    static string[] studenti = { "Anna", "Luca", "Maya", "Sabrina", "Zoe" };
    static string[] materie = { "Matematica", "Italiano", "Inglese", "Storia" };
    static int[,] voti = new int[5, 4];

    static List<string> log = new List<string>();

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
            Console.WriteLine($"7-Media Studenti");
            Console.WriteLine($"0-Esci");

            int scelta = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (scelta)
            {
                case 1:
                    VisualizzaRegistro();
                    AggiungiLog(log, "Visualizzato Registro Voti");
                    break;
                case 2:
                    GestisciVoto();
                    AggiungiLog(log, "Aggiornato voto studente");
                    break;
                case 3:
                    Statistiche(studenti, materie, voti);
                    AggiungiLog(log, "Visualizzate statistiche studenti / materie");
                    break;
                case 4:
                    Log();
                    break;
                case 5:
                    Console.WriteLine("Nome studente: ");
                    string studente = Console.ReadLine();
                    Console.WriteLine("Soglia voto: ");
                    int voto = int.Parse(Console.ReadLine());
                    Ricerca(studente, voto);

                    AggiungiLog(log, "Effettuata ricerca per soglia studente");
                    break;
                case 6:
                    BorsaDiStudio();
                    AggiungiLog(log, "Visionata lista studenti meritevoli");
                    break;
                case 7:
                    MediaStudenti();
                    AggiungiLog(log, "Visualizzata classifica media studenti");
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

    public static void VisualizzaRegistro()
    {
        
        Console.WriteLine(new string('=', 25));
        for (int i = 0; i < voti.GetLength(0); i++)
        {
            Console.WriteLine($"Scheda: {studenti[i]}\n" + new string('-', 25));
            for (int j = 0; j < voti.GetLength(1); j++)
            {
                // Formatta e stampa i risultati per ogni singola materia
                Console.WriteLine($"{materie[j], -11}: {voti[i,j]}");
            }
            Console.WriteLine(new string('=', 25));
        }

        Console.WriteLine("\nPremere un tasto per continuare...");
        Console.ReadKey(true);
        Console.Write("\x1b[3J");
        Console.Clear();
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

    public static void Statistiche(string[] studenti, string[] materie, int[,] voti)
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
        //List<string> log = new List<string>();
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

    public static void Ricerca(string studente, int sogliaVoto)
    {
        if (string.IsNullOrEmpty(studente) || sogliaVoto is < 1 or > 10)
        {
            Console.WriteLine("Errore: Inserire un nome valido e un voto tra 1 e 10.");
            Console.WriteLine("\nPremere un tasto per continuare...");
            Console.ReadKey(true);
            Console.Write("\x1b[3J");
            Console.Clear();
            return;
        }

        // Formatto il nome dello studente (Prima lettera in maiuscolo, il resto in minuscolo)
        studente = char.ToUpper(studente[0]) + studente.Substring(1).ToLower();
        // Ricavo l'indice posizionale dello studente (se non presente, ritorna -1)
        int idxStudente = Array.IndexOf(studenti, studente);


        // Se non presente...
        if (idxStudente is -1) 

        {
            Console.WriteLine("Non è stato trovato nessuno studente che rispetti i filtri forniti.");
            Console.WriteLine("\nPremere un tasto per continuare...");
            Console.ReadKey(true);
            Console.Write("\x1b[3J");
            Console.Clear();
            return;
        }

        Dictionary<string, int> materieVoti = [];

        for (int j = 0; j < voti.GetLength(1); j++)
        {
            if (voti[idxStudente, j] >= sogliaVoto) { materieVoti.Add(materie[j], voti[idxStudente, j]); }
        }


        if (materieVoti.Count > 0) {
            Console.WriteLine(new string('=', 25));
            Console.WriteLine($"{"Ricerca", -8}: {studente}");
            Console.WriteLine(new string('-', 25));
            Console.WriteLine($"{"Filtro", -8}: Voto ≥ {sogliaVoto}");
            Console.WriteLine(new string('-', 25));
            foreach (var materiaVoto in materieVoti) { 
                Console.WriteLine($"{materiaVoto.Key, -11}: {materiaVoto.Value}");
            }
        } else {
            Console.WriteLine("Nessun voto trovato sopra la soglia indicata.");     
        }

        Console.WriteLine(new string('=', 25));
        Console.WriteLine("\nPremere un tasto per continuare...");
        Console.ReadKey(true);
        Console.Write("\x1b[3J");
        Console.Clear();
    }

    public static void BorsaDiStudio()
    {
        double soglia = 6;

        Console.WriteLine($"Studenti meritevoli di borsa di studio: ");

        for (int i = 0; i < studenti.Length; i++)
        {
            double totale = 0;
            bool insufficienza = false;

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

    public static void MediaStudenti()
    {
        Dictionary<string, int> studentiMedia = [];

        // Calcolo della somma dei voti per ogni studente utilizzando un Dictionary (studente, totale)
        for (int i = 0; i < studenti.Length; i++)
        {
            for (int j = 0; j < materie.Length; j++)
            {
                // Verifico se lo studente (chiave) esiste già nel dizionario
                // Se presente, accumulo il voto corrente al totale esistente
                if (studentiMedia.ContainsKey(studenti[i])) studentiMedia[studenti[i]] += voti[i,j];
                // Se lo studente non è presente, inizializzo la voce nel dizionario con il suo primo voto
                else studentiMedia.Add(studenti[i], voti[i,j]);
            }
        }

        // Inizializzo una lista con le voci presenti nel dizionario (necessario per l'ordinamento)
        List<KeyValuePair<string, int>> mediaOrdinata = studentiMedia.ToList();

        // Ordinamento tramite "Bubble-Sorting"
        for (int i = 0; i < mediaOrdinata.Count - 1; i++)
        {
            for (int j = 0; j < mediaOrdinata.Count - 1 - i; j++)
            {
                // Se il valore attuale è minore del successivo, eseguo lo swap.
                // I valori più bassi "affondano" verso il fondo della lista (Ordinamento DESC).
                if (mediaOrdinata[j].Value < mediaOrdinata[j+1].Value)
                {
                    // Uso la decostruzione delle "tuple" per scambiare i due elementi 
                    // N.B.: Argomento non ancora trattato
                    (mediaOrdinata[j], mediaOrdinata[j+1]) = (mediaOrdinata[j+1], mediaOrdinata[j]);
                }
            }
        }

        Console.WriteLine(new string('=', 25) + "\nMedia studenti\n" + new string('-', 25));
        foreach (var media in mediaOrdinata) Console.WriteLine($"{media.Key, -5}: {(double)media.Value / materie.Length, -5} => {Math.Round((double)media.Value / materie.Length)}");
        Console.WriteLine(new string('=', 25));
        Console.WriteLine("\nPremere un tasto per continuare...");
        Console.ReadKey(true);
        Console.Write("\x1b[3J");
        Console.Clear();  
    }
}

