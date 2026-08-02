// 💡 Note sur l'architecture et les noms :
// Le dossier du projet s'appelle "002.Calculatrice". Cependant, en C#, un espace de noms 
// (namespace) n'a pas le droit de commencer par un chiffre.
// J'ai donc choisi le nom "Calculatrice" et je l'ai inscrit explicitement tout en haut 
// des 3 autres fichiers que nous avons créés :
//   - Utils/ConsoleInput.cs         (où j'ai écrit "namespace Calculatrice.Utils;")
//   - Utils/ConsoleTheme.cs         (où j'ai écrit "namespace Calculatrice.Utils;")
//   - Services/CalculatorEngine.cs  (où j'ai écrit "namespace Calculatrice.Services;")
// 
// C'est parce que ces fichiers possèdent ces noms-là à l'intérieur de leur code
// que l'on peut charger leurs fonctionnalités ici via les commandes "using" ci-dessous :

// Les directives 'using' permettent d'importer nos espaces de noms personnalisés.
// Sans elles, on devrait taper "Calculatrice.Utils.ConsoleTheme.ApplyTheme()" au lieu de juste "ConsoleTheme.ApplyTheme()".
using Calculatrice.Utils;
using Calculatrice.Services;

// 0. INITIALISATION
// On appelle la méthode statique ApplyTheme pour colorer toute la console avant de commencer.
ConsoleTheme.ApplyTheme();

// 'while (true)' est une boucle infinie. Le programme restera bloqué dans ce cycle 
// jusqu'à ce que l'instruction 'break' (plus bas) soit appelée.
while (true)
{
    // 'WriteLine' affiche le texte et ajoute un saut de ligne automatique à la fin.
    Console.WriteLine("--- Calculatrice Modulaire ---");

    // 1. SAISIE DES DONNÉES
    // 'double' (double précision) : C'est le type idéal pour les calculs car il gère les virgules, contrairement à 'int' (entier).
    double number1 = ConsoleInput.GetNumber("Saisissez le premier nombre : ");
    
    // 'string' (chaîne de caractères) : On stocke l'opérateur en tant que texte ("+", "-", "*", "/").
    string op = ConsoleInput.GetOperator();
    
    double number2 = ConsoleInput.GetNumber("Saisissez le second nombre : ");

    // 2. EXÉCUTION DU CALCUL
    // On appelle notre moteur de calcul (qui n'a aucune idée qu'il est utilisé dans une console).
    // On lui passe nos 3 variables (number1, number2, op) en argument, et il nous retourne le résultat calculé.
    double result = CalculatorEngine.Calculate(number1, number2, op);

    // 3. AFFICHAGE ET GESTION DES ERREURS MATHÉMATIQUES
    // La méthode 'double.IsNaN' vérifie si la valeur de 'result' est "Not a Number" 
    // (ce qui est renvoyé par notre moteur en cas de division par zéro).
    if (double.IsNaN(result))
    {
        ConsoleSound.PlayError();
        ConsoleTheme.WriteError("Erreur : Impossible de diviser par zéro !");
    }
    // 'double.IsInfinity' vérifie si le résultat a dépassé la limite physique de stockage d'un 'double' (Dépassement de capacité).
    else if (double.IsInfinity(result))
    {
        ConsoleSound.PlayError();
        ConsoleTheme.WriteError("Erreur : Le résultat est trop grand (Dépassement de capacité) !");
    }
    else
    {
        // Si le résultat est valide mathématiquement, on joue la mélodie de succès.
        ConsoleSound.PlayResult();
        
        // On utilise l'interpolation de chaîne (grâce au symbole $ avant les guillemets) 
        // pour insérer la valeur de nos variables directement dans le texte, entre des accolades {}.
        Console.WriteLine($"Résultat : {number1} {op} {number2} = {result}");
    }

    // 4. DEMANDE DE REDÉMARRAGE
    // On affiche une ligne vide pour aérer la console.
    Console.WriteLine();
    Console.WriteLine("Voulez-vous faire un autre calcul ? (Appuyez sur 'O' pour Oui, n'importe quelle autre touche pour quitter)");
    
    // 'ConsoleKeyInfo' est une "structure" (struct) de C# qui contient les informations sur la touche frappée.
    // 'Console.ReadKey(intercept: true)' lit la frappe mais le paramètre 'true' masque la lettre à l'écran.
    ConsoleKeyInfo key = Console.ReadKey(intercept: true); 
    
    // 'key.Key' correspond à une énumération (ConsoleKey) représentant la touche physique du clavier.
    if (key.Key == ConsoleKey.O)
    {
        // Si la touche est 'O', on réapplique le thème, ce qui appelle 'Console.Clear()' 
        // sous le capot, et on recommence tout en haut de la boucle 'while (true)'.
        ConsoleTheme.ApplyTheme();
    }
    else
    {
        // Si on appuie sur n'importe quelle autre touche, 'break' casse la boucle infinie de force.
        // Le programme va donc sortir du 'while' et continuer son exécution juste en dessous.
        break; 
    }
}

// 5. RESTAURATION ET FIN
// Une fois sorti de la boucle, on nettoie les couleurs que l'on avait imposées au terminal de l'utilisateur,
// pour rendre son terminal dans son état naturel Noir/Blanc d'origine. C'est la bonne pratique !
ConsoleTheme.Reset();
