namespace Course1
{
    partial class Basket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Basket));
            this.panelBasketItems = new System.Windows.Forms.Panel();
            this.flowLayoutPanelBasket = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelUserBasket = new System.Windows.Forms.Panel();
            this.pictureBoxActivated = new System.Windows.Forms.PictureBox();
            this.UserNameLabelBasket = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.buttonCheckout = new System.Windows.Forms.Button();
            this.panelBasketItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelUserBasket.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxActivated)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBasketItems
            // 
            this.panelBasketItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBasketItems.Controls.Add(this.flowLayoutPanelBasket);
            this.panelBasketItems.Location = new System.Drawing.Point(0, 36);
            this.panelBasketItems.Name = "panelBasketItems";
            this.panelBasketItems.Size = new System.Drawing.Size(1156, 526);
            this.panelBasketItems.TabIndex = 0;
            // 
            // flowLayoutPanelBasket
            // 
            this.flowLayoutPanelBasket.AutoScroll = true;
            this.flowLayoutPanelBasket.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelBasket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelBasket.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelBasket.Name = "flowLayoutPanelBasket";
            this.flowLayoutPanelBasket.Size = new System.Drawing.Size(1156, 526);
            this.flowLayoutPanelBasket.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1124, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // panelUserBasket
            // 
            this.panelUserBasket.Controls.Add(this.pictureBoxActivated);
            this.panelUserBasket.Controls.Add(this.UserNameLabelBasket);
            this.panelUserBasket.Location = new System.Drawing.Point(0, 0);
            this.panelUserBasket.Name = "panelUserBasket";
            this.panelUserBasket.Size = new System.Drawing.Size(300, 32);
            this.panelUserBasket.TabIndex = 18;
            // 
            // pictureBoxActivated
            // 
            this.pictureBoxActivated.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxActivated.Image")));
            this.pictureBoxActivated.Location = new System.Drawing.Point(86, 3);
            this.pictureBoxActivated.Name = "pictureBoxActivated";
            this.pictureBoxActivated.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxActivated.TabIndex = 19;
            this.pictureBoxActivated.TabStop = false;
            // 
            // UserNameLabelBasket
            // 
            this.UserNameLabelBasket.AutoSize = true;
            this.UserNameLabelBasket.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserNameLabelBasket.Location = new System.Drawing.Point(1, 7);
            this.UserNameLabelBasket.Name = "UserNameLabelBasket";
            this.UserNameLabelBasket.Size = new System.Drawing.Size(0, 18);
            this.UserNameLabelBasket.TabIndex = 18;
            // 
            // labelTotal
            // 
            this.labelTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Segoe UI", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTotal.ForeColor = System.Drawing.Color.Black;
            this.labelTotal.Location = new System.Drawing.Point(95, 588);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(80, 31);
            this.labelTotal.TabIndex = 24;
            this.labelTotal.Text = "Итого:";
            // 
            // labelPrice
            // 
            this.labelPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(100)))), ((int)(((byte)(90)))));
            this.labelPrice.Location = new System.Drawing.Point(192, 589);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(69, 28);
            this.labelPrice.TabIndex = 25;
            this.labelPrice.Text = "Прайс";
            // 
            // buttonCheckout
            // 
            this.buttonCheckout.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCheckout.Location = new System.Drawing.Point(810, 578);
            this.buttonCheckout.Name = "buttonCheckout";
            this.buttonCheckout.Size = new System.Drawing.Size(122, 34);
            this.buttonCheckout.TabIndex = 26;
            this.buttonCheckout.Text = "Оформить заказ";
            this.buttonCheckout.UseVisualStyleBackColor = true;
            this.buttonCheckout.Click += new System.EventHandler(this.buttonCheckout_Click);
            // 
            // Basket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1156, 650);
            this.Controls.Add(this.buttonCheckout);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.panelUserBasket);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panelBasketItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Basket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Basket";
            this.panelBasketItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelUserBasket.ResumeLayout(false);
            this.panelUserBasket.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxActivated)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBasketItems;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBasket;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelUserBasket;
        private System.Windows.Forms.PictureBox pictureBoxActivated;
        private System.Windows.Forms.Label UserNameLabelBasket;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Button buttonCheckout;
    }
}