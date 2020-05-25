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
    public partial class Form1 : Form
    {
        AdminForm adminForm;
        Storekeeper storekeeperForm;
        public Form1()
        {
            InitializeComponent();
            adminForm = new AdminForm(this);
            storekeeperForm = new Storekeeper(this);
        }

        static private string admin = "admin";
        static private string adminPassword = "%%a%%d%%m%%i%%n%%";

        static private string storekeeper = "keep";
        static private string storekeeperPassword = "keep";

        SignUp signupForm = new SignUp();
        Recovery recovery = new Recovery();
        WorkServer workserver = new WorkServer();
        MainInterface mainInterface;
        ManageUsers managerOfUsers;
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void logintext_Click(object sender, EventArgs e)
        {
            setWarningLabel(false);
            if (checkTextbox(logintext.Text))
                logintext.Clear();
            logintext.ForeColor = Color.FromArgb(77, 207, 224);
            passwordtext.ForeColor = Color.WhiteSmoke;
            panel1.BackColor = Color.FromArgb(77, 207, 224);
            panel2.BackColor = Color.WhiteSmoke;
        }

        private void passwordtext_Click(object sender, EventArgs e)
        {
            setWarningLabel(false);
            if (checkTextbox(passwordtext.Text))
                passwordtext.Clear();
            passwordtext.ForeColor = Color.FromArgb(77, 207, 224);
            passwordtext.PasswordChar = '*';
            logintext.ForeColor = Color.WhiteSmoke;
            panel2.BackColor = Color.FromArgb(77, 207, 224);
            panel1.BackColor = Color.WhiteSmoke;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private bool checkTextbox(String text)
        {
            return (text == "Login" || text == "Password");
        }


        private void signupbutton_Click(object sender, EventArgs e)
        {
            setWarningLabel(false);
            signupForm.Top = this.Top;
            signupForm.Left = this.Left;
            timer1.Start();
            signupForm.Show();
            this.TopMost = true;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void forgotPassword_Click(object sender, EventArgs e)
        {
            /* recovery.*/
            setWarningLabel(false);
            recovery.Height = this.Height;
            recovery.Top = this.Top;
            recovery.Left = this.Left;
            timer3.Start();
            recovery.Show();
            this.TopMost = true;
        }
        private void cleanTextBoxes()
        {
            logintext.Text = "Login";
            passwordtext.Text = "";
        }
        private void gobutton_Click(object sender, EventArgs e)
        {
            workserver.createConnection();
            if (PassswordWithLogin(logintext.Text, passwordtext.Text) &&
                workserver.logIn(logintext.Text, passwordtext.Text))
            {
                managerOfUsers = new ManageUsers(logintext.Text, passwordtext.Text,
                                                 workserver.getEmailForManageUser(logintext.Text, passwordtext.Text));
                mainInterface = new MainInterface(logintext.Text, this);
                workserver.loseConnection();
                cleanTextBoxes();
                this.Hide();
                mainInterface.Show();
            }
            else if (PassswordWithLogin(logintext.Text, passwordtext.Text) &&
                    logintext.Text == admin && passwordtext.Text == adminPassword)
            {
                cleanTextBoxes();
                this.Hide();
                adminForm.Show();
            }
            else if (PassswordWithLogin(passwordtext.Text, logintext.Text) && logintext.Text == storekeeper && passwordtext.Text == storekeeperPassword)
            {
                cleanTextBoxes();
                this.Hide();
                storekeeperForm.Show();
            }
            else { setWarningLabel(true); passwordReset(); }
            workserver.loseConnection();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            signupForm.Left += 10;
            if (signupForm.Left > this.Left + this.Width)
            {
                timer1.Stop();
                this.TopMost = false;
                signupForm.TopMost = true;
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            signupForm.Left -= 10;
            if (signupForm.Left <= this.Left)
            {
                timer2.Stop();
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            recovery.Left += 10;
            if (recovery.Left > this.Left+this.Width)
            {
                timer3.Stop();
                this.TopMost = false;
                recovery.TopMost = true;
                timer4.Start();
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            recovery.Left -= 10;
            if (recovery.Left <= this.Left)
                timer4.Stop();
        }

        private bool PassswordWithLogin(String password, String login)
        {
            return (password != "" && login != "");
        }

        private void setWarningLabel(bool setting)
        {
            if (setting)
                warningLabel.Text = "Неправильно введен логин или пароль";
            else
                warningLabel.Text = "";
        }
        
        private void passwordReset() { passwordtext.Text = ""; }

        public void exit()
        {
            this.Close();
        }
    }
}
