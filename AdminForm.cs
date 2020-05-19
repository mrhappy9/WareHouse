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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }
        private Color defualtColor = Color.FromArgb(21, 21, 21);
        WorkServer workServerAdmin = new WorkServer();

        private void setDefaultItemsColor() 
        {
            panelAddItem.BackColor = panelChange.BackColor = panelDelete.BackColor =
            pictureBoxAddItem.BackColor = pictureBoxChange.BackColor = pictureBoxDelete.BackColor = defualtColor;
        }
        private void changeItemsColor(PictureBox picture, Panel panel)
        {
            picture.BackColor = Color.FromArgb(28, 28, 28);
            panel.BackColor = Color.FromArgb(28, 28, 28);
        }

        private void changeLabel_Click(object sender, EventArgs e)
        {
            setDefaultItemsColor();
            changeItemsColor(pictureBoxChange, panelChange);
        }

        private void addItemsLabel_Click(object sender, EventArgs e)
        {
            setDefaultItemsColor();
            changeItemsColor(pictureBoxAddItem, panelAddItem);
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
            setDefaultItemsColor();
        }

    }
}
