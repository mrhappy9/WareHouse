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
    public partial class SmartWatchControl : UserControl
    {
        public SmartWatchControl(string _title, string _compatibleOS, string _sensors, string _screenResolution,
                                     int _price, int _quantity, string[] _quantityCombo, Basket basketItems)
        {
            InitializeComponent();
            Title = _title;
            CompatibleOS = _compatibleOS;
            Sensors = _sensors;
            ScreenResolution = _screenResolution;
            Price = _price;
            Quantity = _quantity;
            QuantityCombo = _quantityCombo;

            basket = basketItems;
        }
        private Basket basket;

        private string _title;
        private string _compatibleOS;
        private string _sensors;
        private string _screenResolution;
        private int _price;
        private int _quantity;
        private string[] _quantityCombo;

        public string Title
        {
            get { return _title; }
            set { _title = value; labelNameSmartWatch.Text = value; }
        }

        public string CompatibleOS
        {
            get { return _compatibleOS; }
            set { _compatibleOS = value; labelCompatibleOS.Text = value; }
        }

        public string Sensors
        {
            get { return _sensors; }
            set { _sensors = value; labelSensors.Text = value; }
        }

        public string ScreenResolution
        {
            get { return _screenResolution; }
            set { _screenResolution = value; labelResolution.Text = value; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; labelPriceSmartWatch.Text = value.ToString() + " р."; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; labelQuantitySmartWatch.Text = value.ToString() + " шт"; }
        }

        public string[] QuantityCombo
        {
            get { return _quantityCombo; }
            set { _quantityCombo = value; comboQuantitySmartWatch.Items.Clear();
                comboQuantitySmartWatch.Items.AddRange(value); }
        }

        public int infoComboQuantitySelected()
        {
            return comboQuantitySmartWatch.SelectedIndex;
        }
        public int infoComboQuantityAmount()
        {
            return comboQuantitySmartWatch.Items.Count-1;
        }
        public void setSelectedQuantity(int selected)
        {
            comboQuantitySmartWatch.SelectedIndex = selected;
        }

        private void comboQuantitySmartWatch_DropDownClosed(object sender, EventArgs e)
        {
            basket.totalPrice();
        }
    }

    public class ManageSmartWatch
    {
        private List<SmartWatchControl> smartWatchControlsItems = new List<SmartWatchControl>();
        public ManageSmartWatch() { }

        public void createSmartWatch(string _title, string _compatibleOS, string _sensors, string _screenResolution, 
                                     int _price, int _quantity, string[] _quantityCombo, Basket basketItems)
        {
            smartWatchControlsItems.Add(new SmartWatchControl(_title, _compatibleOS, _sensors, _screenResolution, _price, _quantity, _quantityCombo, basketItems));
        }

        public List<SmartWatchControl> getAllSmartWatch()
        {
            return smartWatchControlsItems;
        }
    }
}
