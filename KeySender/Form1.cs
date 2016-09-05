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
        #region variables
        const int MAXITEMS = 50;
        KeyListener keylistener = new KeyListener();
        Core.Shortcuts shortcuts = new Core.Shortcuts();
        int Index { get; set; }
        int IndexName { get; set; }
        Core.Shortcut shortcut = null;
        bool editing = false, opened = false;
        string fileName;
        #endregion

        public Form1()
        {
            Initialize();
        }

        public Form1(string[] arg)
        {
            Initialize();
            if (arg.Length > 0) Open(arg[0]);
        }

        void Initialize()
        {
            InitializeComponent();
            keylistener.KeyPressed += OnKeyPressed;
            Index = -1;
            IndexName = -1;
        }

        void Open(string file)
        {
            try
            {
                list.Items.Clear();
                shortcuts.Clear();

                if (!shortcuts.Load(file))
                    throw new Exception();
                else
                {
                    fileName = file;

                    for (int i = 0; i < shortcuts.Count; i++)
                    {
                        list.Items.Add(shortcuts.Get(i).Name);
                    }

                    this.delete.Enabled = true;
                    this.panel1.Enabled = true;
                    this.saveToolStripMenuItem.Enabled = true;
                    this.deleteToolStripMenuItem1.Enabled = true;
                    Index = 0;
                    LoadValues(Index);
                    opened = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unable to read file \n" + file + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        void OnKeyPressed(Keys key)
        {
            if (keylistener.Alt || keylistener.Ctr || keylistener.Shift)
            {
                return;
            }

            for (int i = 0; i < shortcuts.Count; i++)
            {
                if (shortcuts.Get(i).ShortcutKey == key.ToString())
                {
                    if (shortcuts.Get(i).Ready)
                    {
                        Core.Shortcut sendShortcut = null;
                        Thread.Sleep(1000);
                        sendShortcut = shortcuts.Get(i);
                        sendShortcut.Send();
                        sendShortcut = null;
                    }
                }
            }
        }

        private void list_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!editing)
            {
                Index = list.SelectedIndex;
                LoadValues(Index);
            }
        }

        void CleanValues()
        {
            if (!editing)
                editing = true;

            message.Text = "";
            interval.Text = "";
            name.Text = "";
            shortcutKey.Text = "";

            ctr.Checked = false;
            shift.Checked = false;
            alt.Checked = false;

            editing = false;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (editing) return;
            editing = true;
            list.Items.RemoveAt(Index);
            shortcuts.Remove(Index);
            shortcut = null;
            Index--;
            Accept.Enabled = false;

            if (Index < 0 && list.Items.Count == 0)
            {
                CleanValues();
                panel1.Enabled = false;
                delete.Enabled = false;
                this.saveToolStripMenuItem.Enabled = false;
                editing = false;
                deleteToolStripMenuItem1.Enabled = false;

                return;
            }
            else if (Index < 0 && list.Items.Count > 0)
                list.SetSelected(++Index, true);
            else
                list.SetSelected(Index, true);

            editing = false;
            LoadValues(Index);
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (list.Items.Count < MAXITEMS)
            {
                editing = true;
                IndexName++;

                if (Index > 0)
                {
                    if (Index < list.Items.Count)
                    {
                        Index = list.Items.Count;
                        list.SetSelected(Index - 1, true);
                    }
                    else Index++;
                }
                else Index++;

                shortcut = new Core.Shortcut();
                shortcut.Name += IndexName.ToString();

                shortcuts.Add(shortcut);
                delete.Enabled = true;
                panel1.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem1.Enabled = true;
                Accept.Enabled = false;
                list.Items.Insert(Index, shortcut.Name);
                list.SetSelected(Index, true);
                editing = false;

                LoadValues(Index);
            }
        }

        void LoadValues(int index)
        {
            if (editing) return;
            editing = true;
            shortcut = shortcuts.Get(index);
            if (shortcut == null)
                return;

            this.alt.Checked = shortcut.Alt;
            this.shift.Checked = shortcut.Shift;
            this.ctr.Checked = shortcut.Ctr;

            if (string.IsNullOrEmpty(shortcut.ShortcutKey))
            {
                Accept.Enabled = false;
                readyIconControl1.IsReady = false;
            }
            else
            {
                Accept.Enabled = true;
                readyIconControl1.IsReady = shortcut.Ready;
            }

            this.message.Text = shortcut.Message;
            this.name.Text = shortcut.Name;
            this.interval.Text = shortcut.Interval.ToString();
            this.shortcutKey.Text = shortcut.ShortcutKey;

            editing = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            keylistener.Realise();
            keylistener = null;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxClick(object sender, EventArgs e)
        {
            shortcut.Alt = alt.Checked;
            shortcut.Ctr = ctr.Checked;
            shortcut.Shift = shift.Checked;

            shortcuts.Change(Index, shortcut);
        }

        private void message_TextChanged(object sender, EventArgs e)
        {
            if (editing) return;

            shortcut.Message = message.Text;
            shortcuts.Change(Index, shortcut);
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            if (editing) return;

            shortcut.Name = name.Name;
            shortcuts.Change(Index, shortcut);
        }

        private void interval_TextChanged(object sender, EventArgs e)
        {
            if (editing) return;

            shortcut.Interval = int.Parse(interval.Text);
            shortcuts.Change(Index, shortcut);
        }

        private void interval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void shortcutKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            ((TextBox)sender).Text = keylistener.HookedKey.ToString();
        }

        private void shortcutKey_TextChanged(object sender, EventArgs e)
        {
            if (editing) return;

            shortcut.ShortcutKey = shortcutKey.Text;

            shortcuts.Change(Index, shortcut);
            Accept.Enabled = true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resoult = openFileDialog1.ShowDialog();

            if (resoult == DialogResult.OK)
            {
                Open(openFileDialog1.FileName);
            }
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            if (shortcut != null)
            {
                shortcut.Ready = true;
                readyIconControl1.IsReady = true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (opened)
            {
                try
                {
                    if (!shortcuts.Save(fileName))
                        throw new Exception();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to save file \n" + fileName + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else SaveAs();
        }

        private void saveAsTSMI_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        void SaveAs()
        {
            var resoult = saveFileDialog1.ShowDialog();
            if (resoult == DialogResult.OK)
            {
                try
                {
                    if (!shortcuts.Save(saveFileDialog1.FileName))
                        throw new Exception();

                    fileName = saveFileDialog1.FileName;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Unable to save file \n" + fileName + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }
    }
}
