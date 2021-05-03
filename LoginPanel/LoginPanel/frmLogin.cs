using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginPanel
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        bool control;
        private void Form1_Load(object sender, EventArgs e)
        {
            control = false;
            pnlRegister.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.Width += 1;
            pictureBox4.Height += 1;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Width -= 1;
            pictureBox4.Height -= 1;
        }

        DataAccess dataAccess = new DataAccess();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string query = "Select * from tblUser where name = @name and password=@password";
            var bytes = new UTF8Encoding().GetBytes(txtPassword.Text);
            var hashBytes = MD5.Create().ComputeHash(bytes);
            bool user = dataAccess.Login(query, new string[] { "name","password" }, new Object[] { txtName.Text, Convert.ToBase64String(hashBytes) });
            if (user)
            {
                MessageBox.Show("Giriş Başarılı!");
            }
            else
            {
                MessageBox.Show("Giriş Başarısız!");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtRegPass.Text == txtRegPass1.Text)
            {
                string query = "Insert into tblUser (name,password) values (@name,@password)";
                var bytes = new UTF8Encoding().GetBytes(txtRegPass.Text);
                var hashBytes = MD5.Create().ComputeHash(bytes);
                bool user = dataAccess.Register(query, new string[] { "name", "password" }, new Object[] { txtRegName.Text, Convert.ToBase64String(hashBytes)});
                if (user)
                {
                    MessageBox.Show("Kayıt işlemi Başarılı!");
                }
                else
                {
                    MessageBox.Show("Kayıt işlemi Başarısız!");
                }
            }
            else
            {
                MessageBox.Show("Şifreler uyuşmuyor. Lütfen tekrar deneyiniz.");
            }

        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            pnlRegister.Show();
            pnlLogin.Hide();
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            pnlLogin.Show();
            pnlRegister.Hide();
        }
    }
}
