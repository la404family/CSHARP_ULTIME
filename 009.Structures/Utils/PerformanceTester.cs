using System;
using System.Collections.Generic;
using System.Diagnostics;
using _009.Structures.Algorithms.Searching;
using _009.Structures.Algorithms.Sorting;

namespace _009.Structures.Utils
{
    /// <summary>
    /// Classe utilitaire permettant de comparer les performances entre les collections natives .NET
    /// et nos implémentations personnalisées, et de tester les algorithmes de tri/recherche.
    /// Utilise System.Diagnostics.Stopwatch pour mesurer le temps d'exécution en millisecondes ou ticks.
    /// </summary>
    public static class PerformanceTester
    {
        /// <summary>
        /// Exécute tous les tests de performance de manière automatisée.
        /// </summary>
        public static void RunAllTests()
        {
            Console.WriteLine("Démarrage des tests de performance...\n");
            
            // On utilise un grand nombre d'éléments pour voir la différence de performance
            int elementCount = 500_000; 

            TestSorting(elementCount);
            TestSearching(elementCount);
        }

        /// <summary>
        /// Compare Array.Sort natif avec notre MergeSort.
        /// </summary>
        private static void TestSorting(int count)
        {
            Console.WriteLine($"--- Test de Tri sur {count} entiers aléatoires ---");
            
            int[] originalData = GenerateRandomArray(count);
            
            // Clonage pour s'assurer que les deux tris ont les mêmes données non triées
            int[] dataForNativeSort = (int[])originalData.Clone();
            int[] dataForCustomSort = (int[])originalData.Clone();

            Stopwatch sw = new Stopwatch();

            // 1. Test du tri natif C# (Array.Sort utilise un Introspective Sort - très optimisé)
            sw.Start();
            Array.Sort(dataForNativeSort);
            sw.Stop();
            Console.WriteLine($"> C# Array.Sort (Introspective Sort) : {sw.ElapsedMilliseconds} ms");

            // 2. Test de notre MergeSort (Tri Fusion)
            sw.Restart();
            MergeSort.Sort(dataForCustomSort);
            sw.Stop();
            Console.WriteLine($"> Custom MergeSort (Tri Fusion O(n log n)) : {sw.ElapsedMilliseconds} ms");

            Console.WriteLine();
        }

        /// <summary>
        /// Compare Array.BinarySearch natif avec notre Custom BinarySearch.
        /// </summary>
        private static void TestSearching(int count)
        {
            Console.WriteLine($"--- Test de Recherche Dichotomique dans un tableau de {count} entiers ---");
            
            int[] sortedData = GenerateRandomArray(count);
            // La recherche binaire REQUIERT un tableau trié
            Array.Sort(sortedData);

            // On choisit une cible au hasard parmi les éléments existants
            Random rand = new Random();
            int target = sortedData[rand.Next(0, sortedData.Length)];

            Stopwatch sw = new Stopwatch();

            // 1. Test de recherche binaire native
            sw.Start();
            int indexNative = Array.BinarySearch(sortedData, target);
            sw.Stop();
            // On affiche en Ticks car en ms ce sera souvent 0 (très rapide)
            Console.WriteLine($"> C# Array.BinarySearch : {sw.ElapsedTicks} ticks (Trouvé à l'index {indexNative})");

            // 2. Test de notre recherche binaire customisée
            sw.Restart();
            int indexCustom = BinarySearch.Find(sortedData, target);
            sw.Stop();
            Console.WriteLine($"> Custom BinarySearch : {sw.ElapsedTicks} ticks (Trouvé à l'index {indexCustom})");

            Console.WriteLine();
        }

        /// <summary>
        /// Utilitaire générant un tableau de nombres aléatoires pour les tests de perf.
        /// </summary>
        private static int[] GenerateRandomArray(int size)
        {
            int[] arr = new int[size];
            Random rand = new Random(42); // Seed fixe pour avoir les mêmes données à chaque run
            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(0, size * 10);
            }
            return arr;
        }
    }
}
