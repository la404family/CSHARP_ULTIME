using Gestion.Exceptions;
using Gestion.Services;
using Gestion.Utils;

// ========================================================================
// Projet 005 : Gestion d'inventaire (POO, Modélisation, List<T>, CRUD)
// ------------------------------------------------------------------------
// CONCEPTS EXPLICITÉS ET DÉMONTRÉS DANS CE PROJET :
// - Modélisation Orientée Objet (Classe Article avec constructeur, propriétés, encapsulation)
// - Moteur d'inventaire encapsulant une List<Article> avec IDs auto-incrémentés
// - Opérations CRUD complètes en mémoire (Create, Read, Search, Delete)
// - LINQ sur des collections d'objets (.FirstOrDefault, .Where, .Sum)
// - Représentation graphique et formatage monétaire (Console formatting, :C2, :D3)
// - Gestion stricte des exceptions métiers avec try / catch hiérarchisé
// ========================================================================

// 0. INITIALISATION DU THÈME & DU MOTEUR D'INVENTAIRE
// Configure les couleurs de la console et l'encodage UTF-8 sous Windows
ConsoleTheme.ApplyTheme();

// Instanciation de l'objet InventoryEngine qui va gérer l'état interne des articles
var inventory = new InventoryEngine();

// Variable d'état de contrôle de la boucle principale du menu
bool running = true;

// Boucle principale d'interaction utilisateur
while (running)
{
    ConsoleTheme.WriteInfo("========================================");
    ConsoleTheme.WriteInfo("    GESTIONNAIRE D'INVENTAIRE (C#)");
    ConsoleTheme.WriteInfo("========================================\n");

    // Propriétés fléchées :
    // - inventory.Count renvoie le nombre d'articles (=> _articles.Count)
    // - CalculateTotalInventoryValue() additionne tous les ValeurTotale via LINQ .Sum()
    Console.WriteLine($"Articles enregistrés : {inventory.Count} | Valeur totale du stock : {inventory.CalculateTotalInventoryValue():C2}\n");

    Console.WriteLine("1. Ajouter un article");
    Console.WriteLine("2. Afficher la liste des articles");
    Console.WriteLine("3. Rechercher un article (ID ou Nom)");
    Console.WriteLine("4. Supprimer un article par ID");
    Console.WriteLine("5. Vider l'inventaire");
    Console.WriteLine("6. Quitter\n");

    // Appel à la fonction utilitaire qui renvoie l'option choisie (return choice)
    int option = ConsoleInput.AskForMenuOption("Votre choix (1-6) : ", 1, 6);
    Console.WriteLine();

    // =========================================================================
    // BLOC TRY-CATCH : GESTION DES EXCEPTIONS ET SÉCURITÉ D'EXÉCUTION
    // =========================================================================
    // Le bloc 'try' englobe tout code susceptible de lever une exception.
    // Si une méthode dans le 'try' fait un 'throw', l'exécution normale s'arrête
    // et C# bascule immédiatement dans le premier bloc 'catch' correspondant.
    // =========================================================================
    try
    {
        switch (option)
        {
            case 1:
                // --- AJOUTER UN ARTICLE ---
                ConsoleTheme.WriteInfo("--- AJOUT D'UN NOUVEL ARTICLE ---");
                Console.WriteLine("(Saisissez 'Q' à tout moment pour annuler)\n");

                // TryAskForString utilise le mot-clé 'out' pour fournir la valeur 'nom'.
                // La méthode RENVOIE 'true' (return true) si la saisie a réussi, ou 'false' (return false) si annulée.
                if (!ConsoleInput.TryAskForString("Nom de l'article : ", out string nom))
                {
                    ConsoleTheme.WriteWarning("\n[ANNULÉ] Ajout d'article annulé.");
                    break;
                }

                // TryAskForDecimal : même pattern que TryAskForString mais pour un nombre décimal (prix).
                // Le paramètre 'minValue: 0m' utilise un argument nommé pour plus de lisibilité.
                if (!ConsoleInput.TryAskForDecimal("Prix unitaire (€) : ", out decimal prix, minValue: 0m))
                {
                    ConsoleTheme.WriteWarning("\n[ANNULÉ] Ajout d'article annulé.");
                    break;
                }

                // TryAskForInt : même pattern pour un nombre entier (quantité).
                if (!ConsoleInput.TryAskForInt("Quantité en stock : ", out int quantite, minValue: 0))
                {
                    ConsoleTheme.WriteWarning("\n[ANNULÉ] Ajout d'article annulé.");
                    break;
                }

                // AddArticle() crée l'objet Article et le renvoie (return article) avec son ID auto-généré.
                var createdArticle = inventory.AddArticle(nom, prix, quantite);

                // Formatage numérique :D3 affiche l'ID avec 3 chiffres (ex: 001, 012)
                ConsoleTheme.WriteSuccess($"\n[OK] Article #{createdArticle.Id:D3} '{createdArticle.Nom}' ajouté avec succès !");
                break;

            case 2:
                // --- AFFICHER LA LISTE DES ARTICLES ---
                ConsoleTheme.WriteInfo("--- LISTE DES ARTICLES ---");
                
                // GetArticles() renvoie IReadOnlyList<Article>.
                // Si la liste est vide, elle lève une EmptyInventoryException,
                // qui sera interceptée par le catch correspondant ci-dessous.
                var articles = inventory.GetArticles();

                Console.WriteLine(new string('-', 75));

                // Parcours de la collection via 'foreach'
                // Chaque article est affiché via sa méthode ToString() surchargée (override)
                foreach (var art in articles)
                {
                    Console.WriteLine(art);
                }
                Console.WriteLine(new string('-', 75));

                ConsoleTheme.WriteSuccess($"Total : {inventory.CalculateTotalQuantity()} unité(s) en stock | Valeur globale : {inventory.CalculateTotalInventoryValue():C2}");
                break;

            case 3:
                // --- RECHERCHER UN ARTICLE ---
                ConsoleTheme.WriteInfo("--- RECHERCHE D'UN ARTICLE ---");
                Console.WriteLine("1. Recherche par ID");
                Console.WriteLine("2. Recherche par Nom (mot-clé)\n");

                int searchType = ConsoleInput.AskForMenuOption("Votre choix (1-2) : ", 1, 2);
                Console.WriteLine();

                if (searchType == 1)
                {
                    // Recherche par ID : utilise .FirstOrDefault() dans le moteur
                    if (ConsoleInput.TryAskForInt("Entrez l'ID de l'article : ", out int id, minValue: 1))
                    {
                        var foundArticle = inventory.GetArticleById(id);
                        ConsoleSound.PlayInfo();
                        ConsoleTheme.WriteSuccess("\n[RÉSULTAT]");
                        Console.WriteLine(foundArticle);
                    }
                }
                else
                {
                    // Recherche par nom : utilise .Where() dans le moteur (filtrage LINQ)
                    if (ConsoleInput.TryAskForString("Entrez un nom ou mot-clé : ", out string keyword))
                    {
                        var results = inventory.SearchArticlesByName(keyword);
                        ConsoleSound.PlayInfo();
                        ConsoleTheme.WriteSuccess($"\n[RÉSULTATS] {results.Count} article(s) trouvé(s) :");
                        Console.WriteLine(new string('-', 75));
                        foreach (var art in results)
                        {
                            Console.WriteLine(art);
                        }
                        Console.WriteLine(new string('-', 75));
                    }
                }
                break;

            case 4:
                // --- SUPPRIMER UN ARTICLE ---
                ConsoleTheme.WriteInfo("--- SUPPRESSION D'UN ARTICLE ---");
                if (ConsoleInput.TryAskForInt("Entrez l'ID de l'article à supprimer (ou 'Q' pour annuler) : ", out int deleteId, minValue: 1))
                {
                    // RemoveArticleById() renvoie l'article supprimé (return article) pour la confirmation
                    var removedArticle = inventory.RemoveArticleById(deleteId);
                    ConsoleTheme.WriteSuccess($"\n[OK] L'article #{removedArticle.Id:D3} '{removedArticle.Nom}' a été supprimé de l'inventaire.");
                }
                else
                {
                    ConsoleTheme.WriteWarning("\n[ANNULÉ] Suppression annulée.");
                }
                break;

            case 5:
                // --- VIDER L'INVENTAIRE ---
                ConsoleTheme.WriteInfo("--- VIDER L'INVENTAIRE ---");
                inventory.Clear(); // Lève EmptyInventoryException si l'inventaire est déjà vide
                ConsoleTheme.WriteSuccess("[OK] Tous les articles ont été retirés de l'inventaire.");
                break;

            case 6:
                // --- QUITTER L'APPLICATION ---
                // Modifier 'running' à false arrêtera le prochain tour de la boucle 'while (running)'
                running = false;
                ConsoleTheme.WriteInfo("Merci d'avoir utilisé le gestionnaire d'inventaire. À bientôt !");
                break;
        }
    }
    // =========================================================================
    // CAPTURE DES EXCEPTIONS (DU PLUS SPÉCIFIQUE AU PLUS GÉNÉRIQUE)
    // =========================================================================
    // L'ordre des blocs 'catch' est crucial :
    // C# teste les blocs de HAUT en BAS et s'arrête au premier qui correspond.
    // Un 'catch (Exception)' placé en premier capturerait TOUTES les exceptions
    // et empêcherait les catchs plus spécifiques d'être atteints.
    // =========================================================================
    catch (EmptyInventoryException ex)
    {
        // Capture ciblée de l'exception métier "inventaire vide"
        ConsoleSound.PlayError();
        ConsoleTheme.WriteWarning($"[ATTENTION] {ex.Message}");
    }
    catch (ArticleNotFoundException ex)
    {
        // Capture ciblée de l'exception métier "article introuvable"
        ConsoleSound.PlayError();
        ConsoleTheme.WriteError($"[RECHERCHE] {ex.Message}");
    }
    catch (ArgumentException ex)
    {
        // Capture des erreurs de paramètres invalides (ArgumentException, ArgumentOutOfRangeException)
        ConsoleSound.PlayError();
        ConsoleTheme.WriteError($"[ERREUR] Paramètre invalide : {ex.Message}");
    }
    catch (Exception ex)
    {
        // Catch global "filet de sécurité" pour toute autre erreur imprévue
        ConsoleSound.PlayError();
        ConsoleTheme.WriteError($"[ERREUR INATTENDUE] {ex.Message}");
    }

    // Pause d'affichage entre chaque opération du menu si l'utilisateur n'a pas quitté
    if (running)
    {
        Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal...");
        // intercept: true masque la touche pressée à l'écran
        Console.ReadKey(intercept: true);
        ConsoleTheme.ApplyTheme();
    }
}

// Nettoyage final des couleurs et réinitialisation de la console avant de quitter
ConsoleTheme.Reset();
