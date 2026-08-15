using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Roguelike.UI
{
    public static class WindowManager
    {
        // Importation des APIs Windows (Win32) pour manipuler la position de la fenêtre
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private static readonly IntPtr HWND_TOP = IntPtr.Zero;
        private const uint SWP_SHOWWINDOW = 0x0040;

        public static void InitializeConsole(string mode)
        {
            IntPtr handle = GetConsoleWindow();

            // Résolution cible : 1920x1080
            // On utilise 1040 pour la hauteur afin de laisser de la place à la barre des tâches Windows
            int screenWidth = 1920;
            int screenHeight = 1040; 
            int windowWidth = screenWidth / 2;
            int windowHeight = screenHeight;

            if (mode == "map")
            {
                Console.Title = "The Legend of Kevin - CARTE (Principal)";
                // Position : gauche (0, 0), taille : moitié de l'écran
                SetWindowPos(handle, HWND_TOP, 0, 0, windowWidth, windowHeight, SWP_SHOWWINDOW);
            }
            else if (mode == "ui")
            {
                Console.Title = "The Legend of Kevin - INTERFACE (Secondaire)";
                // Position : droite (moitié de l'écran, 0), taille : moitié de l'écran
                SetWindowPos(handle, HWND_TOP, windowWidth, 0, windowWidth, windowHeight, SWP_SHOWWINDOW);
            }

            // Léger délai pour laisser le temps à l'OS de redimensionner la fenêtre 
            // avant que les autres classes n'essaient de lire Console.WindowWidth
            Thread.Sleep(100);
        }
    }
}
