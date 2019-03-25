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
            this.SuspendLayout();
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(586, 302);
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(160, 98);
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
            this.inputAmountOfRoots.Location = new System.Drawing.Point(463, 12);
            this.inputAmountOfRoots.Name = "inputAmountOfRoots";
            this.inputAmountOfRoots.Size = new System.Drawing.Size(48, 21);
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
            this.inputAmountOfRestrictions.Location = new System.Drawing.Point(463, 39);
            this.inputAmountOfRestrictions.Name = "inputAmountOfRestrictions";
            this.inputAmountOfRestrictions.Size = new System.Drawing.Size(48, 21);
            this.inputAmountOfRestrictions.TabIndex = 3;
            // 
            // acceptParemetrs
            // 
            this.acceptParemetrs.Location = new System.Drawing.Point(430, 66);
            this.acceptParemetrs.Name = "acceptParemetrs";
            this.acceptParemetrs.Size = new System.Drawing.Size(81, 23);
            this.acceptParemetrs.TabIndex = 4;
            this.acceptParemetrs.Text = "Принять";
            this.acceptParemetrs.UseVisualStyleBackColor = true;
            this.acceptParemetrs.Click += new System.EventHandler(this.acceptParemetrs_Click);
            // 
            // acceptTable
            // 
            this.acceptTable.Location = new System.Drawing.Point(303, 280);
            this.acceptTable.Name = "acceptTable";
            this.acceptTable.Size = new System.Drawing.Size(75, 23);
            this.acceptTable.TabIndex = 5;
            this.acceptTable.Text = "Принять";
            this.acceptTable.UseVisualStyleBackColor = true;
            this.acceptTable.Click += new System.EventHandler(this.acceptTable_Click);
            // 
            // roots
            // 
            this.roots.AutoSize = true;
            this.roots.Location = new System.Drawing.Point(427, 15);
            this.roots.Name = "roots";
            this.roots.Size = new System.Drawing.Size(30, 13);
            this.roots.TabIndex = 6;
            this.roots.Text = "roots";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.roots);
            this.Controls.Add(this.acceptTable);
            this.Controls.Add(this.acceptParemetrs);
            this.Controls.Add(this.inputAmountOfRestrictions);
            this.Controls.Add(this.inputAmountOfRoots);
            this.Controls.Add(this.outputBox);
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}

