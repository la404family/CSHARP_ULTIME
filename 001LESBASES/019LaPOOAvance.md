# Les concepts POO avancés

## Table des matières

1. [L'héritage et le polymorphisme](#lhéritage-et-le-polymorphisme)
2. [Les classes abstraites et interfaces](#les-classes-abstraites-et-interfaces)
3. [Les propriétés et accesseurs](#les-propriétés-et-accesseurs)
4. [Les constructeurs et destructeurs](#les-constructeurs-et-destructeurs)
5. [Les modificateurs d'accès](#les-modificateurs-daccès)

---

## L'héritage et le polymorphisme

### L'héritage

L'héritage permet à une classe (classe dérivée) d'hériter des propriétés et méthodes d'une autre classe (classe de base). C'est un mécanisme fondamental de la POO qui favorise la réutilisation du code.

#### Exemple d'héritage simple

```csharp
// Classe de base (parent)
public class Animal
{
    public string Nom { get; set; }
    public int Age { get; set; }
    // Méthode virtuelle - peut être surchargée (override) dans les classes dérivées
    // public est la portée la plus permissive
    // virtual permet la surcharge dans les classes dérivées
    // void indique que la méthode ne retourne rien
    public virtual void FaireDuBruit()
    {
        Console.WriteLine("L'animal fait un bruit");
    }
    // Méthode non virtuelle - ne peut pas être surchargée
    public void Dormir()
    {
        Console.WriteLine($"{Nom} dort");
    }
}

// Classe dérivée (enfant)
public class Chien : Animal
{
    public string Race { get; set; }

    // Surcharge de méthode (override)
    public override void FaireDuBruit()
    {
        Console.WriteLine($"{Nom} aboie : Wouf Wouf!");
    }

    // Méthode spécifique à la classe Chien
    public void RemuerLaQueue()
    {
        Console.WriteLine($"{Nom} remue la queue");
    }
}

// Autre classe dérivée
public class Chat : Animal
{
    public bool EstIndependant { get; set; }

    public override void FaireDuBruit()
    {
        Console.WriteLine($"{Nom} miaule : Miaou!");
    }

    public void Ronronner()
    {
        Console.WriteLine($"{Nom} ronronne");
    }
}
```

#### Héritage multiple et chaînes d'héritage

```csharp
public class Mammifere : Animal
{
    public bool Allaite { get; set; } = true;

    public virtual void Allaiter()
    {
        if (Allaite)
            Console.WriteLine($"{Nom} allaite ses petits");
    }
}

public class ChienDomestique : Chien
{
    public string Proprietaire { get; set; }

    public void Obéir()
    {
        Console.WriteLine($"{Nom} obéit à {Proprietaire}");
    }
}
```

### Le polymorphisme

Le polymorphisme permet d'utiliser une interface commune pour différents types d'objets. Il existe deux types principaux :

#### 1. Polymorphisme d'héritage (override)

```csharp
public class Veterinaire
{
    public void ExaminerAnimal(Animal animal)
    {
        Console.WriteLine($"Examen de {animal.Nom} :");
        animal.FaireDuBruit(); // Polymorphisme : chaque animal fait son propre bruit
    }
}

// Utilisation
var veterinaire = new Veterinaire();
var chien = new Chien { Nom = "Rex", Age = 5 };
var chat = new Chat { Nom = "Mimi", Age = 3 };

veterinaire.ExaminerAnimal(chien); // Rex aboie : Wouf Wouf!
veterinaire.ExaminerAnimal(chat);  // Mimi miaule : Miaou!
```

#### 2. Polymorphisme d'interface

```csharp
public interface IVolant
{
    void Voler();
    int AltitudeMax { get; }
}

public class Oiseau : Animal, IVolant
{
    public int AltitudeMax { get; set; } = 1000;

    public override void FaireDuBruit()
    {
        Console.WriteLine($"{Nom} chante : Cui cui!");
    }

    public void Voler()
    {
        Console.WriteLine($"{Nom} vole à {AltitudeMax}m d'altitude");
    }
}

public class Avion : IVolant
{
    public string Modele { get; set; }
    public int AltitudeMax { get; set; } = 12000;

    public void Voler()
    {
        Console.WriteLine($"L'avion {Modele} vole à {AltitudeMax}m d'altitude");
    }
}
```

---

## Les classes abstraites et interfaces

### Les classes abstraites

Une classe abstraite ne peut pas être instanciée directement. Elle sert de modèle pour d'autres classes et peut contenir des méthodes abstraites (sans implémentation) et des méthodes concrètes.

```csharp
public abstract class Forme
{
    public string Couleur { get; set; }

    // Méthode abstraite - doit être implémentée par les classes dérivées
    public abstract double CalculerAire();

    // Méthode concrète - peut être utilisée telle quelle ou surchargée
    public virtual void AfficherInfo()
    {
        Console.WriteLine($"Forme de couleur {Couleur}");
    }

    // Méthode concrète - ne peut pas être surchargée
    public void ChangerCouleur(string nouvelleCouleur)
    {
        Couleur = nouvelleCouleur;
        Console.WriteLine($"Couleur changée en {nouvelleCouleur}");
    }
}

public class Cercle : Forme
{
    public double Rayon { get; set; }

    public override double CalculerAire()
    {
        return Math.PI * Rayon * Rayon;
    }

    public override void AfficherInfo()
    {
        base.AfficherInfo(); // Appel de la méthode parent
        Console.WriteLine($"Cercle de rayon {Rayon}, aire : {CalculerAire():F2}");
    }
}

public class Rectangle : Forme
{
    public double Largeur { get; set; }
    public double Hauteur { get; set; }

    public override double CalculerAire()
    {
        return Largeur * Hauteur;
    }

    public override void AfficherInfo()
    {
        base.AfficherInfo();
        Console.WriteLine($"Rectangle {Largeur}x{Hauteur}, aire : {CalculerAire():F2}");
    }
}
```

### Les interfaces

Une interface définit un contrat que les classes doivent respecter. Elle ne contient que des signatures de méthodes et propriétés, sans implémentation.

```csharp
public interface IComparable<T>
{
    int CompareTo(T autre);
}

public interface IClonable
{
    object Clone();
}

public interface ICalculable
{
    double CalculerPerimetre();
    double CalculerAire();
}

// Implémentation de plusieurs interfaces
public class Carre : Forme, IComparable<Carre>, IClonable, ICalculable
{
    public double Cote { get; set; }

    public override double CalculerAire()
    {
        return Cote * Cote;
    }

    public double CalculerPerimetre()
    {
        return 4 * Cote;
    }

    public int CompareTo(Carre autre)
    {
        return this.Cote.CompareTo(autre.Cote);
    }

    public object Clone()
    {
        return new Carre
        {
            Cote = this.Cote,
            Couleur = this.Couleur
        };
    }

    public override void AfficherInfo()
    {
        base.AfficherInfo();
        Console.WriteLine($"Carré de côté {Cote}, périmètre : {CalculerPerimetre():F2}");
    }
}
```

#### Interfaces avec implémentation par défaut (C# 8.0+)

```csharp
public interface ILogger
{
    void Log(string message);

    // Méthode avec implémentation par défaut
    void LogError(string message)
    {
        Log($"ERREUR: {message}");
    }

    void LogWarning(string message)
    {
        Log($"ATTENTION: {message}");
    }
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
    }

    // Les méthodes LogError et LogWarning sont automatiquement disponibles
}
```

---

## Les propriétés et accesseurs

### Propriétés automatiques

```csharp
public class Personne
{
    // Propriété automatique avec getter et setter publics
    public string Nom { get; set; }

    // Propriété en lecture seule (seulement getter)
    public int Age { get; private set; }

    // Propriété avec valeur par défaut
    public string Email { get; set; } = "non-defini@example.com";

    // Propriété calculée (seulement getter)
    public string NomComplet => $"{Nom} ({Age} ans)";

    // Propriété avec validation
    private int _age;
    public int AgeValide
    {
        get => _age;
        set
        {
            if (value < 0 || value > 150)
                throw new ArgumentException("L'âge doit être entre 0 et 150");
            _age = value;
        }
    }
}
```

### Propriétés avec logique personnalisée

```csharp
public class CompteBancaire
{
    private decimal _solde;
    private readonly List<Transaction> _transactions = new();

    public decimal Solde
    {
        get => _solde;
        private set
        {
            _solde = value;
            Console.WriteLine($"Nouveau solde : {_solde:C}");
        }
    }

    public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();

    public void Deposer(decimal montant)
    {
        if (montant <= 0)
            throw new ArgumentException("Le montant doit être positif");

        Solde += montant;
        _transactions.Add(new Transaction(montant, "Dépôt"));
    }

    public bool Retirer(decimal montant)
    {
        if (montant <= 0)
            throw new ArgumentException("Le montant doit être positif");

        if (montant > Solde)
            return false;

        Solde -= montant;
        _transactions.Add(new Transaction(-montant, "Retrait"));
        return true;
    }
}

public class Transaction
{
    public decimal Montant { get; }
    public string Description { get; }
    public DateTime Date { get; }

    public Transaction(decimal montant, string description)
    {
        Montant = montant;
        Description = description;
        Date = DateTime.Now;
    }
}
```

### Indexeurs

```csharp
public class Inventaire
{
    private Dictionary<string, int> _stock = new();

    // Indexeur pour accéder au stock par nom de produit
    public int this[string nomProduit]
    {
        get
        {
            return _stock.ContainsKey(nomProduit) ? _stock[nomProduit] : 0;
        }
        set
        {
            if (value < 0)
                throw new ArgumentException("Le stock ne peut pas être négatif");
            _stock[nomProduit] = value;
        }
    }

    // Indexeur avec plusieurs paramètres
    public string this[int index, string categorie]
    {
        get
        {
            var produits = _stock.Keys.Where(k => k.StartsWith(categorie)).ToList();
            return index < produits.Count ? produits[index] : null;
        }
    }
}

// Utilisation
var inventaire = new Inventaire();
inventaire["Pommes"] = 50;
inventaire["Bananes"] = 30;
Console.WriteLine($"Stock de pommes : {inventaire["Pommes"]}");
```

---

## Les constructeurs et destructeurs

### Constructeurs

```csharp
public class Voiture
{
    public string Marque { get; set; }
    public string Modele { get; set; }
    public int Annee { get; set; }
    public string Couleur { get; set; }

    // Constructeur par défaut (généré automatiquement si aucun constructeur n'est défini)
    public Voiture()
    {
        Couleur = "Blanc";
        Console.WriteLine("Voiture créée avec le constructeur par défaut");
    }

    // Constructeur avec paramètres
    public Voiture(string marque, string modele, int annee)
    {
        Marque = marque;
        Modele = modele;
        Annee = annee;
        Couleur = "Blanc";
        Console.WriteLine($"Voiture {marque} {modele} {annee} créée");
    }

    // Constructeur avec tous les paramètres
    public Voiture(string marque, string modele, int annee, string couleur)
        : this(marque, modele, annee) // Appel du constructeur précédent
    {
        Couleur = couleur;
        Console.WriteLine($"Couleur définie : {couleur}");
    }

    // Constructeur de copie
    public Voiture(Voiture autre)
    {
        Marque = autre.Marque;
        Modele = autre.Modele;
        Annee = autre.Annee;
        Couleur = autre.Couleur;
        Console.WriteLine("Copie de voiture créée");
    }
}
```

### Constructeurs statiques

```csharp
public class Configuration
{
    public static string NomApplication { get; private set; }
    public static string Version { get; private set; }
    public static DateTime DateCreation { get; private set; }

    // Constructeur statique - appelé une seule fois avant la première utilisation
    static Configuration()
    {
        NomApplication = "MonApplication";
        Version = "1.0.0";
        DateCreation = DateTime.Now;
        Console.WriteLine("Configuration initialisée");
    }

    // Constructeur d'instance
    public Configuration()
    {
        Console.WriteLine("Instance de Configuration créée");
    }
}
```

### Constructeurs dans l'héritage

```csharp
public class Vehicule
{
    public string Marque { get; set; }
    public int Annee { get; set; }

    public Vehicule(string marque, int annee)
    {
        Marque = marque;
        Annee = annee;
        Console.WriteLine($"Véhicule {marque} {annee} créé");
    }
}

public class Moto : Vehicule
{
    public string Type { get; set; }

    // Appel du constructeur parent avec base()
    public Moto(string marque, int annee, string type)
        : base(marque, annee)
    {
        Type = type;
        Console.WriteLine($"Moto de type {type} créée");
    }

    // Constructeur par défaut qui appelle le constructeur parent
    public Moto() : base("Inconnue", DateTime.Now.Year)
    {
        Type = "Standard";
        Console.WriteLine("Moto par défaut créée");
    }
}
```

### Destructeurs (Finalizers)

```csharp
public class RessourceExterne : IDisposable
{
    private bool _disposed = false;
    private IntPtr _handle;

    public RessourceExterne()
    {
        // Simulation d'acquisition d'une ressource externe
        _handle = new IntPtr(12345);
        Console.WriteLine("Ressource externe acquise");
    }

    // Destructeur (finalizer) - appelé par le garbage collector
    ~RessourceExterne()
    {
        Dispose(false);
    }

    // Implémentation de IDisposable
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this); // Empêche l'appel du destructeur
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Libération des ressources managées
                Console.WriteLine("Libération des ressources managées");
            }

            // Libération des ressources non-managées
            _handle = IntPtr.Zero;
            Console.WriteLine("Ressource externe libérée");

            _disposed = true;
        }
    }

    public void Utiliser()
    {
        if (_disposed)
            throw new ObjectDisposedException(nameof(RessourceExterne));

        Console.WriteLine("Utilisation de la ressource");
    }
}
```

---

## Les modificateurs d'accès

### Niveaux d'accès des membres

```csharp
public class ExempleAcces
{
    // public : accessible de partout
    public string ProprietePublique { get; set; }

    // private : accessible seulement dans cette classe (par défaut)
    private string _champPrive = "secret";

    // protected : accessible dans cette classe et les classes dérivées
    protected string ProprieteProtegee { get; set; }

    // internal : accessible dans le même assembly
    internal string ProprieteInterne { get; set; }

    // protected internal : accessible dans le même assembly OU dans les classes dérivées
    protected internal string ProprieteProtegeeInterne { get; set; }

    // private protected : accessible seulement dans cette classe ET les classes dérivées du même assembly
    private protected string ProprietePriveeProtegee { get; set; }

    public void MethodePublique()
    {
        // Accès à tous les membres
        Console.WriteLine(_champPrive);
        Console.WriteLine(ProprieteProtegee);
        Console.WriteLine(ProprieteInterne);
    }

    private void MethodePrivee()
    {
        // Accès aux membres privés et publics
        Console.WriteLine(_champPrive);
    }
}

public class ClasseDerivee : ExempleAcces
{
    public void MethodeDerivee()
    {
        // Accès aux membres publics et protégés
        ProprietePublique = "accessible";
        ProprieteProtegee = "accessible";
        ProprieteProtegeeInterne = "accessible";
        ProprietePriveeProtegee = "accessible";

        // Accès impossible aux membres privés
        // _champPrive = "impossible";
        // ProprieteInterne = "impossible";
    }
}
```

### Niveaux d'accès des classes

```csharp
// Classe publique - accessible de partout
public class ClassePublique
{
    public void Methode() { }
}

// Classe interne - accessible seulement dans le même assembly
internal class ClasseInterne
{
    public void Methode() { }
}

// Classe publique avec membres internes
public class ClassePubliqueAvecMembresInternes
{
    public string ProprietePublique { get; set; }
    internal string ProprieteInterne { get; set; }
    private string ProprietePrivee { get; set; }
}

// Classe abstraite publique
public abstract class ClasseAbstraite
{
    public abstract void MethodeAbstraite();
    public virtual void MethodeVirtuelle() { }
}

// Classe sealed (ne peut pas être héritée)
public sealed class ClasseSealed
{
    public void Methode() { }
}
```

### Exemple pratique avec encapsulation

```csharp
public class CompteBancaireSecurise
{
    // Champs privés - encapsulation des données
    private decimal _solde;
    private readonly string _numeroCompte;
    private readonly List<Transaction> _historique;

    // Propriétés publiques avec validation
    public decimal Solde
    {
        get => _solde;
        private set
        {
            if (value < 0)
                throw new InvalidOperationException("Le solde ne peut pas être négatif");
            _solde = value;
        }
    }

    public string NumeroCompte => _numeroCompte;

    // Propriété en lecture seule pour l'historique
    public IReadOnlyList<Transaction> Historique => _historique.AsReadOnly();

    // Constructeur
    public CompteBancaireSecurise(string numeroCompte, decimal soldeInitial = 0)
    {
        _numeroCompte = numeroCompte ?? throw new ArgumentNullException(nameof(numeroCompte));
        _historique = new List<Transaction>();
        Solde = soldeInitial;
    }

    // Méthodes publiques
    public bool Deposer(decimal montant)
    {
        if (montant <= 0)
            return false;

        Solde += montant;
        _historique.Add(new Transaction(montant, "Dépôt"));
        return true;
    }

    public bool Retirer(decimal montant)
    {
        if (montant <= 0 || montant > Solde)
            return false;

        Solde -= montant;
        _historique.Add(new Transaction(-montant, "Retrait"));
        return true;
    }

    // Méthode interne pour les tests
    internal void ResetSolde(decimal nouveauSolde)
    {
        _solde = nouveauSolde;
        _historique.Clear();
    }
}

// Classe pour les tests dans le même assembly
internal class TestCompteBancaire
{
    public static void TestReset()
    {
        var compte = new CompteBancaireSecurise("12345");
        compte.ResetSolde(1000); // Méthode interne accessible
    }
}
```

### Utilisation des modificateurs d'accès dans l'héritage

```csharp
public class Base
{
    public string Public { get; set; }
    protected string Protected { get; set; }
    internal string Internal { get; set; }
    private string Private { get; set; }
}

public class Derivee : Base
{
    public void Methode()
    {
        Public = "accessible";     // ✓
        Protected = "accessible";  // ✓
        Internal = "accessible";   // ✓ (même assembly)
        // Private = "inaccessible"; // ✗
    }
}

// Dans un autre assembly
public class AutreAssembly : Base
{
    public void Methode()
    {
        Public = "accessible";     // ✓
        // Protected = "inaccessible"; // ✗ (pas dans le même assembly)
        // Internal = "inaccessible";  // ✗ (pas dans le même assembly)
        // Private = "inaccessible";   // ✗
    }
}
```

---

## Exemple complet intégrant tous les concepts

```csharp
// Interface définissant le contrat
public interface ICompte
{
    decimal Solde { get; }
    bool Deposer(decimal montant);
    bool Retirer(decimal montant);
    void AfficherInfo();
}

// Classe abstraite de base
public abstract class Compte : ICompte
{
    protected decimal _solde;
    protected readonly string _numero;
    protected readonly List<Transaction> _transactions;

    public decimal Solde => _solde;
    public string Numero => _numero;
    public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();

    protected Compte(string numero, decimal soldeInitial = 0)
    {
        _numero = numero ?? throw new ArgumentNullException(nameof(numero));
        _solde = soldeInitial;
        _transactions = new List<Transaction>();
    }

    public virtual bool Deposer(decimal montant)
    {
        if (montant <= 0) return false;

        _solde += montant;
        _transactions.Add(new Transaction(montant, "Dépôt"));
        return true;
    }

    public virtual bool Retirer(decimal montant)
    {
        if (montant <= 0 || montant > _solde) return false;

        _solde -= montant;
        _transactions.Add(new Transaction(-montant, "Retrait"));
        return true;
    }

    public abstract void AfficherInfo();

    protected void AjouterTransaction(decimal montant, string description)
    {
        _transactions.Add(new Transaction(montant, description));
    }
}

// Classe concrète héritant de la classe abstraite
public class CompteCourant : Compte
{
    public decimal DecouvertAutorise { get; private set; }

    public CompteCourant(string numero, decimal decouvertAutorise = 0)
        : base(numero)
    {
        DecouvertAutorise = decouvertAutorise;
    }

    public override bool Retirer(decimal montant)
    {
        if (montant <= 0) return false;

        if (_solde - montant >= -DecouvertAutorise)
        {
            _solde -= montant;
            AjouterTransaction(-montant, "Retrait");
            return true;
        }

        return false;
    }

    public override void AfficherInfo()
    {
        Console.WriteLine($"Compte Courant {_numero}");
        Console.WriteLine($"Solde: {_solde:C}");
        Console.WriteLine($"Découvert autorisé: {DecouvertAutorise:C}");
    }
}

// Autre classe concrète
public class CompteEpargne : Compte
{
    public decimal TauxInteret { get; private set; }

    public CompteEpargne(string numero, decimal tauxInteret = 0.02m)
        : base(numero)
    {
        TauxInteret = tauxInteret;
    }

    public void CalculerInterets()
    {
        decimal interets = _solde * TauxInteret;
        _solde += interets;
        AjouterTransaction(interets, "Intérêts");
    }

    public override void AfficherInfo()
    {
        Console.WriteLine($"Compte Épargne {_numero}");
        Console.WriteLine($"Solde: {_solde:C}");
        Console.WriteLine($"Taux d'intérêt: {TauxInteret:P}");
    }
}

// Classe utilitaire
public class Banque
{
    private readonly List<Compte> _comptes;

    public Banque()
    {
        _comptes = new List<Compte>();
    }

    public void AjouterCompte(Compte compte)
    {
        _comptes.Add(compte);
    }

    public void AfficherTousLesComptes()
    {
        foreach (var compte in _comptes)
        {
            compte.AfficherInfo();
            Console.WriteLine();
        }
    }

    public void CalculerInteretsEpargne()
    {
        foreach (var compte in _comptes.OfType<CompteEpargne>())
        {
            compte.CalculerInterets();
        }
    }
}

// Classe pour les transactions
public class Transaction
{
    public decimal Montant { get; }
    public string Description { get; }
    public DateTime Date { get; }

    public Transaction(decimal montant, string description)
    {
        Montant = montant;
        Description = description;
        Date = DateTime.Now;
    }

    public override string ToString()
    {
        return $"{Date:dd/MM/yyyy HH:mm} - {Description}: {Montant:C}";
    }
}
```
