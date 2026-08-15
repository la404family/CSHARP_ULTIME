using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Roguelike.Engine
{
    public enum Direction
    {
        None,
        Up,
        Down,
        Left,
        Right,
        Interact
    }

    public static class InputHandler
    {
        // XInput (Xbox, Xbox-compatible)
        [DllImport("xinput9_1_0.dll")]
        private static extern int XInputGetState(int dwUserIndex, out XINPUT_STATE pState);

        // WinMM (manettes génériques : Switch Pro, PS4/PS5 via pilote générique, etc.)
        [DllImport("winmm.dll")]
        private static extern int joyGetPosEx(int uJoyID, ref JOYINFOEX pji);

        [StructLayout(LayoutKind.Sequential)]
        private struct JOYINFOEX
        {
            public int dwSize;
            public int dwFlags;
            public int dwXpos;
            public int dwYpos;
            public int dwZpos;
            public int dwRpos;
            public int dwUpos;
            public int dwVpos;
            public int dwButtons;
            public int dwButtonNumber;
            public int dwPOV;
            public int dwReserved1;
            public int dwReserved2;
        }

        private const int JOY_RETURNX       = 0x00000001;
        private const int JOY_RETURNY       = 0x00000002;
        private const int JOY_RETURNPOV     = 0x00000040;
        private const int JOY_RETURNBUTTONS = 0x00000080;
        private const int JOY_RETURNALL     = (JOY_RETURNX | JOY_RETURNY | JOY_RETURNPOV | JOY_RETURNBUTTONS);

        private const int JOY_POVFORWARD  = 0;
        private const int JOY_POVRIGHT    = 9000;
        private const int JOY_POVBACKWARD = 18000;
        private const int JOY_POVLEFT     = 27000;
        private const int JOY_POVNEUTRAL  = 65535;

        [StructLayout(LayoutKind.Sequential)]
        private struct XINPUT_STATE
        {
            public uint dwPacketNumber;
            public XINPUT_GAMEPAD Gamepad;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct XINPUT_GAMEPAD
        {
            public ushort wButtons;
            public byte   bLeftTrigger;
            public byte   bRightTrigger;
            public short  sThumbLX;
            public short  sThumbLY;
            public short  sThumbRX;
            public short  sThumbRY;
        }

        // Boutons XInput
        private const ushort XINPUT_DPAD_UP    = 0x0001;
        private const ushort XINPUT_DPAD_DOWN   = 0x0002;
        private const ushort XINPUT_DPAD_LEFT   = 0x0004;
        private const ushort XINPUT_DPAD_RIGHT  = 0x0008;
        private const ushort XINPUT_BTN_A       = 0x1000;
        private const ushort XINPUT_BTN_B       = 0x2000;
        private const ushort XINPUT_BTN_X       = 0x4000;
        private const ushort XINPUT_BTN_Y       = 0x8000;
        private const ushort XINPUT_BTN_START   = 0x0010;

        // --- Seuil de la zone morte du stick analogique ---
        // 32767 = valeur max. 8000 = ~24% → ignore les micro-dérives du stick au repos.
        // 20000 = ~61% → déclenche une direction. Ajuster ici si trop sensible/pas assez.
        private const short STICK_DEADZONE  = 8000;
        private const short STICK_THRESHOLD = 20000;

        // --- Timing du repeat ---
        // InitialDelay : temps avant que le maintien continu commence à répéter (ms)
        // RepeatInterval : délai entre chaque répétition pendant le maintien (ms)
        private const long InitialDelayMs  = 200;
        private const long RepeatIntervalMs = 100;

        // --- État interne ---
        private static readonly Stopwatch _sw = Stopwatch.StartNew();
        private static Direction _lastDir      = Direction.None;
        private static long      _pressStartMs  = 0;   // quand la direction a commencé
        private static long      _lastRepeatMs  = 0;   // dernière répétition émise

        // --- Cache API ---
        private enum GamepadApi { Unknown, XInput, WinMM, None }
        private static GamepadApi _api               = GamepadApi.Unknown;
        private static long       _lastDetectAttempt = -99999;
        private const  long       DetectRetryMs      = 3000;

        // --- Cache paquet XInput ---
        private static uint _lastXInputPacket = uint.MaxValue;

        public static Direction GetInput()
        {
            // ── Clavier (priorité absolue, zéro P/Invoke) ──────────────────────
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey(true);
                while (Console.KeyAvailable) Console.ReadKey(true); // vider le buffer

                Direction kDir = keyInfo.Key switch
                {
                    ConsoleKey.Z or ConsoleKey.UpArrow    => Direction.Up,
                    ConsoleKey.S or ConsoleKey.DownArrow  => Direction.Down,
                    ConsoleKey.Q or ConsoleKey.LeftArrow  => Direction.Left,
                    ConsoleKey.D or ConsoleKey.RightArrow => Direction.Right,
                    ConsoleKey.E or ConsoleKey.Spacebar   => Direction.Interact,
                    ConsoleKey.Enter                      => Direction.Interact,
                    _ => Direction.None
                };

                if (kDir != Direction.None)
                {
                    // Réinitialise l'état manette pour ne pas interférer
                    _lastDir = Direction.None;
                    return kDir;
                }
            }

            // ── Manette ─────────────────────────────────────────────────────────
            try
            {
                long nowMs = _sw.ElapsedMilliseconds;

                // Détection / re-détection périodique
                if (_api == GamepadApi.Unknown || _api == GamepadApi.None)
                {
                    if (nowMs - _lastDetectAttempt < DetectRetryMs)
                        return Direction.None;

                    _lastDetectAttempt = nowMs;
                    _api = DetectApi();

                    if (_api == GamepadApi.None)
                        return Direction.None;

                    // Reset du cache paquet pour la nouvelle manette
                    _lastXInputPacket = uint.MaxValue;
                }

                Direction rawDir = _api == GamepadApi.XInput
                    ? PollXInput()
                    : PollWinMM();

                return ApplyRepeat(rawDir, nowMs);
            }
            catch
            {
                _api = GamepadApi.None;
                return Direction.None;
            }
        }

        // ── Détection de l'API disponible ────────────────────────────────────────
        private static GamepadApi DetectApi()
        {
            try
            {
                if (XInputGetState(0, out _) == 0)
                    return GamepadApi.XInput;
            }
            catch { }

            try
            {
                JOYINFOEX ji = new() { dwSize = Marshal.SizeOf<JOYINFOEX>(), dwFlags = JOY_RETURNALL };
                if (joyGetPosEx(0, ref ji) == 0)
                    return GamepadApi.WinMM;
            }
            catch { }

            return GamepadApi.None;
        }

        // ── Polling XInput ───────────────────────────────────────────────────────
        private static Direction PollXInput()
        {
            int hr = XInputGetState(0, out XINPUT_STATE state);
            if (hr != 0)
            {
                _api = GamepadApi.Unknown;
                _lastXInputPacket = uint.MaxValue;
                return Direction.None;
            }

            // Court-circuit : rien n'a changé ET on n'était pas en train d'appuyer
            if (state.dwPacketNumber == _lastXInputPacket && _lastDir == Direction.None)
                return Direction.None;

            _lastXInputPacket = state.dwPacketNumber;

            // D-Pad
            if ((state.Gamepad.wButtons & XINPUT_DPAD_UP)   != 0) return Direction.Up;
            if ((state.Gamepad.wButtons & XINPUT_DPAD_DOWN)  != 0) return Direction.Down;
            if ((state.Gamepad.wButtons & XINPUT_DPAD_LEFT)  != 0) return Direction.Left;
            if ((state.Gamepad.wButtons & XINPUT_DPAD_RIGHT) != 0) return Direction.Right;

            // Boutons d'interaction (A, B, X, Y, Start)
            if ((state.Gamepad.wButtons & (XINPUT_BTN_A | XINPUT_BTN_B | XINPUT_BTN_X | XINPUT_BTN_Y | XINPUT_BTN_START)) != 0)
                return Direction.Interact;

            // Stick analogique gauche avec zone morte
            short lx = state.Gamepad.sThumbLX;
            short ly = state.Gamepad.sThumbLY;

            // Appliquer zone morte
            if (Math.Abs(lx) < STICK_DEADZONE) lx = 0;
            if (Math.Abs(ly) < STICK_DEADZONE) ly = 0;

            // Axe dominant (évite les diagonales accidentelles)
            if (Math.Abs(ly) >= Math.Abs(lx))
            {
                if (ly >  STICK_THRESHOLD) return Direction.Up;
                if (ly < -STICK_THRESHOLD) return Direction.Down;
            }
            else
            {
                if (lx >  STICK_THRESHOLD) return Direction.Right;
                if (lx < -STICK_THRESHOLD) return Direction.Left;
            }

            return Direction.None;
        }

        // ── Polling WinMM (Switch Pro / PS / générique) ──────────────────────────
        private static Direction PollWinMM()
        {
            JOYINFOEX ji = new()
            {
                dwSize  = Marshal.SizeOf<JOYINFOEX>(),
                dwFlags = JOY_RETURNALL
            };

            if (joyGetPosEx(0, ref ji) != 0)
            {
                _api = GamepadApi.Unknown;
                return Direction.None;
            }

            // D-Pad (POV Hat)
            if (ji.dwPOV != JOY_POVNEUTRAL)
            {
                if (ji.dwPOV == JOY_POVFORWARD)  return Direction.Up;
                if (ji.dwPOV == JOY_POVRIGHT)    return Direction.Right;
                if (ji.dwPOV == JOY_POVBACKWARD) return Direction.Down;
                if (ji.dwPOV == JOY_POVLEFT)     return Direction.Left;
            }

            // Stick analogique gauche (0 à 65535, centre = 32767)
            const int WMM_CENTER     = 32767;
            const int WMM_THRESHOLD  = 12000; // ~37% d'écart par rapport au centre
            const int WMM_DEADZONE   = 3000;  // ~9% de zone morte

            int dx = ji.dwXpos - WMM_CENTER;
            int dy = ji.dwYpos - WMM_CENTER;

            if (Math.Abs(dx) < WMM_DEADZONE) dx = 0;
            if (Math.Abs(dy) < WMM_DEADZONE) dy = 0;

            // Axe dominant
            if (Math.Abs(dy) >= Math.Abs(dx))
            {
                if (dy < -WMM_THRESHOLD) return Direction.Up;
                if (dy >  WMM_THRESHOLD) return Direction.Down;
            }
            else
            {
                if (dx >  WMM_THRESHOLD) return Direction.Right;
                if (dx < -WMM_THRESHOLD) return Direction.Left;
            }

            // Boutons (n'importe lequel = Interact)
            if (ji.dwButtons != 0) return Direction.Interact;

            return Direction.None;
        }

        // ── Gestion du repeat avec délai initial + intervalle ────────────────────
        //
        // Comportement attendu :
        //   • Appui → mouvement IMMÉDIAT
        //   • Maintien → pause InitialDelayMs → répétitions toutes les RepeatIntervalMs
        //   • Relâché → stop
        //
        private static Direction ApplyRepeat(Direction rawDir, long nowMs)
        {
            if (rawDir == Direction.None)
            {
                // Stick/bouton relâché
                _lastDir = Direction.None;
                return Direction.None;
            }

            if (rawDir != _lastDir)
            {
                // Nouvelle direction → mouvement immédiat
                _lastDir      = rawDir;
                _pressStartMs = nowMs;
                _lastRepeatMs = nowMs;
                return rawDir;
            }

            // Même direction maintenue
            long heldMs = nowMs - _pressStartMs;

            if (heldMs >= InitialDelayMs)
            {
                // Phase de répétition
                if (nowMs - _lastRepeatMs >= RepeatIntervalMs)
                {
                    _lastRepeatMs = nowMs;
                    return rawDir;
                }
            }

            return Direction.None;
        }
    }
}
