﻿using System;
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

        ManageBook manageBookForUsers;

        private Color defualtColor = Color.FromArgb(21, 21, 21);
        WorkServer workServerAdmin = new WorkServer();

        private void panelMenuVisible()
        {
            panelMenu.Visible = true;
        }

        private void panelMenuNonVisible()
        {
            panelMenu.Visible = false;
        }
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
            panelUsersItem.BackColor = panelChange.BackColor = panelDelete.BackColor =
            pictureBoxUsersItem.BackColor = pictureBoxChange.BackColor = pictureBoxDelete.BackColor = defualtColor;
        }

        private void setNonVisibleItemsVisible()
        {
            //books items
            panelBookItems.Visible = false;
            buttonBookUpdate.Visible = false;
            buttonChangeBook.Visible = false;

            //clothes items
            panelClothesItems.Visible = false;
            buttonClothesChange.Visible = false;
            buttonClothesUpdate.Visible = false;

            //pcs&laptos items
            panelPcsLaptops.Visible = false;
            buttonPcsLaptopsUpdate.Visible = false;
            buttonPcsLaptopsChange.Visible = false;

            //hPhones items
            panelhPhonesItems.Visible = false;
            buttonhPhonesUpdate.Visible = false;
            buttonhPhonesChange.Visible = false;

            //tvs items
            panelTvsItems.Visible = false;
            buttonTvsChange.Visible = false;
            buttonTvsUpdate.Visible = false;
        }
        // book items
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
        // end book items

        //clothes items
        private void setVisibleClothesItemsVisible()
        {
            panelClothesItems.Visible = true;
            panelClothesItems.Enabled = false;
            buttonClothesUpdate.Visible = true;
        }
        private void setEnableClothesItems()
        {
            panelClothesItems.Enabled = true;
            buttonClothesUpdate.Visible = false;
            buttonClothesChange.Visible = true;
        }
        //end clothes items

        // pcs&laptops items
        private void setVisiblePcsLaptopsItems()
        {
            panelPcsLaptops.Visible = true;
            panelPcsLaptops.Enabled = false;
            buttonPcsLaptopsUpdate.Visible = true;
        }
        private void setEnablePcsLaptopsItems()
        {
            panelPcsLaptops.Enabled = true;
            buttonPcsLaptopsUpdate.Visible = false;
            buttonPcsLaptopsChange.Visible = true;
        }
        //end pcs&laptops items

        //hPhones  items
        private void setVisibleHPhonesItems()
        {
            panelhPhonesItems.Visible = true;
            panelhPhonesItems.Enabled = false;
            buttonhPhonesUpdate.Visible = true;
        }
        private void setEnableHPhonesItems()
        {
            panelhPhonesItems.Enabled = true;
            buttonhPhonesUpdate.Visible = false;
            buttonhPhonesChange.Visible = true;
        }
        //end hPhones items

        //tvs  items
        private void setVisibleTvsItems()
        {
            panelTvsItems.Visible = true;
            panelTvsItems.Enabled = false;
            buttonTvsUpdate.Visible = true;
        }
        private void setEnableTvsItems()
        {
            panelTvsItems.Enabled = true;
            buttonTvsUpdate.Visible = false;
            buttonTvsChange.Visible = true;
        }
        //end tvs items
        private void changeItemsColor(PictureBox picture, Panel panel)
        {
            picture.BackColor = Color.FromArgb(28, 28, 28);
            panel.BackColor = Color.FromArgb(28, 28, 28);
        }

        private void changeLabel_Click(object sender, EventArgs e)
        {
            panelMenuVisible();
            setDefaultItemsColor();
            changeItemsColor(pictureBoxChange, panelChange);
        }

        private void usersItemsLabel_Click(object sender, EventArgs e)
        {
            panelMenuNonVisible();
            setDefaultItemsColor();
            changeItemsColor(pictureBoxUsersItem, panelUsersItem);
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
            panelMenuNonVisible();
            setDefaultItemsColor();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            panelMenuNonVisible();
            setNonVisibleItemsVisible();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //// Book's tables and Items
        ////////////////////////////////////////////////////////////////////////////////////////////////////
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
            setNonVisibleItemsVisible();
            textNameBook.Text = "";
            textAuthor.Text = "";
            textPrice.Text = "";
            labelAddingQuantity.Text = "";
        }

        private void buttonChangeBook_Click(object sender, EventArgs e)
        {
            if (textAuthor.Text != "" && textPrice.Text != "" && comboQuantityBooks.SelectedIndex > 0
                && int.TryParse(textPrice.Text, out int result))
            {
                if (MessageBox.Show("Вы уверены, что хотите продолжить?", "Обновление записи",
                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    workServerAdmin.updateBookTable(labelNameTable.Text, textNameBook.Text, textAuthor.Text,
                                                    Convert.ToInt32(textPrice.Text),
                                                    Convert.ToInt32(comboQuantityBooks.SelectedIndex));
                    setNonVisibleItemsVisible();
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///          END Books Items
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///          Start Clothes Items
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void clothesMenuItem_Click(object sender, EventArgs e)
        {
            setNonVisibleItemsVisible();
            textClothesBrand.Text = "";
            textClothesMaterial.Text = "";
            textClothesPrice.Text = "";
            labelClothesAddingQuantity.Text = "";
        }

        private void shoesMenuItem_Click(object sender, EventArgs e)
        {
            labelClothesNameTable.Text = shoesMenuItem.Tag.ToString();
        }

        private void buttonClothesUpdate_Click(object sender, EventArgs e)
        {
            int defineSex(string sex)
            {
                if (sex == "Мужской")
                    return 0;
                return 1;
            }
            List<String> clothes = workServerAdmin.getParticularClothes(labelClothesNameTable.Text, textClothesName.Text);
            textClothesBrand.Text = clothes[0];
            textClothesMaterial.Text = clothes[1];
            comboClothesSex.SelectedIndex = defineSex(clothes[2]);
            textClothesPrice.Text = clothes[3];
            labelClothesAddingQuantity.Text = clothes[4];
            comboQuantityClothes.Items.AddRange(getNormalQuantityItems());

            setEnableClothesItems();
        }

        private void buttonClothesChange_Click(object sender, EventArgs e)
        {
            if (textClothesBrand.Text != "" && textClothesMaterial.Text != "" && comboQuantityClothes.SelectedIndex > 0
                && comboClothesSex.SelectedIndex > -1 && int.TryParse(textClothesPrice.Text, out int result))
            {
                if (MessageBox.Show("Вы уверены, что хотите продолжить?", "Обновление записи",
                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    workServerAdmin.updateClothesTable(labelClothesNameTable.Text, textClothesName.Text, textClothesBrand.Text, textClothesMaterial.Text,
                                                       comboClothesSex.Text, Convert.ToInt32(textClothesPrice.Text),
                                                       Convert.ToInt32(comboQuantityClothes.SelectedIndex));
                    setNonVisibleItemsVisible();
                }
            }
            else
            {
                MessageBox.Show("Проверьте правильность написания данных", "Предупреждение");
            }
        }
        private void snickersMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = snickersMenuItem.Text;
        }
        private void snickersStrutterMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = snickersStrutterMenuItem.Text;
        }

        private void sliponMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = sliponMenuItem.Text;
        }

        private void XRayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = XRayToolStripMenuItem.Text;
        }

        private void loafersMocMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = loafersMocMenuItem.Text;
        }

        private void loafersMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = loafersMenuItem.Text;
        }

        private void backpackXMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = backpackXMenuItem.Text;
        }

        private void waistBagMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = waistBagMenuItem.Text;
        }

        private void crossBagMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = crossBagMenuItem.Text;
        }

        private void bagMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = bagMenuItem.Text;
        }

        private void backpackUMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = backpackUMenuItem.Text;
        }

        private void backpackLMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = backpackLMenuItem.Text;
        }

        private void bodyMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = bodyMenuItem.Text;
        }

        private void braMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = braMenuItem.Text;
        }

        private void underwearSetMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = underwearSetMenuItem.Text;
        }
        private void shapewearMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = shapewearMenuItem.Text;
        }

        private void underpantsMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = underpantsMenuItem.Text;
        }

        private void tShortMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = tShortMenuItem.Text;
        }

        private void packPAcksMenuItem_Click(object sender, EventArgs e)
        {
            labelClothesNameTable.Text = packPAcksMenuItem.Tag.ToString();
        }

        private void UnderWearMenuItem_Click(object sender, EventArgs e)
        {
            labelClothesNameTable.Text = UnderWearMenuItem.Tag.ToString();
        }
        private void diffClothesMenuItem_Click(object sender, EventArgs e)
        {
            labelClothesNameTable.Text = diffClothesMenuItem.Tag.ToString();
        }

        private void pulloverMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = pulloverMenuItem.Text;
        }

        private void jacketMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = jacketMenuItem.Text;
        }

        private void jeansMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = jeansMenuItem.Text;
        }

        private void jacketAnorakMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = jacketAnorakMenuItem.Text;
        }

        private void pantsMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleClothesItemsVisible();
            textClothesName.Text = pantsMenuItem.Text;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///          End Clothes Items
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///          Start Laptops Pcs Items
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///
        private void electroMenuItem_Click(object sender, EventArgs e)
        {
            setNonVisibleItemsVisible();
            textPcsLaptopsName.Text = "";
            textPcsLaptopsCPU.Text = "";
            textPcsLaptopsGPU.Text = "";
            textPcsLaptopsOS.Text = "";
            textPcsLaptopsPrice.Text = "";
            labelPcsLaptopsQuantity.Text = "";
        }
        private void pcsMenuItem_Click(object sender, EventArgs e)
        {
            labelPcsLaptopsNameTable.Text = pcsMenuItem.Tag.ToString();
        }

        private void laptopsMenuItem_Click(object sender, EventArgs e)
        {
            labelPcsLaptopsNameTable.Text = laptopsMenuItem.Tag.ToString();
        }

        private void buttonPcsLaptopsUpdate_Click(object sender, EventArgs e)
        {
            List<String> pcsLaptops = workServerAdmin.getParticularLaptopsPcs(labelPcsLaptopsNameTable.Text, textPcsLaptopsName.Text);
            textPcsLaptopsCPU.Text = pcsLaptops[0];
            textPcsLaptopsGPU.Text = pcsLaptops[1];
            textPcsLaptopsOS.Text = pcsLaptops[2];
            textPcsLaptopsPrice.Text = pcsLaptops[3];
            labelPcsLaptopsAddingQuantity.Text = pcsLaptops[4];
            comboQuantityPcsLaptops.Items.AddRange(getNormalQuantityItems());

            setEnablePcsLaptopsItems();
        }

        private void buttonPcsLaptopsChange_Click(object sender, EventArgs e)
        {
            if (textPcsLaptopsCPU.Text != "" && textPcsLaptopsGPU.Text != "" && textPcsLaptopsOS.Text != ""
               && comboQuantityPcsLaptops.SelectedIndex > 0 && int.TryParse(textPcsLaptopsPrice.Text, out int result))
            {
                if (MessageBox.Show("Вы уверены, что хотите продолжить?", "Обновление записи",
                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    workServerAdmin.updatePcsLaptopsTable(labelPcsLaptopsNameTable.Text, textPcsLaptopsName.Text, textPcsLaptopsCPU.Text,
                                                          textPcsLaptopsGPU.Text, textPcsLaptopsOS.Text, Convert.ToInt32(textPcsLaptopsPrice.Text),
                                                          Convert.ToInt32(comboQuantityPcsLaptops.Text));
                    setNonVisibleItemsVisible();
                }
            }
            else
            {
                MessageBox.Show("Проверьте правильность написания данных", "Предупреждение");
            }
        }
        private void hPPavilionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisiblePcsLaptopsItems();
            textPcsLaptopsName.Text = hPPavilionToolStripMenuItem.Text;
        }

        private void lenovoLegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisiblePcsLaptopsItems();
            textPcsLaptopsName.Text = lenovoLegionToolStripMenuItem.Text;
        }
        private void lenovoIdeaCentreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisiblePcsLaptopsItems();
            textPcsLaptopsName.Text = lenovoIdeaCentreToolStripMenuItem.Text;
        }

        private void oldiComputersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisiblePcsLaptopsItems();
            textPcsLaptopsName.Text = oldiComputersToolStripMenuItem.Text;
        }

        private void hPOMENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisiblePcsLaptopsItems();
            textPcsLaptopsName.Text = hPOMENToolStripMenuItem.Text;
        }
        private void robotCompToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisiblePcsLaptopsItems();
            textPcsLaptopsName.Text = robotCompToolStripMenuItem.Text;
        }

        private void classicGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisiblePcsLaptopsItems();
            textPcsLaptopsName.Text = classicGameToolStripMenuItem.Text;
        }

        private void lenovoIdeaPad33015ASTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisiblePcsLaptopsItems();
            textPcsLaptopsName.Text = lenovoIdeaPad33015ASTToolStripMenuItem.Text;
        }

        private void aSUSZenBook14ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisiblePcsLaptopsItems();
            textPcsLaptopsName.Text = aSUSZenBook14ToolStripMenuItem.Text;
        }

        private void acerExtensa15ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisiblePcsLaptopsItems();
            textPcsLaptopsName.Text = acerExtensa15ToolStripMenuItem.Text;
        }

        private void hPEnvy13ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisiblePcsLaptopsItems();
            textPcsLaptopsName.Text = hPEnvy13ToolStripMenuItem.Text;
        }

        private void aSUSZenBookSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisiblePcsLaptopsItems();
            textPcsLaptopsName.Text = aSUSZenBookSToolStripMenuItem.Text;
        }

        private void dellPrecision7730ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisiblePcsLaptopsItems();
            textPcsLaptopsName.Text = dellPrecision7730ToolStripMenuItem.Text;
        }

        private void acerSwiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisiblePcsLaptopsItems();
            textPcsLaptopsName.Text = acerSwiftToolStripMenuItem.Text;
        }
        private void honorMagicBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisiblePcsLaptopsItems();
            textPcsLaptopsName.Text = honorMagicBookToolStripMenuItem.Text;
        }

        private void acerAspire3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisiblePcsLaptopsItems();
            textPcsLaptopsName.Text = acerAspire3ToolStripMenuItem.Text;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///          End PcsLaptops Items
        ////////////////////////////////////////////////////////////////////////////////////////////////////




        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///          Start hPhones Items
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///

        private void hPhonesMenuItem_Click(object sender, EventArgs e)
        {
            labelHPhoneNameTable.Text = hPhonesMenuItem.Tag.ToString();
        }

        private void buttonhPhonesUpdate_Click(object sender, EventArgs e)
        {
            List<String> hPhones = workServerAdmin.getParticularHPhones(labelHPhoneNameTable.Text, textHPhonesName.Text);
            texthPhonesMic.Text = hPhones[0];
            textHPhonesType.Text = hPhones[1];
            texthPhonesPrice.Text = hPhones[2];
            labelhPhonesAddingQuantity.Text = hPhones[3];


            combohPhonesQuantity.Items.AddRange(getNormalQuantityItems());
            setEnableHPhonesItems();
        }

        private void buttonhPhonesChange_Click(object sender, EventArgs e)
        {
            if (texthPhonesMic.Text != "" && textHPhonesType.Text != "" && combohPhonesQuantity.SelectedIndex > 0
                && int.TryParse(texthPhonesPrice.Text, out int result))
            {
                if (MessageBox.Show("Вы уверены, что хотите продолжить?", "Обновление записи",
                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    workServerAdmin.updateHPhonesTable(labelHPhoneNameTable.Text, textHPhonesName.Text, textHPhonesType.Text, texthPhonesMic.Text,
                                                       Convert.ToInt32(texthPhonesPrice.Text), Convert.ToInt32(combohPhonesQuantity.Text));
                    setNonVisibleItemsVisible();
                }
            }
            else
            {
                MessageBox.Show("Проверьте правильность написания данных", "Предупреждение");
            }
        }

        private void airPodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleHPhonesItems();
            textHPhonesName.Text = airPodsToolStripMenuItem.Text;
        }

        private void xiaomiRedmiAirDotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleHPhonesItems();
            textHPhonesName.Text = xiaomiRedmiAirDotsToolStripMenuItem.Text;
        }

        private void jBLC100SIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleHPhonesItems();
            textHPhonesName.Text = jBLC100SIToolStripMenuItem.Text;
        }

        private void i9STWSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleHPhonesItems();
            textHPhonesName.Text = i9STWSToolStripMenuItem.Text;
        }

        private void airPodsProToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleHPhonesItems();
            textHPhonesName.Text = airPodsProToolStripMenuItem.Text;
        }

        private void sennheiserHDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleHPhonesItems();
            textHPhonesName.Text = sennheiserHDToolStripMenuItem.Text;
        }

        private void damixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleHPhonesItems();
            textHPhonesName.Text = damixToolStripMenuItem.Text;
        }

        private void qCYT5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleHPhonesItems();
            textHPhonesName.Text = qCYT5ToolStripMenuItem.Text;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///          End HPhones Items
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///          Start TVs Items
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void tvsMenuItem_Click(object sender, EventArgs e)
        {
            labelTvsNameTable.Text = tvsMenuItem.Tag.ToString();
        }

        private void buttonTvsUpdate_Click(object sender, EventArgs e)
        {
            List<String> tvs = workServerAdmin.getParticularTvs(labelTvsNameTable.Text, textTvsName.Text);
            textTvsResolution.Text = tvs[0];
            textTvsFeatures.Text = tvs[1];
            textTvsPrice.Text = tvs[2];
            labelTvsAddingQuantity.Text = tvs[3];

            comboTvsQuantity.Items.AddRange(getNormalQuantityItems());
            setEnableTvsItems();
        }

        private void buttonTvsChange_Click(object sender, EventArgs e)
        {
            if (textTvsResolution.Text != "" && textTvsResolution.Text != "" && comboTvsQuantity.SelectedIndex > 0 &&
                int.TryParse(textTvsPrice.Text, out int result))
            {
                if (MessageBox.Show("Вы уверены, что хотите продолжить?", "Обновление записи",
                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    workServerAdmin.updateTvsTable(labelTvsNameTable.Text, textTvsName.Text, textTvsResolution.Text,
                                                   textTvsFeatures.Text, Convert.ToInt32(textTvsPrice.Text),
                                                   Convert.ToInt32(comboTvsQuantity.Text));
                    setNonVisibleItemsVisible();
                }
            }
            else
            {
                MessageBox.Show("Проверьте правильность написания данных", "Предупреждение");
            }
        }
        private void samsungUE55RU7300UXRUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleTvsItems();
            textTvsName.Text = samsungUE55RU7300UXRUToolStripMenuItem.Text;
        }

        private void lG43UK6200PLAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleTvsItems();
            textTvsName.Text = lG43UK6200PLAToolStripMenuItem.Text;
        }

        private void kIVI55UC50GRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleTvsItems();
            textTvsName.Text = kIVI55UC50GRToolStripMenuItem.Text;
        }

        private void lG49UK6300PLBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleTvsItems();
            textTvsName.Text = lG49UK6300PLBToolStripMenuItem.Text;
        }

        private void samsungQE75Q900RBUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleTvsItems();
            textTvsName.Text = samsungQE75Q900RBUToolStripMenuItem.Text;
        }

        private void thomsonT22FTE1020ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleTvsItems();
            textTvsName.Text = thomsonT22FTE1020ToolStripMenuItem.Text;
        }

        private void asano32LH7010TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleTvsItems();
            textTvsName.Text = asano32LH7010TToolStripMenuItem.Text;
        }

        private void eCONSMARTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleTvsItems();
            textTvsName.Text = eCONSMARTToolStripMenuItem.Text;
        }

        private void sonyKDL32RE303ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibleTvsItems();
            textTvsName.Text = sonyKDL32RE303ToolStripMenuItem.Text;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///          End Tvs Items
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void panelChange_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }
        /// 
        /// ////////////////////////////////////////////////////////////////////////////
        /// ////////////////////////////////////////////////////////////////////////////
        List<BooksControl> booksControlsUsers = new List<BooksControl>();
        private void createBooksForUsers(string name, string author, int price, int quantity)
        {
            manageBookForUsers.createBook(name, author, price, quantity, new string[] { "" }, new Basket(new WorkServer()), "");
        }
        private void createBookControlsUsers()
        {
            booksControlsUsers.AddRange(manageBookForUsers.getAllManageBooks());
        }
        private void showOnFlowBookUsers()
        {
            for (int i = 0; i < booksControlsUsers.Count; i++)
            {
                flowLayoutPanelBookUsers.Controls.Add(booksControlsUsers[i]);
            }
        }
        private void usersMenuItem_Click(object sender, EventArgs e)
        {
            List<String> users = workServerAdmin.getUsersList();
            if (users.Count != usersMenuItem.DropDownItems.Count)
            {
                usersMenuItem.DropDownItems.Clear();
                for (int i = 0; i < users.Count; i++)
                {
                    usersMenuItem.DropDownItems.Add(users[i]);
                    usersMenuItem.DropDownItems[i].Click += new EventHandler(nameUserClick);
                }
            }
        }
        private void nameUserClick(object sender, EventArgs e)
        {
            manageBookForUsers = new ManageBook();
            flowLayoutPanelBookUsers.Controls.Clear();
            booksControlsUsers.Clear();
            List<String> name = new List<String>();
            List<String> author = new List<String>();
            List<int> price = new List<int>();
            List<int> quantity = new List<int>();
            string userLogin = ((ToolStripMenuItem)sender).Text;
            /*MessageBox.Show(str);*/
            workServerAdmin.forFlowUsersBook(userLogin, ref name, ref author, ref price, ref quantity);
            if(name.Count == author.Count && name.Count == price.Count && name.Count == quantity.Count)
            {
                for (int i = 0; i < name.Count; i++)
                {
                    createBooksForUsers(name[i], author[i], price[i], quantity[i]);
                }
            }
            createBookControlsUsers();
            showOnFlowBookUsers();
        }
    }
}
