# 020 - Les Collections Avancées

Maintenant que tu connais bien les tableaux et les listes (`List<T>`), nous allons explorer d'autres façons de stocker et d'organiser tes données. Chaque problème a son outil idéal, et C# te propose de multiples structures appelées "collections". Découvrons les plus populaires et les plus puissantes !

---

## Les Dictionnaires (`Dictionary<TKey, TValue>`)

### 📝 Explication
Un **dictionnaire** fonctionne littéralement comme un dictionnaire francophone ou un annuaire téléphonique. Tu ne cherches pas une information par son numéro d'ordre (son index 0, 1, 2...), mais par une **clé** (comme un mot) qui est associée à une **valeur** (comme sa définition ou son numéro). C'est extrêmement rapide pour retrouver une information précise.

### 🔤 Syntaxe
```csharp
Dictionary<TypeClé, TypeValeur> nomDictionnaire = new Dictionary<TypeClé, TypeValeur>();
```

### 💡 Exemple Simple
```csharp
// Création d'un dictionnaire où la clé est le prénom (texte) et la valeur est l'âge (entier)
Dictionary<string, int> ages = new Dictionary<string, int>();

// Ajout de paires Clé/Valeur
ages.Add("Alice", 25);     // Associe l'âge 25 à la clé "Alice"
ages.Add("Bob", 30);       // Associe l'âge 30 à la clé "Bob"

// Récupérer et afficher la valeur associée à "Alice"
Console.WriteLine(ages["Alice"]); // Affiche "25" sur la console

// Modifier une valeur existante via sa clé
ages["Bob"] = 31;          // Bob vient d'avoir son anniversaire, sa valeur devient 31
```

### 🚀 Exemple Avancé
```csharp
// Un inventaire de jeu vidéo où la clé est l'ID de l'objet, et la valeur son nom
Dictionary<int, string> inventaire = new Dictionary<int, string>()
{
    { 101, "Épée en fer" },    // Initialisation directe avec des paires de valeurs
    { 102, "Bouclier en bois" },
    { 103, "Potion de soin" }
};

// L'identifiant mathématique que nous cherchons
int idRecherche = 104;

// La méthode ContainsKey renvoie 'true' si la clé existe bel et bien dans le dictionnaire
if (inventaire.ContainsKey(idRecherche))
{
    // C'est sécurisé d'y accéder car on sait que la clé est bien là !
    Console.WriteLine($"Objet trouvé : {inventaire[idRecherche]}");
}
else
{
    // Si on essaye d'accéder à inventaire[104] sans vérifier, le programme plante
    Console.WriteLine("Cet objet n'existe pas dans l'inventaire."); 
}
```

### ⚠️ Erreurs Courantes
- **Ajouter une clé existante :** Utiliser `.Add("Alice", 28)` si "Alice" est déjà dans le dictionnaire va faire planter ton programme avec une exception `ArgumentException`. Les clés doivent absolument être **uniques**.
- **Accéder à une clé introuvable :** Écrire `int age = ages["Charlie"]` alors que "Charlie" n'existe pas provoque une erreur `KeyNotFoundException`.

### ✅ Bonnes Pratiques
- Utilise toujours `.ContainsKey()` pour vérifier l'existence d'une clé avant de la lire.
- Encore mieux en C# moderne, utilise la méthode spécialisée `.TryGetValue(clé, out valeur)` qui fait la vérification et récupère la valeur en une seule opération très performante.

---

## Les Ensembles (`HashSet<T>`)

### 📝 Explication
Un `HashSet` (ensemble de hachage) est une collection conçue pour **garantir qu'il n'y ait aucun doublon**. Si tu essaies d'ajouter une valeur qui s'y trouve déjà, elle sera ignorée silencieusement. De plus, c'est l'un des outils les plus rapides de tout l'écosystème C# pour vérifier si un élément précis fait partie d'un très grand groupe de données.

### 🔤 Syntaxe
```csharp
HashSet<Type> nomEnsemble = new HashSet<Type>();
```

### 💡 Exemple Simple
```csharp
// Création d'un ensemble de nombres entiers
HashSet<int> nombresUniques = new HashSet<int>();

// Ajout de nombres
nombresUniques.Add(1); // Le 1 est ajouté avec succès (Add renvoie 'true')
nombresUniques.Add(2); // Le 2 est ajouté avec succès

// Tentative d'ajout d'un doublon
bool estAjoute = nombresUniques.Add(1); // Le 1 existe déjà ! L'ajout échoue silencieusement.

// Affichage du résultat : estAjoute vaut "false", et l'ensemble ne contient qu'un seul "1"
Console.WriteLine($"Ajout réussi ? {estAjoute}"); 
Console.WriteLine($"Total d'éléments : {nombresUniques.Count}"); // Affiche "2"
```

### 🚀 Exemple Avancé
```csharp
// Imaginons que nous avons une liste classique avec des adresses e-mails reçues en double, triple...
List<string> tousLesEmails = new List<string> 
{
    "jean@mail.com", "marie@mail.com", "jean@mail.com", "pierre@mail.com"
};

// On peut utiliser le constructeur du HashSet en lui passant directement notre liste "sale"
// Le HashSet va se construire en purgeant automatiquement et instantanément tous les doublons !
HashSet<string> emailsNettoyes = new HashSet<string>(tousLesEmails);

// On parcourt notre nouvel ensemble, il n'y a plus aucun duplicata
foreach (string email in emailsNettoyes)
{
    // Affiche "jean@mail.com" puis "marie@mail.com" puis "pierre@mail.com"
    Console.WriteLine(email); 
}
```

### ⚠️ Erreurs Courantes
- **Se fier à l'ordre :** Contrairement à une `List<T>`, un `HashSet` ne mémorise absolument pas dans quel ordre tu as inséré les éléments. Si tu les parcours avec un `foreach`, l'ordre ne sera pas garanti. Ne l'utilise jamais si l'ordre est important !

### ✅ Bonnes Pratiques
- Utilise le `HashSet<T>` dès que tu dois effectuer des opérations d'intersection mathématique (garder seulement les éléments communs à deux groupes) ou de suppression de doublons massifs. Rapide et redoutablement efficace.

---

## Les Piles (`Stack<T>`)

### 📝 Explication
Une **pile** fonctionne selon le principe **LIFO** (*Last In, First Out* — Dernier Entré, Premier Sorti). Imagine littéralement une pile d'assiettes à laver : la dernière assiette que tu poses sur la pile est obligatoirement la première que tu vas reprendre pour la nettoyer !

### 🔤 Syntaxe
```csharp
Stack<Type> nomDeLaPile = new Stack<Type>();
```

### 💡 Exemple Simple
```csharp
// Création d'une pile de textes pour reproduire un navigateur web
Stack<string> historiqueNavigation = new Stack<string>();

// Empiler des éléments (Push) - on ajoute tout en haut de la pile
historiqueNavigation.Push("Page d'Accueil"); // Mise tout au fond
historiqueNavigation.Push("Page Produits");  // Mise par dessus
historiqueNavigation.Push("Panier");          // Mise tout au sommet

// Dépiler un élément (Pop) - on retire et on récupère celui du sommet
string pageCourante = historiqueNavigation.Pop(); 

// Affiche "Panier" car c'est le tout dernier élément qui était rentré
Console.WriteLine($"Nous venons de quitter : {pageCourante}"); 
```

### 🚀 Exemple Avancé
```csharp
// Création d'une pile pour gérer le bouton "Annuler" (Undo) d'un logiciel de dessin
Stack<string> actionsJoueur = new Stack<string>();

actionsJoueur.Push("A dessiné un trait noir");
actionsJoueur.Push("A gommé le visage");
actionsJoueur.Push("A colorié en rouge");

// L'utilisateur spam la touche de retour d'annulation. On vide la pile d'actions une par une
while(actionsJoueur.Count > 0)
{
    // On retire la dernière action pour l'annuler
    string actionAAnnuler = actionsJoueur.Pop();
    // On l'affiche sur la console
    Console.WriteLine($"Annulation de l'action : {actionAAnnuler}");
}
// Affichera : Annulation de 'A colorié en rouge', puis 'A gommé le visage', puis 'A dessiné un trait noir'.
```

### ⚠️ Erreurs Courantes
- **Dépiler à vide :** Utiliser la méthode `.Pop()` sur une pile qui n'a plus d'éléments fera violemment planter l'application avec une exception `InvalidOperationException`.
- **Regarder sans retirer :** C'est une erreur de dépiler juste pour regarder. Si tu veux voir ce qu'il y a en haut de la pile sans la retirer pour de vrai, utilise la méthode d'observation `.Peek()` à la place de `.Pop()`.

### ✅ Bonnes Pratiques
- Pour éviter les craches, utilise systématiquement la propriété `.Count` pour vérifier qu'il reste de quoi lire.
- Professionnellement, on privilégie la méthode sécurisée `.TryPop(out dictionnaireVariable)` qui va s'assurer d'elle-même que tout ne s'effondre pas.

---

## Les Files (`Queue<T>`)

### 📝 Explication
Une **file** fonctionne à l'inverse de la pile, selon le principe strict du **FIFO** (*First In, First Out* — Premier Entré, Premier Sorti). Pense très simplement à une file d'attente à la caisse du supermarché : le premier client arrivé à la caisse est logiquement le premier à être encaissé et à partir. 

### 🔤 Syntaxe
```csharp
Queue<Type> nomDeLaFile = new Queue<Type>();
```

### 💡 Exemple Simple
```csharp
// Création d'une file d'attente pour des clients (un texte)
Queue<string> fileDAttente = new Queue<string>();

// Enfiler des éléments (Enqueue) - ils se mettent à la queue leu-leu, les uns derrière les autres
fileDAttente.Enqueue("Paul");    // 1er dans la file
fileDAttente.Enqueue("Jacques"); // 2ème
fileDAttente.Enqueue("Emma");    // 3ème (tout à la fin)

// Défiler un élément (Dequeue) - on fait avancer la file en retirant le tout 1er
string clientServi = fileDAttente.Dequeue();

// Affiche "Paul" car c'est lui qui avait patiemment attendu son tour en premier
Console.WriteLine($"Le client servi est : {clientServi}"); 
```

### 🚀 Exemple Avancé
```csharp
// On veut coder une messagerie en arrière plan qui envoie des notifications l'une après l'autre.
Queue<string> messagesAEnvoyer = new Queue<string>();

// Nouveaux messages à expédier en ordre de priorité temporelle
messagesAEnvoyer.Enqueue("Alerte: Espace disque faible");
messagesAEnvoyer.Enqueue("Info: Mise à jour téléchargée");
messagesAEnvoyer.Enqueue("Bienvenue sur le service");

// Tant qu'il y a des messages en attente de traitement...
while(messagesAEnvoyer.Count > 0)
{
    // On extrait le premier de la file pour l'envoyer
    string messageEnCours = messagesAEnvoyer.Dequeue();
    
    // Traitement du message
    Console.WriteLine($"-> Émission du message en cours : {messageEnCours}");
    
    // S'il reste des messages à la suite, on peut faire un coucou au suivant
    if(messagesAEnvoyer.Count > 0)
    {
        // .Peek() permet de regarder discrètement qui est le prochain sans bousculer la file !
        Console.WriteLine($"[ Le système se prépare pour dire : '{messagesAEnvoyer.Peek()}' ]");
    }
}
```

### ⚠️ Erreurs Courantes
- **Défiler une file vide :** Tout comme pour la pile, utiliser un `.Dequeue()` aveugle sur une `Queue<T>` totalement vide déclenchera toujours une `InvalidOperationException`.

### ✅ Bonnes Pratiques
- Les files sont absolument incontournables quand ton application génère des tâches à faire (les requêtes d'un serveur, les clics impatients d'un utilisateur) et que ton programme complexe a besoin de les exécuter une par une dans leur ordre d'apparition naturel pour ne pas saturer la mémoire.
- De même, utilisez plutôt de nos jours `.TryDequeue(out var prochain)` pour extraire le travail de manière extrêmement sécurisée.
