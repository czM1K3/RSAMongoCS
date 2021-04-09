using System.Security.Cryptography;
using System.Windows;

namespace Mongo
{
    public partial class Create : Window
    {
        private DbConnector connector;
        
        public Create(DbConnector connector)
        {
            InitializeComponent();
            this.connector = connector;
        }

        private void BtnSend_OnClick(object sender, RoutedEventArgs e)
        {
            var cryptoSerProvider = new RSACryptoServiceProvider(2048);
            var publicKey = RSA.GetStrKey(cryptoSerProvider.ExportParameters(false));
            var privateKey = RSA.GetStrKey(cryptoSerProvider.ExportParameters(true));

            var text = tbMessage.Text;
            var nickname = tbNickname.Text;
            var encryptedText = RSA.Encrypt(text, publicKey);

            connector.Insert(new EncryptedItem(encryptedText, privateKey, nickname));

            Close();
        }
    }
}