using System;

class GestionStudenti
{
    public static void Main(string[] args)
    {
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