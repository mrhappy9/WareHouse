namespace Course1
{
    partial class ClothesControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.labelSex = new System.Windows.Forms.Label();
            this.comboQuantityClothes = new System.Windows.Forms.ComboBox();
            this.labelQuantityClothes = new System.Windows.Forms.Label();
            this.labelPriceClothes = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelMaterial = new System.Windows.Forms.Label();
            this.labelBrand = new System.Windows.Forms.Label();
            this.labelNameClothes = new System.Windows.Forms.Label();
            this.pictureBoxClothes = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClothes)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(330, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "Пол";
            // 
            // labelSex
            // 
            this.labelSex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSex.AutoSize = true;
            this.labelSex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSex.Location = new System.Drawing.Point(331, 119);
            this.labelSex.Name = "labelSex";
            this.labelSex.Size = new System.Drawing.Size(34, 16);
            this.labelSex.TabIndex = 94;
            this.labelSex.Text = "Пол";
            // 
            // comboQuantityClothes
            // 
            this.comboQuantityClothes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboQuantityClothes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboQuantityClothes.DropDownHeight = 70;
            this.comboQuantityClothes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboQuantityClothes.DropDownWidth = 30;
            this.comboQuantityClothes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboQuantityClothes.FormattingEnabled = true;
            this.comboQuantityClothes.IntegralHeight = false;
            this.comboQuantityClothes.Location = new System.Drawing.Point(752, 63);
            this.comboQuantityClothes.Name = "comboQuantityClothes";
            this.comboQuantityClothes.Size = new System.Drawing.Size(44, 24);
            this.comboQuantityClothes.TabIndex = 93;
            this.comboQuantityClothes.DropDownClosed += new System.EventHandler(this.comboQuantityClothes_DropDownClosed);
            // 
            // labelQuantityClothes
            // 
            this.labelQuantityClothes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelQuantityClothes.AutoSize = true;
            this.labelQuantityClothes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelQuantityClothes.Location = new System.Drawing.Point(691, 64);
            this.labelQuantityClothes.Name = "labelQuantityClothes";
            this.labelQuantityClothes.Size = new System.Drawing.Size(42, 18);
            this.labelQuantityClothes.TabIndex = 92;
            this.labelQuantityClothes.Text = "n шт.";
            // 
            // labelPriceClothes
            // 
            this.labelPriceClothes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPriceClothes.AutoSize = true;
            this.labelPriceClothes.Font = new System.Drawing.Font("Segoe UI", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPriceClothes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(100)))), ((int)(((byte)(90)))));
            this.labelPriceClothes.Location = new System.Drawing.Point(832, 54);
            this.labelPriceClothes.Name = "labelPriceClothes";
            this.labelPriceClothes.Size = new System.Drawing.Size(68, 31);
            this.labelPriceClothes.TabIndex = 91;
            this.labelPriceClothes.Text = "Цена";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(147, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 89;
            this.label3.Text = "Материал";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(147, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 88;
            this.label1.Text = "Бренд";
            // 
            // labelMaterial
            // 
            this.labelMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMaterial.AutoSize = true;
            this.labelMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMaterial.Location = new System.Drawing.Point(148, 119);
            this.labelMaterial.Name = "labelMaterial";
            this.labelMaterial.Size = new System.Drawing.Size(74, 16);
            this.labelMaterial.TabIndex = 86;
            this.labelMaterial.Text = "Материал";
            // 
            // labelBrand
            // 
            this.labelBrand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBrand.AutoSize = true;
            this.labelBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBrand.Location = new System.Drawing.Point(145, 67);
            this.labelBrand.Name = "labelBrand";
            this.labelBrand.Size = new System.Drawing.Size(49, 16);
            this.labelBrand.TabIndex = 85;
            this.labelBrand.Text = "Бренд";
            // 
            // labelNameClothes
            // 
            this.labelNameClothes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNameClothes.AutoSize = true;
            this.labelNameClothes.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNameClothes.Location = new System.Drawing.Point(145, 11);
            this.labelNameClothes.Name = "labelNameClothes";
            this.labelNameClothes.Size = new System.Drawing.Size(187, 30);
            this.labelNameClothes.TabIndex = 84;
            this.labelNameClothes.Text = "Название одежды";
            // 
            // pictureBoxClothes
            // 
            this.pictureBoxClothes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxClothes.Location = new System.Drawing.Point(12, 13);
            this.pictureBoxClothes.Name = "pictureBoxClothes";
            this.pictureBoxClothes.Size = new System.Drawing.Size(127, 135);
            this.pictureBoxClothes.TabIndex = 83;
            this.pictureBoxClothes.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 166);
            this.panel1.TabIndex = 96;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1156, 1);
            this.panel2.TabIndex = 97;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(0, 165);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1156, 1);
            this.panel3.TabIndex = 98;
            // 
            // ClothesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelSex);
            this.Controls.Add(this.comboQuantityClothes);
            this.Controls.Add(this.labelQuantityClothes);
            this.Controls.Add(this.labelPriceClothes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelMaterial);
            this.Controls.Add(this.labelBrand);
            this.Controls.Add(this.labelNameClothes);
            this.Controls.Add(this.pictureBoxClothes);
            this.Name = "ClothesControl";
            this.Size = new System.Drawing.Size(1156, 166);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClothes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelSex;
        private System.Windows.Forms.ComboBox comboQuantityClothes;
        private System.Windows.Forms.Label labelQuantityClothes;
        private System.Windows.Forms.Label labelPriceClothes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMaterial;
        private System.Windows.Forms.Label labelBrand;
        private System.Windows.Forms.Label labelNameClothes;
        private System.Windows.Forms.PictureBox pictureBoxClothes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}
