using System;

namespace _009.Structures.DataStructures
{
    /// <summary>
    /// Implémentation personnalisée d'une pile (Stack) basée sur un tableau dynamique.
    /// Une pile fonctionne sur le principe LIFO (Last In, First Out) : le dernier élément ajouté est le premier retiré.
    /// </summary>
    /// <typeparam name="T">Le type générique des éléments contenus dans la pile.</typeparam>
    public class CustomStack<T>
    {
        /// <summary>
        /// Tableau interne utilisé pour stocker les éléments de la pile.
        /// </summary>
        private T[] _items;

        /// <summary>
        /// Le nombre actuel d'éléments dans la pile.
        /// Sert également d'index pour savoir où insérer le prochain élément.
        /// </summary>
        private int _count;

        /// <summary>
        /// Propriété publique en lecture seule pour obtenir le nombre d'éléments.
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Constructeur par défaut. Initialise la pile avec une capacité initiale de 4.
        /// </summary>
        public CustomStack()
        {
            // On commence avec une petite taille pour économiser de la mémoire.
            // Le tableau grandira automatiquement si besoin.
            _items = new T[4];
            _count = 0;
        }

        /// <summary>
        /// Ajoute un élément au sommet de la pile. (Opération Push)
        /// Complexité temporelle : O(1) en moyenne, O(n) dans le pire des cas (redimensionnement).
        /// </summary>
        /// <param name="item">L'élément à ajouter.</param>
        public void Push(T item)
        {
            // Vérifie si le tableau interne est plein.
            if (_count == _items.Length)
            {
                // Si le tableau est plein, on double sa capacité.
                // Cela garantit une complexité amortie O(1).
                Resize(_items.Length * 2);
            }

            // On place l'élément à l'index actuel de _count, puis on incrémente _count.
            _items[_count] = item;
            _count++;
        }

        /// <summary>
        /// Retire et retourne l'élément au sommet de la pile. (Opération Pop)
        /// Complexité temporelle : O(1).
        /// </summary>
        /// <returns>L'élément qui était au sommet de la pile.</returns>
        /// <exception cref="InvalidOperationException">Levée si la pile est vide.</exception>
        public T Pop()
        {
            // On ne peut pas retirer un élément d'une pile vide.
            if (_count == 0)
            {
                throw new InvalidOperationException("La pile est vide. Impossible d'effectuer un Pop.");
            }

            // On décrémente _count pour pointer sur le dernier élément ajouté.
            _count--;
            
            // On récupère l'élément à retourner.
            T item = _items[_count];
            
            // On efface la référence dans le tableau pour permettre au Garbage Collector 
            // de libérer la mémoire si T est un type référence (évite les fuites de mémoire).
            _items[_count] = default(T);

            return item;
        }

        /// <summary>
        /// Retourne l'élément au sommet de la pile sans le retirer. (Opération Peek)
        /// Complexité temporelle : O(1).
        /// </summary>
        /// <returns>L'élément au sommet de la pile.</returns>
        /// <exception cref="InvalidOperationException">Levée si la pile est vide.</exception>
        public T Peek()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("La pile est vide. Impossible d'effectuer un Peek.");
            }

            // Retourne simplement le dernier élément (à l'index _count - 1) sans modifier _count.
            return _items[_count - 1];
        }

        /// <summary>
        /// Redimensionne le tableau interne pour augmenter sa capacité.
        /// </summary>
        /// <param name="newCapacity">La nouvelle capacité souhaitée.</param>
        private void Resize(int newCapacity)
        {
            // 1. On crée un nouveau tableau avec la nouvelle capacité.
            T[] newItems = new T[newCapacity];
            
            // 2. On copie les éléments de l'ancien tableau vers le nouveau.
            // Array.Copy est très optimisé et rapide pour cette tâche.
            Array.Copy(_items, newItems, _count);
            
            // 3. On remplace l'ancien tableau par le nouveau.
            _items = newItems;
        }
    }
}
