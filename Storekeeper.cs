using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course1
{
    public partial class Storekeeper : Form
    {
        public Storekeeper(Form mainForm)
        {
            InitializeComponent();
            mForm = mainForm;
        }
        Form mForm;
        WorkServer workServerStore = new WorkServer();
        private Color defualtColor = Color.FromArgb(21, 21, 21);
        private string[] getNormalQuantityItems()
        {
            string[] quantity = new string[501];
            for (int i = 0; i < quantity.Length; i++)
            {
                quantity[i] = i.ToString();
            }
            return quantity;
        }
        private bool stringFields(params string[] field)
        {
            for (int i = 0; i < field.Length; i++)
            {
                if (field[i] == "")
                {
                    return false;
                }
            }
            return true;
        }
        private bool clearPriceAndQuantity(string textPrice, int comboQuantityBooks)
        {
            if (int.TryParse(textPrice, out int result) && comboQuantityBooks > 0)
                return true;
            return false;
        }
        private void setNonVisiblePanels()
        {
            //////////////ADD PANELS and ITEMS////////////////
            panelMenuAdd.Visible = false;
            panelBooksAdd.Visible = false;
            panelClothesAdd.Visible = false;
            panelPcsLaptopsAdd.Visible = false;
            panelHPhonesAdd.Visible = false;
            panelTvsAdd.Visible = false;
            //////////////DELETE PANELS and ITEMS////////////////
            panelMenuDelete.Visible = false;
        }
        private void setVisiblePanel(params Panel[] panels)
        {
            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].Visible = true;
            }
        }
        private void changeItemsColor(PictureBox picture, Panel panel)
        {
            picture.BackColor = Color.FromArgb(28, 28, 28);
            panel.BackColor = Color.FromArgb(28, 28, 28);
        }
        private void setDefaultItemsColor()
        {
            panelAdd.BackColor = panelDelete.BackColor =
            pictureBoxAdd.BackColor = pictureBoxDelete.BackColor = defualtColor;
        }
        private void Storekeeper_Load(object sender, EventArgs e)
        {
            setNonVisiblePanels();
        }

        private void labelAdd_Click(object sender, EventArgs e)
        {
            panelMenuDelete.Visible = false;
            setDefaultItemsColor();
            /*setNonVisiblePanels(Deletpanel, delete menu, listtable)*/   // Вернуться и исправить
            changeItemsColor(pictureBoxAdd, panelAdd);
            setVisiblePanel(panelMenuAdd);
        }
        private void booksMenuItem_Click(object sender, EventArgs e)
        {
            panelClothesAdd.Visible = false;
            panelPcsLaptopsAdd.Visible = false;
            panelHPhonesAdd.Visible = false;
            panelTvsAdd.Visible = false;
        }
        private void bookNameTableForAddingClick(object sender, EventArgs e)
        {
            labelNameBookTable.Text = ((ToolStripMenuItem)sender).Tag.ToString();
            setVisiblePanel(panelBooksAdd);
            comboQuantityBooks.Items.AddRange(getNormalQuantityItems());
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            void clearTextBoxes()
            {
                textNameBook.Text = "";
                textAuthor.Text = "";
                textPrice.Text = "";
                comboQuantityBooks.SelectedIndex = -1;
            }
            if (stringFields(textNameBook.Text, textAuthor.Text) && clearPriceAndQuantity(textPrice.Text, comboQuantityBooks.SelectedIndex))
            {
                if (MessageBox.Show("Вы уверены, что хотите продолжить?", "Добавление записи",
                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    workServerStore.newBookRecordOnTable(labelNameBookTable.Text, textNameBook.Text, textAuthor.Text,
                                                         Convert.ToInt32(textPrice.Text), Convert.ToInt32(comboQuantityBooks.Text));
                    clearTextBoxes();
                    setNonVisiblePanels();
                    setDefaultItemsColor();
                    MessageBox.Show("Запись успешно добавлена");
                }
            }
            else
            {
                MessageBox.Show("Вы допустили ошибку при вводе данных", "Внимание");
            }
        }

        private void clothesMenuItem_Click(object sender, EventArgs e)
        {
            panelBooksAdd.Visible = false;
            panelPcsLaptopsAdd.Visible = false;
            panelHPhonesAdd.Visible = false;
            panelTvsAdd.Visible = false;
        }
        private void clothesNameTableForAddingClick(object sender, EventArgs e)
        {
            labelNameClothesTable.Text = ((ToolStripMenuItem)sender).Tag.ToString();
            setVisiblePanel(panelClothesAdd);
            comboClothesQuantity.Items.AddRange(getNormalQuantityItems());
        }
        private void buttonClothesAdd_Click(object sender, EventArgs e)
        {
            void clearTextBoxes()
            {
                textClothesName.Text = "";
                textBrandClothes.Text = "";
                textMaterialClothes.Text = "";
                textClothesPrice.Text = "";
                comboClothesSex.SelectedIndex = -1;
                comboClothesQuantity.SelectedIndex = -1;
            }
            if (stringFields(textClothesName.Text, textBrandClothes.Text, textMaterialClothes.Text, comboClothesSex.Text)
               && clearPriceAndQuantity(textClothesPrice.Text, comboClothesQuantity.SelectedIndex))
            {
                if (MessageBox.Show("Вы уверены, что хотите продолжить?", "Добавление записи",
                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    workServerStore.newClothesRecordOnTable(labelNameClothesTable.Text, textClothesName.Text, textBrandClothes.Text, textMaterialClothes.Text,
                                                            comboClothesSex.Text, Convert.ToInt32(textClothesPrice.Text), Convert.ToInt32(comboClothesQuantity.Text));
                    clearTextBoxes();
                    setNonVisiblePanels();
                    setDefaultItemsColor();
                    MessageBox.Show("Запись успешно добавлена");
                }
            }
            else
            {
                MessageBox.Show("Вы допустили ошибку при вводе данных", "Внимание");
            }
        }

        private void electroMenuItem_Click(object sender, EventArgs e)
        {
            panelClothesAdd.Visible = false;
            panelBooksAdd.Visible = false;
        }
        private void pcsLaptopsNameTableForAddingClick(object sender, EventArgs e)
        {
            panelHPhonesAdd.Visible = false;
            panelTvsAdd.Visible = false;
            labelPcsLaptopsNameTable.Text = ((ToolStripMenuItem)sender).Tag.ToString();
            setVisiblePanel(panelPcsLaptopsAdd);
            comboPcsLaptopsQuantity.Items.AddRange(getNormalQuantityItems());
        }

        private void buttonPcsLaptopsAdd_Click(object sender, EventArgs e)
        {
            void clearTextBoxes()
            {
                textPcsLaptopsCPU.Text = "";
                textPcsLaptopsRAM.Text = "";
                textPcsLaptopsGPU.Text = "";
                textPcsLaptopsOS.Text = "";
                textPcsLaptopsName.Text = "";
                textPcsLaptopsSSD.Text = "";
                textPcsLaptopsPrice.Text = "";
                comboPcsLaptopsQuantity.SelectedIndex = -1;
            }
            if (stringFields(textPcsLaptopsName.Text, textPcsLaptopsCPU.Text, textPcsLaptopsGPU.Text, textPcsLaptopsOS.Text)
               && clearPriceAndQuantity(textPcsLaptopsPrice.Text, comboPcsLaptopsQuantity.SelectedIndex) 
               && int.TryParse(textPcsLaptopsRAM.Text, out int result) && int.TryParse(textPcsLaptopsSSD.Text, out int res))
            {
                if (MessageBox.Show("Вы уверены, что хотите продолжить?", "Добавление записи",
                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    workServerStore.newPcsLaptopsRecordOnTable(labelPcsLaptopsNameTable.Text, textPcsLaptopsName.Text, textPcsLaptopsCPU.Text,
                                                               Convert.ToInt32(textPcsLaptopsRAM.Text), Convert.ToInt32(textPcsLaptopsSSD.Text),
                                                               textPcsLaptopsGPU.Text, textPcsLaptopsOS.Text,
                                                               Convert.ToInt32(textPcsLaptopsPrice.Text), Convert.ToInt32(comboPcsLaptopsQuantity.Text));
                    clearTextBoxes();
                    setNonVisiblePanels();
                    setDefaultItemsColor();
                    MessageBox.Show("Запись успешно добавлена");
                }
            }
            else
            {
                MessageBox.Show("Вы допустили ошибку при вводе данных", "Внимание");
            }
        }

        private void hPhonesNameTableForAddingClick(object sender, EventArgs e)
        {
            panelPcsLaptopsAdd.Visible = false;
            panelTvsAdd.Visible = false;
            labelHPhonesNameTable.Text = ((ToolStripMenuItem)sender).Tag.ToString();
            setVisiblePanel(panelHPhonesAdd);
            comboHPhonesQuantity.Items.AddRange(getNormalQuantityItems());
        }

        private void buttonHPhonesAdd_Click(object sender, EventArgs e)
        {
            void clearTextBoxes()
            {
                textHPhonesName.Text = "";
                textHPhonesResistance.Text = "";
                textHPhonesHours.Text = "";
                textHPhonesType.Text = "";
                textHPhonesPrice.Text = "";
                comboHPhonesMic.SelectedIndex = -1;
                comboHPhonesQuantity.SelectedIndex = -1;
            }
            if (stringFields(textHPhonesName.Text, textHPhonesType.Text) && comboHPhonesMic.SelectedIndex > -1
               && clearPriceAndQuantity(textHPhonesPrice.Text, comboHPhonesQuantity.SelectedIndex)
               && int.TryParse(textHPhonesResistance.Text, out int result) && int.TryParse(textHPhonesHours.Text, out int res))
            {
                if (MessageBox.Show("Вы уверены, что хотите продолжить?", "Добавление записи",
                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    workServerStore.newHPhonesRecordOnTable(labelHPhonesNameTable.Text, textHPhonesName.Text, comboHPhonesMic.Text, textHPhonesType.Text,
                                                               Convert.ToInt32(textHPhonesHours.Text), Convert.ToInt32(textHPhonesResistance.Text),
                                                               Convert.ToInt32(textHPhonesPrice.Text), Convert.ToInt32(comboHPhonesQuantity.Text));
                    clearTextBoxes();
                    setNonVisiblePanels();
                    setDefaultItemsColor();
                    MessageBox.Show("Запись успешно добавлена");
                }
            }
            else
            {
                MessageBox.Show("Вы допустили ошибку при вводе данных", "Внимание");
            }
        }
        private void tvsNameTableForAddingClick(object sender, EventArgs e)
        {
            panelPcsLaptopsAdd.Visible = false;
            panelHPhonesAdd.Visible = false;
            labelTvsNameTable.Text = ((ToolStripMenuItem)sender).Tag.ToString();
            setVisiblePanel(panelTvsAdd);
            comboTvsQuantity.Items.AddRange(getNormalQuantityItems());
        }

        private void buttonTvsAdd_Click(object sender, EventArgs e)
        {
            void clearTextBoxes()
            {
                textTvsName.Text = "";
                textTvsDiagonal.Text = "";
                textTvsFeatures.Text = "";
                textTvsResolution.Text = "";
                textTvsPrice.Text = "";
                comboTvsQuantity.SelectedIndex = -1;
            }
            if (stringFields(textTvsName.Text, textTvsFeatures.Text, textTvsResolution.Text)
               && clearPriceAndQuantity(textTvsPrice.Text, comboTvsQuantity.SelectedIndex)
               && double.TryParse(textTvsDiagonal.Text, out double result))
            {
                if (MessageBox.Show("Вы уверены, что хотите продолжить?", "Добавление записи",
                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    workServerStore.newTvsRecordOnTable(labelTvsNameTable.Text, textTvsName.Text, Convert.ToDouble(textTvsDiagonal.Text), 
                                                        textTvsResolution.Text, textTvsFeatures.Text,
                                                        Convert.ToInt32(textTvsPrice.Text), Convert.ToInt32(comboTvsQuantity.Text));
                    clearTextBoxes();
                    setNonVisiblePanels();
                    setDefaultItemsColor();
                    MessageBox.Show("Запись успешно добавлена");
                }
            }
            else
            {
                MessageBox.Show("Вы допустили ошибку при вводе данных", "Внимание");
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////Delete panel and Items
        ////////////////////////////////////////////////////////////////////////////////////////////////
        private void deleteLabel_Click(object sender, EventArgs e)
        {
            panelMenuAdd.Visible = false;
            setDefaultItemsColor();
            changeItemsColor(pictureBoxDelete, panelDelete);
            setVisiblePanel(panelMenuDelete);
        }

        private void fillUpItemsForDelete(string nameTable, ToolStripMenuItem Item)
        {
            List<String> items = workServerStore.getItemNames(nameTable);
            if (items.Count != Item.DropDownItems.Count)
            {
                Item.DropDownItems.Clear();
                for (int i = 0; i < items.Count; i++)
                {
                    Item.DropDownItems.Add(items[i]);
                    Item.DropDownItems[i].Tag = nameTable;
                    Item.DropDownItems[i].Click += new EventHandler(ItemToBeDeletedClick);
                }
            }
        }
        private void ItemToBeDeletedClick(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Вы уверены, что хотите удалить {((ToolStripMenuItem)sender).Text}?", "Удаление записи",
                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string deletedRecord = ((ToolStripMenuItem)sender).Text;
                workServerStore.deleteItem(((ToolStripMenuItem)sender).Tag.ToString(), ((ToolStripMenuItem)sender).Text);
                MessageBox.Show($"Была удалена запись {deletedRecord}", "Удалено");
            }
        }
        private void fillUpBooksToBeDeleted(object sender, EventArgs e)
        {
            fillUpItemsForDelete(((ToolStripMenuItem)sender).Tag.ToString(), ((ToolStripMenuItem)sender));
        }
        private void fillItemsToBeDeleted(object sender, EventArgs e)
        {
            fillUpItemsForDelete(((ToolStripMenuItem)sender).Tag.ToString(), ((ToolStripMenuItem)sender));
        }
    }
}
