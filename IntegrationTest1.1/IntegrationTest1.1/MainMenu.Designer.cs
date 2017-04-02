namespace IntegrationTest1._1
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.btnRules = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPlayer = new System.Windows.Forms.Button();
            this.imgCatan = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgCatan)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRules
            // 
            this.btnRules.BackColor = System.Drawing.Color.Silver;
            this.btnRules.Font = new System.Drawing.Font("Copperplate Gothic Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRules.Location = new System.Drawing.Point(317, 627);
            this.btnRules.Name = "btnRules";
            this.btnRules.Size = new System.Drawing.Size(179, 51);
            this.btnRules.TabIndex = 6;
            this.btnRules.Text = "Rules";
            this.btnRules.UseVisualStyleBackColor = false;
            this.btnRules.Click += new System.EventHandler(this.btnRules_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Silver;
            this.btnExit.Font = new System.Drawing.Font("Copperplate Gothic Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(525, 627);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(192, 51);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPlayer
            // 
            this.btnPlayer.BackColor = System.Drawing.Color.Silver;
            this.btnPlayer.Font = new System.Drawing.Font("Copperplate Gothic Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayer.Location = new System.Drawing.Point(30, 627);
            this.btnPlayer.Name = "btnPlayer";
            this.btnPlayer.Size = new System.Drawing.Size(260, 51);
            this.btnPlayer.TabIndex = 5;
            this.btnPlayer.Text = "Select Players";
            this.btnPlayer.UseVisualStyleBackColor = false;
            this.btnPlayer.Click += new System.EventHandler(this.btnPlayer_Click);
            // 
            // imgCatan
            // 
            this.imgCatan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.imgCatan.Image = ((System.Drawing.Image)(resources.GetObject("imgCatan.Image")));
            this.imgCatan.Location = new System.Drawing.Point(30, 12);
            this.imgCatan.Name = "imgCatan";
            this.imgCatan.Size = new System.Drawing.Size(687, 591);
            this.imgCatan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCatan.TabIndex = 4;
            this.imgCatan.TabStop = false;
            // 
            // MainMenu
            // 
            this.AcceptButton = this.btnPlayer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(763, 713);
            this.Controls.Add(this.btnRules);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPlayer);
            this.Controls.Add(this.imgCatan);
            this.Name = "MainMenu";
            this.Text = "Settlers of Catan";
            ((System.ComponentModel.ISupportInitialize)(this.imgCatan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRules;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPlayer;
        private System.Windows.Forms.PictureBox imgCatan;
    }
}

