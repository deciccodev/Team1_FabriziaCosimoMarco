using System;

class GestionStudenti
{
    public static void Main(string[] args)
    {
    }

    public static void VisualizzaRegistro()
    {
        for (int i = 0; i < voti.GetLength(0); i++)
        {
            
            Console.WriteLine("=== " + studenti[i] + " ===");
            for (int j = 0; j < voti.GetLength(1); j++)
            {
                // Ciclo tutte le colonne di "voti" per stampare la materia attuale (usando j) e i voti
                Console.WriteLine($"{materie[j], 2}: {voti[i,j], 2}");
            }
            Console.WriteLine("---------------\n");
        }

        Console.WriteLine("\nPremere un tasto per continuare...");
        Console.ReadKey(true);
        Console.Clear();
    }

    public static void Ricerca(string studente, int voto)
    {
        if (string.IsNullOrEmpty(studente) || voto is < 1 or > 10)
        {
            Console.WriteLine("Errore, rispettare i requisiti richiesti. (Nome e voto da 1 a 10)");
        }

        studente = studente.Substring(0, 1).ToUpper() + studente.Substring(1).ToLower();
        int idxStudente = studenti.IndexOf(studente);

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
            if (voti[idxStudente, j] >= voto) { materieVoti.Add(materie[j], voti[idxStudente, j]); }
        }

        if (materieVoti.Count > 0) {
            Console.WriteLine("===== " + studente + " =====");
            Console.WriteLine($"Voto maggiore/uguale a: {voto}\n");
            foreach (var materiaVoto in materieVoti) { 
                Console.WriteLine($"{materiaVoto.Key} => {materiaVoto.Value}");
            }
        } else {
            Console.WriteLine("Non è stato trovato nessuno studente che rispetti i filtri forniti.");     
        }

        Console.WriteLine("\nPremere un tasto per continuare...");
        Console.ReadKey(true);
        Console.Clear();
    }
}