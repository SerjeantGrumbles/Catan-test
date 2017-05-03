namespace IntegrationTest1._1
{
    partial class DevCardScreen
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lstDevCards = new System.Windows.Forms.ListBox();
            this.picDevCard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDevCard)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Copperplate Gothic Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(207, 257);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(185, 32);
            this.btnCancel.TabIndex = 59;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Enabled = false;
            this.btnPlay.Font = new System.Drawing.Font("Copperplate Gothic Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(207, 207);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(185, 32);
            this.btnPlay.TabIndex = 58;
            this.btnPlay.Text = "Play Card";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Copperplate Gothic Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.Gold;
            this.lblHeading.Location = new System.Drawing.Point(50, 9);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(416, 40);
            this.lblHeading.TabIndex = 60;
            this.lblHeading.Text = "Development Cards";
            // 
            // lstDevCards
            // 
            this.lstDevCards.Font = new System.Drawing.Font("Copperplate Gothic Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDevCards.FormattingEnabled = true;
            this.lstDevCards.ItemHeight = 14;
            this.lstDevCards.Location = new System.Drawing.Point(207, 66);
            this.lstDevCards.Name = "lstDevCards";
            this.lstDevCards.Size = new System.Drawing.Size(282, 102);
            this.lstDevCards.TabIndex = 61;
            this.lstDevCards.SelectedIndexChanged += new System.EventHandler(this.lstDevCards_SelectedIndexChanged);
            // 
            // picDevCard
            // 
            this.picDevCard.Location = new System.Drawing.Point(29, 66);
            this.picDevCard.Name = "picDevCard";
            this.picDevCard.Size = new System.Drawing.Size(157, 237);
            this.picDevCard.TabIndex = 62;
            this.picDevCard.TabStop = false;
            // 
            // DevCardScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(518, 347);
            this.Controls.Add(this.picDevCard);
            this.Controls.Add(this.lstDevCards);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPlay);
            this.Name = "DevCardScreen";
            this.Load += new System.EventHandler(this.DevCardScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picDevCard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.ListBox lstDevCards;
        private System.Windows.Forms.PictureBox picDevCard;
    }
}