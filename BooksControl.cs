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
    public partial class BooksControl : UserControl
    {
        public BooksControl()
        {
            InitializeComponent();
        }
        public BooksControl(string _title, string _author, int _price, int _quantity, string[] _quantityCombo, Basket basketItems, string nameTable/*, Image _picture*/)
        {
            InitializeComponent();
            Title = _title;
            Author = _author;
            Price = _price;
            Quantity = _quantity;
            QuantityCombo = _quantityCombo;

            basket = basketItems;
            this.nameTable = nameTable;
        }
        private Basket basket;
        private string nameTable;

        private string _title;
        private string _author;
        private int _price;
        private int _quantity;
        private string[] _quantityCombo;
        private Image _picture;

        public string getNameTable()
        {
            return nameTable;
        }

        public Image PictureBook
        {
            get { return _picture; }
            set
            {
                _picture = value; pictureBoxBooks.Image = value;
            }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; labelNameBook.Text = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; labelNameAuthor.Text = value; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; labelBooksPrice.Text = value.ToString() + " р."; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; labelQuantityBooks.Text = value.ToString() + " шт"; }
        }

        public string[] QuantityCombo
        {
            get { return _quantityCombo; }
            set { _quantityCombo = value; comboQuantityBooks.Items.Clear(); comboQuantityBooks.Items.AddRange(value); }
        }

        public BooksControl getAllBooks() { return this; }
        
        public int infoComboQuantitySelected()
        {
            return comboQuantityBooks.SelectedIndex;
        }

        public int infoComboQuantityAmount()
        {
            return comboQuantityBooks.Items.Count-1;
        }

        public void setSelectedQuantity(int selected)
        {
            comboQuantityBooks.SelectedIndex = selected;
        }

        private void comboQuantityBooks_DropDownClosed(object sender, EventArgs e)
        {
            basket.totalPrice();
        }
    }

    public class ManageBook
    {
        private List<BooksControl> booksControlsItems = new List<BooksControl>();

        public void createBook(string _title, string _author, int _price, int _quantity, string[] _quantityCombo, Basket basketItems, string nameTable)
        {
            booksControlsItems.Add(new BooksControl(_title, _author, _price, _quantity, _quantityCombo, basketItems, nameTable));
        }
        public ManageBook() { }
        public List<BooksControl> getAllManageBooks()
        {
            return booksControlsItems;
        }
    }
}
