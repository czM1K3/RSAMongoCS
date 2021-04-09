using System.Windows;
using System.Windows.Controls;

namespace Mongo
{
    public partial class Item : UserControl
    {
        private Get windowGet;
        private DbConnector connector;
        
        public Item(EncryptedItem ei, Get windowGet, DbConnector connector)
        {
            InitializeComponent();
            lblNickname.Content = ei.Alias;
            Tag = ei;
            this.windowGet = windowGet;
            this.connector = connector;
        }

        private void BtnGet_OnClick(object sender, RoutedEventArgs e)
        {
            Popup popup = new Popup((EncryptedItem) Tag);
            popup.ShowDialog();
        }

        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            connector.Remove((EncryptedItem) Tag);
            windowGet.updateData();
        }
    }
}