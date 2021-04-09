using System.Security.Cryptography;
using System.Windows;

namespace Mongo
{
    public partial class Create : Window
    {
        public Create()
        {
            InitializeComponent();
        }

        private void BtnSend_OnClick(object sender, RoutedEventArgs e)
        {
            var cryptoSerProvider = new RSACryptoServiceProvider(2048);
            var publicKey = RSA.GetStrKey(cryptoSerProvider.ExportParameters(false));
            var privateKey = RSA.GetStrKey(cryptoSerProvider.ExportParameters(true));

            var text = tbMessage.Text;
            var nickname = tbNickname.Text;
            var encryptedText = RSA.Encrypt(text, publicKey);

            DbConnector connector = new DbConnector();
            connector.Insert(new EncryptedItem(encryptedText, privateKey, nickname));

            Close();
        }
    }
}