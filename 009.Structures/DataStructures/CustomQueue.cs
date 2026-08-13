using System;

namespace _009.Structures.DataStructures
{
    /// <summary>
    /// Implémentation personnalisée d'une file (Queue) basée sur un tableau circulaire (Circular Array).
    /// Une file fonctionne sur le principe FIFO (First In, First Out) : le premier arrivé est le premier servi.
    /// L'utilisation d'un tableau circulaire permet de conserver des performances O(1) pour l'ajout et le retrait.
    /// </summary>
    /// <typeparam name="T">Le type générique des éléments contenus dans la file.</typeparam>
    public class CustomQueue<T>
    {
        /// <summary>
        /// Tableau interne pour stocker les éléments.
        /// </summary>
        private T[] _items;
        
        /// <summary>
        /// Index pointant vers la "tête" (head) de la file, c'est-à-dire le prochain élément à retirer.
        /// </summary>
        private int _head;
        
        /// <summary>
        /// Index pointant vers la "queue" (tail) de la file, c'est-à-dire l'endroit où ajouter le prochain élément.
        /// </summary>
        private int _tail;
        
        /// <summary>
        /// Nombre actuel d'éléments dans la file.
        /// </summary>
        private int _count;

        /// <summary>
        /// Propriété publique indiquant le nombre d'éléments présents dans la file.
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public CustomQueue()
        {
            _items = new T[4]; // Capacité initiale arbitraire mais petite.
            _head = 0;
            _tail = 0;
            _count = 0;
        }

        /// <summary>
        /// Ajoute un élément à la fin de la file. (Opération Enqueue)
        /// Complexité temporelle : O(1) en moyenne.
        /// </summary>
        /// <param name="item">L'élément à ajouter.</param>
        public void Enqueue(T item)
        {
            // Vérifier si le tableau interne est complètement plein
            if (_count == _items.Length)
            {
                // Si on a atteint la limite, on double la capacité
                Resize(_items.Length * 2);
            }

            // On place l'élément à la position de la queue
            _items[_tail] = item;
            
            // On avance la queue d'une position. 
            // Le modulo (%) permet de faire "boucler" la queue au début du tableau si on atteint la fin.
            // C'est le principe du tableau circulaire.
            _tail = (_tail + 1) % _items.Length;
            
            // On incrémente le compteur d'éléments
            _count++;
        }

        /// <summary>
        /// Retire et retourne l'élément au début de la file. (Opération Dequeue)
        /// Complexité temporelle : O(1).
        /// </summary>
        /// <returns>L'élément qui était au début de la file.</returns>
        /// <exception cref="InvalidOperationException">Levée si la file est vide.</exception>
        public T Dequeue()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("La file est vide. Impossible de retirer un élément (Dequeue).");
            }

            // On récupère l'élément situé à la tête de la file
            T item = _items[_head];
            
            // On libère la référence pour le ramasse-miettes (Garbage Collector)
            _items[_head] = default(T);
            
            // On avance la tête d'une position, en bouclant si nécessaire (tableau circulaire)
            _head = (_head + 1) % _items.Length;
            
            // On décrémente le compteur d'éléments
            _count--;

            return item;
        }

        /// <summary>
        /// Retourne l'élément au début de la file sans le retirer. (Opération Peek)
        /// Complexité temporelle : O(1).
        /// </summary>
        /// <returns>L'élément au début de la file.</returns>
        public T Peek()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("La file est vide. Impossible d'observer le premier élément (Peek).");
            }

            // Retourne simplement l'élément à la tête sans modifier les index
            return _items[_head];
        }

        /// <summary>
        /// Redimensionne le tableau circulaire. 
        /// Opération plus complexe que pour la pile car il faut "dérouler" le tableau circulaire.
        /// </summary>
        private void Resize(int newCapacity)
        {
            T[] newItems = new T[newCapacity];
            
            // Si le tableau n'est pas "enroulé" (head est avant tail)
            if (_head < _tail)
            {
                Array.Copy(_items, _head, newItems, 0, _count);
            }
            else // Le tableau boucle sur lui-même (tail est avant head)
            {
                // On copie d'abord la partie de la tête jusqu'à la fin du tableau
                Array.Copy(_items, _head, newItems, 0, _items.Length - _head);
                // Puis on copie la partie du début du tableau jusqu'à la queue
                Array.Copy(_items, 0, newItems, _items.Length - _head, _tail);
            }

            _items = newItems;
            
            // On réinitialise head et tail puisqu'on a remis les éléments "à plat" dans le nouveau tableau
            _head = 0;
            _tail = _count; // Si tail = count et _count = nouveau length, la condition == marchera
        }
    }
}
