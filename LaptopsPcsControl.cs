using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Course1
{
    public partial class LaptopsPcsControl : UserControl
    {
        public LaptopsPcsControl(string _name, string _cpu, int _ram, int _hdd, int _ssd, string _gpu, string _os, int _price,
                              int _quantity, string[] _quantityCombo, Basket basketItem, string nameTable)
        {
            InitializeComponent();
            Title = _name;
            CPU = _cpu;
            RAM = _ram;
            HDD = _hdd;
            SSD = _ssd;
            GPU = _gpu;
            OS = _os;
            Price = _price;
            Quantity = _quantity;
            QuantityCombo = _quantityCombo;

            basket = basketItem;
            this.nameTable = nameTable;
        }
        private string nameTable;
        private Basket basket;

        private string _name;
        private string _cpu;
        private int _ram;
        private int _hdd;
        private int _ssd;
        private string _gpu;
        private string _os;
        private int _price;
        private int _quantity;
        private string[] _quantityCombo;
        private Image _picture;

        public string getNameTable() { return nameTable; }

        public string Title
        {
            get { return _name; }
            set { _name = value; labelNameLaptop.Text = value; }
        }

        public string CPU
        {
            get { return _cpu; }
            set { _cpu = value; labelCPU.Text = value; }
        }

        public int RAM
        {
            get { return _ram; }
            set { _ram = value; labelRAM.Text = value.ToString() + " ГБ"; }
        }

        public int HDD
        {
            get { return _hdd; }
            set { _hdd = value; labelHDD.Text = value.ToString() + " ГБ"; }
        }
        public int SSD
        {
            get { return _ssd; }
            set { _ssd = value; labelSSD.Text = value.ToString() + " ГБ"; }
        }
        
        public string GPU
        {
            get { return _gpu; }
            set { _gpu = value; labelGPU.Text = value; }
        }

        public string OS
        {
            get { return _os; }
            set { _os = value; labelOS.Text = value; }
        }
        public int Price
        {
            get { return _price; }
            set { _price = value; labelLaptopPrice.Text = value.ToString() + " р."; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; labelQuantityLaptops.Text = value.ToString() + " шт"; }
        }

        public string[] QuantityCombo
        {
            get { return _quantityCombo; }
            set { _quantityCombo = value; comboQuantityLaptops.Items.Clear();
                   comboQuantityLaptops.Items.AddRange(value); }
        }

        public Image Picture
        {
            get { return _picture; }
            set { _picture = value; pictureBoxLaptops.Image = value; }
        }

        public int infoComboQuantitySelected()
        {
            return comboQuantityLaptops.SelectedIndex;
        }
        public int infoComboQuantityAmount()
        {
            return comboQuantityLaptops.Items.Count-1;
        }

        public void setSelectedQuantity(int selected)
        {
            comboQuantityLaptops.SelectedIndex = selected;
        }

        public LaptopsPcsControl getAllLaptops() { return this; }

        private void comboQuantityLaptops_DropDownClosed(object sender, EventArgs e)
        {
            basket.totalPrice();
        }
    }

    public class ManageLaptopsPcs
    {
        private List<LaptopsPcsControl> laptopsControlItems = new List<LaptopsPcsControl>();
        public ManageLaptopsPcs() { }
        
        public void createLaptopPcs(string _name, string _cpu, int _ram, int _hdd, int _ssd, string _gpu, string _os, int _price,
                                 int _quantity, string[] _quantityCombo, Basket basketItem, string nameTable)
        {
            laptopsControlItems.Add(new LaptopsPcsControl(_name, _cpu, _ram, _hdd, _ssd, _gpu, _os, _price, _quantity,
                                    _quantityCombo, basketItem, nameTable));
        }

        public List<LaptopsPcsControl> getAllManageLaptops()
        {
            return laptopsControlItems;
        }
    }
}
