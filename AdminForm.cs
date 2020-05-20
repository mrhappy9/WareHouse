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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }
        private Color defualtColor = Color.FromArgb(21, 21, 21);
        WorkServer workServerAdmin = new WorkServer();

        private string[] getNormalQuantityItems() // For each Items from MySql tables
        {
            string[] quantity = new string[501];
            for (int i = 0; i < quantity.Length; i++)
            {
                quantity[i] = i.ToString();
            }
            return quantity;
        }
        private void setDefaultItemsColor() 
        {
            panelAddItem.BackColor = panelChange.BackColor = panelDelete.BackColor =
            pictureBoxAddItem.BackColor = pictureBoxChange.BackColor = pictureBoxDelete.BackColor = defualtColor;
        }

        private void setNonVisibleBookItemsVisible()
        {
            panelBookItems.Visible = false;
            buttonBookUpdate.Visible = false;
            buttonChangeBook.Visible = false;
        }
        private void setVisibleBookItemsVisible()
        {
            panelBookItems.Visible = true;
            panelBookItems.Enabled = false;
            buttonBookUpdate.Visible = true;
        }
        private void setEnableBookItems()
        {
            panelBookItems.Enabled = true;
            buttonBookUpdate.Visible = false;
            buttonChangeBook.Visible = true;
        }
        private void changeItemsColor(PictureBox picture, Panel panel)
        {
            picture.BackColor = Color.FromArgb(28, 28, 28);
            panel.BackColor = Color.FromArgb(28, 28, 28);
        }

        private void changeLabel_Click(object sender, EventArgs e)
        {
            setDefaultItemsColor();
            changeItemsColor(pictureBoxChange, panelChange);
        }

        private void addItemsLabel_Click(object sender, EventArgs e)
        {
            setDefaultItemsColor();
            changeItemsColor(pictureBoxAddItem, panelAddItem);
        }

        private void deleteLabel_Click(object sender, EventArgs e)
        {
            setDefaultItemsColor();
            changeItemsColor(pictureBoxDelete, panelDelete);
        }

        private void pictureBoxAdminClose_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
        }

        private void pictureBoxWareHouse_Click(object sender, EventArgs e)
        {
            setDefaultItemsColor();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            setNonVisibleBookItemsVisible();
        }
        ////////////////////////////
        //// Book's tables and Items
        ////////////////////////////
        private void childrenBooksMenuItem_Click(object sender, EventArgs e)
        {
            labelNameTable.Text = childrenBooksMenuItem.Tag.ToString();
        }

        private void humanSecretsMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = humanSecretsMenuItem.Text;
        }
        private void pinocchioMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = pinocchioMenuItem.Text;
        }

        private void harryPotterMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = harryPotterMenuItem.Text;
        }
        private void сhroniclesNarniaMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = cNarniaMenuItem.Text;
        }

        private void buttonBookUpdate_Click(object sender, EventArgs e)
        {
            List<String> books = workServerAdmin.getParticularBook(labelNameTable.Text, textNameBook.Text);
            textAuthor.Text = books[0];
            textPrice.Text = books[1];
            labelAddingQuantity.Text = books[2];
            comboQuantityBooks.Items.AddRange(getNormalQuantityItems());
            setEnableBookItems();
        }

        private void booksMenuItem_Click(object sender, EventArgs e)
        {
            setNonVisibleBookItemsVisible();
            textNameBook.Text = "";
            textAuthor.Text = "";
            textPrice.Text = "";
            labelAddingQuantity.Text = "";
        }

        private void buttonChangeBook_Click(object sender, EventArgs e)
        { 
            if(textAuthor.Text != "" && textPrice.Text != "" && comboQuantityBooks.SelectedIndex > 0
                && int.TryParse(textPrice.Text, out int result))
            {            
                if (MessageBox.Show("Вы уверены, что хотите продолжить?", "Обновление записи",
                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    workServerAdmin.updateBookTable(labelNameTable.Text, textNameBook.Text, textAuthor.Text, 
                                                    Convert.ToInt32(textPrice.Text),
                                                    Convert.ToInt32(comboQuantityBooks.SelectedIndex));
                    setNonVisibleBookItemsVisible();
                }
            }
            else
            {
                MessageBox.Show("Проверьте правильность написания данных", "Предупреждение");
            }
        }

        private void littlePrinceMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = littlePrinceMenuItem.Text;
        }

        private void headDoylMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = headDoylMenuItem.Text;
        }

        private void timurTeamMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = timurTeamMenuItem.Text;
        }

        private void whiteBimMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = whiteBimMenuItem.Text;
        }

        private void daggerMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = daggerMenuItem.Text;
        }

        private void gulliverMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = gulliverMenuItem.Text;
        }

        private void artBooksMenuItem_Click(object sender, EventArgs e)
        {
            labelNameTable.Text = artBooksMenuItem.Tag.ToString();
        }

        private void arkaMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = arkaMenuItem.Text;
        }

        private void farengateMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = farengateMenuItem.Text;
        }

        private void dorianMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = farengateMenuItem.Text;
        }

        private void dorianMenuItem_Click_1(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = dorianMenuItem.Text;
        }

        private void godFatherMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = godFatherMenuItem.Text;
        }

        private void shaverMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = shaverMenuItem.Text; 
        }

        private void greatGatsbyMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = greatGatsbyMenuItem.Text; 
        }

        private void foolishMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = foolishMenuItem.Text;
        }

        private void r1984MenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = r1984MenuItem.Text;
        }

        private void blacksMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = blacksMenuItem.Text; 
        }

        private void сherryOrchardMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = сherryOrchardMenuItem.Text; 
        }
        private void comicsBooksMenuItem_Click(object sender, EventArgs e)
        {
            labelNameTable.Text = comicsBooksMenuItem.Tag.ToString();
        }
        private void rikMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = rikMenuItem.Text; 
        }

        private void folzMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = folzMenuItem.Text; 
        }

        private void batmenMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = batmenMenuItem.Text; 
        }

        private void diedMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = diedMenuItem.Text; 
        }

        private void blacksadMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = blacksadMenuItem.Text; 
        }

        private void timeTripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = timeTripMenuItem.Text; 
        }

        private void wolverineMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = wolverineMenuItem.Text; 
        }

        private void spiderManMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = spiderManMenuItem.Text; 
        }

        private void superManMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = superManMenuItem.Text; 
        }

        private void mouseMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = mouseMenuItem.Text; 
        }

        private void textBooksMenuItem_Click(object sender, EventArgs e)
        {
            labelNameTable.Text = textBooksMenuItem.Tag.ToString();
        }

        private void historyRusMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = historyRusMenuItem.Text; 
        }

        private void bioChMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = bioChMenuItem.Text; 
        }

        private void dMathMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = dMathMenuItem.Text; 
        }

        private void cosmetologyMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = cosmetologyMenuItem.Text; 
        }

        private void compositionMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = compositionMenuItem.Text; 
        }

        private void phyMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = phyMenuItem.Text; 
        }

        private void pharmacologyMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = pharmacologyMenuItem.Text; 
        }

        private void byhMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = byhMenuItem.Text; 
        }

        private void teraphyMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = teraphyMenuItem.Text; 
        }

        private void speechMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = speechMenuItem.Text; 
        }

        private void diffBooksMenuItem_Click(object sender, EventArgs e)
        {
            labelNameTable.Text = diffBooksMenuItem.Tag.ToString();
        }

        private void gvMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = gvMenuItem.Text; 
        }

        private void chillMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = chillMenuItem.Text; 
        }

        private void magicCleanMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = magicCleanMenuItem.Text; 
        }

        private void shitMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = shitMenuItem.Text; 
        }

        private void doNoРarmMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = doNoРarmMenuItem.Text; 
        }

        private void runAwayMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = runAwayMenuItem.Text; 
        }

        private void stiveMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = stiveMenuItem.Text; 
        }

        private void algorithmMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = algorithmMenuItem.Text; 
        }

        private void manipMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = manipMenuItem.Text; 
        }

        private void moneyStreamMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = moneyStreamMenuItem.Text; 
        }

        private void foreignBooksMenuItem_Click(object sender, EventArgs e)
        {
            labelNameTable.Text = foreignBooksMenuItem.Tag.ToString();
        }

        private void theMisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = theMisterToolStripMenuItem.Text;
        }

        private void theClockmakersDaughterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = theClockmakersDaughterToolStripMenuItem.Text; 
        }

        private void batmanMenuItem1_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = batmanMenuItem1.Text; 
        }

        private void pSIStillLoveYouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = pSIStillLoveYouToolStripMenuItem.Text; 
        }

        private void murakami2020DiaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = murakami2020DiaryToolStripMenuItem.Text; 
        }

        private void senseAndSensibilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = senseAndSensibilityToolStripMenuItem.Text; 
        }

        private void theAdventuresOfHuckleberryFinnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = theAdventuresOfHuckleberryFinnToolStripMenuItem.Text; 
        }

        private void aClashOfKingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = aClashOfKingsToolStripMenuItem.Text; 
        }

        private void wutheringHeightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = wutheringHeightsToolStripMenuItem.Text; 
        }

        private void theExploitsOfMoominpappaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleBookItemsVisible();
            textNameBook.Text = theExploitsOfMoominpappaToolStripMenuItem.Text; 
        }
    }
}
