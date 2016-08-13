namespace KeySender
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.add = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.list = new System.Windows.Forms.ListBox();
            this.NameL = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.message = new System.Windows.Forms.RichTextBox();
            this.MessageL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.interval = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.shortcutKey = new System.Windows.Forms.TextBox();
            this.ctr = new System.Windows.Forms.CheckBox();
            this.alt = new System.Windows.Forms.CheckBox();
            this.shift = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ready = new System.Windows.Forms.CheckBox();
            this.writer = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(951, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(115, 345);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(136, 74);
            this.add.TabIndex = 1;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // delete
            // 
            this.delete.Enabled = false;
            this.delete.Location = new System.Drawing.Point(438, 345);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(148, 74);
            this.delete.TabIndex = 2;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // list
            // 
            this.list.FormattingEnabled = true;
            this.list.HorizontalScrollbar = true;
            this.list.ItemHeight = 16;
            this.list.Location = new System.Drawing.Point(723, 31);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(216, 388);
            this.list.TabIndex = 3;
            this.list.SelectedValueChanged += new System.EventHandler(this.list_SelectedValueChanged);
            // 
            // NameL
            // 
            this.NameL.AutoSize = true;
            this.NameL.Location = new System.Drawing.Point(23, 49);
            this.NameL.Name = "NameL";
            this.NameL.Size = new System.Drawing.Size(45, 17);
            this.NameL.TabIndex = 4;
            this.NameL.Text = "Name";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(136, 44);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(174, 22);
            this.name.TabIndex = 5;
            this.name.TextChanged += new System.EventHandler(this.name_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // message
            // 
            this.message.Location = new System.Drawing.Point(26, 150);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(348, 142);
            this.message.TabIndex = 6;
            this.message.Text = "";
            this.message.TextChanged += new System.EventHandler(this.message_TextChanged);
            // 
            // MessageL
            // 
            this.MessageL.AutoSize = true;
            this.MessageL.Location = new System.Drawing.Point(23, 130);
            this.MessageL.Name = "MessageL";
            this.MessageL.Size = new System.Drawing.Size(65, 17);
            this.MessageL.TabIndex = 7;
            this.MessageL.Text = "Message";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Interval";
            // 
            // interval
            // 
            this.interval.Location = new System.Drawing.Point(136, 72);
            this.interval.MaxLength = 5;
            this.interval.Name = "interval";
            this.interval.Size = new System.Drawing.Size(100, 22);
            this.interval.TabIndex = 9;
            this.interval.TextChanged += new System.EventHandler(this.interval_TextChanged);
            this.interval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.interval_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Shortcut key";
            // 
            // shortcutKey
            // 
            this.shortcutKey.Location = new System.Drawing.Point(136, 100);
            this.shortcutKey.Name = "shortcutKey";
            this.shortcutKey.Size = new System.Drawing.Size(100, 22);
            this.shortcutKey.TabIndex = 11;
            this.shortcutKey.TextChanged += new System.EventHandler(this.shortcutKey_TextChanged);
            this.shortcutKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.shortcutKey_KeyDown);
            this.shortcutKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.shortcutKey_KeyPress);
            // 
            // ctr
            // 
            this.ctr.AutoSize = true;
            this.ctr.Location = new System.Drawing.Point(290, 100);
            this.ctr.Name = "ctr";
            this.ctr.Size = new System.Drawing.Size(48, 21);
            this.ctr.TabIndex = 12;
            this.ctr.Text = "Ctr";
            this.ctr.UseVisualStyleBackColor = true;
            this.ctr.CheckedChanged += new System.EventHandler(this.shortcutkey_CheckedChanged);
            // 
            // alt
            // 
            this.alt.AutoSize = true;
            this.alt.Location = new System.Drawing.Point(242, 102);
            this.alt.Name = "alt";
            this.alt.Size = new System.Drawing.Size(46, 21);
            this.alt.TabIndex = 13;
            this.alt.Text = "Alt";
            this.alt.UseVisualStyleBackColor = true;
            this.alt.CheckedChanged += new System.EventHandler(this.shortcutkey_CheckedChanged);
            // 
            // shift
            // 
            this.shift.AutoSize = true;
            this.shift.Location = new System.Drawing.Point(344, 100);
            this.shift.Name = "shift";
            this.shift.Size = new System.Drawing.Size(58, 21);
            this.shift.TabIndex = 14;
            this.shift.Text = "Shift";
            this.shift.UseVisualStyleBackColor = true;
            this.shift.CheckedChanged += new System.EventHandler(this.shortcutkey_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ready);
            this.panel1.Controls.Add(this.name);
            this.panel1.Controls.Add(this.message);
            this.panel1.Controls.Add(this.MessageL);
            this.panel1.Controls.Add(this.ctr);
            this.panel1.Controls.Add(this.alt);
            this.panel1.Controls.Add(this.shift);
            this.panel1.Controls.Add(this.NameL);
            this.panel1.Controls.Add(this.interval);
            this.panel1.Controls.Add(this.shortcutKey);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(27, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 308);
            this.panel1.TabIndex = 15;
            // 
            // ready
            // 
            this.ready.AutoSize = true;
            this.ready.Enabled = false;
            this.ready.Location = new System.Drawing.Point(411, 271);
            this.ready.Name = "ready";
            this.ready.Size = new System.Drawing.Size(80, 21);
            this.ready.TabIndex = 15;
            this.ready.Text = "is ready";
            this.ready.UseVisualStyleBackColor = true;
            this.ready.CheckedChanged += new System.EventHandler(this.shortcutkey_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 434);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.list);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.add);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "KeySender";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.ListBox list;
        private System.Windows.Forms.Label NameL;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox message;
        private System.Windows.Forms.Label MessageL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox interval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox shortcutKey;
        private System.Windows.Forms.CheckBox ctr;
        private System.Windows.Forms.CheckBox alt;
        private System.Windows.Forms.CheckBox shift;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker writer;
        private System.Windows.Forms.CheckBox ready;
    }
}

