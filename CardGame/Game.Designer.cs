namespace CardGame
{
    partial class Game
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
            this.Message = new System.Windows.Forms.Label();
            this.btnPassTurn = new System.Windows.Forms.Button();
            this.player2NbCard = new System.Windows.Forms.Label();
            this.player1NbCard = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Cards = new System.Windows.Forms.Panel();
            this.Emplacement = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nbIdeo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.Location = new System.Drawing.Point(951, 20);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(110, 13);
            this.Message.TabIndex = 0;
            this.Message.Text = "Waiting other player...";
            // 
            // btnPassTurn
            // 
            this.btnPassTurn.Location = new System.Drawing.Point(1777, 906);
            this.btnPassTurn.Name = "btnPassTurn";
            this.btnPassTurn.Size = new System.Drawing.Size(75, 23);
            this.btnPassTurn.TabIndex = 1;
            this.btnPassTurn.Text = "Pass Turn";
            this.btnPassTurn.UseVisualStyleBackColor = true;
            this.btnPassTurn.Visible = false;
            this.btnPassTurn.Click += new System.EventHandler(this.btnPassTurn_Click);
            // 
            // player2NbCard
            // 
            this.player2NbCard.AutoSize = true;
            this.player2NbCard.Location = new System.Drawing.Point(1774, 20);
            this.player2NbCard.Name = "player2NbCard";
            this.player2NbCard.Size = new System.Drawing.Size(13, 13);
            this.player2NbCard.TabIndex = 2;
            this.player2NbCard.Text = "0";
            this.player2NbCard.Click += new System.EventHandler(this.label1_Click);
            // 
            // player1NbCard
            // 
            this.player1NbCard.AutoSize = true;
            this.player1NbCard.Location = new System.Drawing.Point(1839, 867);
            this.player1NbCard.Name = "player1NbCard";
            this.player1NbCard.Size = new System.Drawing.Size(13, 13);
            this.player1NbCard.TabIndex = 3;
            this.player1NbCard.Text = "0";
            this.player1NbCard.Click += new System.EventHandler(this.player1NbCard_Click);
            // 
            // Cards
            // 
            this.Cards.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cards.Location = new System.Drawing.Point(96, 718);
            this.Cards.Name = "Cards";
            this.Cards.Size = new System.Drawing.Size(1623, 319);
            this.Cards.TabIndex = 4;
            // 
            // Emplacement
            // 
            this.Emplacement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Emplacement.Location = new System.Drawing.Point(96, 36);
            this.Emplacement.Name = "Emplacement";
            this.Emplacement.Size = new System.Drawing.Size(1623, 676);
            this.Emplacement.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1747, 867);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre de carte";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1747, 841);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Point d\'idéo";
            // 
            // nbIdeo
            // 
            this.nbIdeo.AutoSize = true;
            this.nbIdeo.Location = new System.Drawing.Point(1839, 841);
            this.nbIdeo.Name = "nbIdeo";
            this.nbIdeo.Size = new System.Drawing.Size(19, 13);
            this.nbIdeo.TabIndex = 8;
            this.nbIdeo.Text = "10";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1864, 941);
            this.Controls.Add(this.nbIdeo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Emplacement);
            this.Controls.Add(this.Cards);
            this.Controls.Add(this.player1NbCard);
            this.Controls.Add(this.player2NbCard);
            this.Controls.Add(this.btnPassTurn);
            this.Controls.Add(this.Message);
            this.Name = "Game";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Message;
        private System.Windows.Forms.Button btnPassTurn;
        private System.Windows.Forms.Label player2NbCard;
        private System.Windows.Forms.Label player1NbCard;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel Cards;
        private System.Windows.Forms.Panel Emplacement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label nbIdeo;
    }
}