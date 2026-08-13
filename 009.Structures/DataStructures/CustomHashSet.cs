using System;

namespace _009.Structures.DataStructures
{
    /// <summary>
    /// Implémentation personnalisée d'un HashSet (Ensemble mathématique).
    /// Ne stocke que des valeurs UNIQUES sans ordre spécifique.
    /// Utilise en interne le même principe qu'un dictionnaire, mais sans stocker de "Value".
    /// </summary>
    /// <typeparam name="T">Le type des éléments de l'ensemble.</typeparam>
    public class CustomHashSet<T>
    {
        // Pour simplifier et ne pas réinventer la roue, une façon commune 
        // d'implémenter un HashSet personnalisé est d'utiliser son propre CustomDictionary
        // en stockant la clé comme élément, et un booléen (ou byte) factice comme valeur.
        
        /// <summary>
        /// Dictionnaire interne pour stocker les éléments.
        /// </summary>
        private CustomDictionary<T, bool> _internalDict;

        /// <summary>
        /// Nombre d'éléments dans le HashSet.
        /// </summary>
        public int Count => _internalDict.Count;

        /// <summary>
        /// Constructeur. Initialise le dictionnaire interne.
        /// </summary>
        public CustomHashSet()
        {
            _internalDict = new CustomDictionary<T, bool>();
        }

        /// <summary>
        /// Ajoute un élément au HashSet. Si l'élément existe déjà, il n'est pas ajouté.
        /// Complexité : O(1) en moyenne.
        /// </summary>
        /// <param name="item">L'élément à ajouter.</param>
        /// <returns>True si l'élément a été ajouté (n'existait pas). False s'il existait déjà.</returns>
        public bool Add(T item)
        {
            // Si l'élément existe déjà, on ne l'ajoute pas (le HashSet ne contient que des valeurs uniques)
            if (Contains(item))
            {
                return false; // Échec de l'ajout car déjà présent
            }

            // On l'ajoute avec une valeur factice (true par exemple).
            // Le dictionnaire se chargera du hachage.
            _internalDict.Add(item, true);
            return true;
        }

        /// <summary>
        /// Vérifie si l'élément existe dans l'ensemble.
        /// Complexité : O(1) en moyenne grâce à la table de hachage sous-jacente.
        /// </summary>
        /// <param name="item">L'élément à chercher.</param>
        /// <returns>True si l'élément est trouvé, False sinon.</returns>
        public bool Contains(T item)
        {
            // On utilise la méthode TryGetValue pour voir si la clé (notre item) existe
            bool unusedValue;
            return _internalDict.TryGetValue(item, out unusedValue);
        }
    }
}
