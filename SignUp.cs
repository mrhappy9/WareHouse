using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Course1
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void logintext_Click(object sender, EventArgs e)
        {
            if (checkTextbox(logintext.Text))
                logintext.Clear();
            panel1.BackColor = Color.FromArgb(77, 207, 224);
            panel2.BackColor = Color.WhiteSmoke;
            panel3.BackColor = Color.WhiteSmoke;
            logintext.ForeColor = Color.FromArgb(77, 207, 224);
            passwordtext.ForeColor = Color.WhiteSmoke;
            emailtext.ForeColor = Color.WhiteSmoke;
            infoRegistration.Text = "";
        }
        private void passwordtext_Click(object sender, EventArgs e)
        {
            if (checkTextbox(passwordtext.Text))
                passwordtext.Clear();
            panel1.BackColor = Color.WhiteSmoke;
            panel2.BackColor = Color.FromArgb(77, 207, 224); 
            panel3.BackColor = Color.WhiteSmoke;
            logintext.ForeColor = Color.WhiteSmoke;
            passwordtext.ForeColor = Color.FromArgb(77, 207, 224);
            passwordtext.PasswordChar = '*';
            emailtext.ForeColor = Color.WhiteSmoke;
            infoRegistration.Text = "";
        }
        private void emailtext_Click(object sender, EventArgs e)
        {
            if (checkTextbox(emailtext.Text))
                emailtext.Clear();
            panel1.BackColor = Color.WhiteSmoke;
            panel2.BackColor = Color.WhiteSmoke;
            panel3.BackColor = Color.FromArgb(77, 207, 224); 
            logintext.ForeColor = Color.WhiteSmoke;
            passwordtext.ForeColor = Color.WhiteSmoke;
            emailtext.ForeColor = Color.FromArgb(77, 207, 224);
            infoRegistration.Text = "";
        }
        private void signin_Click(object sender, EventArgs e)
        {
            infoRegistration.Text = "";
            if (isValid(emailtext.Text) && PassswordWithLogin(passwordtext.Text, logintext.Text))
            {
                WorkServer workServer = new WorkServer();
                /*workServer.createConnection();*/
                workServer.addUser(logintext.Text, passwordtext.Text, emailtext.Text);
                /*workServer.loseConnection();*/
                this.Hide();
            }
            else
                infoRegistration.Text = "Допущена ошибка при вводе данных.";
        }
        private bool checkTextbox(String text)
        {
            return (text == "Login" || text == "Password" || text == "Email");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private bool isValid(String mail) // Для данной формы нужно проверить есть ли введенная почта в БД
        {
            string pattern = @"[^_+.+][-\w.]+@([A-z0-9][-A-z0-9]+\.)+[A-z]{2,4}$";
            Match match = Regex.Match(mail, pattern, RegexOptions.IgnoreCase);
            return match.Success;
        }

        private bool PassswordWithLogin(String password, String login)
        {
            return (password != "" && login != "");
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;   
        }
    }
}
