using System;

namespace _009.Structures.Algorithms.Sorting
{
    /// <summary>
    /// Classe statique implémentant l'algorithme de Tri Fusion (Merge Sort).
    /// Le tri fusion est un algorithme de type "Diviser pour Régner" (Divide and Conquer).
    /// Il divise le tableau en deux moitiés de manière récursive, trie chaque moitié, 
    /// puis fusionne (merge) les moitiés triées.
    /// </summary>
    public static class MergeSort
    {
        /// <summary>
        /// Trie le tableau fourni en paramètre en utilisant l'algorithme Merge Sort.
        /// 
        /// Complexité temporelle : O(n log n) dans tous les cas (pire, moyen, meilleur).
        /// Complexité spatiale : O(n) à cause de l'allocation d'un tableau temporaire (helper array).
        /// </summary>
        /// <typeparam name="T">Le type des éléments. Doit implémenter IComparable.</typeparam>
        /// <param name="array">Le tableau à trier.</param>
        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            if (array == null || array.Length <= 1)
                return; // Rien à trier

            // On alloue un seul tableau auxiliaire qui sera réutilisé tout au long du tri.
            // Cela évite de créer des sous-tableaux à chaque appel récursif et économise énormément de mémoire.
            T[] helper = new T[array.Length];

            // Lancement du tri récursif sur l'ensemble du tableau
            Sort(array, helper, 0, array.Length - 1);
        }

        /// <summary>
        /// Méthode récursive privée qui divise le tableau et appelle la fusion.
        /// </summary>
        /// <param name="array">Le tableau d'origine.</param>
        /// <param name="helper">Le tableau temporaire pour la fusion.</param>
        /// <param name="low">L'index de début de la section à trier.</param>
        /// <param name="high">L'index de fin de la section à trier.</param>
        private static void Sort<T>(T[] array, T[] helper, int low, int high) where T : IComparable<T>
        {
            // Condition d'arrêt de la récursivité : si l'intervalle est invalide ou réduit à un élément, on s'arrête.
            if (low >= high)
            {
                return;
            }

            // On calcule l'index du milieu
            int middle = low + (high - low) / 2;

            // 1. On trie la moitié GAUCHE (de low à middle)
            Sort(array, helper, low, middle);

            // 2. On trie la moitié DROITE (de middle + 1 à high)
            Sort(array, helper, middle + 1, high);

            // 3. Une fois les deux moitiés triées, on les FUSIONNE (Merge)
            Merge(array, helper, low, middle, high);
        }

        /// <summary>
        /// Fusionne deux moitiés préalablement triées d'un tableau.
        /// </summary>
        private static void Merge<T>(T[] array, T[] helper, int low, int middle, int high) where T : IComparable<T>
        {
            // Étape 1 : Copier les deux moitiés dans le tableau 'helper'
            // On ne copie que la section qui nous intéresse, c'est-à-dire de 'low' à 'high'.
            for (int i = low; i <= high; i++)
            {
                helper[i] = array[i];
            }

            // Définition des pointeurs pour parcourir les deux moitiés dans 'helper'
            int helperLeft = low;          // Pointeur pour parcourir la moitié GAUCHE
            int helperRight = middle + 1;  // Pointeur pour parcourir la moitié DROITE
            int current = low;             // Pointeur pour écrire dans le tableau 'array' original

            // Étape 2 : Parcourir 'helper', comparer les éléments des deux moitiés, et replacer le plus petit dans 'array'
            while (helperLeft <= middle && helperRight <= high)
            {
                // Si l'élément de la moitié gauche est plus petit ou égal à celui de la moitié droite
                if (helper[helperLeft].CompareTo(helper[helperRight]) <= 0)
                {
                    array[current] = helper[helperLeft];
                    helperLeft++;
                }
                else
                {
                    // L'élément de la moitié droite est strictement plus petit
                    array[current] = helper[helperRight];
                    helperRight++;
                }
                current++;
            }

            // Étape 3 : Copier le reste de la moitié gauche (s'il y en a)
            // Note: On n'a pas besoin de copier le reste de la moitié droite car ils sont déjà en place 
            // à la fin de notre section dans le tableau 'array'.
            int remaining = middle - helperLeft;
            for (int i = 0; i <= remaining; i++)
            {
                array[current + i] = helper[helperLeft + i];
            }
        }
    }
}
