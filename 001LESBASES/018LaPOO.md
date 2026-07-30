# Introduction à la Programmation Orientée Objet (POO) en C# 🎯

## Pourquoi apprendre la POO ?

Imaginez que vous devez construire une maison. Au lieu de mélanger tous les matériaux n'importe comment, vous organisez tout : les briques pour les murs, les tuiles pour le toit, les fenêtres à leurs places... La programmation orientée objet, c'est la même chose mais pour le code !

**Avant la POO**, les programmes étaient comme un long texte sans paragraphes ni chapitres. Difficile de s'y retrouver !

**Avec la POO**, nous organisons le code en "boîtes" logiques qui représentent des choses du monde réel. C'est plus facile à comprendre, à modifier et à réutiliser.

Happy coding ! 🚀
La programmation orientée objet (POO) est un paradigme de programmation qui organise le code autour d'**objets**. Un objet est une entité qui regroupe des **données** (appelées attributs ou propriétés) et des **comportements** (appelés méthodes ou fonctions).

### Analogie simple

Pensez à un téléphone portable :

- **Données** : numéro de téléphone, niveau de batterie, contacts
- **Comportements** : appeler, envoyer un SMS, prendre une photo

La POO permet de modéliser des éléments du monde réel sous forme de classes et d'objets, ce qui rend le code plus structuré, réutilisable et facile à maintenir.

---

## Concepts Fondamentaux de la POO

### 1. Classe 📋

Une **classe** est comme un **plan architectural** ou un **moule à gâteau**. Elle définit ce que tous les objets de ce type auront comme caractéristiques et capacités, mais elle n'est pas un objet en elle-même.

```csharp
public class Voiture
{
    // Propriétés (caractéristiques)
    public string Marque;
    public string Couleur;
    public int NombreDePortes;
    public bool EstDemarree;

    // Méthodes (actions que peut faire une voiture)
    public void Demarrer()
    {
        EstDemarree = true;
        Console.WriteLine("La voiture démarre : Vrooom !");
    }

    public void Klaxonner()
    {
        Console.WriteLine("Bip bip !");
    }

    public void Arreter()
    {
        EstDemarree = false;
        Console.WriteLine("La voiture s'arrête.");
    }
}
```

**💡 Point important** : Une classe seule ne fait rien. C'est juste la définition de ce qu'est une voiture.

### 2. Objet (Instance) 🚗

Un **objet** est une voiture concrète créée à partir du plan (la classe). On peut créer plusieurs voitures différentes à partir du même plan.

```csharp
class Program
{
    static void Main(string[] args)
    {
        // Création d'objets (instances de la classe Voiture)
        Voiture voitureDePaul = new Voiture();
        voitureDePaul.Marque = "Renault";
        voitureDePaul.Couleur = "Rouge";
        voitureDePaul.NombreDePortes = 5;

        Voiture voitureDeMarie = new Voiture();
        voitureDeMarie.Marque = "Peugeot";
        voitureDeMarie.Couleur = "Bleue";
        voitureDeMarie.NombreDePortes = 3;

        // Utilisation des méthodes
        voitureDePaul.Demarrer();
        voitureDePaul.Klaxonner();

        Console.WriteLine($"La voiture de Paul est une {voitureDePaul.Marque} {voitureDePaul.Couleur}");
        Console.WriteLine($"La voiture de Marie est une {voitureDeMarie.Marque} {voitureDeMarie.Couleur}");
    }
}
```

### 3. Encapsulation 🔒

L'**encapsulation** consiste à **protéger les données** importantes d'un objet. C'est comme mettre un coffre-fort autour de vos économies : vous ne laissez pas n'importe qui y toucher directement.

#### ❌ Sans encapsulation (dangereux)

```csharp
public class CompteBancaire
{
    public double solde; // Dangereux : tout le monde peut modifier le solde !
}

// Quelqu'un pourrait faire :
CompteBancaire compte = new CompteBancaire();
compte.solde = -1000; // Oups ! Solde négatif impossible !
```

#### ✅ Avec encapsulation (sécurisé)

```csharp
public class CompteBancaire
{
    private double solde; // Privé : personne ne peut y accéder directement
    private string proprietaire;

    // Constructeur pour créer un compte
    public CompteBancaire(string nom, double soldeInitial)
    {
        proprietaire = nom;
        solde = soldeInitial >= 0 ? soldeInitial : 0; // Pas de solde négatif !
    }

    // Méthodes publiques pour interagir avec le solde
    public void Deposer(double montant)
    {
        if (montant > 0)
        {
            solde += montant;
            Console.WriteLine($"Dépôt de {montant}€. Nouveau solde : {solde}€");
        }
        else
        {
            Console.WriteLine("Le montant doit être positif !");
        }
    }

    public bool Retirer(double montant)
    {
        if (montant > 0 && montant <= solde)
        {
            solde -= montant;
            Console.WriteLine($"Retrait de {montant}€. Nouveau solde : {solde}€");
            return true;
        }
        else
        {
            Console.WriteLine("Retrait impossible !");
            return false;
        }
    }

    public double ConsulterSolde()
    {
        return solde;
    }
}

// Utilisation sécurisée
CompteBancaire monCompte = new CompteBancaire("Jean", 100);
monCompte.Deposer(50);  // ✅ Autorisé
monCompte.Retirer(200); // ❌ Refusé (solde insuffisant)
```

**🔑 Mots-clés d'accès important** :

- `public` : Accessible depuis n'importe où
- `private` : Accessible seulement depuis la classe elle-même
- `protected` : Accessible depuis la classe et ses classes filles (héritage)

### 4. Héritage 👨‍👦

L'**héritage** permet de créer une nouvelle classe basée sur une classe existante. C'est comme dire : "Cette nouvelle classe a tout ce que l'ancienne avait, plus quelques trucs en plus."

```csharp
// Classe de base (parent)
public class Animal
{
    public string Nom;
    public int Age;

    public void Manger()
    {
        Console.WriteLine($"{Nom} mange.");
    }

    public void Dormir()
    {
        Console.WriteLine($"{Nom} dort.");
    }
}

// Classe dérivée (enfant)
public class Chien : Animal  // ":" signifie "hérite de"
{
    public string Race;

    // Méthode spécifique aux chiens
    public void Aboyer()
    {
        Console.WriteLine($"{Nom} fait : Wouf wouf !");
    }

    public void JouerAvecLaBalle()
    {
        Console.WriteLine($"{Nom} court après la balle !");
    }
}

public class Chat : Animal
{
    public bool ADesGriffes;

    // Méthodes spécifiques aux chats
    public void Miauler()
    {
        Console.WriteLine($"{Nom} fait : Miaou !");
    }

    public void Ronronner()
    {
        Console.WriteLine($"{Nom} ronronne de plaisir.");
    }
}

// Utilisation
class Program
{
    static void Main(string[] args)
    {
        Chien monChien = new Chien();
        monChien.Nom = "Rex";        // Hérité d'Animal
        monChien.Age = 3;            // Hérité d'Animal
        monChien.Race = "Labrador";  // Spécifique à Chien

        monChien.Manger();           // Méthode héritée
        monChien.Aboyer();           // Méthode spécifique

        Chat monChat = new Chat();
        monChat.Nom = "Whiskers";
        monChat.Age = 2;
        monChat.ADesGriffes = true;

        monChat.Manger();            // Méthode héritée
        monChat.Miauler();           // Méthode spécifique
    }
}
```

**💡 Avantages de l'héritage** :

- Évite la répétition de code
- Crée une hiérarchie logique
- Facilite la maintenance

### 5. Polymorphisme 🎭

Le **polymorphisme** signifie "plusieurs formes". C'est la capacité d'un objet à prendre différentes formes ou à se comporter différemment selon le contexte.

#### Exemple concret

Imaginez que vous disiez à différents animaux "Fais du bruit !" :

- Un chien aboiera
- Un chat miaulera
- Une vache meuglera

Même ordre, résultats différents selon l'animal !

```csharp
public class Animal
{
    public string Nom;

    // Méthode virtuelle = peut être redéfinie par les classes filles
    public virtual void Crier()
    {
        Console.WriteLine($"{Nom} fait un bruit.");
    }
}

public class Chat : Animal
{
    // Override = redéfinition de la méthode du parent
    public override void Crier()
    {
        Console.WriteLine($"{Nom} fait : Miaou !");
    }
}

public class Chien : Animal
{
    public override void Crier()
    {
        Console.WriteLine($"{Nom} fait : Wouf wouf !");
    }
}

public class Vache : Animal
{
    public override void Crier()
    {
        Console.WriteLine($"{Nom} fait : Meuh !");
    }
}

// Démonstration du polymorphisme
class Program
{
    static void Main(string[] args)
    {
        // Créons un tableau d'animaux différents
        Animal[] animaux = {
            new Chat { Nom = "Félix" },
            new Chien { Nom = "Rex" },
            new Vache { Nom = "Marguerite" }
        };

        // Même instruction, comportements différents !
        foreach (Animal animal in animaux)
        {
            animal.Crier(); // Polymorphisme en action !
        }
    }
}

/* Sortie :
Félix fait : Miaou !
Rex fait : Wouf wouf !
Marguerite fait : Meuh !
*/
```

---

## Constructeurs et Propriétés 🏗️

### Constructeurs

Un **constructeur** est une méthode spéciale qui s'exécute automatiquement quand on crée un objet. C'est comme l'assemblage d'un meuble IKEA : les instructions pour bien le monter !

```csharp
public class Personne
{
    public string Nom;
    public int Age;
    public string Email;

    // Constructeur par défaut
    public Personne()
    {
        Nom = "Inconnu";
        Age = 0;
        Email = "non-defini@email.com";
        Console.WriteLine("Une nouvelle personne a été créée !");
    }

    // Constructeur avec paramètres
    public Personne(string nom, int age, string email)
    {
        Nom = nom;
        Age = age;
        Email = email;
        Console.WriteLine($"Bonjour {Nom} !");
    }
}

// Utilisation
Personne p1 = new Personne(); // Utilise le constructeur par défaut
Personne p2 = new Personne("Alice", 25, "alice@email.com"); // Constructeur avec paramètres
```

### Propriétés (Get/Set)

Les **propriétés** sont une façon élégante de contrôler l'accès aux données :

```csharp
public class Produit
{
    private double prix; // Champ privé

    // Propriété avec validation
    public double Prix
    {
        get { return prix; }
        set
        {
            if (value >= 0)
                prix = value;
            else
                Console.WriteLine("Le prix ne peut pas être négatif !");
        }
    }

    // Propriété automatique (plus simple)
    public string Nom { get; set; }

    // Propriété en lecture seule
    public DateTime DateCreation { get; private set; }

    public Produit(string nom)
    {
        Nom = nom;
        DateCreation = DateTime.Now;
    }
}
```

---

## Exemple Pratique Complet 🎮

Créons un petit jeu avec des personnages :

```csharp
// Classe de base
public abstract class Personnage
{
    public string Nom { get; set; }
    public int PointsVie { get; protected set; }
    public int Niveau { get; protected set; }

    public Personnage(string nom)
    {
        Nom = nom;
        PointsVie = 100;
        Niveau = 1;
    }

    // Méthode abstraite = doit être implémentée par les classes filles
    public abstract void Attaquer(Personnage cible);

    public virtual void RecevoirDegats(int degats)
    {
        PointsVie -= degats;
        Console.WriteLine($"{Nom} reçoit {degats} dégâts ! PV restants : {PointsVie}");

        if (PointsVie <= 0)
        {
            Console.WriteLine($"{Nom} est KO !");
        }
    }
}

public class Guerrier : Personnage
{
    public int Force { get; set; }

    public Guerrier(string nom) : base(nom)
    {
        Force = 20;
        Console.WriteLine($"Le guerrier {nom} entre en scène !");
    }

    public override void Attaquer(Personnage cible)
    {
        Console.WriteLine($"{Nom} attaque {cible.Nom} avec son épée !");
        cible.RecevoirDegats(Force);
    }
}

public class Mage : Personnage
{
    public int Mana { get; set; }

    public Mage(string nom) : base(nom)
    {
        Mana = 50;
        Console.WriteLine($"Le mage {nom} maîtrise les arcanes !");
    }

    public override void Attaquer(Personnage cible)
    {
        if (Mana >= 10)
        {
            Console.WriteLine($"{Nom} lance une boule de feu sur {cible.Nom} !");
            cible.RecevoirDegats(25);
            Mana -= 10;
            Console.WriteLine($"Mana restant : {Mana}");
        }
        else
        {
            Console.WriteLine($"{Nom} n'a plus assez de mana !");
        }
    }
}

// Utilisation
class Program
{
    static void Main(string[] args)
    {
        Guerrier arthur = new Guerrier("Arthur");
        Mage merlin = new Mage("Merlin");

        Console.WriteLine("\n--- COMBAT ! ---");
        arthur.Attaquer(merlin);
        merlin.Attaquer(arthur);
        arthur.Attaquer(merlin);
        merlin.Attaquer(arthur);
    }
}
```

---

## Organisation du Code : Namespaces et Dossiers 📁

Pour les projets plus importants, organisez votre code :

### Structure de dossiers recommandée

```text
MonProjet/
├── Models/           (Classes de données)
│   ├── Personne.cs
│   └── Produit.cs
├── Services/         (Logique métier)
│   └── CalculateurPrix.cs
├── Utilities/        (Outils utiles)
│   └── Validateur.cs
└── Program.cs        (Point d'entrée)
```

### Exemple avec namespace

### Models/Voiture.cs

```csharp
namespace MonProjet.Models
{
    public class Voiture
    {
        public string Marque { get; set; }
        public string Couleur { get; set; }
        public int Vitesse { get; private set; }

        public void Accelerer(int vitesse)
        {
            Vitesse += vitesse;
            Console.WriteLine($"Vitesse actuelle : {Vitesse} km/h");
        }

        public void Freiner()
        {
            Vitesse = 0;
            Console.WriteLine("La voiture s'arrête.");
        }
    }
}
```

### Program.cs

```csharp
using MonProjet.Models; // Importer le namespace

class Program
{
    static void Main(string[] args)
    {
        Voiture maVoiture = new Voiture
        {
            Marque = "Tesla",
            Couleur = "Blanc"
        };

        maVoiture.Accelerer(50);
        maVoiture.Freiner();
    }
}
```

---

## Erreurs Fréquentes à Éviter ❌

### 1. Oublier le mot-clé `new`

```csharp
// ❌ Incorrect
Voiture voiture;
voiture.Demarrer(); // Erreur : objet null !

// ✅ Correct
Voiture voiture = new Voiture();
voiture.Demarrer();
```

### 2. Confusion entre classe et objet

```csharp
// ❌ On ne peut pas faire ça
Voiture.Demarrer(); // Voiture est une classe, pas un objet !

// ✅ Il faut créer un objet d'abord
Voiture maVoiture = new Voiture();
maVoiture.Demarrer();
```

### 3. Accès à des membres privés

```csharp
public class Test
{
    private string secret = "mot de passe";
}

// ❌ Ne compilera pas
Test t = new Test();
Console.WriteLine(t.secret); // Erreur : secret est privé !
```

---

## Avantages de la POO 🌟

1. **Organisation** : Le code ressemble à la façon dont nous pensons le monde réel
2. **Réutilisabilité** : Une fois écrite, une classe peut être utilisée partout
3. **Facilité de maintenance** : Les changements sont localisés
4. **Travail en équipe** : Chacun peut travailler sur sa classe
5. **Évolutivité** : Facile d'ajouter de nouvelles fonctionnalités
6. **Debugging** : Plus facile de trouver les erreurs
