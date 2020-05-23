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
    public partial class MainInterface : Form
    {
        Basket basketItems = new Basket(new WorkServer());


        ManageClothes manageClothes;
        ManageSmartPhone manageSmartPhone;
        ManageSmartWatch manageSmartWatch;
        ManageTvs manageTvs;
        ManageHphones manageHphones;
        ManageLaptopsPcs manageLaptopPcs;
        ManageBook manageBook;
        WorkServer workServerOnMainInterface = new WorkServer();

        static Color defaultColor = Color.FromArgb(21, 21, 21);

        public Form1 form;
        public MainInterface()
        {
            InitializeComponent();
        }
        Form formMain;
        public MainInterface(string user, Form MAINFORM)
        {
            InitializeComponent();
            UserNameLabel.Text = user;
            basketItems.setUserNameLabel(user);
            formMain = MAINFORM;
        }
        
        private List<Label> getAllLabels()
        {
            List<Label> labels = new List<Label> {comicsLabel , artLabel, childrenLabel, textbooksLabel, ForeignBooksLabel, DiffBooksLabel,
                            PcsLabel, HeadphonesLabel, TvsLabel, LaptopsLabel, SmartWatchesLabel, SmartphonesLabel,
                            ShoesLabel, BackpacksLabel, UnderWearLabel, DiffClothesLabel};
            return labels;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
            formMain.Show();
        }

        private void electroLabel_Click(object sender, EventArgs e)
        {
            setDefaultFlowLayout();
            setDefaultAddingItemsColor();
            defaultBackColor(pictureBoxBooks, pictureBoxClothes, panelBooks, panelClothes);
            setDefaultDistanceMainItems(panelMainAddingBooks, panelMainAddingClothes, panelMainAddingElectro);
            
            defaultMovingForward(panelClothes, panelMainAddingElectro);
            panelMove.Top = panelElectro.Top + 1;
            changeItemsColor(panelMove, panelElectro, pictureBoxElectro);
        }

        private void booksLabel_Click(object sender, EventArgs e)
        {
            setDefaultFlowLayout();
            setDefaultAddingItemsColor();
            defaultBackColor(pictureBoxElectro, pictureBoxClothes, panelElectro, panelClothes);
            setDefaultDistanceMainItems(panelMainAddingBooks, panelMainAddingClothes, panelMainAddingElectro);
            defaultMovingForward(panelElectro, panelClothes, panelMainAddingBooks);
            panelMove.Top = panelBooks.Top + 1;
            changeItemsColor(panelMove, panelBooks, pictureBoxBooks);
        }

        private void clothesLabel_Click(object sender, EventArgs e)
        {
            setDefaultFlowLayout();
            setDefaultAddingItemsColor();
            setDefaultDistanceMainItems(panelMainAddingBooks, panelMainAddingClothes, panelMainAddingElectro);
            defaultBackColor(pictureBoxElectro, pictureBoxBooks, panelBooks, panelElectro);
            defaultMovingForward(panelMainAddingClothes);
            panelMove.Top = panelClothes.Top + 1;
            changeItemsColor(panelMove, panelClothes, pictureBoxClothes);
        }

        private void defaultBackColor(PictureBox firstPic, PictureBox secondPic,  params Panel[] panel)
        {
            for (int i = 0; i < panel.Length; i++) { panel[i].BackColor = Color.FromArgb(21, 21, 21); }
            firstPic.BackColor = Color.FromArgb(21, 21, 21);
            secondPic.BackColor = Color.FromArgb(21, 21, 21);
        }

        private void defaultMovingForward(params Panel[] panel)
        {
            if (panel[panel.Length - 1].Visible is false)
            {
                if (panel.Length > 1)
                {
                    // последняя panel = panelMainAddingBooks
                    for (int i = 0; i < panel.Length - 1; i++)
                    {
                        panel[i].Top += panel[panel.Length - 1].Height;
                    }
                }
                visibleMode(panel[panel.Length - 1], true);
            }
        }

        private void visibleMode(Panel panel, bool visible)
        {
            if (visible)
                panel.Visible = true;
            else
                panel.Visible = false;
        }

        private void changeItemsColor(Panel movePanel, Panel simplePanel, PictureBox pic)
        {
            movePanel.BackColor = Color.FromArgb(255, 245, 20);
            simplePanel.BackColor = Color.FromArgb(28, 28, 28);
            pic.BackColor = Color.FromArgb(28, 28, 28);
        }

        private void setDefaultDistanceMainItems(params Panel[] panels) // return Main Blocks back
        {
            panelBooks.Top = 144;
            panelElectro.Top = 204;
            panelClothes.Top = 264;
            for (int i = 0; i < panels.Length; i++)
            {
                visibleMode(panels[i], false);
            }
        }

        private void changeAddingItemsColor(Panel mainPanel, params Panel[] panels)  // for added items, in instance Books -> Comics/Artbookt etc.
        {
            if (mainPanel.BackColor != defaultColor)
            {
                panels[0].BackColor = Color.FromArgb(65, 65, 65);
                for (int i = 1; i < panels.Length; i++)
                {
                    panels[i].BackColor = defaultColor;
                }
            }
        }

        private void setDefaultAddingItemsColor()
        {
            panelComics.BackColor = panelArtBooks.BackColor = panelChildren.BackColor = panelTextbooks.BackColor
                = panelDiffBooks.BackColor = panelForeignBooks.BackColor = panelPcs.BackColor = 
                panelHeadphones.BackColor = panelTvs.BackColor = panelSmartphones.BackColor = 
                panelLaptops.BackColor = panelSmartwatches.BackColor = panelShoes.BackColor = 
                panelBackpacks.BackColor = panelUnderWear.BackColor = panelDiff.BackColor = defaultColor;
        }

        private void setDefaultPanelMoveColor()
        {
            panelMove.BackColor = defaultColor;
        }

        private void setDefaultMainItemsColor()
        {
            panelBooks.BackColor = panelElectro.BackColor = panelClothes.BackColor = defaultColor;
        }
        private void MainInterface_Load(object sender, EventArgs e)
        {
            pictureBoxActivated.Left = UserNameLabel.Left + UserNameLabel.Width;

        }

        private void setDefaultFlowLayout()
        {
            flowLayoutPanel.Controls.Clear();
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void pictureBoxWareHouse_Click(object sender, EventArgs e)
        {
            setDefaultFlowLayout();
            setDefaultDistanceMainItems(panelMainAddingBooks, panelMainAddingClothes, panelMainAddingElectro);
            setDefaultPanelMoveColor();
            setDefaultMainItemsColor();
        }
   
        // Added items from books---------------------------------------------------------------------------------------
        public void completeBooksItem(string table)
        {
            List<String> title = new List<String>();
            List<String> author = new List<String>();
            List<int> price = new List<int>();
            List<int> quantity = new List<int>();
            workServerOnMainInterface.createInfoBooksArray(table, ref title, ref author, ref price, ref quantity);
            if(title.Count == author.Count && title.Count == price.Count && title.Count == quantity.Count)
            {
                flowLayoutPanel.Controls.Clear();
                manageBook = new ManageBook();
                for(int i = 0; i < title.Count; i++)
                {
                    string[] quantityCombo = new string[quantity[i]+1];
                    for(int j = 0; j < quantityCombo.Length; j++) 
                        quantityCombo[j] = (j).ToString();
                    manageBook.createBook(title[i], author[i], price[i], quantity[i], quantityCombo, basketItems, table/*, new Bitmap(@"D:\Лабораторки_С#\Course\ProjectImages\cancel.png")*/);
                }

                for(int i = 0; i < manageBook.getAllManageBooks().Count; i++)
                {
                    flowLayoutPanel.Controls.Add(manageBook.getAllManageBooks()[i]);
                }
            }
            
        }
        private void comicsLabel_Click(object sender, EventArgs e)
        {
            changeAddingItemsColor(panelBooks, panelComics, panelArtBooks, panelChildren, panelTextbooks, panelForeignBooks, panelDiffBooks);
            completeBooksItem(comicsLabel.Tag.ToString());
        }

        private void artLabel_Click(object sender, EventArgs e)
        {
            changeAddingItemsColor(panelBooks, panelArtBooks, panelComics, panelChildren, panelTextbooks, panelForeignBooks, panelDiffBooks);
            completeBooksItem(artLabel.Tag.ToString());
        }

        private void childrenLabel_Click(object sender, EventArgs e)
        {
            changeAddingItemsColor(panelBooks, panelChildren, panelArtBooks, panelComics, panelTextbooks, panelForeignBooks, panelDiffBooks);
            completeBooksItem(childrenLabel.Tag.ToString());
        }

        private void textbooksLabel_Click(object sender, EventArgs e)
        {
            changeAddingItemsColor(panelBooks, panelTextbooks, panelArtBooks, panelComics, panelChildren, panelForeignBooks, panelDiffBooks);
            completeBooksItem(textbooksLabel.Tag.ToString());
        }

        private void ForeignBooksLabel_Click(object sender, EventArgs e)
        {
            changeAddingItemsColor(panelBooks, panelForeignBooks, panelArtBooks, panelComics, panelChildren, panelTextbooks, panelDiffBooks);
            completeBooksItem(ForeignBooksLabel.Tag.ToString());
        }

        private void DiffBooksLabel_Click(object sender, EventArgs e)
        {
            changeAddingItemsColor(panelBooks, panelDiffBooks, panelArtBooks, panelComics, panelChildren, panelTextbooks, panelForeignBooks);
            completeBooksItem(DiffBooksLabel.Tag.ToString());
        }

        //Added items from Electro--------------------------------------------------------------------------------------
        public void completeHphonesItem(string table)
        {
            List<String> titles = new List<String>();
            List<String> mic = new List<String>();
            List<String> type = new List<String>();
            List<int> workingHours = new List<int>();
            List<int> resistance = new List<int>();
            List<int> price = new List<int>();
            List<int> quantity = new List<int>();
            workServerOnMainInterface.createInfoHphonesArray(table, ref titles, ref mic, ref type, ref workingHours, ref resistance, ref price, ref quantity);
            if(titles.Count == mic.Count && titles.Count == type.Count && titles.Count == workingHours.Count && titles.Count == resistance.Count &&
               titles.Count == price.Count && titles.Count == quantity.Count)
            {
                flowLayoutPanel.Controls.Clear();
                manageHphones = new ManageHphones();
                for(int i = 0; i < titles.Count; i++)
                {
                    string[] quantityCombo = new string[quantity[i]+1];
                    for (int j = 0; j < quantityCombo.Length; j++)
                        quantityCombo[j] = (j).ToString();
                    manageHphones.createHphones(titles[i], mic[i], type[i], workingHours[i], resistance[i], price[i], quantity[i], quantityCombo, basketItems, table);
                }

                for(int i = 0; i < manageHphones.getAllHphones().Count; i++)
                {
                    flowLayoutPanel.Controls.Add(manageHphones.getAllHphones()[i]);
                }
            }
        }
        private void HeadphonesLabel_Click(object sender, EventArgs e)
        {
            changeAddingItemsColor(panelElectro, panelHeadphones, panelPcs, panelTvs, panelLaptops, panelSmartwatches, panelSmartphones);
            completeHphonesItem("Headphones");
        }

        public void completeTvsItem(string table)
        {
            List<String> titles = new List<String>();
            List<double> screenDiagonal = new List<double>();
            List<String> resolution = new List<String>();
            List<String> features = new List<String>();
            List<int> price = new List<int>();
            List<int> quantity = new List<int>();
            workServerOnMainInterface.createInfoTvsArray(table, ref titles, ref screenDiagonal, ref resolution, ref features, ref price, ref quantity);
            if(titles.Count == screenDiagonal.Count && titles.Count == resolution.Count && titles.Count == features.Count && 
               titles.Count == price.Count && titles.Count == quantity.Count)
            {
                flowLayoutPanel.Controls.Clear();
                manageTvs = new ManageTvs();
                for(int i = 0; i < titles.Count; i++)
                {
                    string[] quantityCombo = new string[quantity[i]+1];
                    for (int j = 0; j < quantityCombo.Length; j++)
                        quantityCombo[j] = (j).ToString();
                    manageTvs.createTvs(titles[i], screenDiagonal[i], resolution[i], features[i], price[i], quantity[i], quantityCombo, basketItems, table);
                }

                for(int i = 0; i < manageTvs.getAllTvs().Count; i++)
                {
                    flowLayoutPanel.Controls.Add(manageTvs.getAllTvs()[i]);
                }
            }
        }

        private void TvsLabel_Click(object sender, EventArgs e)
        {
            changeAddingItemsColor(panelElectro, panelTvs, panelPcs, panelHeadphones, panelLaptops, panelSmartwatches, panelSmartphones);
            completeTvsItem("TVs");
        }

        public void completeLaptopsPcsItem(string table)
        {
            List<String> titles = new List<String>();
            List<String> cpu = new List<String>();
            List<int> ram = new List<int>();
            List<int> hdd = new List<int>();
            List<int> ssd = new List<int>();
            List<String> gpu = new List<String>();
            List<String> os = new List<String>();
            List<int> price = new List<int>();
            List<int> quantity = new List<int>();
            workServerOnMainInterface.createInfoLaptopsPcsArray(table, ref titles, ref cpu, ref ram, ref hdd, ref ssd, ref gpu, ref os, ref price, ref quantity);
            if(titles.Count == cpu.Count && titles.Count == ram.Count && titles.Count == hdd.Count && titles.Count == ssd.Count 
               && titles.Count == gpu.Count && titles.Count == os.Count 
               && titles.Count == price.Count && titles.Count == quantity.Count)
            {
                flowLayoutPanel.Controls.Clear();
                manageLaptopPcs = new ManageLaptopsPcs();
                for(int i = 0; i < titles.Count; i++)
                {
                    string[] quantityCombo = new string[quantity[i]+1];
                    for (int j = 0; j < quantityCombo.Length; j++)
                        quantityCombo[j] = (j).ToString();
                    manageLaptopPcs.createLaptopPcs(titles[i], cpu[i], ram[i], hdd[i], ssd[i], gpu[i], os[i], price[i], quantity[i],
                                                    quantityCombo, basketItems, table);
                }

                for (int i = 0; i < manageLaptopPcs.getAllManageLaptops().Count; i++)
                    flowLayoutPanel.Controls.Add(manageLaptopPcs.getAllManageLaptops()[i]);
            }
        }
        private void LaptopsLabel_Click(object sender, EventArgs e)
        {
            changeAddingItemsColor(panelElectro, panelLaptops, panelPcs, panelHeadphones, panelTvs, panelSmartwatches, panelSmartphones);
            completeLaptopsPcsItem(LaptopsLabel.Tag.ToString());
        }
        private void PcsLabel_Click(object sender, EventArgs e)
        {
            changeAddingItemsColor(panelElectro, panelPcs, panelHeadphones, panelTvs, panelLaptops, panelSmartwatches, panelSmartphones);
            completeLaptopsPcsItem(PcsLabel.Tag.ToString());
        }

        public void completeSmartWatch(string table)
        {
            List<String> titles = new List<String>();
            List<String> compatibleOS = new List<String>();
            List<String> sensors = new List<String>();
            List<String> screenResolution = new List<String>();
            List<int> price = new List<int>();
            List<int> quantity = new List<int>();
            workServerOnMainInterface.createInfoSmartWatchArray(table, ref titles, ref compatibleOS, ref sensors, ref screenResolution, ref price, ref quantity);
            if (titles.Count == compatibleOS.Count && titles.Count == sensors.Count && titles.Count == screenResolution.Count && 
                titles.Count == price.Count && titles.Count == quantity.Count)
            {
                flowLayoutPanel.Controls.Clear();
                manageSmartWatch = new ManageSmartWatch();
                for (int i = 0; i < titles.Count; i++)
                {
                    string[] quantityCombo = new string[quantity[i]+1];
                    for (int j = 0; j < quantityCombo.Length; j++)
                        quantityCombo[j] = (j).ToString();
                    manageSmartWatch.createSmartWatch(titles[i], compatibleOS[i], sensors[i], screenResolution[i], price[i], quantity[i], quantityCombo, basketItems, table);
                }

                for (int i = 0; i < manageSmartWatch.getAllSmartWatch().Count; i++)
                    flowLayoutPanel.Controls.Add(manageSmartWatch.getAllSmartWatch()[i]);
            }
        }
        private void SmartWatchesLabel_Click(object sender, EventArgs e)
        {
            changeAddingItemsColor(panelElectro, panelSmartwatches, panelPcs, panelHeadphones, panelTvs, panelLaptops, panelSmartphones);
            completeSmartWatch("Smartwhatches");
        }

        public void completeSmartPhone(string table)
        {
            List<String> titles = new List<String>();
            List<int> internalMemory = new List<int>();
            List<int> ram = new List<int>();
            List<int> cameraResolution = new List<int>();
            List<double> screenDiagonal = new List<double>();
            List<int> capacity = new List<int>();
            List<int> price = new List<int>();
            List<int> quantity = new List<int>();
            workServerOnMainInterface.createInfoSmartPhones(table, ref titles, ref internalMemory,ref  ram, ref cameraResolution, 
                                                            ref screenDiagonal, ref capacity, ref price, ref quantity);
            if(titles.Count == internalMemory.Count && titles.Count == ram.Count && titles.Count == cameraResolution.Count && titles.Count == screenDiagonal.Count && 
                titles.Count == capacity.Count && titles.Count == price.Count && titles.Count == quantity.Count)
            {
                manageSmartPhone = new ManageSmartPhone();
                flowLayoutPanel.Controls.Clear();
                for(int i = 0; i < titles.Count; i++)
                {
                    string[] quantityCombo = new string[quantity[i]+1];
                    for (int j = 0; j < quantityCombo.Length; j++)
                        quantityCombo[j] = (j).ToString();
                    manageSmartPhone.createSmartPhone(titles[i], internalMemory[i], ram[i], cameraResolution[i], screenDiagonal[i], capacity[i], 
                                                      price[i], quantity[i], quantityCombo, basketItems, table);
                }

                for(int i = 0; i < manageSmartPhone.getAllSmartPhones().Count; i++)
                {
                    flowLayoutPanel.Controls.Add(manageSmartPhone.getAllSmartPhones()[i]);
                }
            }

        }
        private void SmartphonesLabel_Click(object sender, EventArgs e)
        {
            changeAddingItemsColor(panelElectro, panelSmartphones, panelPcs, panelHeadphones, panelTvs, panelLaptops, panelSmartwatches);
            completeSmartPhone("Smartphones");
        }

        //Added items from clothes_--------------------------------------------------------------------------------------------------------------
        public void completeClothes(string table)
        {
            List<String> titles = new List<String>();
            List<String> brand = new List<String>();
            List<String> materials = new List<String>();
            List<String> sex = new List<String>();
            List<int> price = new List<int>();
            List<int> quantity = new List<int>();
            workServerOnMainInterface.createInfoClothes(table, ref titles, ref brand, ref materials, ref sex, ref price, ref quantity);
            if(titles.Count == brand.Count && titles.Count == materials.Count && titles.Count == sex.Count && titles.Count == price.Count
               && titles.Count == quantity.Count)
            {
                manageClothes = new ManageClothes();
                flowLayoutPanel.Controls.Clear();
                for (int i = 0; i < titles.Count; i++)
                {
                    string[] quantityCombo = new string[quantity[i]+1];
                    for (int j = 0; j < quantityCombo.Length; j++)
                        quantityCombo[j] = (j).ToString();
                    manageClothes.createClothes(titles[i], brand[i], materials[i], sex[i], price[i], quantity[i], quantityCombo, basketItems, table);
                }
                for (int i = 0; i < manageClothes.getAllClothes().Count; i++)
                {
                    flowLayoutPanel.Controls.Add(manageClothes.getAllClothes()[i]);
                }
            }
        }
        private void ShoesLabel_Click(object sender, EventArgs e)
        {
            changeAddingItemsColor(panelClothes, panelShoes, panelBackpacks, panelUnderWear, panelDiff);
            completeClothes(ShoesLabel.Tag.ToString());
        }

        private void BackpacksLabel_Click(object sender, EventArgs e)
        {
            changeAddingItemsColor(panelClothes, panelBackpacks, panelShoes, panelUnderWear, panelDiff);
            completeClothes(BackpacksLabel.Tag.ToString());
        }

        private void UnderWearLabel_Click(object sender, EventArgs e)
        {
            changeAddingItemsColor(panelClothes, panelUnderWear, panelShoes, panelBackpacks, panelDiff);
            completeClothes(UnderWearLabel.Tag.ToString());
        }

        private void DiffLabel_Click(object sender, EventArgs e)
        {
            changeAddingItemsColor(panelClothes, panelDiff, panelShoes, panelBackpacks, panelUnderWear);
            completeClothes(DiffClothesLabel.Tag.ToString());
        }
        //--------------------------------------------------------------------------------------------------------------
        
        private void buttonAddItems_Click(object sender, EventArgs e)
        {
            if(booksLabel.BackColor != defaultColor)   // For Booking Items Which will be added to Basket
            {
                
                addBooksToBasket(manageBook);
                basketItems.finallyAddedToFlowBook();

                string selectedLabel = null;
                foreach (Label label in getAllLabels())
                {
                    if (label.BackColor != defaultColor) { 
                        selectedLabel = label.Tag.ToString();
                        break;
                    }
                }
                completeBooksItem(selectedLabel);
            }
            else if(electroLabel.BackColor != defaultColor) // For Electring Items Which will be added to Basket
            {
                if(LaptopsLabel.BackColor != defaultColor || PcsLabel.BackColor != defaultColor)
                {
                    addLaptopsPcsToBasket(manageLaptopPcs);
                    basketItems.finallyAddedToFlowLaptopsPcs();
                    if (LaptopsLabel.BackColor != defaultColor)
                        completeLaptopsPcsItem(LaptopsLabel.Tag.ToString());
                    else
                        completeLaptopsPcsItem(PcsLabel.Tag.ToString());
                }
                else if(HeadphonesLabel.BackColor != defaultColor)
                {
                    addHphoneToBasket(manageHphones);
                    basketItems.finallyAddedToFlowHphones();
                    completeHphonesItem(HeadphonesLabel.Tag.ToString());
                }
                else if(TvsLabel.BackColor != defaultColor)
                {
                    addTvsToBasket(manageTvs);
                    basketItems.finallyAddedToFlowTvs();
                    completeTvsItem(TvsLabel.Tag.ToString());
                }
                else if(SmartWatchesLabel.BackColor != defaultColor)
                {
                    addSmartWatchesToBasket(manageSmartWatch);
                    basketItems.finallyAddedToFlowSmartWatches();
                    completeSmartWatch(SmartWatchesLabel.Tag.ToString());
                }
                else if(SmartphonesLabel.BackColor != defaultColor)
                {
                    addSmarPhonesToBasket(manageSmartPhone);
                    basketItems.finallyAddedToFlowSmartPhones();
                    completeSmartPhone(SmartphonesLabel.Tag.ToString());
                }

            }
            else if(clothesLabel.BackColor != defaultColor) // For clothes Items Which will be added to Basket
            {
                addClothesToBasket(manageClothes);
                basketItems.finallyAddedToFlowClothes();

                string selectedLabel = null;
                foreach (Label label in getAllLabels())
                {
                    if (label.BackColor != defaultColor)
                    {
                        selectedLabel = label.Tag.ToString();
                        break;
                    }
                }
                completeClothes(selectedLabel);
            }
        }

        public void addBooksToBasket(ManageBook manageBook)
        {
            for (int i = 0; i < manageBook.getAllManageBooks().Count; i++)
            {
                int newQuantityItems = manageBook.getAllManageBooks()[i].infoComboQuantitySelected();  // to update quantity of product
                if (newQuantityItems > 0) 
                {
                    if (!basketItems.checkSimilarAddedBook(manageBook.getAllManageBooks()[i])) 
                        basketItems.addBooksItems(manageBook.getAllManageBooks()[i]);
                }
            }
        }
        
        public void addClothesToBasket(ManageClothes manageClothes)
        {
            for (int i = 0; i < manageClothes.getAllClothes().Count; i++)
            {
                int newQuantityItems = manageClothes.getAllClothes()[i].infoComboQuantitySelected();  // to update quantity of product
                if (newQuantityItems > 0)
                {
                    if (!basketItems.checkSimilarAddedClothes(manageClothes.getAllClothes()[i]))
                        basketItems.addClothesItems(manageClothes.getAllClothes()[i]);
                }
            }
        }

        public void addLaptopsPcsToBasket(ManageLaptopsPcs manageLaptopsPcs)
        {
            for (int i = 0; i < manageLaptopsPcs.getAllManageLaptops().Count; i++)
            {
                int newQuantityItems = manageLaptopsPcs.getAllManageLaptops()[i].infoComboQuantitySelected();
                if (newQuantityItems > 0)
                {
                    if (!basketItems.checkSimilarAddedLaptopsPcs(manageLaptopsPcs.getAllManageLaptops()[i]))
                        basketItems.addLaptopsPcsItems(manageLaptopsPcs.getAllManageLaptops()[i]);
                }
            }
        }

        public void addHphoneToBasket(ManageHphones manageHphones)
        {
            for (int i = 0; i < manageHphones.getAllHphones().Count; i++)
            {
                int newQuantityItems = manageHphones.getAllHphones()[i].infoComboQuantitySelected();
                if(newQuantityItems > 0)
                {
                    if (!basketItems.checkSimilarAddedHphones(manageHphones.getAllHphones()[i]))
                    {
                        basketItems.addHphones(manageHphones.getAllHphones()[i]);
                    }
                }
            }
        }

        public void addTvsToBasket(ManageTvs manageTvs)
        {
            for (int i = 0; i < manageTvs.getAllTvs().Count; i++)
            {
                int newQuantityItems = manageTvs.getAllTvs()[i].infoComboQuantitySelected();
                if(newQuantityItems > 0)
                {
                    if (!basketItems.checkSimilarAddedTvs(manageTvs.getAllTvs()[i]))
                    {
                        basketItems.addTvs(manageTvs.getAllTvs()[i]);
                    }
                }
            }
        }
        public void addSmartWatchesToBasket(ManageSmartWatch manageSmartWatch)
        {
            for (int i = 0; i < manageSmartWatch.getAllSmartWatch().Count; i++)
            {
                int newQuantityItems = manageSmartWatch.getAllSmartWatch()[i].infoComboQuantitySelected();
                if (newQuantityItems > 0)
                {
                    if (!basketItems.checkSimilarAddedSmartWatches(manageSmartWatch.getAllSmartWatch()[i]))
                    {
                        basketItems.addSmartWatch(manageSmartWatch.getAllSmartWatch()[i]);
                    }
                }
            }
        }
        public void addSmarPhonesToBasket(ManageSmartPhone manageSmartPhone)
        {
            for (int i = 0; i < manageSmartPhone.getAllSmartPhones().Count; i++)
            {
                int newQuantityItems = manageSmartPhone.getAllSmartPhones()[i].infoComboQuantitySelected();
                if (newQuantityItems > 0)
                {
                    if (!basketItems.checkSimilarAddedSmartPhones(manageSmartPhone.getAllSmartPhones()[i]))
                    {
                        basketItems.addSmartPhone(manageSmartPhone.getAllSmartPhones()[i]);
                    }
                }
            }
        }
        private void pictureBoxBasket_Click(object sender, EventArgs e)
        {
            pictureBoxWareHouse_Click(sender, e);
            basketItems.totalPrice();
            basketItems.Show();
        }
    }
}
