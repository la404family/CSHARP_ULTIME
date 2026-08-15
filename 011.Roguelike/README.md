# The Legend of Kevin : La Quête du Cerfa A-38

Un Rogue-like procédural et bureaucratique entièrement en mode Console C#.

## 📖 L'Histoire : Le Labyrinthe Administratif

Dans le redoutable bâtiment de l'Administration Centrale, **Kevin** (`@`) s'est vu confier une quête d'apparence simple : obtenir le fameux **Formulaire Cerfa A-38**. 
Cependant, le bâtiment est un véritable dédale procédural, et l'administration est machiavélique !

👉 **[Consultez GAME_LOGIC.md pour découvrir toutes les règles vicieuses de l'administration !](GAME_LOGIC.md)**

Oubliez les orcs et les dragons. Ici, vos pires cauchemars sont les **Agents Administratifs** (Josiane, Bernadette, Gertrude, Jacqueline, Micheline, Francine, Huguette). Chacun possède son propre bureau et arbore un tailleur de couleur différente.

**Le But du Jeu :**
Au début de chaque partie, le jeu génère un parcours aléatoire parmi les 7 agents et vous donne un indice (souvent flou) pour trouver le premier. Lorsque Kevin atteint ce premier agent, le dialogue d'introduction se déclenche et le joueur donne son **Nom** et son **Âge**. L'âge renseigné à ce moment précis sera la "Vérité Absolue" du dossier.
L'agent donne ensuite un indice vers le prochain bureau. Kevin doit suivre cet ordre précis jusqu'au dernier agent.
À chaque interaction, l'agent vous fera remplir un formulaire. Attention à la rigueur administrative :
- Vous devez impérativement vous appeler **Kevin** (avec la majuscule). Une erreur de casse et le dossier est rejeté !
- Vous pouvez mentir sur votre âge à chaque étape, l'agent de base ne vérifiera pas... Mais au dernier bureau, l'agent final vérifiera l'intégralité du dossier. La moindre incohérence d'âge par rapport au TOUT PREMIER agent, et le dossier est brûlé !

Vous avez **15 Points de Patience** (☕). Vous adresser au mauvais agent ou faire une erreur de nom vous fera perdre de la patience, avec des excuses générées procéduralement. Si la jauge tombe à zéro, c'est le **BURNOUT** (Game Over).

## 🎮 Concept Visuel : Le Multi-Fenêtrage (IPC)

Le jeu est techniquement constitué de deux fenêtres de console qui s'exécutent simultanément et communiquent via un état JSON (Communication Inter-Processus).

1. **Console Principale (Carte, à gauche)** : Le moteur graphique gère une matrice 2D affichant Kevin (`@`), les couloirs (`.`), les murs (`#`) et les 7 agents identifiés par leur initiale colorée.
2. **Console Secondaire (Interface, à droite)** : Moteur narratif. Affiche les objectifs actuels, la barre de patience, les dialogues absurdes et capture les saisies de formulaires (`Console.ReadLine()`), en bloquant l'affichage de la carte pendant la saisie.

Les deux fenêtres s'ouvrent, se calculent et se positionnent automatiquement en plein écran divisé grâce aux appels API Win32 (`user32.dll`).

## 🎯 Architecture Technique

- **Moteur d'États (State Machine)** : `GameManager.cs` synchronise les deux écrans via un objet `GameState` sérialisé en temps réel.
- **Sérialisation JSON** : Les cartes (`level01.json`), les dialogues (`dialogues.json`) et les excuses (`excuses.json`) sont externalisés pour une modification aisée de la logique.
- **Rendu Optimisé Console** : Utilisation de `Console.SetCursorPosition` et de `Console.ForegroundColor` pour dessiner sans scintillement.
- **Logique Algorithmique (Quêtes)** : Séquence de quête générée aléatoirement, avec un système d'indices trompeurs tirés au sort.

## 📂 Architecture du Projet

Voici comment les dossiers et fichiers sont articulés dans le projet :

```text
📁 011.Roguelike
├── 📁 Data            # Fichiers de configuration JSON et niveaux
│   ├── LevelLoader.cs # Charge les niveaux en mémoire
│   ├── 📁 Levels      # Contient les cartes sous forme de grilles JSON
│   ├── dialogues.json # Textes et règles des dialogues avec les agents
│   ├── excuses.json   # Base d'excuses absurdes (pour les mauvaises interactions)
│   └── intro.json     # Textes d'introduction
├── 📁 Engine          # Moteur du jeu et de la logique métier
│   ├── GameManager.cs # Machine à états (State Machine), gère la boucle de jeu et la synchro IPC
│   ├── InputHandler.cs# Gestion des entrées clavier et des formulaires
│   └── QuestManager.cs# Génération procédurale de la séquence d'agents et indices
├── 📁 Models          # Classes de données (POCOs)
│   ├── Agent.cs       
│   ├── Entity.cs      
│   ├── GameState.cs   # L'état global du jeu partagé entre la Map et l'UI
│   ├── LevelData.cs   
│   ├── Player.cs      
│   └── Position.cs    
├── 📁 UI              # Gestion de l'affichage Console
│   ├── Renderer.cs    # Moteur de rendu optimisé pour la console
│   └── WindowManager.cs# Appels natifs Win32 (user32.dll) pour gérer les deux fenêtres
├── Program.cs         # Point d'entrée (args: "map" ou "ui")
├── GAME_LOGIC.md      # Règles complètes du gameplay et mécaniques (Boss de fin, indices)
└── README.md          # Ce fichier
```

## 🚀 Comment Jouer

1. Compilez le projet (`dotnet build`).
2. Lancez le jeu via `dotnet run`.
3. Le terminal principal lance automatiquement le second terminal.
4. **Déplacement** : `Z, Q, S, D` (ou flèches directionnelles).
5. **Interaction** : Avancez sur un Agent (passez dessus ou collez-le) pour lui parler.
6. Lisez attentivement la console de droite et remplissez les formulaires sans erreur !
