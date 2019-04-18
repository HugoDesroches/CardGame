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
            this.PanelError.SuspendLayout();
            this.MessagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelError
            // 
            this.PanelError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelError.BackColor = System.Drawing.Color.Red;
            this.PanelError.Controls.Add(this.ErrorLabel);
            this.PanelError.Location = new System.Drawing.Point(524, 13);
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
            this.TextMessage.Location = new System.Drawing.Point(3, 1);
            this.TextMessage.Name = "TextMessage";
            this.TextMessage.Size = new System.Drawing.Size(60, 36);
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
            this.MessagePanel.Size = new System.Drawing.Size(197, 37);
            this.MessagePanel.TabIndex = 2;
            this.MessagePanel.Visible = false;
            // 
            // btnPassTurn
            // 
            this.btnPassTurn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPassTurn.Location = new System.Drawing.Point(713, 415);
            this.btnPassTurn.Name = "btnPassTurn";
            this.btnPassTurn.Size = new System.Drawing.Size(75, 23);
            this.btnPassTurn.TabIndex = 3;
            this.btnPassTurn.Text = "Pass Turn";
            this.btnPassTurn.UseVisualStyleBackColor = true;
            this.btnPassTurn.Visible = false;
            this.btnPassTurn.Click += new System.EventHandler(this.btnPassTurn_Click);
            // 
            // Game2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPassTurn);
            this.Controls.Add(this.MessagePanel);
            this.Controls.Add(this.PanelError);
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
    }
}