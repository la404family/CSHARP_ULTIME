# The Legend of Kevin - Logique du Jeu (GAME LOGIC)

Ce document détaille la logique narrative et spatiale des interactions entre Kevin et les Agents Administratifs.

## 1. La Quête du Cerfa A-38

L'objectif de Kevin est d'obtenir le légendaire Cerfa A-38. 
Cependant, l'Administration Centrale est un labyrinthe bureaucratique : aucun agent ne peut lui donner le Cerfa directement sans qu'il ait obtenu les tampons préalables des autres agents.

### Déroulement de la Quête

Au début de chaque partie, le jeu génère un **ordre aléatoire** parmi les 7 agents. Kevin reçoit un indice (souvent flou ou trompeur) pour trouver le **premier agent** de cette séquence.

Lorsque Kevin atteint ce premier agent, le dialogue d'introduction se déclenche :

- **Kevin :** *"Bonjour, je viens pour le Cerfa A-38."*
- **L'Agent (ex: Josiane) :** *"Bonjour Monsieur. Vous ne pouvez pas avoir le Cerfa A-38 directement. Le Cerfa A-38 est strictement réservé aux citoyens préalablement identifiés par le formulaire bleu B-42, lui-même conditionné par la présentation d'un justificatif de domicile de moins de 12 heures, visé par le bureau des réclamations du sous-sol... [Long pavé absurde] ... Bref, je peux vous donner la liasse rose, mais pour la suite il faudra voir avec mes collègues. Mais avant cela quel est votre nom et vous avez quel age ?"*

C'est à ce moment que Kevin donne son **nom** et son **âge** pour la première fois. L'âge renseigné ici est la "Vérité Absolue" du dossier.

Après validation, l'agent donne un indice vers le prochain agent de la séquence. Kevin doit ensuite suivre cet ordre précis jusqu'au dernier agent.


## 2. Les Indices (Le Bureau des Doutes)

La carte est fixe et **la position de chaque agent est fixe**. C'est **l'ordre de la quête** (le parcours des agents restants après le premier) qui change aléatoirement à chaque partie ! 
Puisque les positions sont fixes, on peut décrire les lieux. MAIS l'administration aime la confusion : les agents donnent souvent des indices flous, confondent les prénoms (ex: Josiane et Jacqueline commencent par J), ou ne donnent qu'une position vague sans citer de nom.


Pour chaque agent cible, le jeu piochera au hasard parmi **5 indices différents** (certains évidents, d'autres très trompeurs) :

**Agent 1 : Josiane (Magenta, "Formulaire B-42")**
1. *"Il faut que vous alliez voir la dame en tailleur Magenta... C'est dans la première salle en entrant."* (Clair)
2. *"Le prochain formulaire ? C'est une certaine J... Josiane ou Jacqueline, je ne sais plus. En tout cas, c'est la première salle."* (Doute sur le nom, lieu clair)
3. *"Le prochain document ? Je crois que c'est pour une certaine J... ou peut-être B. Bonne chance pour la trouver, moi je prends ma pause."* (Doute total sur la lettre, AUCUN lieu, AUCUNE couleur)
4. *"C'est le bureau de Josiane. On la repère de loin avec ses vêtements Magenta criards."* (Clair)
5. *"Il vous faut la signature d'une femme dont le nom commence par J. Elle est vers l'entrée du bâtiment."* (Doute sur J)

**Agent 2 : Bernadette (Vert, "Cerfa 1138-bis")**
1. *"Votre dossier doit passer par le bureau Vert. C'est Bernadette, dans la deuxième salle."* (Clair)
2. *"Allez voir la dame en tailleur émeraude. Son nom m'échappe... un truc qui commence par B, dans la deuxième salle."* (Flou sur le nom)
3. *"Il faut voir l'agent B... ou peut-être G. Je n'ai aucune idée d'où elle est, ne me posez plus de questions."* (Doute total sur la lettre, AUCUN lieu, AUCUNE couleur)
4. *"Il faut trouver l'agent B. Elle est habillée tout en Vert, dans la deuxième salle."* (Clair)
5. *"Cherchez un bureau vert, pas très loin de l'entrée. C'est pour une certaine Bernadette."* (Clair)

**Agent 3 : Gertrude (Cyan, "Laissez-passer A-39")**
1. *"Vous devez trouver le bureau en cul-de-sac. C'est pour G... Gertrude."* (Clair)
2. *"Allez voir Gertrude. Elle est dans la seule salle avec une seule issue, habillée en Cyan."* (Clair)
3. *"C'est un dossier pour G... Débrouillez-vous avec ça, ça ne relève pas de mes compétences."* (Une lettre, AUCUN lieu, AUCUNE couleur)
4. *"Il me semble que c'est la dame en Cyan. Allez la déranger dans son cul-de-sac."* (Clair)
5. *"Cherchez un tailleur couleur Cyan. C'est un bureau où on ne fait que passer... ou plutôt d'où on ne peut pas sortir !"* (Indice lieu cryptique)

**Agent 4 : Jacqueline (Gris, "Timbre Fiscal de 14,99€")**
1. *"Allez voir Jacqueline, elle est tout au fond du bâtiment."* (Clair)
2. *"Le prochain formulaire est visé par une dame en J... Jacqueline ou Josiane. Elle est dans le bureau tout au fond."* (Doute sur J, lieu clair)
3. *"Il vous faut l'accord de J. Je ne sais pas laquelle, il y en a plusieurs de toute façon. Allez la chercher."* (Doute sur quelle J, AUCUN lieu, AUCUNE couleur)
4. *"Cherchez la couleur Grise. C'est tout au fond du complexe."* (Clair)
5. *"Allez trouver la femme en J qui est tout au fond. Ne la confondez pas avec l'autre J à l'entrée !"* (Aide sur le doute)

**Agent 5 : Micheline (Bleu, "Dossier Z-77 Dérogatoire")**
1. *"Le prochain bureau est géré par Micheline. C'est un bureau coincé entre deux autres."* (Clair)
2. *"Trouvez la dame dont le prénom commence par M... ou J. À ce qu'il paraît, son bureau est entre deux autres."* (Doute sur M/J, lieu clair)
3. *"C'est le tampon de M. Je n'ai pas la moindre idée d'où est son bureau aujourd'hui."* (Une lettre, AUCUN lieu, AUCUNE couleur)
4. *"Allez voir Micheline ! Elle est coincée entre deux autres bureaux."* (Clair)
5. *"Il vous faut le tampon de M. Cherchez un bureau au milieu du couloir."* (Clair)

**Agent 6 : Francine (Jaune, "Annexe K-90 en triple exemplaire")**
1. *"Il vous faut l'Annexe de Francine. C'est la personne vêtue de Jaune."* (Clair)
2. *"Allez trouver la dame en Jaune... F... Francine, je crois. Elle adore les paperasses en triple exemplaire."* (Clair)
3. *"Le prochain guichet est tenu par Francine. Cherchez une lueur Jaune dans un recoin."* (Flou sur la localisation)
4. *"Il vous manque une annexe. Voyez avec F., la dame en Jaune. Bon courage."* (Clair)
5. *"C'est au tour de Francine de vous humilier. Repérez son tailleur Jaune."* (Clair)

**Agent 7 : Huguette (Rouge, "Justificatif de Non-Existence")**
1. *"Seule Huguette en Rouge peut valider cette étape."* (Clair)
2. *"Cherchez la dame habillée tout en Rouge, c'est H... Huguette. Elle demande des trucs impossibles."* (Clair)
3. *"Allez voir la couleur Rouge, c'est Huguette. Ne la fixez pas trop longtemps dans les yeux."* (Clair)
4. *"Il manque la signature de H., la préposée en Rouge."* (Clair)
5. *"Passez voir Huguette. Vous la reconnaîtrez à son horrible gilet Rouge."* (Clair)

## 3. Logique d'Échec (Mauvais Ordre)

Si Kevin s'adresse à un agent qui n'est pas le prochain sur sa liste :
- L'agent refuse catégoriquement de l'aider en piochant aléatoirement parmi ces **10 excuses absurdes** :
  1. *"Vous n'avez pas le formulaire précédent ! Ne me dérangez pas pendant ma pause"*
  2. *"Votre dossier n'est pas complet. Revenez quand vous aurez le tampon adéquat, et arrêtez de respirer mon air."*
  3. *"Je suis en plein classement de mes trombones par ordre de brillance, ce n'est vraiment pas le moment !"*
  4. *"Mais enfin, vous voyez bien que le guichet est fermé ! Le fait que je sois assise derrière à vous regarder ne change rien."*
  5. *"Ah non, pour ça il faut aller voir le bureau compétent. Lequel ? Aucune idée, mais ce n'est pas ici."*
  6. *"Votre demande est irrecevable, je ne vous écoute pas bla blabla bli bla bla bla !! Oust !"*
  7. *"C'est l'heure de la mise à jour du système informatique central. Je suis navrée..."*
  8. *"C'est votre problème, pas le mien."*
  9. *"Revenez plus tard. Je termine dans 45 minutes donc je n'ai plus le temps."*
  10. *"Je suis navrée, mais la machine à café est en panne."*
- **Conséquence :** Kevin perd 1 Point de Patience (☕). Kevin à 15 points de patience au début du jeu.
- Si la patience tombe à 0, c'est le Burnout (Game Over).
- Au gameover la fentre ne doit pas se fermé brutalement mais afficher seulement un message ... **BURNOUT!** appuryer sur n'importe qu'elle touche pour recommencer une nouvelle partie.

## 4. La Mécanique Diabolique des Formulaires

L'administration exige des formulaires impeccables. À chaque interaction avec un agent, le joueur devra prouver son identité directement **dans la fenêtre d'interface**.

1. **L'Enregistrement Initial :** Le jeu démarre directement par une recherche. C'est **lors de la première interaction** avec le premier agent valide de la séquence que le joueur donne son âge. Après le premier pavé de dialogue absurde refusant le Cerfa A-38, l'agent demande : *"quel est votre nom et vous avez quel age ?"*. L'âge renseigné à ce moment précis devient la "Vérité Absolue" du dossier.
2. **Le Remplissage :** Pour chaque agent rencontré, le jeu mettra l'action en pause. Dans la console UI, le joueur sera invité à taper :
   - Son Prénom (qui doit absolument être "Kevin", peu importe la casse).
   - Son Âge. (L'âge qu'il veut mais toujours le même par rapport au premier agent.)
3. **Erreur de Prénom (Immédiate) :** Si le joueur tape un autre prénom que Kevin (Avec la majuscule), l'agent le rejette immédiatement : *"Vous n'êtes pas sur le dossier ! Refus !"* -> -1 Patience et on lui indique qu'il doit tout recommencer du début à partir du premier agent ! 
4. **Erreur d'Âge (Piège à Retardement) :** Si le joueur tape un âge **différent** de celui donné au TOUT PREMIER agent, l'agent **ne dit rien**. Il accepte le formulaire et valide l'étape. Le joueur croit avoir réussi.
5. **Le Contrôle Final (Le Boss de Fin) :** Lorsque Kevin arrive enfin au tout dernier agent pour récupérer le Cerfa A-38, l'agent épluche l'intégralité du dossier.
   - L'interface affiche avec un suspense insoutenable (pause de 1.5 secondes entre chaque ligne) :
     - *"Alors... Formulaire (nom du formulaire) : Kevin, 32 ans..."*
     - *"Formulaire (nom du formulaire) : Kevin, 32 ans..."*
     - *"Formulaire (nom du formulaire) : Kevin, 45 ans..."*
   - S'il y a la moindre incohérence dans un âge : *"INCOHÉRENCE DANS LE DOSSIER ! VOTRE ÂGE CHANGE SELON LES BUREAUX ! DOSSIER REJETÉ !"* ²
   - **Conséquence :** -5 Patience, ET toute la quête est réinitialisée et si plus de point de patience c'est le BURNOUT ! Kevin doit retourner voir le tout premier agent et recommencer la chaîne parfaite depuis le début !
