# Projet 007 : Simulateur de Banque

Ce projet est une application console en C# simulant la gestion simple d'un compte bancaire. L'objectif principal est de mettre en pratique la gestion robuste des erreurs via les blocs `try/catch` et la création d'exceptions personnalisées, tout en gardant une trace persistante des opérations grâce à la manipulation de fichiers.

---

## Fonctionnalités

1. **Dépôt d'argent** : Ajouter un montant au solde du compte.
2. **Retrait d'argent** : Retirer un montant du solde du compte, en s'assurant que les fonds sont suffisants.
3. **Journalisation des transactions (Logs)** : Chaque opération (dépôt, retrait, erreur) est horodatée grâce à la structure `DateTime` et enregistrée de manière persistante dans un fichier texte.
4. **Gestion des erreurs spécifiques** :
   - Empêcher les dépôts ou retraits de montants négatifs.
   - Empêcher les retraits si le solde est insuffisant.
   - Informer l'utilisateur proprement en cas d'erreur métier.

---

## Concepts clés abordés

- **Gestion des Exceptions (`try/catch/finally`)** : Intercepter et traiter les erreurs sans interrompre brutalement l'application.
- **Exceptions personnalisées** : Créer ses propres classes d'exceptions héritant de `Exception` pour des cas métiers précis (ex : `FondsInsuffisantsException`, `MontantInvalideException`).
- **Dates et Heures (`DateTime`)** : Utiliser `DateTime.Now` pour générer un horodatage précis pour chaque transaction.
- **I/O Fichiers (`File.AppendAllText`)** : Ajouter du texte à la fin d'un fichier existant de façon optimisée, ce qui est la méthode standard pour écrire des journaux de bord (logs).

> 💡 **Note éducative** : L'ensemble du code source de ce projet (classes, méthodes et logique interne) est **abondamment commenté**. N'hésitez pas à lire les fichiers `.cs` pour comprendre chaque étape de l'exécution et les choix d'implémentation.

---

## Architecture suggérée

```text
007.Simulateur/
│
├── 007.Simulateur.csproj
├── Program.cs                        <-- Boucle principale de la console (Menu interactif)
│
├── Exceptions/
│   ├── MontantInvalideException.cs   <-- Exception : Déclenchée si le montant est <= 0
│   └── FondsInsuffisantsException.cs <-- Exception : Déclenchée si le retrait > solde
│
├── Models/
│   └── CompteBancaire.cs             <-- Logique métier (Solde actuel, méthodes Deposer et Retirer)
│
└── Services/
    └── JournalisationService.cs      <-- Logique d'écriture dans le fichier log (File.AppendAllText)
```

---

## Instructions (Futures)

Pour compiler et lancer le projet (une fois implémenté) :

```bash
cd 007.Simulateur
dotnet run
```
