#!/usr/bin/env python3
# -*- coding: utf-8 -*-

"""
Script de compilation pour la Formation C# & SQL (001LESBASES)
--------------------------------------------------------------
Ce script :
1. Détecte tous les fichiers .tex situés dans le dossier 'src/'.
2. Génère le fichier maître 'lesbases.tex' à la racine du projet.
3. Optionnellement, lance le compilateur LaTeX (xelatex / lualatex / pdflatex) pour générer le PDF final.
4. Nettoie les fichiers temporaires de compilation.
"""

import os
import sys
import subprocess
import glob
import argparse

# Configuration des chemins
SCRIPT_DIR = os.path.dirname(os.path.abspath(__file__))
SRC_DIR = os.path.join(SCRIPT_DIR, "src")
OUTPUT_TEX = os.path.join(SCRIPT_DIR, "lesbases.tex")
OUTPUT_PDF = os.path.join(SCRIPT_DIR, "lesbases.pdf")

# En-tête du document maître lesbases.tex
MASTER_TEX_HEADER = r"""% ==============================================================================
% Document Maître Assemblé : Les Bases C# et SQL
% Généré automatiquement par compile.py
% ==============================================================================

\documentclass[11pt,a4paper]{article}

% --- Packages fondamentaux ---
\usepackage[french]{babel}
\usepackage{geometry}
\geometry{margin=2.5cm}
\usepackage{amsmath,amssymb}
\usepackage{graphicx}
\usepackage{booktabs}
\usepackage{array}
\usepackage{xcolor}
\usepackage{enumitem}
\usepackage{hyperref}

% --- Configuration Typographique et Code ---
\usepackage{iftex}

\ifXeTeX
  \usepackage{fontspec}
  \setmonofont{JetBrains Mono}[
      Path = ./fonts/,
      Extension = .ttf,
      UprightFont = *-Regular,
      BoldFont = *-Bold,
      ItalicFont = *-Italic,
      BoldItalicFont = *-BoldItalic,
      Scale = 0.88,
      ErrorFilter = ignore
  ]
\else
  \ifLuaTeX
    \usepackage{fontspec}
    \setmonofont{JetBrainsMono-Regular}[Scale=0.88]
  \else
    \usepackage[utf8]{inputenc}
    \usepackage[T1]{fontenc}
  \fi
\fi

\usepackage{listings}
\usepackage{tcolorbox}
\tcbuselibrary{skins,breakable}

% --- Couleurs du thème ---
\definecolor{codegray}{rgb}{0.5,0.5,0.5}
\definecolor{backcolour}{rgb}{0.97,0.97,0.98}
\definecolor{keywordcolor}{rgb}{0.0,0.45,0.75}
\definecolor{stringcolor}{rgb}{0.8,0.25,0.1}

% --- Style de code C# et SQL ---
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
    tabsize=4,
    extendedchars=true,
    literate=
        {é}{{\'e}}1
        {è}{{\`e}}1
        {à}{{\`a}}1
        {â}{{\^a}}1
        {Â}{{\^A}}1
        {ç}{{\c{c}}}1
        {œ}{{\oe}}1
        {ù}{{\`u}}1
        {É}{{\'E}}1
        {È}{{\`E}}1
        {À}{{\`A}}1
        {Ç}{{\c{C}}}1
        {î}{{\^i}}1
        {ê}{{\^e}}1
        {ô}{{\^o}}1
        {û}{{\^u}}1
        {ë}{{\"e}}1
        {ï}{{\"i}}1
        {ü}{{\"u}}1
}
\lstset{style=csharpstyle}

% --- Liens Hyperref ---
\hypersetup{
    colorlinks=true,
    linkcolor=keywordcolor,
    filecolor=magenta,      
    urlcolor=keywordcolor,
    pdftitle={001 - Les Bases : C\# et SQL},
    pdfauthor={Formation .NET}
}

\begin{document}

"""

MASTER_TEX_FOOTER = r"""

\end{document}
"""

def get_tex_files():
    """Récupère tous les fichiers .tex du dossier src/ triés par ordre alphabétique."""
    if not os.path.exists(SRC_DIR):
        print(f"[ERREUR] Le dossier '{SRC_DIR}' n'existe pas.")
        return []
    
    files = glob.glob(os.path.join(SRC_DIR, "*.tex"))
    files.sort(key=lambda f: os.path.basename(f).lower())
    return files

def generate_master_tex(tex_files):
    """Génère le fichier lesbases.tex en assemblant les inputs vers chaque sous-fichier .tex."""
    print(f"[*] Assemblage de {len(tex_files)} fichier(s) .tex dans '{OUTPUT_TEX}'...")
    
    with open(OUTPUT_TEX, "w", encoding="utf-8") as f:
        f.write(MASTER_TEX_HEADER)
        
        for filepath in tex_files:
            rel_path = os.path.relpath(filepath, SCRIPT_DIR).replace("\\", "/")
            basename = os.path.basename(filepath)
            f.write(f"% --- Inclusion de {basename} ---\n")
            f.write(f"\\input{{{rel_path}}}\n\n")
            
        f.write(MASTER_TEX_FOOTER)
        
    print(f"[OK] Fichier '{OUTPUT_TEX}' généré avec succès.")

def compile_pdf(compiler="xelatex"):
    """Compile lesbases.tex en PDF à l'aide de l'outil LaTeX spécifié."""
    if not os.path.exists(OUTPUT_TEX):
        print(f"[ERREUR] Le fichier maître '{OUTPUT_TEX}' n'existe pas.")
        return False
        
    print(f"[*] Lancement de la compilation avec '{compiler}'...")
    try:
        # Première passe
        subprocess.run([compiler, "-interaction=nonstopmode", "lesbases.tex"], check=True, cwd=SCRIPT_DIR)
        # Deuxième passe (pour la table des matières et les références)
        subprocess.run([compiler, "-interaction=nonstopmode", "lesbases.tex"], check=True, cwd=SCRIPT_DIR)
        print(f"[OK] PDF généré : '{OUTPUT_PDF}'")
        return True
    except FileNotFoundError:
        print(f"[AVERTISSEMENT] Compilateur '{compiler}' introuvable dans le PATH système.")
        print("    Vous pouvez ouvrir et compiler 'lesbases.tex' avec votre éditeur LaTeX préféré (Overleaf, TeXstudio, VS Code...).")
        return False
    except subprocess.CalledProcessError as e:
        print(f"[ERREUR] La compilation a échoué avec le code de retour {e.returncode}.")
        return False

def clean_temp_files():
    """Supprime les fichiers temporaires de compilation LaTeX."""
    extensions = [".aux", ".log", ".toc", ".out", ".fls", ".fdb_latexmk", ".synctex.gz"]
    count = 0
    for ext in extensions:
        pattern = os.path.join(SCRIPT_DIR, f"*{ext}")
        for filepath in glob.glob(pattern):
            try:
                os.remove(filepath)
                count += 1
            except OSError as e:
                print(f"[!] Impossible de supprimer {filepath} : {e}")
    print(f"[OK] Nettoyage terminé ({count} fichier(s) temporaire(s) supprimé(s)).")

def main():
    parser = argparse.ArgumentParser(description="Compilateur et assembleur de cours LaTeX (001LESBASES).")
    parser.add_argument("--compile", action="store_true", help="Compile le fichier lesbases.tex en PDF.")
    parser.add_argument("--compiler", default="xelatex", choices=["xelatex", "pdflatex", "lualatex"], help="Moteur LaTeX à utiliser (par défaut : xelatex).")
    parser.add_argument("--clean", action="store_true", help="Nettoie les fichiers temporaires après assemblage.")
    
    args = parser.parse_args()
    
    tex_files = get_tex_files()
    if not tex_files:
        print("[!] Aucun fichier .tex trouvé dans src/.")
        sys.exit(1)
        
    generate_master_tex(tex_files)
    
    if args.compile:
        compile_pdf(compiler=args.compiler)
        
    if args.clean:
        clean_temp_files()

if __name__ == "__main__":
    main()
