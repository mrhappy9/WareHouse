namespace Course1
{
    partial class BooksControl
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
            this.pictureBoxBooks = new System.Windows.Forms.PictureBox();
            this.comboQuantityBooks = new System.Windows.Forms.ComboBox();
            this.labelBooksPrice = new System.Windows.Forms.Label();
            this.labelQuantityBooks = new System.Windows.Forms.Label();
            this.labelNameAuthor = new System.Windows.Forms.Label();
            this.labelNameBook = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxBooks
            // 
            this.pictureBoxBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxBooks.Location = new System.Drawing.Point(12, 13);
            this.pictureBoxBooks.Name = "pictureBoxBooks";
            this.pictureBoxBooks.Size = new System.Drawing.Size(127, 135);
            this.pictureBoxBooks.TabIndex = 13;
            this.pictureBoxBooks.TabStop = false;
            // 
            // comboQuantityBooks
            // 
            this.comboQuantityBooks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboQuantityBooks.DropDownHeight = 70;
            this.comboQuantityBooks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboQuantityBooks.DropDownWidth = 30;
            this.comboQuantityBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboQuantityBooks.FormattingEnabled = true;
            this.comboQuantityBooks.IntegralHeight = false;
            this.comboQuantityBooks.Location = new System.Drawing.Point(738, 70);
            this.comboQuantityBooks.Name = "comboQuantityBooks";
            this.comboQuantityBooks.Size = new System.Drawing.Size(44, 24);
            this.comboQuantityBooks.TabIndex = 12;
            this.comboQuantityBooks.DropDownClosed += new System.EventHandler(this.comboQuantityBooks_DropDownClosed);
            // 
            // labelBooksPrice
            // 
            this.labelBooksPrice.AutoSize = true;
            this.labelBooksPrice.Font = new System.Drawing.Font("Segoe UI", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBooksPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(100)))), ((int)(((byte)(90)))));
            this.labelBooksPrice.Location = new System.Drawing.Point(853, 67);
            this.labelBooksPrice.Name = "labelBooksPrice";
            this.labelBooksPrice.Size = new System.Drawing.Size(68, 31);
            this.labelBooksPrice.TabIndex = 11;
            this.labelBooksPrice.Text = "Цена";
            // 
            // labelQuantityBooks
            // 
            this.labelQuantityBooks.AutoSize = true;
            this.labelQuantityBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelQuantityBooks.Location = new System.Drawing.Point(687, 73);
            this.labelQuantityBooks.Name = "labelQuantityBooks";
            this.labelQuantityBooks.Size = new System.Drawing.Size(42, 18);
            this.labelQuantityBooks.TabIndex = 10;
            this.labelQuantityBooks.Text = "n шт.";
            // 
            // labelNameAuthor
            // 
            this.labelNameAuthor.AutoSize = true;
            this.labelNameAuthor.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNameAuthor.Location = new System.Drawing.Point(144, 95);
            this.labelNameAuthor.Name = "labelNameAuthor";
            this.labelNameAuthor.Size = new System.Drawing.Size(147, 23);
            this.labelNameAuthor.TabIndex = 9;
            this.labelNameAuthor.Text = "Название Автора";
            // 
            // labelNameBook
            // 
            this.labelNameBook.AutoSize = true;
            this.labelNameBook.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNameBook.Location = new System.Drawing.Point(142, 49);
            this.labelNameBook.Name = "labelNameBook";
            this.labelNameBook.Size = new System.Drawing.Size(165, 30);
            this.labelNameBook.TabIndex = 8;
            this.labelNameBook.Text = "Название книги";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 165);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1156, 1);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1156, 1);
            this.panel2.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 165);
            this.panel3.TabIndex = 15;
            // 
            // BooksControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBoxBooks);
            this.Controls.Add(this.comboQuantityBooks);
            this.Controls.Add(this.labelBooksPrice);
            this.Controls.Add(this.labelQuantityBooks);
            this.Controls.Add(this.labelNameAuthor);
            this.Controls.Add(this.labelNameBook);
            this.Name = "BooksControl";
            this.Size = new System.Drawing.Size(1156, 166);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBooks;
        private System.Windows.Forms.ComboBox comboQuantityBooks;
        private System.Windows.Forms.Label labelBooksPrice;
        private System.Windows.Forms.Label labelQuantityBooks;
        private System.Windows.Forms.Label labelNameAuthor;
        private System.Windows.Forms.Label labelNameBook;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}
