using System.Windows;
using System.Windows.Controls;

namespace Mongo
{
    public partial class Item : UserControl
    {
        private Get windowGet;
        
        public Item(EncryptedItem ei, Get windowGet)
        {
            InitializeComponent();
            lblNickname.Content = ei.Alias;
            Tag = ei;
            this.windowGet = windowGet;
        }

        private void BtnGet_OnClick(object sender, RoutedEventArgs e)
        {
            Popup popup = new Popup((EncryptedItem) Tag);
            popup.ShowDialog();
        }

        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            DbConnector connector = new DbConnector();
            connector.Remove((EncryptedItem) Tag);
            windowGet.updateData();
        }
    }
}