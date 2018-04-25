namespace Connect4
{
    partial class Connect4
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
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RED_PIECE_COUNT = new System.Windows.Forms.Label();
            this.RED_CONSOLE_CHECKBOX = new System.Windows.Forms.CheckBox();
            this.RED_CURRENT_STATE_LABEL = new System.Windows.Forms.Label();
            this.RED_COMPUTER_BUTTON = new System.Windows.Forms.Button();
            this.RED_HUMAN_BUTTON = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BLACK_PIECES_COUNT = new System.Windows.Forms.Label();
            this.BLACK_CONSOLE_CHECKBOX = new System.Windows.Forms.CheckBox();
            this.BLACK_CURRENT_STATE_LABEL = new System.Windows.Forms.Label();
            this.BLACK_COMPUTER_BUTTON = new System.Windows.Forms.Button();
            this.BLACK_HUMAN_BUTTON = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.RESET_BUTTON = new System.Windows.Forms.Button();
            this.START_BUTTON = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CURRENT_TURN_PICTURE_BOX = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GameGrid = new System.Windows.Forms.DataGridView();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CURRENT_TURN_PICTURE_BOX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1501, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1,
            this.toolStripComboBox2});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "5x5",
            "11x11",
            "13x13"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 28);
            this.toolStripComboBox1.Text = "Board Size";
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GameGrid);
            this.splitContainer1.Size = new System.Drawing.Size(1501, 750);
            this.splitContainer1.SplitterDistance = 523;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(523, 750);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.RED_PIECE_COUNT);
            this.panel1.Controls.Add(this.RED_CONSOLE_CHECKBOX);
            this.panel1.Controls.Add(this.RED_CURRENT_STATE_LABEL);
            this.panel1.Controls.Add(this.RED_COMPUTER_BUTTON);
            this.panel1.Controls.Add(this.RED_HUMAN_BUTTON);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 244);
            this.panel1.TabIndex = 0;
            // 
            // RED_PIECE_COUNT
            // 
            this.RED_PIECE_COUNT.AutoSize = true;
            this.RED_PIECE_COUNT.Location = new System.Drawing.Point(9, 149);
            this.RED_PIECE_COUNT.Name = "RED_PIECE_COUNT";
            this.RED_PIECE_COUNT.Size = new System.Drawing.Size(66, 17);
            this.RED_PIECE_COUNT.TabIndex = 5;
            this.RED_PIECE_COUNT.Text = "Pieces: 0";
            // 
            // RED_CONSOLE_CHECKBOX
            // 
            this.RED_CONSOLE_CHECKBOX.AutoSize = true;
            this.RED_CONSOLE_CHECKBOX.Location = new System.Drawing.Point(12, 111);
            this.RED_CONSOLE_CHECKBOX.Name = "RED_CONSOLE_CHECKBOX";
            this.RED_CONSOLE_CHECKBOX.Size = new System.Drawing.Size(212, 21);
            this.RED_CONSOLE_CHECKBOX.TabIndex = 4;
            this.RED_CONSOLE_CHECKBOX.Text = "Show Red\'s Console Window";
            this.RED_CONSOLE_CHECKBOX.UseVisualStyleBackColor = true;
            // 
            // RED_CURRENT_STATE_LABEL
            // 
            this.RED_CURRENT_STATE_LABEL.AutoSize = true;
            this.RED_CURRENT_STATE_LABEL.Location = new System.Drawing.Point(9, 79);
            this.RED_CURRENT_STATE_LABEL.Name = "RED_CURRENT_STATE_LABEL";
            this.RED_CURRENT_STATE_LABEL.Size = new System.Drawing.Size(63, 17);
            this.RED_CURRENT_STATE_LABEL.TabIndex = 3;
            this.RED_CURRENT_STATE_LABEL.Text = "Current: ";
            this.RED_CURRENT_STATE_LABEL.Click += new System.EventHandler(this.label4_Click);
            // 
            // RED_COMPUTER_BUTTON
            // 
            this.RED_COMPUTER_BUTTON.Location = new System.Drawing.Point(303, 33);
            this.RED_COMPUTER_BUTTON.Name = "RED_COMPUTER_BUTTON";
            this.RED_COMPUTER_BUTTON.Size = new System.Drawing.Size(112, 38);
            this.RED_COMPUTER_BUTTON.TabIndex = 2;
            this.RED_COMPUTER_BUTTON.Text = "Computer...";
            this.RED_COMPUTER_BUTTON.UseVisualStyleBackColor = true;
            this.RED_COMPUTER_BUTTON.Click += new System.EventHandler(this.RED_COMPUTER_BUTTON_Click);
            // 
            // RED_HUMAN_BUTTON
            // 
            this.RED_HUMAN_BUTTON.Location = new System.Drawing.Point(37, 33);
            this.RED_HUMAN_BUTTON.Name = "RED_HUMAN_BUTTON";
            this.RED_HUMAN_BUTTON.Size = new System.Drawing.Size(95, 38);
            this.RED_HUMAN_BUTTON.TabIndex = 1;
            this.RED_HUMAN_BUTTON.Text = "Human ";
            this.RED_HUMAN_BUTTON.UseVisualStyleBackColor = true;
            this.RED_HUMAN_BUTTON.Click += new System.EventHandler(this.RED_HUMAN_BUTTON_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Red";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.BLACK_PIECES_COUNT);
            this.panel2.Controls.Add(this.BLACK_CONSOLE_CHECKBOX);
            this.panel2.Controls.Add(this.BLACK_CURRENT_STATE_LABEL);
            this.panel2.Controls.Add(this.BLACK_COMPUTER_BUTTON);
            this.panel2.Controls.Add(this.BLACK_HUMAN_BUTTON);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 253);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(517, 244);
            this.panel2.TabIndex = 1;
            // 
            // BLACK_PIECES_COUNT
            // 
            this.BLACK_PIECES_COUNT.AutoSize = true;
            this.BLACK_PIECES_COUNT.Location = new System.Drawing.Point(10, 178);
            this.BLACK_PIECES_COUNT.Name = "BLACK_PIECES_COUNT";
            this.BLACK_PIECES_COUNT.Size = new System.Drawing.Size(66, 17);
            this.BLACK_PIECES_COUNT.TabIndex = 6;
            this.BLACK_PIECES_COUNT.Text = "Pieces: 0";
            // 
            // BLACK_CONSOLE_CHECKBOX
            // 
            this.BLACK_CONSOLE_CHECKBOX.AutoSize = true;
            this.BLACK_CONSOLE_CHECKBOX.Location = new System.Drawing.Point(12, 138);
            this.BLACK_CONSOLE_CHECKBOX.Name = "BLACK_CONSOLE_CHECKBOX";
            this.BLACK_CONSOLE_CHECKBOX.Size = new System.Drawing.Size(220, 21);
            this.BLACK_CONSOLE_CHECKBOX.TabIndex = 5;
            this.BLACK_CONSOLE_CHECKBOX.Text = "Show Black\'s Console Window";
            this.BLACK_CONSOLE_CHECKBOX.UseVisualStyleBackColor = true;
            // 
            // BLACK_CURRENT_STATE_LABEL
            // 
            this.BLACK_CURRENT_STATE_LABEL.AutoSize = true;
            this.BLACK_CURRENT_STATE_LABEL.Location = new System.Drawing.Point(9, 100);
            this.BLACK_CURRENT_STATE_LABEL.Name = "BLACK_CURRENT_STATE_LABEL";
            this.BLACK_CURRENT_STATE_LABEL.Size = new System.Drawing.Size(63, 17);
            this.BLACK_CURRENT_STATE_LABEL.TabIndex = 4;
            this.BLACK_CURRENT_STATE_LABEL.Text = "Current: ";
            // 
            // BLACK_COMPUTER_BUTTON
            // 
            this.BLACK_COMPUTER_BUTTON.Location = new System.Drawing.Point(303, 46);
            this.BLACK_COMPUTER_BUTTON.Name = "BLACK_COMPUTER_BUTTON";
            this.BLACK_COMPUTER_BUTTON.Size = new System.Drawing.Size(112, 38);
            this.BLACK_COMPUTER_BUTTON.TabIndex = 3;
            this.BLACK_COMPUTER_BUTTON.Text = "Computer...";
            this.BLACK_COMPUTER_BUTTON.UseVisualStyleBackColor = true;
            this.BLACK_COMPUTER_BUTTON.Click += new System.EventHandler(this.BLACK_COMPUTER_BUTTON_Click);
            // 
            // BLACK_HUMAN_BUTTON
            // 
            this.BLACK_HUMAN_BUTTON.Location = new System.Drawing.Point(37, 46);
            this.BLACK_HUMAN_BUTTON.Name = "BLACK_HUMAN_BUTTON";
            this.BLACK_HUMAN_BUTTON.Size = new System.Drawing.Size(95, 38);
            this.BLACK_HUMAN_BUTTON.TabIndex = 2;
            this.BLACK_HUMAN_BUTTON.Text = "Human ";
            this.BLACK_HUMAN_BUTTON.UseVisualStyleBackColor = true;
            this.BLACK_HUMAN_BUTTON.Click += new System.EventHandler(this.BLACK_HUMAN_BUTTON_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Black";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.RESET_BUTTON);
            this.panel3.Controls.Add(this.START_BUTTON);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.CURRENT_TURN_PICTURE_BOX);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 503);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(517, 244);
            this.panel3.TabIndex = 2;
            // 
            // RESET_BUTTON
            // 
            this.RESET_BUTTON.Location = new System.Drawing.Point(37, 120);
            this.RESET_BUTTON.Name = "RESET_BUTTON";
            this.RESET_BUTTON.Size = new System.Drawing.Size(114, 47);
            this.RESET_BUTTON.TabIndex = 4;
            this.RESET_BUTTON.Text = "Reset";
            this.RESET_BUTTON.UseVisualStyleBackColor = true;
            this.RESET_BUTTON.Click += new System.EventHandler(this.RESET_BUTTON_Click);
            // 
            // START_BUTTON
            // 
            this.START_BUTTON.Location = new System.Drawing.Point(37, 56);
            this.START_BUTTON.Name = "START_BUTTON";
            this.START_BUTTON.Size = new System.Drawing.Size(114, 47);
            this.START_BUTTON.TabIndex = 3;
            this.START_BUTTON.Text = "Start";
            this.START_BUTTON.UseVisualStyleBackColor = true;
            this.START_BUTTON.Click += new System.EventHandler(this.START_BUTTON_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(345, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Current Turn:";
            // 
            // CURRENT_TURN_PICTURE_BOX
            // 
            this.CURRENT_TURN_PICTURE_BOX.Location = new System.Drawing.Point(348, 86);
            this.CURRENT_TURN_PICTURE_BOX.Name = "CURRENT_TURN_PICTURE_BOX";
            this.CURRENT_TURN_PICTURE_BOX.Size = new System.Drawing.Size(146, 139);
            this.CURRENT_TURN_PICTURE_BOX.TabIndex = 1;
            this.CURRENT_TURN_PICTURE_BOX.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Game Controls";
            // 
            // GameGrid
            // 
            this.GameGrid.AllowUserToAddRows = false;
            this.GameGrid.AllowUserToDeleteRows = false;
            this.GameGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GameGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameGrid.Location = new System.Drawing.Point(0, 0);
            this.GameGrid.Name = "GameGrid";
            this.GameGrid.ReadOnly = true;
            this.GameGrid.RowTemplate.Height = 24;
            this.GameGrid.Size = new System.Drawing.Size(974, 750);
            this.GameGrid.TabIndex = 0;
            this.GameGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GameGrid_CellClick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox2.Items.AddRange(new object[] {
            "5 Seconds",
            "10 Seconds",
            "20 Seconds",
            "1 Minute",
            "No Limit"});
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.Size = new System.Drawing.Size(121, 28);
            this.toolStripComboBox2.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox2_SelectedIndexChanged);
            // 
            // Connect4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1501, 778);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Connect4";
            this.Text = "Connect4";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CURRENT_TURN_PICTURE_BOX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button RED_COMPUTER_BUTTON;
        private System.Windows.Forms.Button RED_HUMAN_BUTTON;
        private System.Windows.Forms.Button BLACK_COMPUTER_BUTTON;
        private System.Windows.Forms.Button BLACK_HUMAN_BUTTON;
        private System.Windows.Forms.Label RED_CURRENT_STATE_LABEL;
        private System.Windows.Forms.Label BLACK_CURRENT_STATE_LABEL;
        private System.Windows.Forms.CheckBox RED_CONSOLE_CHECKBOX;
        private System.Windows.Forms.CheckBox BLACK_CONSOLE_CHECKBOX;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox CURRENT_TURN_PICTURE_BOX;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.DataGridView GameGrid;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.Label RED_PIECE_COUNT;
        private System.Windows.Forms.Label BLACK_PIECES_COUNT;
        private System.Windows.Forms.Button RESET_BUTTON;
        private System.Windows.Forms.Button START_BUTTON;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox2;
    }
}