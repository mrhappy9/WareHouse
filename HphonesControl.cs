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
    public partial class HphonesControl : UserControl
    {
        public HphonesControl(string _title, string _mic, string _type, int _workingHours, int _resistance,
                              int _price, int _quantity, string[] _quantityCombo, Basket basketItem, string nameTable)
        {
            InitializeComponent();
            Title = _title;
            Mic = _mic;
            Type = _type;
            WorkingHours = _workingHours;
            Resistance = _resistance;
            Price = _price;
            Quantity = _quantity;
            QuantityCombo = _quantityCombo;

            basket = basketItem;
            this.nameTable = nameTable;
        }
        private string nameTable;
        private Basket basket;

        private string _title;
        private string _mic;
        private string _type;
        private int _workingHours;
        private int _resistance;
        private int _price;
        private int _quantity;
        private string[] _quantityCombo;

        public string getNameTable() { return nameTable; }

        public string Title
        {
            get { return _title; }
            set { _title = value; labelNameHphones.Text = value; }
        }

        public string Mic
        {
            get { return _mic; }
            set { _mic = value; labelMic.Text = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; labelType.Text = value; }
        }

        public int WorkingHours
        {
            get { return _workingHours; }
            set { _workingHours = value; labelWorkingHours.Text = value + " ч"; }
        }

        public int Resistance
        {
            get { return _resistance; }
            set { _resistance = value; labelResistance.Text = value.ToString() + " Ом"; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; labelPriceHphones.Text = value.ToString() + " р."; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; labelQuantityHphones.Text = value.ToString() + " шт"; }
        }

        public string[] QuantityCombo
        {
            get { return _quantityCombo; }
            set { _quantityCombo = value; comboQuantityHphones.Items.Clear();
                   comboQuantityHphones.Items.AddRange(value); }
        }

        public int infoComboQuantitySelected()
        {
            return comboQuantityHphones.SelectedIndex;
        }
        public int infoComboQuantityAmount()
        {
            return comboQuantityHphones.Items.Count-1;
        }
        public void setSelectedQuantity(int selected)
        {
            comboQuantityHphones.SelectedIndex = selected;
        }

        private void comboQuantityHphones_DropDownClosed(object sender, EventArgs e)
        {
            basket.totalPrice();
        }
    }

    public class ManageHphones
    {
        private List<HphonesControl> hphonesControlsItems = new List<HphonesControl>();
        public ManageHphones() { }

        public void createHphones(string _title, string _mic, string _type, int _workingHours, int _resistance, int _price, int _quantity, 
                                  string[] _quantityCombo, Basket basketItem, string nameTable)
        {
            hphonesControlsItems.Add(new HphonesControl(_title, _mic, _type, _workingHours, _resistance, _price, _quantity, _quantityCombo, basketItem, nameTable));
        }

        public List<HphonesControl> getAllHphones()
        {
            return hphonesControlsItems;
        }
    }
}
