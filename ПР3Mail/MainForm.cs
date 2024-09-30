using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using ПР3Mail.UsersClasses;
using System.Net.Http.Headers;

namespace ПР3Mail
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
            string.IsNullOrWhiteSpace(textBoxName.Text) ||
            string.IsNullOrWhiteSpace(textBoxSubject.Text) ||
            string.IsNullOrWhiteSpace(textBoxBody.Text))
            {
                MessageBox.Show("Заполните поля!");
                return;
            }
            string smtp = "smtp.mail.ru";
            StringPair fromInfo = new StringPair("16.11ufd@mail.ru", "Гаврильченко Ксения Ивановна");
            string password = "izbSbtjFV4YfdVPuA3Ay";

            StringPair toInfo = new StringPair(textBoxEmail.Text, textBoxName.Text);
            string subject = textBoxSubject.Text;
            string body = $"{DateTime.Now} \n" +
                $"{Dns.GetHostName()} \n" +
                $"{Dns.GetHostAddresses(Dns.GetHostName()).First()} \n" +
                $"{textBoxBody.Text}";
            InfoEmailSending info =
                new InfoEmailSending(smtp, fromInfo, password, toInfo, subject, body);
            SendingEmail sendingEmail = new SendingEmail(info);
            sendingEmail.Send();
            MessageBox.Show("Письмо отправлено!");
            foreach (TextBox textBox in Controls.OfType<TextBox>())
                textBox.Text = "";
        }
    }
}
