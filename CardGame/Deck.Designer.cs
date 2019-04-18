namespace CardGame
{
    partial class Deck
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
            this.btnImport = new System.Windows.Forms.Button();
            this.AllCards = new System.Windows.Forms.Panel();
            this.PanelDeck = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(12, 12);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // AllCards
            // 
            this.AllCards.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AllCards.Location = new System.Drawing.Point(1475, 12);
            this.AllCards.Name = "AllCards";
            this.AllCards.Size = new System.Drawing.Size(376, 917);
            this.AllCards.TabIndex = 2;
            // 
            // PanelDeck
            // 
            this.PanelDeck.Location = new System.Drawing.Point(31, 61);
            this.PanelDeck.Name = "PanelDeck";
            this.PanelDeck.Size = new System.Drawing.Size(1438, 868);
            this.PanelDeck.TabIndex = 3;
            // 
            // Deck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1864, 941);
            this.Controls.Add(this.PanelDeck);
            this.Controls.Add(this.AllCards);
            this.Controls.Add(this.btnImport);
            this.Name = "Deck";
            this.Text = "Deck";
            this.Load += new System.EventHandler(this.Deck_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Panel AllCards;
        private System.Windows.Forms.Panel PanelDeck;
    }
}