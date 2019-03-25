namespace laba1
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
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.inputAmountOfRoots = new System.Windows.Forms.ComboBox();
            this.inputAmountOfRestrictions = new System.Windows.Forms.ComboBox();
            this.acceptParemetrs = new System.Windows.Forms.Button();
            this.acceptTable = new System.Windows.Forms.Button();
            this.roots = new System.Windows.Forms.Label();
            this.restrictions = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(12, 370);
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(527, 98);
            this.outputBox.TabIndex = 0;
            this.outputBox.Text = "";
            // 
            // inputAmountOfRoots
            // 
            this.inputAmountOfRoots.FormattingEnabled = true;
            this.inputAmountOfRoots.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.inputAmountOfRoots.Location = new System.Drawing.Point(707, 37);
            this.inputAmountOfRoots.Name = "inputAmountOfRoots";
            this.inputAmountOfRoots.Size = new System.Drawing.Size(81, 21);
            this.inputAmountOfRoots.TabIndex = 2;
            // 
            // inputAmountOfRestrictions
            // 
            this.inputAmountOfRestrictions.FormattingEnabled = true;
            this.inputAmountOfRestrictions.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.inputAmountOfRestrictions.Location = new System.Drawing.Point(707, 64);
            this.inputAmountOfRestrictions.Name = "inputAmountOfRestrictions";
            this.inputAmountOfRestrictions.Size = new System.Drawing.Size(81, 21);
            this.inputAmountOfRestrictions.TabIndex = 3;
            // 
            // acceptParemetrs
            // 
            this.acceptParemetrs.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.acceptParemetrs.Location = new System.Drawing.Point(707, 91);
            this.acceptParemetrs.Name = "acceptParemetrs";
            this.acceptParemetrs.Size = new System.Drawing.Size(81, 23);
            this.acceptParemetrs.TabIndex = 4;
            this.acceptParemetrs.Text = "Accept";
            this.acceptParemetrs.UseVisualStyleBackColor = true;
            this.acceptParemetrs.Click += new System.EventHandler(this.acceptParemetrs_Click);
            // 
            // acceptTable
            // 
            this.acceptTable.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.acceptTable.Location = new System.Drawing.Point(707, 144);
            this.acceptTable.Name = "acceptTable";
            this.acceptTable.Size = new System.Drawing.Size(81, 23);
            this.acceptTable.TabIndex = 5;
            this.acceptTable.Text = "Calculate";
            this.acceptTable.UseVisualStyleBackColor = true;
            this.acceptTable.Click += new System.EventHandler(this.acceptTable_Click);
            // 
            // roots
            // 
            this.roots.AutoSize = true;
            this.roots.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roots.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.roots.Location = new System.Drawing.Point(593, 38);
            this.roots.Name = "roots";
            this.roots.Size = new System.Drawing.Size(108, 16);
            this.roots.TabIndex = 6;
            this.roots.Text = "Amount Of Roots";
            // 
            // restrictions
            // 
            this.restrictions.AutoSize = true;
            this.restrictions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restrictions.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.restrictions.Location = new System.Drawing.Point(559, 65);
            this.restrictions.Name = "restrictions";
            this.restrictions.Size = new System.Drawing.Size(142, 16);
            this.restrictions.TabIndex = 7;
            this.restrictions.Text = "Amount Of Restrictions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(700, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Simplex";
            // 
            // resetButton
            // 
            this.resetButton.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.resetButton.Location = new System.Drawing.Point(707, 184);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(81, 23);
            this.resetButton.TabIndex = 9;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(800, 485);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.restrictions);
            this.Controls.Add(this.roots);
            this.Controls.Add(this.acceptTable);
            this.Controls.Add(this.acceptParemetrs);
            this.Controls.Add(this.inputAmountOfRestrictions);
            this.Controls.Add(this.inputAmountOfRoots);
            this.Controls.Add(this.outputBox);
            this.Name = "Form1";
            this.Text = "GKS-4 Lab1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox outputBox;
        private System.Windows.Forms.ComboBox inputAmountOfRoots;
        private System.Windows.Forms.ComboBox inputAmountOfRestrictions;
        private System.Windows.Forms.Button acceptParemetrs;
        private System.Windows.Forms.Button acceptTable;
        private System.Windows.Forms.Label roots;
        private System.Windows.Forms.Label restrictions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button resetButton;
    }
}

