using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;

namespace KeySender
{
    public partial class Form1 : Form
    {
        #region keylogger
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private LowLevelKeyboardProc _proc;
        private static IntPtr _hookID = IntPtr.Zero;
        static Keys _hookedKey;
        Keys HookedKey
        {
            get
            {
                return _hookedKey;
            }
            set
            {
                _hookedKey = value;
                if (KeyPressed != null) KeyPressed(_hookedKey);
            }
        }

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
        #endregion

        const int MAXITEMS = 49;
        Core.Shortcuts shortcuts = new Core.Shortcuts();
        Core.Shortcut shortcut = null;
        Core.Shortcut sendShortcut = null;
        int indexName = -1;
        int index = -1;
        bool adding = false;
        bool deleting = false;
        bool editing = false;

        public delegate void KeyPressedEvent(Keys key);
        public event KeyPressedEvent KeyPressed;

        public Form1()
        {
            InitializeComponent();
            _proc = HookCallback;
            _hookID = SetHook(_proc);

            this.KeyPressed += this.OnKeyPressed;
        }

        public Form1(String[] args)
        {
            InitializeComponent();
            _proc = HookCallback;
            _hookID = SetHook(_proc);

            if (args.Length != 0)
            {
                try
                {
                    shortcuts.Load(args[0]);
                }
                catch(Exception)
                {
                      MessageBox.Show("Unable to load file: " + args[0], "Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.KeyPressed += this.OnKeyPressed;

        }

        private void add_Click(object sender, EventArgs e)
        {
            if (index > MAXITEMS) return;

            adding = true;
            indexName++;

            if (index > 0)
            {
                if (index < list.Items.Count - 1)
                {
                    index = list.Items.Count;
                    list.SetSelected(index - 1, true);
                }
                else
                    index++;
            }
            else
                index++;
            Debug.WriteLine(index);

            shortcut = new Core.Shortcut();
            shortcut.Name += indexName.ToString();

            shortcuts.Add(shortcut);

            this.delete.Enabled = true;
            this.panel1.Enabled = true;
            this.saveToolStripMenuItem.Enabled = true;
            ready.Enabled = false;
            this.list.Items.Insert(index, shortcut.Name);
            LoadValues(index);
            this.list.ClearSelected();
            this.list.SetSelected(index, true);
            adding = false;
        }

        private void LoadValues(int index)
        {
            editing = true;
            shortcut = shortcuts.Get(index);
            if (shortcut == null)
            {
                shortcut = new Core.Shortcut();
                shortcuts.Add(shortcut);
            }

            this.alt.Checked = shortcut.Alt;
            this.shift.Checked = shortcut.Shift;
            this.ctr.Checked = shortcut.Ctr;
            this.ready.Checked = shortcut.Ready;

            if (string.IsNullOrEmpty(shortcut.ShortcutKey))
                ready.Enabled = false;

            this.message.Text = shortcut.Message;
            this.name.Text = shortcut.Name;
            this.interval.Text = shortcut.Interval.ToString();
            this.shortcutKey.Text = shortcut.ShortcutKey;

            editing = false;
        }

        private void CleanCheckBoxes()
        {
            alt.Checked = false;
            shift.Checked = false;
            ctr.Checked = false;
            ready.Checked = false;
        }

        private void CleanValues()
        {
            editing = true;
            this.name.Text = "";
            this.message.Text = "";
            this.interval.Text = "";
            this.shortcutKey.Text = "";

            CleanCheckBoxes();
            editing = false;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            deleting = true;
            this.list.Items.RemoveAt(index);
            shortcuts.Remove(index);
            shortcut = null;
            index--;
            if (index < 0 && list.Items.Count == 0)
            {
                CleanValues();
                panel1.Enabled = false;
                delete.Enabled = false;
                this.saveToolStripMenuItem.Enabled = false;
                deleting = false;

                return;
            }
            else if (index < 0 && list.Items.Count > 0)
                list.SetSelected(++index, true);
            else
                list.SetSelected(index, true);

            LoadValues(index);

            deleting = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resoult = openFileDialog1.ShowDialog();
            
            if (resoult == DialogResult.OK)
            {
                Debug.WriteLine(openFileDialog1.FileName);

                try
                {
                    list.Items.Clear();
                    shortcuts.Clear();
                    shortcuts.Load(openFileDialog1.FileName);
                    for (int i = 0; i < shortcuts.Count; i++)
                    {
                        list.Items.Add(shortcuts.Get(i).Name);
                    }
                    this.delete.Enabled = true;
                    this.panel1.Enabled = true;
                    this.saveToolStripMenuItem.Enabled = true;
                    index = 0;
                    LoadValues(index);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resoult = saveFileDialog1.ShowDialog();

            Debug.WriteLine(resoult.ToString());
            Debug.WriteLine(saveFileDialog1.FileName);


            if (resoult == DialogResult.OK)
            {
                shortcuts.Save(saveFileDialog1.FileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void shortcutkey_CheckedChanged(object sender, EventArgs e)
        {
            if (!editing)
            {
                shortcut.Alt = alt.Checked;
                shortcut.Ctr = ctr.Checked;
                shortcut.Shift = shift.Checked;
                shortcut.Ready = ready.Checked;
                shortcuts.Change(index, shortcut);
            }
        }

        private void list_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!adding && !deleting && !editing)
            {
                index = list.SelectedIndex;
                LoadValues(index);
            }
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            if(!deleting && !editing)
            {
                editing = true;

                shortcut.Name = name.Text;
                list.Items[index] = name.Text;

                shortcuts.Change(index, shortcut);
                editing = false;
            }
        }

        private void interval_TextChanged(object sender, EventArgs e)
        {
            if (!deleting && !editing)
            {
                shortcut.Interval = int.Parse(interval.Text);
                shortcuts.Change(index, shortcut);

            }
        }

        private void message_TextChanged(object sender, EventArgs e)
        {
            if (!deleting && !editing)
            {
                shortcut.Message = message.Text;
                shortcuts.Change(index, shortcut);
            }
        }

        private void interval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = false;
            }
            else e.Handled = true;
        }

        private void shortcutKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            ((TextBox)sender).Text = HookedKey.ToString();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            UnhookWindowsHookEx(_hookID);
        }

        void OnKeyPressed(Keys key)
        {
            for(int i = 0; i < shortcuts.Count; i++)
            {
                if (shortcuts.Get(i).ShortcutKey == key.ToString())
                {
                    if (shortcuts.Get(i).Ready)
                    {
                        Thread.Sleep(1000);
                        sendShortcut = shortcuts.Get(i);
                        sendShortcut.Send();
                        sendShortcut = null;
                    }
                }
            }
        }

        private void shortcutKey_TextChanged(object sender, EventArgs e)
        {
            if (!deleting)
            {
                shortcut.ShortcutKey = shortcutKey.Text;

                shortcuts.Change(index, shortcut);
                ready.Enabled = true;
            }
        }
    }
}
