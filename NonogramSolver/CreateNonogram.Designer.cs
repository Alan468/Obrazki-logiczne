namespace NonogramSolver {
    partial class CreateNonogram {
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
            this.ConfirmGameButton = new System.Windows.Forms.Button();
            this.SaveGameToXMLButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.YLayersUpDown = new System.Windows.Forms.NumericUpDown();
            this.XLayersUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.HeightUpDown = new System.Windows.Forms.NumericUpDown();
            this.WidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GridX = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridY = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CancelGameButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YLayersUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XLayersUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridY)).BeginInit();
            this.SuspendLayout();
            // 
            // ConfirmGameButton
            // 
            this.ConfirmGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmGameButton.Location = new System.Drawing.Point(434, 426);
            this.ConfirmGameButton.Name = "ConfirmGameButton";
            this.ConfirmGameButton.Size = new System.Drawing.Size(88, 23);
            this.ConfirmGameButton.TabIndex = 0;
            this.ConfirmGameButton.Text = "OK";
            this.ConfirmGameButton.UseVisualStyleBackColor = true;
            this.ConfirmGameButton.Click += new System.EventHandler(this.Confirm);
            // 
            // SaveGameToXMLButton
            // 
            this.SaveGameToXMLButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveGameToXMLButton.Location = new System.Drawing.Point(340, 426);
            this.SaveGameToXMLButton.Name = "SaveGameToXMLButton";
            this.SaveGameToXMLButton.Size = new System.Drawing.Size(88, 23);
            this.SaveGameToXMLButton.TabIndex = 1;
            this.SaveGameToXMLButton.Text = "Zapisz do XML";
            this.SaveGameToXMLButton.UseVisualStyleBackColor = true;
            this.SaveGameToXMLButton.Click += new System.EventHandler(this.SaveToXML);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.YLayersUpDown);
            this.panel1.Controls.Add(this.XLayersUpDown);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.HeightUpDown);
            this.panel1.Controls.Add(this.WidthUpDown);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.GridX);
            this.panel1.Controls.Add(this.GridY);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 407);
            this.panel1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "x";
            // 
            // YLayersUpDown
            // 
            this.YLayersUpDown.Location = new System.Drawing.Point(91, 86);
            this.YLayersUpDown.Name = "YLayersUpDown";
            this.YLayersUpDown.Size = new System.Drawing.Size(63, 20);
            this.YLayersUpDown.TabIndex = 12;
            this.YLayersUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.YLayersUpDown.ValueChanged += new System.EventHandler(this.ChangeYLayers);
            // 
            // XLayersUpDown
            // 
            this.XLayersUpDown.Location = new System.Drawing.Point(4, 86);
            this.XLayersUpDown.Name = "XLayersUpDown";
            this.XLayersUpDown.Size = new System.Drawing.Size(63, 20);
            this.XLayersUpDown.TabIndex = 11;
            this.XLayersUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.XLayersUpDown.ValueChanged += new System.EventHandler(this.ChangeXLayers);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ilość grup:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(73, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "x";
            // 
            // HeightUpDown
            // 
            this.HeightUpDown.Location = new System.Drawing.Point(91, 34);
            this.HeightUpDown.Name = "HeightUpDown";
            this.HeightUpDown.Size = new System.Drawing.Size(63, 20);
            this.HeightUpDown.TabIndex = 8;
            this.HeightUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HeightUpDown.ValueChanged += new System.EventHandler(this.HeightChange);
            // 
            // WidthUpDown
            // 
            this.WidthUpDown.Location = new System.Drawing.Point(4, 34);
            this.WidthUpDown.Name = "WidthUpDown";
            this.WidthUpDown.Size = new System.Drawing.Size(63, 20);
            this.WidthUpDown.TabIndex = 7;
            this.WidthUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WidthUpDown.ValueChanged += new System.EventHandler(this.WidthChange);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Rozmiar:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Oś Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Oś X";
            // 
            // GridX
            // 
            this.GridX.AllowUserToAddRows = false;
            this.GridX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridX.ColumnHeadersVisible = false;
            this.GridX.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.GridX.Location = new System.Drawing.Point(210, 4);
            this.GridX.Name = "GridX";
            this.GridX.RowHeadersWidth = 50;
            this.GridX.Size = new System.Drawing.Size(292, 200);
            this.GridX.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // GridY
            // 
            this.GridY.AllowUserToAddRows = false;
            this.GridY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GridY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridY.ColumnHeadersVisible = false;
            this.GridY.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.GridY.Location = new System.Drawing.Point(4, 210);
            this.GridY.Name = "GridY";
            this.GridY.Size = new System.Drawing.Size(200, 190);
            this.GridY.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // CancelGameButton
            // 
            this.CancelGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelGameButton.Location = new System.Drawing.Point(170, 426);
            this.CancelGameButton.Name = "CancelGameButton";
            this.CancelGameButton.Size = new System.Drawing.Size(88, 23);
            this.CancelGameButton.TabIndex = 3;
            this.CancelGameButton.Text = "Anuluj";
            this.CancelGameButton.UseVisualStyleBackColor = true;
            this.CancelGameButton.Click += new System.EventHandler(this.CloseWindow);
            // 
            // CreateNonogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 461);
            this.Controls.Add(this.CancelGameButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SaveGameToXMLButton);
            this.Controls.Add(this.ConfirmGameButton);
            this.MinimumSize = new System.Drawing.Size(450, 450);
            this.Name = "CreateNonogram";
            this.Text = "CreateNonogram";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YLayersUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XLayersUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ConfirmGameButton;
        private System.Windows.Forms.Button SaveGameToXMLButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CancelGameButton;
        private System.Windows.Forms.DataGridView GridY;
        private System.Windows.Forms.DataGridView GridX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown HeightUpDown;
        private System.Windows.Forms.NumericUpDown WidthUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown YLayersUpDown;
        private System.Windows.Forms.NumericUpDown XLayersUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}