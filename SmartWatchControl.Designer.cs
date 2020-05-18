namespace Course1
{
    partial class SmartWatchControl
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
            this.comboQuantitySmartWatch = new System.Windows.Forms.ComboBox();
            this.labelQuantitySmartWatch = new System.Windows.Forms.Label();
            this.labelPriceSmartWatch = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelResolution = new System.Windows.Forms.Label();
            this.labelCompatibleOS = new System.Windows.Forms.Label();
            this.labelNameSmartWatch = new System.Windows.Forms.Label();
            this.pictureBoxSmartWatch = new System.Windows.Forms.PictureBox();
            this.labelSensors = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSmartWatch)).BeginInit();
            this.SuspendLayout();
            // 
            // comboQuantitySmartWatch
            // 
            this.comboQuantitySmartWatch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboQuantitySmartWatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboQuantitySmartWatch.DropDownHeight = 70;
            this.comboQuantitySmartWatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboQuantitySmartWatch.DropDownWidth = 30;
            this.comboQuantitySmartWatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboQuantitySmartWatch.FormattingEnabled = true;
            this.comboQuantitySmartWatch.IntegralHeight = false;
            this.comboQuantitySmartWatch.Location = new System.Drawing.Point(752, 65);
            this.comboQuantitySmartWatch.Name = "comboQuantitySmartWatch";
            this.comboQuantitySmartWatch.Size = new System.Drawing.Size(44, 24);
            this.comboQuantitySmartWatch.TabIndex = 67;
            this.comboQuantitySmartWatch.DropDownClosed += new System.EventHandler(this.comboQuantitySmartWatch_DropDownClosed);
            // 
            // labelQuantitySmartWatch
            // 
            this.labelQuantitySmartWatch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelQuantitySmartWatch.AutoSize = true;
            this.labelQuantitySmartWatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelQuantitySmartWatch.Location = new System.Drawing.Point(691, 66);
            this.labelQuantitySmartWatch.Name = "labelQuantitySmartWatch";
            this.labelQuantitySmartWatch.Size = new System.Drawing.Size(42, 18);
            this.labelQuantitySmartWatch.TabIndex = 66;
            this.labelQuantitySmartWatch.Text = "n шт.";
            // 
            // labelPriceSmartWatch
            // 
            this.labelPriceSmartWatch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPriceSmartWatch.AutoSize = true;
            this.labelPriceSmartWatch.Font = new System.Drawing.Font("Segoe UI", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPriceSmartWatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(100)))), ((int)(((byte)(90)))));
            this.labelPriceSmartWatch.Location = new System.Drawing.Point(832, 56);
            this.labelPriceSmartWatch.Name = "labelPriceSmartWatch";
            this.labelPriceSmartWatch.Size = new System.Drawing.Size(68, 31);
            this.labelPriceSmartWatch.TabIndex = 65;
            this.labelPriceSmartWatch.Text = "Цена";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(291, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "Разрешение";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(147, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Совместимые ОС";
            // 
            // labelResolution
            // 
            this.labelResolution.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelResolution.AutoSize = true;
            this.labelResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelResolution.Location = new System.Drawing.Point(292, 121);
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new System.Drawing.Size(90, 16);
            this.labelResolution.TabIndex = 60;
            this.labelResolution.Text = "Разрешение";
            // 
            // labelCompatibleOS
            // 
            this.labelCompatibleOS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCompatibleOS.AutoSize = true;
            this.labelCompatibleOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCompatibleOS.Location = new System.Drawing.Point(147, 121);
            this.labelCompatibleOS.Name = "labelCompatibleOS";
            this.labelCompatibleOS.Size = new System.Drawing.Size(120, 16);
            this.labelCompatibleOS.TabIndex = 59;
            this.labelCompatibleOS.Text = "Совместимые ОС";
            // 
            // labelNameSmartWatch
            // 
            this.labelNameSmartWatch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNameSmartWatch.AutoSize = true;
            this.labelNameSmartWatch.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNameSmartWatch.Location = new System.Drawing.Point(145, 13);
            this.labelNameSmartWatch.Name = "labelNameSmartWatch";
            this.labelNameSmartWatch.Size = new System.Drawing.Size(235, 30);
            this.labelNameSmartWatch.TabIndex = 58;
            this.labelNameSmartWatch.Text = "Название умных часов";
            // 
            // pictureBoxSmartWatch
            // 
            this.pictureBoxSmartWatch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSmartWatch.Location = new System.Drawing.Point(12, 13);
            this.pictureBoxSmartWatch.Name = "pictureBoxSmartWatch";
            this.pictureBoxSmartWatch.Size = new System.Drawing.Size(127, 135);
            this.pictureBoxSmartWatch.TabIndex = 57;
            this.pictureBoxSmartWatch.TabStop = false;
            // 
            // labelSensors
            // 
            this.labelSensors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSensors.AutoSize = true;
            this.labelSensors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSensors.Location = new System.Drawing.Point(406, 121);
            this.labelSensors.Name = "labelSensors";
            this.labelSensors.Size = new System.Drawing.Size(63, 16);
            this.labelSensors.TabIndex = 61;
            this.labelSensors.Text = "Датчики";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(409, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "Датчики";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1156, 1);
            this.flowLayoutPanel1.TabIndex = 68;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 166);
            this.panel1.TabIndex = 69;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(0, 165);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1156, 1);
            this.panel2.TabIndex = 70;
            // 
            // SmartWatchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.comboQuantitySmartWatch);
            this.Controls.Add(this.labelQuantitySmartWatch);
            this.Controls.Add(this.labelPriceSmartWatch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelSensors);
            this.Controls.Add(this.labelResolution);
            this.Controls.Add(this.labelCompatibleOS);
            this.Controls.Add(this.labelNameSmartWatch);
            this.Controls.Add(this.pictureBoxSmartWatch);
            this.Name = "SmartWatchControl";
            this.Size = new System.Drawing.Size(1156, 166);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSmartWatch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboQuantitySmartWatch;
        private System.Windows.Forms.Label labelQuantitySmartWatch;
        private System.Windows.Forms.Label labelPriceSmartWatch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelResolution;
        private System.Windows.Forms.Label labelCompatibleOS;
        private System.Windows.Forms.Label labelNameSmartWatch;
        private System.Windows.Forms.PictureBox pictureBoxSmartWatch;
        private System.Windows.Forms.Label labelSensors;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
