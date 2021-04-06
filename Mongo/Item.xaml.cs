using System.Windows;
using System.Windows.Controls;

namespace Mongo
{
    public partial class Item : UserControl
    {
        public Item(EncryptedItem ei)
        {
            InitializeComponent();
            lblNickname.Content = ei.Alias;
            btnGet.Tag = ei;
        }

        private void BtnGet_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                Popup popup = new Popup((EncryptedItem)btn.Tag);
                popup.ShowDialog();
            }
        }
    }
}