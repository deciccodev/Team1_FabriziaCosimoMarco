using System;

class GestionStudenti
{
    static string[] studenti = { "Anna", "Luca", "Maya", "Rami", "Zoe" };
    static string[] materie = { "Matematica", "Italiano", "Inglese", "Storia" };
    static int[,] voti = new int[5,4];

    public static void Main(string[] args)
    {
        Random rnd = new();

        for (int i = 0; i < studenti.Length; i++) // Cicla le righe (Studenti)
        {
            for (int j = 0; j < materie.Length; j++) // Cicla le colonne (Materie)
            {
                // Genera un voto casuale tra 2 e 10
                voti[i, j] = rnd.Next(2, 11); 
            }
        }

        VisualizzaRegistro();
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
    }
}