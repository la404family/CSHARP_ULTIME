# Instructions pour la Génération des Cours LaTeX (.tex) & Script d'Assemblage

Ce document définit les règles et directives d'écriture pour générer le contenu théorique de **`001.LesBases`** sous forme de modules LaTeX (`.tex`) individuels, ainsi que les spécifications pour le script Python d'assemblage et de compilation.

---

## 1. Objectif et Architecture Modulaire

Pour éviter la surcharge d'un fichier unique et faciliter les modifications ciblées :
- **Un fichier `.tex` par chapitre** basé sur les sujets définis dans le [`README.md`](./README.md).
- Les fichiers source sont stockés dans un dossier `src/` (ex: `src/ch01_environnement.tex`, `src/ch02_variables.tex`, etc.).
- Un script Python `builder.py` orchestre la génération du document principal `main.tex` et la compilation en PDF.

---

## 2. Charte Graphique & Configuration LaTeX

### Style Général
- **Style scientifique et académique** : Utilisation des packages standard (`amsmath`, `amssymb`, `geometry`, `microtype`, `hyperref`, `booktabs`, `tcolorbox`).
- **Mise en page** : Marges équilibrées (ex: `geometry` avec `margin=2.5cm`), entêtes/pieds de page propres (`fancyhdr`), numérotation rigoureuse des sections, théorèmes et définitions.

### Typographie du Code
- **Police du code** : **`JetBrains Mono`** pour tous les blocs de code, listings et inline code (`\texttt`).
- **Mise en valeur du code** :
  - Utilisation du package `listings` (ou `minted` / `tcolorbox`) configuré avec JetBrains Mono.
  - Thème de coloration syntaxique clair et professionnel (style IDE moderne).
  - Numérotation des lignes à gauche, bordure fine et fond gris très léger (`#F8F9FA`).

#### Exemple de préambule LaTeX pour le code (`preamble.tex`) :
```latex
\usepackage{fontspec}
\setmonofont{JetBrains Mono}[
    Path = ./fonts/, % Ou installée sur le système
    Extension = .ttf,
    UprightFont = *-Regular,
    BoldFont = *-Bold,
    ItalicFont = *-Italic,
    BoldItalicFont = *-BoldItalic,
    Scale = 0.88
]

\usepackage{listings}
\usepackage{xcolor}

\definecolor{codegray}{rgb}{0.5,0.5,0.5}
\definecolor{backcolour}{rgb}{0.97,0.97,0.98}
\definecolor{keywordcolor}{rgb}{0.0,0.45,0.75}
\definecolor{stringcolor}{rgb}{0.8,0.25,0.1}

\lstdefinestyle{csharpstyle}{
    backgroundcolor=\color{backcolour},
    commentstyle=\color{codegray}\itshape,
    keywordstyle=\color{keywordcolor}\bfseries,
    numberstyle=\tiny\color{codegray},
    stringstyle=\color{stringcolor},
    basicstyle=\ttfamily\small,
    breakatwhitespace=false,
    breaklines=true,
    captionpos=b,
    keepspaces=true,
    numbers=left,
    numbersep=8pt,
    showspaces=false,
    showstringspaces=false,
    showtabs=false,
    tabsize=4
}
\lstset{style=csharpstyle}
```

---

## 3. Structure d'un Chapitre `.tex`

Chaque chapitre `.tex` individuel doit suivre une structure rigoureuse :

1. **Titre de la section** (`\section{...}`)
2. **Introduction théorique** : Définition formelle du concept, intérêt et cas d'usage scientifique/technique.
3. **Syntaxe et Règles** : Description des mots-clés, règles de typage et structures.
4. **Exemples de code commentés** :
   - Bloc de code avec `JetBrains Mono`.
   - Explications détaillées ligne par ligne sous le bloc.
5. **Pièges courants & Erreurs de compilation** (dans un bloc `tcolorbox` d'avertissement).
6. **Synthèse / A retenir** (tableau récapitulatif ou liste à puces).

---

## 4. Script Python de Compilation (`compile.py`)

Un script Python à la racine du projet `001.LesBases/` gère l'assemblage et la compilation automatique.

### Spécifications du script (`compile.py`) :
1. **Scan et Ordre** : Lit le dossier `src/` pour identifier tous les fichiers `.tex` dans l'ordre numérique défini dans le `README.md`.
2. **Génération de `main.tex`** :
   - Inclut le préambule (`preamble.tex`).
   - Génère automatiquement la table des matières (`\tableofcontents`).
   - Insère chaque fichier `.tex` via `\input{src/chXX_nom.tex}`.
3. **Compilation PDF** :
   - Exécute l'outil LaTeX (ex: `xelatex` ou `lualatex` pour supporter les polices TrueType/OpenType comme JetBrains Mono).
   - Effectue les passes nécessaires pour les références croisées et la table des matières.
4. **Nettoyage** : Supprime les fichiers temporaires de compilation (`.aux`, `.log`, `.toc`, `.out`, `.fls`, `.fdb_latexmk`).

#### Interface CLI du script :
```bash
python compile.py          # Compile le document complet
python compile.py --clean  # Nettoie les fichiers temporaires
python compile.py --watch  # Recompile automatiquement lors de la modification d'un fichier .tex
```

---

## 5. Directives pour le Formateur / l'IA

Lors de la rédaction ou mise à jour d'un cours `.tex` :
- **Ne jamais créer de fichier unique monolithique**.
- Traiter **un seul sujet du `README.md` par fichier `.tex`**.
- Utiliser un français châtié, technique et précis.
- **Règle absolue pour les explications** : Utiliser EXCLUSIVEMENT des concepts et exemples d'ingénierie logicielle ou d'informatique. Ne JAMAIS faire d'analogies avec la vie quotidienne, la cuisine, la mécanique automobile, etc. ("Le code c'est le code"). Les développeurs attendent des explications pour développeurs.
- Garantir que tous les exemples de code C# et SQL respectent le standard C# moderne (.NET 8+) et SQL Server.
- S'assurer que le code source compile sans erreur avant de l'inclure dans un fichier `.tex`.
- **Ne jamais utiliser `---` comme séparateur horizontal dans les fichiers LaTeX**, car cela génère un long tiret disgracieux seul sur une ligne dans le PDF généré. Utilisez l'espacement naturel des sections ou `\vspace` si nécessaire.
