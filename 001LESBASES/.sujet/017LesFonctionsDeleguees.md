# Les fonctions déléguées

Les fonctions déléguées sont des types qui représentent des références à des méthodes. Elles permettent de passer des méthodes comme arguments à d'autres méthodes, de stocker des méthodes dans des variables, et de créer des événements.

## Exemples de fonctions déléguées

```csharp
// Déclaration d'un délégué
public delegate void MyDelegate(string message);
// Méthode qui correspond au délégué
public void ShowMessage(string message)
{
    Console.WriteLine(message);
}
// Utilisation du délégué
MyDelegate del = new MyDelegate(ShowMessage);
del("Hello, World!"); // Affiche "Hello, World!"
```

## Utilisation des délégués

Les délégués sont souvent utilisés pour les événements et les callbacks. Ils permettent de créer des méthodes qui peuvent être appelées en réponse à des actions spécifiques, comme un clic de souris ou une touche de clavier.

```csharp
// Déclaration d'un délégué pour un événement
public delegate void EventHandler(string eventMessage);
// Classe qui déclenche l'événement
public class EventPublisher
{
    public event EventHandler OnEvent;
    public void TriggerEvent(string message)
    {
        OnEvent?.Invoke(message); // Appelle les méthodes abonnées à l'événement
    }
}
// Classe qui s'abonne à l'événement
public class EventSubscriber
{
    public void HandleEvent(string message)
    {
        Console.WriteLine("Event received: " + message);
    }
}

// Utilisation de l'événement
EventPublisher publisher = new EventPublisher();
EventSubscriber subscriber = new EventSubscriber();
publisher.OnEvent += subscriber.HandleEvent; // S'abonne à l'événement
publisher.TriggerEvent("This is an event message!"); // Affiche "Event received: This
// is an event message!"
```

## Avantages des délégués

Les délégués offrent plusieurs avantages :

- **Flexibilité** : Ils permettent de passer des méthodes comme arguments, ce qui rend le code plus flexible et réutilisable.

- **Découplage** : Ils permettent de séparer la logique de l'événement de la logique de traitement, ce qui facilite la maintenance du code.
- **Support des événements** : Ils sont utilisés pour implémenter des événements, ce qui est essentiel pour la programmation orientée événement.
- **Type-safety** : Les délégués sont des types forts, ce qui signifie qu'ils garantissent que les méthodes appelées correspondent à la signature du délégué.
- **Support des callbacks** : Ils permettent de créer des méthodes de rappel, ce qui est utile pour les opérations asynchrones ou les traitements en arrière-plan.
- **Interopérabilité** : Ils peuvent être utilisés pour interagir avec des API externes ou des bibliothèques qui utilisent des délégués.
- **Simplicité** : Ils simplifient la gestion des événements et des callbacks en fournissant une syntaxe claire et concise.
- **Performance** : Ils peuvent améliorer les performances en évitant la création de classes anonymes pour les événements simples.
- **Support des lambdas** : Ils peuvent être utilisés avec des expressions lambda, ce qui rend le code plus concis et lisible.
- **Support des méthodes anonymes** : Ils permettent de créer des méthodes anonymes, ce qui est utile pour les événements et les callbacks sans avoir à définir une méthode séparée.
- **Support des fonctions d'ordre supérieur** : Ils permettent de créer des fonctions qui acceptent d'autres fonctions comme arguments, ce qui est utile pour les opérations de filtrage, de tri, etc.
