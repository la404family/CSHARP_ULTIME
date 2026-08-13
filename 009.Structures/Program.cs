using System;
using _009.Structures.DataStructures;
using _009.Structures.Utils;

namespace _009.Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=====================================================");
            Console.WriteLine("=== Projet 009 - Structures de données & Algorithmes ===");
            Console.WriteLine("=====================================================\n");
            
            // Petit test manuel rapide des structures de données avant les benchmarks
            TestCustomStructures();

            // Lance les tests de performance (Algorithmes)
            PerformanceTester.RunAllTests();

            Console.WriteLine("Fin du programme.");
        }

        /// <summary>
        /// Test unitaire basique "manuel" pour vérifier que les implémentations fonctionnent.
        /// </summary>
        static void TestCustomStructures()
        {
            Console.WriteLine("--- Test de la CustomStack (LIFO) ---");
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            Console.WriteLine($"Pile (Count: {stack.Count}) - Peek: {stack.Peek()}"); // Devrait être 30
            Console.WriteLine($"Pop: {stack.Pop()}, Pop: {stack.Pop()}, Reste: {stack.Count}\n");

            Console.WriteLine("--- Test de la CustomQueue (FIFO) ---");
            CustomQueue<string> queue = new CustomQueue<string>();
            queue.Enqueue("Alice");
            queue.Enqueue("Bob");
            queue.Enqueue("Charlie");
            Console.WriteLine($"File (Count: {queue.Count}) - Peek: {queue.Peek()}"); // Devrait être Alice
            Console.WriteLine($"Dequeue: {queue.Dequeue()}, Reste: {queue.Count}\n");

            Console.WriteLine("--- Test du CustomDictionary (Hachage) ---");
            CustomDictionary<string, int> dict = new CustomDictionary<string, int>();
            dict.Add("Pomme", 50);
            dict.Add("Banane", 80);
            dict.Add("Orange", 30);
            
            if (dict.TryGetValue("Banane", out int val))
                Console.WriteLine($"Prix de la banane : {val}"); // Devrait être 80
            Console.WriteLine();

            Console.WriteLine("--- Test du CustomHashSet (Unicité) ---");
            CustomHashSet<int> set = new CustomHashSet<int>();
            Console.WriteLine($"Ajout de 5: {set.Add(5)}");   // True
            Console.WriteLine($"Ajout de 10: {set.Add(10)}"); // True
            Console.WriteLine($"Ajout de 5: {set.Add(5)}");   // False (déjà présent)
            Console.WriteLine($"Contains(10): {set.Contains(10)}\n");
        }
    }
}
