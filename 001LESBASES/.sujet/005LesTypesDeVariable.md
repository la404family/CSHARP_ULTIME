# Les types de variables en C-Sharp

En C#, chaque variable possède un concept fondamental nommé "type", qui définit la nature des données qu'elle peut contenir (un nombre entier, du texte, un nombre à virgule, etc.). Comprendre ces types est essentiel pour bien maîtriser la mémoire et le comportement de ton programme.

---

## Les Types Valeur (Value Types)

### 📝 Explication
Les types valeur sont des types de variables qui contiennent directement ton information. 
Imagine une boîte dans laquelle tu mets directement ton objet. Si tu copies cette boîte, tu crées une deuxième boîte avec une copie exacte de l'objet à l'intérieur. Si tu modifie la deuxième boîte, la première reste absolument intacte !
Ces types sont stockés dans une zone de mémoire très rapide de ton ordinateur, gérée de manière automatique : la **pile** (stack).

### 🔤 Syntaxe
```csharp
// Le nom du type suivi du nom de la variable, puis de = et la valeur
typeVoulu nomDeLaVariable = valeur;
```

### 💡 Exemple Simple
```csharp
// 1. Je crée une variable 'age' et j'y range le nombre 25
int age = 25; 

// 2. Je crée une autre variable 'copieAge' et j'y copie la valeur de 'age'
int copieAge = age; 

// 3. Je modifie la copie !
copieAge = 30; 

// 4. Résultat : 'age' vaut toujours 25, car 'copieAge' est une copie totalement indépendante en mémoire.
Console.WriteLine(age); // Affichera : 25
Console.WriteLine(copieAge); // Affichera : 30
```

### 🚀 Exemple Avancé
```csharp
// Déclaration d'une structure (qui est un format de classement personnalisé et un type valeur)
struct Coordonnees
{
    // Coordonnée horizontale X
    public int X;
    // Coordonnée verticale Y
    public int Y;
}

// Je crée un point de départ en utilisant cette structure
Coordonnees pointDeDepart = new Coordonnees { X = 10, Y = 20 };

// Je copie ce point du départ dans une nouvelle variable
Coordonnees nouveauPoint = pointDeDepart;

// Je modifie le nouveau point (par exemple, le joueur avance de 40 pixels)
nouveauPoint.X = 50;

// Le point de départ n'est pas affecté du tout car sa modification n'impacte que la copie.
Console.WriteLine(pointDeDepart.X);  // Affichera toujours : 10
Console.WriteLine(nouveauPoint.X);   // Affichera : 50
```

### ⚠️ Erreurs Courantes
- **Penser qu'une modification affecte l'original :** Les débutants oublient régulièrement que copier un type valeur crée deux données physiquement séparées. Changer la version B ne modifiera pas la version A !

### ✅ Bonnes Pratiques
- Utilise les types valeur (notamment les structures) pour des données petites et simples (comme des nombres de base, ou des coordonnées) car leur allocation et désallocation en mémoire par la "pile" est extrêmement rapide.

---

## Les Types Référence (Reference Types)

### 📝 Explication
Contrairement aux types valeur, les types référence ne contiennent pas directement la donnée elle-même. Ils contiennent une **adresse mémoire** (une information qui pointe vers l'endroit exact où l'objet est réellement stocké sur l'ordinateur). 
Imagine une télécommande (ta variable) qui contrôle une télévision (ta véritable donnée). Si tu copies la télécommande, tu te retrouves avec deux télécommandes... mais qui contrôlent **la même télévision** ! Si tu éteins la télé via la première télécommande, l'autre personne verra aussi la télé s'éteindre.
Les véritables objets créés ici sont stockés dans le **tas** (heap), une zone mémoire plus volumineuse qui est gérée par le nettoyeur automatique : le "Garbage Collector".

### 🔤 Syntaxe
```csharp
// "new" est souvent utilisé pour allouer et pointer vers le nouvel objet dans le tas.
TypeReference nomDeLaVariable = new TypeReference();
```

### 💡 Exemple Simple
```csharp
// Je crée un tableau contenant des notes (ceci est un type référence)
int[] notes = new int[] { 10, 15, 20 };

// Je copie la référence (la télécommande) dans une nouvelle variable
int[] copieNotes = notes;

// Je modifie la toute première note en passant par la copie 
copieNotes[0] = 5;

// La note originale (dans 'notes') est tout de suite modifiée aussi, car les deux variables visent le même tableau !
Console.WriteLine(notes[0]); // Affiche : 5
```

### 🚀 Exemple Avancé
```csharp
// Définition d'une classe "Personne" (toutes les classes sont systématiquement des types référence)
class Personne
{
    // Le nom de la personne
    public string Nom;
}

// 1. Création d'une nouvelle personne (l'objet va officiellement sur le tas)
Personne joueur1 = new Personne();
joueur1.Nom = "Alice"; // On lui attribue le pseudo Alice

// 2. Copie de la référence pour un deuxième utilisateur
Personne joueur2 = joueur1;

// 3. Changement du nom du joueur via la deuxième référence
joueur2.Nom = "Bob";

// 4. Cela force la modification sur l'objet unique et initial : joueur 1 devient Bob aussi !
Console.WriteLine(joueur1.Nom); // Affiche : Bob
Console.WriteLine(joueur2.Nom); // Affiche : Bob
```

### ⚠️ Erreurs Courantes
- **Modifier une référence sans le réaliser :** C'est le piège ultime ! Tu envoies la fiche d'un joueur dans une formule mathématique "Méthode" ailleurs dans ton code. Cette méthode modifie le joueur, puis termine, et l'original du joueur se retrouve transformé partout !
- **L'exception d'absence de référence (`NullReferenceException`) :** Le message rouge sang des erreurs : Essayer d'interagir avec une "télécommande" (une variable) qui, dans l'instant T, ne pointe vers absolument rien (état de vide = `null`).

### ✅ Bonnes Pratiques
- Si tu manipules des types référence et que tu veux opérer sur une copie sûre et **indépendante**, il te faudra techniquement créer un nouvel objet à part entière et copier à la main ses propriétés (une action baptisée le "clonage" d'objet).

---

## Les Types Entiers (int, long, short, byte)

### 📝 Explication
Les types entiers ont un objectif clair : stocker des nombres nets, purs et durs... bref, **sans la moindre virgule** ! (ex: 1, 42, -50). En programmation C#, afin d'optimiser la mémoire de l'ordinateur, il existe différents types d'entiers adaptés à la taille de ton nombre.
Le souverain, c'est le type `int` (pour integer - entier), omniprésent pour 90% de tes calculs. Mais attention : celui-ci s'arrête vers le plafond de 2 milliards. Si tu listes la population de la terre (8 milliards), tu dois appeler un `long`, un type gérant des nombres monstrueusement géants. À l'opposé complet, le `byte` gère de 0 à 255 seulement.

### 🔤 Syntaxe
```csharp
// Le type de base que tu verras partout
int compteurSimple = 10;
// Le type très capacitaire (on ajoute généralement un petit 'L' à la fin pour rassurer l'ordinateur)
long laPopulationMondiale = 8000000000L;
```

### 💡 Exemple Simple
```csharp
// Je crée avec le type universel entier 'int'
int ageUtilisateur = 32;

// Je retire un an
int anneePrecedente = ageUtilisateur - 1;

// Affiche sagement le nombre voulu
Console.WriteLine(anneePrecedente); // Affiche : 31
```

### 🚀 Exemple Avancé
```csharp
// 1. Un byte ne gaspille pas d'espace en mémoire. Il gère 0 à 255.
// Parfait pour représenter le niveau d'une lampe classique, du son ou un niveau maximum.
byte pourcentageBatterie = 99;

// 2. Un long permet de stocker des scores qui pèsent trop lourd pour le type int
// Petite astuce de syntaxe : on peut mettre des "underscores" '_' pour nous faciliter la lecture. Le code les ignore !
long scoreInterstellaire = 500_000_000_000L; 

// On affiche
Console.WriteLine("Batterie à : " + pourcentageBatterie); 
Console.WriteLine("Score : " + scoreInterstellaire);
```

### ⚠️ Erreurs Courantes
- **Le Dépassement de capacité (Le célèbre "Overflow") :** Forcer un type limité (comme `byte`) à recevoir une donnée qui l'écrase (comme le nombre `256`). Techniquement cela fera planter ton logiciel ou passera soudainement aux valeurs négatives.

### ✅ Bonnes Pratiques
- **Laisse faire le `int` par défaut.** La mémoire vive est très abordable aujourd'hui. Ne consacre pas de la complexité superflue dans ton code avec du "byte" ou du "short" sauf si tu mets une application sur un microcontrôleur super strict avec un giga d'espace, ou si tu fais de la data de réseau pure.

---

## Les Types Flottants (float, double, decimal)

### 📝 Explication
Les entiers, c'est sympa, mais parfois tu auras un résultat tel que 3.14 (des **décimales**). En C#, la virgule est représentée par le point `.`.
Devant ce besoin, C# te propose trois guerriers spécialisés :
1. `float` : La précision dite "simple". Il calcule à une vitesse supersonique, et le monde des Moteurs de Jeux / Graphismes 3D base absolument tous ses calculs physiques dessus !
2. `double` : Le standard absolu des calculs en C#. Une précision "double" bien robuste que tu devrais utiliser dès l'instant où tu fais de la géométrie ou divises.
3. `decimal` : L'ultra précision monétaire. Une machine impitoyable et assez lente mais vitale pour l'argent (elle empêche les moindres de bogues d'arrondis pendant les calculs).

### 🔤 Syntaxe
```csharp
float accelerationVehicule = 12.5f; // Utilise 'f' en suffixe ('float')
double laMoitieDunePiece = 0.5; // Comportement naturel
decimal tauxInteret = 1.05m; // Utilise un 'm' en suffixe (Money, 'decimal')
```

### 💡 Exemple Simple
```csharp
// Je gère le calcul du périmètre d'un petit cercle
double surface = 3.14;

// Je le divise tout bêtement
double quartier = surface / 4;

// Afficher
Console.WriteLine(quartier); // Produit : 0.785
```

### 🚀 Exemple Avancé
```csharp
// DÉMONSTRATION DU PROBLÈME DES ARRONDIS!

// Dans le cas A (le standard C#)
double prixA1 = 0.1;
double prixA2 = 0.2;
// Par commodité d'optimisation informatique, l'ordinateur compresse ici...
double totalDouble = prixA1 + prixA2; 

// Dans le cas B (la calculette comptable)
// Le compilateur exige de mettre le 'm' pour prouver ton intention
decimal prixB1 = 0.1m; 
decimal prixB2 = 0.2m;
// Le résultat est minutieusement respecté
decimal totalDecimal = prixB1 + prixB2;

Console.WriteLine(totalDouble);  // Affiche un problème complexe de mémoire 32bits: 0.30000000000000004
Console.WriteLine(totalDecimal); // Affiche le but fixé parfait : 0.3
```

### ⚠️ Erreurs Courantes
- Omettre ou oublier les fameuses lettres finales comme le `f` ou le `m`. Le compilateur (la moulinette du code) te rappellera à l'ordre net : "*Literal of type double cannot be implicitly converted*". 

### ✅ Bonnes Pratiques
- **Finance ou Boutiques e-commerce = `decimal`.** Si une variable manipule potentiellement une chose qui se convertit en euros/dollars, interdis-toi d'utiliser le `double` ou le `float`.
- **Méga données, architecture, astronomie ou physique = `double`**.
- **Jeu vidéo 3D (ex: Unity) = `float`** ! La vitesse gagne sur la précision du micron près.

---

## Les Types Textuels (string et char)

### 📝 Explication
Pour afficher un titre, écrire un pseudonyme de joueur dans un système ou dialoguer avec ton utilisateur, l'informatique doit utiliser des caractères ! 
1. `char` (pour character) : C'est comme une brique unique. Un seul pion sur un jeu. Il encadre toujours par l'Apostrophe Unique.
2. `string` (pour une chaîne de caractères) : C'est le mur complet contenant les briques et des espaces de texte. Il s'encadre sous les Guillemets Doubles.
À l'échelle atomique, se dire d'ailleurs qu'une chaîne C# (`string`) n'est finalement qu'une file alignée (un "Tableau") remplit de tonnes de caractères `char`.

### 🔤 Syntaxe
```csharp
char seuleLettreValide = 'A';
string phraseComplete = "Bonjour tout le monde !";
```

### 💡 Exemple Simple
```csharp
// Stockons l'initiale
char codeDeSecret = 'K';

// Le nom de l'agence
string nomService = "KGB";

// "Concaténons" notre texte d'une manière classique
Console.WriteLine("Bienvenue au service secret, rang : " + codeDeSecret); 
```

### 🚀 Exemple Avancé
```csharp
// PRATIQUE MAGIQUE DE C# : l'Interpolation !

string prenom = "Alice";
string poste = "Chasseuse de prime spatial";

// C'est illisible et laid en pratique industrielle si on fait "texte = a + " : " + b" 
// Alors en rajoutant ce signe `$` à l'avant, le C# nous offre la possibilité
// d'injecter du code à la volée entre de simples accolades !
string texteDescription = $"Utilisatrice : {prenom}. Emploi validé : {poste}.";

// Je peux même forcer la visibilité de caractères normalement techniques comme les guillemets via l'Echappement '\' 
string replique = "\"Vous m'aviez contacté...\" chuchota la mercenaire.";

Console.WriteLine(texteDescription);
Console.WriteLine(replique);
```

### ⚠️ Erreurs Courantes
- **Confondre `' '` (pour `char`) et `" "` (pour `string`) :** Placer `char x = "Z";` mettra le C# en panique. L'ordinateur considère le double guillemet comme identitaire du texte long, même s'il n'y inclut qu'une petite lettre !

### ✅ Bonnes Pratiques
- Use et abuse à volonté de l'**Interpolation** : (`$"{variable}"`). Elle améliore exponentiellement la lisibilité de ton code et donc la maintenance long terme par toi-même ou t'es collègues.
- Note que le texte avec `string` à toujours le statut final de composante **immuable**. Conséquence drôle, le C# détruit à bas niveau (secrètement) tout le texte entier lors d'une simple fusion `+` et en reconstruit un nouveau pour protéger la sécurité de ton application. 

---

## Le Type Booléen (bool)

### 📝 Explication
C'est le sommet absolu de la logique basique binaire. Une variable `boolean` (raccourcie en `bool` dans la majorité de l'environnement C#) c'est ton interrupteur on/off.
Elle ne sait contenir que deux réponses magistrales : **vrai (`true`)** ou **faux (`false`)**. 
Pas de demi-mesure ! C'est le centre gravitationnel de tes futurs algorithmes conditionnels. Quand tu te demanderas "si le joueur est devant un coffre alors ouvrir?", le `bool` répondra oui ou non pour débloquer la suite.

### 🔤 Syntaxe
```csharp
bool nomVariable = true;
// L'inverse existe : false
```

### 💡 Exemple Simple
```csharp
// Un joueur de jeu de rôle attaque un dragon !
bool estEmpoisonne = true;

// Il prend une poudre d'antidote en cours de combat
estEmpoisonne = false;

// Le programme affiche son résultat sur l'écran
Console.WriteLine(estEmpoisonne); // Produit : False (faux)
```

### 🚀 Exemple Avancé
```csharp
// Mettons en place l'âge d'un visiteur sur ta page web 
int ageConnexion = 16;

// Dans notre variable "bool" nous ne tapons pas "true ou false".
// Nous confions au compilateur l'exigence formelle MENTALE d'exécuter un test "sur place" : 'Est-il plus grand ou égal à 18' ?
bool estAdulteOfficiel = ageConnexion >= 18;

// Par de la magie pure, le test est échoué, donc un "false" est rangé directement ici.
Console.WriteLine($"Vérification majeur validée ? -> {estAdulteOfficiel}");
```

### ⚠️ Erreurs Courantes
- Commencer True et False par la majuscule redoutée comme sur le langage Python par exemple. En C#, la discipline impose : un minuscule pour `true` et `false`.

### ✅ Bonnes Pratiques
- **Pose la question en posant la variable.** Formate mentalement tes variables comme des questions à te poser : `estMort`, `aFaim`, `peutCliquer`, `isLoaded`. Ton collègue de l'informatique lira cela à haute voix comme "Si... Le Joueur... est en colere", ton code deviendra d'ailleurs presque un livre naturel !

---

## Les Types Nullable (? et null)

### 📝 Explication
C# a posé un repère philosophique simple : L'absence, le vent ou le rien indéfini, c'est le `null`. C'est l'essence du trou noir.
Dans le milieu des fameux de tes "**Types référence**" (classes ou listes), tu as le droit de posséder une donnée contenant "le Rien" (`null`). 
Cependant dans tes vaillants **Types Valeurs** (un âge `int`, un `bool`), on doit impérativement disposer d'un renseignement immédiat! Les concepteurs du langage nous interdisaient farouchement de laisser ce champ à blanc (zéro y est par défaut imposé).
Afin d'outrepasser exceptionnellement cette règle quand on en a vraiment besoin, on convertit la chose en déclarant le point d'interrogation (`?`). Tu détiendras ainsi les mystérieux de **types nullables**.

### 🔤 Syntaxe
```csharp
// On l'ajoute au cul de la déclaration originelle.
int? donneeFacultative = null;
```

### 💡 Exemple Simple
```csharp
// Un élève passe un examen. Quelle est sa note vu qu'on a pas corrigé l'objet de recherche ?
// Vu l'attribut du "?", on a le droit au néant
int? noteTotaleExamen = null;

// Dès qu'on remplit, l'int reprend sa nature d'entier pour toujours (ou jusqu'au prochain oubli !)
noteTotaleExamen = 15;
Console.WriteLine(noteTotaleExamen); // Affiche 15
```

### 🚀 Exemple Avancé
```csharp
// Exemple de formulaire avec un questionnaire. L'âge est "facultatif" !
int? formulaireAgeUtilisateur = null; 

// Nous utilisons LA technique redoutable du "Null-Coalescing Operator" symbolisée par les symboles '??'.
// Traduction en français pour toi : "Vérifie si la variable gauche est le Rien aboslu. Si c'est effectivement le cas (null), donne moi par obligation la valeur inscrite à la droite des ??"
int traitementSystemeAgeDefaut = formulaireAgeUtilisateur ?? 18;

// Étant donné formellement qu'on n'a rien mis en formulaire, "18" s'approprie le résultat.
Console.WriteLine($"L'âge traité par défaut dans les registres sera de : {traitementSystemeAgeDefaut}");
```

### ⚠️ Erreurs Courantes
- **L'Apocalypse : L'`Exception de Référence Nulle` (NullReferenceException) :** Te tromper ou foncer allègrement dans le mur en convoquant ou travaillant une variable détentrice de ce vide atomique causera une coupure intégrale instantanée (et violente) à ton soft en pleine action. 

### ✅ Bonnes Pratiques
- Si tu gères une base de d'utilisateur ou interagis avec des pages frontaux (comme Internet Explorer et assimilés), ces variables facultatives te soulageront l'existence. Par ailleurs, utilise instinctivement `??` pour te blinder, parer la chute du logiciel, et garantir la survie des processus face un "Rien" égaré !

---

## Convertir les types

### 📝 Explication
On arrive au point culminant : La barrière d'assimilation ! Souvent une information nous tombe dessus du ciel dans le pire format ; Ex. On interroge d'une console classique le nom + données du gars, elle répond en te vomissant une gigantesque masse de `string`.
Mais il est clair que ton ordinateur d'intelligence en C# ne peut pas opérer de calcul mathématique avec des "lettres d'alphabets" !! On devra initier un cycle de **Conversion**. On traduit le texte avec un outil comme la méthode interne `int.Parse()`. 

### 🔤 Syntaxe
```csharp
// 'Parse' demande au système informatique de transposer de force le contenu du format natif au nom d'un autre type formatif
int monVariablePropre = int.Parse("445585");
```

### 💡 Exemple Simple
```csharp
// Le type d'information entrante est purement textuelle 
string argentTotalTexte = "4000";

// Hop, je lance l'outil en machine
int argentRecupereEnNombreInt = int.Parse(argentTotalTexte);

// Je vais procéder à des affaires
int monTresorEtAvenir = argentRecupereEnNombreInt + 500;

Console.WriteLine($"Au trésorier central d'afficher le solde numéraire : {monTresorEtAvenir}.");
```

### 🚀 Exemple Avancé
```csharp
// ET SI... UN UTILISATEUR VOULAIS FAIRE IMPLOSER MA MACHINE AVEC DU FAUX TEXTE (HACK)?!
string sabotageSaisieHack = "VINGT-MILLES!";

// Avec le 'int.Parse', en constatant que ce ne sont pas des nombres décryptables, le C# paniquerait et ferait crasher.
// Du coup nous mettons de base un test TryParse pour évaluer l'assurance sur du texte incertain !
// La formule 'TryParse' produit deux choses : Une analyse de Succès (Vrai ou Faux) + l'extraction mathématique et précise, si Vrai en l'occurrence.

// La variable de sauvetage 
int nombreObtenuFinalement;

// Out nous donne le feu vert pour garnir de suite notre base numérique dans la fonction externe !! Incroyable.
bool aEteConvertieBrillament = int.TryParse(sabotageSaisieHack, out nombreObtenuFinalement);

// Et le barrage en mode booléen final ! 
if (aEteConvertieBrillament)
{
    Console.WriteLine($"Incroyable, la machine compte désormais {nombreObtenuFinalement} Or !!");
}
else
{
    Console.WriteLine("DANGER : L'information n'était décidément point compatible pour le royaume chiffré.");
}
```

### ⚠️ Erreurs Courantes
- **La mort par `Parse` :** Croire aveuglément en ses utilisateurs humains et parser du vide, du charabia ou des lettres accidentelles... qui brisent d'un seul coup toute l'application.

### ✅ Bonnes Pratiques
- **Toujours privilégier `TryParse`** pour la validation des zones de clavier du grand public. Avec cela, ta machine demeurera majestueusement en ligne sans se laisser tromper par le format !