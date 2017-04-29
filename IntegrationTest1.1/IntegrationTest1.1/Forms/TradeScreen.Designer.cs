namespace IntegrationTest1._1.Forms
{
    partial class TradeScreen
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
            this.btnTrade = new System.Windows.Forms.Button();
            this.lblHeading = new System.Windows.Forms.Label();
            this.updCurrentPlayer = new System.Windows.Forms.NumericUpDown();
            this.updRecipientPlayer = new System.Windows.Forms.NumericUpDown();
            this.lblCurrentResource = new System.Windows.Forms.Label();
            this.lblRecipientResource = new System.Windows.Forms.Label();
            this.lblFor = new System.Windows.Forms.Label();
            this.cmbCurrentPlayer = new System.Windows.Forms.ComboBox();
            this.cmbRecipientPlayer = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.updCurrentPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updRecipientPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTrade
            // 
            this.btnTrade.Enabled = false;
            this.btnTrade.Font = new System.Drawing.Font("Copperplate Gothic Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrade.Location = new System.Drawing.Point(12, 220);
            this.btnTrade.Name = "btnTrade";
            this.btnTrade.Size = new System.Drawing.Size(231, 32);
            this.btnTrade.TabIndex = 39;
            this.btnTrade.Text = "Request Trade";
            this.btnTrade.UseVisualStyleBackColor = true;
            this.btnTrade.Click += new System.EventHandler(this.btnTrade_Click);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Copperplate Gothic Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.Gold;
            this.lblHeading.Location = new System.Drawing.Point(38, 9);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(402, 40);
            this.lblHeading.TabIndex = 38;
            this.lblHeading.Text = "(Trade with Player)";
            // 
            // updCurrentPlayer
            // 
            this.updCurrentPlayer.Location = new System.Drawing.Point(77, 81);
            this.updCurrentPlayer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updCurrentPlayer.Name = "updCurrentPlayer";
            this.updCurrentPlayer.Size = new System.Drawing.Size(120, 20);
            this.updCurrentPlayer.TabIndex = 50;
            this.updCurrentPlayer.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // updRecipientPlayer
            // 
            this.updRecipientPlayer.Location = new System.Drawing.Point(77, 143);
            this.updRecipientPlayer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updRecipientPlayer.Name = "updRecipientPlayer";
            this.updRecipientPlayer.Size = new System.Drawing.Size(120, 20);
            this.updRecipientPlayer.TabIndex = 51;
            this.updRecipientPlayer.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCurrentResource
            // 
            this.lblCurrentResource.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentResource.Font = new System.Drawing.Font("Copperplate Gothic Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentResource.ForeColor = System.Drawing.Color.Gold;
            this.lblCurrentResource.Location = new System.Drawing.Point(303, 142);
            this.lblCurrentResource.Name = "lblCurrentResource";
            this.lblCurrentResource.Size = new System.Drawing.Size(183, 25);
            this.lblCurrentResource.TabIndex = 52;
            // 
            // lblRecipientResource
            // 
            this.lblRecipientResource.BackColor = System.Drawing.Color.Transparent;
            this.lblRecipientResource.Font = new System.Drawing.Font("Copperplate Gothic Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecipientResource.ForeColor = System.Drawing.Color.Gold;
            this.lblRecipientResource.Location = new System.Drawing.Point(303, 199);
            this.lblRecipientResource.Name = "lblRecipientResource";
            this.lblRecipientResource.Size = new System.Drawing.Size(183, 25);
            this.lblRecipientResource.TabIndex = 53;
            // 
            // lblFor
            // 
            this.lblFor.BackColor = System.Drawing.Color.Transparent;
            this.lblFor.Font = new System.Drawing.Font("Copperplate Gothic Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFor.ForeColor = System.Drawing.Color.Gold;
            this.lblFor.Location = new System.Drawing.Point(74, 113);
            this.lblFor.Name = "lblFor";
            this.lblFor.Size = new System.Drawing.Size(183, 25);
            this.lblFor.TabIndex = 54;
            this.lblFor.Text = "for";
            // 
            // cmbCurrentPlayer
            // 
            this.cmbCurrentPlayer.Font = new System.Drawing.Font("Copperplate Gothic Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCurrentPlayer.FormattingEnabled = true;
            this.cmbCurrentPlayer.Items.AddRange(new object[] {
            "Lumber",
            "Grain",
            "Wool",
            "Ore",
            "Brick"});
            this.cmbCurrentPlayer.Location = new System.Drawing.Point(230, 80);
            this.cmbCurrentPlayer.Name = "cmbCurrentPlayer";
            this.cmbCurrentPlayer.Size = new System.Drawing.Size(121, 20);
            this.cmbCurrentPlayer.TabIndex = 55;
            this.cmbCurrentPlayer.SelectedIndexChanged += new System.EventHandler(this.cmbCurrentPlayer_SelectedIndexChanged);
            // 
            // cmbRecipientPlayer
            // 
            this.cmbRecipientPlayer.Font = new System.Drawing.Font("Copperplate Gothic Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRecipientPlayer.FormattingEnabled = true;
            this.cmbRecipientPlayer.Items.AddRange(new object[] {
            "Lumber",
            "Grain",
            "Wool",
            "Ore",
            "Brick"});
            this.cmbRecipientPlayer.Location = new System.Drawing.Point(230, 143);
            this.cmbRecipientPlayer.Name = "cmbRecipientPlayer";
            this.cmbRecipientPlayer.Size = new System.Drawing.Size(121, 20);
            this.cmbRecipientPlayer.TabIndex = 56;
            this.cmbRecipientPlayer.SelectedIndexChanged += new System.EventHandler(this.cmbRecipientPlayer_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Copperplate Gothic Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(267, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(185, 32);
            this.btnCancel.TabIndex = 57;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // TradeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(477, 285);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbRecipientPlayer);
            this.Controls.Add(this.cmbCurrentPlayer);
            this.Controls.Add(this.lblFor);
            this.Controls.Add(this.lblRecipientResource);
            this.Controls.Add(this.lblCurrentResource);
            this.Controls.Add(this.updRecipientPlayer);
            this.Controls.Add(this.updCurrentPlayer);
            this.Controls.Add(this.btnTrade);
            this.Controls.Add(this.lblHeading);
            this.Name = "TradeScreen";
            this.Text = "TradeScreen";
            this.Load += new System.EventHandler(this.TradeScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.updCurrentPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updRecipientPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTrade;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.NumericUpDown updCurrentPlayer;
        private System.Windows.Forms.NumericUpDown updRecipientPlayer;
        private System.Windows.Forms.Label lblCurrentResource;
        private System.Windows.Forms.Label lblRecipientResource;
        private System.Windows.Forms.Label lblFor;
        private System.Windows.Forms.ComboBox cmbCurrentPlayer;
        private System.Windows.Forms.ComboBox cmbRecipientPlayer;
        private System.Windows.Forms.Button btnCancel;
    }
}