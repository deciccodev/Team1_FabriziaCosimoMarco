using System;

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
}