using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course1
{
    public class Users
    {
        private string login;
        private string password;
        private string email;

        public Users(string login, string password, string email)
        {
            this.login = login;
            this.password = password;
            this.email = email;
        }

        public Users() { login = password = email = ""; }
        public String getLogin() { return login; }
        public String getPassword() { return password; }
        public String getEmail() { return email; }
        public Users giveUsers() { return this; }
        public void setLogin(string login) { this.login = login; }
        public void setPassword(string password) { this.password = password; }
        public void setEmail(string email) { this.email = email; }
    }

    class ManageUsers : Users
    {
        private List<Users> collectionUsers = new List<Users>();
        public ManageUsers(string login, string password, string email) : base(login, password, email)
        {
            collectionUsers.Add(base.giveUsers());
        }
        public List<Users> GetUsers() { return collectionUsers; }
    }
}
