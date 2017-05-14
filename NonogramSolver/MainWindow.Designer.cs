namespace NonogramSolver {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.GamePanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartSolvingButton = new System.Windows.Forms.ToolStripMenuItem();
            this.StopSolvingButton = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadXMLButton = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateNonogramButton = new System.Windows.Forms.ToolStripMenuItem();
            this.informacjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutProgramButton = new System.Windows.Forms.ToolStripMenuItem();
            this.Background = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.Background.SuspendLayout();
            this.SuspendLayout();
            // 
            // GamePanel
            // 
            this.GamePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GamePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GamePanel.BackColor = System.Drawing.SystemColors.Control;
            this.GamePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GamePanel.Location = new System.Drawing.Point(3, 3);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(578, 381);
            this.GamePanel.TabIndex = 0;
            this.GamePanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.WindowUpdate);
            this.GamePanel.SizeChanged += new System.EventHandler(this.WindowRedraw);
            this.GamePanel.Resize += new System.EventHandler(this.WindowRedraw);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.informacjeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartSolvingButton,
            this.StopSolvingButton,
            this.LoadXMLButton,
            this.CreateNonogramButton});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // StartSolvingButton
            // 
            this.StartSolvingButton.Enabled = false;
            this.StartSolvingButton.Name = "StartSolvingButton";
            this.StartSolvingButton.Size = new System.Drawing.Size(194, 22);
            this.StartSolvingButton.Text = "Rozwiąż";
            this.StartSolvingButton.Click += new System.EventHandler(this.ToongleSolvingState);
            // 
            // StopSolvingButton
            // 
            this.StopSolvingButton.Enabled = false;
            this.StopSolvingButton.Name = "StopSolvingButton";
            this.StopSolvingButton.Size = new System.Drawing.Size(194, 22);
            this.StopSolvingButton.Text = "Przerwij rozwiązywanie";
            this.StopSolvingButton.Click += new System.EventHandler(this.ToongleSolvingState);
            // 
            // LoadXMLButton
            // 
            this.LoadXMLButton.Name = "LoadXMLButton";
            this.LoadXMLButton.Size = new System.Drawing.Size(194, 22);
            this.LoadXMLButton.Text = "Wczytaj XML";
            this.LoadXMLButton.Click += new System.EventHandler(this.LoadXML);
            // 
            // CreateNonogramButton
            // 
            this.CreateNonogramButton.Name = "CreateNonogramButton";
            this.CreateNonogramButton.Size = new System.Drawing.Size(194, 22);
            this.CreateNonogramButton.Text = "Własny obraz";
            this.CreateNonogramButton.Click += new System.EventHandler(this.CreateNewNonogram);
            // 
            // informacjeToolStripMenuItem
            // 
            this.informacjeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutProgramButton});
            this.informacjeToolStripMenuItem.Name = "informacjeToolStripMenuItem";
            this.informacjeToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.informacjeToolStripMenuItem.Text = "Informacje";
            // 
            // AboutProgramButton
            // 
            this.AboutProgramButton.Name = "AboutProgramButton";
            this.AboutProgramButton.Size = new System.Drawing.Size(141, 22);
            this.AboutProgramButton.Text = "O programie";
            this.AboutProgramButton.Click += new System.EventHandler(this.AboutProgram);
            // 
            // Background
            // 
            this.Background.Controls.Add(this.GamePanel);
            this.Background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Background.Location = new System.Drawing.Point(0, 24);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(584, 387);
            this.Background.TabIndex = 3;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.Background);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(500, 450);
            this.Name = "MainWindow";
            this.Text = "Rozwiązywanie obrazków logicznych ";
            this.DockChanged += new System.EventHandler(this.WindowUpdate);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.WindowRedraw);
            this.Move += new System.EventHandler(this.WindowRedraw);
            this.Resize += new System.EventHandler(this.WindowRedraw);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Background.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StartSolvingButton;
        private System.Windows.Forms.ToolStripMenuItem LoadXMLButton;
        private System.Windows.Forms.ToolStripMenuItem informacjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutProgramButton;
        private System.Windows.Forms.ToolStripMenuItem CreateNonogramButton;
        private System.Windows.Forms.ToolStripMenuItem StopSolvingButton;
        private System.Windows.Forms.Panel Background;
    }
}

