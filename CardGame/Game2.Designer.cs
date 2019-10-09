namespace CardGame
{
    partial class Game2
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
            this.PanelError = new System.Windows.Forms.Panel();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.TextMessage = new System.Windows.Forms.Label();
            this.MessagePanel = new System.Windows.Forms.Panel();
            this.btnPassTurn = new System.Windows.Forms.Button();
            this.Deck = new System.Windows.Forms.Label();
            this.EnemyDeck = new System.Windows.Forms.Label();
            this.CardInHand2 = new System.Windows.Forms.Label();
            this.CardsPanel = new System.Windows.Forms.Panel();
            this.Emplacement1 = new System.Windows.Forms.Panel();
            this.Emplacement2 = new System.Windows.Forms.Panel();
            this.IdeoPoint = new System.Windows.Forms.Label();
            this.IdeoEnemy = new System.Windows.Forms.Label();
            this.PanelError.SuspendLayout();
            this.MessagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelError
            // 
            this.PanelError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelError.BackColor = System.Drawing.Color.Red;
            this.PanelError.Controls.Add(this.ErrorLabel);
            this.PanelError.Location = new System.Drawing.Point(1628, 13);
            this.PanelError.Name = "PanelError";
            this.PanelError.Size = new System.Drawing.Size(264, 36);
            this.PanelError.TabIndex = 0;
            this.PanelError.Visible = false;
            this.PanelError.Click += new System.EventHandler(this.PanelError_Click);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLabel.Location = new System.Drawing.Point(3, 7);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(60, 24);
            this.ErrorLabel.TabIndex = 0;
            this.ErrorLabel.Text = "label1";
            this.ErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ErrorLabel.Click += new System.EventHandler(this.ErrorLabel_Click);
            // 
            // TextMessage
            // 
            this.TextMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextMessage.Location = new System.Drawing.Point(70, 1);
            this.TextMessage.Name = "TextMessage";
            this.TextMessage.Size = new System.Drawing.Size(1228, 36);
            this.TextMessage.TabIndex = 1;
            this.TextMessage.Text = "label1";
            this.TextMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TextMessage.Click += new System.EventHandler(this.TextMessage_Click);
            // 
            // MessagePanel
            // 
            this.MessagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessagePanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.MessagePanel.Controls.Add(this.TextMessage);
            this.MessagePanel.Location = new System.Drawing.Point(279, 12);
            this.MessagePanel.Name = "MessagePanel";
            this.MessagePanel.Size = new System.Drawing.Size(1301, 37);
            this.MessagePanel.TabIndex = 2;
            this.MessagePanel.Visible = false;
            // 
            // btnPassTurn
            // 
            this.btnPassTurn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPassTurn.Location = new System.Drawing.Point(1817, 1006);
            this.btnPassTurn.Name = "btnPassTurn";
            this.btnPassTurn.Size = new System.Drawing.Size(75, 23);
            this.btnPassTurn.TabIndex = 3;
            this.btnPassTurn.Text = "Pass Turn";
            this.btnPassTurn.UseVisualStyleBackColor = true;
            this.btnPassTurn.Visible = false;
            this.btnPassTurn.Click += new System.EventHandler(this.btnPassTurn_Click);
            // 
            // Deck
            // 
            this.Deck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Deck.Location = new System.Drawing.Point(1817, 938);
            this.Deck.Name = "Deck";
            this.Deck.Size = new System.Drawing.Size(75, 65);
            this.Deck.TabIndex = 4;
            this.Deck.Text = "0";
            // 
            // EnemyDeck
            // 
            this.EnemyDeck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EnemyDeck.Location = new System.Drawing.Point(1814, 9);
            this.EnemyDeck.Name = "EnemyDeck";
            this.EnemyDeck.Size = new System.Drawing.Size(78, 69);
            this.EnemyDeck.TabIndex = 5;
            this.EnemyDeck.Text = "0";
            this.EnemyDeck.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // CardInHand2
            // 
            this.CardInHand2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CardInHand2.Location = new System.Drawing.Point(12, 9);
            this.CardInHand2.Name = "CardInHand2";
            this.CardInHand2.Size = new System.Drawing.Size(1799, 69);
            this.CardInHand2.TabIndex = 7;
            this.CardInHand2.Text = "0";
            this.CardInHand2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CardInHand2.Click += new System.EventHandler(this.CardInHand2_Click);
            // 
            // CardsPanel
            // 
            this.CardsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CardsPanel.Location = new System.Drawing.Point(12, 779);
            this.CardsPanel.Name = "CardsPanel";
            this.CardsPanel.Size = new System.Drawing.Size(1799, 250);
            this.CardsPanel.TabIndex = 8;
            // 
            // Emplacement1
            // 
            this.Emplacement1.BackColor = System.Drawing.SystemColors.Control;
            this.Emplacement1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Emplacement1.Location = new System.Drawing.Point(12, 443);
            this.Emplacement1.Name = "Emplacement1";
            this.Emplacement1.Size = new System.Drawing.Size(1799, 330);
            this.Emplacement1.TabIndex = 9;
            // 
            // Emplacement2
            // 
            this.Emplacement2.BackColor = System.Drawing.SystemColors.Control;
            this.Emplacement2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Emplacement2.Location = new System.Drawing.Point(12, 81);
            this.Emplacement2.Name = "Emplacement2";
            this.Emplacement2.Size = new System.Drawing.Size(1799, 330);
            this.Emplacement2.TabIndex = 10;
            // 
            // IdeoPoint
            // 
            this.IdeoPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.IdeoPoint.Location = new System.Drawing.Point(1817, 849);
            this.IdeoPoint.Name = "IdeoPoint";
            this.IdeoPoint.Size = new System.Drawing.Size(75, 65);
            this.IdeoPoint.TabIndex = 11;
            this.IdeoPoint.Text = "0";
            // 
            // IdeoEnemy
            // 
            this.IdeoEnemy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IdeoEnemy.Location = new System.Drawing.Point(1817, 81);
            this.IdeoEnemy.Name = "IdeoEnemy";
            this.IdeoEnemy.Size = new System.Drawing.Size(78, 69);
            this.IdeoEnemy.TabIndex = 12;
            this.IdeoEnemy.Text = "0";
            this.IdeoEnemy.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Game2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.IdeoEnemy);
            this.Controls.Add(this.IdeoPoint);
            this.Controls.Add(this.Emplacement2);
            this.Controls.Add(this.Emplacement1);
            this.Controls.Add(this.CardsPanel);
            this.Controls.Add(this.btnPassTurn);
            this.Controls.Add(this.PanelError);
            this.Controls.Add(this.MessagePanel);
            this.Controls.Add(this.CardInHand2);
            this.Controls.Add(this.EnemyDeck);
            this.Controls.Add(this.Deck);
            this.Name = "Game2";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game2_Load);
            this.PanelError.ResumeLayout(false);
            this.PanelError.PerformLayout();
            this.MessagePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelError;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.Label TextMessage;
        private System.Windows.Forms.Panel MessagePanel;
        private System.Windows.Forms.Button btnPassTurn;
        private System.Windows.Forms.Label Deck;
        private System.Windows.Forms.Label EnemyDeck;
        private System.Windows.Forms.Label CardInHand2;
        private System.Windows.Forms.Panel CardsPanel;
        private System.Windows.Forms.Panel Emplacement1;
        private System.Windows.Forms.Panel Emplacement2;
        private System.Windows.Forms.Label IdeoPoint;
        private System.Windows.Forms.Label IdeoEnemy;
    }
}