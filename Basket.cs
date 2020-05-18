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
    public partial class Basket : Form
    {
        public Basket(WorkServer workServer)
        {
            InitializeComponent();
            workServerBasket = workServer;
        }

        private WorkServer workServerBasket;

        public void totalPrice()
        {
            int total = getPriceBooksInBasket() + getPriceClothesInBasket() + getPriceHphonesInBasket() + getPriceLaptopsPcsInBasket() +
                        getPriceSmartPhonesInBasket() + getPriceSmartWatchInBasket() + getPriceTvsInBasket();
            labelPrice.Text = total.ToString() + " р.";
        }
        public void setUserNameLabel(string user)
        {
            UserNameLabelBasket.Text = user;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        // FOR Books---------------------------------------------------------------------------------------------------------------------------------------------------
        private List<BooksControl> booksControlsInBasket = new List<BooksControl>();

        public int getPriceBooksInBasket()  // Income from books that are on the basket
        {
            int summa = 0;
            if(booksControlsInBasket.Count > 0)
            {
                for (int i = 0; i < booksControlsInBasket.Count; i++)
                {
                    summa += booksControlsInBasket[i].Price * booksControlsInBasket[i].infoComboQuantitySelected();
                }
                return summa;
            }
            return 0;
        }

        public void addBooksItems(BooksControl addBooksItems)
        {
            booksControlsInBasket.Add(addBooksItems);
        }

        public void finallyAddedToFlowBook()
        {
            for (int i = 0; i < booksControlsInBasket.Count; i++)
            {
                flowLayoutPanelBasket.Controls.Add(booksControlsInBasket[i]);
            }
        }

        public List<BooksControl> getBooksInBasket()
        {
            return booksControlsInBasket;
        }

        public void changeBooksControlsInBasket(BooksControl newBooksItem, BooksControl deleteBooks)
        {
            int newQuantityCombo = newBooksItem.infoComboQuantitySelected() + deleteBooks.infoComboQuantitySelected();
            if(newQuantityCombo > newBooksItem.infoComboQuantityAmount()) { 
                booksControlsInBasket.Remove(deleteBooks);
                flowLayoutPanelBasket.Controls.Remove(deleteBooks);  // delete from flowlayout old string of data
                booksControlsInBasket.Add(newBooksItem);
            }
            else
            {
                newBooksItem.setSelectedQuantity(newQuantityCombo);
                booksControlsInBasket.Remove(deleteBooks);
                flowLayoutPanelBasket.Controls.Remove(deleteBooks);  // delete from flowlayout old string of data
                booksControlsInBasket.Add(newBooksItem);
            }
        }

        public bool checkSimilarAddedBook(BooksControl addBooksItem)
        {
            if(getBooksInBasket().Count != 0)
            {
                for (int i = 0; i < getBooksInBasket().Count; i++)
                {
                    if (getBooksInBasket()[i].Title == addBooksItem.Title)
                    {
                        changeBooksControlsInBasket(addBooksItem, getBooksInBasket()[i]);
                        return true;
                    }
                }
            }
            return false;
        }
        // End books----------------------------------------------------------------------------------------------------------------------------------------------

        // For LaptopsPcs-----------------------------------------------------------------------------------------------------------------------------------------
        private List<LaptopsPcsControl> laptopsPcsControlsInBasket = new List<LaptopsPcsControl>();
        public int getPriceLaptopsPcsInBasket()  // Income from books that are on the basket
        {
            int summa = 0;
            if (laptopsPcsControlsInBasket.Count > 0)
            {
                for (int i = 0; i < laptopsPcsControlsInBasket.Count; i++)
                {
                    summa += laptopsPcsControlsInBasket[i].Price * laptopsPcsControlsInBasket[i].infoComboQuantitySelected();
                }
                return summa;
            }
            return 0;
        }
        public void addLaptopsPcsItems(LaptopsPcsControl addLaptopsPcs)
        {
            laptopsPcsControlsInBasket.Add(addLaptopsPcs);
        }

        public void finallyAddedToFlowLaptopsPcs()
        {
            for (int i = 0; i < laptopsPcsControlsInBasket.Count; i++)
            {
                flowLayoutPanelBasket.Controls.Add(laptopsPcsControlsInBasket[i]);
            }
        }

        public List<LaptopsPcsControl> getLaptopsPcsInBasket()
        {
            return laptopsPcsControlsInBasket;
        }

        public void changeLaptopsPcsControlsInBasket(LaptopsPcsControl newLaptopsPcsItem, LaptopsPcsControl deletelaptopsPcsControls)
        {
            int newQuantityCombo = newLaptopsPcsItem.infoComboQuantitySelected() + deletelaptopsPcsControls.infoComboQuantitySelected();
            if (newQuantityCombo > newLaptopsPcsItem.infoComboQuantityAmount()) 
            { 
                laptopsPcsControlsInBasket.Remove(deletelaptopsPcsControls);
                flowLayoutPanelBasket.Controls.Remove(deletelaptopsPcsControls); // delete from flowlayout old string of data
                laptopsPcsControlsInBasket.Add(newLaptopsPcsItem);
            }
            else
            {
                newLaptopsPcsItem.setSelectedQuantity(newQuantityCombo);
                laptopsPcsControlsInBasket.Remove(deletelaptopsPcsControls);
                flowLayoutPanelBasket.Controls.Remove(deletelaptopsPcsControls); // delete from flowlayout old string of data
                laptopsPcsControlsInBasket.Add(newLaptopsPcsItem);
            }
        }

        public bool checkSimilarAddedLaptopsPcs(LaptopsPcsControl laptopsPcsItem)
        {
            if (getLaptopsPcsInBasket().Count != 0)
            {
                for (int i = 0; i < getLaptopsPcsInBasket().Count; i++)
                {
                    if (getLaptopsPcsInBasket()[i].Title == laptopsPcsItem.Title)
                    {
                        changeLaptopsPcsControlsInBasket(laptopsPcsItem, getLaptopsPcsInBasket()[i]);
                        return true;
                    }
                }
            }
            return false;
        }
        // end LaptopsPcs----------------------------------------------------------------------------------------------------------------------------------------

        // For HeadPhones----------------------------------------------------------------------------------------------------------------------------------------

        private List<HphonesControl> hphonesControlsInBasket = new List<HphonesControl>();
        public int getPriceHphonesInBasket()  // Income from books that are on the basket
        {
            int summa = 0;
            if (hphonesControlsInBasket.Count > 0)
            {
                for (int i = 0; i < hphonesControlsInBasket.Count; i++)
                {
                    summa += hphonesControlsInBasket[i].Price * hphonesControlsInBasket[i].infoComboQuantitySelected();
                }
                return summa;
            }
            return 0;
        }
        public void addHphones(HphonesControl addHphones)
        {
            hphonesControlsInBasket.Add(addHphones);
        }
        public void finallyAddedToFlowHphones()
        {
            for (int i = 0; i < hphonesControlsInBasket.Count; i++)
            {
                flowLayoutPanelBasket.Controls.Add(hphonesControlsInBasket[i]);
            }
        }
        public List<HphonesControl> getHphonesInBasket()
        {
            return hphonesControlsInBasket;
        }
        public void changeHphonesControlsInBasket(HphonesControl newHphonesItem, HphonesControl deleteHphones)
        {
            int newQuantityCombo = newHphonesItem.infoComboQuantitySelected() + deleteHphones.infoComboQuantitySelected();
            if(newQuantityCombo > newHphonesItem.infoComboQuantityAmount())
            {
                hphonesControlsInBasket.Remove(deleteHphones);
                flowLayoutPanelBasket.Controls.Remove(deleteHphones);
                hphonesControlsInBasket.Add(newHphonesItem);
            }
            else
            {
                newHphonesItem.setSelectedQuantity(newQuantityCombo);
                hphonesControlsInBasket.Remove(deleteHphones);
                flowLayoutPanelBasket.Controls.Remove(deleteHphones);
                hphonesControlsInBasket.Add(newHphonesItem);
            }
        }
        public bool checkSimilarAddedHphones(HphonesControl HphonesItem)
        {
            if (getHphonesInBasket().Count != 0)
            {
                for (int i = 0; i < getHphonesInBasket().Count; i++)
                {
                    if (getHphonesInBasket()[i].Title == HphonesItem.Title)
                    {
                        changeHphonesControlsInBasket(HphonesItem, getHphonesInBasket()[i]);
                        return true;
                    }
                }
            }
            return false;
        }
        // end HeadPhones----------------------------------------------------------------------------------------------------------------------------------------

        // For TVs----------------------------------------------------------------------------------------------------------------------------------------

        private List<TvsControl> tvsControlsInBasket = new List<TvsControl>();
        public int getPriceTvsInBasket()  // Income from books that are on the basket
        {
            int summa = 0;
            if (tvsControlsInBasket.Count > 0)
            {
                for (int i = 0; i < tvsControlsInBasket.Count; i++)
                {
                    summa += tvsControlsInBasket[i].Price * tvsControlsInBasket[i].infoComboQuantitySelected();
                }
                return summa;
            }
            return 0;
        }
        public void addTvs(TvsControl tvs)
        {
            tvsControlsInBasket.Add(tvs);
        }
        public void finallyAddedToFlowTvs()
        {
            for (int i = 0; i < tvsControlsInBasket.Count; i++)
            {
                flowLayoutPanelBasket.Controls.Add(tvsControlsInBasket[i]);
            }
        }
        public List<TvsControl> getTvsInBasket()
        {
            return tvsControlsInBasket;
        }
        public void changeTvsControlsInBasket(TvsControl newTvsItem, TvsControl deleteTvs)
        {
            int newQuantityCombo = newTvsItem.infoComboQuantitySelected() + deleteTvs.infoComboQuantitySelected();
            if (newQuantityCombo > newTvsItem.infoComboQuantityAmount())
            {
                tvsControlsInBasket.Remove(deleteTvs);
                flowLayoutPanelBasket.Controls.Remove(deleteTvs);
                tvsControlsInBasket.Add(newTvsItem);
            }
            else
            {
                newTvsItem.setSelectedQuantity(newQuantityCombo);
                tvsControlsInBasket.Remove(deleteTvs);
                flowLayoutPanelBasket.Controls.Remove(deleteTvs);
                tvsControlsInBasket.Add(newTvsItem);
            }
        }
        public bool checkSimilarAddedTvs(TvsControl TvsItem)
        {
            if (getTvsInBasket().Count != 0)
            {
                for (int i = 0; i < getTvsInBasket().Count; i++)
                {
                    if (getTvsInBasket()[i].Title == TvsItem.Title)
                    {
                        changeTvsControlsInBasket(TvsItem, getTvsInBasket()[i]);
                        return true;
                    }
                }
            }
            return false;
        }
        // end Tvs----------------------------------------------------------------------------------------------------------------------------------------------------

        //For SmartWhatches-------------------------------------------------------------------------------------------------------------------------------------------
        private List<SmartWatchControl> smartWatchControlsInBasket = new List<SmartWatchControl>();
        public int getPriceSmartWatchInBasket()  // Income from books that are on the basket
        {
            int summa = 0;
            if (smartWatchControlsInBasket.Count > 0)
            {
                for (int i = 0; i < smartWatchControlsInBasket.Count; i++)
                {
                    summa += smartWatchControlsInBasket[i].Price * smartWatchControlsInBasket[i].infoComboQuantitySelected();
                }
                return summa;
            }
            return 0;
        }
        public void addSmartWatch(SmartWatchControl smartWatch)
        {
            smartWatchControlsInBasket.Add(smartWatch);
        }
        public List<SmartWatchControl> getSmartWatchInBasket()
        {
            return smartWatchControlsInBasket;
        }
        public void finallyAddedToFlowSmartWatches()
        {
            for (int i = 0; i < smartWatchControlsInBasket.Count; i++)
            {
                flowLayoutPanelBasket.Controls.Add(smartWatchControlsInBasket[i]);
            }
        }
        public void changeSmartWathesControlsInBasket(SmartWatchControl newSmartWatchesItem, SmartWatchControl deleteSmartWatches)
        {
            int newQuantityCombo = newSmartWatchesItem.infoComboQuantitySelected() + deleteSmartWatches.infoComboQuantitySelected();
            if (newQuantityCombo > newSmartWatchesItem.infoComboQuantityAmount())
            {
                smartWatchControlsInBasket.Remove(deleteSmartWatches);
                flowLayoutPanelBasket.Controls.Remove(deleteSmartWatches);
                smartWatchControlsInBasket.Add(newSmartWatchesItem);
            }
            else
            {
                newSmartWatchesItem.setSelectedQuantity(newQuantityCombo);
                smartWatchControlsInBasket.Remove(deleteSmartWatches);
                flowLayoutPanelBasket.Controls.Remove(deleteSmartWatches);
                smartWatchControlsInBasket.Add(newSmartWatchesItem);
            }
        }
        public bool checkSimilarAddedSmartWatches(SmartWatchControl SmartWatchesItem)
        {
            if (getSmartWatchInBasket().Count != 0)
            {
                for (int i = 0; i < getSmartWatchInBasket().Count; i++)
                {
                    if (getSmartWatchInBasket()[i].Title == SmartWatchesItem.Title)
                    {
                        changeSmartWathesControlsInBasket(SmartWatchesItem, getSmartWatchInBasket()[i]);
                        return true;
                    }
                }
            }
            return false;
        }
        // end SmartWhatches------------------------------------------------------------------------------------------------------------------------------------------

        // For SmartPhones
        private List<SmartPhonesControl> smartPhonesControlsInBasket = new List<SmartPhonesControl>();
        public int getPriceSmartPhonesInBasket()  // Income from books that are on the basket
        {
            int summa = 0;
            if (smartPhonesControlsInBasket.Count > 0)
            {
                for (int i = 0; i < smartPhonesControlsInBasket.Count; i++)
                {
                    summa += smartPhonesControlsInBasket[i].Price * smartPhonesControlsInBasket[i].infoComboQuantitySelected();
                }
                return summa;
            }
            return 0;
        }
        public void addSmartPhone(SmartPhonesControl smartPhone)
        {
            smartPhonesControlsInBasket.Add(smartPhone);
        }

        public List<SmartPhonesControl> getSmartPhonesInBasket()
        {
            return smartPhonesControlsInBasket;
        }

        public void finallyAddedToFlowSmartPhones()
        {
            for (int i = 0; i < smartPhonesControlsInBasket.Count; i++)
            {
                flowLayoutPanelBasket.Controls.Add(smartPhonesControlsInBasket[i]);
            }
        }
        public void changeSmartPhonesControlsInBasket(SmartPhonesControl newSmartPhonesItem, SmartPhonesControl deleteSmartPhones)
        {
            int newQuantityCombo = newSmartPhonesItem.infoComboQuantitySelected() + deleteSmartPhones.infoComboQuantitySelected();
            if (newQuantityCombo > newSmartPhonesItem.infoComboQuantityAmount())
            {
                smartPhonesControlsInBasket.Remove(deleteSmartPhones);
                flowLayoutPanelBasket.Controls.Remove(deleteSmartPhones);
                smartPhonesControlsInBasket.Add(newSmartPhonesItem);
            }
            else
            {
                newSmartPhonesItem.setSelectedQuantity(newQuantityCombo);
                smartPhonesControlsInBasket.Remove(deleteSmartPhones);
                flowLayoutPanelBasket.Controls.Remove(deleteSmartPhones);
                smartPhonesControlsInBasket.Add(newSmartPhonesItem);
            }
        }
        public bool checkSimilarAddedSmartPhones(SmartPhonesControl SmartPhonesItem)
        {
            if (getSmartPhonesInBasket().Count != 0)
            {
                for (int i = 0; i < getSmartPhonesInBasket().Count; i++)
                {
                    if (getSmartPhonesInBasket()[i].Title == SmartPhonesItem.Title)
                    {
                        changeSmartPhonesControlsInBasket(SmartPhonesItem, getSmartPhonesInBasket()[i]);
                        return true;
                    }
                }
            }
            return false;
        }
        // end  SmartPhones-------------------------------------------------------------------------------------------------------------------------------------------

        // FOR Clothes---------------------------------------------------------------------------------------------------------------------------------------------------
        private List<ClothesControl> clothesControlsInBasket = new List<ClothesControl>();
        public int getPriceClothesInBasket()  // Income from books that are on the basket
        {
            int summa = 0;
            if (clothesControlsInBasket.Count > 0)
            {
                for (int i = 0; i < clothesControlsInBasket.Count; i++)
                {
                    summa += clothesControlsInBasket[i].Price * clothesControlsInBasket[i].infoComboQuantitySelected();
                }
                return summa;
            }
            return 0;
        }
        public void addClothesItems(ClothesControl addClothesItems)
        {
            clothesControlsInBasket.Add(addClothesItems);
        }

        public void finallyAddedToFlowClothes()
        {
            for (int i = 0; i < clothesControlsInBasket.Count; i++)
            {
                flowLayoutPanelBasket.Controls.Add(clothesControlsInBasket[i]);
            }
        }

        public List<ClothesControl> getClothesInBasket()
        {
            return clothesControlsInBasket;
        }

        public void changeClothesControlsInBasket(ClothesControl newClothesItem, ClothesControl deleteClothes)
        {
            int newQuantityCombo = newClothesItem.infoComboQuantitySelected() + deleteClothes.infoComboQuantitySelected();
            if (newQuantityCombo > newClothesItem.infoComboQuantityAmount())
            {
                clothesControlsInBasket.Remove(deleteClothes);
                flowLayoutPanelBasket.Controls.Remove(deleteClothes);  // delete from flowlayout old string of data
                clothesControlsInBasket.Add(newClothesItem);
            }
            else
            {
                newClothesItem.setSelectedQuantity(newQuantityCombo);
                clothesControlsInBasket.Remove(deleteClothes);
                flowLayoutPanelBasket.Controls.Remove(deleteClothes);  // delete from flowlayout old string of data
                clothesControlsInBasket.Add(newClothesItem);
            }
        }

        public bool checkSimilarAddedClothes(ClothesControl addClothesItem)
        {
            if (getClothesInBasket().Count != 0)
            {
                for (int i = 0; i < getClothesInBasket().Count; i++)
                {
                    if (getClothesInBasket()[i].Title == addClothesItem.Title)
                    {
                        changeClothesControlsInBasket(addClothesItem, getClothesInBasket()[i]);
                        return true;
                    }
                }
            }
            return false;
        }
        // End books----------------------------------------------------------------------------------------------------------------------------------------------



        ////////////////////////////
        ///////////// Creating ORDER
        ////////////////////////////
        ///
        
        public void createOrder() // ДОБАВИТЬ ОЧИСТКУ И ЗАКРЫТИЕ КОРЗИНЫ ПОСЛЕ ПОДТВЕРЖДЕНИЯ ЗАКАЗА!!!!!!!!
        {
            void addingToBookPurchase()
            {
                for (int i = 0; i < getBooksInBasket().Count; i++)
                {
                    if(getBooksInBasket()[i].infoComboQuantitySelected() > 0)
                    {
                        workServerBasket.createBookPurchaseTable(getBooksInBasket()[i].Title, getBooksInBasket()[i].Author, getBooksInBasket()[i].Price,
                                                                 getBooksInBasket()[i].infoComboQuantitySelected(), 
                                                                 workServerBasket.UsersId(UserNameLabelBasket.Text));
                        workServerBasket.updateQuantityItemsInTables(getBooksInBasket()[i].getNameTable(), getBooksInBasket()[i].Title,
                                                                     getBooksInBasket()[i].infoComboQuantityAmount() - getBooksInBasket()[i].infoComboQuantitySelected());
                    }
                }
            }
            void addingToClothesPurchase()
            {
                for (int i = 0; i < getClothesInBasket().Count; i++)
                {
                    if(getClothesInBasket()[i].infoComboQuantitySelected() > 0)
                    {
                        workServerBasket.createClothesPurchaseTable(getClothesInBasket()[i].Title, getClothesInBasket()[i].Brand, getClothesInBasket()[i].Material,
                                                                    getClothesInBasket()[i].Sex, getClothesInBasket()[i].Price, 
                                                                    getClothesInBasket()[i].infoComboQuantitySelected(),
                                                                    workServerBasket.UsersId(UserNameLabelBasket.Text));
                        workServerBasket.updateQuantityItemsInTables(getClothesInBasket()[i].getNameTable(), getClothesInBasket()[i].Title,
                                                                     getClothesInBasket()[i].infoComboQuantityAmount() - getClothesInBasket()[i].infoComboQuantitySelected());
                    }
                }
            }
            void addingToLaptopsPcsPurchase()
            {
                for (int i = 0; i < getLaptopsPcsInBasket().Count; i++)
                {
                    if(getLaptopsPcsInBasket()[i].infoComboQuantitySelected() > 0)
                    {
                        workServerBasket.createLaptopsPcsPurchaseTable(getLaptopsPcsInBasket()[i].Title, getLaptopsPcsInBasket()[i].CPU, getLaptopsPcsInBasket()[i].RAM,
                                                                       getLaptopsPcsInBasket()[i].HDD, getLaptopsPcsInBasket()[i].SSD, getLaptopsPcsInBasket()[i].GPU,
                                                                       getLaptopsPcsInBasket()[i].OS, getLaptopsPcsInBasket()[i].Price, 
                                                                       getLaptopsPcsInBasket()[i].infoComboQuantitySelected(),
                                                                       workServerBasket.UsersId(UserNameLabelBasket.Text));
                        workServerBasket.updateQuantityItemsInTables(getLaptopsPcsInBasket()[i].getNameTable(), getLaptopsPcsInBasket()[i].Title,
                                         getLaptopsPcsInBasket()[i].infoComboQuantityAmount() - getLaptopsPcsInBasket()[i].infoComboQuantitySelected());
                    }
                }
            }
            void addingToHphonesPurchase()
            {
                for (int i = 0; i < getHphonesInBasket().Count; i++)
                {
                    if(getHphonesInBasket()[i].infoComboQuantitySelected() > 0)
                    {
                        workServerBasket.createHphonesPurchaseTable(getHphonesInBasket()[i].Title, getHphonesInBasket()[i].Mic, getHphonesInBasket()[i].Type,
                                                                    getHphonesInBasket()[i].WorkingHours, getHphonesInBasket()[i].Resistance,
                                                                    getHphonesInBasket()[i].Price, getHphonesInBasket()[i].infoComboQuantitySelected(),
                                                                    workServerBasket.UsersId(UserNameLabelBasket.Text));
                        workServerBasket.updateQuantityItemsInTables(getHphonesInBasket()[i].getNameTable(), getHphonesInBasket()[i].Title,
                                         getHphonesInBasket()[i].infoComboQuantityAmount() - getHphonesInBasket()[i].infoComboQuantitySelected());
                    }
                }
            }
            void addingToTvsPurchase()
            {
                for (int i = 0; i < getTvsInBasket().Count; i++)
                {
                    if(getTvsInBasket()[i].infoComboQuantitySelected() > 0)
                    {
                        workServerBasket.createTvsPurchaseTable(getTvsInBasket()[i].Title, getTvsInBasket()[i].ScreenDiagonal, getTvsInBasket()[i].Resolution,
                                                                getTvsInBasket()[i].Features, getTvsInBasket()[i].Price, getTvsInBasket()[i].infoComboQuantitySelected(),
                                                                workServerBasket.UsersId(UserNameLabelBasket.Text));
                        workServerBasket.updateQuantityItemsInTables(getTvsInBasket()[i].getNameTable(), getTvsInBasket()[i].Title,
                                         getTvsInBasket()[i].infoComboQuantityAmount() - getTvsInBasket()[i].infoComboQuantitySelected());
                    }
                }
            }
            void addingToSmartWatchesPurchase()
            {
                for (int i = 0; i < getSmartWatchInBasket().Count; i++)
                {
                    if(getSmartWatchInBasket()[i].infoComboQuantitySelected() > 0)
                    {
                        workServerBasket.createSmartWathesTable(getSmartWatchInBasket()[i].Title, getSmartWatchInBasket()[i].CompatibleOS,
                                                                getSmartWatchInBasket()[i].Sensors, getSmartWatchInBasket()[i].ScreenResolution,
                                                                getSmartWatchInBasket()[i].Price, getSmartWatchInBasket()[i].infoComboQuantitySelected(),
                                                                workServerBasket.UsersId(UserNameLabelBasket.Text));
                        workServerBasket.updateQuantityItemsInTables(getSmartWatchInBasket()[i].getNameTable(), getSmartWatchInBasket()[i].Title,
                                         getSmartWatchInBasket()[i].infoComboQuantityAmount() - getSmartWatchInBasket()[i].infoComboQuantitySelected());
                    }
                }
            }
            void addingToSmartPhonesPurchase()
            {
                for (int i = 0; i < getSmartPhonesInBasket().Count; i++)
                {
                    if(getSmartPhonesInBasket()[i].infoComboQuantitySelected() > 0)
                    {
                        workServerBasket.createSmartPhonesTable(getSmartPhonesInBasket()[i].Title, getSmartPhonesInBasket()[i].InternalMemory,
                                                                getSmartPhonesInBasket()[i].Ram, getSmartPhonesInBasket()[i].CameraResolution,
                                                                getSmartPhonesInBasket()[i].ScreenDiagonal, getSmartPhonesInBasket()[i].Capacity,
                                                                getSmartPhonesInBasket()[i].Price, getSmartPhonesInBasket()[i].infoComboQuantitySelected(),
                                                                workServerBasket.UsersId(UserNameLabelBasket.Text));
                        workServerBasket.updateQuantityItemsInTables(getSmartPhonesInBasket()[i].getNameTable(), getSmartPhonesInBasket()[i].Title,
                                         getSmartPhonesInBasket()[i].infoComboQuantityAmount() - getSmartPhonesInBasket()[i].infoComboQuantitySelected());
                    }
                }
            }

            addingToBookPurchase();
            addingToClothesPurchase();
            addingToLaptopsPcsPurchase();
            addingToHphonesPurchase();
            addingToTvsPurchase();
            addingToSmartWatchesPurchase();
            addingToSmartPhonesPurchase();
        }

        private void clearBasketItems() // clearing basket and flowlayoutpanel after order is confirmed
        {
            booksControlsInBasket.Clear();
            clothesControlsInBasket.Clear();
            laptopsPcsControlsInBasket.Clear();
            hphonesControlsInBasket.Clear();
            tvsControlsInBasket.Clear();
            smartWatchControlsInBasket.Clear();
            smartPhonesControlsInBasket.Clear();
            flowLayoutPanelBasket.Controls.Clear();
        }
        private void buttonCheckout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите продолжить?", "Оформление заказа",
               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                createOrder();
                this.Hide();
                clearBasketItems();
            }
        }
    }
}
