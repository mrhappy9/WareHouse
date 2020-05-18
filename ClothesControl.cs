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
    public partial class ClothesControl : UserControl
    {
        public ClothesControl(string _title, string _brand, string _material,
                              string _sex, int _price, int _quantity, string[] _quantityCombo, Basket basketItem, string nameTable)
        {
            InitializeComponent();
            Title = _title;
            Brand = _brand;
            Material = _material;
            Sex = _sex;
            Price = _price;
            Quantity = _quantity;
            QuantityCombo = _quantityCombo;

            basket = basketItem;
            this.nameTable = nameTable;
        }
        private string nameTable;
        private Basket basket;

        private string _title;
        private string _brand;
        private string _material;
        private string _sex;
        private int _price;
        private int _quantity;
        private string[] _quantityCombo;

        public string getNameTable() { return nameTable; }

        public string Title
        {
            get { return _title; }
            set { _title = value; labelNameClothes.Text = value; }
        }

        public string Brand
        {
            get { return _brand; }
            set { _brand = value; labelBrand.Text = value.ToString(); }
        }

        public string Material
        {
            get { return _material; }
            set { _material = value; labelMaterial.Text = value.ToString(); }
        }

        public string Sex
        {
            get { return _sex; }
            set { _sex = value; labelSex.Text = value.ToString(); }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; labelPriceClothes.Text = value.ToString() + " р."; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; labelQuantityClothes.Text = value.ToString() + " шт"; }
        }

        public string[] QuantityCombo
        {
            get { return _quantityCombo; }
            set { _quantityCombo = value; comboQuantityClothes.Items.Clear();
                   comboQuantityClothes.Items.AddRange(value); }
        }

        public int infoComboQuantitySelected()
        {
            return comboQuantityClothes.SelectedIndex;
        }
        public int infoComboQuantityAmount()
        { 
            return comboQuantityClothes.Items.Count - 1;
        }
        public void setSelectedQuantity(int selected)
        {
            comboQuantityClothes.SelectedIndex = selected;
        }

        private void comboQuantityClothes_DropDownClosed(object sender, EventArgs e)
        {
            basket.totalPrice();
        }
    }

    public class ManageClothes
    {
        private List<ClothesControl> clothesControlsItems = new List<ClothesControl>();
        public ManageClothes() { }
        
        public void createClothes(string _title, string _brand, string _material,
                                  string _sex,  int _price, int _quantity, string[] _quantityCombo, Basket basketItem, string nameTable)
        {
            clothesControlsItems.Add(new ClothesControl(_title, _brand, _material, _sex, _price, _quantity, _quantityCombo, basketItem, nameTable));
        }

        public List<ClothesControl> getAllClothes()
        {
            return clothesControlsItems;
        }
    }
}

