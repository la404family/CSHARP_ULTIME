using System;

namespace _009.Structures.Algorithms.Searching
{
    /// <summary>
    /// Classe statique fournissant une implémentation de la recherche dichotomique (Binary Search).
    /// </summary>
    public static class BinarySearch
    {
        /// <summary>
        /// Recherche la position d'un élément dans un tableau TRIÉ en divisant l'intervalle de recherche par deux à chaque étape.
        /// PRÉREQUIS STRICT : Le tableau 'array' DOIT être trié avant d'appeler cette méthode, sinon le résultat est imprévisible.
        /// 
        /// Complexité temporelle : O(log n) - Très performant pour les grands tableaux.
        /// Complexité spatiale : O(1) - Recherche itérative, pas d'allocation mémoire supplémentaire.
        /// </summary>
        /// <typeparam name="T">Le type des éléments. Doit implémenter IComparable pour pouvoir utiliser CompareTo.</typeparam>
        /// <param name="array">Le tableau de données (qui doit être préalablement trié).</param>
        /// <param name="target">L'élément recherché.</param>
        /// <returns>L'index de l'élément s'il est trouvé ; sinon, -1.</returns>
        public static int Find<T>(T[] array, T target) where T : IComparable<T>
        {
            if (array == null || array.Length == 0)
                return -1;

            // Définition des bornes de l'intervalle de recherche
            int left = 0;                    // Début du tableau
            int right = array.Length - 1;    // Fin du tableau

            // Tant que la borne gauche ne dépasse pas la borne droite
            // Si left dépasse right, cela signifie que la zone de recherche est vide
            while (left <= right)
            {
                // Calcul du milieu. 
                // On utilise "left + (right - left) / 2" au lieu de "(left + right) / 2" 
                // pour éviter un dépassement de capacité (overflow) si les index sont très grands.
                int mid = left + (right - left) / 2;

                // On compare l'élément du milieu avec la cible
                // CompareTo retourne :
                //   0 si les éléments sont égaux
                //  <0 si l'élément courant est plus petit que la cible
                //  >0 si l'élément courant est plus grand que la cible
                int comparison = array[mid].CompareTo(target);

                if (comparison == 0)
                {
                    // Eurêka ! L'élément du milieu est la cible. On retourne son index.
                    return mid;
                }
                else if (comparison < 0)
                {
                    // L'élément du milieu est plus petit que la cible.
                    // Comme le tableau est trié, on sait que la cible, si elle existe,
                    // se trouve forcément dans la MOITIÉ DROITE.
                    // On déplace donc la borne gauche juste après le milieu.
                    left = mid + 1;
                }
                else
                {
                    // L'élément du milieu est plus grand que la cible.
                    // Donc la cible se trouve forcément dans la MOITIÉ GAUCHE.
                    // On déplace la borne droite juste avant le milieu.
                    right = mid - 1;
                }
            }

            // Si la boucle se termine sans avoir retourné de valeur, l'élément n'existe pas dans le tableau.
            return -1;
        }
    }
}
