using System.Windows;

namespace Mongo
{
    public partial class Popup : Window
    {
        public Popup(EncryptedItem ei)
        {
            InitializeComponent();
            var decrypted = RSA.Decrypt(ei.Text, ei.PrivateKey);
            lblText.Content = ei.Alias;
            tbText.Text = decrypted;
        }
    }
}