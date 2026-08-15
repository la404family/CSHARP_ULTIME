import json
import random

WIDTH = 115
HEIGHT = 25

# 1. Grille remplie de VIDE (espaces) et non de murs massifs !
grid = [[' ' for _ in range(WIDTH)] for _ in range(HEIGHT)]

# --- ÉTAPE 1 : Générer des salles rectangulaires ---
rooms = []
MAX_ROOMS = 8
MIN_ROOM_W = 10
MAX_ROOM_W = 24
MIN_ROOM_H = 6
MAX_ROOM_H = 10

for _ in range(200):
    if len(rooms) >= MAX_ROOMS:
        break
    w = random.randint(MIN_ROOM_W, MAX_ROOM_W)
    h = random.randint(MIN_ROOM_H, MAX_ROOM_H)
    x = random.randint(2, WIDTH - w - 3)
    y = random.randint(2, HEIGHT - h - 3)

    overlap = False
    for rx, ry, rw, rh in rooms:
        if (x - 2 < rx + rw and x + w + 2 > rx and
            y - 2 < ry + rh and y + h + 2 > ry):
            overlap = True
            break
    if not overlap:
        rooms.append((x, y, w, h))

# Creuser les sols des salles (uniquement des points '.')
for rx, ry, rw, rh in rooms:
    for yy in range(ry, ry + rh):
        for xx in range(rx, rx + rw):
            grid[yy][xx] = '.'

# --- ÉTAPE 2 : Connecter les salles par des couloirs ---
def center(room):
    rx, ry, rw, rh = room
    return rx + rw // 2, ry + rh // 2

def carve_h_corridor(x1, x2, y):
    for x in range(min(x1, x2), max(x1, x2) + 1):
        if 0 < y < HEIGHT - 1 and 0 < x < WIDTH - 1:
            grid[y][x] = '.'

def carve_v_corridor(y1, y2, x):
    for y in range(min(y1, y2), max(y1, y2) + 1):
        if 0 < y < HEIGHT - 1 and 0 < x < WIDTH - 1:
            grid[y][x] = '.'

sorted_rooms = sorted(rooms, key=lambda r: r[0])

for i in range(len(sorted_rooms) - 1):
    cx1, cy1 = center(sorted_rooms[i])
    cx2, cy2 = center(sorted_rooms[i + 1])

    if random.random() < 0.5:
        carve_h_corridor(cx1, cx2, cy1)
        carve_v_corridor(cy1, cy2, cx2)
    else:
        carve_v_corridor(cy1, cy2, cx1)
        carve_h_corridor(cx1, cx2, cy2)

# --- ÉTAPE 3 : Ajouter les murs UNIQUEMENT autour des sols ---
# On crée une copie pour lire l'état précédent proprement
old_grid = [row[:] for row in grid]

for y in range(HEIGHT):
    for x in range(WIDTH):
        if old_grid[y][x] == ' ':
            # Vérifier si un voisin (haut, bas, gauche, droite, diagonales) est un sol '.'
            neighbors = [
                (x-1, y-1), (x, y-1), (x+1, y-1),
                (x-1, y),             (x+1, y),
                (x-1, y+1), (x, y+1), (x+1, y+1)
            ]
            for nx, ny in neighbors:
                if 0 <= nx < WIDTH and 0 <= ny < HEIGHT:
                    if old_grid[ny][nx] == '.':
                        grid[y][x] = '#'  # Placer un mur
                        break

# --- ÉTAPE 4 : Portes (Désactivé) ---
# Pas de portes ('+') générées dans le labyrinthe pour le moment.

# --- Convertir en liste de strings ---
layout = ["".join(row) for row in grid]

start_room = sorted_rooms[0]
start_x, start_y = center(start_room)

exit_room = sorted_rooms[-1]
exit_x, exit_y = center(exit_room)

room_centers = [{"X": center(r)[0], "Y": center(r)[1]} for r in sorted_rooms]

level_data = {
    "Name": "La Maison Qui Rend Fou - Étage 1",
    "Width": WIDTH,
    "Height": HEIGHT,
    "Layout": layout,
    "StartPosition": {"X": start_x, "Y": start_y},
    "ExitPosition": {"X": exit_x, "Y": exit_y},
    "RoomCenters": room_centers
}

output_path = r'D:\Documents perso\0000Site internet\DEV\C-Sharp\011.Roguelike\Data\Levels\level01.json'
with open(output_path, 'w', encoding='utf-8') as f:
    json.dump(level_data, f, indent=2, ensure_ascii=False)

print("Carte propre générée !")
