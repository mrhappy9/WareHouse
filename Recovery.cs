using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;


namespace Course1
{
    public partial class Recovery : Form
    {
        public Recovery()
        {
            InitializeComponent();
        }

        WorkServer workServerRecovery = new WorkServer();

        private void emailtext_Click(object sender, EventArgs e)
        {
            if (checkTextbox(emailtext.Text))
                emailtext.Clear();
            panel1.BackColor = Color.FromArgb(77, 207, 224); 
            panel2.BackColor = Color.WhiteSmoke;
            panel3.BackColor = Color.WhiteSmoke;
            emailtext.ForeColor = Color.FromArgb(77, 207, 224); 
            newpasswordtext.ForeColor = Color.WhiteSmoke;
            repeatpasswordtext.ForeColor = Color.WhiteSmoke;
            infoRecovery.Text = "";

        }
        private void newpasswordtext_Click(object sender, EventArgs e)
        {
            if (checkTextbox(newpasswordtext.Text))
                newpasswordtext.Clear();
            panel1.BackColor = Color.WhiteSmoke;
            panel2.BackColor = Color.FromArgb(77, 207, 224);
            panel3.BackColor = Color.WhiteSmoke;
            emailtext.ForeColor = Color.WhiteSmoke;
            newpasswordtext.ForeColor = Color.FromArgb(77, 207, 224);
            newpasswordtext.PasswordChar = '*';
            repeatpasswordtext.ForeColor = Color.WhiteSmoke;
            infoRecovery.Text = "";
        }

        private void repeatpasswordtext_Click(object sender, EventArgs e)
        {
            if (checkTextbox(repeatpasswordtext.Text))
                repeatpasswordtext.Clear();
            panel1.BackColor = Color.WhiteSmoke;
            panel2.BackColor = Color.WhiteSmoke;
            panel3.BackColor = Color.FromArgb(77, 207, 224);
            emailtext.ForeColor = Color.WhiteSmoke;
            newpasswordtext.ForeColor = Color.WhiteSmoke;
            repeatpasswordtext.ForeColor = Color.FromArgb(77, 207, 224);
            repeatpasswordtext.PasswordChar = '*';
            infoRecovery.Text = "";
        }
        private bool checkTextbox(String text)
        {
            return (text == "New password" || text == "Repeat password" || text == "Email");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void contin_Click(object sender, EventArgs e)
        {
            infoRecovery.Text = "";
            workServerRecovery.createConnection();
            if (workServerRecovery.CheckEmail(emailtext.Text)) { 
                if (CheckPassword(newpasswordtext.Text, repeatpasswordtext.Text) && isValid(emailtext.Text))
                {
                    workServerRecovery.updatePassword(emailtext.Text, newpasswordtext.Text);
                    SendEmail();
                    emailtext.Text = "";
                    newpasswordtext.Text = "";
                    repeatpasswordtext.Text = "";
                }
                else
                {
                    infoRecovery.Text = "Пароли не совпадают";
                    repeatpasswordtext.Clear();
                    newpasswordtext.Clear();
                }
            }
            else
            {
                infoRecovery.Text = "Проверьте правильность написания почты";
                emailtext.Text = "";
            }
        }

        private void SendEmail()
        {
            MailAddress from = new MailAddress("mrhatet5@mail.ru", "Creator WareHouse");
            MailAddress to = new MailAddress($"{emailtext.Text}");
            MailMessage message = new MailMessage(from, to);

            message.Subject = "Смена пароля";
            message.Body = $"<p>Ваш новый пароль: {newpasswordtext.Text}</p>" +
                           $"<p>Ваш логин: {workServerRecovery.getLogin(emailtext.Text)}</p>";
            message.IsBodyHtml = true;
            workServerRecovery.loseConnection();
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 25);

            smtp.Credentials = new NetworkCredential("mrhatet5@mail.ru", "Ezpzlmnsqz27");
            smtp.EnableSsl = true;
            smtp.Send(message);
            this.Hide();
        }
        
        private bool CheckPassword(String pass1, String pass2)
        {
            return pass1 == pass2;
        }

        private bool isValid(String mail) // Для данной формы нужно проверить есть ли введенная почта в БД
        {
            string pattern = @"[^_+.+][-\w.]+@([A-z0-9][-A-z0-9]+\.)+[A-z]{2,4}$";
            Match match = Regex.Match(mail, pattern, RegexOptions.IgnoreCase);
            return match.Success;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
