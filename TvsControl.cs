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
    public partial class TvsControl : UserControl
    {
        public TvsControl(string _title, double _screenDiagonal, string _resolution, string _features, int _price, int _quantity, 
                          string[] _quantityCombo, Basket basketItem, string nameTable)
        {
            InitializeComponent();
            Title = _title;
            ScreenDiagonal = _screenDiagonal;
            Resolution = _resolution;
            Features = _features;
            Price = _price;
            Quantity = _quantity;
            QuantityCombo = _quantityCombo;

            basket = basketItem;
            this.nameTable = nameTable;
        }
        private string nameTable;
        private Basket basket;

        private string _title;
        private double _screenDiagonal;
        private string _resolution;
        private string _features;
        private int _price;
        private int _quantity;
        private string[] _quantityCombo;

        public string getNameTable() { return nameTable; }

        public string Title
        {
            get { return _title; }
            set { _title = value; labelNameTvs.Text = value; }
        }

        public double ScreenDiagonal
        {
            get { return _screenDiagonal; }
            set { _screenDiagonal = value; labelDiagonal.Text = value.ToString(); }
        }

        public string Resolution
        {
            get { return _resolution; }
            set { _resolution = value; labelResolution.Text = value; }
        }

        public string Features
        {
            get { return _features; }
            set { _features = value; labelFeatures.Text = value; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; labelPriceTvs.Text = value.ToString() + " р."; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; labelQuantityTvs.Text = value.ToString() + " шт"; }
        }

        public string[] QuantityCombo
        {
            get { return _quantityCombo; }
            set { _quantityCombo = value; comboQuantityTvs.Items.Clear();
                comboQuantityTvs.Items.AddRange(value); }
        }

        public int infoComboQuantitySelected()
        {
            return comboQuantityTvs.SelectedIndex;
        }
        public int infoComboQuantityAmount()
        {
            return comboQuantityTvs.Items.Count-1;
        }
        public void setSelectedQuantity(int selected)
        {
            comboQuantityTvs.SelectedIndex = selected;
        }

        private void comboQuantityTvs_DropDownClosed(object sender, EventArgs e)
        {
            basket.totalPrice();
        }
    }

    public class ManageTvs
    {
        private List<TvsControl> tvsControlsItems = new List<TvsControl>();

        public ManageTvs() { }

        public void createTvs(string _title, double _screenDiagonal, string _resolution, string _features, int _price, 
                              int _quantity, string[] _quantityCombo, Basket basketItem, string nameTable)
        {
            tvsControlsItems.Add(new TvsControl(_title, _screenDiagonal, _resolution, _features, _price, _quantity, _quantityCombo, basketItem, nameTable));
        }

        public List<TvsControl> getAllTvs()
        {
            return tvsControlsItems;
        }
    }
}
