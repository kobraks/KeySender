using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace KeySender
{
    class KeyListener
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private LowLevelKeyboardProc _proc;
        private static IntPtr _hookID = IntPtr.Zero;
        static Keys _hookedKey;
        public Keys HookedKey
        {
            get
            {
                return _hookedKey;
            }
            private set
            {
                _hookedKey = value;
                if (_hookedKey == Keys.Alt) Alt = true;
                else Alt = false;
                if (_hookedKey == Keys.RControlKey || _hookedKey == Keys.LControlKey) Ctr = true;
                else Ctr = false;
                if (_hookedKey == Keys.Shift) Shift = true;
                else Shift = false;
                if (KeyPressed != null) KeyPressed(_hookedKey);
            }
        }

        public bool Shift
        {
            get;
            set;
        }

        public bool Alt
        {
            get;
            set;
        }

        public bool Ctr
        {
            get;
            set;
        }

        public delegate void KeyPressedEvent(Keys key);
        public event KeyPressedEvent KeyPressed;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                Keys key = (Keys)Marshal.ReadInt32(lParam);

                Debug.WriteLine(key.ToString());
                HookedKey = key;
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        public KeyListener()
        {
            _proc = HookCallback;
            _hookID = SetHook(_proc);
        }

        public void Realise()
        {
            UnhookWindowsHookEx(_hookID);
        }
    }
}
