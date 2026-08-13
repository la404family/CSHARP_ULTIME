using System;
using System.Collections.Generic; // Utilisé uniquement pour IEnumerable/IEnumerator pour faciliter l'utilisation, ou IEqualityComparer

namespace _009.Structures.DataStructures
{
    /// <summary>
    /// Représente une entrée (une paire Clé-Valeur) dans le dictionnaire.
    /// Utilisée également comme un nœud de liste chaînée pour gérer les collisions.
    /// </summary>
    public class Entry<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;
        
        /// <summary>
        /// Pointeur vers l'entrée suivante en cas de collision (deux clés ayant le même index de hachage).
        /// C'est le principe du chaînage (Chaining).
        /// </summary>
        public Entry<TKey, TValue> Next;

        public Entry(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            Next = null;
        }
    }

    /// <summary>
    /// Implémentation personnalisée d'un dictionnaire (Dictionary ou HashTable).
    /// Permet d'associer une clé unique à une valeur.
    /// </summary>
    /// <typeparam name="TKey">Le type de la clé. (Généralement string ou int).</typeparam>
    /// <typeparam name="TValue">Le type de la valeur associée à la clé.</typeparam>
    public class CustomDictionary<TKey, TValue>
    {
        /// <summary>
        /// Les "buckets" (seaux) du dictionnaire. 
        /// Chaque bucket contient une liste chaînée (Entry) de paires clé-valeur.
        /// </summary>
        private Entry<TKey, TValue>[] _buckets;

        /// <summary>
        /// Le nombre de paires clé-valeur actuellement dans le dictionnaire.
        /// </summary>
        private int _count;

        public int Count => _count;

        /// <summary>
        /// Initialise un nouveau dictionnaire avec une taille de buckets par défaut.
        /// (Généralement on utilise un nombre premier pour de meilleures répartitions de hachage).
        /// </summary>
        public CustomDictionary()
        {
            // On initialise un tableau de buckets de petite taille (ex: 5).
            _buckets = new Entry<TKey, TValue>[5];
        }

        /// <summary>
        /// Fonction de hachage pour déterminer dans quel bucket stocker la clé.
        /// </summary>
        /// <param name="key">La clé à hacher.</param>
        /// <returns>L'index du bucket (entre 0 et _buckets.Length - 1).</returns>
        private int GetBucketIndex(TKey key)
        {
            // 1. On récupère le HashCode de l'objet (fourni par C#).
            int hashCode = key.GetHashCode();
            
            // 2. Math.Abs pour s'assurer que le hashCode est positif (s'il était négatif).
            // 3. Modulo (%) pour contraindre l'index à la taille de notre tableau de buckets.
            return Math.Abs(hashCode) % _buckets.Length;
        }

        /// <summary>
        /// Ajoute une paire clé-valeur. Met à jour la valeur si la clé existe déjà.
        /// Complexité : O(1) en moyenne.
        /// </summary>
        public void Add(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            // Si la capacité atteint un certain seuil de "remplissage" (Load Factor), on redimensionne.
            // On choisit ici arbitrairement si Count >= Taille buckets * 2
            if (_count >= _buckets.Length * 2)
            {
                Resize();
            }

            int bucketIndex = GetBucketIndex(key);
            Entry<TKey, TValue> head = _buckets[bucketIndex];
            Entry<TKey, TValue> current = head;

            // On parcourt la liste chaînée dans ce bucket (en cas de collision)
            while (current != null)
            {
                // Si la clé existe déjà, on met à jour la valeur et on sort
                if (current.Key.Equals(key))
                {
                    current.Value = value;
                    return;
                }
                current = current.Next;
            }

            // Si la clé n'existait pas, on crée une nouvelle entrée
            Entry<TKey, TValue> newEntry = new Entry<TKey, TValue>(key, value);
            
            // On insère cette nouvelle entrée en TÊTE de la liste chaînée du bucket
            newEntry.Next = head;
            _buckets[bucketIndex] = newEntry;
            
            _count++;
        }

        /// <summary>
        /// Tente de récupérer la valeur associée à une clé.
        /// </summary>
        public bool TryGetValue(TKey key, out TValue value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            int bucketIndex = GetBucketIndex(key);
            Entry<TKey, TValue> current = _buckets[bucketIndex];

            // On parcourt les collisions potentielles
            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    // Clé trouvée, on retourne la valeur
                    value = current.Value;
                    return true;
                }
                current = current.Next;
            }

            // Clé non trouvée
            value = default(TValue);
            return false;
        }

        /// <summary>
        /// Redimensionne le tableau des buckets et réattribue les hachages (Rehashing).
        /// C'est une opération coûteuse O(n) mais qui garantit des performances O(1) sur le long terme.
        /// </summary>
        private void Resize()
        {
            // On double (environ) la taille. (Dans la vraie vie, on prendrait le prochain nombre premier).
            int newSize = _buckets.Length * 2;
            Entry<TKey, TValue>[] newBuckets = new Entry<TKey, TValue>[newSize];

            // Pour chaque bucket de l'ancien tableau
            for (int i = 0; i < _buckets.Length; i++)
            {
                Entry<TKey, TValue> current = _buckets[i];
                
                // Pour chaque élément de la liste chaînée dans ce bucket
                while (current != null)
                {
                    // On doit sauvegarder le 'suivant' avant de casser le lien
                    Entry<TKey, TValue> next = current.Next;

                    // On recalcule le NOUVEL index pour ce nouvel espace (nouveau Modulo)
                    int hashCode = current.Key.GetHashCode();
                    int newBucketIndex = Math.Abs(hashCode) % newSize;

                    // On insère cet élément en tête dans le nouveau bucket
                    current.Next = newBuckets[newBucketIndex];
                    newBuckets[newBucketIndex] = current;

                    // On passe au suivant de l'ancienne liste
                    current = next;
                }
            }

            // On remplace l'ancien tableau
            _buckets = newBuckets;
        }
    }
}
