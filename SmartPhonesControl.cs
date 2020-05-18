using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course1
{
    public partial class SmartPhonesControl : UserControl
    {
        public SmartPhonesControl(string _title, int _internalMemory, int _ram, int _cameraResolution, double _screenDiagonal, int _capaticy, 
                                  int _price, int _quantity, string[] _quantityCombo, Basket basketItem)
        {
            InitializeComponent();
            Title = _title;
            InternalMemory = _internalMemory;
            Ram = _ram;
            CameraResolution = _cameraResolution;
            ScreenDiagonal = _screenDiagonal;
            Capacity = _capaticy;
            Price = _price;
            Quantity = _quantity;
            QuantityCombo = _quantityCombo;

            basket = basketItem;
        }
        private Basket basket;

        private string _title;
        private int _internalMemory;
        private int _ram;
        private int _cameraResolution;
        private double _screenDiagonal;
        private int _capaticy;
        private int _price;
        private int _quantity;
        private string[] _quantityCombo;

        public string Title
        {
            get { return _title; }
            set { _title = value; labelNameSmartPhone.Text = value; }
        }

        public int InternalMemory
        {
            get { return _internalMemory; }
            set { _internalMemory = value; labelInternalMemory.Text = value.ToString() + " ГБ"; }
        }

        public int Ram
        {
            get { return _ram; }
            set { _ram = value; labelRAM.Text = value.ToString() + " ГБ"; }
        }

        public int CameraResolution
        {
            get { return _cameraResolution; }
            set { _cameraResolution = value; labelResolutionCamera.Text = value.ToString() + " Мпикс"; }
        }

        public double ScreenDiagonal
        {
            get { return _screenDiagonal; }
            set { _screenDiagonal = value; labelScreenDiagonal.Text = value.ToString() + " дюйм"; }
        }

        public int Capacity
        {
            get { return _capaticy; }
            set { _capaticy = value; labelCapacity.Text = value.ToString() + " мAч"; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; labelPriceSmartPhones.Text = value.ToString() + " р."; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; labelQuantitySmartPhones.Text = value.ToString() + " шт"; }
        }

        public string[] QuantityCombo
        {
            get { return _quantityCombo; }
            set { _quantityCombo = value; comboQuantitySmartPhones.Items.Clear();
                comboQuantitySmartPhones.Items.AddRange(value); }
        }

        public int infoComboQuantitySelected()
        {
            return comboQuantitySmartPhones.SelectedIndex;
        }
        public int infoComboQuantityAmount()
        {
            return comboQuantitySmartPhones.Items.Count-1;
        }
        public void setSelectedQuantity(int selected)
        {
            comboQuantitySmartPhones.SelectedIndex = selected;
        }

        private void comboQuantitySmartPhones_DropDownClosed(object sender, EventArgs e)
        {
            basket.totalPrice();
        }
    }

    public class ManageSmartPhone
    {
        private List<SmartPhonesControl> smartPhonesControlsItems = new List<SmartPhonesControl>();
        public ManageSmartPhone() { }
        public void createSmartPhone(string _title, int _internalMemory, int _ram, int _cameraResolution, double _screenDiagonal, int _capaticy,
                                     int _price, int _quantity, string[] _quantityCombo, Basket basketItem)
        {
            smartPhonesControlsItems.Add(new SmartPhonesControl(_title, _internalMemory, _ram, _cameraResolution, _screenDiagonal,
                                         _capaticy, _price, _quantity, _quantityCombo, basketItem));
        }

        public List<SmartPhonesControl> getAllSmartPhones()
        {
            return smartPhonesControlsItems;
        }
    }
}

