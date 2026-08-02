// L'espace de noms (namespace) permet d'organiser le code.
// Bien que ce ne soit pas strictement obligatoire pour le compilateur, la convention standard et incontournable en C#
// est de faire correspondre le namespace à l'arborescence : NomDuProjet.NomDuDossier (ici Calculatrice.Services).
// Cela facilite grandement le repérage du code, le travail en équipe, et c'est utilisé par les outils (comme Visual Studio).
namespace Calculatrice.Services;

// 'public' : La classe est accessible depuis d'autres fichiers (comme Program.cs).
// 'static' : Il n'y a pas besoin de créer une "instance" (un objet) de cette classe avec le mot-clé 'new' pour l'utiliser. 
// On peut appeler ses méthodes directement via CalculatorEngine.Calculate(...).
public static class CalculatorEngine
{
    // 'public static' : Méthode accessible partout sans instanciation.
    // 'double' : Le type de retour est un nombre décimal (double précision). Idéal pour les mathématiques car il gère les virgules et les très grands nombres.
    // Paramètres :
    // - double num1, num2 : Les deux nombres sur lesquels opérer.
    // - string op : L'opérateur sous forme de texte ("+", "-", "*", "/").
    public static double Calculate(double num1, double num2, string op)
    {
        // 'switch expression' : Syntaxe moderne (C# 8+) qui évalue la variable 'op' 
        // et retourne directement le résultat correspondant sans avoir besoin du mot-clé 'return' à chaque ligne.
        return op switch
        {
            "+" => num1 + num2, // Si op vaut "+", on retourne l'addition
            "-" => num1 - num2,
            "*" => num1 * num2,
            
            // L'opérateur ternaire (condition ? vrai : faux) est utilisé ici pour éviter de diviser par zéro.
            // Si num2 est différent de 0, on divise. Sinon, on renvoie double.NaN (Not a Number, signifiant "Pas un nombre valide").
            "/" => num2 != 0 ? num1 / num2 : double.NaN, 
            
            // '_' correspond au cas par défaut (default). 
            // 'throw' déclenche une exception (une erreur violente d'exécution) si un opérateur inconnu a réussi à arriver jusqu'ici.
            _ => throw new InvalidOperationException("Opérateur invalide")
        };
    }
}
